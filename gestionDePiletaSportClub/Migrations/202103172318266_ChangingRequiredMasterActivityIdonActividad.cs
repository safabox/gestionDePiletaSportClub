namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingRequiredMasterActivityIdonActividad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity");
            DropIndex("dbo.Actividad", new[] { "MasterActivityId" });
            AlterColumn("dbo.Actividad", "MasterActivityId", c => c.Int());
            CreateIndex("dbo.Actividad", "MasterActivityId");
            AddForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity");
            DropIndex("dbo.Actividad", new[] { "MasterActivityId" });
            AlterColumn("dbo.Actividad", "MasterActivityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Actividad", "MasterActivityId");
            AddForeignKey("dbo.Actividad", "MasterActivityId", "dbo.MasterActivity", "Id", cascadeDelete: true);
        }
    }
}
