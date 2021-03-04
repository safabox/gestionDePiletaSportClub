using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gestionDePiletaSportClub.DAL;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.ViewModels;
using gestionDePiletaSportClub.Dtos;
using System.Data.Entity;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace gestionDePiletaSportClub.Controllers.Api
{
    public class MembershipsController : ApiController
    {
        private ApplicationDBContext _context;
        private IMapper mapper;
        public MembershipsController()
        {
            _context = ApplicationDBContext.Create();
            mapper = Mapper.Instance;
        }

        public async Task<IEnumerable<MembershipTypeDto>> GetMembershipTypes() {
            var membershipTypes = await _context.MembershipType.ToListAsync();
            return Mapper.Map<List<MembershipTypeDto>>(membershipTypes); 
        }

        public async Task<MembershipTypeDto> GetMembershipTypes(int Id)
        {
            var membershipType = await _context.MembershipType.Where(m=> m.Id ==Id).SingleOrDefaultAsync();
            if (membershipType == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<MembershipType, MembershipTypeDto>(membershipType);
        }
        [Route("api/Memberships/{Id}/Levels")]
        public IEnumerable<LevelDto> GetLevelsForMembershipType(int Id) {
            var levels = _context.MembershipType
                .Where(m => m.Id == Id)
                .SelectMany(m => m.Levels)
                .Select(Mapper.Map<Level,LevelDto>);
            return levels;

        }



    }
}
