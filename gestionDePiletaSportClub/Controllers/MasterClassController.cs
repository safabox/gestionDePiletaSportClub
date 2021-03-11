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
using gestionDePiletaSportClub.Dtos.MasterActivity;
using gestionDePiletaSportClub.ViewModels.MasterClass;

namespace gestionDePiletaSportClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MasterClassController : Controller
    {

        private ApplicationDBContext _context;
        private IMapper _mapper;

        public MasterClassController()
        {
            _context = ApplicationDBContext.Create();
            _mapper = Mapper.Instance;
        }

        // GET: MasterClass
        

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> MasterClass(int Id = 0)
        {
            var masterActivity = await _context.MasterActivity
                .Include(a => a.TipoActividad)
                .Include(a => a.MembershipType)
                .Include(a => a.Level)
                .SingleOrDefaultAsync(a => a.Id == Id);

            var masterActivityViewModel=new MasterClassViewModel();
            if (masterActivity != null)
            {
                masterActivityViewModel.MasterActivity = Mapper.Map<MasterActivity, MasterActivityDto>(masterActivity);
                
            }
            else {
                masterActivityViewModel.MasterActivity = new MasterActivityDto();
            }
            
            return View("MasterClass", masterActivityViewModel);
        }





    }
}