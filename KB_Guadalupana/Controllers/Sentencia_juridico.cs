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
                        camporesultante = "100";
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
                        camporesultante = "900";
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

        public void guardartipocredito(string id, string gastosco, string gastosju, string otrosgastos, string total, string comentario, string numcredito, string fecha, string fechaestado, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_tipocredito VALUES('"+id+"', '"+gastosco+"', '"+gastosju+"', '"+otrosgastos+"', '"+total+"', '"+comentario+"', '"+numcredito+"', '"+fecha+"', '"+fechaestado+"', '"+observaciones+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void guardartipotarjeta(string id, string numtarjeta, string numcuenta, string cif, string nombre1, string nombre2, string otronombre, string apellidocasada, string apellido, string apellido2, string limite, string saldo, string credito, string gastoscobranza, string gastosjudiciales, string otrosgastos, string comentario, string total, string fechacreacion, string fechaestado, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_tipotarjeta VALUES('"+id+"', '"+numtarjeta+"', '"+numcuenta+"', '"+cif+"', '"+nombre1+"', '"+nombre2+"', '"+otronombre+"', '"+apellidocasada+"', '"+apellido+"', '"+apellido2+"', '"+limite+"', '"+saldo+"', '"+credito+"', '"+gastoscobranza+"', '"+gastosjudiciales+"', '"+otrosgastos+"', '"+comentario+"', '"+total+"', '"+fechacreacion+"', '"+ fechaestado + "', '"+observaciones+"')";
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

        public void guardaretapa(string id, string etapa, string credito, string fecha, string status, string usuario, string area, string nombrecliente, string numincidente)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_etapa_credito VALUES('" + id + "', '" + etapa + "', '" + credito + "', '" + fecha + "', '" + status + "', '" + usuario + "', '" + area + "', '"+nombrecliente+"', '"+numincidente+"')";
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

        public void editartarjeta(string id, string numtarjeta, string numcuenta, string cif, string nombre1, string nombre2, string otronombre, string apellidocasada, string apellido, string apellido2, string limite, string saldo, string credito, string gastoscobranza, string gastosjudiciales, string otrosgastos, string comentario, string total, string fechaestado, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_tipotarjeta SET pj_numtarjeta='"+ numtarjeta + "', pj_numcuenta='"+ numcuenta + "', pj_cif='"+ cif + "', pj_primernombre = '"+ nombre1 + "', pj_segundonombre='"+ nombre2 + "', pj_otronombre='"+ otronombre + "', pj_apellidocasada='"+ apellidocasada + "', pj_primerapellido = '"+ apellido + "', pj_segundoapellido='"+ apellido2 + "', pj_limite='"+ limite + "', pj_saldo='"+ saldo + "', pj_gastoscobranza='"+ gastoscobranza + "', pj_gastosjudiciales='"+ gastosjudiciales + "', pj_otrosgastos='"+ otrosgastos + "', pj_comentariogastos='"+ comentario + "', pj_total='"+ total + "', pj_fechaestado= '"+fechaestado+ "', pj_comentario = '"+observaciones+"'  WHERE idpj_tipotarjeta='" + id+"'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void editarcredito(string id, string gastosco, string gastosju, string otrosgastos, string total, string comentario, string numcredito, string fechaestado, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_tipocredito SET pj_gastoscobranza='"+ gastosco + "', pj_gastosjudiciales='"+ gastosju + "', pj_otrosgastos='"+ otrosgastos + "', pj_total='"+ total + "', pj_comentario='"+ comentario + "', pj_fechaestado = '"+fechaestado+ "', pj_observaciones = '"+observaciones+"' WHERE idpj_tipocredito = '" + id+"'";
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

        public DataTable reporteabogados(string abogado)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre, A.pj_cif, A.pj_numcredito, A.pj_fechaasignacion, B.pj_nombreabogado FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado WHERE A.idpj_abogado = '"+abogado+"'";
                     MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public void insertarcertificacionjuridico(string id, string abogado, string tipoproceso, string procesonombre, string numcredito, string usuario, string fechaasignacion, string nombre, string cif, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_certificacionjuidico VALUES('"+id+"', '"+abogado+"', '"+tipoproceso+"', '"+procesonombre+"', '"+numcredito+"', '"+usuario+"', '"+fechaasignacion+"', '"+nombre+"', '"+cif+"', '"+observaciones+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch { }
            }
        }

        public void insertarmedidaspre(string id, string medida, string nombreotro, string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_asignacionmedidas VALUES('"+id+"', '"+medida+"', '"+nombreotro+"', '"+numcredito+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch { }
            }
        }

        public string tipodocumentoMemorial(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=16";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipoproceso(string credito)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";

                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_tipoproceso FROM pj_certificacionjuidico WHERE pj_numcredito = '"+credito+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void insertarpresentaciondemanda(string id, string numincidente, string numproceso, string fechapresentacion, string numcredito, string oficial, string notificador, string numjuzgado, string nombrejuzgado, string departamento, string municipio, string usuario)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_presentaciondemanda VALUES ('"+id+"', '"+numincidente+"', '"+numproceso+"', '"+fechapresentacion+"', '"+numcredito+"', '"+oficial+"', '"+notificador+"', '"+numjuzgado+"', '"+nombrejuzgado+"', '"+departamento+"', '"+municipio+"', '"+usuario+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string tipodocumentoresolucion(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=17";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void insertarresolucion(string id, string numcredito, string usuario, string estado, string motivorechazo, string fechanotificacion)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_resoluciontramite VALUES ('"+id+"', '"+numcredito+"', '"+usuario+"', '"+estado+"', '"+ motivorechazo + "', '"+fechanotificacion+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string tipodocumentoAvaluo(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=5";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoTransunion(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=12";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public DataTable fechaactual()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DATE_FORMAT(CURDATE(), '%d / %m / %Y') AS Fecha";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable nombreabogado(string id)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_nombreabogado FROM pj_abogado WHERE idpj_abogado = '"+id+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable dpi(string usuario)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT(B.ep_informaciongeneralnumeroidentificacion) FROM ep_control AS A INNER JOIN ep_informaciongeneral AS B ON A.codepinformaciongeneralcif = B.codepinformaciongeneralcif WHERE A.codgenusuario = '"+usuario+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable nombreUsuario(string usuario)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT CONCAT(B.ep_informaciongeneralprimernombre , ' ' , B.ep_informaciongeneralsegundonombre , ' ' , B.ep_informaciongeneralprimerapellido , ' ' , B.ep_informaciongeneralsegundoapellido) AS Nombre FROM ep_control AS A INNER JOIN ep_informaciongeneral AS B ON A.codepinformaciongeneralcif = B.codepinformaciongeneralcif WHERE A.codgenusuario = '"+usuario+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string tipodocumentoFactura(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=18";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void guardarfacturaabogado(string id, string numcredito, string usuario, string numfactura, string numserie, string descripcion, string importetotal, string fechaemision, string importecaso, string motivopago, string nombremotivo, string cif, string nombreaso, string nombrecheque, string observaciones, string estado)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "INSERT INTO pj_facturacionabogado VALUES ('"+id+"', '"+numcredito+"', '"+usuario+"', '"+numfactura+"', '"+numserie+"', '"+descripcion+"', '"+importetotal+"', '"+fechaemision+"', '"+importecaso+"', '"+motivopago+"', '"+nombremotivo+"', '"+cif+"', '"+nombreaso+"', '"+nombrecheque+"', '"+observaciones+"', '"+estado+"')";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public string fecha()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DATE_FORMAT(CURDATE(), '%d / %m / %Y')";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string importetotal(string numcredito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_importetotal FROM pj_facturacionabogado WHERE pj_numcredito = '"+numcredito+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public DataTable solicitudcheque(string serie)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT A.pj_cif AS CIF, A.pj_nombreasociado AS Nombre, A.pj_numcredito AS Credito, B.pj_numproceso AS Juicio, CONCAT('Juzgado', B.pj_numjuzgado, ' ' , B.pj_nombrejuzgado) AS Juzgado, CONCAT('SERIE ', A.pj_numserie, ' No. ', A.pj_numfactura) AS Factura, CONCAT('Q ', A.pj_importecaso) AS Importe FROM pj_facturacionabogado AS A INNER JOIN pj_presentaciondemanda AS B ON B.pj_numcredito = A.pj_numcredito INNER JOIN pj_etapa_credito AS D ON D.idpj_credito = A.pj_numcredito WHERE A.pj_numserie = '"+serie+ "' AND A.pj_estado = 'Pendiente' AND D.idpj_etapa = 5 AND D.pj_status = 'Espera'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string fechaestadocredito(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DATE_FORMAT(pj_fechaestado, '%Y-%m-%d') FROM pj_tipocredito WHERE pj_numcredito = '" + credito+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string fechaestadotarjeta(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DATE_FORMAT(pj_fechaestado, '%Y-%m-%d') FROM pj_tipotarjeta WHERE pj_numcredito = '" + credito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
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
                    string query = "SELECT pj_nombrearchivo FROM pj_documento WHERE idpj_documento = '"+id+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string rolusuario(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_rol FROM pj_controlingreso WHERE idpj_usuario = '" + usuario + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] datosfactura(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM pj_facturacionabogado WHERE pj_numcredito = '" + credito + "'";
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

        public DataTable reporteabogados2(string abogado, string fecha)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre, A.pj_cif, A.pj_numcredito, A.pj_fechaasignacion, B.pj_nombreabogado FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE A.idpj_abogado = '"+abogado+ "' AND C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso') AND C.pj_fecha = '"+ fecha +"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public void insertarreporteabogado(string id, string usuario, string fecha, string tipodoc, string ruta, string nombrearchivo, string observaciones)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_reporteabogado VALUES ('"+id+"', '"+usuario+"', '"+fecha+"', '"+tipodoc+"', '"+ruta+"', '"+nombrearchivo+"', '"+observaciones+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public DataTable reporteabogados3(string abogado)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre AS Nombre, A.pj_cif, A.pj_numcredito AS Credito, A.pj_fechaasignacion, B.pj_nombreabogado, C.pj_numincidente AS Incidente FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE A.idpj_abogado = '" + abogado + "' AND C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso')";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string tipodocumentoReporte(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=19";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string motivopago(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_nombremotivo FROM pj_motivopago WHERE idpj_motivopago= '" + id + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void modificarfacturaabogado(string id, string numfactura, string numserie, string descripcion, string importetotal, string fechaemision, string importecaso, string motivopago, string nombremotivo, string nombrecheque)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "UPDATE pj_facturacionabogado SET pj_numfactura = '"+ numfactura + "', pj_numserie = '"+ numserie + "', pj_descripcion = '"+descripcion+ "', pj_importetotal = '"+ importetotal + "', pj_fechaemision = '"+ fechaemision + "', pj_importecaso = '"+ importecaso + "', pj_motivopago = '"+ motivopago + "', pj_nombremotivo = '"+ nombremotivo + "', pj_nombrecheque = '"+ nombrecheque + "' WHERE idpj_facturacionabogado = '" + id + "'";
                MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = myCommand.ExecuteReader();
            }
        }

        public void insertarrequerimientopago(string id, string numcredito, string usuario, string observaciones, string registrocont, string observacionescredito, string concepto)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_requerimientopago VALUES ('"+id+"', '"+numcredito+"', '"+usuario+"', '"+observaciones+"', '"+registrocont+"', '"+observacionescredito+"', '"+concepto+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string tipodocumentoCheque(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=20";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void insertarsolicitudcheque(string id, string numcredito, string usuario, string numcheque, string fechaemision, string banco, string observaciones, string monto)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO pj_solicitudcheque VALUES('" + id+"', '"+numcredito+"', '"+usuario+"', '"+numcheque+"', '"+fechaemision+"', '"+banco+"', '"+observaciones+"', '"+monto+"')";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string etapavoucher(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_correlativo_etapa FROM pj_etapa_credito WHERE idpj_credito = '"+credito+"' AND idpj_etapa = 6";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string tipodocumentoVoucher(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_documento FROM pj_documento WHERE idpj_credito= '" + credito + "' AND idpj_tipodocumento=21";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void cambiarestadoVoucher(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Cargar Voucher' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string tipoProceso(string proceso)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_nombreproceso FROM pj_tipoproceso WHERE idpj_tipoproceso= '" + proceso + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] traerComentarios(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT pj_comentario FROM pj_bitacora WHERE pj_estado = 'Enviado' AND pj_numcredito = '" + credito + "'";
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

        public DataTable reporteabogadosNombre(string abogado)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre, A.pj_cif, A.pj_numcredito, A.pj_fechaasignacion, B.pj_nombreabogado FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE A.idpj_abogado = '" + abogado + "' AND C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso')";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable reporteabogados3Todo(string abogado, string fecha)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre AS Nombre, A.pj_cif, A.pj_numcredito AS Credito, A.pj_fechaasignacion, B.pj_nombreabogado, C.pj_numincidente AS Incidente FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE A.idpj_abogado = '" + abogado + "' AND C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso') AND C.pj_fecha = '" + fecha + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable reporteabogadosFecha(string fecha)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre, A.pj_cif, A.pj_numcredito, A.pj_fechaasignacion, B.pj_nombreabogado FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso') AND C.pj_fecha = '" + fecha + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable reporteabogados3Fecha(string fecha)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_nombre AS Nombre, A.pj_cif, A.pj_numcredito AS Credito, A.pj_fechaasignacion, B.pj_nombreabogado, C.pj_numincidente AS Incidente FROM pj_certificacionjuidico AS A INNER JOIN pj_abogado AS B ON B.idpj_abogado = A.idpj_abogado INNER JOIN  pj_etapa_credito AS C ON C.idpj_credito = A.pj_numcredito WHERE C.idpj_etapa = 3 AND C.pj_status IN('Enviado','Reingreso') AND C.pj_fecha = '" + fecha + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public DataTable actualizarcreditosreporte()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 4 AND pj_status = 'Pendiente' ";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public void actualizaretapareporte(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Enviado' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "' AND pj_status = 'Pendiente'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public DataSet consultarComentarios(string credito)
        {
            DataSet ds1 = new DataSet();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT pj_comentario AS Comentario FROM pj_bitacora WHERE pj_estado = 'Enviado' AND pj_numcredito = '" + credito + "'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;

            }



        }

        public string numproceso(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT pj_numproceso FROM pj_presentaciondemanda WHERE pj_numcredito = '" + credito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public void cambiarestadoFactura(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_facturacionabogado SET pj_estado = 'Pendiente' WHERE pj_numcredito= '" + credito + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public string numserie(string credito)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT pj_numserie FROM pj_facturacionabogado WHERE pj_numcredito = '" + credito + "'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public string pendientesolicitud(string serie)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string camporesultante = "";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT pj_numserie FROM pj_facturacionabogado WHERE pj_estado = 'Iniciado' AND pj_numserie = '" + serie+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return camporesultante;// devuelve un arrgeglo con los campos 
            }
        }

        public DataTable cambioestadofactura(string serie)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT A.pj_cif AS CIF, A.pj_nombreasociado AS Nombre, A.pj_numcredito AS Credito, C.pj_numproceso AS Juicio, CONCAT('Juzgado', B.pj_numjuzgado, ' ' , B.pj_nombrejuzgado) AS Juzgado, CONCAT('SERIE ', A.pj_numserie, ' No. ', A.pj_numfactura) AS Factura, CONCAT('Q ', A.pj_importecaso) AS Importe FROM pj_facturacionabogado AS A INNER JOIN pj_presentaciondemanda AS B ON B.pj_numcredito = A.pj_numcredito INNER JOIN pj_presentaciondemanda AS C ON C.pj_numcredito = A.pj_numcredito INNER JOIN pj_etapa_credito AS D ON D.idpj_credito = A.pj_numcredito WHERE A.pj_numserie = '" + serie + "' AND A.pj_estado = 'Pendiente' AND D.idpj_etapa = 5";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public void cambiarestadocredito(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Espera' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public void cambiarestadorechazado(string credito, string etapa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE pj_etapa_credito SET pj_status = 'Rechazado' WHERE idpj_credito= '" + credito + "' AND idpj_etapa = '" + etapa + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = myCommand.ExecuteReader();
                }
                catch
                {

                }
            }
        }

        public DataTable solicitudcheque2(string serie)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT A.pj_cif AS CIF, A.pj_nombreasociado AS Nombre, A.pj_numcredito AS Credito, B.pj_numproceso AS Juicio, CONCAT('Juzgado', B.pj_numjuzgado, ' ' , B.pj_nombrejuzgado) AS Juzgado, CONCAT('SERIE ', A.pj_numserie, ' No. ', A.pj_numfactura) AS Factura, CONCAT('Q ', A.pj_importecaso) AS Importe, B.pj_numincidente AS Incidente FROM pj_facturacionabogado AS A INNER JOIN pj_presentaciondemanda AS B ON B.pj_numcredito = A.pj_numcredito INNER JOIN pj_etapa_credito AS D ON D.idpj_credito = A.pj_numcredito WHERE A.pj_numserie = '" + serie + "' AND A.pj_estado = 'Pendiente' AND D.idpj_etapa = 5 AND D.pj_status = 'Espera'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
    }
}
