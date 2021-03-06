﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionDePiletaSportClub.DAL;
using System.Data.Entity;
using System.Security.Principal;
using gestionDePiletaSportClub.ViewModels;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using AutoMapper;


namespace gestionDePiletaSportClub.Controllers
{

    [Authorize(Roles = RolNames.AuthorizedRoles)]
    public class UserController : Controller
    {
        private ApplicationDBContext _context;
        private IMapper _mapper;
        public UserController()
        {
            _context=ApplicationDBContext.Create();
            _mapper = Mapper.Instance; 
        }
        protected override void Dispose(bool disposing)

        {
            _context.Dispose();

        }
        // GET: User
        public ActionResult Index()
        {
            
            return View();
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
        public ActionResult NewEmployee()
        {
            var viewModel = new AddEmployeeViewModel()
            {
                Roles= new string[] { "Empleado","Coordinador","Administrator"}
                
            };
            return View("AddEmployeeForm", viewModel);
        }



        public ActionResult Edit(string Id) {
            var user = _context.Users.Where(u => u.Id == Id).SingleOrDefault();
            if (user == null) { return HttpNotFound(); }
            var viewModel = new EditUserViewModel() {
                User = Mapper.Map<ApplicationUser,UserDto>(user),
                MembershipTypes = _context.MembershipType.ToList(),
                Levels = _context.Level.ToList(),
                PaymentTypes = _context.PaymentType.ToList() };
            return View("UserForm",viewModel);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Save(UserDto user)
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
                //userInDB.BirthDay = user.BirthDay.Value.ToString("s");
                userInDB.BirthDay = user.BirthDay;
                userInDB.MembershipTypeId = user.MembershipTypeId;
                userInDB.PaymentTypeId = user.PaymentTypeId;
                userInDB.LevelId = user.LevelId;
                userInDB.DNI = user.DNI;
                userInDB.AmountOfActivities = user.AmountOfActivities;
                //userInDB.LastPaymentDate = user.LastPaymentDate.ToString("s");
                 
                userInDB.LastPaymentDate = DateTime.Parse(user.LastPaymentDate, new System.Globalization.CultureInfo("es-AR")).ToString("s"); 
                //userInDB.DueDate = user.LastPaymentDate.AddMonths(1).ToString("s");
                userInDB.DueDate = DateTime.Parse(user.DueDate, new System.Globalization.CultureInfo("es-AR")).ToString("s");
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
        [AllowAnonymous]
        public ActionResult ReadUser(string Id) {
            
            var user = _context.Users.Include(u => u.MembershipType)
               .Include(u => u.PaymentType)
               .Include(u => u.Level)
               .SingleOrDefault(U => U.Id == Id);
            if (user == null) { return HttpNotFound(); }

            return View("ReadOnlyUser", _mapper.Map<UserDto>(user));
        }


    }
}