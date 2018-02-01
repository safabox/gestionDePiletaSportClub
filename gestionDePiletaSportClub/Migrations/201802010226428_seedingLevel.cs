namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingLevel : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Level (id,name, description) values (1,'Inicial','Inicial')");
            Sql("Insert into Level (id,name, description) values (2,'Intermedio1','Intermedio1')");
            Sql("Insert into Level (id,name, description) values (3,'Intermedio2','Intermedio 2')");
            Sql("Insert into Level (id,name, description) values (4,'Avanzado','Avanzado')");
            Sql("Insert into Level (id,name, description) values (5,'Pre Equipo','Pre Equipo')");

        }

        public override void Down()
        {
        }
    }
}
