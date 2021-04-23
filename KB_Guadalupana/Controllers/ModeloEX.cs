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
        Conexion conexiongeneral = new Conexion();
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
        //SELECT exc.ex_cifgeneral, exc.ex_controlarea, exc.ex_controlrol FROM ex_controlingreso exc WHERE exc.ex_cifgeneral = "778208"
        public string[] datosempleado(string cif)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT exc.ex_cifgeneral, exc.ex_controlarea, exc.ex_controlrol FROM ex_controlingreso exc WHERE exc.ex_cifgeneral = '" + cif + "' ;";
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
    
        public string[] cartaenvio(string user)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT gcrd.gen_fechaprestamo,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ', gaso.segundo_apellido) AS nombrecompleto , gcrd.gen_monto, extp.ex_nomtipo FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gcrd.gen_numcredito WHERE gaso.usercreacion = '" + user + "'  ";
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
        public string obtenerrol(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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

        public string contpdf(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = " SELECT COUNT( tmp.Nocredito) FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gcrd.gen_numcredito WHERE gaso.usercreacion = '"+usuario+"';";
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
                    MySqlCommand command = new MySqlCommand("SELECT exp.codexp, gcrd.gen_fechaprestamo,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ' , gaso.segundo_apellido) AS nombrecompleto , gcrd.gen_monto, extp.ex_nomtipo FROM ex_envio exenv INNER JOIN ex_bitacora exb ON exenv.codexenvio = exb.codexenvio INNER JOIN ex_expediente exp ON exp.codexp=exb.codexp INNER JOIN gen_credito gcrd ON gcrd.codgencred = exp.codgencred INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 extmp ON extmp.codexp = exp.codexp WHERE extmp.estado = 7", sqlCon);
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gcrd.gen_fechaprestamo,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ', gaso.segundo_apellido) AS nombrecompleto , gcrd.gen_monto, extp.ex_nomtipo FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia WHERE NOT EXISTS ( SELECT null FROM ex_expediente exp WHERE gcrd.gen_numcredito = exp.codgencred) AND gaso.usercreacion = '" + user + "' AND NOT EXISTS ( SELECT null FROM ex_temporal1 tmp WHERE tmp.Nocredito = gcrd.gen_numcredito ) ", sqlCon);
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gcrd.gen_fechaprestamo,gaso.cifgeneral, gcrd.gen_numcredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ', gaso.segundo_apellido) AS nombrecompleto , gcrd.gen_monto, extp.ex_nomtipo FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gcrd.gen_numcredito WHERE gaso.usercreacion = '"+user+"'  ", sqlCon);
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT tmp.Nocredito, CONCAT(gaso.primer_nombre, ' ' , gaso.segundo_nombre, ' ' , gaso.primer_apellido, ' ', gaso.segundo_apellido) as nomcom, gaso.cifgeneral, gcrd.gen_monto, gcrd.gen_fechadesembolso  FROM gen_credito gcrd INNER JOIN gen_asociado gaso ON gaso.codgenasociado = gcrd.codgenasociado INNER JOIN ex_tipocredito extp ON extp.codextipocred = gaso.codgarantia INNER JOIN ex_temporal1 tmp ON tmp.Nocredito = gcrd.gen_numcredito WHERE gaso.usercreacion = '"+user+"' AND tmp.estado = 7", sqlCon);
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