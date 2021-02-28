namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sportClubActivitiesMonday20212 : DbMigration
    {
        public override void Up()
        {
            DateTime lunes8hs = new DateTime(2021, 3, 1, 8, 0, 0);
            DateTime lunes9hs = new DateTime(2021, 3, 1, 9, 0, 0);
            DateTime lunes13hs = new DateTime(2021, 3, 1, 13, 0, 0);
            DateTime lunes19hs = new DateTime(2021, 3, 1, 19, 0, 0);

            int id = 1;

            for (int i = 0; i < 5; i++)
            {


                #region adulto8HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, lunes8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, lunes8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto9HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, lunes9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, lunes9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto13HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, lunes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, lunes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, lunes13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto19HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, lunes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, lunes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, lunes19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                lunes8hs = lunes8hs.AddDays(7);
                lunes9hs = lunes9hs.AddDays(7);
                lunes13hs = lunes13hs.AddDays(7);
                lunes19hs = lunes19hs.AddDays(7);


            }
        }

        public override void Down()
        {
        }
    }
}
