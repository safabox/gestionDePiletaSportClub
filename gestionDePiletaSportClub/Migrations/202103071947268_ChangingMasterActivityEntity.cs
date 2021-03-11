namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingMasterActivityEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterActivity", "DateOfWeek", c => c.Int(nullable: false));
            AddColumn("dbo.MasterActivity", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.MasterActivity", "WeekDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MasterActivity", "WeekDay", c => c.Int(nullable: false));
            DropColumn("dbo.MasterActivity", "Duration");
            DropColumn("dbo.MasterActivity", "DateOfWeek");
        }
    }
}
