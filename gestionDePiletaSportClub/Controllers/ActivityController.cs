using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using gestionDePiletaSportClub.DAL;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;
using gestionDePiletaSportClub.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace gestionDePiletaSportClub.Controllers
{
    public class ActivityController : Controller
    {

        private ApplicationDBContext _context;
        private IMapper _mapper;
        public ActivityController()
        {
            _context = ApplicationDBContext.Create();
            _mapper = Mapper.Instance;
        }
        protected override void Dispose(bool disposing)

        {
            _context.Dispose();

        }



        // GET: Activity
        public async Task<ActionResult> Index()
        {
            var userId= System.Web.HttpContext.Current.User.Identity.GetUserId();
            var appUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            ActivityIndexViewModel activityIndex = new ActivityIndexViewModel()
            {
                PlanId = appUser.MembershipTypeId,
                LevelId = appUser.LevelId,
                PaymentDate = appUser.LastPaymentDate,
                DueDate = appUser.DueDate

            };

            return View("Actividades",activityIndex);
            
        }


        public ActionResult ListActivities()
        {

            return View("ListActivities");

        }

        public ActionResult Activity(int Id = 0) {
            var activity = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a=> a.EstadoActividad)
                .Include(a=> a.MembershipType)
                .Include(a=> a.Level)
                .SingleOrDefault(a => a.Id == Id);

            var enrollments = _context.Enrollment
                        .Where(e => e.ActividadId == Id)
                        .Include(e => e.ApplicationUser)
                        .Include(e => e.EnrollmentStatus)
                        .ToList();
            
            var activityViewModel = new ActivityViewModel() {
                Activity = Mapper.Map<Actividad, ActivityDto>(activity),
                Enrollments = enrollments
            };

            return View("Activity", activityViewModel);
        }

        [AllowAnonymous]
        public ActionResult Disponibilidad(int Id = 0)
        {
            var activity = _context.Actividad
                .Include(a => a.TipoActividad)
                .Include(a => a.EstadoActividad)
                .Include(a => a.MembershipType)
                .Include(a => a.Level)
                .SingleOrDefault(a => a.Id == Id);



            var disponibiliActivityViewModel = new DisponibilidadViewModel()
            {
                Activity = Mapper.Map<Actividad, ActivityDto>(activity),

            };

            return View("Disponibilidad", disponibiliActivityViewModel);
        }


    }
}