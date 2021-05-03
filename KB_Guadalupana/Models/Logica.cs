using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;

namespace KB_Guadalupana.Models
{
    public class Logica
    {
        Sentencia sn = new Sentencia();
        Sentencia_seguridad snseguridad = new Sentencia_seguridad();
        Conexion_seguridad cnseguridad = new Conexion_seguridad();
        public void insertarconcepto(string numero, string nombre)
        {

            string cadena = "INSERT INTO gen_sucursal VALUES ('" + numero + "', '" + nombre + "')";
            sn.ingreso(cadena);

        }

        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }

        public void insertartablas(string tabla, string[] datos)
        {
            sn.insertartablas(tabla, datos);
        }

        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            sn.modificartablas(tabla, campos, datos);
        }

        public void modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            sn.modificartablasdoscampos(tabla, campos, datos);
        }

        //FUNCIONES PARA CONSULTAR ESTADO PATRIMONIAL YA INGRESADO

        //FUNCIONES DE MOSTRAR

        public MySqlDataReader consultarCodigo(string usuario)
        {
            return sn.consultarCodigo(usuario);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public void bitacoraingresoprocedimientos(string nombreusuario, string modulo, string aplicacion, string operacion)
        {
            string[] var1 = snseguridad.datetime();
            DateTime fechai = Convert.ToDateTime(var1[0]);
            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            using (MySqlConnection sqlCon = new MySqlConnection(cnseguridad.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string strsql;
                    strsql = "bitacora_procedimientos";
                    MySqlCommand comm = new MySqlCommand(strsql, sqlCon);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@username", nombreusuario);
                    comm.Parameters.AddWithValue("@ipaddress", GetLocalIPAddress());
                    comm.Parameters.AddWithValue("@macaddress", macAddr);
                    comm.Parameters.AddWithValue("@fechahora_actual", fechai);
                    comm.Parameters.AddWithValue("@nombremodulo", modulo);
                    comm.Parameters.AddWithValue("@aplicacion", aplicacion);
                    comm.Parameters.AddWithValue("@operacion", operacion);
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                catch (Exception err)
                {
                }
            }

        }

        public MySqlDataReader consultarcif(string valor)
        {
            return sn.consultarconcampoIOs(valor);
        }

        public void eliminarregistro(string tabla, string campo, string dato)
        {
            sn.eliminarregistro(tabla, campo, dato);
        }

        public DataTable buscarCIF(string cif, string valor)
        {
            return sn.buscarCIF(cif, valor);
        }
    }
}