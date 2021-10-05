using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Sentencia_proceso
    {
        Conexion conexiongeneral = new Conexion();

        public string siguiente(string tabla, string campo)
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

        public void insertardocumento(string id, string tipodoc, string codigo, string nombredoc, string nombrearchivo, string ruta, string version, string fechaaprobacion, string estado, string origen, string tipousuario, string categoria, string subcategoria, string usuario, string restriccion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pro_registro VALUES('" + id + "', '" + tipodoc + "', '" + codigo + "', '"+nombredoc+"', '"+nombrearchivo+"', '"+ruta+"', '"+version+"', '"+fechaaprobacion+"', '"+estado+"', '"+origen+"', '"+tipousuario+"', '"+categoria+"', '"+subcategoria+"', '"+usuario+"', '"+restriccion+"')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public string obteneridusuario(string usuario)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    string consultaGraAsis = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre = '" + usuario + "'";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }

        }

        public string obtenerrutadocumento(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_rutaarchivo FROM pro_registro WHERE idpro_registro = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch { }
                return camporesultante;
            }
        }

        public string nombrearchivo(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_nombrearchivo FROM pro_registro WHERE idpro_registro = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public DataSet subcategorias1(string categoria)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT pro_nombre AS Subcategoria FROM pro_subcategoria WHERE idpro_categoria = '" + categoria + "'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        public string url(string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_ruta FROM pro_subcategoriamant WHERE pro_nombre = '" + nombre + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string idsubcategoria(string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpro_subcategoriamant FROM pro_subcategoriamant WHERE pro_nombre = '" + nombre + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string nombredoc(string idsubcategoria, string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_nombredocumento FROM pro_registro WHERE idpro_subcategoria = '" + idsubcategoria + "' AND idpro_registro = '"+id+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string nombredoccategoria(string categoria, string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_nombredocumento FROM pro_registro WHERE idpro_categoria = '" + categoria + "' AND idpro_registro = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] obtenerdatosdocumento(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[15];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pro_registro WHERE idpro_registro = '" + id + "'";

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
                return Campos;
            }
        }
    }
}