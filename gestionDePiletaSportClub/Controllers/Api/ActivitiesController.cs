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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Globalization;

namespace gestionDePiletaSportClub.Controllers.Api
{
    public class ActivitiesController : ApiController
    {
        private ApplicationDBContext _context;
        private IMapper mapper;
        public ActivitiesController()
        {
            _context = ApplicationDBContext.Create();
            mapper = Mapper.Instance;
        }


        //GET /api/activities
        public async Task<IEnumerable<EventDto>> GetActivities(int? planId = null, int? levelId = null, string fromDate = null, string toDate = null) {

            var query = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.Level)
                .Include(a => a.MembershipType)
                .Include(a => a.EstadoActividad);
            if (planId != null && planId > 0) {
                query = query.Where(a => a.MembershipTypeId == planId);
            }
            if (levelId != null && levelId > 0) {
                query = query.Where(a => a.LevelId == levelId);
            }
            if (fromDate != null) {
                var from = Convert.ToDateTime(fromDate);
                query = query.Where(a => a.Schedule.CompareTo(fromDate) >= 0);
            }
            if (toDate != null) {
                var to = Convert.ToDateTime(toDate);
                query = query.Where(a => a.Schedule.CompareTo(toDate) <= 0);
            }


            var activitiesDb = await query.ToListAsync();
            var activities = Mapper.Map<List<Actividad>, List<ActivityDto>>(activitiesDb);

            List<EventDto> events = new List<EventDto>();

            foreach (ActivityDto a in activities) {

                events.Add(new EventDto(a));
            }
            return events.ToArray();
        }

        //GET /api/activities/{id}
        [HttpGet]
        [Route("api/activities/{Id}")]
        public async Task<EventDto> GetActivity(int Id)
        {
            var activity = await _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.Level)
                .Include(a => a.MembershipType)
                .Include(a => a.EstadoActividad)
                .SingleOrDefaultAsync(a => a.Id == Id);
            if (activity == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return new EventDto(Mapper.Map<Actividad, ActivityDto>(activity));
        }


        [HttpPut]
        [Route("api/activities/{Id}")]
        public async Task<IHttpActionResult> UpdateActivity(int Id)
        {
            var activity = await _context.Actividad
                .SingleOrDefaultAsync(a => a.Id == Id);

            if (activity == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            activity.EstadoActividadId = EstadoActividad.Abierta;
            _context.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        [Route("api/activities/{Id}")]
        public async Task<IHttpActionResult> CancelActivity(int Id)
        {
            var activity = await _context.Actividad
                .Include(a=>a.TipoActividad)
                .Include(a=>a.Level)
                .Include(a=>a.MembershipType)
                .SingleOrDefaultAsync(a => a.Id == Id);
            if (activity == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            activity.EstadoActividadId = EstadoActividad.Cancelada;

            var enrollments = await _context.Enrollment.Where(e => e.ActividadId == activity.Id).Include(e=>e.ApplicationUser).ToListAsync();
            List<string> emailList = new List<string>();
            foreach (Enrollment e in enrollments) {
                e.ApplicationUser.AmountOfPendingActivities++;
                emailList.Add(e.ApplicationUser.Email);
            }
            if (enrollments.Count > 0)
            {
                string emails = string.Join(",", emailList.ToArray());
                 InformarCancelarActividad(emails, activity);
                _context.Enrollment.RemoveRange(enrollments);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void InformarCancelarActividad(string email, Actividad activity)
        {
            EmailService e = new EmailService();
            IdentityMessage message = new IdentityMessage();
            message.Subject = "[Sport Club] Clase " + activity.Schedule.ToString()+" cancelada ";
            message.Body = String.Format("La clase de {0} para el nivel {1} de {2} ha sido cancelada. La misma no sera descontada de su plan de actividades.<br/> " +
                "Disculpe las molestias ocasionadas <br/>" +
                "<strong>Equipo de Sport Club </strong>",activity.TipoActividad.Name, activity.Level.Name,activity.MembershipType.Name);
            message.Destination = email;
            e.Send(message);
        }
    }
}
