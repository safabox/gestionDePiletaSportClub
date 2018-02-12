using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Models
{
    public class Actividad
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Activad")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Nivel")]
        public byte LevelId { get; set; }

        public Level Level { get; set; }

    }
}