namespace gestionDePiletaSportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreoTurnosMenoresViernes : DbMigration
    {
        public override void Up()
        {
            
           
            DateTime fri17hs = new DateTime(2018, 2, 23, 17, 0, 0);

            int id = 1;

            for (int i = 0; i < 45; i++)
            {


                

                

                


                #region menor17hs
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},8,8,'{2}',1,2)", 1, 1, fri17hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},7,7,'{2}',1,2)", 2, 1, fri17hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},7,7,'{2}',1,2)", 3, 1, fri17hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                Sql(String.Format("Insert into Actividad ( levelid,tipoActividadid,amountofenrollment,pendingenrollment,schedule,estadoActividadid,membershiptypeid) values ({0},{1},7,7,'{2}',1,2)", 5, 1, fri17hs.ToString("yyyy-MM-ddTHH:mm:ss")));
                id++;
                #endregion

               
                fri17hs = fri17hs.AddDays(7);


            }
        }
        
        public override void Down()
        {
        }
    }
}
