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
    public partial class PendienteResolucion : System.Web.UI.Page
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
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status FROM pj_etapa_credito WHERE idpj_etapa = 4 AND pj_status IN ('Enviado','Reingreso', 'Diligenciamiento') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDemanda.DataSource = dt;
                    gridViewDemanda.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedDemanda(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewDemanda.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("ResolucionTramite.aspx");
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
                    e.Row.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }
}