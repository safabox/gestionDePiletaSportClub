namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sportclubActivitiesSat2020 : DbMigration
    {
        public override void Up()
        {
            DateTime sat9hs = new DateTime(2020, 1, 4, 9, 0, 0);
            DateTime sat10hs = new DateTime(2020, 1, 4, 10, 0, 0);
            DateTime sat11hs = new DateTime(2020, 1, 4, 11, 0, 0);
            DateTime sat12hs = new DateTime(2020, 1, 4, 12, 0, 0);



            int id = 1;

            for (int i = 0; i < 52; i++)
            {


                #region adulto9HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, sat9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 6, 1, sat9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},6,6,'{2}',1,3)", 4, 1, sat9hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region adulto10HS
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 1, 1, sat10hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,3)", 6, 1, sat10hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},6,6,'{2}',1,3)", 4, 1, sat10hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion


                #region menor11hs
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 1, 1, sat11hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 2, 1, sat11hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 3, 1, sat11hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 5, 1, sat11hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

                #region bebe11hs
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},15,15,'{2}',1,1)", 1, 1, sat12hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                #endregion


                sat9hs = sat9hs.AddDays(7);
                sat10hs = sat10hs.AddDays(7);
                sat11hs = sat11hs.AddDays(7);
                sat12hs = sat12hs.AddDays(7);


            }
        }
        
        public override void Down()
        {
        }
    }
}
