﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Conexion
    {
        protected MySqlDataAdapter AdaptadorDatos;
        protected MySqlDataReader reader;
        protected DataSet data;

        public string cadenadeconexiongeneral()
        {
            string connectionString = @"Server=10.60.81.5;Database=bdkbguadalupana;Uid=BDuser1205;Pwd=K91nforPGADM;";
            //string connectionString = @"Server=10.60.81.4;Database=bdkbguadalupana;Uid=BDuser1204;Pwd=K91nforPG1;";
            //string connectionString = @"Server=10.60.81.5;Database=bdkbguadalupana;Uid=User4pDes@rrollo;Pwd=BDK0ntr@PG1;";
            //string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
            return connectionString;
        }

        public void conectar(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(cadenadeconexiongeneral()))
            {
                try
                {
                    connection.Open();
                    //string insertData = "insert into pruebadatos values ('" + TextBox1.Text + "', '" + TextBox2.Text + "')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.Write("realizado");
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.Write("no realizado" + ex);
                }
                finally { desconectar(); }

            }
        }

        public MySqlConnection conectar()
        {


            MySqlConnection conn = new MySqlConnection(cadenadeconexiongeneral());
            try
            {
                conn.Open();
                Console.WriteLine("se realizo");
              //  conn.Close();
                
               

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("No se pudo realizar la conexion", ex);
            }
            finally {
                desconectar();
                KillSleepingConnections(5);
            }
            return conn;
        }

        public void conectar2()
        {
            using (MySqlConnection connection = new MySqlConnection(cadenadeconexiongeneral()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM gen_usuario;";
                    //string insertData = "insert into pruebadatos values ('" + TextBox1.Text + "', '" + TextBox2.Text + "')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.Write("realizado");
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.Write("no realizado" + ex);
                }

            }

        }

        public DataSet Data
        {
            set { data = value; }
            get { return data; }
        }

        public MySqlDataReader DataReader
        {
            set { reader = value; }
            get { return reader; }
        }

        public MySqlConnection desconectar()
        {
            MySqlConnection conn = new MySqlConnection(cadenadeconexiongeneral());
            try
            {             
                conn.Close();                               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conn;
        }
        public void desconexion(MySqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch
            {
                Console.WriteLine("No Conectó");
            }
        }
        public int KillSleepingConnections(int iMinSecondsToExpire)
        {
            string strSQL = "show processlist";
            System.Collections.ArrayList m_ProcessesToKill = new ArrayList();

            MySqlConnection myConn = new MySqlConnection(cadenadeconexiongeneral());
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);
            MySqlDataReader MyReader = null;

            try
            {
                myConn.Open();

                // Get a list of processes to kill.
                MyReader = myCmd.ExecuteReader();
                while (MyReader.Read())
                {
                    // Find all processes sleeping with a timeout value higher than our threshold.
                    int iPID = Convert.ToInt32(MyReader["Id"].ToString());
                    string strState = MyReader["Command"].ToString();
                    int iTime = Convert.ToInt32(MyReader["Time"].ToString());

                    if (strState == "Sleep" && iTime >= iMinSecondsToExpire && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }

                MyReader.Close();

                foreach (int aPID in m_ProcessesToKill)
                {
                    strSQL = "kill " + aPID;
                    myCmd.CommandText = strSQL;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine(excep);
            }
            finally
            {
                if (MyReader != null && !MyReader.IsClosed)
                {
                    MyReader.Close();
                }

                if (myConn != null && myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            return m_ProcessesToKill.Count;
        }

    }
}