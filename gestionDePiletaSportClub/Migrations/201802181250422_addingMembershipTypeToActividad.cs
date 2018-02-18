namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingMembershipTypeToActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Actividad", "MembershipTypeId");
            AddForeignKey("dbo.Actividad", "MembershipTypeId", "dbo.MembershipType", "Id", cascadeDelete: true);
            DropColumn("dbo.Actividad", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actividad", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Actividad", "MembershipTypeId", "dbo.MembershipType");
            DropIndex("dbo.Actividad", new[] { "MembershipTypeId" });
            DropColumn("dbo.Actividad", "MembershipTypeId");
        }
    }
}
