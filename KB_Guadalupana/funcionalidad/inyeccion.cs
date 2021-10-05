using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Models;


namespace KB_Guadalupana.funcionalidad
{
    public class inyeccion
    {
        
        public bool insertar(string d1, string d2, string d3)
        {
            bool saber = false;
            string query = "";
      
            query = "insert into "+d1+" ("+d2+") values (" +d3+")";
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);
            try
            {
                comando.ExecuteNonQuery();
                saber = true;
            }
            catch (Exception ex)
            {
            }
            cone.cerrar();

            return saber;


        }

        public bool update(string d1, string d2, string d3)
        {
            bool saber = false;
            string query = "";

            query = "update  "+d1+" set "+d2+" where "+d3;
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);
            try
            {
                comando.ExecuteNonQuery();
                saber = true;
            }
            catch (Exception ex)
            {
            }
            cone.cerrar();

            return saber;


        }



        public List<modelogeneral.modelox> vistausuario(string tabla, string cuando)
        {


            string query3 = "SELECT id_usu, t1.id_col, usu_est, usu_cat, id_uni, nom_uni FROM " + tabla+" "+cuando+" ";

            List<modelogeneral.modelox> data = new List<modelogeneral.modelox>();
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    modelogeneral.modelox nuevo = new modelogeneral.modelox();

                    nuevo.d1 = dr["id_usu"].ToString();
                    nuevo.d2 = dr["id_col"].ToString();
                    nuevo.d3 = dr["usu_est"].ToString();
                    nuevo.d4 = dr["usu_cat"].ToString();
                    nuevo.d5 = dr["id_uni"].ToString();

                    data.Add(nuevo);
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

            return data;
         
        }



        public List<modelogeneral.modelox> vistacolaboradores(string tabla, string cuando)
        {


            string query3 = "SELECT * FROM " + tabla + " " + cuando + " ";

            List<modelogeneral.modelox> data = new List<modelogeneral.modelox>();
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    modelogeneral.modelox nuevo = new modelogeneral.modelox();

           
                    nuevo.d1 = dr["id_col"].ToString();
                    nuevo.d2 = dr["col_dpi"].ToString();
                    nuevo.d3 = dr["col_1no"].ToString() + " " + dr["col_1ap"].ToString();



                    data.Add(nuevo);
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

            return data;

        }



        public string[,] vistageneral(string tabla, string que, string cuando)
        {

            string query3 = "SELECT "+que+" FROM " + tabla + " " + cuando + " ";

            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            string[,] respuesta = null;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                int columnas = dr.FieldCount;
                int filas = cuantasfilas(query3);
                int contador = 0;
                string datox = "";
                respuesta = new string[filas, columnas];

                while (dr.Read())
                {
                    for (int x = 0; x < columnas; x++)
                    {
                        datox = dr[x].ToString();
                        respuesta[contador, x] = dr[x].ToString();
                    }
                    contador++;

                }

            }
            catch (Exception ex)
            {
            }

            cone.cerrar();
            return respuesta;

        }

        private int cuantasfilas(string query)
        {

            int saber = 0;

            string query3 = query;




            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlDataAdapter ada = new MySqlDataAdapter(query3, cone.conne1);

            DataTable dt = new DataTable();
            try
            {
                
                ada.Fill(dt);
                saber = dt.Rows.Count;

            }
            catch (Exception ex)
            {
            }

            cone.cerrar();

            return saber;

        }



        public string maquetado (string[,] nueva)
        {

            int filas = nueva.GetLength(0);
            int columnas = nueva.GetLength(1);
            string[] devolver = new string[filas];
            string arreglo = "";
            for (int i = 0; i < nueva.GetLength(0); i++)
            {

                arreglo = arreglo + "{";
                for (int j = 0; j < nueva.GetLength(1); j++)
                {
                    arreglo = arreglo + " \"d" + j + "\": \"" + nueva[i, j] + "\"";
                    if ((columnas - j) > 1)
                    {
                        arreglo = arreglo + ",";
                    }

                }
                arreglo = arreglo + "}";
                if ((filas - i) > 1)
                {
                    arreglo = arreglo + ",";
                }

                devolver[i] = arreglo;

            }

            arreglo = "[" + arreglo + "]";

            return arreglo;

        }



        public bool validarexiste(string tabla, string que, string cuando)
        {

            bool saber = true;

            string query3 = "SELECT " + que + " FROM " + tabla + " " + cuando + " ";
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    saber = false;

                }

            }
            catch (Exception ex)
            {
            }

            cone.cerrar();
            return saber;

        }

        public int ultimo(string tabla, string que, string cuando)
        {

            string query3 = "SELECT " + que + " FROM " + tabla + " " + cuando + " ";
            int valor = 0;
            borrar01.conexion.conexion00 cone = new borrar01.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
      
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {

                    valor = Convert.ToInt16(dr["dato"].ToString());

                }

            }
            catch (Exception ex)
            {
            }

            cone.cerrar();
            return valor;

        }



    }
}