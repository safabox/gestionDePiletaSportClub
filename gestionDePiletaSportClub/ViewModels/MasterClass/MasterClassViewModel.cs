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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}