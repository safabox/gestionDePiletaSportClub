using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Dtos.Payment
{
    public class ProcessNewPaymentDto
    {
        public byte AmountOfActivities { get; set; }
        public string DueDate { get; set; }
    }
}