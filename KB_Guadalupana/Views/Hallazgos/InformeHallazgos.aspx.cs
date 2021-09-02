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
    public partial class InformeHallazgos : System.Web.UI.Page
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

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = MatrizdeSeguimiento.xls");
            Response.ContentType = "application/vnd.xls";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.RenderControl(hw);

            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = MatrizdeSeguimiento.xls");
            Response.ContentType = "application/vnd.xls";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewReporteH.RenderControl(hw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public void llenargridviewreporte()
        {

            gerencia = Session["Gerencia1"].ToString();
            area = Session["Area1"].ToString();
            estado = Session["Estado1"].ToString(); 

            año = Session["Año1"].ToString();
            trimestre = Session["Mes1"].ToString();

            mostrar();

            mess.InnerText = trimestre;
            B1.InnerText = año;
        }

        public void mostrar()
        {

            if((gerencia == "0" ) || (area == null || area == "") || (estado == "Estado"))
            {
                GridView1.Visible = false;
                btnExcel.Visible = true;
                Button1.Visible = false;
                using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
                {
                    try
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                        sqlCon.Open();
                        string QueryString = "SELECT a.codshrespuestaasignacion, c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,c.sh_rubro,c.sh_hallazgo,a.sh_recomendacion,a.sh_usuario,a.sh_fecha,a.sh_comentario,f.sh_nombre,a.sh_calificacion,a.sh_comentarioauditor FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea LEFT JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='" +trimestre+"' AND c.sh_año='"+año+"';";
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
            else
            {
                if ((estado == "2") || (estado == "3") || (estado == "1") || (estado == "4"))
                {
                    GridView1.Visible = false;
                    btnExcel.Visible = true;
                    Button1.Visible = false;
                    using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
                    {
                        try
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                            sqlCon.Open();
                            string QueryString = "SELECT a.codshrespuestaasignacion, c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,c.sh_rubro,c.sh_hallazgo,a.sh_recomendacion,a.sh_usuario,a.sh_fecha,a.sh_comentario,f.sh_nombre,a.sh_calificacion,a.sh_comentarioauditor FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea LEFT JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='"+trimestre+"' AND c.sh_año='"+año+"' AND b.sh_gerencias_id_shgerencia='"+gerencia+"' AND b.sh_idarea='"+area+"';";
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
                else
                {
                    GridViewReporteH.Visible = false;
                    btnExcel.Visible = false;
                    using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
                    {
                        try
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                            sqlCon.Open();
                            string QueryString = "SELECT a.codshrespuestaasignacion, c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,c.sh_rubro,c.sh_hallazgo,a.sh_recomendacion,a.sh_usuario,a.sh_fecha,a.sh_comentario,f.sh_nombre,a.sh_calificacion,a.sh_comentarioauditor FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea LEFT JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='"+trimestre+"' AND c.sh_año='"+año+"' AND b.sh_gerencias_id_shgerencia='"+gerencia+"' AND b.sh_idarea='"+area+"' AND a.sh_estatus='"+estado+"';";
                            MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                            DataTable ds3 = new DataTable();
                            command.Fill(ds3);
                            GridView1.DataSource = ds3;
                            GridView1.DataBind();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                        }
                    }
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