namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clasesCovid20192020Sat : DbMigration
    {
        public override void Up()
        {

            DateTime sabado9hs = new DateTime(2020, 12, 19, 9, 0, 0);

            int id = 1;

            for (int i = 0; i < 12; i++)
            {


                #region adulto9HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, sabado9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, sabado9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, sabado9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                sabado9hs = sabado9hs.AddDays(7);


            }
        }

        public override void Down()
        {
        }
    }
}
