using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;
using AutoMapper;
using gestionDePiletaSportClub.Dtos.MasterActivity;

namespace gestionDePiletaSportClub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            //CreateMap<UserDto, ApplicationUser>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<Level, LevelDto>();
            CreateMap<Actividad, ActivityDto>().ReverseMap();
            //CreateMap<ActivityDto, Actividad>();
            CreateMap<MasterActivityCreationDto, MasterActivity>();
            CreateMap<MasterActivityDto, MasterActivity>().ReverseMap();
            CreateMap<MasterActivity, Actividad>();

        }
    }
}