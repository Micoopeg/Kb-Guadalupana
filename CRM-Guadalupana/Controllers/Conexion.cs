using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Guadalupana.Controllers
{
    public class Conexion
    {
        public string cadenadeconexion()
        {
            string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
            return connectionString;
        }
    }


}