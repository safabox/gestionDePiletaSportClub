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
        [Route("api/enrollments/")]
        public async Task<IEnumerable<Enrollment>> GetEnrollments() {

            var enrollments = await _context.Enrollment.ToListAsync();

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




    }
}
