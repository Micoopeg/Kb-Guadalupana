using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using Microsoft.Reporting.WebForms;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class ExpedientesEntregados : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcomboabogados();
            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {

        }

        public void llenarcomboabogados()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_abogado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Abogados.DataSource = ds;
                    Abogados.DataTextField = "pj_nombreabogado";
                    Abogados.DataValueField = "idpj_abogado";
                    Abogados.DataBind();
                    Abogados.Items.Insert(0, new ListItem("[Abogado]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Generar_Click(object sender, EventArgs e)
        {
            ReporteAbogados.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSetJuridico", obtenerdatos());

            ReporteAbogados.LocalReport.DataSources.Add(fuente);
            ReporteAbogados.LocalReport.ReportPath = "Views/ProcesosJudiciales/Reportes/Report1.rdlc";
            ReporteAbogados.LocalReport.Refresh();
        }

        private DataTable obtenerdatos()
        {
            DataTable dt = new DataTable();

            dt = sn.reporteabogados(Abogados.SelectedValue);

            return dt;
        }
    }
}