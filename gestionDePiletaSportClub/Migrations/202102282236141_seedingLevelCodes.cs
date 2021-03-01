namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingLevelCodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Level", "Code", c => c.String(nullable: false));
            Sql("update level set Code='INI' where id=1");
            Sql("update level set Code='INT1' where id=2");
            Sql("update level set Code='INT2' where id=3");
            Sql("update level set Code='INT' where id=4");
            Sql("update level set Code='PreEq' where id=5");
            Sql("update level set Code='ADV' where id=6");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Level", "Code");
        }
    }
}
