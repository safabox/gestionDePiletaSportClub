using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;
using AutoMapper;

namespace gestionDePiletaSportClub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<Level, LevelDto>();
            CreateMap<Actividad, ActivityDto>();
            CreateMap<ActivityDto, Actividad>();
        }
    }
}