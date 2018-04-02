namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMembershipTypeLevel : DbMigration
    {
        public override void Up()
        {

            //adulto
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (3,1)");
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (3,6)");
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (3,4)");
            //menor
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (2,1)");
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (2,2)");
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (2,3)");
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (2,5)");
            //Bebe
            Sql("Insert into MembershipTypeLevel (MembershipType_Id, Level_Id) values (1,1)");



        }
        
        public override void Down()
        {
        }
    }
}
