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
    public partial class PendienteNotificacionApremio : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewsinotificacion();
                llenargridviewcreditos();
                llenargridviewhonorarios();

                if (gridViewSiNotificacion.Rows.Count == 0)
                {
                    SiNotificacion.Visible = false;
                }

                if (gridViewHonorarios.Rows.Count == 0)
                {
                    NotificacionHonorarios.Visible = false;
                }
            }
        }

        public void llenargridviewcreditos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 20 AND pj_status IN ('Enviado', 'Reingreso') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewCreditos.DataSource = dt;
                    gridViewCreditos.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedCreditos(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewCreditos.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("NotificacionViaApremio.aspx");
        }

        protected void gridViewCertificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "pj_status").ToString();

                if (_estado == "Reingreso")
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                else
                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }

        public void llenargridviewsinotificacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 24 AND pj_status IN ('Enviado', 'Reingreso') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewSiNotificacion.DataSource = dt;
                    gridViewSiNotificacion.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedSiNotificacion(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewSiNotificacion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("SiNotificacionApremio.aspx");
        }

        public void llenargridviewhonorarios()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 39 AND pj_status IN ('Enviado', 'Reingreso') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewHonorarios.DataSource = dt;
                    gridViewHonorarios.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedHonorarios(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewHonorarios.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("TestimonioFacturacion.aspx");
        }
    }
}