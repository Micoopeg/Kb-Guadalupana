using CRM_Guadalupana.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.CRM_SISTEMA.Dashboard
{
    public partial class CRM_SubestadoNoaprobado : System.Web.UI.Page
    {
        CRM_Sentencias sn = new CRM_Sentencias();

        protected void Page_Load(object sender, EventArgs e)
        {
            llamardata();
        }
        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRM_Dashboard.aspx");

        }
        public void llamardata()
        {
            DataSet ds1 = sn.consultarsubestadosnoaplica(); //vonsulta las tareas del agente en fecha actual
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();
        }
    }
}