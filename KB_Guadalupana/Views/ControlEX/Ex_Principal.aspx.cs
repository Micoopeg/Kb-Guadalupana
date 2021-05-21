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
            usernombre = Convert.ToString(Session["sesion_usuario"]   );
            nombrepersona = Convert.ToString(Session["Nombre"]  );


            NombreAgencia.InnerText = Convert.ToString(Session["NombreAG"] = exc.agencia(usernombre));
            usuarioent.InnerText = nombrepersona;
            now();
            string area = exc.obtenerarea(usernombre);
            string rol = exc.obtenerrol(usernombre);
            string codigous = mex.obtenercodigo(usernombre);
            if (area == "52" && rol == "1") {
                Response.Redirect("Ex_VistaMensajeria.aspx");
            }
            else
            {
                if (codigous != "")
                {


                    coduser = exc.obtenercoduser(usernombre);
                 

                    switch (rol)
                    {

                        case "2":
                            mesareg.Visible = true;
                            archivo.Visible = false;
                            negocios.Visible = false;
                            hallazgos.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;
                        case "3":
                            negocios.Visible = false;
                            archivo.Visible = false;
                            mesareg.Visible = false;
                            hallazgos.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;
                        case "4":
                            mesareg.Visible = false;
                            archivo.Visible = false;
                            negocios.Visible = false;
                            hallazgos.Visible = false;
                            exmesa.InnerText = exc.contenv(area);
                            esmens.InnerText = exc.contpen(area);
                            extran.InnerText = exc.contret(area);
                            exppenv.InnerText = exc.contexis(area);
                            exjur.InnerText = mex.contjur(area);
                            exret.InnerText = mex.contreten(area);
                            exarch.InnerText = mex.contarch(area);
                            break;
                        case "5":
                            negocios.Visible = true;
                            archivo.Visible = false;
                            mesareg.Visible = false;
                            hallazgos.Visible = false;
                            pendientes.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;
                        case "6":
                            mesareg.Visible = false;
                            archivo.Visible = false;
                            negocios.Visible = false;
                            exmesa.InnerText = exc.contenv(area);
                            esmens.InnerText = exc.contpen(area);
                            extran.InnerText = exc.contret(area);
                            exppenv.InnerText = exc.contexis(area);
                            exjur.InnerText = mex.contjur(area);
                            exret.InnerText = mex.contreten(area);
                            exarch.InnerText = mex.contarch(area);
                            break;
                        case "7":
                            archivo.Visible = true;
                            mesareg.Visible = false;
                            negocios.Visible = false;
                            pendientes.Visible = false;
                            hallazgos.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;
                        case "8":
                            mesareg.Visible = true;
                            archivo.Visible = false;
                            hallazgos.Visible = false;
                            negocios.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;
                        case "9":
                            negocios.Visible = false;
                            archivo.Visible = false;
                            mesareg.Visible = false;
                            hallazgos.Visible = false;
                            exmesa.InnerText = exc.contenv2();
                            esmens.InnerText = mex.contpen2();
                            extran.InnerText = mex.contreten2();
                            exppenv.InnerText = mex.contexis2();
                            exjur.InnerText = mex.contjur2();
                            exret.InnerText = mex.contreten2();
                            exarch.InnerText = mex.contarch2();
                            break;

                    }
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

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_AgenciaHallazgos.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");
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

            Response.Redirect("Ex_VistaNegocios.aspx");

        }
    
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");
        }
    }
}