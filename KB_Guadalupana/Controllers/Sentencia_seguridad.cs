using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Sentencia_seguridad
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        Conexion_seguridad cn = new Conexion_seguridad();

        public string obtenerestado(string usuario)
        {
            String camporesultante = "";
            String campo = "";
            try
            {
                string sql = "SELECT gen_estado FROM gen_usuario where codgenusuario = '" + usuario + "'";
                MySqlCommand command = new MySqlCommand(sql, cn.conectar());
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();

                //if(camporesultante == "0")
                //{
                //    campo = "Activo";
                //}
                //else if(camporesultante == "1")
                //{
                //    campo = "Inactivo";
                //}
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            finally { cn.desconectar(); }
            return camporesultante;
        }

        public string obtenerusuario(string id)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT gen_usuarionombre FROM gen_usuario WHERE codgenusuario = '" + id + "'";
                MySqlCommand command = new MySqlCommand(sql, cn.conectar());
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
}