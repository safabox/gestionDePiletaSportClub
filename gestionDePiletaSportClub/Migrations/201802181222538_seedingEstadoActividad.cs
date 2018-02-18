namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingEstadoActividad : DbMigration
    {
        public override void Up()
        {
            
            Sql("Insert into EstadoActividad (id,name) values (1,'Abierta')");
            Sql("Insert into EstadoActividad (id,name) values (2,'Cerrada')");
            Sql("Insert into EstadoActividad (id,name) values (3,'Cancelada')");
        }
        
        public override void Down()
        {
        }
    }
}
