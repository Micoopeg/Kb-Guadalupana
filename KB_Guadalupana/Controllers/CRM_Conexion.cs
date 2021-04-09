using KB_Guadalupana.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Guadalupana.Controllers
{
    public class CRM_Conexion
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