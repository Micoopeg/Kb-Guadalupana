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
    public partial class MatrizHallazgos : System.Web.UI.Page
    {
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombosucursal();
                llenarcomboestado();
               
            }
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

                    IGAgencia1.Enabled = true;
                    IGADepa1.Enabled = true;

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

        protected void iniciar_Click(object sender, EventArgs e)
        {
            Session["Mes1"] = Mes.Value;
            Session["Año1"] = año.Value;
            Session["Gerencia1"] = IGAgencia1.Text;
            Session["Area1"] = IGADepa1.Text;
            Session["Estado1"] = cmbestado.SelectedValue;

            Response.Redirect("InformeHallazgos.aspx");
        }
        public void llenarcomboestado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_estado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "estado");
                    cmbestado.DataSource = ds;
                    cmbestado.DataTextField = "sh_nombre";
                    cmbestado.DataValueField = "id_shestado";
                    cmbestado.DataBind();
                    cmbestado.Items.Insert(0, new ListItem("[Estado]", "0"));
                }
                catch { }
            }
        }

    }

}