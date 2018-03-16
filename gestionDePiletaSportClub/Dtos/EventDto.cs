using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End { get; set; }
        public bool Editable = false;
        public string Title { get; set; }
        public string BackgroundColor { get; set; }
        public bool AllowEnrollment { get; set; }
        public string level { get; set; }
        public string membership { get; set; }
        public byte pendings { get; set; }

        public EventDto(ActivityDto activity) {
            Id = activity.Id;
            Start = activity.Schedule;
            End = activity.Schedule.AddHours(1);
            Title = activity.TipoActividad.Name;
            level = activity.Level.Name;
            membership = activity.MembershipType.Name;
            pendings = activity.PendingEnrollment;
            AllowEnrollment = false;
            BackgroundColor = "#FF0000";
            if ((activity.PendingEnrollment > 0) && (activity.EstadoActividadId.Equals(EstadoActividad.Abierta))){
                AllowEnrollment = true;
                BackgroundColor = "#2196f3";
            }

        }
        public EventDto(Enrollment enrollment)
        {
            Id = enrollment.Id;
            Start = enrollment.Schedule;
            End = enrollment.Schedule.AddHours(1);
            Title = enrollment.Actividad.TipoActividad.Name;
 
        }

    }
}