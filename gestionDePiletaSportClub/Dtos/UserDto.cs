using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Dtos
{
    public class UserDto
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

        public LevelDto Level { get; set; }


        [Display(Name = "Nivel")]
        public byte? LevelId { get; set; }

        public PaymentTypeDto PaymentType { get; set; }


        [Display(Name = "Tipo de pago")]
        public byte? PaymentTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Display(Name = "Plan")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime StartingDate { get; set; }


        [Display(Name = "Fecha de pago")]
        public DateTime LastPaymentDate { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Cantidad de clases es requerido")]
        [Display(Name="Cantidad de clases")]
        public byte AmountOfActivities { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "El mail no es válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

       
        [Display(Name = "UserName")]
        public string UserName { get; set; }

      
        [Display(Name = "Id")]
        public string Id { get; set; }


        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }


        public DateTime? LockoutEndDateUtc { get; set; }

    }
}