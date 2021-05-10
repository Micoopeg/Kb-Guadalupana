using System;
using KB_Guadalupana.Controllers;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Sentencia_juridico
    {
        Conexion conexiongeneral = new Conexion();

        public void guardarcobros(string sig, string numproceso, string usuario, string numcredito, string cif, string nombre, string fechades, string plazo, string tasa, string montodes, string saldo, string valor)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_procesocobros VALUES ('" + sig + "', 1, '" + numproceso + "', '" + usuario + "', '" + numcredito + "', '" + cif + "', '" + nombre + "', '" + fechades + "', '" + plazo + "', '" + tasa + "', '" + montodes + "', '" + saldo + "', '" + valor + "')";
                }
                catch { }
            }
        }

        public void agregardemandado(string id, string nombres, string apellidos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pj_demandados VALUES('" + id + "', '" + nombres + "', '" + apellidos + "')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

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

        public string siguienteCredito(string tabla, string campo)
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
                        camporesultante = "10101";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }
        }

        public string siguienteTarjeta(string tabla, string campo)
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
                        camporesultante = "20201";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }
        }

        public void guardardocumentoexp(string id, string tipodoc, string archivo, string nombredoc, string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_documento VALUES ('" + id + "', '" + tipodoc + "', '" + archivo + "', '" + nombredoc + "', '" + credito + "')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
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
                    string query = "SELECT pj_archivo FROM pj_documento WHERE idpj_documento = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch { }
                return camporesultante;
            }
        }

        public string obtenernombredocumento(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_nombrearchivo FROM pj_documento WHERE idpj_documento = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch { }
                return camporesultante;
            }
        }

        public string[] obtenerinforcredito(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[50];
                int i = 0;

                try
                {
                    string consultaGraAsis = "SELECT * FROM gen_credito WHERE gen_numprestamo = '" + numcredito + "'";

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

        public void asignarcreditojuridico(string id, string numcredito, string fecha, string estado)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_asignacion_juridico VALUES ('" + id + "', '" + numcredito + "', '" + fecha + "', '" + estado + "') ";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string datetime()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                string fecha = "";
                try
                {
                    string consultaGraAsis = "SELECT DATE_FORMAT(CURRENT_DATE,  '%Y %m %d')";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    fecha = reader.GetValue(0).ToString();
                    string[] fechaseparada = fecha.Split(' ');
                    string año = fechaseparada[0];
                    string mes = fechaseparada[1];
                    string dia = fechaseparada[2];
                    camporesultante = año + '-' + mes + '-' + dia;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }

        }

        public void guardartipocredito(string id, string gastosco, string gastosju, string otrosgastos, string total, string comentario, string numcredito, string fecha)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_tipocredito VALUES('"+id+"', '"+gastosco+"', '"+gastosju+"', '"+otrosgastos+"', '"+total+"', '"+comentario+"', '"+numcredito+"', '"+fecha+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void guardartipotarjeta(string id, string numtarjeta, string numcuenta, string cif, string nombre1, string nombre2, string otronombre, string apellidocasada, string apellido, string apellido2, string limite, string saldo, string credito, string gastoscobranza, string gastosjudiciales, string otrosgastos, string comentario, string total, string fechacreacion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_tipotarjeta VALUES('"+id+"', '"+numtarjeta+"', '"+numcuenta+"', '"+cif+"', '"+nombre1+"', '"+nombre2+"', '"+otronombre+"', '"+apellidocasada+"', '"+apellido+"', '"+apellido2+"', '"+limite+"', '"+saldo+"', '"+credito+"', '"+gastoscobranza+"', '"+gastosjudiciales+"', '"+otrosgastos+"', '"+comentario+"', '"+total+"', '"+fechacreacion+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string[] obtenertipocredito(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[15];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pj_tipocredito WHERE pj_numcredito = '" + numcredito + "'";

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

        public string[] obtenertipotarjeta(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[20];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pj_tipotarjeta WHERE pj_numcredito = '" + numcredito + "'";

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

        public string[] obtenerdatoscredito(string NumCredito, string Nombres, string Apellidos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[15];
                int i = 0;
                string consultaGraAsis;
                try
                {
                   
                    if (Apellidos != "" && Nombres != "")
                    {
                        consultaGraAsis = "SELECT gen_numprestamo, gen_nombre AS Nombre, gen_estado FROM gen_credito WHERE gen_numprestamo = '" + NumCredito + "' OR gen_nombre LIKE '%" + Apellidos + "%" + Nombres + "%'";
                    }
                    else if(Apellidos != "")
                    {
                        consultaGraAsis = "SELECT gen_numprestamo, gen_nombre AS Nombre, gen_estado FROM gen_credito WHERE gen_numprestamo = '" + NumCredito + "' OR gen_nombre LIKE '%" + Apellidos + "%'";
                    }
                    else if (Nombres != "")
                    {
                        consultaGraAsis = "SELECT gen_numprestamo, gen_nombre AS Nombre, gen_estado FROM gen_credito WHERE gen_numprestamo = '" + NumCredito + "' OR gen_nombre LIKE '%" + Nombres + "%'";
                    }
                    else
                    {
                        consultaGraAsis = "SELECT gen_numprestamo, gen_nombre AS Nombre, gen_estado FROM gen_credito WHERE gen_numprestamo = '" + NumCredito + "'";
                    }
                    

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

        public void guardaretapa(string id, string etapa, string credito, string fecha, string status, string usuario, string area, string nombrecliente)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_etapa_credito VALUES('" + id + "', '" + etapa + "', '" + credito + "', '" + fecha + "', '" + status + "', '" + usuario + "', '" + area + "', '"+nombrecliente+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string obteneridusuario(string usuario)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    string consultaGraAsis = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre = '"+usuario+"'";
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

        public void guardarcreditocontable(string id, string nombrearchivo, string ruta, string credito, string usuario, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_certificacioncontable VALUES ('"+id+"', '"+nombrearchivo+"', '"+ruta+"', '"+credito+"', '"+usuario+"', '"+observaciones+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void estadodevuelto(string credito, string area, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Devuelto', gen_area = '"+area+"' WHERE idpj_credito= '" + credito+ "' AND idpj_etapa = '"+etapa+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void estadoreingreso(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Reingreso' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "' AND pj_status = 'Devuelto'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void devolvercertificacionjuridico(string id, string credito, string comentario, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_certificacionjuridicodevolver VALUES ('"+id+"', '"+credito+"', '"+comentario+"', '"+usuario+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string creditoscobros()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(idpj_correlativo_etapa) FROM pj_etapa_credito WHERE pj_status = 'Devuelto' AND idpj_etapa= 1";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoInfornet(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '"+credito+ "' AND idpj_tipodocumento=1";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }
        public string tipodocumentoRecibo(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=2";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoDPI(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=3";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoCartaIngreso(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=4";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoContratos(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=6";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoSolicitudCredito(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=7";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoConsultaIggs(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=8";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoConsultaDicabi(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=9";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoBitacora(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=10";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoEstadoCuenta(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=11";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void cambiarestado(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Recibido' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '"+etapa+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void estadoacobros(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Cobros' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string cantidadcreditoscobros()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(idpj_credito) FROM pj_etapa_credito WHERE idpj_etapa = 1 AND pj_status IN ('Enviado','Devuelto') ";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string cantidadcreditosconta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(idpj_correlativo_etapa) FROM pj_etapa_credito WHERE idpj_etapa = 1 AND pj_status IN ('Enviado','Reingreso')";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string cantidadcreditosjuridico()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(idpj_correlativo_etapa) FROM pj_etapa_credito WHERE idpj_etapa = 2 AND pj_status IN ('Enviado','Reingreso')";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void insertarbitacora(string id, string incidente, string credito, string nombre, string estado, string dearea, string paraarea, string fecha, string fechacreacion, string comentario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_bitacora VALUES('"+id+"', '"+incidente+"', '"+credito+"', '"+nombre+"', '"+estado+"', '"+dearea+"', '"+paraarea+"', '"+fecha+"', '"+fechacreacion+"', '"+comentario+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }


        public string fechacreacioncredito(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_fechacreacion FROM pj_tipocredito WHERE pj_numcredito = '" + numcredito+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string fechacreaciontarjeta(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_fechacreacion FROM pj_tipotarjeta WHERE pj_numcredito = '" + numcredito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] fechayhora()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT DATE_FORMAT(CURRENT_DATE,  '%Y %m %d'), CURRENT_TIME";
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

        public void editartarjeta(string id, string numtarjeta, string numcuenta, string cif, string nombre1, string nombre2, string otronombre, string apellidocasada, string apellido, string apellido2, string limite, string saldo, string credito, string gastoscobranza, string gastosjudiciales, string otrosgastos, string comentario, string total)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_tipotarjeta SET pj_numtarjeta='"+ numtarjeta + "', pj_numcuenta='"+ numcuenta + "', pj_cif='"+ cif + "', pj_primernombre = '"+ nombre1 + "', pj_segundonombre='"+ nombre2 + "', pj_otronombre='"+ otronombre + "', pj_apellidocasada='"+ apellidocasada + "', pj_primerapellido = '"+ apellido + "', pj_segundoapellido='"+ apellido2 + "', pj_limite='"+ limite + "', pj_saldo='"+ saldo + "', pj_gastoscobranza='"+ gastoscobranza + "', pj_gastosjudiciales='"+ gastosjudiciales + "', pj_otrosgastos='"+ otrosgastos + "', pj_comentariogastos='"+ comentario + "', pj_total='"+ total + "' WHERE idpj_tipotarjeta='" +id+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void editarcredito(string id, string gastosco, string gastosju, string otrosgastos, string total, string comentario, string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_tipocredito SET pj_gastoscobranza='"+ gastosco + "', pj_gastosjudiciales='"+ gastosju + "', pj_otrosgastos='"+ otrosgastos + "', pj_total='"+ total + "', pj_comentario='"+ comentario + "' WHERE idpj_tipocredito = '"+id+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string area(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_area FROM pj_controlingreso WHERE idpj_usuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string nombrearea(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT gen_areanombre FROM gen_area WHERE codgenarea = '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void actualizararea(string id, string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_area SET gen_areanombre='"+nombre+ "' WHERE codgenarea='"+id+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch { }
            }
        }

        public void nuevaarea(string id, string nombre)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO gen_area VALUES('"+id+"', '"+nombre+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch { }
            }
        }

        public string obtenernumtipocredito(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_tipocredito FROM pj_tipocredito WHERE pj_numcredito = '" + credito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string obtenernumtipotarjeta(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_tipotarjeta FROM pj_tipotarjeta WHERE pj_numcredito = '" + credito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] traercertificacioncontable(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pj_certificacioncontable WHERE pj_numcredito = '"+credito+"'";
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

        public void editarcertificacioncontable(string credito, string numregistro, string contador, string observaciones, string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_certificacioncontable SET pj_numregistrado='" + numregistro + "', pj_contador = '"+contador+ "', pj_observaciones = '"+observaciones+ "', pj_usuario = '"+usuario+"' WHERE pj_numcredito='" + credito + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch { }
            }
        }
    }
}
