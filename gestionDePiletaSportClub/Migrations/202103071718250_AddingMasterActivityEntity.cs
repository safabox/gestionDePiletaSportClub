namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMasterActivityEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipTypeId = c.Byte(nullable: false),
                        LevelId = c.Byte(nullable: false),
                        TipoActividadId = c.Byte(nullable: false),
                        AmountOfEnrollment = c.Byte(nullable: false),
                        WeekDay = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Level", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.MembershipType", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TipoActividad", t => t.TipoActividadId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId)
                .Index(t => t.LevelId)
                .Index(t => t.TipoActividadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MasterActivity", "TipoActividadId", "dbo.TipoActividad");
            DropForeignKey("dbo.MasterActivity", "MembershipTypeId", "dbo.MembershipType");
            DropForeignKey("dbo.MasterActivity", "LevelId", "dbo.Level");
            DropIndex("dbo.MasterActivity", new[] { "TipoActividadId" });
            DropIndex("dbo.MasterActivity", new[] { "LevelId" });
            DropIndex("dbo.MasterActivity", new[] { "MembershipTypeId" });
            DropTable("dbo.MasterActivity");
        }
    }
}
