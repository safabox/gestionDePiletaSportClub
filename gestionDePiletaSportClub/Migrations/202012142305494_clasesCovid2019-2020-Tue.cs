namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clasesCovid20192020Tue : DbMigration
    {
        public override void Up()
        {

            DateTime martes8hs = new DateTime(2020, 12, 15, 8, 0, 0);
            DateTime martes9hs = new DateTime(2020, 12, 15, 9, 0, 0);
            DateTime martes13hs = new DateTime(2020, 12, 15, 13, 0, 0);
            DateTime martes18hs = new DateTime(2020, 12, 15, 18, 0, 0);
            DateTime martes19hs = new DateTime(2020, 12, 15, 19, 0, 0);

            int id = 1;

            for (int i = 0; i < 12; i++)
            {


                #region adulto8HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, martes8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, martes8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, martes8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto9HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, martes9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, martes9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, martes9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto13HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, martes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, martes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, martes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto18HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, martes18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, martes18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, martes18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto19HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, martes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, martes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, martes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                martes8hs = martes8hs.AddDays(7);
                martes9hs = martes9hs.AddDays(7);
                martes13hs = martes13hs.AddDays(7);
                martes18hs = martes18hs.AddDays(7);
                martes19hs = martes19hs.AddDays(7);


            }
        }

        public override void Down()
        {
        }
    }
}
