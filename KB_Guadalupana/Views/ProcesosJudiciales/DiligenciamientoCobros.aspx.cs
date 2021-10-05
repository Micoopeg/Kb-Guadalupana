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
    public partial class DiligenciamientoCobros : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewinvestigacion();
                llenargridviewvoluntaria();

                if (gridViewInvestigacion.Rows.Count == 0)
                {
                    Div2.Visible = false;
                    SolicitudInvestigacion.Visible = false;
                }

                if (gridViewVoluntaria.Rows.Count == 0)
                {
                    Div1.Visible = false;
                    TransaccionVoluntaria.Visible = false;
                }
            }
        }

        public void llenargridviewinvestigacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 9 AND pj_status = 'Investigacion'";
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
            Response.Redirect("NuevaInvestigacion.aspx");
        }

        public void llenargridviewvoluntaria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 9 AND pj_status = 'Medidas suficientes'";
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
            Response.Redirect("TransaccionVoluntaria.aspx");
        }
    }
}