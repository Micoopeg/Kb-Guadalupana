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
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewcreditos();
        }

        public void llenargridviewcreditos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT gen_numprestamo, CONCAT(gen_clientenombre1, ' ',  gen_clientenombre2, ' ', gen_clienteapellido1, ' ', gen_clienteapellido2) AS Nombre, gen_fechaasignacion, gen_estadoasignacion FROM gen_credito2";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewAsignacion.DataSource = dt;
                    gridViewAsignacion.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedAsignacion(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewAsignacion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito_buscado"] = numcredito;
            Response.Redirect("ProcesoJudicial.aspx");
        }
    }
}
