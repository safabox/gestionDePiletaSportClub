using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionDePiletaSportClub.DAL;
using AutoMapper;
using Microsoft.AspNet.Identity;

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
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();

            //var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            //DateTime from = user.LastPaymentDate.Value;
            //DateTime to = user.DueDate.Value;
            //var actividades = _context.Actividad.Where(c => c.Schedule >= from && c.Schedule <= to ).
            //    Where(c=> c.LevelId == user.LevelId && c.MembershipTypeId == user.MembershipTypeId).
            //    Where(c=> c.PendingEnrollment > 0).ToList();
            return View("Actividades");
            
        }
    }
}