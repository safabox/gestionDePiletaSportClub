using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Dtos.MasterActivity
{
    public class MasterActivityCreationDto
    {

        [Required]
        public byte LevelId;

        [Required]
        public byte MembershipTypeId { get; set; }

        [Required]
        public byte TipoActividadId { get; set; }
        [Required]
        public int DateOfWeek { get; set; }
        [Required]
        public int Hour { get; set; }
        [Required]
        public int Minutes { get; set; }
        [Required]
        public int Duration { get; set; }

        [Required]
        public byte AmountOfEnrollment { get; set; }

    }

}