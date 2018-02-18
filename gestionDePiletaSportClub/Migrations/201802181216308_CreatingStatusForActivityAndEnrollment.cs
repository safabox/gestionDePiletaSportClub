namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingStatusForActivityAndEnrollment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstadoActividad",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Actividad", "EstadoActividadId", c => c.Byte(nullable: false));
            AddColumn("dbo.Enrollment", "EnrollmentStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Actividad", "EstadoActividadId");
            CreateIndex("dbo.Enrollment", "EnrollmentStatusId");
            AddForeignKey("dbo.Actividad", "EstadoActividadId", "dbo.EstadoActividad", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "EnrollmentStatusId", "dbo.EnrollmentStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "EnrollmentStatusId", "dbo.EnrollmentStatus");
            DropForeignKey("dbo.Actividad", "EstadoActividadId", "dbo.EstadoActividad");
            DropIndex("dbo.Enrollment", new[] { "EnrollmentStatusId" });
            DropIndex("dbo.Actividad", new[] { "EstadoActividadId" });
            DropColumn("dbo.Enrollment", "EnrollmentStatusId");
            DropColumn("dbo.Actividad", "EstadoActividadId");
            DropTable("dbo.EnrollmentStatus");
            DropTable("dbo.EstadoActividad");
        }
    }
}
