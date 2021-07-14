using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;

namespace KB_Guadalupana.Views.Evaluaciones
{
    public partial class SQ_Puestos : System.Web.UI.Page
    {
        ModeloSQ msq = new ModeloSQ();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ingresarpuesto()
        {
            string sig = msq.obtenerfinal("sq_puestoseval","codsqpuesto");
            string sql = "INSERT INTO `sq_puestoseval`(`codsqpuesto`, `puestodescrip`, `puestocant`) VALUES ( '"+sig+"','"+puesto.Value+"','"+cantidad.Value+"' );";

            msq.Insertar(sql);
            
        }
        protected void btnpuestos_Click(object sender, EventArgs e)
        {
           
            ingresarpuesto();

        }
    }
}