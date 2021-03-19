using System;
using SA_Arqueos.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Modulo_de_arqueos.Views
{
    public partial class MenuArqueos : System.Web.UI.Page
    {
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string usuario;
        string idusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            string abre;
            try
            {
                //    nombreuser.InnerText = Session["Nombre"].ToString();
                //    abre = Session["sesion_usuario"].ToString();
                //    string resultado = abre.Substring(2, 2);
                //Session["sesion_usuario"] = "pgaortiz";
                usuario = Session["sesion_usuario"] as string;
                //Session["Nombre"] = "Aida Jimena Ortiz Delgado";
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                idusuario = sn.obteneridusuario(usuario);
                Session["puesto_usuario"] = sn.obtenerpuesto(idusuario);
            }
            catch
            {

            }
        }

        protected void Cajero_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoCajero.aspx");
        }

        protected void CajeroAutomatico_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoCajeroAutomatico.aspx");
        }

        protected void Tesoreria_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoTesoreria.aspx");
        }

        protected void CajaChica_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoCajaChica.aspx");
        }

        
    }
}
