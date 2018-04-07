using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Dtos
{
    public class ActivityDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nivel")]
        public byte LevelId { get; set; }

        public LevelDto Level { get; set; }

        [Required]
        [Display(Name = "Plan")]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        
        [Required]
        [Display(Name = "Tipo de Actividad")]
        public byte TipoActividadId { get; set; }

        public TipoActividadDto TipoActividad { get; set; }

        [Display(Name = "Cantidad maxima de alumnos")]
        public byte AmountOfEnrollment { get; set; }

        [Display(Name = "Inscripciones pendientes")]
        public byte PendingEnrollment { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public string Schedule { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public byte EstadoActividadId { get; set; }

        public EstadoActividadDto EstadoActividad { get; set; }
    }
}