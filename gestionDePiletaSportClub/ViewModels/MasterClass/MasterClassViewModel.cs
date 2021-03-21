using gestionDePiletaSportClub.Dtos.MasterActivity;
using gestionDePiletaSportClub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace gestionDePiletaSportClub.ViewModels.MasterClass
{
    public class MasterClassViewModel
    {
        public MasterActivityDto MasterActivity { get; set; }
        [Display(Name ="Primera Clase")]
        public string StartDate { get; set; }
        [Display(Name = "Ultima Clase")]
        public string EndDate { get; set; }
        [Display(Name = "Cantidad de Clases")]
        public int AmountOfActivities { get; set; }
        public List<TipoActividad> ActivityTypes { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
        public List<Level> LevelTypes { get; set; }
        public Dictionary<int,string> DaysOfWeekList { get; set; }
        public MasterClassViewModel()
        {
            ActivityTypes = new List<TipoActividad>();
            MembershipTypes = new List<MembershipType>();
            LevelTypes = new List<Level>();
            DaysOfWeekList = new Dictionary<int, string>() {
                {1,"Lunes"},
                {2,"Martes"},
                {3,"Miercoles"},
                {4,"Jueves"},
                {5,"Viernes"},
                {6,"Sabado"}
            };
        }
        


    }
}