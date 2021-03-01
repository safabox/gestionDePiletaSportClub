using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Dtos
{
    public class LevelDto
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        public string Code { get; set; }
    }
}