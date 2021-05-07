using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA_Arqueos.Controllers;
using KB_Guadalupana.Controllers;
//using SelectPdf;
//using Microsoft.AspNetCore.Mvc;
using Rotativa;
using System.Web.Mvc;

namespace SA_Arqueos.Controllers
{
    public class Sentencia_arqueos
    {
        Conexion conexiongeneral = new Conexion();
        Conexion_arqueos cn = new Conexion_arqueos();
        MySqlCommand comm;

       //public IActionResult GeneratePdf(string html)
       // {
       //     html = html.Replace("StrTag", "<").Replace("EndTag", ">");

       //     HtmlToPdf oHtmlToPdf = new HtmlToPdf();
       //     PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
       //     byte[] pdf = oPdfDocument.Save();
       //     oPdfDocument.Close();

       //     return File(
       //             pdf,
       //             "application/pdf",
       //             "StudentList.pdf"
       //         );
       // }

       // private IActionResult File(byte[] pdf, string v1, string v2)
       // {
       //     throw new NotImplementedException();
       // }

        public ActionResult Print()
        {
            return new ActionAsPdf("MenuArqueos", new { nombre = "Aida" })
            { FileName = "Test.pdf" };
        }

        public void ingreso(string query)
        {
            try { cn.conectar(query); }
            catch { }
            finally { cn.desconectar(); }
            
        }

