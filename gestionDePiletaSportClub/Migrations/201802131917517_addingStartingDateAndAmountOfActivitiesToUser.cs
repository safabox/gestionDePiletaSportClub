namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStartingDateAndAmountOfActivitiesToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StartingDate", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "AmountOfActivities", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AmountOfActivities");
            DropColumn("dbo.AspNetUsers", "StartingDate");
        }
    }
}
