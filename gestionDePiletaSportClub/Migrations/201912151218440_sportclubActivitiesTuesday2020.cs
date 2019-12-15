namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sportclubActivitiesTuesday2020 : DbMigration
    {
        public override void Up()
        {
            DateTime tuesday830hs = new DateTime(2020, 1, 7, 8, 30, 0);
            DateTime tuesday13hs = new DateTime(2020, 1, 7, 13, 0, 0);
            DateTime tuesday19hs = new DateTime(2020, 1, 7, 19, 0, 0);
            DateTime tuesday18hs = new DateTime(2020, 1, 7, 18, 0, 0);
            int id = 1;

            for (int i = 0; i < 51; i++)
            {


                #region adulto830HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, tuesday830hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 6, 1, tuesday830hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},6,6,'{2}',1,3)", 4, 1, tuesday830hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto19HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, tuesday13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 6, 1, tuesday13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},6,6,'{2}',1,3)", 4, 1, tuesday13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto19HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, tuesday19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 6, 1, tuesday19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},6,6,'{2}',1,3)", 4, 1, tuesday19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region menor18hs
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},16,16,'{2}',1,2)", 1, 1, tuesday18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 2, 1, tuesday18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 3, 1, tuesday18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 5, 1, tuesday18hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                tuesday830hs = tuesday830hs.AddDays(7);
                tuesday13hs = tuesday13hs.AddDays(7);
                tuesday19hs = tuesday19hs.AddDays(7);
                tuesday18hs = tuesday18hs.AddDays(7);

            }
        }

        public override void Down()
        {
        }
    }
}
