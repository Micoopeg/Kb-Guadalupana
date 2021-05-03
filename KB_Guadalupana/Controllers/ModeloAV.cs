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
        Conexion conexiongeneral = new Conexion();
        //funciones de llenado y consultas
        public DataSet consultarAc(string numero)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
        public DataTable reportemontosresultante(string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT  (SELECT SUM(avt.av_monto) FROM av_tarea avt INNER JOIN av_credito avcr ON avt.codavtarea=avcr.codavtarea WHERE avt.cod_estado=3 AND avt.codtipotarea=1 AND avt.av_monto > 1 AND  avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "'  )-(SELECT SUM(avt.av_monto)  FROM av_tarea avt WHERE  avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avt.codtipotarea=1 AND avt.cod_estado=3 AND avt.av_monto > 1 AND  NOT EXISTS  ( SELECT null FROM  av_credito avcr WHERE avt.codavtarea=avcr.codavtarea )) as resultado", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportetable(string coduser, string area)
        {

            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  SELECT DISTINCT avci.av_controlusuario , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avge ON avt.codavagenda = avge.codavagenda INNER jOIN av_controlingreso avci ON avci.codavcontroling= avge.codavcontroling INNER JOIN av_controlasignado avc ON avc.codavcontroling = avci.codavcontroling  WHERE avge.codavcontroling = '" + coduser + "' AND avci.av_controlarea = '" + area + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);



                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public string url(string app)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gapp.gen_urlcontrol FROM gen_aplicacion gapp WHERE gapp.gen_estadoapp=1 AND gapp.codgenapp= '" + app + "' ;";
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
        public DataSet consultarapps(string id)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gapp.codgenapp , gapp.gen_nombreapp FROM gen_mdimenu gmdi INNER JOIN gen_aplicacion gapp ON gmdi.codgenapp=gapp.codgenapp WHERE gmdi.codgenusuario = '" + id+ "' AND gapp.gen_estadoapp=1 AND gmdi.gen_mdiest = 1 ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }
        public DataTable reportetableunosolo(string coduser, string fecha1, string fecha2)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT avci.av_controlusuario , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avge ON avt.codavagenda = avge.codavagenda INNER jOIN av_controlingreso avci ON avci.codavcontroling= avge.codavcontroling INNER JOIN av_controlasignado avc ON avc.codavcontroling=avci.codavcontroling WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avge.codavcontroling = '" + coduser + "' ; ", sqlCon);
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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


            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT avci.av_controlusuario , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avge ON avt.codavagenda = avge.codavagenda INNER jOIN av_controlingreso avci ON avci.codavcontroling= avge.codavcontroling INNER JOIN av_controlasignado avc ON avc.codavcontroling=avci.codavcontroling WHERE avge.codavcontroling = '" + coduser + "' AND  avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avci.av_controlarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable reportetabletodos(string area)
        {

            DataTable dt = new DataTable();


            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT avci.av_controlusuario , avt.codavtarea, avt.codavagenda, avt.av_titulo, avt.fechaini, avt.fechafin, ave.av_estado FROM av_estado ave INNER JOIN av_tarea avt ON ave.codestado=avt.cod_estado INNER JOIN av_agenda avge ON avt.codavagenda = avge.codavagenda INNER jOIN av_controlingreso avci ON avci.codavcontroling= avge.codavcontroling INNER JOIN av_controlasignado avc ON avc.codavcontroling=avci.codavcontroling WHERE avci.av_controlarea ='" + area + "'; ", sqlCon);
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
           

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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


        public DataSet consultar(string usertarea)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.*FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea=avt.codavtarea WHERE avc.codavcontroling='" + usertarea + "' AND (avt.cod_estado=2 OR avt.cod_estado=1) ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }
        public string consultaragenda(string coduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codavagenda FROM av_agenda avge WHERE avge.codavcontroling   = '" + coduser + "'  ;";
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
          
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
         
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
        public DataSet consultarasigtarea(string tarea)
        {
            DataSet ds1 = new DataSet();


            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avci.av_controlusuario  ,avc.avcifgeneral FROM av_controlasignado avc INNER JOIN av_controlingreso avci  ON avc.codavcontroling = avci.codavcontroling WHERE avc.codavtarea = '" + tarea + "'; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public string[] datetime() {
           
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

           

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

       


            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT avci.av_controlrol FROM av_controlingreso avci WHERE avci.codavcontroling = '" + usuario + "';";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT avci.av_controlarea FROM av_controlingreso avci WHERE avci.codavcontroling = '" + usuario + "';";
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
        public string consultartareauserexistente(string user, string codtar)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT avc.codavtarea FROM av_controlasignado avc WHERE avc.codavcontroling= '" + user + "' AND avc.codavtarea = '"+codtar+"' LIMIT 1 ;";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT  avci.codavcontroling FROM av_controlingreso avci  WHERE avci.avcifgeneral= '" + cif + "';";
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


        public string areauser(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT avci.av_controlarea FROM av_controlingreso avci  WHERE avci.codavcontroling = '" + usuario + "' ; ";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea INNER JOIN av_controlingreso avci ON avci.codavcontroling=avc.codavcontroling  WHERE avc.avcifgeneral = '" + cif + "' AND avci.av_controlarea = '" + area + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porFecha(string fecha1, string fecha2, string area)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avc.codavtarea = avt.codavtarea INNER JOIN av_controlingreso avci ON avci.codavcontroling=avc.codavcontroling WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avci.av_controlarea = '" + area + "'   ;", sqlCon);
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
         
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
           
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
          
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avt.av_fechaini  BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avci.av_controlarea = '" + area + "';", sqlCon);
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


            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avci.av_controlarea = '" + area + "' ;", sqlCon);
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avci.av_controlarea = '" + area + "' AND avt.cod_estado= '" + estado + "' ;", sqlCon);
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avci.av_controlarea = '" + area + "' AND avt.cod_estado = '" + estado + "' ;", sqlCon);
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avt.av_fechaini BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND avt.cod_estado = '" + estado + "' AND avci.codavcontroling = '" + user + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }

        }
        public DataSet porestadousuairo(string estado, string usuario)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avt.cod_estado = '" + estado + "' AND avci.codavcontroling= '" + usuario + "';", sqlCon);
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

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT avt.* FROM av_tarea avt INNER JOIN av_controlasignado avc ON avt.codavtarea=avc.codavtarea INNER JOIN av_controlingreso avci ON avc.codavcontroling = avci.codavcontroling WHERE avt.cod_estado = '" + estado + "' AND avci.av_controlarea = '" + area + "' ;", sqlCon);
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT avci.codavcontroling FROM av_controlingreso avci WHERE avci.av_controlusuario = '" + nomuser + "';";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT  avci.avcifgeneral FROM av_controlingreso avci   WHERE  avci.codavcontroling =   '" + coduser + "'  ;";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
        public void Insertar(string sql)
        {
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
 


        //update

     
       
    }
}