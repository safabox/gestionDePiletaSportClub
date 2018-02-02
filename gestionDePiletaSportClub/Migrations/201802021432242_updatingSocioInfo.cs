namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingSocioInfo : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                update AspNetUsers set Name='Socio', LastName='Apellido',DNI=11111111,LevelId=1,PaymentTypeId=1,MembershipTypeId=1 where username='socio@safabox.com'
            ");

            Sql(@"
                update AspNetUsers set Name='Empleado', LastName='Empleado',DNI=22222222 where username='empleado@safabox.com'
            ");
            Sql(@"
                update AspNetUsers set Name='Admin', LastName='Admin',DNI=33333333 where username='admin@safabox.com'
            ");
            Sql(@"
                update AspNetUsers set Name='Coordinador', LastName='Coordinador',DNI=44444444 where username='coordinador@safabox.com'
            ");

        }
        
        public override void Down()
        {
        }
    }
}
