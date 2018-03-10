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

            return View("Actividades");
            
        }


        public ActionResult ListActivities()
        {

            return View("ListActivities");

        }


    }
}