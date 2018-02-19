using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using gestionDePiletaSportClub.Models;

namespace gestionDePiletaSportClub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DNI")]
        public int DNI { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public Nullable<DateTime> BirthDay { get; set; }

        public Level Level { get; set; }


        [Display(Name = "Nivel")]
        public byte? LevelId { get; set; }

        public PaymentType PaymentType { get; set; }


        [Display(Name = "Tipo de pago")]
        public byte? PaymentTypeId { get; set; }

        public MembershipType MembershipType { get; set; }


        [Display(Name = "Plan")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Fecha de alta")]
        public DateTime StartingDate { get; set; }
        [Display(Name="Cantidad de clases")]
        public byte? AmountOfActivities { get; set; }

        [Display(Name = "Fecha de pago")]
        public Nullable<DateTime> LastPaymentDate { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        public Nullable<DateTime> DueDate { get; set; }

        [Display(Name = "Cantidad de clases pendientes")]
        public byte? AmountOfPendingActivities { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }




    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}