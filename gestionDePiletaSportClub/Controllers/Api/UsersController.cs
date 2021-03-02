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

namespace gestionDePiletaSportClub.Controllers.Api
{
   
    public class UsersController : ApiController
    {
        private ApplicationDBContext _context;
        private IMapper mapper;
        public UsersController() {
            _context = ApplicationDBContext.Create();
            mapper = Mapper.Instance;
        }
        //GET users
        public IEnumerable<UserDto> GetUsers() {
            var users = _context.Users.Where(u => u.Roles.FirstOrDefault().RoleId == Rol.Socio)
               .Include(u => u.MembershipType)
               .Include(u => u.PaymentType)
               .Include(u => u.Level).ToList().Select(Mapper.Map<ApplicationUser, UserDto>); 
            return users;
        }

        //GET Users/{id}
        public UserDto GetUser(string Id)
        {
            var user = _context.Users.SingleOrDefault(C => C.Id == Id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<ApplicationUser, UserDto>(user);
        }

        

        //PUT Users/{id}
        [HttpPut]
        public void UpdateUser(string Id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var userInDb = _context.Users.SingleOrDefault(c => c.Id == Id);
            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            userInDb.Id = Id;
            Mapper.Map<UserDto, ApplicationUser>(userDto, userInDb);

            _context.SaveChanges();
        }
        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteUser(string Id) {
            var user = _context.Users.Single(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            
        }



        //UPDATE /api/users/{Id}/bloquear
        [HttpPut]
        [Route("api/users/{Id}/bloquear")]
        public void LockUser(string Id)
        {
            var user = _context.Users.Single(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.LockoutEndDateUtc = DateTime.Today.AddYears(1000);
            _context.SaveChanges();

        }

        //UPDATE /api/users/{Id}/desbloquear
        [HttpPut]
        [Route("api/users/{Id}/desbloquear")]
        public void UnlockUser(string Id)
        {
            var user = _context.Users.Single(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.LockoutEndDateUtc = null;
            _context.SaveChanges();

        }


        //UPDATE /api/users/{Id}/pagar/{cantidad de clases}
        [HttpPut]
        [Route("api/users/{Id}/pagar/{Clases}")]
        public void ProcesarPago(string Id,byte clases)
        {
            var user = _context.Users.Single(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.AmountOfPendingActivities = clases;
            user.AmountOfActivities = clases;
            user.LastPaymentDate = DateTime.Now.ToString("s");
            user.DueDate = DateTime.Now.AddMonths(1).ToString("s");

            _context.SaveChanges();

        }



        //GET User/{id}/activities
        [Route("api/users/{Id}/activities")]
        public IEnumerable<EventDto> GetActivities(string Id)
        {

            var user = _context.Users.SingleOrDefault(u => u.Id == Id);
            DateTime from = DateTime.Parse(user.LastPaymentDate);
            DateTime to = DateTime.Parse(user.DueDate);
            List<EventDto> events = new List<EventDto>();
            var activities = _context.Actividad
                //.Where(c => DateTime.Parse(c.Schedule) >= from && DateTime.Parse(c.Schedule) <= to)
                .Where(c => c.LevelId == user.LevelId && c.MembershipTypeId == user.MembershipTypeId)
                .Where(c => c.PendingEnrollment > 0)
                .Where (c=> c.EstadoActividadId != EstadoActividad.Cancelada)
                .Include(c=> c.EstadoActividad)
                .Include(c => c.TipoActividad)
                .Include(c=>c.Level)
                .Include(c=>c.MembershipType)
                .ToList().Select(Mapper.Map<Actividad, ActivityDto>);

            var enrollments = _context.Enrollment.Where(e => e.ApplicationUser.Id == Id).Select(e => e.ActividadId);
            
            foreach (ActivityDto activity in activities) {
                var activityDate= DateTime.Parse(activity.Schedule, new System.Globalization.CultureInfo("es-AR"));
                if (activityDate >= from && activityDate <= to)
                {
                    EventDto userEvent = new EventDto(activity);
                    if (enrollments.Contains(activity.Id))
                    {

                        userEvent.BackgroundColor = "#17D14E";
                    }
                    events.Add(userEvent);
                }
            }
            
            
            return events.ToArray();


        }



        [Route("api/users/{userId}/activities/{activityId:int}/enrollments")]
        
        public EventDto GetEnrollment(string userId, int activityId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var activity = _context.Actividad.SingleOrDefault(a => a.Id == activityId);
            if (user == null || activity == null)
            {
                return null;
            }
            var enrollment = _context.Enrollment.SingleOrDefault(e => e.ApplicationUserId == user.Id && e.ActividadId == activity.Id);

            if (enrollment != null)
            {
                return null;
            }
            return new EventDto(enrollment);
            
        }


        [Route("api/users/{userId}/activities/{activityId:int}/enrollments")]
        [HttpPost]
        public IHttpActionResult CreateEnrollment(string userId, int activityId) {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var activity = _context.Actividad.SingleOrDefault(a => a.Id == activityId);
            if (user == null || activity == null)
            {
                return BadRequest();
            }
            try
            {

                if (user.AmountOfPendingActivities <= 0) {
                    return BadRequest();
                }

                var enrollmentCheck = _context.Enrollment.SingleOrDefault(e => e.ApplicationUserId == user.Id && e.ActividadId == activity.Id);

                if (enrollmentCheck != null) {
                    return BadRequest();
                }

                var enrollment = new Enrollment()
                {
                    ApplicationUserId = user.Id,
                    ActividadId = activity.Id,
                    EnrollmentStatusId = EnrollmentStatus.Pendiente,
                    Schedule = DateTime.Parse(activity.Schedule)
                };
                _context.Enrollment.Add(enrollment);
                user.AmountOfPendingActivities--;
                activity.PendingEnrollment--;
                _context.SaveChanges();
            }
            catch {
                return BadRequest();
            }
            return Ok();
        }

        [Route("api/users/{userId}/enrollments")]
        public async Task<IEnumerable<EventDto>> GetEnrollments(string userId, string fromDate=null, string toDate = null) {
            List<EventDto> events = new List<EventDto>();
            var query = _context.Enrollment
                .Include(e => e.EnrollmentStatus)
                .Include(e => e.Actividad.TipoActividad)
                .Include(e => e.Actividad.Level)
                .Include(e => e.Actividad.MembershipType)
                .AsQueryable();
            query = query.Where(e => e.ApplicationUserId == userId);
            if (fromDate != null)
            {
                var from = Convert.ToDateTime(fromDate);
                query = query.Where(e => e.Schedule >= from);
            }if (toDate != null)
            {
                var to = Convert.ToDateTime(toDate);
                query = query.Where(e => e.Schedule >= to);
            }

            var enrollments = await query.ToListAsync();    
            foreach (Enrollment e in enrollments) {
                events.Add(new EventDto(e));
            }
            return events.ToArray();
        }

        [Route("api/users/{userId}/enrollments/{status}")]
        public IEnumerable<EventDto> GetEnrollments(string userId,byte status)
        {
            List<EventDto> events = new List<EventDto>();
            var enrollments = _context.Enrollment
                .Where(e => e.ApplicationUserId == userId)
                .Where(e => e.EnrollmentStatusId == status)
                .Include(e => e.EnrollmentStatus)
                .Include(e => e.Actividad.TipoActividad)
                .Include(e => e.Actividad.Level)
                .Include(e => e.Actividad.MembershipType)
                .OrderBy(e=>e.Schedule)
                .ToList();
            foreach (Enrollment e in enrollments)
            {
                events.Add(new EventDto(e));
            }
            return events.ToArray();
        }




    }
}
