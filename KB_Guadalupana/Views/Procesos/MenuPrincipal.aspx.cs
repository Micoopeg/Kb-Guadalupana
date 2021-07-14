using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NombreUsuario.InnerText = Session["Nombre"] as string;
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string tipousuario = sn.tipousuario(idusuario);
                Session["nivel_usuario"] = tipousuario;
                string categoria = sn.categoriausuario(idusuario);
                Session["categoria_usuario"] = categoria;
                string subcategoria = sn.subcategoriausuario(idusuario);
                Session["subcategoria_usuario"] = subcategoria;

                if(subcategoria == "2")
                {
                    Procesos.Visible = true;
                }
                else
                {
                    Procesos.Visible = false;
                }
            }
        }
    }
}