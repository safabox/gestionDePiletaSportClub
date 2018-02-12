namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enableActividadRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "LevelId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Actividad", "LevelId");
            AddForeignKey("dbo.Actividad", "LevelId", "dbo.Level", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividad", "LevelId", "dbo.Level");
            DropIndex("dbo.Actividad", new[] { "LevelId" });
            DropColumn("dbo.Actividad", "LevelId");
        }
    }
}
