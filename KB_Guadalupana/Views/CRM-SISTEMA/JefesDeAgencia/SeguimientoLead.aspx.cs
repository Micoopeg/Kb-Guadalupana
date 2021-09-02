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

namespace KB_Guadalupana.Views.CRM_SISTEMA.JefesDeAgencia
{

    public partial class SeguimientoLead : System.Web.UI.Page
    {
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        string nombreusuario;
        string codigodelead;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            codigodelead = Convert.ToString(Session["CodLead"]);
            if (rolusuario == 5 || rolusuario == 6)
            {

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }

            if (!IsPostBack)
            {
                llenarcombotiposervicio();
                llenarcontactollamada();
                llenarsemaforo();
                llenartipodomicilio();
                llenarsucursalmascercana();




                string[] var2 = sn.consultaparaseguimientoleads(codigodelead);
                txtnumerogeneral.Value = var2[0];
                txtnumeroderegistro.Value = var2[1];
                txtnumerodpi.Value = var2[2];
                txtnombrecompleto.Value = var2[3];
                txttelefono.Value = var2[4];
                txtemail.Value = var2[5];
                txtingreso.Value = var2[6];
                txtegresos.Value = var2[7];
                txtañoslaborados.Value = var2[8];
                combotienetrabajo.SelectedValue = var2[9];
                txttabajoactual.Value = var2[10];
                combotiposervicio.SelectedValue = var2[11];
                llenarcombofinalidadservicio(long.Parse(combotiposervicio.SelectedValue));
                txtmonto.Value = var2[12];
                combofinalidaddeservicio.Value = var2[13];
                combocontactollamadas.SelectedValue = var2[14];


                var fecha = Convert.ToDateTime(var2[15]);
                string fecha1 = fecha.ToString("yyyy-MM-dd");
                txtfechainicio.Value = fecha1;

                var fecha2 = Convert.ToDateTime(var2[16]);
                string fecha3 = fecha2.ToString("yyyy-MM-dd");
                txtfechafin.Value = fecha3;

                combosemaforoestado.SelectedValue = var2[17];
                llenarcombosemaforodescripcion(long.Parse(combosemaforoestado.SelectedValue));
                combosemaforodescripcion.SelectedValue = var2[18];
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
                combocuentaigss.SelectedValue = var2[19];
                combotipodomicilio.SelectedValue = var2[20];
                txtañodomicilio.Value = var2[21];
                comboposeecuentacoope.SelectedValue = var2[22];
                combosucursalmascerca.SelectedValue = var2[23];
                exampleFormControlTextarea1.Value = var2[24];
                txtcontactadopor.Value = var2[25];
                txtdpireferencia.Value = var2[26];

            }
        }



        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Catalogo_clientes/Prospectoenprocesos.aspx");
        }


        protected void btnmenucerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Sesion/MenuBarra.aspx");
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
                    combotiposervicio.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
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
                    combocontactollamadas.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
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
                    combosemaforoestado.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
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
                    combotipodomicilio.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
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
                    string QueryString = "Select * FROM crm_genagencias where crm_genagenciasnombre !='telemercadeo';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "sucursal");
                    combosucursalmascerca.DataSource = ds;
                    combosucursalmascerca.DataTextField = "crm_genagenciasnombre";
                    combosucursalmascerca.DataValueField = "codcrmgenagencias";
                    combosucursalmascerca.DataBind();
                    combosucursalmascerca.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
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
                    txtnumerodpi.Visible = true;
                    txtnombrecompleto.Visible = true;
                    txttelefono.Visible = true;
                    txtemail.Visible = true;
                    txtmonto.Visible = true;
                    txtingreso.Visible = true;
                    txtegresos.Visible = true;
                    txtañoslaborados.Visible = true;
                    combotienetrabajo.Visible = true;
                    txttabajoactual.Visible = true;
                    combocuentaigss.Visible = true;
                    combotiposervicio.Visible = true;
                    combofinalidaddeservicio.Visible = true;
                    combocontactollamadas.Visible = true;
                    txtfechainicio.Visible = true;
                    txtfechafin.Visible = true;
                    combotipodomicilio.Visible = true;
                    txtañodomicilio.Visible = true;
                    comboposeecuentacoope.Visible = true;
                    combosucursalmascerca.Visible = true;
                    txtcontactadopor.Visible = true;
                    txtdpireferencia.Visible = true;
                    exampleFormControlTextarea1.Visible = true;
                    break;
                case 1:
                    //verde
                    txtcolorestado.BackColor = Color.Green;
                    txtnumerodpi.Visible = true;
                    txtnombrecompleto.Visible = true;
                    txttelefono.Visible = true;
                    txtemail.Visible = true;
                    txtmonto.Visible = true;
                    txtingreso.Visible = true;
                    txtegresos.Visible = true;
                    txtañoslaborados.Visible = true;
                    combotienetrabajo.Visible = true;
                    txttabajoactual.Visible = true;
                    combocuentaigss.Visible = true;
                    combotiposervicio.Visible = true;
                    combofinalidaddeservicio.Visible = true;
                    combocontactollamadas.Visible = true;
                    txtfechainicio.Visible = true;
                    txtfechafin.Visible = true;
                    combotipodomicilio.Visible = true;
                    txtañodomicilio.Visible = true;
                    comboposeecuentacoope.Visible = true;
                    combosucursalmascerca.Visible = true;
                    txtcontactadopor.Visible = true;
                    txtdpireferencia.Visible = true;
                    exampleFormControlTextarea1.Visible = true;
                    break;
                case 2:
                    //amarillo
                    txtcolorestado.BackColor = Color.Yellow;
                    txtnumerodpi.Visible = true;
                    txtnombrecompleto.Visible = true;
                    txttelefono.Visible = true;
                    txtemail.Visible = true;
                    txtmonto.Visible = true;
                    txtingreso.Visible = true;
                    txtegresos.Visible = true;
                    txtañoslaborados.Visible = true;
                    combotienetrabajo.Visible = true;
                    txttabajoactual.Visible = true;
                    combocuentaigss.Visible = true;
                    combotiposervicio.Visible = true;
                    combofinalidaddeservicio.Visible = true;
                    combocontactollamadas.Visible = true;
                    txtfechainicio.Visible = true;
                    txtfechafin.Visible = true;
                    combotipodomicilio.Visible = true;
                    txtañodomicilio.Visible = true;
                    comboposeecuentacoope.Visible = true;
                    combosucursalmascerca.Visible = true;
                    txtcontactadopor.Visible = true;
                    txtdpireferencia.Visible = true;
                    exampleFormControlTextarea1.Visible = true;
                    break;
                case 3:
                    //naranja
                    txtcolorestado.BackColor = Color.Orange;
                    txtnumerodpi.Visible = true;
                    txtnombrecompleto.Visible = true;
                    txttelefono.Visible = true;
                    txtemail.Visible = true;
                    txtmonto.Visible = true;
                    txtingreso.Visible = true;
                    txtegresos.Visible = true;
                    txtañoslaborados.Visible = true;
                    combotienetrabajo.Visible = true;
                    txttabajoactual.Visible = true;
                    combocuentaigss.Visible = true;
                    combotiposervicio.Visible = true;
                    combofinalidaddeservicio.Visible = true;
                    combocontactollamadas.Visible = true;
                    txtfechainicio.Visible = true;
                    txtfechafin.Visible = true;
                    combotipodomicilio.Visible = true;
                    txtañodomicilio.Visible = true;
                    comboposeecuentacoope.Visible = true;
                    combosucursalmascerca.Visible = true;
                    txtcontactadopor.Visible = true;
                    txtdpireferencia.Visible = true;
                    exampleFormControlTextarea1.Visible = true;
                    break;
                case 4:
                    //rojo
                    if (txtnumerodpi.Value == "")
                    {

                        String script = "alert('Antes de seleccionar este estado debe haber elegido un Lead'); window.location.href= 'CRM_Asesores.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else
                    {

                        //rojo
                        txtcolorestado.BackColor = Color.Red;
                        txtnumerodpi.Visible = false;
                        txtnombrecompleto.Visible = false;
                        txttelefono.Visible = false;
                        txtemail.Visible = false;
                        txtmonto.Visible = false;
                        txtingreso.Visible = false;
                        txtegresos.Visible = false;
                        txtañoslaborados.Visible = false;
                        combotienetrabajo.Visible = false;
                        txttabajoactual.Visible = false;
                        combocuentaigss.Visible = false;
                        combotiposervicio.Visible = false;
                        combofinalidaddeservicio.Visible = false;
                        combocontactollamadas.Visible = false;
                        txtfechainicio.Visible = false;
                        txtfechafin.Visible = true;
                        combotipodomicilio.Visible = false;
                        txtañodomicilio.Visible = false;
                        comboposeecuentacoope.Visible = false;
                        combosucursalmascerca.Visible = false;
                        txtcontactadopor.Visible = false;
                        txtdpireferencia.Visible = false;
                        exampleFormControlTextarea1.Visible = false;
                    }
                    break;

            }
            exampleFormControlTextarea1.Focus();

            llenarcombosemaforodescripcion(long.Parse(combosemaforoestado.SelectedValue));
            SetFocus(exampleFormControlTextarea1);
        }

        protected void Btn_Guardarprospecto_Click(object sender, EventArgs e)
        {
            if (combosemaforoestado.SelectedValue == "4")
            {
                if (txtfechafin.Value == "" || combosemaforodescripcion.SelectedValue == "" || combosemaforodescripcion.SelectedValue == "")
                {
                    String script = "alert('Verifique que todos los campos se encuentren llenos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    string[] campos = { "codcrminfoprospecto", "codcrminfogeneralprospecto", "codcrmtiposervicio",
                    "codcrmcontactollamadas","codcrmsemaforoestado","codcrmestadodescripcion",
                    "codcrmtipodomicilio","codcrmfinalidadservicio","crminfo_prospectotelefono","crminfo_prospectoemail",
                    "crminfo_prospectoingresos","crminfo_prospectoegresos","crminfo_prospectomonto","crminfo_prospectoañoslaborados",
                    "crminfo_prospectotrabajaactualmente","crminfo_prospectodescripciontrabajoactual","crminfo_prospectofechaprimerllamada",
                    "crminfo_prospectofechaultimallamada","crminfo_prospectodescripcion","crminfo_prospectosucursalcerca","crminfo_prospectocuentaconigss",
                    "crminfo_prospectoañosdomicilio","crminfo_prospectocuentaencooperativa","crminfo_prospectoreferenciado"};
                    string[] valores = {txtnumerogeneral.Value,txtnumeroderegistro.Value,combotiposervicio.SelectedValue,
                    combocontactollamadas.SelectedValue,combosemaforoestado.SelectedValue,combosemaforodescripcion.SelectedValue,
                    combotipodomicilio.SelectedValue,combofinalidaddeservicio.Value,txttelefono.Value,txtemail.Value,txtingreso.Value,txtegresos.Value,
                    txtmonto.Value,txtañoslaborados.Value,combotienetrabajo.SelectedValue,txttabajoactual.Value,txtfechainicio.Value,txtfechafin.Value,
                    exampleFormControlTextarea1.Value,combosucursalmascerca.SelectedValue,combocuentaigss.SelectedValue,
                    txtañodomicilio.Value,comboposeecuentacoope.SelectedValue,txtdpireferencia.Value };

                    string[] campos1 = { "codcrminfogeneralprospecto", "crminfogeneral_prospectodpi", "crminfogeneral_prospectonombrecompleto" };
                    string[] valores1 = { txtnumeroderegistro.Value, txtnumerodpi.Value, txtnombrecompleto.Value };
                    try
                    {
                        logic.modificartablas("crminfo_prospecto", campos, valores);
                        logic.modificartablas("crminfogeneral_prospecto", campos1, valores1);
                        logic.bitacoraingresoprocedimientos("usuario", "CRM", "Aplicación Asesores", "Modificado de un prospecto - Correlativo : '" + txtnumerodpi.Value + "'");
                    }
                    catch
                    {
                        Console.WriteLine("dejo de funcionar");
                    }
                    txtnumerogeneral.Value = "";
                    txtnumeroderegistro.Value = ""; combotiposervicio.SelectedValue = "0";
                    combocontactollamadas.SelectedValue = "0";
                    combosemaforoestado.SelectedValue = "0";
                    combosemaforodescripcion.SelectedValue = "0";
                    combotipodomicilio.SelectedValue = "0";
                    combofinalidaddeservicio.Value = "0";
                    txttelefono.Value = ""; txtemail.Value = "";
                    txtingreso.Value = "";
                    txtegresos.Value = "";
                    txtmonto.Value = "";
                    txtañoslaborados.Value = "";
                    combotienetrabajo.SelectedValue = "0";
                    txttabajoactual.Value = "0";
                    txtfechainicio.Value = ""; txtfechafin.Value = "";
                    exampleFormControlTextarea1.Value = "0";
                    combosucursalmascerca.SelectedValue = "0";
                    combocuentaigss.SelectedValue = "0";
                    combotipodomicilio.SelectedValue = "0";
                    comboposeecuentacoope.SelectedValue = "0";
                    txtnumeroderegistro.Value = "";
                    txtnumerodpi.Value = "";
                    txtnombrecompleto.Value = "";
                    txtañodomicilio.Value = "";
                    exampleFormControlTextarea1.Value = "";
                    txtcontactadopor.Value = "";
                    txtdpireferencia.Value = "";
                    Response.Redirect("SeguimientoLead.aspx");
                }
            }
            else
            {
                if (txtnumerodpi.Value == "" || txtnombrecompleto.Value == "" || txttelefono.Value == "" ||
              txtemail.Value == "" || txtingreso.Value == "" || txtegresos.Value == "" || txtañoslaborados.Value == "" || combotienetrabajo.SelectedValue == "0" ||
              txttelefono.Value == "" || combotiposervicio.SelectedValue == "0" || txtmonto.Value == "" || combofinalidaddeservicio.Value == "0" || combocontactollamadas.SelectedValue == "0" ||
              txtfechainicio.Value == "" || txtfechafin.Value == "" || combosemaforoestado.SelectedValue == "0" || combosemaforodescripcion.SelectedValue == "0" ||
              combocuentaigss.SelectedValue == "0" || combotipodomicilio.SelectedValue == "0" || txtañodomicilio.Value == "" || comboposeecuentacoope.SelectedValue == "0" ||
              combosucursalmascerca.SelectedValue == "0")
                {
                    String script = "alert('Verifique que todos los campos se encuentren llenos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    efectuarcambio();
                }
            }





        }
        public void efectuarcambio()
        {
            string[] campos = { "codcrminfoprospecto", "codcrminfogeneralprospecto", "codcrmtiposervicio",
                    "codcrmcontactollamadas","codcrmsemaforoestado","codcrmestadodescripcion",
                    "codcrmtipodomicilio","codcrmfinalidadservicio","crminfo_prospectotelefono","crminfo_prospectoemail",
                    "crminfo_prospectoingresos","crminfo_prospectoegresos","crminfo_prospectomonto","crminfo_prospectoañoslaborados",
                    "crminfo_prospectotrabajaactualmente","crminfo_prospectodescripciontrabajoactual","crminfo_prospectofechaprimerllamada",
                    "crminfo_prospectofechaultimallamada","crminfo_prospectodescripcion","crminfo_prospectosucursalcerca","crminfo_prospectocuentaconigss",
                    "crminfo_prospectoañosdomicilio","crminfo_prospectocuentaencooperativa","crminfo_prospectoreferenciado"};
            string[] valores = {txtnumerogeneral.Value,txtnumeroderegistro.Value,combotiposervicio.SelectedValue,
                    combocontactollamadas.SelectedValue,combosemaforoestado.SelectedValue,combosemaforodescripcion.SelectedValue,
                    combotipodomicilio.SelectedValue,combofinalidaddeservicio.Value,txttelefono.Value,txtemail.Value,txtingreso.Value,txtegresos.Value,
                    txtmonto.Value,txtañoslaborados.Value,combotienetrabajo.SelectedValue,txttabajoactual.Value,txtfechainicio.Value,txtfechafin.Value,
                    exampleFormControlTextarea1.Value,combosucursalmascerca.SelectedValue,combocuentaigss.SelectedValue,
                    txtañodomicilio.Value,comboposeecuentacoope.SelectedValue,txtdpireferencia.Value };

            string[] campos1 = { "codcrminfogeneralprospecto", "crminfogeneral_prospectodpi", "crminfogeneral_prospectonombrecompleto" };
            string[] valores1 = { txtnumeroderegistro.Value, txtnumerodpi.Value, txtnombrecompleto.Value };
            try
            {
                logic.modificartablas("crminfo_prospecto", campos, valores);
                logic.modificartablas("crminfogeneral_prospecto", campos1, valores1);
                logic.bitacoraingresoprocedimientos("usuario", "CRM", "Aplicación Asesores", "Modificado de un prospecto - Correlativo : '" + txtnumerodpi.Value + "'");
                String script = "window.location.href= '../Catalogo_clientes/Prospectoenprocesos.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            catch
            {
                Console.WriteLine("dejo de funcionar");
            }
            txtnumerogeneral.Value = "";
            txtnumeroderegistro.Value = ""; combotiposervicio.SelectedValue = "0";
            combocontactollamadas.SelectedValue = "0";
            combosemaforoestado.SelectedValue = "0";
            combosemaforodescripcion.SelectedValue = "0";
            combotipodomicilio.SelectedValue = "0";
            combofinalidaddeservicio.Value = "0";
            txttelefono.Value = ""; txtemail.Value = "";
            txtingreso.Value = "";
            txtegresos.Value = "";
            txtmonto.Value = "";
            txtañoslaborados.Value = "";
            combotienetrabajo.SelectedValue = "0";
            txttabajoactual.Value = "0";
            txtfechainicio.Value = ""; txtfechafin.Value = "";
            exampleFormControlTextarea1.Value = "0";
            combosucursalmascerca.SelectedValue = "0";
            combocuentaigss.SelectedValue = "0";
            combotipodomicilio.SelectedValue = "0";
            comboposeecuentacoope.SelectedValue = "0";
            txtnumeroderegistro.Value = "";
            txtnumerodpi.Value = "";
            txtnombrecompleto.Value = "";
            txtañodomicilio.Value = "";
            exampleFormControlTextarea1.Value = "";
            txtcontactadopor.Value = "";
            txtdpireferencia.Value = "";
        }
        public void efectuarcambio1()
        {
            string[] campos = { "codcrminfoprospecto", "codcrminfogeneralprospecto", "codcrmtiposervicio",
                    "codcrmcontactollamadas","codcrmsemaforoestado","codcrmestadodescripcion",
                    "codcrmtipodomicilio","codcrmfinalidadservicio","crminfo_prospectotelefono","crminfo_prospectoemail",
                    "crminfo_prospectoingresos","crminfo_prospectoegresos","crminfo_prospectomonto","crminfo_prospectoañoslaborados",
                    "crminfo_prospectotrabajaactualmente","crminfo_prospectodescripciontrabajoactual","crminfo_prospectofechaprimerllamada",
                    "crminfo_prospectofechaultimallamada","crminfo_prospectodescripcion","crminfo_prospectosucursalcerca","crminfo_prospectocuentaconigss",
                    "crminfo_prospectoañosdomicilio","crminfo_prospectocuentaencooperativa","crminfo_prospectoreferenciado"};
            string[] valores = {txtnumerogeneral.Value,txtnumeroderegistro.Value,"1",
                    "1",combosemaforoestado.SelectedValue,combosemaforodescripcion.SelectedValue,
                   "1","1",txttelefono.Value,txtemail.Value,txtingreso.Value,txtegresos.Value,
                    txtmonto.Value,txtañoslaborados.Value,"1",txttabajoactual.Value,"2020-01-01",txtfechafin.Value,
                    exampleFormControlTextarea1.Value,"0","0",
                    txtañodomicilio.Value,"0",txtdpireferencia.Value };
            try
            {
                logic.modificartablas("crminfo_prospecto", campos, valores);
                logic.bitacoraingresoprocedimientos("usuario", "CRM", "Aplicación Asesores", "Modificado de un prospecto - Correlativo : '" + txtnumerodpi.Value + "'");
                Response.Redirect("../Catalogo_clientes/Prospectoenprocesos.aspx");
                String script = "window.location.href= '../Catalogo_clientes/Prospectoenprocesos.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            catch
            {
                Console.WriteLine("dejo de funcionar");
            }
            txtnumerogeneral.Value = "";
            txtnumeroderegistro.Value = ""; combotiposervicio.SelectedValue = "0";
            combocontactollamadas.SelectedValue = "0";
            combosemaforoestado.SelectedValue = "0";
            combosemaforodescripcion.SelectedValue = "0";
            combotipodomicilio.SelectedValue = "0";
            combofinalidaddeservicio.Value = "0";
            txttelefono.Value = ""; txtemail.Value = "";
            txtingreso.Value = "";
            txtegresos.Value = "";
            txtmonto.Value = "";
            txtañoslaborados.Value = "";
            combotienetrabajo.SelectedValue = "0";
            txttabajoactual.Value = "0";
            txtfechainicio.Value = ""; txtfechafin.Value = "";
            exampleFormControlTextarea1.Value = "0";
            combosucursalmascerca.SelectedValue = "0";
            combocuentaigss.SelectedValue = "0";
            combotipodomicilio.SelectedValue = "0";
            comboposeecuentacoope.SelectedValue = "0";
            txtnumeroderegistro.Value = "";
            txtnumerodpi.Value = "";
            txtnombrecompleto.Value = "";
            txtañodomicilio.Value = "";
            exampleFormControlTextarea1.Value = "";
            txtcontactadopor.Value = "";
            txtdpireferencia.Value = "";
        }
        public void enviodecodigodelead()
        {

        }
    }
}