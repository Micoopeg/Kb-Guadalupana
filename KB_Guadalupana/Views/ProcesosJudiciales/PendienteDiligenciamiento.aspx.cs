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
    public partial class PendienteDiligenciamiento : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewcreditos();
            llenargridviewinvestigacion();
            llenargridviewvoluntaria();
            if (gridViewInvestigacion.Rows.Count == 0)
            {
                Investigacion.Visible = false;
            }

            if (gridViewVoluntaria.Rows.Count == 0)
            {
                TransaccionVoluntaria.Visible = false;
            }
        }

        public void llenargridviewcreditos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 8 AND pj_status IN ('Enviado','Reingreso') ";
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
            Response.Redirect("DiligenciamientoMedidas.aspx");
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

        public void llenargridviewinvestigacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 9 AND pj_status IN ('Nueva Investigacion') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewInvestigacion.DataSource = dt;
                    gridViewInvestigacion.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedInvestigacion(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewInvestigacion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("ResultadosDiligenciamiento.aspx");
        }

        public void llenargridviewvoluntaria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 9 AND pj_status IN ('Transaccion voluntaria', 'Transaccion no voluntaria') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewVoluntaria.DataSource = dt;
                    gridViewVoluntaria.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedVoluntaria(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewVoluntaria.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            string estado = Convert.ToString((gridViewVoluntaria.SelectedRow.FindControl("lblestado") as Label).Text);
            Session["estado"] = estado;
            Response.Redirect("MedidasVoluntarias.aspx");
        }

        public void llenargridviewdevueltos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 3 AND pj_status = 'Devuelto' ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDevueltos.DataSource = dt;
                    gridViewDevueltos.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedDevueltos(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewInvestigacion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("DevueltosDiligenciamiento.aspx");
        }

    }
}