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
        CRM_Sentencias sn = new CRM_Sentencias();
        string nombreusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 3 || rolusuario == 6)
            {

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            llamardata();
        }
        public void llamardata()
        {
            string[] var4 = sn.fechaactual();
            string[] agenteacargo = sn.consultarcontrolingreso(nombreusuario);
            DateTime fechaactual = Convert.ToDateTime(var4[0]);
            DataSet ds1 = sn.consultarAc(agenteacargo[0], string.Format("{0: yyyy-MM-dd}", fechaactual)); ; //vonsulta las tareas del agente en fecha actual
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();


        }
        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Asesores/CRM_Asesores.aspx");

        }

        protected void btncerrasesion_Click(object sender, EventArgs e)
        {
            String script = "alert('Se encuentra saliendo del programa'); window.location.href= '../Asesores/CRM_Asesores.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

    }
}