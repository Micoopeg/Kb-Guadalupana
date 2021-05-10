using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class DashboardJuridico : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            creditosjuridico();
        }

        public void creditosjuridico()
        {
            string cantidad;
            cantidad = sn.cantidadcreditosjuridico();
            Juridico.InnerHtml = cantidad;
        }
    }
}