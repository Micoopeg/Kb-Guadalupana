using System;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class PendientePagoExtrajudicial : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IrPago_Click(object sender, EventArgs e)
        {
            Session["credito"] = Credito.Value;
            string credito = Session["credito"] as string;
            string desistimiento = sn.obtenerdesistimiento(credito);

            if(desistimiento == "" || desistimiento == null)
            {
                Response.Redirect("PagoExtrajudicial.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ya se realizó un pago extrajudicial con ese crédito');", true);
            }
            
        }
    }
}