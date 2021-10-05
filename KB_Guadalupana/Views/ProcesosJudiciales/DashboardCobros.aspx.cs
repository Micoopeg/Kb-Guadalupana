using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    
    public partial class DashboardCredito : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                creditoscobros();
                creditosdiligenciamiento();
                creditosfondos();
            }
        }

        public void creditoscobros()
        {
            string cantidad;
            cantidad = sn.creditoscobrosexpediente();
            CantidadCobros.InnerHtml = cantidad;

        }

        public void creditosdiligenciamiento()
        {
            string cantidad;
            cantidad = sn.creditoscobrosdiligenciamiento();
            DiligenciamientoCant.InnerHtml = cantidad;
        }

        public void creditosfondos()
        {
            string cantidad;
            cantidad = sn.creditoscobrosfondos();
            FondosCant.InnerHtml = cantidad;
        }

        protected void BtnCobros_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarProceso.aspx");
        }

        protected void Diligenciamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiligenciamientoCobros.aspx");
        }

        protected void EntregaFondos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteResolucionFavorable.aspx");
        }
    }
}