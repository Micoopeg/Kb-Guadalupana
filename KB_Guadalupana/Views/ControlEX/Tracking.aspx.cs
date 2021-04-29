using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Tracking : System.Web.UI.Page
    {
        string etapas, agencia, exp, cod;
        protected void Page_Load(object sender, EventArgs e)
        {
            etapas = Convert.ToString(Session["etapa"]);
            agencia = Convert.ToString(Session["agencia"]);
            exp = Convert.ToString(Session["exp"]);
            cod = Convert.ToString(Session["cred"]);
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
                    progress.Attributes.Add("style", "width: 80%;");
                    break;


            }









        }
        //recibo el estado del expediente y aumento width segun estado

        //
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
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");
        }
    }
}