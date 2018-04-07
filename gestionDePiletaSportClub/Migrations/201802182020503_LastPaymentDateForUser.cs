namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastPaymentDateForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastPaymentDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "AmountOfActivities", c => c.Byte());
            AlterColumn("dbo.AspNetUsers", "DueDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "AmountOfPendingActivities", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "AmountOfPendingActivities", c => c.Byte(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DueDate", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AmountOfActivities", c => c.Byte(nullable: false));
            DropColumn("dbo.AspNetUsers", "LastPaymentDate");
        }
    }
}
