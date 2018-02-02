using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionDePiletaSportClub.DAL;

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

            var membershipTypes = _context.MembershipType.ToList();
            return View(membershipTypes);
        }
    }
}