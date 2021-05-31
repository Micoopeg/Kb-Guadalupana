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
    public partial class Bitacora : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewbitacora();
        }

        public void llenargridviewbitacora()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpj_incidente AS Incidente, A.pj_numcredito AS Credito, A.pj_nombre AS Nombre, A.pj_fechacreacion AS FechaCre, DATEDIFF(now(), A.pj_fechacreacion) AS Dias, A.pj_estado AS Estado, B.gen_areanombre AS DeArea, C.gen_areanombre AS ParaNombre, A.pj_comentario AS Comentario, A.pj_fecha AS Fecha FROM pj_bitacora AS A INNER JOIN pj_area AS B ON B.codgenarea = A.pj_deArea INNER JOIN pj_area AS C ON C.codgenarea = A.pj_paraArea WHERE A.pj_numcredito = '" + numcredito + "'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIncidente.DataSource = dt;
                    gridViewIncidente.DataBind();
                }
                catch
                {

                }
            }
        }

        public void estadocredito()
        {
            string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);

            if(estado == "Regresado")
            {
                
            }
        }

  

        protected void gridViewIncidente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

                if (_estado == "Devuelto")
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                else
                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }
    }
}