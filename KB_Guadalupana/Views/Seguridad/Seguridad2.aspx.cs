using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KBGuada.Controllers;
using KB_Guadalupana.Controllers;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class Seguridad2 : System.Web.UI.Page
    {   
        ControladorAV cav = new ControladorAV();
        Sentencia_seguridad SNS = new Sentencia_seguridad();
        string user, id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["sesion_usuario"]);
            string respuesta = SNS.obtenerpermisoseguridad(user);

            if (respuesta == "0" || respuesta == null || respuesta == "" || respuesta == "False")
            {
                String script = "alert('El usuario no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

            user = Convert.ToString(Session["usuario_seguridad"]);
            id = SNS.obteneridusuario(user);

            if (user != "" || id != "") { 
            DataSet ds = cav.consultarapps(id);

            repetirapp.DataSource = ds;
            repetirapp.DataBind(); }
            else {
                String script = "alert('no hay un usuario seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                Response.Redirect("Seguridad1.aspx");
                
            }

        }
       
        protected void btnmantenimiento_Click(object sender, EventArgs e)
        {
            string idc;
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("idapp")).Text;

            string url = cav.url(idc);




            Response.Redirect(url);
        }

        //botones redireccion

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