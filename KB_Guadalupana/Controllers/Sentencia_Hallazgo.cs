﻿using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Controllers
{

    public class Sentencia_Hallazgo
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Conexion cn = new Conexion();
        MySqlCommand comm;

        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
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

        public void insertartablas(string tabla, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
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

        public string[] consultarTotal1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion WHERE sh_estatus='4';";
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

        public string[] consultarTotal2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion WHERE sh_estatus='2' OR sh_estatus='3';";
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

        public string[] consultarTotal3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion WHERE sh_estatus='1';";
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

        public string[] consultarTotal4()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion WHERE sh_estatus='5';";
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

        public string[] consultarTotal5()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion;";
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

        public string[] consultarTotal6()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT count(*) FROM sh_respuesta_asignacion WHERE sh_estatus='6';";
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

        public string[] consultarID()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select id_shhallazgo from sh_hallazgo order by id_shhallazgo DESC limit 1";
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

        public string[] consultarRubro(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select sh_rubro from sh_hallazgo WHERE id_shhallazgo='" + dato + "'";
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

        public string[] consultarHallazgorestructurado(string dato)
        {
           
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();     
                    MySqlCommand command = new MySqlCommand("SELECT d.id_shgerencia,e.id_sharea,a.codshrespuestaasignacion,a.sh_calificacion,c.sh_mes,c.sh_año,c.sh_rubro,f.id_shestado,a.sh_imagensolucion,c.sh_hallazgo,a.sh_recomendacion,a.sh_comentarioauditor,a.sh_comentario FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE a.codshrespuestaasignacion='" + dato + "';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                                miLista.Add(reader.GetString(p));
                                 i++;
                        }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultarGerencia1(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select sh_gerencias_id_shgerencia,sh_idarea from sh_asignacion where sh_hallazgo_id_shhallazgo='" + dato + "' limit 1";
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

        public string[] consultarGerencia11(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select sh_gerencias_id_shgerencia,sh_idarea from sh_asignacion where sh_hallazgo_id_shhallazgo='" + dato + "' order by sh_idarea ASC LIMIT 1";
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

        public string[] consultarAsigancion(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select count(sh_hallazgo_id_shhallazgo) from sh_asignacion where sh_hallazgo_id_shhallazgo='" + dato + "'";
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

        public string[] consultarValor(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select COUNT(sh_hallazgo_id_shhallazgo) from sh_asignacion where sh_hallazgo_id_shhallazgo='" + dato + "'";
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

        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
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

        public void modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
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
                    sqlCon.Open();
                    string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "' AND " + campos[1] + " = '" + datos[1] + "';";
                    comm = new MySqlCommand(consulta, sqlCon);

                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        public string[] consultarAsigacionId(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `id_shasignacion` from sh_asignacion where sh_hallazgo_id_shhallazgo='" + dato + "'";
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

        public string[] consultarGerencia(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `sh_gerencianombre` from sh_gerencias where id_shgerencia='" + dato + "'";
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

        public string[] consultarArea(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `id_sharea`,`sh_areanombre` from sh_area where id_sharea ='" + dato + "'";
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

        public string[] consultarUsuario(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select codgenusuario from gen_usuario where gen_usuarionombre='" + dato + "'";
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

        public string[] consultarRol(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT sh_rol,sh_gerencia,sh_area from sh_permisos where sh_usuario='" + dato + "'";
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

        public string[] consultarAreas(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT t1.sh_areanombre from sh_permisos t0 inner join sh_area t1 on t0.sh_area=t1.id_sharea where t0.sh_area='" + dato + "'";
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

        public string[] consultarAreasGerencia(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `sh_gerencias_id_shgerencia` from sh_area where id_sharea='" + dato + "'";
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

        public string[] consultarAreasGerencia1(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `sh_gerencias_id_shgerencia`,`id_sharea` from sh_area where `sh_areanombre`='" + dato + "'";
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

        public string[] consultarHora()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select now();";
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

        public string[] consultarasiganacion1(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `id_shasignacion`,`sh_gerencias_id_shgerencia`,`sh_hallazgo_id_shhallazgo`,`sh_idarea` from sh_asignacion where `sh_hallazgo_id_shhallazgo`= '" + dato + "' order by `id_shasignacion` desc limit 1";
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

        public string[] consultarasiganacion11(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select `id_shasignacion`,`sh_gerencias_id_shgerencia`,`sh_hallazgo_id_shhallazgo`,`sh_idarea` from sh_asignacion where `sh_hallazgo_id_shhallazgo`= '" + dato + "' order by `id_shasignacion` asc limit 1";
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

        public string[] consultarasiganacioncontador(string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select count(`id_shasignacion`) from sh_asignacion where `sh_hallazgo_id_shhallazgo`='" + dato + "' order by `id_shasignacion` desc";
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

        public string[] cidhallazgo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select count(`id_shhallazgo`) from sh_hallazgo";
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

        public string[] consultaparcial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select count(sh_estatus) from sh_respuesta_asignacion where sh_estatus='7'";
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

        public string[] consultanosolucionado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select count(sh_estatus) from sh_respuesta_asignacion where sh_estatus='8'";
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

        public string[] consultararchivodehallazgo(string dato)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT c.sh_archivo FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE a.codshrespuestaasignacion='"+dato+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultarimagensolucionh(string dato)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT sh_imagensolucion FROM sh_respuesta_asignacion where codshrespuestaasignacion='" + dato + "'", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultarrespuestadehallazgo(string dato)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.sh_comentario FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE a.codshrespuestaasignacion='" + dato + "';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultaridhallazgo(string dato)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT c.id_shhallazgo FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE a.codshrespuestaasignacion='"+dato+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

    }

}