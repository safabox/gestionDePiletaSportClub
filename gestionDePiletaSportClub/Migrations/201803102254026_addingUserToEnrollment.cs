namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUserToEnrollment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollment", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Enrollment", "ApplicationUserId");
            AddForeignKey("dbo.Enrollment", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollment", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Enrollment", "ApplicationUserId", c => c.String(nullable: false));
        }
    }
}
