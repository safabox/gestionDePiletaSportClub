using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End { get; set; }
        public bool Editable = false;
        public string Title = "Clase Natacion";
        
    }
}