        public MySqlDataReader consultar(string tabla)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    conn.Open();
                    string consultaGraAsis = " select * from " + tabla + ";";
                    comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                    MySqlDataReader mostrarResultados = comm.ExecuteReader();
                    return mostrarResultados;
                }
            
              
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }

        }

        public MySqlDataReader consultarRol(string usuario)
        {
            try
            {
                string consultaGraAsis = "SELECT gen_roles_codgenroles FROM gen_usuario WHERE gen_usuarionombre= '" + usuario + "';";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarArea(string usuario)
        {
            try
            {
                string consultaGraAsis = "SELECT gen_area_codgenarea FROM bdkbguadalupana.gen_usuario WHERE gen_usuarionombre = '" + usuario + "';";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarTotal(string id)
        {
            try
            {
                string consultaGraAsis = "SELECT sa_saldo FROM sa_detallecajachica WHERE idsa_detallecajachica = '" + id + "'";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarTotalHaber()
        {
            try
            {
                string consultaGraAsis = "SELECT SUM(sa_haber) FROM sa_detallecajachica";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarCodigo(string usuario)
        {
            try
            {
                string consultaGraAsis = "SELECT ep_control.codgenusuario FROM ep_control INNER JOIN gen_usuario ON ep_control.codgenusuario = gen_usuario.codgenusuario AND gen_usuario.gen_usuarionombre = '" + usuario + "' GROUP BY gen_usuario.codgenusuario; ";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public MySqlDataReader validarfechadeingreso_ep()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    conn.Open();
                    string consulta = "SELECT gen_usuarionombre,ep_administracionlotefechainicio,ep_administracionfechafin,a.codepadministracionlote,ep_administracionloteestado " +
                        "FROM ep_control a " +
                        "INNER JOIN gen_usuario b " +
                        "INNER JOIN ep_administracionlote c " +
                        "ON a.codgenusuario = b.codgenusuario AND a.codepadministracionlote = c.codepadministracionlote WHERE ep_administracionloteestado = 1;";
                    comm = new MySqlCommand(consulta, cn.conectar());
                    MySqlDataReader mostrarResultados = comm.ExecuteReader();
                    return mostrarResultados;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public MySqlDataReader fechaactual()
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT CURDATE();";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
         
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public string[] fechaactual2()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT CURRENT_DATE()";
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

        public MySqlDataReader busquedacif(string usuario, string lote)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT codepinformaciongeneralcif,gen_usuarionombre " +
                    "FROM ep_control a " +
                    "INNER JOIN gen_usuario b " +
                    "ON a.codgenusuario = b.codgenusuario AND codepadministracionlote= '" + lote + "' where  b.gen_usuarionombre ='" + usuario + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public MySqlDataReader estadodeprocesocif(string cif)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT codeptipoestado FROM ep_informaciongeneral WHERE codepinformaciongeneralcif = '" + cif + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public void insertartablas(string tabla, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
                finally { cn.desconectar(); }
            }
        }

        public MySqlDataReader modificartablas(string tabla, string[] campos, string[] datos)
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
                cn.conectar();
                string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrar = comm.ExecuteReader();
                Console.WriteLine(consulta);
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }
        public MySqlDataReader modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            string query = "";
            int n = 2;
            query += " set ";
            for (int i = 2; i < datos.Length; i++)
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
                cn.conectar();
                string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "' AND "+ campos[1] + " = '" + datos[1] + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                
                MySqlDataReader mostrar = comm.ExecuteReader();
                Console.WriteLine(consulta);
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        //TRAER FECHA ACTUAL
        public string[] datetime()
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

        //AGENCIA
        public string nombreagencia(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT sa_nombreagencia FROM sa_agencia WHERE idsa_agencia = '"+id+"'";
                    MySqlCommand command = new MySqlCommand(query, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                }
                catch { }
                return camporesultante;
            }
        }

        //MODIFICAR ENCABEZADO
        public void modificarencabezado(string dolares, string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                //string[] Campos = new string[30];
                //int i = 0;

                try
                {
                    string consulta = "UPDATE sa_encabezadotesoreria SET sa_tesoreriaDol = '" + dolares + "' WHERE idsa_encabezadotesoreria = '" + id + "'";
                    sqlCon.Open();
                    MySqlCommand comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = comm.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    for (int p = 0; p < reader.FieldCount; p++)
                    //    {
                    //        Campos[i] = reader.GetString(p);
                    //        i++;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
                finally { cn.desconectar(); }
                //return Campos;
            }
        }

        public void modificarRegistros( string id, string fecha, string documento, string proveedor, string descripcion, string debe, string haber)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                //string[] Campos = new string[30];
                //int i = 0;

                try
                {
                    string consulta = "UPDATE sa_detallecajachica SET sa_fecha = '" + fecha + "', sa_numdocumento = '" + documento + "', sa_proveedor = '" + proveedor + "', sa_descripcion = '" + descripcion + "', sa_debe = '" + debe + "', sa_haber = '" + haber + "' WHERE idsa_detallecajachica = '" + id + "'";
                    sqlCon.Open();
                    MySqlCommand comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = comm.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    for (int p = 0; p < reader.FieldCount; p++)
                    //    {
                    //        Campos[i] = reader.GetString(p);
                    //        i++;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
                finally { cn.desconectar(); }
                //return Campos;
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        public string obtenerid(string tabla, string campo)
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        public string ultimoid(string tabla, string campo)
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
                finally { cn.desconectar(); }
                return camporesultante;
                }
        }

        public MySqlDataReader consultarconcampo(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = " select * from " + tabla + " where " + campo + "='" + valor + "';";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public MySqlDataReader consultaridcontrol(string usuario, string lote)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = " select codepcontrol from ep_control where codgenusuario ='" + usuario + "' AND codepadministracionlote ='" + lote + "' ;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

        public string consultararqueoC(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT idsa_encabezadocajero FROM sa_encabezadocajero WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = DATE_FORMAT(CURRENT_DATE, '%Y') AND DATE_FORMAT(sa_fechayhora,  '%m') = DATE_FORMAT(CURRENT_DATE, '%m') AND DATE_FORMAT(sa_fechayhora,  '%d') = DATE_FORMAT(CURRENT_DATE, '%d') AND idsa_usuario = '"+id+"'";
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

        public string consultararqueoCC(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT idsa_encabezadocajachica FROM sa_encabezadocajachica WHERE DATE_FORMAT(sa_fecha,  '%Y') = DATE_FORMAT(CURRENT_DATE, '%Y') AND DATE_FORMAT(sa_fecha,  '%m') = DATE_FORMAT(CURRENT_DATE, '%m') AND DATE_FORMAT(sa_fecha,  '%d') = DATE_FORMAT(CURRENT_DATE, '%d') AND idsa_usuario = '" + id + "'";
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

        public string consultararqueoCA(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT idsa_encabezadocajeroaut FROM sa_encabezadocajeroaut WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = DATE_FORMAT(CURRENT_DATE, '%Y') AND DATE_FORMAT(sa_fechayhora,  '%m') = DATE_FORMAT(CURRENT_DATE, '%m') AND DATE_FORMAT(sa_fechayhora,  '%d') = DATE_FORMAT(CURRENT_DATE, '%d') AND idsa_usuario = '" + id + "'";
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

        public string consultararqueoT(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT idsa_encabezadotesoreria FROM sa_encabezadotesoreria WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = DATE_FORMAT(CURRENT_DATE, '%Y') AND DATE_FORMAT(sa_fechayhora,  '%m') = DATE_FORMAT(CURRENT_DATE, '%m') AND DATE_FORMAT(sa_fechayhora,  '%d') = DATE_FORMAT(CURRENT_DATE, '%d') AND idsa_usuario = '" + id + "'";
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

        public DataTable llenarGridView(string id)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM sa_detallecajachica WHERE idsa_encabezadocajachica = '" + id + "'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        //OBETNER NUMERO DE ARQUEO
        public string numarqueoCA(string año, string mes, string dia, string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sa_numarqueo + 1) FROM sa_encabezadocajeroaut WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '"+ mes +"' AND DATE_FORMAT(sa_fechayhora,  '%d') = '"+ dia +"' AND idsa_usuario = '" + id + "'";
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        public string numarqueoCC(string año, string mes, string dia, string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sa_numarqueo + 1) FROM sa_encabezadocajachica WHERE DATE_FORMAT(sa_fecha,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fecha,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fecha,  '%d') = '" + dia + "' AND idsa_usuario = '" + id + "'";
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        public string numarqueoC(string año, string mes, string dia, string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sa_numarqueo + 1) FROM sa_encabezadocajero WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + id + "'";
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        public string numarqueoT(string año, string mes, string dia, string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(sa_numarqueo + 1) FROM sa_encabezadotesoreria WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + id + "'";
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
                finally { cn.desconectar(); }
                return camporesultante;
            }
        }

        //MOSTRAR PUESTO
        public string obtenerpuesto(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT cod_puesto FROM sa_control_ingreso where cod_genusuario = '" + usuario + "'";
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

        public string obteneridusuario(string usuario)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT codgenusuario FROM gen_usuario WHERE gen_usuarionombre = '"+ usuario +"'";
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

        //OBTENER TOTAL HABER
        public string totalhaber(string id)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT SUM(sa_haber) FROM sa_detallecajachica WHERE idsa_encabezadocajachica= '"+id+"'";
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

        //MOSTRAR ENCABEZADO
        public string[] mostrarencabezadoCA(string año, string mes, string dia, string usuario, string numarqueo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT idsa_encabezadocajeroaut, DATE_FORMAT(sa_fechayhora,  '%Y %m %d %T'), sa_agencia, sa_nombreoperador, sa_numoperador, sa_puestooperador, sa_nombreencargado, sa_puestoencargado, sa_atm FROM sa_encabezadocajeroaut WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + usuario + "' AND sa_numarqueo = '" + numarqueo + "'";

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

        public string[] mostrarencabezadoC(string año, string mes, string dia, string usuario, string numarqueo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT idsa_encabezadocajero, DATE_FORMAT(sa_fechayhora,  '%Y %m %d %T'), sa_agencia, sa_nombre, sa_usuario, sa_operador, sa_puestooperador, sa_nombreencargado, sa_puestoencargado, sa_comentarios FROM sa_encabezadocajero WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + usuario + "' AND sa_numarqueo = '" + numarqueo + "'";

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

        public string[] mostrarencabezadoT(string año, string mes, string dia, string usuario, string numarqueo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT idsa_encabezadotesoreria, DATE_FORMAT(sa_fechayhora,  '%Y %m %d %T'), sa_agencia, sa_nombreoperador, sa_numoperador, sa_puestooperador, sa_nombreencargado, sa_puestoencargado, sa_tesoreriaQ, sa_tesoreriaDol FROM sa_encabezadotesoreria WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + usuario + "' AND sa_numarqueo = '" + numarqueo + "'";

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

        public string[] mostrarencabezadoT2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT idsa_encabezadotesoreria, DATE_FORMAT(sa_fechayhora,  '%Y %m %d %T'), sa_agencia, sa_nombreoperador, sa_numoperador, sa_puestooperador, sa_nombreencargado, sa_puestoencargado, sa_tesoreriaQ, sa_tesoreriaDol FROM sa_encabezadotesoreria WHERE idsa_encabezadotesoreria = '" + id + "'";

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

        public string[] mostrarencabezadoCC(string año, string mes, string dia, string usuario, string numarqueo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT idsa_encabezadocajachica, sa_agencia, DATE_FORMAT(sa_fecha, '%Y %m %d %T'), sa_nombre, sa_numoperador, sa_puestooperador, sa_nombreencargado, sa_puestoencargado, sa_saldoinicial FROM sa_encabezadocajachica WHERE DATE_FORMAT(sa_fecha, '%Y') = '" + año + "' AND DATE_FORMAT(sa_fecha,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fecha,  '%d') = '" + dia + "' AND idsa_usuario = '" + usuario + "' AND sa_numarqueo = '" + numarqueo + "'";

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

        //MOSTRAR DETALLE CAJERO AUTOMATICO
        public string[] mostrardetalleCA1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 1";

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

        public string[] mostrardetalleCA2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 2";

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

        public string[] mostrardetalleCA3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 3";

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

        public string[] mostrardetalleCA4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 4";

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

        public string[] mostrardetalleCA5(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 5";

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

        public string[] mostrardetalleCA6(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 6";

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
        public string[] mostrardetalleCA7(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajeroaut WHERE idsa_encabezadocajeroaut = '" + id + "' AND idsa_billetes = 7";

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


        //MOSTRAR DETALLE CAJA CHICA

        public string[] mostrardetalleCC1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 1";

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

        public string[] mostrardetalleCC2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 2";

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

        public string[] mostrardetalleCC3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 3";

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

        public string[] mostrardetalleCC4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 4";

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

        public string[] mostrardetalleCC5(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 5";

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

        public string[] mostrardetalleCC6(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 6";

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

        public string[] mostrardetalleCC7(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_cuadrecajachica WHERE idsa_encabezadocajachica = '" + id + "' AND idsa_billetes = 7";

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

        //MOSTRAR DETALLE CAJERO
        public string[] mostrardetalleC1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 1";

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

        public string[] mostrardetalleC2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 2";

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

        public string[] mostrardetalleC3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 3";

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

        public string[] mostrardetalleC4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 4";

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

        public string[] mostrardetalleC5(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 5";

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

        public string[] mostrardetalleC6(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 6";

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

        public string[] mostrardetalleC7(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detallecajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_billetes = 7";

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

        //MOSTRAR CHEQUES CAJERO
        public string[] mostrarchequeC1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequescajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_tipocheque = 1 AND idsa_tipomoneda = 1";

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

        public string[] mostrarchequeC2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequescajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_tipocheque = 1 AND idsa_tipomoneda = 2";

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

        public string[] mostrarchequeC3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequescajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_tipocheque = 2 AND idsa_tipomoneda = 1";

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

        public string[] mostrarchequeC4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequescajero WHERE idsa_encabezadocajero = '" + id + "' AND idsa_tipocheque = 2 AND idsa_tipomoneda = 2";

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

        //MOSTRAR DETALLE TESORERIA QUETZALES

        public string[] mostrardetalleT1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 1 AND sa_tipomoneda = 1";

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

        public string[] mostrardetalleT2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 2";

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

        public string[] mostrardetalleT3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 3";

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

        public string[] mostrardetalleT4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 4";

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

        public string[] mostrardetalleT5(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 5";

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

        public string[] mostrardetalleT6(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 6";

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

        public string[] mostrardetalleT7(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 7";

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

        //MOSTRAR CHEQUES TESORERIA QUETZALES
        public string[] mostrarchequesTQ1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequestesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_tipomoneda = 1 AND idsa_tipocheque = 1";

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

        public string[] mostrarchequesTQ2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequestesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_tipomoneda = 1 AND idsa_tipocheque = 2";

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


        //MOSTRAR DETALLE TESORERIA DOLARES
        public string[] mostrardetalleTD1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 1 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 2 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD3(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 3 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD4(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 4 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD5(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 5 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD6(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 6 AND sa_tipomoneda = 2";

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

        public string[] mostrardetalleTD7(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_detalletesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_billetes = 7 AND sa_tipomoneda = 2";

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


        //MOSTRAR CHEQUES DOLARES TESORERIA

        public string[] mostrarchequesTD1(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequestesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_tipomoneda = 2 AND idsa_tipocheque = 1";

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

        public string[] mostrarchequesTD2(string id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * FROM sa_chequestesoreria WHERE idsa_encabezadotesoreria = '" + id + "' AND idsa_tipomoneda = 2 AND idsa_tipocheque = 2";

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



        public void eliminarregistro(string tabla, string campo, string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "DELETE FROM " + tabla + " WHERE " + campo + " = " + dato + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    comm = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader mostrarResultados = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }


        //public MySqlDataReader eliminarregistro(string tabla, string campo, string dato)
        //{
        //    try
        //    {
        //        cn.conectar();
        //        string sql = "DELETE FROM " + tabla + " WHERE " + campo + " = " + dato + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
        //        comm = new MySqlCommand(sql, cn.conectar());
        //        MySqlDataReader mostrarResultados = comm.ExecuteReader();
        //        return mostrarResultados;
        //    }
        //    catch (Exception err)
        //    {
        //        Console.WriteLine(err.Message);
        //        return null;
        //    }
        //}

    }

}