using CRM_Guadalupana.Controllers;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Reporteria
{
    public partial class CRM_Reporteria : System.Web.UI.Page
    {
        Sentencias sn = new Sentencias();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            refrescarreporte();
        }
        private DataTable obtenermontos()
        {
            DataTable dt2 = new DataTable();

            dt2 = sn.reportetable("2");

            return dt2;
        }

        public void refrescarreporte()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSet1", obtenermontos());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/CRM-SISTEMA/Reporteria/Report1.rdlc";


            ReportViewer1.LocalReport.Refresh();

        }


    }
}