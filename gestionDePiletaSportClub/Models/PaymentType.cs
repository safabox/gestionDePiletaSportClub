using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gestionDePiletaSportClub.Models
{
    public class PaymentType
    {
        [Required]
        public byte Id { get; set; }
        [Required]
        [Display(Name ="Tipo de pago")]
        public string Name { get; set; }

        public const byte Efectivo = 1;
        public const byte Debito = 2;
    }
}