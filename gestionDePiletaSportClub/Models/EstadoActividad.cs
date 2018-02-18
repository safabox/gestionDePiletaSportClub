using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace gestionDePiletaSportClub.Models
{
    public class EstadoActividad
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        [Display(Name ="Estado")]
        public string Name { get; set; }


        public const byte Abierta = 1;
        public const byte Cerrada = 2;
        public const byte Cancelada = 3;
    }
}