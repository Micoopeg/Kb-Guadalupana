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
            string cantidad;
            cantidad = sn.creditoscobros();
            CantidadCobros.InnerHtml = cantidad;

        }

        public void creditosconta()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosconta();
            BtnConta.InnerHtml = cantidad;
        }

        public void creditosjuridico()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosjuridico();
            Juridico.InnerHtml = cantidad;
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
