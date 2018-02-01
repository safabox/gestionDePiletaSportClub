namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipType (id,name, description) values (1,'Bebe','Menores de 3 años')");
            Sql("Insert into MembershipType (id,name, description) values (2,'Menor','Menores de entre 3 y 13 años')");
            Sql("Insert into MembershipType (id,name, description) values (3,'Adulto','Mayores de 13 años')");

        }
        
        public override void Down()
        {
        }
    }
}
