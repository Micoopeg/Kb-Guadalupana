using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Reporteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btncerrar(object sender, EventArgs e)
        {

            Response.Redirect("../../Index.aspx");
        }
        protected void btninicio_click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }
        protected void btngeneral_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
    }
}