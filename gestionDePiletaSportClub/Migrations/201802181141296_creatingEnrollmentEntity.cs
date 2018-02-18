namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingEnrollmentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false),
                        ActividadId = c.Int(nullable: false),
                        Schedule = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enrollment");
        }
    }
}
