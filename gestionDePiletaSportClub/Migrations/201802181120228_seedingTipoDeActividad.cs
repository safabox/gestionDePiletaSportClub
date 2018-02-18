namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingTipoDeActividad : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into TipoActividad (id,name) values (1,'Natacion')");
        }
        
        public override void Down()
        {
        }
    }
}
