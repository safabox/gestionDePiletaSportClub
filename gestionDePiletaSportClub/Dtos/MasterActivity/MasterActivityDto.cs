using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Dtos.MasterActivity
{
    public class MasterActivityDto
    {

        [Required]
        public int Id;

        [Required(ErrorMessage = "El nivel es requerido")]
        [Display(Name = "Nivel")]
        public byte LevelId { get; set; }

        [Required(ErrorMessage = "El plan es requerido")]
        [Display(Name = "Plan")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "Tipo de actividad es requerido")]
        [Display(Name = "Tipo Actividad")]
        public byte TipoActividadId { get; set; }
        [Required(ErrorMessage = "El dia de la semana es requerido")]
        [Display(Name = "Dia de la semana")]
        public int DateOfWeek { get; set; }
        [Required(ErrorMessage = "Hora de inicio es requerida")]
        [Display(Name = "Hora")]
        public int Hour { get; set; }
        [Required]
        [Display(Name = "Minuto")]
        public int Minutes { get; set; }
        [Required(ErrorMessage = "La duracion de la clase es requerida")]
        [Display(Name = "Duracion")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La cantidad de clases es requerida")]
        [Display(Name = "Cupos")]
        public byte AmountOfEnrollment { get; set; }
    }
}