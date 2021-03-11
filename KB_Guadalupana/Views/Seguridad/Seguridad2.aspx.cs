using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KBGuada.Controllers;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class Seguridad2 : System.Web.UI.Page
    {
        ControladorAV cav = new ControladorAV();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = cav.consultarapps();

            repetirapp.DataSource = ds;
            repetirapp.DataBind();


        }

        protected void btnmantenimiento_Click(object sender, EventArgs e)
        {
            string idc;
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("idapp")).Text;

            string url = cav.url(idc);




            Response.Redirect(url);
        }
    }
}