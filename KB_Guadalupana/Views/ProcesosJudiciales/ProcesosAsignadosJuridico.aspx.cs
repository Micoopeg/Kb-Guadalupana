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
    public partial class ProcesosAsignadosJuridico : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewasignacion();
        }

        public void llenargridviewasignacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.pj_numcredito AS Credito, CONCAT(B.gen_clientenombre1, ' ',  B.gen_clientenombre2, ' ', B.gen_clienteapellido1, ' ', B.gen_clienteapellido2) AS Nombre, A.pj_fechaasignacion AS Fecha, A.pj_estado AS Estado FROM pj_asignacion_juridico AS A INNER JOIN gen_credito2 AS B ON B.gen_numprestamo = A.pj_numcredito WHERE A.pj_estado = 'Pendiente'";
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
            Session["credito"] = numcredito;
            Response.Redirect("ProcesoJudicial.aspx");
        }
    }
}
