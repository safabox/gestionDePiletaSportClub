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

        public IEnumerable<MembershipTypeDto> GetMembershipTypes() {
            var membershipTypes = _context.MembershipType.ToList().Select(Mapper.Map<MembershipType, MembershipTypeDto>); ;
            return membershipTypes;
        }

        public MembershipTypeDto GetMembershipTypes(int Id)
        {
            var membershipType = _context.MembershipType.Where(m=> m.Id ==Id).SingleOrDefault(); 
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
