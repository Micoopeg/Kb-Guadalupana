using System;
using System.Data;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreusuario = Session["Nombre"] as string;
            NombreUsuario.InnerHtml = nombreusuario;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string area = sn.area(idusuario);

            if(area == "26")
            {
                MenuCobros.Visible = true;
                MenuConta.Visible = false;
                MenuJuridico.Visible = false;
            }
            else if(area == "28")
            {
                MenuCobros.Visible = false;
                MenuConta.Visible = true;
                MenuJuridico.Visible = false;
            }
            else if(area == "34")
            {
                MenuCobros.Visible = false;
                MenuConta.Visible = false;
                MenuJuridico.Visible = true;
            }
        }
    }
}