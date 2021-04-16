using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace KB_Guadalupana.Controllers
{
    public class ModeloEX
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        public string[] datetime()
        {

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

        public string[] datosexpedientependiente(string codex)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT exb.codexbit, exp.codexp,exb.ex_fechaev, extcr.codextipocred, extev.ex_evento, excr.ex_numcredito, excr.ex_monto, exas.ex_cif, exas.ex_pnombre, exas.ex_snombre, exas.ex_papell, exas.ex_sapell FROM ex_bitacora exb INNER JOIN ex_expediente exp ON exp.codexp = exp.codexp=exb.codexp INNER JOIN ex_creditos excr ON excr.codexcrd = exp.codexcrd INNER JOIN ex_asociado exas ON exas.codexasociado= excr.codexasociado INNER JOIN ex_tipoevento extev ON extev.codexevento=exb.codexevento INNER JOIN ex_tipocredito extcr ON extcr.codextipocred= exp.codextipocred WHERE exp.codexp = '" + codex + "' ;";
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
        public string obtenercodporcif(string cif)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
        public string obtenercodcred(string noexp)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT exc.codexcrd  FROM ex_expediente exc WHERE  = exc.codexp = '" + noexp + "' ;";
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
        public string obtenerean13(string expediente)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT ex_ean13 FROM ex_expediente WHERE codexp = '" + expediente + "' ;";
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
        public string contenv(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exc.codexp) FROM ex_expediente exc WHERE exc.codusuario= '" + usuario + "' AND exc.ex_tipoevento = 2  ;";
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
        public string contpen(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exc.codexp) FROM ex_expediente exc WHERE exc.codusuario= '" + usuario + "' AND exc.ex_tipoevento = 7  ;";
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

        public string contret(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exc.codexp) FROM ex_expediente exc WHERE exc.codusuario= '" + usuario + "' AND exc.ex_tipoevento = 5  ;";
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

        public string contexis(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT COUNT(exc.codexp) FROM ex_expediente exc WHERE exc.codusuario= '" + usuario + "'   ;";
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exb.codexbit, exp.codexp,exb.ex_fechaev, extcr.ex_nomtipo, extev.ex_evento, excr.ex_numcredito, excr.ex_monto, exas.ex_cif, exas.ex_pnombre, exas.ex_snombre, exas.ex_papell, exas.ex_sapell FROM ex_bitacora exb INNER JOIN ex_expediente exp ON exp.codexp = exp.codexp=exb.codexp INNER JOIN ex_creditos excr ON excr.codexcrd = exp.codexcrd INNER JOIN ex_asociado exas ON exas.codexasociado= excr.codexasociado INNER JOIN ex_tipoevento extev ON extev.codexevento=exb.codexevento INNER JOIN ex_tipocredito extcr ON extcr.codextipocred= exp.codextipocred WHERE exp.ex_tipoevento = 7", sqlCon);
                     MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable llenarGridViewevento2(string codex)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT exb.codexbit, exp.codexp,exb.ex_fechaev, extcr.ex_nomtipo, extev.ex_evento, excr.ex_numcredito, excr.ex_monto, exas.ex_cif, exas.ex_pnombre, exas.ex_snombre, exas.ex_papell, exas.ex_sapell FROM ex_bitacora exb INNER JOIN ex_expediente exp ON exp.codexp = exp.codexp=exb.codexp INNER JOIN ex_creditos excr ON excr.codexcrd = exp.codexcrd INNER JOIN ex_asociado exas ON exas.codexasociado= excr.codexasociado INNER JOIN ex_tipoevento extev ON extev.codexevento=exb.codexevento INNER JOIN ex_tipocredito extcr ON extcr.codextipocred= exp.codextipocred WHERE exp.codexp = '"+codex+"'", sqlCon);
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

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
        public string obtenerultimo(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
        public string tablavacia(string tabla)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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