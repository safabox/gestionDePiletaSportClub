namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sportClubActivitiesWednesday20212 : DbMigration
    {
        public override void Up()
        {

            DateTime miercoles8hs = new DateTime(2021, 3, 3, 8, 0, 0);
            DateTime miercoles9hs = new DateTime(2021, 3, 3, 9, 0, 0);
            DateTime miercoles13hs = new DateTime(2021, 3, 3, 13, 0, 0);
            DateTime miercoles19hs = new DateTime(2021, 3, 3, 19, 0, 0);

            int id = 1;

            for (int i = 0; i < 5; i++)
            {


                #region adulto8HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, miercoles8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, miercoles8hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto9HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, miercoles9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, miercoles9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto13HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 1, 1, miercoles13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, miercoles13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, miercoles13hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region adulto19HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, miercoles19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 6, 1, miercoles19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},4,4,'{2}',1,3)", 4, 1, miercoles19hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                miercoles8hs = miercoles8hs.AddDays(7);
                miercoles9hs = miercoles9hs.AddDays(7);
                miercoles13hs = miercoles13hs.AddDays(7);
                miercoles19hs = miercoles19hs.AddDays(7);


            }
        }

        public override void Down()
        {
        }
    }
}
