namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testFacundo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Enrollment", "ActividadId");
            AddForeignKey("dbo.Enrollment", "ActividadId", "dbo.Actividad", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "ActividadId", "dbo.Actividad");
            DropIndex("dbo.Enrollment", new[] { "ActividadId" });
        }
    }
}
