using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class Seguridad1 : System.Web.UI.Page
    {
        Conexion_seguridad cn = new Conexion_seguridad();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        string estado = "";
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
  string user = Convert.ToString(Session["sesion_usuario"]);
            string respuesta = sn.obtenerpermisoseguridad(user);

            if (respuesta == "0" || respuesta == null || respuesta == "" || respuesta == "False")
            {
                String script = "alert('El usuario no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            if (!IsPostBack)
            {
                llenarcomboagencia();
            }

        }

        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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
  
        protected void SUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["usuario_seguridad"] = SUsuario.SelectedItem.Text;
            estado = sn.obtenerestado(SUsuario.SelectedValue);
            if(estado == "True")
            {
                SEstado.Value = "Activo";
          
                lblmensaje.Visible = false;
            }else if(estado == "False")
            {
                SEstado.Value = "Inactivo";
     
                lblmensaje.Visible = true;
            }

            
        }

        protected void SVerificar_Click(object sender, EventArgs e)
        {
            estado = sn.obtenerestado(SUsuario.SelectedValue);
            if (estado == "True")
            {
                Response.Redirect("Seguridad2.aspx");
            }
            else if (estado == "False")
            {
                String script = "alert('No se puede acceder ya que el usuario se encuentra inactivo');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }
    }
}