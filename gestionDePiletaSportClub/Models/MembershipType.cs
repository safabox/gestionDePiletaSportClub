using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class MembershipType
    {
        [Required]
        public byte Id { get; set; }
        [Required]
        [Display(Name="Plan")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        //[Required]
        [Display(Name = "Niveles")]
        public List<Level> Levels { get; set; }

        public const byte Bebe= 1;
        public const byte Menor= 2;
        public const byte Adulto = 3;
        

    }
}