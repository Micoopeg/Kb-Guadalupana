using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class AsignarHallazgo : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                llenarcombosucursal();
            }
            datos();
        }

        public void llenarcombosucursal()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_gerencias";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "GerenciasH");
                    IGAgencia1.DataSource = ds;
                    IGAgencia1.DataTextField = "sh_gerencianombre";
                    IGAgencia1.DataValueField = "id_shgerencia";
                    IGAgencia1.DataBind();
                    IGAgencia1.Items.Insert(0, new ListItem("[Gerencias]", "0"));
                }
                catch { }
            }
        }

        public void llenarcomboarea(long codtiposucursal)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_area where 	sh_gerencias_id_shgerencia ='" + codtiposucursal + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    IGADepa1.DataSource = ds;
                    IGADepa1.DataTextField = "sh_areanombre";
                    IGADepa1.DataValueField = "id_sharea";
                    IGADepa1.DataBind();
                    IGADepa1.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void IGAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGADepa1.Visible = true;
            IGADepa1.ClearSelection();
            llenarcomboarea(long.Parse(IGAgencia1.SelectedValue));
        }

        protected void Guardar_Hallazgo_Click(object sender, EventArgs e)
        {
            id = Session["IDH"].ToString();
            string valor;
            string valor2 = "1";
            string valor1 = "0";

            string[] var1 = sen.consultarAsigancion(id);
            valor = Convert.ToString(var1[0].Trim());

            string recomendacion;
            recomendacion = Session["Recomendacion"].ToString();

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('ID:" + id + " Valor: " + valor + "');", true);

            if (valor == valor1)
            {
                string sig199 = logic.siguiente("sh_asignacion ", "	id_shasignacion ");
                string[] valores199 = { sig199, IGAgencia1.Text, id, IGADepa1.Text };
                logic.insertartablas("sh_asignacion", valores199);

                string sig200 = logic.siguiente("sh_respuesta_asignacion ", "codshrespuestaasignacion");
                string[] valores200 = { sig200, "", "", "null",sig199,"0","","5",recomendacion,"" };
                logic.insertartablas("sh_respuesta_asignacion", valores200);
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Asignado');", true);
            }
            if (valor == valor2)
            {
                string sig1999 = logic.siguiente("sh_asignacion ", "	id_shasignacion ");
                string[] valores1999 = { sig1999, IGAgencia1.Text, id, IGADepa1.Text };
                logic.insertartablas("sh_asignacion", valores1999);

                string sig201 = logic.siguiente("sh_respuesta_asignacion ", "codshrespuestaasignacion");
                string[] valores201 = { sig201, "", "", "null", sig1999, "0", "", "5", recomendacion, "" };
                logic.insertartablas("sh_respuesta_asignacion", valores201);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Key", "alert('2 Areas Asignadas al Hallazgo');", true);

                IGAgencia1.Visible = false;
                IGADepa1.Visible = false;
                guardar.Visible = false;
            }
        }

        protected void Guardar_Hallazgo1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "window.location.href= 'MenuHallazgos.aspx';", true);
        }

        protected void area2()
        {

        }

        protected void datos()
        {
            id = Session["IDH"].ToString();
            IDss.Value = id;
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('ID: "+id+"');", true);
            //string[] var1 = sen.consultarRubro(id);
            //for (int i = 0; i < var1.Length; i++)
            //{
            //    Text1s.Value = Convert.ToString(var1[0].Trim());
            //}
        }
    }
}