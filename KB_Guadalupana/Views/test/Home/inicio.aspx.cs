using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.test.Home
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            string dato = this.Session["sessionString"].ToString() ;
            // bool respuesta = false;

            if (dato == "si")
            {
                
                
            }
            else if (dato == "resolver")
            {
                //return RedirectToAction("Index", "resolver");
                Response.Redirect("../resolver/Index");

            }
            else
            {
                
                //return RedirectToAction("index", "Home");
                Response.Redirect("../Home/Index");
            }


        }
    }
}