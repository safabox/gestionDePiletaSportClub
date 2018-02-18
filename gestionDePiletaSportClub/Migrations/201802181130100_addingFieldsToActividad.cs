namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFieldsToActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "TipoActividadId", c => c.Byte(nullable: false));
            AddColumn("dbo.Actividad", "AmountOfEnrollment", c => c.Byte(nullable: false));
            AddColumn("dbo.Actividad", "PendingEnrollment", c => c.Byte(nullable: false));
            CreateIndex("dbo.Actividad", "TipoActividadId");
            AddForeignKey("dbo.Actividad", "TipoActividadId", "dbo.TipoActividad", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividad", "TipoActividadId", "dbo.TipoActividad");
            DropIndex("dbo.Actividad", new[] { "TipoActividadId" });
            DropColumn("dbo.Actividad", "PendingEnrollment");
            DropColumn("dbo.Actividad", "AmountOfEnrollment");
            DropColumn("dbo.Actividad", "TipoActividadId");
        }
    }
}
