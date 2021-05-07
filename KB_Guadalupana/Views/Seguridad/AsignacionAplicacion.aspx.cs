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

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class AsignacionAplicacion : System.Web.UI.Page
    {
        Conexion_seguridad cn = new Conexion_seguridad();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        Logica lg = new Logica();
        Conexion conexiongeneral = new Conexion();
        string app, idusuario, user;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["sesion_usuario"]);
            string respuesta = sn.obtenerpermisoseguridad(user);

            if (respuesta == "0" || respuesta == null || respuesta == "" || respuesta == "False")
            {
                String script = "alert('El usuario no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

            AAUsuario.Value = Session["usuario_seguridad"] as string;
            user = Convert.ToString( Session["usuario_seguridad"]);
            if (user != "")
            {
                if (!IsPostBack)
                {
                    llenarcomboaplicacion();

                    llenargridviewaplicacion();
                }
            }
            else
            {
                String script = "alert('no hay un usuario seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                Response.Redirect("Seguridad1");

            }
           
        }

        protected void AAsignar_Click(object sender, EventArgs e)
        {
            idusuario = sn.obteneridusuario(AAUsuario.Value);
            app = sn.obtenerapp(idusuario, AAplicacion.SelectedValue);

            if(app == "")
            {
                string sig = lg.siguiente("gen_mdimenu", "codgenmdi");
                sn.asignarAplicacion(sig, AAplicacion.SelectedValue, idusuario);
                String script = "alert('Se ha asignado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
              
            }
            else
            {
                sn.actualizarappuserestado1(app,idusuario);
           
            }
            //Response.Redirect("Seguridad2.aspx");
            llenargridviewaplicacion();
        }
        protected void AAdesasignar_Click(object sender, EventArgs e)
        {
            idusuario = sn.obteneridusuario(AAUsuario.Value);
            app = sn.obtenerapp(idusuario, AAplicacion.SelectedValue);

            if (app == "")
            {
                String script = "alert('No se puede desasignar una aplicación que aún no ha sido asignada');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else
            {

                sn.actualizarappuserestado(app,idusuario);


                String script = "alert('Cambios realizados');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                Response.Redirect("Seguridad2.aspx");

            }
            //Response.Redirect("Seguridad2.aspx");
            llenargridviewaplicacion();
        }
        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_aplicacion";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Aplicacion");
                    AAplicacion.DataSource = ds;
                    AAplicacion.DataTextField = "gen_nombreapp";
                    AAplicacion.DataValueField = "codgenapp";
                    AAplicacion.DataBind();
                    AAplicacion.Items.Insert(0, new ListItem("[Aplicacion]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenargridviewaplicacion()
        {
            idusuario = sn.obteneridusuario(AAUsuario.Value);
            DataTable dt1 = new DataTable();
            dt1 = sn.llenarGridViewAplicaciones(idusuario);
            GridViewAplicaciones.DataSource = dt1;
            GridViewAplicaciones.DataBind();
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