using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<Level> Levels { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }

    }
}