using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class VistaHallazgo : System.Web.UI.Page
    {

        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        string trimestre, año, gerencia, area, estado;
        string mes1 = "1";
        string mes2 = "2";
        string mes3 = "3";
        string mes4 = "4";
        string idguardar;

        string val1, val2, val3;


        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewreporte();
        }

        public void llenargridviewreporte()
        {
            trimestre = Session["Mes"].ToString();
            año = Session["Año"].ToString();
            gerencia = Session["Gerencia"].ToString();
            area = Session["Area"].ToString();
            estado = Session["Estado"].ToString();
            mostrar();

            //Trimestre 1 (Enero,Febrero,Marzo)
            //if(trimestre == mes1)
            //{
            //    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Trimestre 1');", true);
            //    val1 = "Enero";
            //    val2 = "Febrero";
            //    val3 = "Marzo";
            //    mostrar();
            //}
            ////Trimestre 2 (Abril,Marzo,Junio)
            //else if (trimestre == mes2)
            //{
            //    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Trimestre 2');", true);
            //    val1 = "Abril";
            //    val2 = "Mayo";
            //    val3 = "Junio";
            //    mostrar();
            //}
            ////Trimestre 3 (Julio,Agosto,Septiembre)
            //else if (trimestre == mes3)
            //{
            //    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Trimestre 3');", true);
            //    val1 = "Julio";
            //    val2 = "Agosto";
            //    val3 = "Septiembre";
            //    mostrar();
            //}
            ////Trimestre 4 (Octubre,Novimebre,Diciembre)
            //else if (trimestre == mes4)
            //{
            //    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Trimestre 4');", true);
            //    val1 = "Octubre";
            //    val2 = "Noviembre";
            //    val3 = "Diciembre";
            //    mostrar();
        }

        public void mostrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes,t4.sh_nombre,t2.sh_gerencianombre,t3.sh_areanombre " +
                        "from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo " +
                        "inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia " +
                        "inner join sh_area t3 on t1.sh_idarea= t3.id_sharea " +
                        "inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado " +
                        "where t0.sh_mes='" + trimestre + "' and t0.sh_año='" + año + "' and t1.sh_gerencias_id_shgerencia='" + gerencia + "' and t1.sh_idarea='" + area + "' and t0.sh_estado_id_shestado ='" + estado + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporteH.DataSource = ds3;
                    GridViewReporteH.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        protected void OnSelectedIndexChangedReporte(object sender, EventArgs e)
        {
            string val1, val2;



            GridViewRow row = GridViewReporteH.SelectedRow;
            idguardar = Convert.ToString((GridViewReporteH.SelectedRow.FindControl("idhallazgo") as Label).Text);

            Session["Idguardar"] = idguardar;
            Response.Redirect("EditarHallazgo.aspx");
        }

    }
}