using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Dtos
{
    public class EstadoActividadDto
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Name { get; set; }
    }
}