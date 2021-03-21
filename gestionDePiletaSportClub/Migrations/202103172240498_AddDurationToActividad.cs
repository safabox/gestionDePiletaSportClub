namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationToActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actividad", "Duration");
        }
    }
}
