using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gestionDePiletaSportClub.DAL;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.ViewModels;
using gestionDePiletaSportClub.Dtos;
using System.Data.Entity;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace gestionDePiletaSportClub.Controllers.Api
{
    public class EnrollmentsController : ApiController
    {
        private ApplicationDBContext _context;
        private IMapper mapper;
        public EnrollmentsController()
        {
            _context = ApplicationDBContext.Create();
            mapper = Mapper.Instance;
        }

        // GET /api/enrollments
        //[Authorize]
        [HttpGet]
        [Route("api/enrollments/")]
        public async Task<IEnumerable<Enrollment>> GetEnrollments(byte? planId = null, byte? levelId = null, string fromDate=null, string toDate = null) {

            var query = _context.Enrollment
                .Include(e=> e.Actividad)
                .AsQueryable();
            if (planId != null) {
                query = query.Where(e => e.Actividad.MembershipTypeId == planId);
            }
            if (levelId != null) {
                query = query.Where(e => e.Actividad.LevelId == levelId);
            }
            if (fromDate != null) {
                query = query.Where(e => e.Actividad.Schedule.CompareTo(fromDate)>=0);
            }if (toDate != null) {
                query = query.Where(e => e.Actividad.Schedule.CompareTo(toDate)<=0);
            }


            var enrollments = await query.ToListAsync();

            return enrollments;

        }

        //GET /api/enrollments/{Id}
        [HttpGet]
        [Route("api/enrollments/{Id}")]
        public async Task<Enrollment> GetEnrollment(int Id) {
            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(e => e.Id == Id);
            if (enrollment == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return enrollment;

        }

        //DEL /api/enrollments/{Id}
        [HttpDelete]
        [Route("api/enrollments/{Id}")]
        public async Task<IHttpActionResult> DeleteEnrollment(int Id) {
            var enrollment = await _context.Enrollment
                .Include(e => e.ApplicationUser)
                .Include(e => e.Actividad)
                .SingleOrDefaultAsync(e => e.Id == Id);
            if (enrollment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            enrollment.ApplicationUser.AmountOfPendingActivities++;
            enrollment.Actividad.PendingEnrollment++;
            _context.SaveChanges();
            _context.Enrollment.Remove(enrollment);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/enrollments/{Id}")]
        public async Task<IHttpActionResult> UpdateEnrollment(int Id, [FromBody] EnrollmentUpdateDto enrollmentUpdateDto)
        {
            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(e => e.Id == Id);
            if (enrollment == null || enrollment.Id != enrollmentUpdateDto.Id) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            enrollment.EnrollmentStatusId = enrollmentUpdateDto.Status;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("api/enrollments/")]
        public async Task<IHttpActionResult> CreateEnrollment([FromBody] EnrollmentCreationDto enrollmentCreationDto)
        {

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == enrollmentCreationDto.UserId);
            if (user == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var activity = await _context.Actividad.SingleOrDefaultAsync(a => a.Id == enrollmentCreationDto.ActivityId);
            if (activity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (user.LevelId != activity.LevelId || user.MembershipTypeId != activity.MembershipTypeId) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkEnrollment = await _context.Enrollment.SingleOrDefaultAsync(e => e.ApplicationUserId == enrollmentCreationDto.UserId && e.ActividadId == enrollmentCreationDto.ActivityId);
            if (checkEnrollment != null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var enrollment = new Enrollment()
            {
                ApplicationUserId = user.Id,
                ActividadId = activity.Id,
                Schedule = Convert.ToDateTime(activity.Schedule),
                EnrollmentStatusId = EnrollmentStatus.Pendiente
            };

            _context.Enrollment.Add(enrollment);
            await _context.SaveChangesAsync();
            return Ok();
        }



    }
}
