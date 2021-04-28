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
    public partial class Ex_Principal : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string fechamin, horamin, fechahora;
        char delimitador2 = ' ';
        string usernombre, nombrepersona, coduser;
        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"] = "pgecasasola");
            nombrepersona = Convert.ToString(Session["Nombre"] = "Edgar Casasola");

            NombreAgencia.InnerText = Convert.ToString(Session["Nombre"] = exc.agencia(usernombre));

            now();
            string area = exc.obtenerarea(usernombre);
            string rol = exc.obtenerrol(usernombre);
            if (area == "52" && rol == "1") {
                Response.Redirect("Ex_VistaMensajeria.aspx");
            }
            else
            {
                if (usernombre != "")
                {


                    coduser = exc.obtenercoduser(usernombre);
                    expenv.InnerText = exc.contenv(coduser);
                    exppenv.InnerText = exc.contpen(coduser);
                    exphall.InnerText = exc.contret(coduser);
                    expgen.InnerText = exc.contexis(coduser);

                }
                else
                {
                    Response.Redirect("../Sesion/MenuBarra.aspx");

                }
            }
        }

        public void now()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[2] + "/" + valores2[1] + "/" + valores2[0];

                    Date.InnerText = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }


        protected void btnInicio_Click(object sender, EventArgs e) {

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
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");
        }
    }
}