namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DueDateAndPendingActivitiesForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "AmountOfPendingActivities", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AmountOfPendingActivities");
            DropColumn("dbo.AspNetUsers", "DueDate");
        }
    }
}
