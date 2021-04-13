using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Asesores
{
    public partial class CRM_Crearreferido : System.Web.UI.Page
    {
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        string nombreusuario;
        string registrodpiremplazable;
        string dpiguardar="";
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 3 || rolusuario == 6)
            {

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                llenarcombotiposervicio();
                llenarcontactollamada();
                llenarsemaforo();
                llenartipodomicilio();
                // llenarsucursalmascercana();
            }
        }
        public void llenarcontactollamada()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmcontacto_llamadas;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "contactollaamada");
                    combocontactollamadas.DataSource = ds;
                    combocontactollamadas.DataTextField = "crmcontacto_llamadasnombre";
                    combocontactollamadas.DataValueField = "codcrmcontactollamadas";
                    combocontactollamadas.DataBind();
                    combocontactollamadas.Items.Insert(0, new ListItem("[Estado de la llamada]", "0"));
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
                    combosemaforoestado.DataSource = ds;
                    combosemaforoestado.DataTextField = "crmsemaforo_estadonombre";
                    combosemaforoestado.DataValueField = "codcrmsemaforoestado";
                    combosemaforoestado.DataBind();
                    combosemaforoestado.Items.Insert(0, new ListItem("[Seleccione el color]", "0"));
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
                    combotipodomicilio.Items.Insert(0, new ListItem("[Tipo de domicilio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarsucursalmascercana()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_area;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "sucursal");
                    combosucursalmascerca.DataSource = ds;
                    combosucursalmascerca.DataTextField = "gen_areanombre";
                    combosucursalmascerca.DataValueField = "codgenarea";
                    combosucursalmascerca.DataBind();
                    combosucursalmascerca.Items.Insert(0, new ListItem("[¿Sucrusal más cercana?]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
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
                    myCommand.Fill(ds, "tiposervicio125");
                    combotiposervicio.DataSource = ds;
                    combotiposervicio.DataTextField = "crmtipo_servicionombre";
                    combotiposervicio.DataValueField = "codcrmtiposervicio";
                    combotiposervicio.DataBind();
                    combotiposervicio.Items.Insert(0, new ListItem("[Tipo de servicio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombofinalidadservicio(long codtiposervicio)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_finalidadservicio where codcrmtiposervicio='" + codtiposervicio + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "finalidadservicio");
                    combofinalidaddeservicio.DataSource = ds;
                    combofinalidaddeservicio.DataTextField = "crm_finalidaddescripcion";
                    combofinalidaddeservicio.DataValueField = "codcrmfinalidadservicio";
                    combofinalidaddeservicio.DataBind();
                    combofinalidaddeservicio.Items.Insert(0, new ListItem("[Seleccione la finalidad del servicio]", "0"));
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
                    combosemaforodescripcion.DataSource = ds;
                    combosemaforodescripcion.DataTextField = "crmestado_descripcionnombre";
                    combosemaforodescripcion.DataValueField = "codcrmestadodescripcion";
                    combosemaforodescripcion.DataBind();
                    combosemaforodescripcion.Items.Insert(0, new ListItem("[Motivo del estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void tiposervicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombofinalidadservicio(long.Parse(combotiposervicio.SelectedValue));
            combocuentaigss.Focus();
        }
        protected void seleccionsemaforo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(combosemaforoestado.SelectedValue);
            switch (num)
            {
                case 0:
                    txtcolorestado.BackColor = Color.Gray;
                    break;
                case 1:
                    //verde
                    txtcolorestado.BackColor = Color.Green;
                    break;
                case 2:
                    //amarillo
                    txtcolorestado.BackColor = Color.Yellow;
                    break;
                case 3:
                    //naranja
                    txtcolorestado.BackColor = Color.Orange;
                    break;
                case 4:
                    //rojo
                    txtcolorestado.BackColor = Color.Red;
                    break;

            }
            exampleFormControlTextarea1.Focus();

            llenarcombosemaforodescripcion(long.Parse(combosemaforoestado.SelectedValue));
            SetFocus(exampleFormControlTextarea1);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (comprobardpiexistente(txtnumerodpi.Value))  //DPI EXISTENTE 
            {
                // Response.Write("el nuevo" + registrodpiremplazable);
                string[] regdpiguardado = sn.consultarconcampo("crminfogeneral_prospecto", "crminfogeneral_prospectodpi", registrodpiremplazable);
                dpiguardar = regdpiguardado[0];
            }
            else
            {
                string sig1 = logic.siguiente("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                string[] valores2 = { sig1, txtnumerodpi.Value, "", "", txtnombrecompleto.Value, "0" };
                logic.insertartablas("crminfogeneral_prospecto", valores2);
                dpiguardar = sig1;


            }
            //INSERTAR DATOS
            string sig = logic.siguiente("crminfo_prospecto", "codcrminfoprospecto");
            string[] valores1 = { sig, dpiguardar, combotiposervicio.SelectedValue, "1", "1",
                        "1","1","1",txttelefono.Value,txtemail.Value,txtingreso.Value,txtegresos.Value,txtmonto.Value,txtañoslaborados.Value,combotienetrabajo.SelectedValue,txttabajoactual.Value,txtfechainicio.Value,txtfechafin.Value,exampleFormControlTextarea1.Value,combosucursalmascerca.SelectedValue,
                        combocuentaigss.SelectedValue,txtañodomicilio.Value,comboposeecuentacoope.SelectedValue,"Referenciado",txtdpidereferido.Value};
            logic.insertartablas("crminfo_prospecto", valores1);
            logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Aplicación Asesores", "Creación del referido - Correlativo: '"+txtnumerodpi.Value+"'");
            string sig3 = logic.siguiente("crmcontrol_prospecto_agente", "codcrmcontrolprospectoagente");
            string[] var4 = sn.fechaactual();
           DateTime fechaactual = Convert.ToDateTime(var4[0]);
           string[] agenteacargo = sn.consultarcontrolingreso(nombreusuario);
            string[] valores3 = { sig3, sig, agenteacargo[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
            logic.insertartablas("crmcontrol_prospecto_agente", valores3);
        }
        public bool comprobardpiexistente(string dpiacomprobar)
        {
            string[] var2 = sn.consultardpiexistente();

            int cont = 0;
            while (cont != var2.Length)
            {
                string dpiextraido = Convert.ToString(var2[cont]);

                if (dpiacomprobar != dpiextraido)
                {
                    cont = cont + 1;

                }
                else
                {
                    registrodpiremplazable = dpiacomprobar;

                    return true;
                }

            }
            return false;
        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }

    }
}