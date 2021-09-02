using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.MantenimientosEP
{
    public partial class MenuMantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnmantcambioestado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mant_epestados.aspx");
        }
    }
}