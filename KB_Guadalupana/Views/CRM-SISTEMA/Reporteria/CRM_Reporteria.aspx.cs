using CRM_Guadalupana.Controllers;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Reporteria
{
    public partial class CRM_Reporteria : System.Web.UI.Page
    {
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Conexion cn = new CRM_Conexion();
        string nombreusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 2 || rolusuario == 6 || rolusuario == 5)
            {

            }
            else
            {

                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                combotiposervicio.Visible = false;
                comboestadosemaforo.Visible = false;
                combodescripcionestado.Visible = false;
                combotipodomicilio.Visible = false;
                combofinalidadservicio.Visible = false;
                txtingresos.Visible = false;
                txtmonto.Visible = false;
                combotrabajoactual.Visible = false;
                combocuentaigss.Visible = false;
                txtañodomicilios.Visible = false;
                txttipodecontacto.Visible = false;
                comboagencia.Visible = false;
                combousuario.Visible = false;
                combocuentacooperativa.Visible = false;
                llenarcombotiposervicio();
                llenarcombofinalidadservicio();
                llenarsemaforo();
                llenartipodomicilio();
                llenarcomboagencia();

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string fechainicio1 = fechainicio.Value;
            string fechafin1 = fechafin.Value;
            if (fechainicio1 == "" || fechafin1 == "")
            {
                String script = "alert('OBLIGATORIO COLOCAR UNA FECHA PARA FILTRAR');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else
            {
                refrescarreporte();
            }

        }
        private DataTable obtenermontos()
        {
            DataTable dt2 = new DataTable();
            dt2 = sn.reportetable(fechainicio.Value, fechafin.Value, combotiposervicio.SelectedValue, comboestadosemaforo.SelectedValue,
                combodescripcionestado.SelectedValue, combotipodomicilio.SelectedValue, combofinalidadservicio.SelectedValue, txtingresos.Text,
                txtmonto.Text, combotrabajoactual.SelectedValue, combocuentaigss.SelectedValue, combocuentacooperativa.SelectedValue,
                txtañodomicilios.Text, txttipodecontacto.Text, comboagencia.SelectedValue, combousuario.SelectedValue);
            return dt2;
        }

        public void refrescarreporte()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("ReporteDataSet", obtenermontos());
            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.ReportPath = "Views/CRM-SISTEMA/Reporteria/ReporteCRM.rdlc";
            ReportViewer1.LocalReport.Refresh();

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }

        protected void chktiposervicio_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            if (chktiposervicio.Checked == true)
            {
                combotiposervicio.Visible = true;
            }
            else
            {
                combotiposervicio.ClearSelection();
                combotiposervicio.Visible = false;


            }
        }
        protected void chkestadosemaforo_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            if (chkestadosemaforo.Checked == true)
            {
                comboestadosemaforo.Visible = true;
            }
            else
            {
                comboestadosemaforo.ClearSelection();
                comboestadosemaforo.Visible = false;

            }
        }
        protected void chkdescripcionsemaforo_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            if (chkdescripcionsemaforo.Checked == true)
            {
                comboestadosemaforo.Visible = true;
                combodescripcionestado.Visible = true;
            }
            else
            {
                combodescripcionestado.ClearSelection();
                comboestadosemaforo.Visible = false;
                combodescripcionestado.Visible = false;
            }
        }
        protected void chktipodomicilio_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            if (chktipodomicilio.Checked == true)
            {
                combotipodomicilio.Visible = true;
            }
            else
            {
                combotipodomicilio.ClearSelection();
                combotipodomicilio.Visible = false;
            }
        }
        protected void chkfinalidadservicio_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkfinalidadservicio.Checked == true)
            {
                combofinalidadservicio.Visible = true;
            }
            else
            {
                combofinalidadservicio.ClearSelection();
                combofinalidadservicio.Visible = false;
            }
        }
        protected void chkingresos_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkingresos.Checked == true)
            {
                txtingresos.Visible = true;
            }
            else
            {
                txtingresos.Text = "";
                txtingresos.Visible = false;
            }
        }
        protected void chkmonto_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkmonto.Checked == true)
            {
                txtmonto.Visible = true;
            }
            else
            {
                txtmonto.Text = "";
                txtmonto.Visible = false;
            }
        }
        protected void chktrabajoactual_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chktrabajoactual.Checked == true)
            {
                combotrabajoactual.Visible = true;
            }
            else
            {
                combotrabajoactual.ClearSelection();
                combotrabajoactual.Visible = false;
            }
        }
        protected void chkcuentaconigss_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkcuentaconigss.Checked == true)
            {
                combocuentaigss.Visible = true;
            }
            else
            {
                combocuentaigss.ClearSelection();
                combocuentaigss.Visible = false;
            }
        }
        protected void chkcuentaencooperativa_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkcuentaencooperativa.Checked == true)
            {
                combocuentacooperativa.Visible = true;
            }
            else
            {
                combocuentacooperativa.ClearSelection();
                combocuentacooperativa.Visible = false;
            }
        }
        protected void chkañosdomicilio_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkañosdomicilio.Checked == true)
            {
                txtañodomicilios.Visible = true;
            }
            else
            {
                txtañodomicilios.Text = "";
                txtañodomicilios.Visible = false;
            }
        }
        protected void chktipocontacto_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chktipocontacto.Checked == true)
            {
                txttipodecontacto.Visible = true;
            }
            else
            {
                txttipodecontacto.Text = "";
                txttipodecontacto.Visible = false;
            }
        }
        protected void chkporagencia_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkporagencia.Checked == true)
            {
                comboagencia.Visible = true;
            }
            else
            {
                comboagencia.ClearSelection();
                comboagencia.Visible = false;
            }
        }
        protected void chkporusuario_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();

            if (chkporusuario.Checked == true)
            {

                if (chkporagencia.Checked == true)
                {
                    combousuario.ClearSelection();
                    llenarcombousuarioporagencia(comboagencia.SelectedValue);
                    combousuario.Visible = true;
                }
                else
                {
                    combousuario.Visible = true;
                }
            }
            else
            {
                combousuario.ClearSelection();
                combousuario.Visible = false;
            }
        }

        public void llenarcombotiposervicio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmtipo_servicio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tiposervicio");
                    combotiposervicio.DataSource = ds;
                    combotiposervicio.DataTextField = "crmtipo_servicionombre";
                    combotiposervicio.DataValueField = "codcrmtiposervicio";
                    combotiposervicio.DataBind();
                    combotiposervicio.Items.Insert(0, new ListItem("[Tipo de servicio]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombofinalidadservicio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_finalidadservicio";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "finalidadservicio");
                    combofinalidadservicio.DataSource = ds;
                    combofinalidadservicio.DataTextField = "crm_finalidaddescripcion";
                    combofinalidadservicio.DataValueField = "codcrmfinalidadservicio";
                    combofinalidadservicio.DataBind();
                    combofinalidadservicio.Items.Insert(0, new ListItem("[Seleccione la finalidad del servicio]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarsemaforo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmsemaforo_estado;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "semaforo");
                    comboestadosemaforo.DataSource = ds;
                    comboestadosemaforo.DataTextField = "crmsemaforo_estadodescripcion";
                    comboestadosemaforo.DataValueField = "codcrmsemaforoestado";
                    comboestadosemaforo.DataBind();
                    comboestadosemaforo.Items.Insert(0, new ListItem("[Seleccione el estado]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombosemaforodescripcion(long codestadosemaforo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmestado_descripcion where codcrmsemaforoestado='" + codestadosemaforo + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "descripcionestado");
                    combodescripcionestado.DataSource = ds;
                    combodescripcionestado.DataTextField = "crmestado_descripcionnombre";
                    combodescripcionestado.DataValueField = "codcrmestadodescripcion";
                    combodescripcionestado.DataBind();
                    combodescripcionestado.Items.Insert(0, new ListItem("[Descripción estado]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombousuarioporagencia(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "Select * FROM crmcontrol_ingreso where crmcontrol_ingresosucursal='" + agencia + "' AND crmcontrol_ingresorol=3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agentesucursal");
                    combousuario.DataSource = ds;
                    combousuario.DataTextField = "crmcontrol_ingresousuario";
                    combousuario.DataValueField = "crmcontrol_ingresousuario";
                    combousuario.DataBind();
                    combousuario.Items.Insert(0, new ListItem("[Descripción estado]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenartipodomicilio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmtipo_domicilio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipodomicilio");
                    combotipodomicilio.DataSource = ds;
                    combotipodomicilio.DataTextField = "crmtipo_domicilionombre";
                    combotipodomicilio.DataValueField = "codcrmtipodomicilio";
                    combotipodomicilio.DataBind();
                    combotipodomicilio.Items.Insert(0, new ListItem("[Tipo de domicilio]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "Select * FROM crm_genagencias;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agencias");
                    comboagencia.DataSource = ds;
                    comboagencia.DataTextField = "crm_genagenciasnombre";
                    comboagencia.DataValueField = "crm_genagenciasnombre";
                    comboagencia.DataBind();
                    comboagencia.Items.Insert(0, new ListItem("[Seleccione la agencia]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboagente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "Select * FROM crmcontrol_ingreso where crmcontrol_ingresorol=3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agente");
                    combousuario.DataSource = ds;
                    combousuario.DataTextField = "crmcontrol_ingresousuario";
                    combousuario.DataValueField = "crmcontrol_ingresousuario";
                    combousuario.DataBind();
                    combousuario.Items.Insert(0, new ListItem("[Seleccione el usuario]", ""));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void seleccionsemaforo_SelectedIndexChanged(object sender, EventArgs e)
        {

            llenarcombosemaforodescripcion(long.Parse(comboestadosemaforo.SelectedValue));
        }





    }
}