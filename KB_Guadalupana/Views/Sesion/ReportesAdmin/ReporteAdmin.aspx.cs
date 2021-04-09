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

namespace KB_Guadalupana.Views.Sesion.ReportesAdmin
{
    public partial class ReporteAdmin : System.Web.UI.Page
    {
        int valor1, valor2, valor3, total;
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarIE();
            mostrarIE1();
            mostrarIE2();

            total = valor1 + valor2 + valor3;
            Totales.Value = Convert.ToString(total);
        }

        protected void iniciar_Click(object sender, EventArgs e)
        {
            Session["Valor"] = valor.Value;

            Response.Redirect("../Reporte.aspx");
        }

        public void mostrarIE()
        {
            string[] var1 = sn.consultarTotal1();
            for (int i = 0; i < var1.Length; i++)
            {
                valor1 = Convert.ToInt32(var1[0]);
                noini.Value = Convert.ToString(valor1);
            }
        }

        public void mostrarIE1()
        {
            string[] var1 = sn.consultarTotal2();
            for (int i = 0; i < var1.Length; i++)
            {
                valor2 = Convert.ToInt32(var1[0]);
                ini.Value = Convert.ToString(valor2);
            }
        }

        public void mostrarIE2()
        {
            string[] var1 = sn.consultarTotal3();
            for (int i = 0; i < var1.Length; i++)
            {
                valor3 = Convert.ToInt32(var1[0]);
                ter.Value = Convert.ToString(valor3);
            }
        }
    }
}