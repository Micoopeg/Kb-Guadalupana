using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Sentencia_seguridad
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        Conexion_seguridad cn = new Conexion_seguridad();

        public string obtenerestado(string usuario)
        {
            String camporesultante = "";
            String campo = "";
            try
            {
                string sql = "SELECT gen_usuarioest FROM gen_usuario where codgenusuario = '" + usuario + "'";
                MySqlCommand command = new MySqlCommand(sql, cn.conectar());
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();

                //if(camporesultante == "0")
                //{
                //    campo = "Activo";
                //}
                //else if(camporesultante == "1")
                //{
                //    campo = "Inactivo";
                //}
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            finally { cn.desconectar(); }
            return camporesultante;
        }

        public string obtenerusuario(string id)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT gen_usuarionombre FROM gen_usuario WHERE codgenusuario = '" + id + "'";
                MySqlCommand command = new MySqlCommand(sql, cn.conectar());
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            finally { cn.desconectar(); }
            return camporesultante;
        }

        public void actualizarArqueos(string puesto, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE sa_control_ingreso SET cod_puesto = '"+puesto+ "' WHERE cod_genusuario = '"+usuario+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string obteneridusuario(string usuario)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre = '" + usuario + "'";
                MySqlCommand command = new MySqlCommand(sql, cn.conectar());
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            finally { cn.desconectar(); }
            return camporesultante;
        }
        public string obtenerapp(string usuario, string aplicacion)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codgenapp FROM gen_mdimenu WHERE codgenusuario = '" + usuario + "' AND codgenapp = '" + aplicacion + "'";
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                finally { cn.desconectar(); }
                return camporesultante;
            }

        }

        public string[] mostraraplicacion(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[20];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM gen_aplicacion WHERE codgenapp = '" + codigo + "'";

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
        public void actualizarestado(string usuario, string estado)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_usuario SET gen_usuarioest = '" + estado + "' WHERE codgenusuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void actualizarmodulo(string codigo, string literal, string nombre, string url, string estado)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_aplicacion SET gen_literalapp = '" + literal + "', gen_nombreapp = '" + nombre + "', gen_urlcontrol = '" + url + "', gen_estadoapp = '" + estado + "' WHERE codgenapp = '" + codigo + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void actualizarappuserestado( string codapp, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_mdimenu SET gen_mdiest = 0  WHERE codgenapp = '"+codapp+ "' AND codgenusuario = '"+usuario+"' ; ";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }
        public void actualizarappuserestado1(string codapp, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_mdimenu SET gen_mdiest = 1  WHERE codgenapp = '" + codapp + "' AND codgenusuario = '" + usuario + "' ; ";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }
        public void asignarAplicacion(string id, string app, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO gen_mdimenu VALUES ('" + id + "', '" + app + "', '" + usuario + "', 1 ;)";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public DataTable llenarGridViewAplicaciones(string id)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gen_usuario.gen_usuarionombre, gen_aplicacion.gen_nombreapp, gen_mdimenu.gen_mdiest FROM gen_mdimenu INNER JOIN gen_usuario ON gen_usuario.codgenusuario = gen_mdimenu.codgenusuario INNER JOIN gen_aplicacion ON gen_aplicacion.codgenapp = gen_mdimenu.codgenapp WHERE gen_usuario.codgenusuario = '" + id+"';", sqlCon);
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