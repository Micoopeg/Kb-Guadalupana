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
        Conexion conexiongeneral = new Conexion();

        Conexion_seguridad cn = new Conexion_seguridad();

        public string obtenerestado(string usuario)
        {


            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT gen_usuarioest FROM gen_usuario where codgenusuario = '" + usuario + "';";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE sa_control_ingreso SET cod_puesto = '" + puesto + "' WHERE cod_genusuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }
        public string[] datosusuarioav(string codavuser)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM av_controlingreso WHERE codavcontroling = '" + codavuser + "' ;";
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
        public string obteneridusuario(string usuario)
        {


            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre = '" + usuario + "'";
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
        public string obteneridusuarioav(string usuario)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT codavcontroling FROM av_controlingreso WHERE av_controlusuario = '" + usuario + "'";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

        public string mostrarareaapp(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string Campos = "";
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codgenarea FROM gen_areaapp WHERE codegenapp = '" + codigo + "'";

                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Campos = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }

        public string mostrarurlapp(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string Campos = "";
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT gen_urlareaapp FROM gen_areaapp WHERE codegenapp = '" + codigo + "'";

                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Campos = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }

        public void actualizarestado(string usuario, string estado)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

        public void actualizararea(string area, string url, string app)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_areaapp SET codgenarea = '" + area + "', gen_urlareaapp = '" + url + "' WHERE codegenapp = '" + app + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void actualizarappuserestado(string codapp, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_mdimenu SET gen_mdiest = 0  WHERE codgenapp = '" + codapp + "' AND codgenusuario = '" + usuario + "' ; ";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO gen_mdimenu VALUES ('" + id + "', '" + app + "', '" + usuario + "', 1)";
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT gen_usuario.gen_usuarionombre, gen_aplicacion.gen_nombreapp, gen_mdimenu.gen_mdiest FROM gen_mdimenu INNER JOIN gen_usuario ON gen_usuario.codgenusuario = gen_mdimenu.codgenusuario INNER JOIN gen_aplicacion ON gen_aplicacion.codgenapp = gen_mdimenu.codgenapp WHERE gen_usuario.codgenusuario = '" + id + "';", sqlCon);
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
                    string sql = "SELECT gar.gen_urlareaapp  FROM gen_areaapp gar WHERE  gar.codegenapp  = '" + app + "' ;";
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
        public string[] datetime()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
        public DataSet conultaareaapp(string user)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT DISTINCT ga.gen_areanombre FROM gen_mdimenu gmdi INNER JOIN gen_areaapp gapp ON gmdi.codgenapp = gapp.codegenapp INNER JOIN gen_aplicacion gapl ON gapl.codgenapp=gmdi.codgenapp INNER JOIN gen_area ga ON ga.codgenarea = gapp.codgenarea WHERE gmdi.codgenusuario= '" + user + "' AND gmdi.gen_mdiest = 1 AND gapl.gen_estadoapp = 1", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);



                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;
            }

        }
        public DataSet consultaappnombre(string user, string area)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(" SELECT gapl.gen_nombreapp, ga.gen_areanombre, gapp.codegenapp FROM gen_mdimenu gmdi INNER JOIN gen_areaapp gapp ON gmdi.codgenapp = gapp.codegenapp INNER JOIN gen_aplicacion gapl ON gapl.codgenapp=gmdi.codgenapp INNER JOIN gen_area ga ON ga.codgenarea = gapp.codgenarea WHERE gmdi.codgenusuario= '" + user + "' AND gmdi.gen_mdiest = 1 AND gapl.gen_estadoapp = 1 AND ga.gen_areanombre = '" + area + "'  ", sqlCon);
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
        }
    } 