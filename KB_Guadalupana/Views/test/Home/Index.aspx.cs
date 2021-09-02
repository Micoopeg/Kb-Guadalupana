using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.test.Home
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["sessionString"] = "no";
            System.Web.HttpContext.Current.Session["idusu"] = "";
        }
    }
}