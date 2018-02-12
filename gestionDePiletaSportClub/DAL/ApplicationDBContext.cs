using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using gestionDePiletaSportClub.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace gestionDePiletaSportClub.DAL
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
    {
                
        //public ApplicationDBContext() : base("ApplicationDBContext") { }
        public ApplicationDBContext() : base("DefaultConnection") { }

        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<IdentityUserRole> IdentityUserRole { get; set; }
        public DbSet<IdentityUserLogin> IdentityUserLogin { get; set; }
        public DbSet<Actividad> Actividad { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<IdentityUser>().ToTable("user");
            //modelBuilder.Entity<ApplicationUser>().ToTable("user");
            //modelBuilder.Entity<IdentityRole>().ToTable("role");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("userrole");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaim");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogin");
        }
        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }



    }
}