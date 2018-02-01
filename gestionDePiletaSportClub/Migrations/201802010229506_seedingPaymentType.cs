namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingPaymentType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into PaymentType (id,name) values (1,'Efectivo')");
            Sql("Insert into PaymentType (id,name) values (2,'Debito')");
        }
        
        public override void Down()
        {
        }
    }
}
