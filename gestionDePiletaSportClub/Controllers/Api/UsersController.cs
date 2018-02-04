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
        public IEnumerable<UserDto> getUsers() {
            var users = _context.Users.ToList().Select(Mapper.Map<ApplicationUser, UserDto>); ;
            return users;
        }

        //GET Users/{id}
        public UserDto getUser(string Id)
        {
            var user = _context.Users.SingleOrDefault(C => C.Id == Id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<ApplicationUser, UserDto>(user);
        }
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



    }
}
