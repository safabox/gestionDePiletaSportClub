namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createRelationBetweenMasterClassAndActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "MasterActivityId", c => c.Int(nullable: true));
            CreateIndex("dbo.Actividad", "MasterActivityId");
            AddForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity");
            DropIndex("dbo.Actividad", new[] { "MasterActivityId" });
            DropColumn("dbo.Actividad", "MasterActivityId");
        }
    }
}
