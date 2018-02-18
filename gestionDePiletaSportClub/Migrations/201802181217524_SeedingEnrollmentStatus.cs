namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingEnrollmentStatus : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into EnrollmentStatus (id,name) values (1,'Pendiente')");
            Sql("Insert into EnrollmentStatus (id,name) values (2,'Presente')");
            Sql("Insert into EnrollmentStatus (id,name) values (3,'Ausente')");
            
        }
        
        public override void Down()
        {
        }
    }
}
