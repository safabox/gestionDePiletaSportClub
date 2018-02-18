namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingScheduleFieldToActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "Schedule", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actividad", "Schedule");
        }
    }
}
