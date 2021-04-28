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
    public partial class EditarGerencia : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        string idgerencia, idguardar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrar();
                mostrar1();
            }

        }

        public void mostrar()
        {
            idgerencia = Session["IdGerencia"].ToString();
            ID.Value = idgerencia;


            string[] var1 = sen.consultarGerencia(idgerencia);

            Gerencian.Value = Convert.ToString(var1[0]);

        }

        protected void GuardarGerencia_Click(object sender, EventArgs e)
        {

            idgerencia = Session["IdGerencia"].ToString();

            string[] campos = { "id_shgerencia", "sh_gerencianombre" };
            string[] valores = { idgerencia, Gerencian.Value };
            try
            {
                logic.modificartablas("sh_gerencias", campos, valores);
            }
            catch
            { }
            finally
            {
                try
                {
                    cn.desconectar();
                }
                catch
                { }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Gerencia Actualizada'); window.location.href= 'MantenimientoGerencias.aspx';", true);
        }

        public void mostrar1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    idgerencia = Session["IdGerencia"].ToString();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "select `id_sharea`,`sh_areanombre`,`sh_gerencias_id_shgerencia` from sh_area where `sh_gerencias_id_shgerencia`='" + idgerencia + "'";
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
            idguardar = Convert.ToString((GridViewReporteH.SelectedRow.FindControl("lblrubro") as Label).Text);

            Session["IdArea"] = idguardar;
            Response.Redirect("EditarArea.aspx");
        }
    }
}