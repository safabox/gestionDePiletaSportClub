using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;

namespace gestionDePiletaSportClub.ViewModels
{
    public class EditUserViewModel
    {
        public UserDto User { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<Level> Levels { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }
        //public int[] AmountOfActivities = new int[] { 4, 8, 12 };
    }
}