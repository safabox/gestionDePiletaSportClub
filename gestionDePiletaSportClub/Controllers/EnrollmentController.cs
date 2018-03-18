using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionDePiletaSportClub.Controllers
{
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }
        // GET: Enrollment
        public ActionResult MyEnrollments(string userId)
        {
            return View("MyEnrollments");
        }
        // GET: Enrollment
        public ActionResult List(string userId)
        {
            return View("Historico");
        }
    }
}