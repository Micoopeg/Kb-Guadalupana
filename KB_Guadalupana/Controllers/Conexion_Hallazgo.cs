using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Conexion_Hallazgo
    {

        Conexion conexiongeneral = new Conexion();
        public string cadenadeconexion()
        {
            string connectionString = conexiongeneral.cadenadeconexiongeneral();
            //string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
            return connectionString;
        }

    }
}