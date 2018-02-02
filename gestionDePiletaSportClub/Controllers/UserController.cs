using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionDePiletaSportClub.DAL;
using System.Data.Entity;

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

            var user = _context.Users.Where(u => u.UserName == "socio@safabox.com")
                .Include(u=> u.MembershipType)
                .Include(u=> u.PaymentType)
                .Include(u=> u.Level)
                .Single();
            return View(user);
        }
    }
}