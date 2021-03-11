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
using gestionDePiletaSportClub.Dtos.Payment;
using System.Globalization;

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
        public async Task<IEnumerable<UserDto>> GetUsers() {
            var users = await _context.Users.Where(u => u.Roles.FirstOrDefault().RoleId == Rol.Socio)
               .Include(u => u.MembershipType)
               .Include(u => u.PaymentType)
               .Include(u => u.Level)
               .ToListAsync();
                
            return Mapper.Map<List<UserDto>>(users); 
        }

        //GET Users/{id}
        public async Task<UserDto> GetUser(string Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(C => C.Id == Id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<ApplicationUser, UserDto>(user);
        }

        

        //PUT Users/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(string Id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userInDb = await _context.Users.SingleOrDefaultAsync(c => c.Id == Id);
            if (userInDb == null)
                NotFound();
            userInDb.Id = Id;
            Mapper.Map<UserDto, ApplicationUser>(userDto, userInDb);

            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/customer/1
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(string Id) {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
            
        }



        //UPDATE /api/users/{Id}/bloquear
        [HttpPut]
        [Route("api/users/{Id}/bloquear")]
        public async Task<IHttpActionResult> LockUser(string Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.LockoutEndDateUtc = DateTime.Today.AddYears(1000);
            _context.SaveChanges();
            return Ok();
        }

        //UPDATE /api/users/{Id}/desbloquear
        [HttpPut]
        [Route("api/users/{Id}/desbloquear")]
        public async Task<IHttpActionResult> UnlockUser(string Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.LockoutEndDateUtc = null;
            _context.SaveChanges();
            return Ok();
        }


        //UPDATE /api/users/{Id}/pagar/{cantidad de clases}
        [HttpPut]
        [Route("api/users/{Id}/pagar/{Clases}")]
        public async Task<IHttpActionResult> ProcesarPago(string Id,byte clases)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return NotFound();
            }
            user.AmountOfPendingActivities = clases;
            user.AmountOfActivities = clases;
            user.LastPaymentDate = DateTime.Now.ToString("s");
            user.DueDate = DateTime.Now.AddMonths(1).ToString("s");

            _context.SaveChanges();
            return Ok();
        }



        //GET User/{id}/activities
        [Route("api/users/{Id}/activities")]
        public async Task<IEnumerable<EventDto>> GetActivities(string Id, string fromDate = null, string toDate = null)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            List<EventDto> events = new List<EventDto>();

            var activitiesDb = await _context.Actividad
                .Where(c => c.LevelId == user.LevelId && c.MembershipTypeId == user.MembershipTypeId)
                .Where(c => c.PendingEnrollment > 0)
                .Where(c => c.EstadoActividadId != EstadoActividad.Cancelada)
                .Where(a => a.Schedule.CompareTo(user.LastPaymentDate) >= 0)
                .Where(a => a.Schedule.CompareTo(user.DueDate) <= 0)
                .Include(c => c.EstadoActividad)
                .Include(c => c.TipoActividad)
                .Include(c => c.Level)
                .Include(c => c.MembershipType)
                .ToListAsync();
            
            var activities = Mapper.Map<List<ActivityDto>>(activitiesDb);

            var enrollments = await _context.Enrollment.Where(e => e.ApplicationUser.Id == Id).Select(e => e.ActividadId).ToListAsync();
            
            foreach (ActivityDto activity in activities) {
                EventDto userEvent = new EventDto(activity);
                if (enrollments.Contains(activity.Id))
                {
                    userEvent.BackgroundColor = "#17D14E";
                }
                events.Add(userEvent);
            }
                       
            return events;


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
        public async Task<IHttpActionResult> CreateEnrollment(string userId, int activityId) {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var activity = await _context.Actividad.SingleOrDefaultAsync(a => a.Id == activityId);
            if (user == null || activity == null)
            {
                return BadRequest();
            }
            try
            {

                if (user.AmountOfPendingActivities <= 0 || activity.PendingEnrollment <=0) {
                    return BadRequest();
                }

                var enrollmentCheck = await _context.Enrollment.SingleOrDefaultAsync(e => e.ApplicationUserId == user.Id && e.ActividadId == activity.Id);

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

                if (user.AmountOfPendingActivities > 0)
                {
                    user.AmountOfPendingActivities--;
                }
                if (activity.PendingEnrollment > 0)
                {
                    activity.PendingEnrollment--;
                }
                
                await _context.SaveChangesAsync();
            }
            catch {
                return BadRequest();
            }
            return Ok();
        }

        [Route("api/users/{userId}/enrollments")]
        public async Task<IEnumerable<EventDto>> GetEnrollments(string userId, string fromDate=null, string toDate = null, byte? status = null) {
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
            if (status != null) {
                query = query.Where(e => e.EnrollmentStatusId == status);
            }


            var enrollments = await query.ToListAsync();    
            foreach (Enrollment e in enrollments) {
                events.Add(new EventDto(e));
            }
            return events.ToArray();
        }
        [Route("api/users/{userId}/payments")]
        [HttpPost]
        public async Task<IHttpActionResult> ProcessNewPayment(string userId, [FromBody] ProcessNewPaymentDto paymentDto) {

            var applicationUser = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (applicationUser == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            try
            {
                var dueDate = DateTime.Parse(paymentDto.DueDate);
            }
            catch {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            applicationUser.AmountOfActivities = paymentDto.AmountOfActivities;
            applicationUser.AmountOfPendingActivities = paymentDto.AmountOfActivities;
            applicationUser.LastPaymentDate = DateTime.Now.ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern);
            applicationUser.DueDate = paymentDto.DueDate;

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
