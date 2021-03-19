using System;
using KB_Guadalupana.Controllers;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class ModificarEstado : System.Web.UI.Page
    {
        Conexion_seguridad cn = new Conexion_seguridad();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        string estado;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombousuario();
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {

                    sqlCon.Open();
                    string QueryString = "select * from gen_usuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    SUsuario.DataSource = ds;
                    SUsuario.DataTextField = "gen_usuarionombre";
                    SUsuario.DataValueField = "codgenusuario";
                    SUsuario.DataBind();
                    SUsuario.Items.Insert(0, new ListItem("[Usuario]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
    
        }

        protected void MGuardar_Click(object sender, EventArgs e)
        {
            if (seleccion.Value != "Estado" || SUsuario.SelectedIndex != 0) {
                sn.actualizarestado(SUsuario.SelectedValue, seleccion.Value);
                Response.Redirect("Seguridad1.aspx");
            }
            else {
                String script = "alert('Seleccione los campos correspondientes');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        }
        protected void SUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = sn.obtenerestado(SUsuario.SelectedValue);
            seleccion.Value = estado;
        }
        protected void btninicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad1.aspx");
        }
        protected void btnmoduloscrear_Click(object sender, EventArgs e)
        {

            Response.Redirect("SeguridadMod.aspx");
        }
        protected void btnappuser_Click(object sender, EventArgs e)
        {

            Response.Redirect("AsignacionAplicacion.aspx");
        }
        protected void btnModapp_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarModulo.aspx");
        }
        protected void btnmodulospermisos_Clicl(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad2.aspx");
        }
        protected void btnestadouser_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarEstado.aspx");
        }
    }
}