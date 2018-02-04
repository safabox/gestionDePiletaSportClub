using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionDePiletaSportClub.Models
{
    public static class RolNames
    {
        public const string Socio = "Socio";
        public const string Empleado = "Empleado";
        public const string Administrator = "Administrator";
        public const string Coordinador = "Coordinador";

        public const string AuthorizedRoles =   Administrator + "," + Empleado + "," + Coordinador;
                
        
    }
}