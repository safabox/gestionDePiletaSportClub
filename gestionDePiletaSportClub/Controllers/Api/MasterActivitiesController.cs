using AutoMapper;
using gestionDePiletaSportClub.DAL;
using gestionDePiletaSportClub.Dtos;
using gestionDePiletaSportClub.Dtos.MasterActivity;
using gestionDePiletaSportClub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace gestionDePiletaSportClub.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    public class MasterActivitiesController : ApiController
    {

        ApplicationDBContext _context = null;
        IMapper _mapper = null;

        public MasterActivitiesController()
        {
            _context = ApplicationDBContext.Create();
            _mapper = Mapper.Instance;
        }

        [HttpGet]
        [Route("api/masteractivities")]
        public async Task<List<EventDto>> GetMasterActivities(int? planId = null, int? levelId = null) {

            var query =  _context.MasterActivity
                .Include(a => a.TipoActividad)
                .Include(a => a.MembershipType)
                .Include(a => a.Level)
                .AsQueryable();
            if (planId != null && planId > 0)
            {
                query = query.Where(a => a.MembershipTypeId == planId);
            }
            if (levelId != null && levelId > 0)
            {
                query = query.Where(a => a.LevelId == levelId);
            }

            var masterActivities = await query.ToListAsync();
            var events = new List<EventDto>();
            foreach (MasterActivity a in masterActivities) {
                var eventDto = new EventDto(a);
                eventDto.Start = calculateDateForEvent(a);
                eventDto.End = eventDto.Start.AddMinutes(a.Duration);
                events.Add(eventDto);
            }
                        
            return events;
        }

        [HttpGet]
        [Route("api/masteractivities/{id}")]
        public async Task<MasterActivity> GetMasterActivity(int id)
        {
            var masterActivity = await _context.MasterActivity.SingleOrDefaultAsync(a => a.Id == id);
            if (masterActivity == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return masterActivity;
        }

        [HttpDelete]
        [Route("api/masteractivities/{id}")]
        public async Task<IHttpActionResult> DeleteMasterActivity(int id)
        {
            var masterActivity = await _context.MasterActivity.SingleOrDefaultAsync(a => a.Id == id);
            if (masterActivity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //implementar borrado

            return Ok();
        }

        [HttpPost]
        [Route("api/masteractivities/")]
        public async Task<MasterActivityDto> CreateMasterActivity([FromBody] MasterActivityCreationDto masterActivityDto)
        {

            
            var plan = await _context.MembershipType.Include(l=> l.Levels).SingleOrDefaultAsync(m => m.Id == masterActivityDto.MembershipTypeId);
            var level = await _context.Level.SingleOrDefaultAsync(l => l.Id == masterActivityDto.LevelId);
            var tipoActividad = await _context.TipoActividad.SingleOrDefaultAsync(t => t.Id == masterActivityDto.TipoActividadId);
            


            if (plan == null || level == null || tipoActividad == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (!isValidDto(masterActivityDto) || !plan.Levels.Contains(level))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var masterActivity = await _context.MasterActivity
                .SingleOrDefaultAsync(a => a.MembershipTypeId == masterActivityDto.MembershipTypeId &&
                a.LevelId == masterActivityDto.LevelId &&
                a.Hour == masterActivityDto.Hour &&
                a.Minutes == masterActivityDto.Minutes);
            if (masterActivity != null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            masterActivity = _mapper.Map<MasterActivity>(masterActivityDto);
            _context.MasterActivity.Add(masterActivity);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<MasterActivityDto>(masterActivity);
        }



        private DateTime calculateDateForEvent(MasterActivity a) {

            int restWeek = 0;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                restWeek = -1;
            }
            var calendarDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + a.DateOfWeek);
            calendarDate = calendarDate.AddDays(7 * restWeek);
            return new DateTime(calendarDate.Year, calendarDate.Month, calendarDate.Day, a.Hour, a.Minutes, 0);
            
        }

        private bool isValidDto(MasterActivityCreationDto masterActivityDto) {
            return !(masterActivityDto.DateOfWeek < 1 
                || masterActivityDto.DateOfWeek > 7 
                || (masterActivityDto.Duration % 15) != 0  
                || masterActivityDto.Hour > 23 
                || masterActivityDto.Hour <0
                || masterActivityDto.Minutes > 59
                || masterActivityDto.Minutes < 0
                || masterActivityDto.AmountOfEnrollment < 0
                );
        }
    }
}
