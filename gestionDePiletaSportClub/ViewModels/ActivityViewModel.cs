using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionDePiletaSportClub.Dtos;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.ViewModels
{
    public class ActivityViewModel
    {
        public ActivityDto Activity { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}