using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Models
{
    public class MasterActivity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Plan")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public byte LevelId { get; set; }
        public Level Level { get; set; }
               
        [Required]
        [Display(Name = "Tipo de Actividad")]
        public byte TipoActividadId { get; set; }
        public TipoActividad TipoActividad { get; set; }

        [Display(Name = "Cantidad maxima de alumnos")]
        public byte AmountOfEnrollment { get; set; }

        [Required]
        [Display(Name = "Dia de la semana")]
        public int DateOfWeek { get; set; }
               
        [Required]
        [Display(Name = "Hora")]
        public int Hour { get; set; }

        [Required]
        [Display(Name = "Minutos")]
        public int Minutes { get; set; }

        [Required]
        [Display(Name = "Duracion")]
        public int Duration { get; set; }

        public List<Actividad> Activities { get; set; }

    }
}