using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;
using gestionDePiletaSportClub.Dtos;

namespace gestionDePiletaSportClub.ViewModels
{
    public class AddUserViewModel
    {
        //public ApplicationUser User { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<Level> Levels { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }
        
        //[Required(ErrorMessage = "La password es requerida")]
        //[StringLength(100, ErrorMessage = "La {0} debe de tener al menos {2} caracteres.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirmar password")]
        //[Compare("Password", ErrorMessage = "Las passwords no coinciden.")]
        //public string ConfirmPassword { get; set; }

        [Display(Name ="Cantidad de clases")]
        public int[] AmountOfActivities = new int[] { 4, 8, 12 };

    }
}