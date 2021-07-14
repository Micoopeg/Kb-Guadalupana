﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace KB_Guadalupana.Controllers
{
    public class ModeloEX
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
        //SELECT exc.ex_cifgeneral, exc.ex_controlarea, exc.ex_controlrol FROM ex_controlingreso exc WHERE exc.ex_cifgeneral = "778208"
        public string[] datosempleado(string cif)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT exc.ex_cifgeneral, exc.ex_controlarea, exc.ex_controlrol FROM ex_controlingreso exc INNER JOIN ex_aleatorio exal ON exal.asignado = exc.codexcontroling WHERE exal.numero = '" + cif + "' ;";
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
    
        public string[] cartaenvio(string area)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito WHERE tmp.codexarea = '" + area + "' AND  tmp.estado = 7";
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
        public string[] cartaenviomesa()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = " SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE  exev.estado= 8  AND exev.codexetapa = 3";
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
        public string[] cartaenviojuridico()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = " SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE exev.estado= 8 AND exev.codexetapa = 4";
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
        public string[] cartaenviomesaarch()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE  exev.estado= 8 AND exev.codexetapa = 5";
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
        public string[] solvenciaarchivomensajeria(string nummero)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT exc.nomcom, exl.ex_lote FROM ex_aleatorio exal INNER JOIN ex_controlingreso exc ON exc.codexcontroling = exal.asignado INNER JOIN ex_lotemensajero exl ON exl.ex_mensajerocod = exal.numero WHERE exal.numero = ' "+nummero+"' ";
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
        public string[] lotes(string nlote)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[950];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT exlo.codexenvio, exev.Nocredito FROM  ex_envio  exev  INNER JOIN ex_loteenvio exlo ON exev.codexenvio = exlo.codexenvio WHERE exlo.numerolote = '" + nlote + "' ;";
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

        public string Agencia(string coduser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exca.ex_nombrea FROM ex_controlingreso exc INNER JOIN ex_controlarea exca ON exc.ex_controlarea = exca.codexcontrolarea WHERE exc.ex_controlusuario = '"+coduser+"' ;";
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
        public string aleatoriovalido(string numero)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT estado  FROM `ex_aleatorio` WHERE numero = '"+numero+"'  ;";
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
        public string mensajeronom(string numero)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exc.nomcom FROM ex_aleatorio exal INNER JOIN ex_controlingreso exc ON exc.codexcontroling = exal.asignado INNER JOIN ex_lotemensajero exl ON exl.ex_mensajerocod = exal.numero WHERE exal.numero = '" + numero + "'  ;";
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
        public string obtenerhall(string codexp)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT hallazgo FROM ex_hallazgos WHERE codexp ='" + codexp + "' and estadohall=1 ;";
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
        public string obteneraleatorio()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT round(rand()*100000) ;";
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
        public string obtenercodporcif(string cif)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codexasociado FROM ex_asociado WHERE ex_cif = '"+cif+"' ;";
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
        public string obtenerrol(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exc.ex_controlrol FROM ex_controlingreso exc WHERE exc.ex_controlusuario = '" + usuario + "' ;";
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
        public string obtenerarea(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exc.ex_controlarea FROM ex_controlingreso exc WHERE exc.ex_controlusuario = '" + usuario + "' ;";
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
        public string obtenerareanombre(string codarea)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exa.ex_nombrea FROM ex_controlarea exa WHERE exa.codexcontrolarea = '" + codarea + "' ;";
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
        public string obtenercodncred(string ncred)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codexcrd FROM ex_creditos WHERE ex_numcredito = '"+ncred+"' ;";
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
      
        public string obtenercoduser(string nomuser)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codexcontroling FROM ex_controlingreso WHERE ex_controlusuario = '" + nomuser + "' ;";
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
        public string obtenercrdexp(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codexp FROM ex_expediente exc WHERE exc.codgencred = '" + crd + "' ;";
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
        public string obtenerlote(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT exlo.numerolote FROM ex_envio  exev INNER JOIN ex_loteenvio exlo ON exev.codexenvio = exlo.codexenvio WHERE exev.Nocredito = '"+crd+"' ; ";
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
        public string obtenerlote2(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT exsal.numerolote FROM ex_expediente  expe INNER JOIN ex_lotesalida exsal ON expe.codexp  = exsal.codexp WHERE expe.codgencred = '" + crd + "' ; ";
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
        public string obtenercoduserexp(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gep.gen_peticionesusuariodelcredito FROM gen_peticiones gep WHERE gep.gen_peticionesnumerocredito = '" + crd + "' ;";
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
        public string obtenercodigo(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT exc.codexcontroling FROM ex_controlingreso exc WHERE exc.ex_controlusuario = '" +usuario + "' ;";
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
        public string obtenertipocrd(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gep.gen_peticionesgarantia FROM gen_peticiones gep WHERE gep.gen_peticionesnumerocredito = '" + crd + "' ;";
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
        public string obtenertipocrd2(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exp.codextipocred FROM ex_expediente exp WHERE exp.codgencred = '" + crd + "' ;";
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
        public string obtenertipocrdnom(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT ex_nomtipo FROM ex_tipocredito WHERE codextipocred = '"+crd+"' ;";
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
        public string obtenerexp(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT codexp FROM ex_expediente WHERE codgencred = '" + crd + "' ;";
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
        public string obtenerhallazgo (string nohall)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT hallazgo FROM `ex_hallazgos` WHERE  codexhall = '" + nohall + "' ;";
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
        public string obtenercodenv(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT codexenvio FROM ex_envio WHERE Nocredito = '" + crd + "' ;";
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
        public string confirmarasog(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT exa.codasig  FROM ex_asignado exa INNER JOIN ex_expediente exp ON exa.codexp = exp.codexp  WHERE exp.codgencred = '" + crd + "' ;";
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

        public string comentario(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT exp.ex_comentario  FROM  ex_expediente exp WHERE exp.codgencred = '" + crd + "' ;";
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
        //SELECT exev.codexenvio FROM ex_envio exev INNER JOIN ex_expediente exp ON exp.codgencred = exev.Nocredito INNER JOIN ex_asignado exa ON exa.codexp = exp.codexp WHERE exev.Nocredito= "0400024134" AND exev.estado = 1 AND exev.codexetapa = 3 AND exa.proceso = 3
        public string confirmarareaasig(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT exa.codasig  FROM ex_asignado exa INNER JOIN ex_expediente exp ON exa.codexp = exp.codexp  WHERE exp.codgencred = '" + crd + "' AND exa.proceso= 4 ;";
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
        public string confirmarareaasig2(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT exa.codasig  FROM ex_asignado exa INNER JOIN ex_expediente exp ON exa.codexp = exp.codexp  WHERE exp.codgencred = '" + crd + "' AND exa.proceso= 3 ;";
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
        public string expedienteexiste(string crd, string estado, string etapa)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT exev.codexenvio FROM ex_envio exev WHERE exev.estado ='"+estado+"' AND exev.codexetapa='"+etapa+"' AND exev.Nocredito= '"+crd+"' ;";
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
        public string confirmarareaasig3(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "  SELECT exa.codasig  FROM ex_asignado exa INNER JOIN ex_expediente exp ON exa.codexp = exp.codexp  WHERE exp.codgencred = '" + crd + "' AND exa.proceso= 5 ;";
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
        //...conteo de expendientes 

        public string contpdf(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT COUNT( tmp.Nocredito) FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito =gep.gen_peticionesnumerocredito WHERE gep.gen_peticionesusuariodelcredito  = '" + usuario+"';";
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
        public string contenv2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio) FROM ex_envio exenv WHERE (exenv.estado = 1 AND exenv.codexetapa =3) OR (exenv.estado = 2 AND exenv.codexetapa =3) OR (exenv.estado = 1 AND exenv.codexetapa =5);";
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
        public string contjur2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio) FROM ex_envio exenv WHERE (exenv.estado = 1 AND exenv.codexetapa = 4) OR (exenv.estado = 8 AND exenv.codexetapa = 4) OR (exenv.estado = 2 AND exenv.codexetapa = 4)  ;";
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
        public string contpen2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio)  FROM ex_envio exenv WHERE (exenv.estado = 2  AND exenv.codexetapa =2) OR (exenv.estado = 6  AND exenv.codexetapa =5);";
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
        public string contreten2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT( DISTINCT exh.codexp)  FROM  ex_hallazgos exh WHERE exh.estadohall = 1;";
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
        public string contexis2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(tmp.codextemp) FROM ex_temporal1 tmp WHERE tmp.estado = 7  ;";
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
        public string contenv(string area )
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio) FROM ex_envio exenv INNER JOIN ex_temporal1 ext ON ext.Nocredito = exenv.Nocredito  WHERE (exenv.estado = 1 AND exenv.codexetapa =3) OR (exenv.estado = 2 AND exenv.codexetapa =3) OR (exenv.estado = 1 AND exenv.codexetapa =5) AND ext.codexarea = '"+area+"';";
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
        public string contjur(string area)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio) FROM ex_envio exenv INNER JOIN ex_temporal1 ext ON ext.Nocredito = exenv.Nocredito WHERE (exenv.estado = 1 AND exenv.codexetapa = 4) OR (exenv.estado = 8 AND exenv.codexetapa = 4) OR (exenv.estado = 2 AND exenv.codexetapa = 4) AND ext.codexarea = '"+area+"'  ;";
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
        public string contpen(string area)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio)  FROM ex_envio exenv INNER JOIN ex_temporal1 ext ON ext.Nocredito = exenv.Nocredito  WHERE (exenv.estado = 2  AND exenv.codexetapa =2) OR (exenv.estado = 6  AND exenv.codexetapa =5) AND ext.codexarea = '"+area+"';";
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
        public string contreten(string area)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT( DISTINCT exh.codexp)  FROM  ex_hallazgos exh  INNER JOIN ex_expediente exp ON exp.codexp = exh.codexp INNER JOIN ex_temporal1 ext ON ext.Nocredito = exp.codgencred WHERE exh.estadohall = 1 AND ext.codexarea = '"+area+"';";
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

        public string contret(string area )
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio)  FROM ex_envio exenv INNER JOIN ex_temporal1 ext ON ext.Nocredito = exenv.Nocredito  WHERE (exenv.estado = 2  AND exenv.codexetapa = 1) OR (exenv.estado = 6  AND exenv.codexetapa = 5) AND ext.codexarea = '"+area+"' ;";
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
        public string contarch2()
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio)  FROM ex_envio exenv WHERE exenv.estado = 1 AND exenv.codexetapa =7 ;";
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
        public string contarch(string area)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exenv.codexenvio)  FROM ex_envio exenv INNER JOIN ex_temporal1 ext ON ext.Nocredito = exenv.Nocredito WHERE exenv.estado = 1 AND exenv.codexetapa =7  AND ext.codexarea = '"+area+"' ;";
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

        public string contexis(string area)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(tmp.codextemp) FROM ex_temporal1 tmp WHERE tmp.estado = 7 and tmp.codexarea = '"+area+"'  ;";
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
        public string lotevalidado(string lote)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT estado FROM ex_loteenvio WHERE  numerolote = '"+lote+ "' LIMIT 1  ;";
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
        public string lotevalidado2(string lote)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT estado FROM ex_lotesalida WHERE  numerolote = '" + lote + "' LIMIT 1  ;";
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
        // fin
        public DataTable llenarGridViewevento()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exp.codexp, gcrd.gen_fechadesembolso,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ' , gaso.segundo_apellido) AS nombrecompleto , CONCAT('Q',FORMAT(gcrd.gen_monto,2,'de_DE')) as gen_monto, extp.ex_nomtipo FROM ex_envio exenv INNER JOIN ex_bitacora exb ON exenv.codexenvio = exb.codexenvio INNER JOIN ex_expediente exp ON exp.codexp=exb.codexp INNER JOIN gen_credito gcrd ON gcrd.codgencred = exp.codgencred INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 extmp ON extmp.codexp = exp.codexp WHERE extmp.estado = 7", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenardgvnegocios(string crd)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT gep.gen_peticionescodigocliente AS cifgeneral, gep.gen_peticionesnumerocredito AS gen_numcredito, CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto ,  CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred WHERE exp.codgencred ='" + crd + "' ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarporareaage(string area)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT gep.gen_peticionescodigocliente AS cifgeneral, gep.gen_peticionesnumerocredito AS gen_numcredito, CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto ,  CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred WHERE tmp.codexarea = '" + area + "' ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarGridViewevento3(string user)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia WHERE NOT EXISTS ( SELECT null FROM ex_expediente exp WHERE gep.gen_peticionesnumerocredito = exp.codgencred)  AND   gep.gen_peticionesusuariodelcredito = '"+user+"' AND NOT EXISTS ( SELECT null FROM ex_temporal1 tmp WHERE tmp.Nocredito = gep.gen_peticionesnumerocredito ) AND gep.gen_peticionesfechacredito > '2021-07-08';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarGridViewevento2(string user)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia  INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito WHERE gep.gen_peticionesusuariodelcredito = '" + user + "' AND tmp.estado = 7  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarenvio(string area)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito WHERE tmp.estado = 7 AND tmp.codexarea = '" + area + "';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarexphall(string area)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_hallazgos exh ON exh.codexp = exp.codexp WHERE tmp.codexarea = '" + area + "' AND exh.estadohall = 1; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarenviomesa()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE  exev.estado=8 AND exev.codexetapa = 3 ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarenviojuridicomesa()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE  exev.estado=8 AND exev.codexetapa = 4 ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarenviomesaarch()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exev  ON exev.Nocredito = tmp.Nocredito  WHERE  exev.estado = 8 AND exev.codexetapa = 5 ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarsolvenciamensajero()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarmesa()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred  WHERE tmp.estado = 2 AND exenv.codexetapa = 3 AND exenv.estado = 1 AND NOT EXISTS ( SELECT null FROM ex_asignado exas WHERE exas.codexp = exp.codexp)  ; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarjuridico()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred  WHERE  exenv.codexetapa = 4 AND exenv.estado = 1  AND NOT EXISTS ( SELECT null FROM ex_asignado exas WHERE exas.codexp = exp.codexp AND exas.proceso = 4) ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

         public DataTable llenarmesaarch()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gcrd.gen_fechadesembolso,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT_ws(' ',gaso.primer_nombre, gaso.segundo_nombre, gaso.primer_apellido, gaso.segundo_apellido) AS nombrecompleto , CONCAT('Q',FORMAT(gcrd.gen_monto,2,'de_DE')) as gen_monto, extp.ex_nomtipo FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gcrd.gen_numcredito INNER JOIN ex_expediente exp ON exp.codgencred = gcrd.gen_numcredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred  WHERE  exenv.codexetapa = 4 AND exenv.estado = 2  AND NOT EXISTS ( SELECT null FROM ex_asignado exas WHERE exas.codexp = exp.codexp AND exas.proceso = 5)  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenararch()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito= exp.codgencred WHERE exenv.codexetapa = 7 AND exenv.estado = 1 ; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenartrack(string nocre)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exp.codgencred, exb.ex_fechaev, exte.ex_evento, exeta.etapa_actual, exeta.etapa_siguiente FROM ex_bitacora exb INNER JOIN ex_tipoevento exte ON exte.codexevento=exb.codexevento INNER JOIN ex_etapa exeta ON exeta.codexetapa= exb.codexetapa INNER JOIN ex_expediente exp ON exb.codexp = exp.codexp INNER JOIN ex_envio exev ON exev.codexenvio = exb.codexenvio WHERE exp.codgencred = '"+nocre+"' ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarmesamesaasignado(string coduser)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred INNER JOIN ex_asignado exasig ON exasig.codexp = exp.codexp WHERE  exenv.codexetapa = 3 AND exenv.estado = 1 AND exasig.codasignado = '" + coduser + "' AND exasig.proceso = 3 ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }


        public DataTable llenarjuridicoasignado(string coduser)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred INNER JOIN ex_asignado exasig ON exasig.codexp = exp.codexp WHERE exenv.codexetapa = 4 AND exenv.estado = 1 AND exasig.codasignado = '" + coduser + "' AND exasig.proceso = 4", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable llenarhallazgos(string codexp)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exh.codexhall, exh.hallazgo, exh.estadohall FROM ex_hallazgos exh INNER JOIN ex_expediente exp ON exp.codexp= exh.codexp WHERE  exh.codexp = '" + codexp+"' AND (exh.estadohall = 1 OR exh.estadohall = 2)  ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarhallazgos2(string codexp)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exh.codexhall, exh.hallazgo, exh.estadohall FROM ex_hallazgos exh INNER JOIN ex_expediente exp ON exp.codexp= exh.codexp WHERE  exh.codexp = '" + codexp + "' AND exh.estadohall = 1   ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarmesarchasignadohall(string coduser)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred INNER JOIN ex_asignado exasig ON exasig.codexp = exp.codexp WHERE   exenv.codexetapa = 4 AND exenv.estado = 3 AND exasig.codasignado = '"+coduser+ "' AND exasig.proceso = 5 OR exasig.proceso = 3;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable llenarmesarchasignado(string coduser)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT gep.gen_peticionesfechacredito as gen_fechadesembolso, gep.gen_peticionescodigocliente AS cifgeneral ,gep.gen_peticionesnumerocredito AS gen_numcredito , CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nombrecompleto, CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, extp.ex_nomtipo AS ex_nomtipo FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito INNER JOIN ex_expediente exp ON exp.codgencred = gep.gen_peticionesnumerocredito INNER JOIN ex_envio exenv ON exenv.Nocredito=exp.codgencred INNER JOIN ex_asignado exasig ON exasig.codexp = exp.codexp WHERE   exenv.codexetapa = 5 AND exenv.estado = 1 AND exasig.codasignado = '"+coduser+"' AND (exasig.proceso = 3 OR exasig.proceso = 4)", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable codigostable(string user)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT tmp.Nocredito,  CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nomcom, gep.gen_peticionescodigocliente AS cifgeneral , CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, gep.gen_peticionesfechacredito as gen_fechadesembolso,  extp.ex_nomtipo AS ex_nomtipo  FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito WHERE  tmp.estado = 7;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }


        public DataTable codigostablegerencia(string area)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT tmp.Nocredito,  CONCAT_ws(' ', gep.gen_peticionesprimernombre, gep.gen_peticionessegundonombre, gep.gen_peticionestercernombre, gep.gen_peticionesprimerapellido, gep.gen_peticionessegundoapellido) AS nomcom, gep.gen_peticionescodigocliente AS cifgeneral , CONCAT('Q',FORMAT(gep.gen_peticionesmontocredito,2,'de_DE')) as gen_monto, gep.gen_peticionesfechacredito as gen_fechadesembolso,  extp.ex_nomtipo AS ex_nomtipo   FROM gen_peticiones gep INNER JOIN ex_tipocredito extp ON extp.codextipocred = gep.gen_peticionesgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gep.gen_peticionesnumerocredito WHERE tmp.estado = 7 AND tmp.codexarea = '" + area + "'; ", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable lotesinfo(string nlote)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exlo.codexenvio, exev.Nocredito FROM  ex_envio exev  INNER JOIN ex_loteenvio exlo ON exev.codexenvio = exlo.codexenvio WHERE exlo.numerolote = '" + nlote + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable lotesinfo2(string nlote)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT expe.codexp, expe.codgencred FROM  ex_expediente expe  INNER JOIN ex_lotesalida exsal ON expe.codexp = exsal.codexp WHERE exsal.numerolote = '" + nlote + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public DataTable repolotes(string codmens)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT exl.ex_lote  FROM ex_lotemensajero exl  WHERE exl.ex_mensajerocod  = '" + codmens + "' ;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
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
        public string obtenerfinallote(string tabla, string campo)
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
                        camporesultante = "100";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }


        }

        public string obtenerultimo(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(" + campo + ") FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
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

        public string buscareanigual(string ean)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT ea.codexan13 FROM ex_ean13ctrl ea WHERE ea.codexan13 = '" + ean + "'; ";   
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
        public string buscaretapa(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exev.codexetapa FROM ex_envio exev  WHERE exev.Nocredito =  '" + crd + "'; ";
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
        public string buscaragencia(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exar.ex_nombrea FROM ex_temporal1  tmp INNER JOIN ex_controlarea exar ON exar.codexcontrolarea =tmp.codexarea WHERE tmp.Nocredito =  '" + crd + "'; ";
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

        public string buscarnoexp(string crd)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exp.codexp  FROM ex_expediente exp WHERE exp.codgencred =  '" + crd + "'; ";
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
        public string tablavacia(string tabla)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(*) FROM "+tabla+" ";
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
    }
}