namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationBetweenMembershipAndLevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypeLevel",
                c => new
                    {
                        MembershipType_Id = c.Byte(nullable: false),
                        Level_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.MembershipType_Id, t.Level_Id })
                .ForeignKey("dbo.MembershipType", t => t.MembershipType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Level", t => t.Level_Id, cascadeDelete: true)
                .Index(t => t.MembershipType_Id)
                .Index(t => t.Level_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembershipTypeLevel", "Level_Id", "dbo.Level");
            DropForeignKey("dbo.MembershipTypeLevel", "MembershipType_Id", "dbo.MembershipType");
            DropIndex("dbo.MembershipTypeLevel", new[] { "Level_Id" });
            DropIndex("dbo.MembershipTypeLevel", new[] { "MembershipType_Id" });
            DropTable("dbo.MembershipTypeLevel");
        }
    }
}
