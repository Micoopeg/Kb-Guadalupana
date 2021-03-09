using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM_Guadalupana.Controllers
{
    public class Sentencias
    {
        string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
        Conexion cn = new Conexion();
        MySqlCommand comm;
        public void insertartablas(string tabla, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
                    sqlCon.Open();
                    string consulta = "insert into " + tabla + " values(" + query + ");";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
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


        public void eliminadoderegistrosprotegida(string tabla)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
              
                try
                {
                    sqlCon.Open();
                    string consulta = "DELETE FROM " + tabla + ";";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
            }
        }

        public string[] fechaactual()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT CURDATE();", sqlCon);
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

        public string[] consultarparateleventas()//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3 AND crmcontrol_ingresosucursal ='telemercadeo';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultarparasucursal()//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3 AND crmcontrol_ingresosucursal !='telemercadeo';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
                    sqlCon.Open();
                    string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "';";
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        public string[] consultardpiexistente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT crminfogeneral_prospectodpi FROM crminfogeneral_prospecto;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultartabla(string tabla)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + tabla +"", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultarconcampo(string tabla, string campo, string dato)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + tabla + " where " + campo + "='" + dato + "'", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public DataSet consultarAc()
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" select * from crmcontacto_llamadas;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;
            }

        }

        public DataTable reportetable(string dato)
        {

            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("select * from crmcontacto_llamadas where codcrmcontactollamadas='" + dato+"';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);



                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string[] datetime()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT NOW();", sqlCon);
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


    }
}
       
