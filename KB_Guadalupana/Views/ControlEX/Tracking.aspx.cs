using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;


namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Tracking : System.Web.UI.Page
    {
        string etapas, agencia, exp, cod;
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        protected void Page_Load(object sender, EventArgs e)
        {
            etapas = Convert.ToString(Session["etapa"]);
            agencia = Convert.ToString(Session["agencia"]);
            exp = Convert.ToString(Session["exp"]);
            cod = Convert.ToString(Session["cred"]);
            llenararch();
            switch (etapas) {

                case "1":
                    progress.Attributes.Add("style", "width: 10%;");
                    numeroexp.InnerText = "Expediente: "+exp +"," +agencia  ;
                    procesoesp.InnerText = "En Transito a central"  ;
                    nocred.InnerText = "No. Credito "+ cod  ;
                    break;
                case "2":
                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText = "En Mensajeria para validación"  ;
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 20%;");
                    break;
                case "3":
                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText = "En Mesa para distribución"  ;
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 40%;");
                    break;
                case "4":
                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText ="Envio a jurídico"   ;
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 50%;");
                    break;
                case "5":
                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText = "Mesa de control Envia al Archivo";
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 60%;");
                    break;
                case "6":

                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText ="Expediente Archivado"   ;
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 60%;");
                    break;
                case "7":

                    numeroexp.InnerText = "Expediente: " + exp + "," + agencia;
                    procesoesp.InnerText = "Expediente Archivado";
                    nocred.InnerText = "No. Credito " + cod;
                    progress.Attributes.Add("style", "width: 80%;");
                    break;

            }









        }
        //recibo el estado del expediente y aumento width segun estado

        public void llenararch()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenartrack(cod);
            DGVTRACK.DataSource = dt1;
            DGVTRACK.DataBind();

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void DGVTRACK_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVTRACK.PageIndex = e.NewPageIndex;
            llenararch();
        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_VistaNegocios.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/CerrarSesion.aspx");
        }
    }
}