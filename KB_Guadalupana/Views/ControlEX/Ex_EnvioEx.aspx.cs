using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_EnvioEx : System.Web.UI.Page
    {
        ControladorEX exc = new ControladorEX();
        ModeloEX mex = new ModeloEX();
        string envio;
        protected void Page_Load(object sender, EventArgs e)
        {

            envio = Convert.ToString(Session["varenv"]);
        }


        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }



    }
}