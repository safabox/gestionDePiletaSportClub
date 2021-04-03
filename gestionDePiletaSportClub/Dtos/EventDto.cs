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
        public string LevelCode { get; set; }
        public string membership { get; set; }
        public byte pendings { get; set; }
        public string status { get; set; }
        public int ActivityId { get; set; }


        public EventDto(ActivityDto activity) {
            Id = activity.Id;
            Start = DateTime.Parse(activity.Schedule, new System.Globalization.CultureInfo("es-AR"));
            activity.Duration = activity.Duration > 0 ? activity.Duration : 60;
            End = Start.AddMinutes(activity.Duration);
            Title = activity.TipoActividad.Name;
            level = activity.Level.Name;
            LevelCode = activity.Level.Code;
            membership = activity.MembershipType.Name;
            pendings = activity.PendingEnrollment;
            AllowEnrollment = false;
            BackgroundColor = "#FF0000";
            ActivityId = activity.Id;

            DateTime ArgentinaTime = getArgentinaTime();
            if (
                (activity.PendingEnrollment > 0) 
                && (activity.EstadoActividadId.Equals(EstadoActividad.Abierta)) 
                && ((Start - ArgentinaTime).TotalHours >= 0)
                ){
                AllowEnrollment = true;
                BackgroundColor = "#2196f3";
            }
            status = activity.EstadoActividad.Name;

        }
        public EventDto(Enrollment enrollment)
        {
            var duration = enrollment.Actividad.Duration > 0 ? enrollment.Actividad.Duration : 60;
            Id = enrollment.Id;
            Start = enrollment.Schedule;
            
            End = enrollment.Schedule.AddMinutes(duration);
            Title = enrollment.Actividad.TipoActividad.Name;
            level = enrollment.Actividad.Level.Name;
            LevelCode = enrollment.Actividad.Level.Code;
            membership = enrollment.Actividad.MembershipType.Name;
            pendings = enrollment.Actividad.PendingEnrollment;
            status = enrollment.EnrollmentStatus.Name;
            AllowEnrollment = true;
            ActivityId = enrollment.ActividadId;


            
            DateTime ArgentinaTime = getArgentinaTime(); 
            
            if ((Start - ArgentinaTime).TotalHours <= 1)
            {
                AllowEnrollment = false;
            }
            
        }

        private DateTime getArgentinaTime()
        {
            var timeZoneId = "Argentina Standard Time";
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        }

        public EventDto(gestionDePiletaSportClub.Models.MasterActivity masterActivity)
        {
            Id = masterActivity.Id;

            Title = masterActivity.TipoActividad.Name;
            level = masterActivity.Level.Name;
            LevelCode = masterActivity.Level.Code;
            membership = masterActivity.MembershipType.Name;
            AllowEnrollment = true;
            
        }



    }
}