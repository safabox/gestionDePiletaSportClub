using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class Level
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name="Nivel")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }

        public const byte Inicial = 1;
        public const byte Intermedio1 = 2;
        public const byte Intermedio2 = 3;
        public const byte Avanzado = 4;
        public const byte PreEquipo = 5;
        public const byte Intermedio = 6;


    }
}