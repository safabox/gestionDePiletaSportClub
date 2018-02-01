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
        // GET: User
        private ApplicationDBContext _context = ApplicationDBContext.Create();
        public ActionResult Index()
        {

            var membershipTypes = _context.MembershipType.ToList();
            return View(membershipTypes);
        }
    }
}