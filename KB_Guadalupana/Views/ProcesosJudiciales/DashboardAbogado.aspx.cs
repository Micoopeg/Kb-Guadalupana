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
    public partial class DashboardAbogado : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                creditosdemanda();
                creditosdiligenciamiento();
                creditosnotificacionApremio();
                creditosfacturacion();
                creditosnotificacion();
                creditosresolucion();
            }
        }

        public void creditosdemanda()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosabogadodemanda();
            PresentacionCant.InnerHtml = cantidad;
        }

        public void creditosdiligenciamiento()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosabogadodiligenciamiento();
            DiligenciamientoCant.InnerHtml = cantidad;
        }

        public void creditosnotificacionApremio()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosabogadonotificacioneva();
            NotificacionEvaCant.InnerHtml = cantidad;
        }

        public void creditosfacturacion()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosabogadofacturacion();
            FacturacionCant.InnerHtml = cantidad;
        }

        public void creditosnotificacion()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosabogadonotificacion();
            NotificacionCant.InnerHtml = cantidad;
        }

        public void creditosresolucion()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosresolucion();
            btnResolucion.InnerHtml = cantidad;
        }

        protected void Presentacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendientePresentacionDemanda.aspx");
        }

        protected void Diligenciamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteDiligenciamiento.aspx");
        }

        protected void NotificacionEva_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteNotificacionApremio.aspx");
        }

        protected void Facturación_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteFacturacionAbogado.aspx");
        }

        protected void Notificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendienteNotificacion.aspx");
        }

        protected void Resolucion_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendientePresentacionDemanda.aspx");
        }
    }
}