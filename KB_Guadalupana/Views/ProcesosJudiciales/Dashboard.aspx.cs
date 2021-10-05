using System;
using KB_Guadalupana.Controllers;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            //llenargridviewcreditos();
            creditoscobros();
            creditosconta();
            creditosjuridico();
            creditosabogado();
        }

        protected void BtnCobros_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardCobros.aspx");
        }

        protected void Contabilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardConta.aspx");
        }

        protected void BtnJuridico_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardJuridico.aspx");
        }

        public void creditoscobros()
        {
            string cantidadexpedientes, cantidaddili, cantidadfondos;
            int total;

            cantidadexpedientes = sn.creditoscobrosexpediente();
            cantidaddili = sn.creditoscobrosdiligenciamiento();
            cantidadfondos = sn.creditoscobrosfondos();

            total = Convert.ToInt32(cantidadexpedientes) + Convert.ToInt32(cantidaddili) + Convert.ToInt32(cantidadfondos);

            CantidadCobros.InnerHtml = total.ToString();

        }

        public void creditosconta()
        {
            string cantidadcerti, cantidadsolicitud;
            int total;

            cantidadcerti = sn.cantidadcreditoscontacertificacion();
            cantidadsolicitud = sn.cantidadcreditoscontasolicitud();

            total = Convert.ToInt32(cantidadcerti) + Convert.ToInt32(cantidadsolicitud);

            BtnConta.InnerHtml = total.ToString();
        }

        public void creditosjuridico()
        {
            string cantidadveri, cantidadreporte, cantidadrequerimiento;
            int total;

            cantidadveri = sn.cantidadcreditosjuridicoexpedientes();
            cantidadreporte = sn.cantidadcreditosjuridicoreporte();
            cantidadrequerimiento = sn.cantidadcreditosjuridicorequerimiento();

            total = Convert.ToInt32(cantidadveri) + Convert.ToInt32(cantidadreporte) + Convert.ToInt32(cantidadrequerimiento);

            Juridico.InnerHtml = total.ToString() ;
        }

        public void creditosabogado()
        {
            string cantidaddemanda, cantidadmedidas, cantidadnotieva, cantidadfacturacion, cantidadnotificacion, cantidadresolucion;
            int total;

            cantidaddemanda = sn.cantidadcreditosabogadodemanda();
            cantidadmedidas = sn.cantidadcreditosabogadodiligenciamiento();
            cantidadnotieva = sn.cantidadcreditosabogadonotificacioneva();
            cantidadfacturacion = sn.cantidadcreditosabogadofacturacion();
            cantidadnotificacion = sn.cantidadcreditosabogadonotificacion();
            cantidadresolucion = sn.cantidadcreditosresolucion();

            total = Convert.ToInt32(cantidaddemanda) + Convert.ToInt32(cantidadmedidas) + Convert.ToInt32(cantidadnotieva) + Convert.ToInt32(cantidadfacturacion) + Convert.ToInt32(cantidadnotificacion) + Convert.ToInt32(cantidadresolucion);

            Abogado.InnerHtml = total.ToString();
        }

        protected void BtnAbogado_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardAbogado.aspx");
        }

        //public void llenargridviewcreditos()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string query = "SELECT gen_numprestamo, CONCAT(gen_clientenombre1, ' ',  gen_clientenombre2, ' ', gen_clienteapellido1, ' ', gen_clienteapellido2) AS Nombre, gen_fechaasignacion FROM gen_credito";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataTable dt = new DataTable();
        //            myCommand.Fill(dt);
        //            gridViewAsignacion.DataSource = dt;
        //            gridViewAsignacion.DataBind();
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}

        //protected void OnSelectedIndexChangedAsignacion(object sender, EventArgs e)
        //{
        //    string numcredito = Convert.ToString((gridViewAsignacion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
        //    Session["credito"] = numcredito;
        //    Response.Redirect("ProcesoJudicial.aspx");
        //}
    }
}
