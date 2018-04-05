using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Dtos
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El DNI es requerido")]
        [Display(Name = "DNI")]

        public int DNI { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public Nullable<DateTime> BirthDay { get; set; }


        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "El mail no es válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Id")]
        public string Id { get; set; }

    }
}