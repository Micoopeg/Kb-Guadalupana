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
    public partial class Seguridad : System.Web.UI.Page
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
                llenarcombousuario();
                mostrar1();
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
                }
                catch { }
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `gen_usuario` ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "GerenciasH");
                    usuario.DataSource = ds;
                    usuario.DataTextField = "gen_usuarionombre";
                    usuario.DataValueField = "codgenusuario";
                    usuario.DataBind();
                    usuario.Items.Insert(0, new ListItem("[Usuarios]", "0"));
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
            string sig1999 = logic.siguiente("sh_permisos ", "id_shpermisos");
            string[] valores1999 = { sig1999, IGAgencia1.Text, IGADepa1.Text, puestos.Value, usuario.Text, roles.Value };
            logic.insertartablas("sh_permisos", valores1999);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Key", "alert('Permiso Creado');", true);
        }

        public void mostrar1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "select t0.id_shpermisos,t1.sh_gerencianombre,t2.sh_areanombre,t3.gen_usuarionombre, " +
                        "CASE when t0.sh_rol = '1' then 'Gerente General' when t0.sh_rol ='2' then 'Gerente' when t0.sh_rol='3' then 'Jefe' when t0.sh_rol='4' then 'Auditor' END as Rol" +
                        " from sh_permisos t0 inner join sh_gerencias t1 on t0.sh_gerencia=t1.id_shgerencia inner join sh_area t2 on t0.sh_area=t2.id_sharea " +
                        "inner join gen_usuario t3 on t0.sh_usuario=t3.codgenusuario";
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
    }
}