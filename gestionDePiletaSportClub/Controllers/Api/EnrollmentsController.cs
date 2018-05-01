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
        [Authorize]
        public IEnumerable<Enrollment> GetEnrollments() {

            var enrollments = _context.Enrollment.ToList();

            return enrollments;

        }

        //GET /api/enrollments/{Id}

        public Enrollment GetEnrollment(int Id) {
            var enrollment = _context.Enrollment.SingleOrDefault(e => e.Id == Id);

            return enrollment;

        }

        //DEL /api/enrollments/{Id}
        [HttpDelete]
        public void DeleteEnrollment(int Id) {
            var enrollment = _context.Enrollment
                .Include(e => e.ApplicationUser)
                .Include(e => e.Actividad)
                .SingleOrDefault(e => e.Id == Id);
            if (enrollment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            enrollment.ApplicationUser.AmountOfPendingActivities++;
            enrollment.Actividad.PendingEnrollment++;
            _context.SaveChanges();
            _context.Enrollment.Remove(enrollment);
            _context.SaveChanges();
        }

        [HttpPut]
        //PUT /api/enrollments/{Id}/{status}
        [Route("api/enrollments/{Id}/{Status}")]
        public void UpdateEnrollment(int Id, byte Status)
        {
            var enrollment = _context.Enrollment.SingleOrDefault(e => e.Id == Id);
            enrollment.EnrollmentStatusId = Status;
            _context.SaveChanges();

            

        }




    }
}
