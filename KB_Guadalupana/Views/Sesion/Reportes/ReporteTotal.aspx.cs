using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.Reportes
{
    public partial class ReporteTotal : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string sesion;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarCaja();
            mostrarCuentasQ();
            mostrarCuentasD();
            mostrarCooperativasD();
            mostrarCooperativasQ();
            mostrarCP();
            mostrarCP();
        }

        public void mostrarCaja()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarCaja("ep_informaciongeneral", "codepinformaciongeneralcif", cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        EfectivoCaja.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarCuentasQ()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarQ(cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        CuentasBancos.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarCuentasD()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarD(cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        CuentasBancos1.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarCooperativasD()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarCD(cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        CuentasCope1.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarCooperativasQ()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarCQ(cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        CuentasCope.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        
        public void mostrarCP()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            try
            {
                MySqlDataReader mostrar = logic.consultarCP(cifnumero);
                try
                {
                    if (mostrar.Read())
                    {
                        CuentasPC.Value = Convert.ToString(mostrar.GetString(0));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}