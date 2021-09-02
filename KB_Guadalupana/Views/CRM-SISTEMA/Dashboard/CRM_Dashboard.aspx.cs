using CRM_Guadalupana.Controllers;
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
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Sentencias sn = new CRM_Sentencias();
        string nombreusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 2 || rolusuario == 6)
            {

            }
            else
            {

                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                llenarcomboagencias();
                llenargrafico2();
                llenargrafico3("CENTRAL ZONA 14");
                string[] aprobados = sn.consultadeaprobados();
                string[] procesos = sn.consultaenprocesos();
                string[] nocontesta = sn.consultanocontesta();
                string[] noaplica = sn.consultanoaplica();
                lblaprobados.Text = aprobados[0];
                lblenproceso.Text = procesos[0];
                lblnocontestada.Text = nocontesta[0];
                lblnoaplica.Text = noaplica[0];
            }
        }

        public void llenargrafico2()
        {
            string totalsuma;
            string[] totaldeestado = sn.consultasumatoriadeestados();
            if (totaldeestado[0] == "" || totaldeestado[0] == null || totaldeestado[0] == "NULL")
            {
                totalsuma = "1";
            }
            else
            {
                totalsuma = totaldeestado[0];
            }
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,ROUND(COUNT(a.codcrmsemaforoestado)*100/'" + totalsuma + "',2) AS Cantidad FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
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
        public void llenargrafico3(string sucursal)
        {
            string totalsuma;
            string[] totaldeestado = sn.consultasumatoriadeestados();
            if (totaldeestado[0] == "" || totaldeestado[0] == null || totaldeestado[0] == "NULL")
            {
                totalsuma = "1";
            }
            else
            {
                totalsuma = totaldeestado[0];
            }
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,ROUND(COUNT(a.codcrmsemaforoestado)*100/'" + totalsuma + "',2) AS Cantidad  FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso where crmcontrol_ingresosucursal='" + sucursal + "' group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
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
        public void llenargrafico4(string sucursal)
        {
            string totalsuma;
            string[] totaldeestado = sn.consultasumatoriadeestadosporagencia(comboagencias.SelectedValue);
            if (totaldeestado.Length != 0)
            {
                if (totaldeestado[0] == "" || totaldeestado[0] == null || totaldeestado[0] == "NULL")
                {
                    totalsuma = "1";
                }
                else
                {
                    totalsuma = totaldeestado[0];
                }
                using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
                {
                    try
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,ROUND(COUNT(a.codcrmsemaforoestado)*100/'" + totalsuma + "',2) AS Cantidad  FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso where crmcontrol_ingresosucursal='" + sucursal + "' group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
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
            else
            {
                String script = "alert('Sin Asignación de LEADS');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }



        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            llenargrafico2();
            string[] aprobados = sn.consultadeaprobados();
            string[] procesos = sn.consultaenprocesos();
            string[] nocontesta = sn.consultanocontesta();
            string[] noaplica = sn.consultanoaplica();
            lblaprobados.Text = aprobados[0];
            lblenproceso.Text = procesos[0];
            lblnocontestada.Text = nocontesta[0];
            lblnoaplica.Text = noaplica[0];


            //realizar busquedas
        }
        public void llenarcomboagencias()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM crm_genagencias;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciaorigen1");
                    comboagencias.DataSource = ds;
                    comboagencias.DataTextField = "crm_genagenciasnombre";
                    comboagencias.DataValueField = "crm_genagenciasnombre";
                    comboagencias.DataBind();
                    comboagencias.Items.Insert(0, new ListItem("Seleccione una agencia", "0"));

                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void seleccionagencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string agencia = comboagencias.SelectedValue;
            llenargrafico2();
            llenargrafico4(agencia);
        }
    }
}