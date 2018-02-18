using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class EnrollmentStatus
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name="Estado")]
        public string Name { get; set; }

        public const byte Pendiente = 1;
        public const byte Presente = 2;
        public const byte Ausente = 3;


    }
}