using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Dtos
{
    public class EventDisponibilidadDto
    {

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Editable = false;
        public string Title { get; set; }
     
        public string BackgroundColor { get; set; }
        public bool AllowEnrollment { get; set; }
        public string level { get; set; }
        public string membership { get; set; }
        public byte pendings { get; set; }
        public string status { get; set; }

        public EventDisponibilidadDto(ActivityDto activity)
        {
            Id = activity.Id;
            Start = DateTime.Parse(activity.Schedule, new System.Globalization.CultureInfo("es-AR"));
            End = Start.AddHours(1);
            Title = activity.Level.Name + " cupos: " +
                    activity.PendingEnrollment.ToString();

            level = activity.Level.Name;
            membership = activity.MembershipType.Name;
            pendings = activity.PendingEnrollment;
            AllowEnrollment = false;
            BackgroundColor = "#FF0000";

            if ((activity.PendingEnrollment > 0) && (activity.EstadoActividadId.Equals(EstadoActividad.Abierta) &&
                                                     ((DateTime.Now - Start).TotalHours < 3)))
            {
                if (activity.MembershipType.Name.Equals("Menor"))
                {

                    BackgroundColor = "#2196f3";
                    if (activity.Level.Name.Equals("Inicial"))
                    {
                        Title = "INI: "+ activity.PendingEnrollment.ToString();
                    }
                    else if (activity.Level.Name.Equals("Intermedio1"))
                    {
                        Title = "INT1: " + activity.PendingEnrollment.ToString();
                    }
                    else if (activity.Level.Name.Equals("Intermedio2"))
                    {
                        Title = "INT2: " + activity.PendingEnrollment.ToString();
                    }
                    else if (activity.Level.Name.Equals("Pre Equipo"))
                    {
                        Title = "PreEq: " + activity.PendingEnrollment.ToString();
                    }

                }
                else if (activity.MembershipType.Name.Equals("Adulto"))
                {

                    BackgroundColor = "#800080";
                    if (activity.Level.Name.Equals("Inicial"))
                    {
                        Title = "INI: " + activity.PendingEnrollment.ToString();
                    }
                    else if (activity.Level.Name.Equals("Intermedio"))
                    {
                        Title = "INT: " + activity.PendingEnrollment.ToString();
                    }
                    else if (activity.Level.Name.Equals("Avanzado"))
                    {
                        Title = "ADV: " + activity.PendingEnrollment.ToString();
                    }
                    
                }
                else if (activity.MembershipType.Name.Equals("Bebe"))
                {

                    BackgroundColor = "#008000";
                    if (activity.Level.Name.Equals("Inicial"))
                    {
                        Title = "INI: " + activity.PendingEnrollment.ToString();
                    }
                  
                }
            }
        }
    }


}