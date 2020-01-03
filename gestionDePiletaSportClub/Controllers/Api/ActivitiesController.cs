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
        public IEnumerable<EventDto> GetActivities() {
            var activities = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.Level)
                .Include(a => a.MembershipType)
                .Select(Mapper.Map<Actividad, ActivityDto>);
                //.Where(a=> DateTime.Parse(a.Schedule) >= new DateTime (2018,03,28,9,0,0) && DateTime.Parse(a.Schedule) <= new DateTime(2018, 03, 28, 23, 59, 59));


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

        //GET User/{id}/activities
        [Route("api/activities/mes")]
        public IEnumerable<EventDisponibilidadDto> GetActivitiesDelMes()
        {

            DateTime from = DateTime.Now;
            DateTime to = DateTime.Now.AddMonths(1);
            List<EventDisponibilidadDto> events = new List<EventDisponibilidadDto>();
            var activities = _context.Actividad
                //.Where(c => DateTime.Parse(c.Schedule) >= from && DateTime.Parse(c.Schedule) <= to)
                // .Where(c => c.LevelId == user.LevelId && c.MembershipTypeId == user.MembershipTypeId)
                                
                .Include(c => c.EstadoActividad)
                .Include(c => c.TipoActividad)
                .Include(c => c.Level)
                .Include(c => c.MembershipType)
                .Select(Mapper.Map<Actividad, ActivityDto>)
                .Where(c => c.EstadoActividadId != EstadoActividad.Cancelada && DateTime.Parse(c.Schedule) >= from && DateTime.Parse(c.Schedule) <= to);

            foreach (ActivityDto activity in activities)
            {
                var activityDate = DateTime.Parse(activity.Schedule, new System.Globalization.CultureInfo("es-AR"));
                
                EventDisponibilidadDto userEvent = new EventDisponibilidadDto(activity);
                events.Add(userEvent);
                
            }


            return events.ToArray();


        }

        //GET /api/activities/{year}/{month}/{day}
        [Route("api/activities/{year}/{month}/{day}")]
        public IEnumerable<EventDto> GetActivities(int year,int month, int day)
        {
            var activities = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.Level)
                .Include(a => a.MembershipType)
                .Select(Mapper.Map<Actividad, ActivityDto>)
                .Where(a=> DateTime.Parse(a.Schedule) >= new DateTime (year,month,day,9,0,0) && DateTime.Parse(a.Schedule) <= new DateTime(year, month,day, 23, 59, 59));


            List<EventDto> events = new List<EventDto>();

            foreach (ActivityDto a in activities)
            {

                events.Add(new EventDto(a));
            }
            return events.ToArray();
        }


    }
}
