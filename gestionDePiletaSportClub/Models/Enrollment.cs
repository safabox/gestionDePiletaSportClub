using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class Enrollment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public int ActividadId { get; set; }

        [Display(Name = "Horario")]
        public DateTime Schedule { get; set; }


    }
}