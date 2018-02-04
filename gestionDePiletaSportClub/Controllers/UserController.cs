using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionDePiletaSportClub.DAL;
using System.Data.Entity;
using System.Security.Principal;
using gestionDePiletaSportClub.ViewModels;
using gestionDePiletaSportClub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace gestionDePiletaSportClub.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDBContext _context;
        public UserController()
        {
            _context=ApplicationDBContext.Create();
        }
        protected override void Dispose(bool disposing)

        {
            _context.Dispose();

        }
        // GET: User
        public ActionResult Index()
        {
            //var userName = User.Identity.Name;
            var users = _context.Users.Where(u => u.Roles.FirstOrDefault().RoleId == Rol.Socio)
                .Include(u => u.MembershipType)
                .Include(u => u.PaymentType)
                .Include(u => u.Level).ToList();
                

            return View(users);
        }

        public ActionResult New()
        {
            var viewModel = new AddUserViewModel()
            {
                
                MembershipTypes = _context.MembershipType.ToList(),
                Levels = _context.Level.ToList(),
                PaymentTypes = _context.PaymentType.ToList()
            };
            return View("AddUserForm", viewModel);
        }



        public ActionResult Edit(string Id) {
            var user = _context.Users.Where(u => u.Id == Id).SingleOrDefault();
            if (user == null) { return HttpNotFound(); }
            var viewModel = new EditUserViewModel() {
                User = user,
                MembershipTypes = _context.MembershipType.ToList(),
                Levels = _context.Level.ToList(),
                PaymentTypes = _context.PaymentType.ToList() };
            return View("UserForm",viewModel);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Save(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                var editUserViewModel = new EditUserViewModel();
                editUserViewModel.User = user;
                editUserViewModel.MembershipTypes = _context.MembershipType.ToList();
                editUserViewModel.Levels = _context.Level.ToList();
                editUserViewModel.PaymentTypes = _context.PaymentType.ToList();
                return View("UserForm", editUserViewModel);
            }
            else
            {

                
                var userInDB = _context.Users.Single(U => U.Id == user.Id);
                userInDB.Name = user.Name;
                userInDB.BirthDay = user.BirthDay;
                userInDB.MembershipTypeId = user.MembershipTypeId;
                userInDB.PaymentTypeId = user.PaymentTypeId;
                userInDB.LevelId = user.LevelId;
                userInDB.DNI = user.DNI;
                
                _context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
        }


        public ActionResult Delete(string Id)
        {
            var user = _context.Users.Where(u => u.Id == Id).SingleOrDefault();
            if (user == null) { return HttpNotFound(); }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }


    }
}