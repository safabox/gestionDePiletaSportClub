using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionDePiletaSportClub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
<<<<<<< HEAD

        public ActionResult inicio()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
<<<<<<< HEAD


        
=======
>>>>>>> parent of 937c4b9... vista de inicio
=======
>>>>>>> parent of 91d19a6... pantalla de disponibilidad
    }
}