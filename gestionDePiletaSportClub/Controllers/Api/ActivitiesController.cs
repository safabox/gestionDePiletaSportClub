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
        public IEnumerable<EventDto> GetActivities() {
            var activities = _context.Actividad
                .Include(a=>a.TipoActividad)
                .Include(a=>a.Level)
                .Include(a=>a.MembershipType)
                .Select(Mapper.Map<Actividad, ActivityDto>);
            List<EventDto> events = new List<EventDto>();

            foreach (ActivityDto a in activities) {
                events.Add(new EventDto(a));
            }
            return events.ToArray();
        }

        //GET /api/activities/{id}
        public EventDto GetActivity(int Id)
        {
            var activity = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.Level)
                .Include(a => a.MembershipType)
                .SingleOrDefault(a => a.Id == Id);

            return new EventDto(Mapper.Map<Actividad, ActivityDto>(activity));
        }


        [HttpPut]
        [Route("api/activities/{Id}/abrir")]
        public void OpenActivity(int Id)
        {
            var activity = _context.Actividad
                .SingleOrDefault(a => a.Id == Id);

            activity.EstadoActividadId = EstadoActividad.Abierta;
            _context.SaveChanges();
        }



        [HttpPut]
        [Route("api/activities/{Id}/cancelar")]
        public void CancelActivity(int Id)
        {
            var activity = _context.Actividad
                .Include(a=>a.TipoActividad)
                .Include(a=>a.Level)
                .Include(a=>a.MembershipType)
                .SingleOrDefault(a => a.Id == Id);

            activity.EstadoActividadId = EstadoActividad.Cancelada;

            var enrollments = _context.Enrollment.Where(e => e.ActividadId == activity.Id).Include(e=>e.ApplicationUser).ToList();
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
            _context.SaveChanges();
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
