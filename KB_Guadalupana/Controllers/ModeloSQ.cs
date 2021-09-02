using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Controllers
{
   
    public class ModeloSQ
    {
        Conexion conexiongeneral = new Conexion();
        public string[] datetime()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
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
        public string[] datetime2()
        {

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
        public string[] datospuesto(string codpuesto)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM `sq_puestoseval` WHERE `codsqpuesto` = '"+codpuesto+"' ;";
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
        public string[] datosescala(string codescala)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM `sq_escalapregunta` WHERE `codsqescala` = '" + codescala + "' ;";
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
        public string[] datosescaladatos(string codescala)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM `sq_escala` WHERE `codsqescalaid` = '" + codescala + "' ;";
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
        public string[] preguntas(string pregunta)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM `sq_preguntas` WHERE `codsqpregunta` = '" + pregunta + "' ;";
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
        public string[] datosasignado(string codasignado)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT sqo.codsqorganigrama, sqo.codsqpuesto, sqo.organisup FROM sq_organigrama sqo INNER JOIN sq_puestoseval sqp ON sqp.codsqpuesto= sqo.codsqpuesto WHERE sqo.codsqorganigrama = '" + codasignado + "' ;";
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
        public string[] datosevaluacion(string codeval)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT sqe.comentario, sqe.nombreevaluacion,  DATE_FORMAT(sqe.fechainicial,  '%Y %m %d %T')  ,  DATE_FORMAT(sqe.fechafinal,  '%Y %m %d %T') , sqe.tipoevaluacion, sqe.estado FROM sq_evaluacion sqe INNER JOIN sq_tipoevaluacion sqt ON sqe.tipoevaluacion = sqt.codsqtipoeval INNER JOIN sq_estadoeval sqest ON sqest.codsqlesteval = sqe.estado WHERE sqe.codsqeval =  '" + codeval + "' ;";
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
        public DataSet preguntas()
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `sq_preguntas` where estado = 1 ORDER BY ordenpregunta ASC ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        public DataSet preguntas2()
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `sq_preguntas` where estado = 1 AND codsqpregunta IN (1,2,3,4,5,6,7,8,9,10,11,12,13,21,22,23) ORDER BY ordenpregunta ASC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }
        public DataSet escala(string escala)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `sq_escala` WHERE estado = 1 AND codsqescala = '"+escala+"'  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        public void Insertar(string sql)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {

                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

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
        public string obtenerorden(string pregunta)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT ordenpregunta FROM sq_preguntas WHERE codsqpregunta = '" + pregunta + "' ;";
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
        public string obtenerescala(string pregunta)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqescala FROM sq_preguntas WHERE codsqpregunta = '" + pregunta + "' ;";
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
        public string obtenertipo(string pregunta)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqtipopregunta FROM sq_preguntas WHERE codsqpregunta = '" + pregunta + "' ;";
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
        public string obtenerordendeultima()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sqp.ordenpregunta)  FROM sq_preguntas sqp INNER JOIN sq_evaluacion sqe WHERE sqp.estado = 1 and sqe.estado = 1;";
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
        public string obtenerultima()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sqp.`codsqpregunta` )  FROM sq_preguntas sqp INNER JOIN sq_evaluacion sqe WHERE sqp.estado = 1 and sqe.estado = 1;";
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
        public DataTable llenarmesamesaasignado()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `sq_puestoseval` ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarasignadosevaluadores()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT sqo.codsqorganigrama , sqp.puestodescrip as puesto,sqp1.puestodescrip as subpuesto FROM sq_organigrama sqo INNER JOIN sq_puestoseval sqp ON sqo.codsqpuesto = sqp.codsqpuesto INNER JOIN sq_puestoseval sqp1 ON sqo.organisup= sqp1.codsqpuesto ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarpreguntastab()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT sqp.codsqpregunta, sqp.pregunta ,sqp.InfoExtrapregunta, sqe.codsqeval, sqtp.tipopregunta, sqp.ordenpregunta, sqpreg.estado, sqesq.nombreescala FROM sq_preguntas sqp INNER JOIN sq_evaluacion sqe ON sqp.codsqeval= sqe.codsqeval INNER JOIN sq_tipopregunta sqtp ON sqtp.codqstipopregunta = sqp.codsqtipopregunta INNER JOIN sq_estadopregunta sqpreg ON sqpreg.codsqestadopregunta = sqp.estado INNER JOIN sq_escalapregunta sqesq ON sqesq.codsqescala = sqp.codsqescala WHERE sqe.estado = 1 ORDER BY ordenpregunta ASC ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarescalas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT sqesc.codsqescala, sqesc.nombreescala, sqest.estadoeval FROM sq_escalapregunta sqesc INNER JOIN sq_estadoeval sqest ON sqesc.estadoescala = sqest.codsqlesteval", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarescalasdatos()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT sqe.codsqescalaid, sqep.nombreescala,sqe.rangonumerico, sqe.valortexto ,sqeval.estadoeval FROM sq_escala sqe INNER JOIN sq_escalapregunta sqep ON sqe.codsqescala = sqep.codsqescala INNER JOIN sq_estadoeval sqeval ON sqeval.codsqlesteval = sqe.estado ORDER BY `sqe`.`codsqescalaid` ASC  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable buscarentablas(string consulta)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" "+consulta+" ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        //public string consultarpuesto(string idpuesto)
        //{
        //    String camporesultante = "";
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string sql = "SELECT exc.nomcom FROM ex_aleatorio exal INNER JOIN ex_controlingreso exc ON exc.codexcontroling = exal.asignado INNER JOIN ex_lotemensajero exl ON exl.ex_mensajerocod = exal.numero WHERE exal.numero = '" + numero + "'  ;";
        //            MySqlCommand command = new MySqlCommand(sql, sqlCon);
        //            MySqlDataReader reader = command.ExecuteReader();
        //            reader.Read();
        //            camporesultante = reader.GetValue(0).ToString();

        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine(camporesultante);
        //        }
        //        return camporesultante;
        //    }

        //}

        public string obtenerevaluacion()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqeval FROM sq_evaluacion WHERE estado = 1";
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




        public DataTable PROM15(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT a.usuario_calificado,c.ordenpregunta, CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio1 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 0) AND (`ordenpregunta` < 6)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }


        //seccion de promedios
        public DataTable PROM613(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable PROM6132(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 14)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable PROM1420(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio3 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 13) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }



    

        public DataTable jefe15prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable jefe613prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 14)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable jefe1420prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio3 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 13) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable auto15prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable auto613prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio2 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 5) AND (`ordenpregunta` < 14)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable auto1420prom(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.usuario_calificado,c.ordenpregunta,CAST(AVG(b.nota) AS DECIMAL(10,2)) as promedio3 FROM sq_resultadopregunta a INNER JOIN sq_calificaciones b   INNER JOIN sq_preguntas c ON b.codsqcalificacion=a.resultado AND a.codsqpregunta=c.codsqpregunta WHERE a.usuario_calificado='" + iduser + "' GROUP BY a.codsqpregunta, a.usuario_calificado HAVING ((`ordenpregunta` > 13) AND (`ordenpregunta` < 21)) ORDER BY c.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }






        public string obteneridusuario(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqpersonal FROM sq_personal WHERE usuario = '" + usuario+"'";
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

        public string obtenerusuariopersonal(string idusuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqpersonal FROM sq_personal WHERE codgen_usuario = '" + idusuario + "'";
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

        public string[] autoevaluacionresuelta(string idusuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codsqrespreg FROM sq_resultadopregunta WHERE codsquser = '"+idusuario+ "' AND usuario_calificado = '"+idusuario+"' AND codsqpregunta = 1";
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

        public string[] evaluacionjeferesuelta(string idusuario, string usuariocal)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codsqrespreg FROM sq_resultadopregunta WHERE codsquser = '" + idusuario + "' AND usuario_calificado = '" + usuariocal + "' AND codsqpregunta = 14";
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

        public string obtenerarea(string idusuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT area FROM sq_personal WHERE codsqpersonal = '" + idusuario + "'";
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

        public string obtenerpuesto(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codesqpuesto FROM sq_personal WHERE usuario = '" + usuario + "'";
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
        public string obtenerpuestoid(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codesqpuesto FROM sq_personal WHERE codsqpersonal = '" + usuario + "'";
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

        public string obtenernombrepuesto(string idpuesto)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT puestodescrip FROM sq_puestoseval WHERE codsqpuesto = '" + idpuesto + "'";
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

        public string obtenerjefe(string idpuesto)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqpuesto FROM sq_organigrama WHERE organisup = '" + idpuesto + "'";
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

        public string obtenerfecha(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT fechaingreso FROM sq_personal WHERE usuario = '" + usuario + "'";
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

        public string[] usuariosevaluados(string idusuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[50];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DISTINCT usuario_calificado FROM sq_resultadopregunta WHERE codsquser = '"+idusuario+"'";
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

        public string obtenerpuestojefe(string idpuesto)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT DISTINCT codsqpuesto FROM sq_organigrama WHERE organisup = '" + idpuesto + "'";
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
        public string obtenerpuestojefe2(string idpuesto)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT DISTINCT codsqpuesto FROM sq_organigrama WHERE codsqpuesto = '" + idpuesto + "'";
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
        public string obtenerusuario(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT usuario FROM sq_personal WHERE codsqpersonal = '" + usuario + "'";
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

        public string[] obtenerjefaso(string idpuesto)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codsqpuesto FROM sq_organigrama WHERE organisup = '" + idpuesto + "';";
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
        public string obtenerunidad(string idusuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT unidadoperativa FROM sq_personal WHERE codsqpersonal =  '" + idusuario + " '";
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
        public string obteneridjefaso(string idpuesto, string unidadop)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codsqpersonal FROM sq_personal WHERE codesqpuesto =  '" + idpuesto + "' AND unidadoperativa = '" + unidadop + "' ; ";
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

        public DataTable reportependientes()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" select a.codsqpersonal as COD, a.codsqcifgeneral as CIF, nombrepersonal as NOMBRE, upper(puestodescrip) as PUESTO, a.gerencia as GERENCIA ,(select count(*) from bdkbguadalupana.sq_organigrama as c inner join bdkbguadalupana.sq_personal as d ON d.codesqpuesto = c.organisup where c.codsqpuesto = b.codsqpuesto and d.fechaingreso < '2021-04-23' AND d.unidadoperativa = a.unidadoperativa) AS EVALUACIONES_A_CARGO, 1 as EVALUACION_PROPIA, 1 AS EVALUACION_JEFE, (select count(distinct(e.usuario_calificado)) from bdkbguadalupana.sq_resultadopregunta e where e.codsquser = a.codsqpersonal) as EVALUACIONES_COMPLETADAS from bdkbguadalupana.sq_personal a, bdkbguadalupana.sq_puestoseval b where b.codsqpuesto = a.codesqpuesto AND a.fechaingreso < '2021-04-23' ORDER BY `COD` ASC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable repodatanotas()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT e.nombrepersonal as EVALUADO, pu2.puestodescrip AS PUESTO_EVALUADO ,d.nombrepersonal as EVALUADOR , pu.puestodescrip AS PUESTO_EVALUADOR , TRUNCATE(avg(g.nota)*10 , 1) AS NOTA FROM sq_resultadopregunta c INNER JOIN sq_personal d ON c.codsquser = d.codsqpersonal INNER JOIN sq_personal e ON e.codsqpersonal = c.usuario_calificado INNER JOIN sq_calificaciones g ON g.codsqcalificacion = c.resultado INNER JOIN sq_puestoseval pu on pu.codsqpuesto = d.codesqpuesto INNER JOIN sq_puestoseval pu2 on pu2.codsqpuesto = e.codesqpuesto where g.nota !=0 GROUP BY d.nombrepersonal, e.nombrepersonal, pu2.puestodescrip, pu.puestodescrip ORDER BY `evaluado` ASC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable notafinal(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("    SELECT e.nombrepersonal as EVALUADO, pu2.puestodescrip AS PUESTO_EVALUADO , d.nombrepersonal as EVALUADOR , pu.puestodescrip AS PUESTO_EVALUADOR , TRUNCATE(avg(g.nota) *10 , 1) AS NOTA FROM sq_resultadopregunta c INNER JOIN sq_personal d ON c.codsquser = d.codsqpersonal INNER JOIN sq_personal e ON e.codsqpersonal = c.usuario_calificado INNER JOIN sq_calificaciones g ON g.codsqcalificacion = c.resultado INNER JOIN sq_puestoseval pu on pu.codsqpuesto = d.codesqpuesto INNER JOIN sq_puestoseval pu2 on pu2.codsqpuesto = e.codesqpuesto where g.nota !=0 AND c.usuario_calificado = '" + iduser + "' GROUP BY d.nombrepersonal, e.nombrepersonal, pu2.puestodescrip, pu.puestodescrip ORDER BY `evaluado` ASC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }


      

        public DataTable AUTO15(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado  WHERE a.usuario_calificado = '" + iduser + "' HAVING EVALUADO= EVALUADOR AND ORDEN >0 AND ORDEN<6 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable AUTO613(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' HAVING EVALUADO= EVALUADOR AND ORDEN >5 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable AUTO6132(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' HAVING EVALUADO= EVALUADOR AND ORDEN >5 AND ORDEN<14 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable AUTO1420(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' HAVING EVALUADO= EVALUADOR AND ORDEN >13 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }




        public DataTable JEFE15(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) HAVING ORDEN >0 AND ORDEN<6 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE613(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) HAVING ORDEN >5 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE6132(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) HAVING ORDEN >5 AND ORDEN<14 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE1420(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) HAVING ORDEN >13 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }


  
     
        public DataTable sub15(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.usuario_calificado AS EVALUADO , b.pregunta, CAST(avg(c.nota) AS DECIMAL(10,2)) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) GROUP BY b.ordenpregunta,a.usuario_calificado,b.pregunta HAVING ORDEN>0 AND ORDEN<6 ORDER BY b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable sub613(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.usuario_calificado AS EVALUADO , b.pregunta, CAST(avg(c.nota) AS DECIMAL(10,2)) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) GROUP BY b.ordenpregunta,a.usuario_calificado,b.pregunta HAVING ORDEN>5 AND ORDEN<14 ORDER BY b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable sub1420(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.usuario_calificado AS EVALUADO , b.pregunta, CAST(avg(c.nota) AS DECIMAL(10,2)) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) GROUP BY b.ordenpregunta,a.usuario_calificado,b.pregunta HAVING ORDEN>13 AND ORDEN<21 ORDER BY b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable COMENT(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta,  a.respuesta_texto FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '"+iduser+"' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '"+iduser+"' AND a.unidadoperativa = c.unidadoperativa) HAVING ORDEN >20 AND ORDEN<24 ORDER BY a.codsqrespreg, b.ordenpregunta ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        

        public DataTable ENCABEZADO(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  SELECT 'Junio' as Periodo,now() as fecha,a.nombrepersonal AS EVALUADO,a.gerencia as unidadoperativa,e.puestodescrip AS PUESTOEVALUADO,c.nombrepersonal AS JEFE,d.puestodescrip AS PUESTOJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable preguntassub()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  select `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta` AS `ORDEN`,`bdkbguadalupana`.`sq_preguntas`.`pregunta` AS `pregunta`,`bdkbguadalupana`.`sq_preguntas`.`InfoExtrapregunta` AS `InfoExtrapregunta` from `bdkbguadalupana`.`sq_preguntas` where (`bdkbguadalupana`.`sq_preguntas`.`estado` = 1) having ((`ORDEN` > 0) and (`ORDEN` < 14)) order by `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta`", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable preguntasjefe()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  select `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta` AS `ORDEN`,`bdkbguadalupana`.`sq_preguntas`.`pregunta` AS `pregunta`,`bdkbguadalupana`.`sq_preguntas`.`InfoExtrapregunta` AS `InfoExtrapregunta` from `bdkbguadalupana`.`sq_preguntas` where (`bdkbguadalupana`.`sq_preguntas`.`estado` = 1) having ((`ORDEN` > 0) and (`ORDEN` < 17)) order by `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta`", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }

        public DataTable preguntasrangosjefe1()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.ordenpregunta as orden, a.pregunta, a.InfoExtrapregunta, c.rangonumerico, c.valortexto FROM sq_preguntas a INNER JOIN sq_escalapregunta b ON a.codsqescala = b.codsqescala INNER JOIN sq_escala c ON b.codsqescala = c.codsqescala WHERE a.estado = 1 HAVING orden>0 AND orden<21 ORDER BY `orden` ASC ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable preguntasrangosjefe2()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT a.ordenpregunta as orden, a.pregunta, a.InfoExtrapregunta, c.rangonumerico, c.valortexto FROM sq_preguntas a INNER JOIN sq_escalapregunta b ON a.codsqescala = b.codsqescala INNER JOIN sq_escala c ON b.codsqescala = c.codsqescala WHERE a.estado = 1 HAVING orden>0 AND orden<14 ORDER BY `orden` ASC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable preguntasjefe17()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  select `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta` AS `ORDEN`,`bdkbguadalupana`.`sq_preguntas`.`pregunta` AS `pregunta`,`bdkbguadalupana`.`sq_preguntas`.`InfoExtrapregunta` AS `InfoExtrapregunta` from `bdkbguadalupana`.`sq_preguntas` where (`bdkbguadalupana`.`sq_preguntas`.`estado` = 1) having ((`ORDEN` > 16) and (`ORDEN` < 21)) order by `bdkbguadalupana`.`sq_preguntas`.`ordenpregunta`", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public string[] puestos(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + credito + "'";
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
        public string iduser(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT `codsqpersonal` FROM `sq_personal` WHERE `usuario` = '" + usuario + "' ";
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


        //modulo agencias

    


        public DataTable ENCABEZADOmod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  SELECT 'Junio' as Periodo,now() as fecha,a.nombrepersonal AS EVALUADO,a.unidadoperativa,e.puestodescrip AS PUESTOEVALUADO,c.nombrepersonal AS JEFE,d.puestodescrip AS PUESTOJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "'  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE15mod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) HAVING ORDEN >0 AND ORDEN<6 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE613mod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) HAVING ORDEN >5 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE6132mod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) HAVING ORDEN >5 AND ORDEN<14 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable JEFE1420mod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta, c.nota FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) HAVING ORDEN >13 AND ORDEN<21 ORDER BY a.codsqrespreg, b.ordenpregunta", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public DataTable COMENTmod(string iduser)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("  SELECT b.ordenpregunta AS ORDEN , a.codsquser as EVALUADOR, a.usuario_calificado AS EVALUADO , b.pregunta,  a.respuesta_texto FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT  c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) HAVING ORDEN >20 AND ORDEN<24 ORDER BY a.codsqrespreg, b.ordenpregunta ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }


        //modulo notastodos
        public DataTable notastodos()
        {

            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT e.codsqpersonal as cod, e.nombrepersonal as EVALUADO, e.unidadoperativa , e.gerencia ,pu2.puestodescrip AS PUESTO_EVALUADO , e.fechaingreso as Fecha_Ingreso , 1 auto, 1 AS subal, 1 AS jefeinmed, 1 AS NOTAFINAL FROM sq_personal e INNER JOIN sq_puestoseval pu2 on pu2.codsqpuesto = e.codesqpuesto where e.fechaingreso < '2021-04-23' and e.codsqpersonal != '344' GROUP BY e.codsqpersonal, e.nombrepersonal, pu2.puestodescrip, e.unidadoperativa,e.gerencia, e.fechaingreso ORDER BY `cod` ASC ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }

        }
        public string[] obtenerusuariosrepofinal()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[307];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT  codsqpersonal FROM sq_personal where fechaingreso < '2021-04-23' and codsqpersonal != '344' order by codsqpersonal    ";
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

        //modulo notas


        //notas finales
        public string autototal15(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 ,2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado  WHERE a.usuario_calificado = '" + iduser + "' AND c.nota != 0 AND b.ordenpregunta > 0 and b.ordenpregunta < 6 AND a.usuario_calificado= a.codsquser ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string autototal613(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 ,2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado  WHERE a.usuario_calificado = '" + iduser + "' AND c.nota != 0 AND b.ordenpregunta > 5 and b.ordenpregunta < 14 AND a.usuario_calificado= a.codsquser ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string autototal1420(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 ,2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado  WHERE a.usuario_calificado = '" + iduser + "' AND c.nota != 0 AND b.ordenpregunta >13 and b.ordenpregunta < 21 AND a.usuario_calificado= a.codsquser ORDER BY a.codsqrespreg, b.ordenpregunta";
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

        public string jefetotal15(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >0 AND b.ordenpregunta <6 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string jefetotal613(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >5 AND b.ordenpregunta <14 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string jefetotal1420(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >13 AND b.ordenpregunta <21 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' AND a.unidadoperativa = c.unidadoperativa) ORDER BY a.codsqrespreg, b.ordenpregunta";
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


        public string jefetotal15mod(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >0 AND b.ordenpregunta <6 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string jefetotal613mod(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >5 AND b.ordenpregunta <14 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) ORDER BY a.codsqrespreg, b.ordenpregunta";
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
        public string jefetotal1420mod(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT TRUNCATE(avg(c.nota)*10 , 2) FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta >13 AND b.ordenpregunta <21 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser = (SELECT DISTINCT c.codsqpersonal AS IDJEFE FROM sq_personal a INNER JOIN sq_organigrama b ON b.organisup=a.codesqpuesto LEFT JOIN sq_personal c ON c.codesqpuesto=b.codsqpuesto LEFT JOIN sq_puestoseval d ON d.codsqpuesto=c.codesqpuesto INNER JOIN sq_puestoseval e ON e.codsqpuesto=a.codesqpuesto WHERE a.codsqpersonal = '" + iduser + "' ) ORDER BY a.codsqrespreg, b.ordenpregunta";
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


        public string subaltotal15(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT CAST(avg(c.nota)* 10 AS DECIMAL(10,2) ) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta>0 AND b.ordenpregunta<6 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) ORDER BY b.ordenpregunta";
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
        public string subaltotal613(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT CAST(avg(c.nota)* 10 AS DECIMAL(10,2) ) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta>5 AND b.ordenpregunta<14 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) ORDER BY b.ordenpregunta";
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
        public string subaltotal1420(string iduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT CAST(avg(c.nota)* 10 AS DECIMAL(10,2) ) as resultado FROM sq_resultadopregunta a INNER JOIN sq_preguntas b ON a.codsqpregunta= b.codsqpregunta INNER JOIN sq_calificaciones c ON c.codsqcalificacion = a.resultado WHERE b.ordenpregunta>13 AND b.ordenpregunta<21 AND a.usuario_calificado = '" + iduser + "' AND a.codsquser IN((SELECT m.codsqpersonal FROM sq_personal m WHERE m.codesqpuesto IN ((SELECT f.organisup FROM sq_organigrama f INNER JOIN sq_personal t ON t.codesqpuesto = f.codsqpuesto WHERE t.codsqpersonal = '" + iduser + "')))) ORDER BY b.ordenpregunta";
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
        //

        //

        //finales

        //
    }
}