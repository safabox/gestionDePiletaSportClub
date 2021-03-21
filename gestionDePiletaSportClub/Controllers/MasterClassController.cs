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
    [Authorize(Roles = "Administrator,Coordinador")]
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
                masterActivityViewModel.ActivityTypes.Add(masterActivity.TipoActividad);
                masterActivityViewModel.MembershipTypes.Add(masterActivity.MembershipType);
                masterActivityViewModel.LevelTypes.Add(masterActivity.Level);

                masterActivityViewModel.DaysOfWeekList = new Dictionary<int, string>() {
                    { masterActivity.DateOfWeek, masterActivityViewModel.DaysOfWeekList[masterActivity.DateOfWeek]}
                };
                var activities = await _context.Actividad.Where(a => a.MasterActivityId == masterActivity.Id && a.EstadoActividadId == EstadoActividad.Abierta).ToListAsync();
                if(activities.Count> 0) { 
                    masterActivityViewModel.StartDate = activities.First().Schedule;
                    masterActivityViewModel.EndDate = activities.Last().Schedule;
                    masterActivityViewModel.AmountOfActivities = activities.Count;
                }


            }
            else {
                masterActivityViewModel.MasterActivity = new MasterActivityDto();
                masterActivityViewModel.ActivityTypes = await _context.TipoActividad.ToListAsync();
                masterActivityViewModel.MembershipTypes = await _context.MembershipType.ToListAsync();
                masterActivityViewModel.LevelTypes = new List<Level>();
            }
            
            return View("MasterClass", masterActivityViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> SaveMasterClass(MasterClassViewModel masterClassVM) {

            if (!ModelState.IsValid)
            {
                var masterActivityViewModel = new MasterClassViewModel();
                masterActivityViewModel.MasterActivity = new MasterActivityDto();
                masterActivityViewModel.ActivityTypes = await _context.TipoActividad.ToListAsync();
                masterActivityViewModel.MembershipTypes = await _context.MembershipType.ToListAsync();
                if (masterClassVM.MasterActivity.MembershipTypeId > 0) {
                    var plan = await _context.MembershipType.Include(l => l.Levels).SingleOrDefaultAsync(m => m.Id == masterClassVM.MasterActivity.MembershipTypeId);
                    masterActivityViewModel.LevelTypes = plan.Levels;
                }
                else {
                    masterActivityViewModel.LevelTypes = new List<Level>();
                }

                return View("MasterClass", masterActivityViewModel);
            }
            else {
                var masterClass = _mapper.Map<MasterActivity>(masterClassVM.MasterActivity);
                _context.MasterActivity.Add(masterClass);
                await _context.SaveChangesAsync();

                return RedirectToAction("MasterClass", "MasterClass", new { @id = masterClass.Id });
            }

        }



    }
}