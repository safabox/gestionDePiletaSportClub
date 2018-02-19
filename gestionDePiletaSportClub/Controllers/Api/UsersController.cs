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

        //GET User/{id}/activities

        [Route("api/users/{Id}/activities")]
        public IEnumerable<EventDto> getActivities(string Id)
        {

            var user = _context.Users.SingleOrDefault(u => u.Id == Id);
            DateTime from = user.LastPaymentDate.Value;
            DateTime to = user.DueDate.Value;
            List<EventDto> events = new List<EventDto>();
            var activities = _context.Actividad.Where(c => c.Schedule >= from && c.Schedule <= to).
                Where(c => c.LevelId == user.LevelId && c.MembershipTypeId == user.MembershipTypeId).
                Where(c => c.PendingEnrollment > 0).ToList().Select(Mapper.Map<Actividad, ActivityDto>);
            foreach (ActivityDto activity in activities) {
                events.Add(new EventDto { Id = activity.Id, Start = activity.Schedule ,End = activity.Schedule.AddHours(1)});

            }
            
            
            return events.ToArray();


        }



    }
}
