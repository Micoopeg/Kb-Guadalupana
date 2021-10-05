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
    public partial class DiligenciamientoCartera : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewinvestigacion();
            }
        }

        public void llenargridviewinvestigacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 9 AND pj_status = 'Investigacion (Cartera Depurada)'";
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
            Response.Redirect("NuevaInvestigacionCartera.aspx");
        }
    }
}