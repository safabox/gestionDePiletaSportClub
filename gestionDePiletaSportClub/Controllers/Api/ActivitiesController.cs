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
            var activities = _context.Actividad.Include(a=>a.TipoActividad).Select(Mapper.Map<Actividad, ActivityDto>);
            List<EventDto> events = new List<EventDto>();

            foreach (ActivityDto a in activities) {
                events.Add(new EventDto(a));
            }
            return events.ToArray();
        }

        //GET /api/activities/{id}
        public EventDto GetActivity(int Id)
        {
            var activity = _context.Actividad.Include(a => a.TipoActividad).SingleOrDefault(a => a.Id == Id);

            return new EventDto(Mapper.Map<Actividad, ActivityDto>(activity));
        }

        
        [HttpPut]
        [Route("api/activities/{Id}/cancelar")]
        public void UpdateUser(int Id)
        {
            var activity = _context.Actividad.SingleOrDefault(a => a.Id == Id);

            activity.EstadoActividadId = EstadoActividad.Cancelada;

            var enrollments = _context.Enrollment.Where(e => e.ActividadId == activity.Id).Include(e=>e.ApplicationUser).ToList();

            foreach (Enrollment e in enrollments) {
                e.ApplicationUser.AmountOfPendingActivities++;
                //AVISAR QUE LA CLASE FUE CANCELADA
                
            }
            _context.Enrollment.RemoveRange(enrollments);

            _context.SaveChanges();
        }



    }
}
