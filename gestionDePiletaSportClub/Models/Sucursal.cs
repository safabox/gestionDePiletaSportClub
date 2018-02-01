using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class Sucursal
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name="Sucursal")]
        public string Name { get; set; }

    }
}