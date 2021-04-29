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
                    exmesa.InnerText = exc.contenv();
                    esmens.InnerText = exc.contpen();
                    extran.InnerText = exc.contret();
                    exppenv.InnerText = exc.contexis();
                    exjur.InnerText = mex.contjur();
                    exret.InnerText = mex.contret();
                    exarch.InnerText = mex.contarch();

                }
                else
                {
                    Response.Redirect("../Sesion/MenuBarra.aspx");

                }
            }
            if (rol=="8" || rol == "2") {
                mesareg.Visible = true;
            
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_VistaMesaQA.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e) {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
    
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");
        }
    }
}