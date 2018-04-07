namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingDateTimeForString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actividad", "Schedule", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.String());
            AlterColumn("dbo.AspNetUsers", "StartingDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastPaymentDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DueDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LastPaymentDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "StartingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Actividad", "Schedule", c => c.DateTime(nullable: false));
        }
    }
}
