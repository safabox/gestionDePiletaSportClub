namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingInfoToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "DNI", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LevelId", c => c.Byte());
            AddColumn("dbo.AspNetUsers", "PaymentTypeId", c => c.Byte());
            AddColumn("dbo.AspNetUsers", "MembershipTypeId", c => c.Byte());
            CreateIndex("dbo.AspNetUsers", "LevelId");
            CreateIndex("dbo.AspNetUsers", "PaymentTypeId");
            CreateIndex("dbo.AspNetUsers", "MembershipTypeId");
            AddForeignKey("dbo.AspNetUsers", "LevelId", "dbo.Level", "Id");
            AddForeignKey("dbo.AspNetUsers", "MembershipTypeId", "dbo.MembershipType", "Id");
            AddForeignKey("dbo.AspNetUsers", "PaymentTypeId", "dbo.PaymentType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PaymentTypeId", "dbo.PaymentType");
            DropForeignKey("dbo.AspNetUsers", "MembershipTypeId", "dbo.MembershipType");
            DropForeignKey("dbo.AspNetUsers", "LevelId", "dbo.Level");
            DropIndex("dbo.AspNetUsers", new[] { "MembershipTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "PaymentTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "LevelId" });
            DropColumn("dbo.AspNetUsers", "MembershipTypeId");
            DropColumn("dbo.AspNetUsers", "PaymentTypeId");
            DropColumn("dbo.AspNetUsers", "LevelId");
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "DNI");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
