using CRM_Guadalupana.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Asesores
{
    public partial class CRM_Alertas : System.Web.UI.Page
    {
        Sentencias sn = new Sentencias();
        protected void Page_Load(object sender, EventArgs e)
        {
            llamardata();
        }
        public void llamardata()
        {
            DataSet ds1 = sn.consultarAc();
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();


        }
        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Asesores/CRM_Asesores.aspx");

        }

        protected void btncerrasesion_Click(object sender, EventArgs e)
        {
            String script = "alert('Se encuentra saliendo del programa'); window.location.href= '../../Index.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

    }
}