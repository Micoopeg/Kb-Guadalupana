using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Dashboard
{
    public partial class CRM_Dashboard : System.Web.UI.Page
    {
        Logica logic = new Logica();
        string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargrafico2();
            llenargrafico3();
            lblaprobados.Text = "3";
            lblenproceso.Text = "10000";
            lblnoaplica.Text = "20";
            lblnocontestada.Text = "5";
        }

        public void llenargrafico2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,COUNT(a.codcrmsemaforoestado) AS Cantidad  FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto where codcrmcontrolingreso=4 group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "grafica");
                    Chart1.Titles.Clear();
                    Chart1.Series.Clear();
                    Chart1.ChartAreas.Clear();
                    // Chart1.DataSource = ds;
                    ChartArea agregargrafico = new ChartArea();
                    agregargrafico.Area3DStyle.Enable3D = true;
                    Chart1.ChartAreas.Add(agregargrafico);
                    Series seriedatos = new Series("codcrmsemaforoestado");
                    seriedatos.ChartType = SeriesChartType.Pie;
                    seriedatos.XValueMember = "crmsemaforo_estadodescripcion";
                    seriedatos.YValueMembers = "Cantidad";
                    seriedatos.IsValueShownAsLabel = true;
                    Chart1.Series.Add(seriedatos);
                    Chart1.DataSource = ds;


                }
                catch
                {
                    Console.WriteLine("Verifique los campos");
                }
            }


        }
        public void llenargrafico3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,COUNT(a.codcrmsemaforoestado) AS Cantidad  FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto where codcrmcontrolingreso=4 group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "grafica");
                    Chart2.Titles.Clear();
                    Chart2.Series.Clear();
                    Chart2.ChartAreas.Clear();
                    // Chart1.DataSource = ds;
                    ChartArea agregargrafico = new ChartArea();
                    agregargrafico.Area3DStyle.Enable3D = true;
                    Chart2.ChartAreas.Add(agregargrafico);
                    Series seriedatos = new Series("codcrmsemaforoestado");
                    seriedatos.ChartType = SeriesChartType.Pie;
                    seriedatos.XValueMember = "crmsemaforo_estadodescripcion";
                    seriedatos.YValueMembers = "Cantidad";
                    seriedatos.IsValueShownAsLabel = true;
                    Chart2.Series.Add(seriedatos);
                    Chart2.DataSource = ds;


                }
                catch
                {
                    Console.WriteLine("Verifique los campos");
                }
            }


        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");

        }

    }
}