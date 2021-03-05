using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using KB_Guadalupana.Controllers;
namespace KBGuada.Models
{
    public class ModeloAV
    {
        Conexion cn = new Conexion();
        MySqlCommand comm;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        //funciones de llenado y consultas
        public DataSet consultarAc(string numero)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            { 
                try
            {
                sqlCon.Open();
                MySqlCommand command = new MySqlCommand(" select * from  av_subtarea where codtarea = '" + numero + "' AND codestado = 1 ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                 

            }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;
            }

        }

        public DataTable reportetable(string coduser, string area) {

            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT geu.gen_usuarionombre , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avg ON avt.codavagenda = avg.codavagenda INNER jOIN gen_usuario geu ON geu.codgenusuario= avg.codgenusuario INNER JOIN av_controlasignado avc ON avc.codgenusuario=geu.codgenusuario WHERE avg.codgenusuario = '" + coduser + "' AND geu.gen_area_codgenarea = '" + area + "'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable reportetableunosolo(string coduser, string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            { 

                try
            {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT geu.gen_usuarionombre , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avg ON avt.codavagenda = avg.codavagenda INNER jOIN gen_usuario geu ON geu.codgenusuario= avg.codgenusuario INNER JOIN av_controlasignado avc ON avc.codgenusuario=geu.codgenusuario WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avg.codgenusuario = '" + coduser + "' ; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);

                  
            }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportemontos( string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT cast( (SELECT COUNT( avcr.av_numcredito) FROM av_tarea avt INNER JOIN av_credito avcr ON avt.codavtarea = avcr.codavtarea  WHERE avt.av_fechaini  BETWEEN '"+fecha1+"' AND '"+fecha2+"' ) / (SELECT COUNT(avt.codavtarea) as tareas  FROM av_tarea avt   WHERE avt.av_fechaini  BETWEEN '"+fecha1+"' AND '"+fecha2+"' AND avt.cod_estado = 3 and avt.codtipotarea=1) as decimal(4,3) ) * 100 as resultado", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportemontosdatos(string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" select `avt`.`codavtarea` AS `codavtarea`,`avt`.`av_titulo` AS `av_titulo`,`ave`.`av_estado` AS `av_estado`,`avt`.`av_monto` AS `av_monto`, `avt`.`fechaini` AS `fechaini`, `avt`.`fechafin` AS `fechafin` from (`bdkbguadalupana`.`av_tarea` `avt` join `bdkbguadalupana`.`av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) where avt.av_fechaini BETWEEN '"+fecha1+"' AND '"+fecha2+"' AND `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportemontostotal(string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" select `avt`.`codavtarea` AS `codavtarea`,`avt`.`av_titulo` AS `av_titulo`,`ave`.`av_estado` AS `av_estado`,`avt`.`av_monto` AS `av_monto`, `avt`.`fechaini` AS `fechaini`, `avt`.`fechafin` AS `fechafin` from (`bdkbguadalupana`.`av_tarea` `avt` join `bdkbguadalupana`.`av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) where avt.av_fechaini BETWEEN '"+fecha1+"' AND '"+fecha2+"' AND `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportetableuserfecha(string coduser, string fecha1, string fecha2, string area)
        {

            DataTable dt = new DataTable();


            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT geu.gen_usuarionombre , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avg ON avt.codavagenda = avg.codavagenda INNER jOIN gen_usuario geu ON geu.codgenusuario= avg.codgenusuario INNER JOIN av_controlasignado avc ON avc.codgenusuario=geu.codgenusuario WHERE avg.codgenusuario = '" + coduser + "' AND  avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND geu.gen_area_codgenarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportetabletodos(string area )
        {

            DataTable dt = new DataTable();


            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT geu.gen_usuarionombre , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avg ON avt.codavagenda = avg.codavagenda INNER jOIN gen_usuario geu ON geu.codgenusuario= avg.codgenusuario INNER JOIN av_controlasignado avc ON avc.codgenusuario=geu.codgenusuario WHERE geu.gen_area_codgenarea ='" + area + "'; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataSet consultarAcReal(string numero)
        {
            DataSet ds1 = new DataSet();
           

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  select * from  av_subtarea where codtarea = '" + numero + "' AND codestado = 3 ; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return ds1;
            }

        }
     

        public DataSet consultar(string usertarea) {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
               
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.*FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea=avt.codavtarea WHERE avc.codgenusuario='" + usertarea + "' AND (avt.cod_estado=2 OR avt.cod_estado=1) ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);
                   
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" ); }
                return ds1;

            }



        }
        public string consultaragenda(string coduser) {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codavagenda FROM av_agenda WHERE codgenusuario  = '" + coduser + "'  ;";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }





        }
     
        public string[] estadopermisotarea(string tarea) {
          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select cod_estado, codavpertarea from av_tarea where codavtarea = '" + tarea + "'; ";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }


        }
        public string[] permisotarea(string tarea)
        {
         
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select codavpertarea from av_tarea where codavtarea = '" + tarea + "';  ";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }


        }
        public DataSet consultarasigtarea(string tarea) {
            DataSet ds1 = new DataSet();
        

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT geu.gen_usuarionombre ,avc.avcifgeneral FROM av_controlasignado avc INNER JOIN gen_usuario geu  ON avc.codgenusuario = geu.codgenusuario WHERE avc.codavtarea = '" + tarea + "'; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);
                
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public string[] datetime() {
           
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DATE_FORMAT(CURRENT_DATE,  '%Y %m %d'), CURRENT_TIME ;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }

        }
        public string[] consultafecha(string tarea) {

           

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DATE_FORMAT( avt.av_fechaini  ,'%Y %m %d %T' ), DATE_FORMAT( avt.av_fechafin ,'%Y %m %d %T' ) FROM av_tarea avt where avt.codavtarea = '" + tarea + "'; ";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }


        }
   
     
        public string[] consultadatostarea(string tarea)
        {

       


            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codavtarea, codavagenda, av_titulo, av_pnombre, av_papellido, av_telefono,av_monto, DATE_FORMAT(av_fechaini,  '%Y %m %d %T'), DATE_FORMAT(av_fechafin, '%Y %m %d %T') , fechaini, fechafin, av_descripcion, cod_estado, codprioridad, codtipotarea, codasociado, codavpertarea FROM `av_tarea` WHERE codavtarea = '" + tarea + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }

        }
     
        public string consultarRol(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gen_roles_codgenroles FROM gen_usuario WHERE codgenusuario= '" + usuario + "'; ";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }



        }
        public string consultarArea(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gen_area_codgenarea FROM bdkbguadalupana.gen_usuario WHERE codgenusuario = '" + usuario + "';";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }
        }
        public string consultartareauserexistente(string user) {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codavtarea FROM av_controlasignado WHERE codgenusuario= '"+user+"';";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }

        }
        public string buscarusercif(string cif)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT DISTINCT epc.codgenusuario FROM ep_control epc  INNER JOIN ep_informaciongeneral epig ON epig.ep_informaciongeneralcif=epc.codepinformaciongeneralcif WHERE epc.codepinformaciongeneralcif= '"+cif+"';";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }

        }


        public string areauser(string usuario) {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gen_area_codgenarea FROM bdkbguadalupana.gen_usuario WHERE codgenusuario = '" + usuario + "' ; ";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }



        }

        public string tipotarea(string tarea)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codtipotarea FROM av_tarea WHERE codavtarea = '" + tarea + "' ; ";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }



        }

        //filtros de busqueda
        public DataSet porcif(string cif, string area)
        {
            DataSet ds1 = new DataSet();
          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea INNER JOIN gen_usuario geu ON geu.codgenusuario=avc.codgenusuario  WHERE avc.avcifgeneral = '" + cif + "' AND geu.gen_area_codgenarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porFecha( string fecha1, string fecha2, string area)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea INNER JOIN gen_usuario geu ON geu.codgenusuario=avc.codgenusuario WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND geu.gen_area_codgenarea = '" + area + "'   ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porcifFecha(string cif, string fecha1, string fecha2)
        {
            DataSet ds1 = new DataSet();
         
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea WHERE avc.avcifgeneral = '" + cif + "' AND avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porcifEstado(string cif, string estado)
        {
            DataSet ds1 = new DataSet();
           
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea WHERE avc.avcifgeneral = '" + cif + "' AND avt.cod_estado = '" + estado + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porcifFechaEstado(string cif, string fecha1, string fecha2, string estado)
        {
            DataSet ds1 = new DataSet();
          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea WHERE avc.avcifgeneral = '" + cif + "' AND avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avt.cod_estado = '" + estado + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porareaFecha(string area, string fecha1, string fecha2)
        {
            DataSet ds1 = new DataSet();
          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND geu.gen_area_codgenarea = '" + area + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }

        public DataSet porarea(string area)
        {
            DataSet ds1 = new DataSet();
        

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE geu.gen_area_codgenarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }
        }
        public DataSet porareaEstado(string area, string estado)
        {
            DataSet ds1 = new DataSet();
    
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE geu.gen_area_codgenarea = '" + area + "' AND avt.cod_estado= '" + estado + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porareafechaEstado(string area, string fecha1, string fecha2, string estado)
        {
            DataSet ds1 = new DataSet();
          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND geu.gen_area_codgenarea = '" + area + "' AND avt.cod_estado = '" + estado + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porfechaEstado(string fecha1, string fecha2, string estado, string user)
        {
            DataSet ds1 = new DataSet();
      
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avt.cod_estado = '" + estado + "' AND geu.codgenusuario = '" + user + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porestadousuairo( string estado, string usuario)
        {
            DataSet ds1 = new DataSet();
       
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE avt.cod_estado = '" + estado + "' AND geu.codgenusuario= '" + usuario + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porestadoadmin(string estado, string area)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN gen_usuario geu ON avc.codgenusuario = geu.codgenusuario WHERE avt.cod_estado = '" + estado + "' AND geu.gen_area_codgenarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(" + campo + "+1) FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                    //Console.WriteLine("El resultado es: " + camporesultante);
                    if (String.IsNullOrEmpty(camporesultante))
                        camporesultante = "1";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }


        }
        public string obtenercoduser(string nomuser)
        {

            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT geu.codgenusuario FROM gen_usuario geu WHERE geu.gen_usuarionombre = '" + nomuser + "';";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }



        }

        public string obtenercif(string coduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT DISTINCT epig.ep_informaciongeneralcif FROM ep_informaciongeneral epig INNER JOIN ep_control epc   ON epc.codepinformaciongeneralcif = epig.ep_informaciongeneralcif   WHERE  epc.codgenusuario =   '" + coduser + "'  ;";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }




        }

        public string obtenerconteo(string tarea)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT COUNT(codsubtarea)  FROM `av_subtarea`  WHERE codtarea = '"+tarea+"' AND codestado = 1";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();

                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }




        }
      

        //---------------fin----------------------------
        //insert


        public void insertartarea(string sql) {
            try
            {
                cn.conectar();
                
                Console.WriteLine(sql);
                comm = new MySqlCommand(sql, cn.conectar());
                MySqlDataReader mostrar = comm.ExecuteReader();
              
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            
            }


        }
        public MySqlDataReader insertartablas(string tabla, string[] datos)
        {
            {
                string query = "";
                for (int i = 0; i < datos.Length; i++)
                {
                    query += "'";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                }
                try
                {
                    cn.conectar();
                    string consulta = "insert into " + tabla + " values(" + query + ");";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, cn.conectar());
                    MySqlDataReader mostrar = comm.ExecuteReader();
                    return mostrar;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    return null;
                }
            }



        }


        //update

        public MySqlDataReader modificartablas(string tabla, string[] campos, string[] datos)
        {
            string query = "";
            int n = 1;
            query += " set ";
            for (int i = 1; i < datos.Length; i++)
            {
                query += campos[n];
                query += " = '";
                query += datos[i];
                if (i == datos.Length - 1)
                    query += "'";
                else
                    query += "',";
                n++;
            }

            try
            {
                cn.conectar();
                string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrar = comm.ExecuteReader();
                Console.WriteLine(consulta);
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }



        //delete

        //ingreso de usuario

        public MySqlDataReader validarfechadeingreso_ep()
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT gen_usuarionombre,ep_administracionlotefechainicio,ep_administracionfechafin,a.codepadministracionlote,ep_administracionloteestado " +
                    "FROM ep_control a " +
                    "INNER JOIN gen_usuario b " +
                    "INNER JOIN ep_administracionlote c " +
                    "ON a.codgenusuario = b.codgenusuario AND a.codepadministracionlote = c.codepadministracionlote WHERE ep_administracionloteestado = 1;";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public MySqlDataReader busquedacif(string usuario, string lote)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT codepinformaciongeneralcif,gen_usuarionombre " +
                    "FROM ep_control a " +
                    "INNER JOIN gen_usuario b " +
                    "ON a.codgenusuario = b.codgenusuario AND codepadministracionlote= '" + lote + "' where  b.gen_usuarionombre ='" + usuario + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader estadodeprocesocif(string cif)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT codeptipoestado FROM ep_informaciongeneral WHERE codepinformaciongeneralcif = '" + cif + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
     
        public MySqlDataReader validarcifantiguo(string usuario)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT codepinformaciongeneralcif,codepadministracionlote FROM ep_control  WHERE codgenusuario='" + usuario + "' ORDER BY codepadministracionlote DESC limit 1,1;";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                Console.WriteLine(consulta);

                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}