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
    public partial class DashboardConta : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                creditoscontasolicitud();
                creditosconta();
            }
            
        }

        public void creditosconta()
        {
            string cantidad;
            cantidad = sn.cantidadcreditoscontacertificacion();
            BtnConta.InnerHtml = cantidad;
        }

        public void creditoscontasolicitud()
        {
            string cantidad;
            cantidad = sn.cantidadcreditoscontasolicitud();
            SolicitudCant.InnerHtml = cantidad;
        }

        protected void BtnCobros_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteCertificacion.aspx");
        }

        protected void SolicitudCheque_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteSolicitudCheque.aspx");
        }
    }
}