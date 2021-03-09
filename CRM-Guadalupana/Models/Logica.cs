using CRM_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;

namespace CRM_Guadalupana.Models
{
    public class Logica
    {
         string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
        Sentencias sn = new Sentencias();
        Conexion cn = new Conexion();
        MySqlCommand comm;
        public void insertartablas(string tabla, string[] datos)
        {
            sn.insertartablas(tabla, datos);
        }
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }
        public void eliminadoderegistrosprotegida(string tabla)
        {
            sn.eliminadoderegistrosprotegida(tabla);
        }

        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            sn.modificartablas(tabla, campos, datos);
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

        public void bitacoraingreso()
        {
            string[] var1 = sn.datetime();
            DateTime fechai = Convert.ToDateTime(var1[0]);
            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string strsql;
                    strsql = "bitacora_ingresos_egresos";
                    MySqlCommand comm = new MySqlCommand(strsql, sqlCon);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@username", "Normal");
                    comm.Parameters.AddWithValue("@ipaddress", GetLocalIPAddress());
                    comm.Parameters.AddWithValue("@macaddress", macAddr);
                    comm.Parameters.AddWithValue("@fechahora_actual", fechai);
                    comm.Parameters.AddWithValue("@nombremodulo", "CRM");
                    comm.Parameters.AddWithValue("@ingresos_egresos", "Ingreso");
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                catch (Exception err)
                {
                }
            }

        }

        public void bitacoraingresoprocedimientos()
        {
            string[] var1 = sn.datetime();
            DateTime fechai = Convert.ToDateTime(var1[0]);
            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string strsql;
                    strsql = "bitacora_procedimientos";
                    MySqlCommand comm = new MySqlCommand(strsql, sqlCon);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@username", "Normal");
                    comm.Parameters.AddWithValue("@ipaddress", GetLocalIPAddress());
                    comm.Parameters.AddWithValue("@macaddress", macAddr);
                    comm.Parameters.AddWithValue("@fechahora_actual", fechai);
                    comm.Parameters.AddWithValue("@nombremodulo", "CRM");
                    comm.Parameters.AddWithValue("@aplicacion", "Ingreso");
                    comm.Parameters.AddWithValue("@operacion", "Ingreso");
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                catch (Exception err)
                {
                }
            }

        }





    }
}