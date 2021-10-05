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
    public partial class DashboardJuridico : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                creditosjuridico();
                creditosreporte();
                creditosrequerimiento();
            }
            
        }

        public void creditosjuridico()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosjuridicoexpedientes();
            Juridico.InnerHtml = cantidad;
        }

        public void creditosreporte()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosjuridicoreporte();
            ReporteCant.InnerHtml = cantidad;
        }

        public void creditosrequerimiento()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosjuridicorequerimiento();
            RequerimientoCant.InnerHtml = cantidad;
        }

        protected void BtnCobros_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreditosCertificacionJuridico.aspx");
        }

        protected void Reporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExpedientesEntregados.aspx");
        }

        protected void RequerimientoPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteRequerimientoPago.aspx");
        }
    }
}