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
            string rol = sn.rolusuario(idusuario);

            if(rol == "1")
            {
                if (area == "26")
                {
                    MenuCobros.Visible = true;
                    Cobros.Visible = true;
                    MenuConta.Visible = false;
                    MenuJuridico.Visible = false;
                    MenuAbogado.Visible = false;
                    MenuAsistente.Visible = false;
                }
                else if (area == "28")
                {
                    MenuCobros.Visible = false;
                    MenuConta.Visible = true;
                    Certificacion.Visible = true;
                    Solicitud.Visible = false;
                    MenuJuridico.Visible = false;
                    MenuAbogado.Visible = false;
                    MenuAsistente.Visible = false;
                }
                else if (area == "34")
                {
                    MenuCobros.Visible = false;
                    MenuConta.Visible = false;
                    MenuJuridico.Visible = true;
                    Expedientes.Visible = true;
                    Reporte.Visible = false;
                    MenuAbogado.Visible = false;
                    MenuAsistente.Visible = false;
                }
            }
            else
            {
                MenuCobros.Visible = true;
                Cobros.Visible = true;
                MenuConta.Visible = true;
                Certificacion.Visible = true;
                MenuJuridico.Visible = true;
                Expedientes.Visible = true;
                Solicitud.Visible = false;
                MenuAbogado.Visible = false;
                MenuAsistente.Visible = false;
                Reporte.Visible = false;
            }
        }
    }
}