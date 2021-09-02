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
                    string consultaGraAsis = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre LIKE '" + '%' + usuario + '%' + "'";
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
                    MySqlCommand command = new MySqlCommand("SELECT pro_nombre AS Subcategoria, pro_nombre AS IdCategoria, pro_nombre AS IdSubcategoria, pro_nombre AS IdDocumento FROM pro_subcategoria WHERE idpro_categoria = '" + categoria + "' ORDER BY pro_nombre", sqlCon);
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
                    string query = "SELECT idpro_subcategoria FROM pro_subcategoria WHERE pro_nombre = '" + nombre + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string idcategoria(string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpro_categoria FROM pro_categoria WHERE pro_nombre = '" + nombre + "'";
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

        public DataTable reportedocumentos()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, A.pro_fechaaprobacion AS Fecha, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen, E.pro_nombreusuario AS Usuario, F.pro_nombre AS Categoria, G.pro_nombreres AS Restriccion, H.pro_nombre AS Subcategoria FROM pro_registro AS A"
                                    + " INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F"
                                    + " ON F.idpro_categoria = A.idpro_categoria INNER JOIN pro_restriccion AS G ON A.idpro_restriccion = G.idpro_restriccion INNER JOIN pro_subcategoria AS H ON H.idpro_subcategoria = A.idpro_subcategoria";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public void editardocumento(string id, string tipodoc, string codigo, string nombredoc, string nombrearchivo, string ruta, string version, string fechaaprobacion, string estado, string origen, string tipousuario, string categoria, string subcategoria, string usuario, string restriccion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pro_registro SET idpro_tipodocumento = '"+tipodoc+ "', pro_codigo = '"+codigo+ "', pro_nombredocumento = '"+nombredoc+ "', pro_nombrearchivo = '"+nombrearchivo+ "', pro_rutaarchivo = '"+ruta+ "', pro_version = '"+version+ "', pro_fechaaprobacion = '"+fechaaprobacion+ "', idpro_estado= '"+estado+ "', idpro_origen='"+origen+ "', idpro_tipousuario = '"+tipousuario+ "', idpro_categoria = '"+categoria+ "', idpro_subcategoria = '"+subcategoria+ "', idpro_usuario = '"+usuario+ "', idpro_restriccion = '"+restriccion+ "' WHERE idpro_registro = '"+id+"'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void editardocumento2(string id, string tipodoc, string codigo, string nombredoc, string version, string fechaaprobacion, string estado, string origen, string tipousuario, string categoria, string subcategoria, string usuario, string restriccion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pro_registro SET idpro_tipodocumento = '" + tipodoc + "', pro_codigo = '" + codigo + "', pro_nombredocumento = '" + nombredoc + "', pro_version = '" + version + "', pro_fechaaprobacion = '" + fechaaprobacion + "', idpro_estado= '" + estado + "', idpro_origen='" + origen + "', idpro_tipousuario = '" + tipousuario + "', idpro_categoria = '" + categoria + "', idpro_subcategoria = '" + subcategoria + "', idpro_usuario = '" + usuario + "', idpro_restriccion = '" + restriccion + "' WHERE idpro_registro = '" + id + "'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public string tipousuario(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_tipousuario FROM pro_registroingreso WHERE gen_usuario = '"+usuario+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string subcategoriausuario(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_subcategoria FROM pro_registroingreso WHERE gen_usuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string subcategoriausuarionombre(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT B.pro_nombre FROM pro_registroingreso AS A INNER JOIN pro_subcategoria AS B ON B.idpro_subcategoria = A.pro_subcategoria WHERE A.gen_usuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string categoriausuario(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_categoria FROM pro_registroingreso WHERE gen_usuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public DataSet categorias()
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT pro_nombre AS Categoria FROM pro_categoria ORDER BY pro_nombre DESC", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        //public DataSet documentos(string subcategoria)
        //{
        //    DataSet ds1 = new DataSet();
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {

        //        try
        //        {
        //            //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
        //            sqlCon.Open();
        //            MySqlCommand command = new MySqlCommand("SELECT A.idpro_categoria AS IdCategoria, A.idpro_subcategoria AS IdSubcategoria, A.idpro_documento AS IdDocumento, B.pro_nombretipo AS Nombre FROM pro_controlDocumentos AS A INNER JOIN pro_tipodocumento AS B ON A.idpro_documento = B.idpro_tipodocumento WHERE A.idpro_subcategoria = '" + subcategoria + "'", sqlCon);
        //            MySqlDataAdapter ds = new MySqlDataAdapter();
        //            ds.SelectCommand = command;
        //            ds.Fill(ds1);

        //        }
        //        catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
        //        return ds1;

        //    }



        //}

        public DataSet documentos(string subcategoria)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT A.idpro_categoria AS IdCategoria, A.idpro_subcategoria AS IdSubcategoria, A.idpro_documento AS IdDocumento, B.pro_nombretipo AS Nombre FROM pro_controlDocumentos AS A INNER JOIN pro_tipodocumento AS B ON A.idpro_documento = B.idpro_tipodocumento INNER JOIN pro_registro AS C ON A.idpro_documento = C.idpro_tipodocumento WHERE C.idpro_subcategoria = '"+subcategoria+"' AND A.idpro_subcategoria = '"+subcategoria+"'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }
        }

        //public DataSet documentosSub(string categoria)
        //{
        //    DataSet ds1 = new DataSet();
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {

        //        try
        //        {
        //            //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
        //            sqlCon.Open();
        //            MySqlCommand command = new MySqlCommand("SELECT A.idpro_categoria AS IdCategoria, A.idpro_subcategoria AS IdSubcategoria, A.idpro_documento AS IdDocumento, B.pro_nombretipo AS Subcategoria FROM pro_controlDocumentos AS A INNER JOIN pro_tipodocumento AS B ON A.idpro_documento = B.idpro_tipodocumento WHERE A.idpro_categoria = '" + categoria + "'", sqlCon);
        //            MySqlDataAdapter ds = new MySqlDataAdapter();
        //            ds.SelectCommand = command;
        //            ds.Fill(ds1);

        //        }
        //        catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
        //        return ds1;

        //    }



        //}

        public DataSet documentosSub(string categoria)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT DISTINCT A.idpro_categoria AS IdCategoria, A.idpro_subcategoria AS IdSubcategoria, A.idpro_documento AS IdDocumento, B.pro_nombretipo AS Subcategoria FROM pro_controlDocumentos AS A INNER JOIN pro_tipodocumento AS B ON A.idpro_documento = B.idpro_tipodocumento INNER JOIN pro_registro AS C ON C.idpro_tipodocumento = A.idpro_documento WHERE A.idpro_categoria = '" + categoria + "' AND C.idpro_categoria = '" + categoria + "'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        public string[] obtenerdocumentos(string subcategoria)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[15];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT B.pro_nombretipo AS Nombre FROM pro_controlDocumentos AS A INNER JOIN pro_tipodocumento AS B ON A.idpro_documento = B.idpro_tipodocumento WHERE A.idpro_subcategoria = '" + subcategoria+"'";

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

        public string nombrecategoria(string idcat)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_nombre FROM pro_categoria WHERE idpro_categoria = '" + idcat + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string nombresubcategoria(string idsub)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pro_nombre FROM pro_subcategoria WHERE idpro_subcategoria = '" + idsub + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void editarcategoria(string id, string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pro_categoria SET pro_nombre = '"+nombre+ "' WHERE idpro_categoria = '" + id + "'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void insertarcategoria(string id, string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pro_categoria VALUES('"+id+"', '"+nombre+"')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public string[] obtenersubcategorias(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[5];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pro_subcategoria WHERE idpro_subcategoria = '"+id+"'";

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

        public void editarsubcategoria(string id, string nombre, string categoria)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pro_subcategoria SET pro_nombre = '" + nombre + "', idpro_categoria = '"+categoria+ "' WHERE idpro_subcategoria = '" + id + "'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void editarsubcategoria2(string idsub, string categoria)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pro_controlDocumentos SET idpro_categoria = '" + categoria + "' WHERE idpro_subcategoria = '" + idsub + "'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void insertarsubcategoria(string id, string nombre, string categoria)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pro_subcategoria VALUES('"+id+"', '"+nombre+"', '"+categoria+"')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void insertarsubcategoria2(string id, string categoria, string subcategoria, string documento)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pro_controlDocumentos VALUES('"+id+"', '"+categoria+"', '"+subcategoria+"', '"+documento+"')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public string numdocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(idpro_tipodocumento) FROM pro_tipodocumento";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void eliminardocumento(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "DELETE FROM pro_registro WHERE idpro_registro = '"+id+"'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public DataTable reporteusuarios()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT B.gen_usuarionombre AS Usuario, CONCAT(D.ep_informaciongeneralprimernombre, ' ', D.ep_informaciongeneralsegundonombre, ' ', D.ep_informaciongeneralnombreadicional, ' ', D.ep_informaciongeneralprimerapellido, ' ', D.ep_informaciongeneralsegundoapellido) AS Nombre, A.pro_tipousuario AS Nivel, A.pro_estado AS Estado"
                                    + " FROM pro_registroingreso AS A INNER JOIN gen_usuario AS B ON B.codgenusuario = A.gen_usuario INNER JOIN ep_control AS C ON C.codgenusuario = A.gen_usuario INNER JOIN ep_informaciongeneral AS D ON C.codepinformaciongeneralcif = D.codepinformaciongeneralcif";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string[] obtenerusuarioregistro(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[5];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DISTINCT idpro_registroingreso FROM pro_registroingreso WHERE gen_usuario = '" + usuario + "' AND pro_estado = 'Activo'";

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