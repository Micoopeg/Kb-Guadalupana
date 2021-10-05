using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace borrar01.conexion
{
    public class conexion00
    {
        public MySqlConnection conne1 = new MySqlConnection();

        public string cc = "";
        public string mensaje = "";


        public void abrirconexion()
        {

            try
            {
                cc = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
                //cc = @"Server=10.60.81.4;Database=bdkbguadalupana;Uid=User4pDes@rrollo;Pwd=BDK0ntr@PG1;";

                conne1 = new MySqlConnection(cc);
                conne1.Open();
                mensaje = "Conectado";


            }
            catch (Exception )
            {

                mensaje = "errod de conexion";
            }

        }
        public void cerrar()
        {

            conne1.Close();


        }



    }
}