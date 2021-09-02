using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.CRM_SISTEMA.Administracion.Reasignaciones
{
    public partial class Asignacionporlead : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        string Nombresesion;
        string sucurusalcrm;
        string usuariodelcrm;
        string roldelcrm;
        string controlingresocrm;
        int centinela1 = 0;
        int centinela2 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Nombresesion = Session["sesion_usuario"].ToString();
            obtenciondeinformacion();
            Session["controlingreso"] = controlingresocrm;
            Session["usuariodelcrm"] = usuariodelcrm;
            Session["sucurusalcrm"] = sucurusalcrm;
            Session["roldelcrm"] = roldelcrm;
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (!IsPostBack)
            {
                if (roldelcrm == "7" || roldelcrm == "6" || roldelcrm == "2")
                {

                    switch (rolusuario)
                    {
                        case 7:
                            //Ingreso para coordinador de agencia
                            llenarcomboaplicacion();
                            break;
                        case 6:
                            //Ingreso para superusuario
                            llenarcomboaplicacion();
                            break;
                        case 2:
                            //Ingreso para jefes
                            llenarcomboaplicacion();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    String script = "alert('El usuario  no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../../../Index.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                }
            }

        }
        protected void obtenciondeinformacion()
        {
            string[] var1 = sn.consultarconcampo("crmcontrol_ingreso", "crmcontrol_ingresousuario", Nombresesion);
            controlingresocrm = var1[0];
            sucurusalcrm = var1[1];
            usuariodelcrm = var1[2];
            roldelcrm = var1[3];
        }
        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            String script = "window.location.href= 'Reasignar_prospecto.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

        }
        protected void SUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnaceptar_Click(object sender, EventArgs e)
        {

            string[] dato = sn.consultarconcampo("crminfo_prospecto", "codcrminfoprospecto", txtnumerolead.Text);
            if (txtnumerolead.Text == "" || dato.Length == 0)
            {


                lblaceptar.Visible = false;
                lblerror.Visible = true;
                lblerror.Text = "EL NÚMERO DE LEAD QUE ESTA INGRESANDO NO EXISTE";
            }
            else
            {
                if (comboagenciadar.SelectedValue == "" || comboagente.SelectedValue == "" || comboagenciadar.SelectedValue == "0" || comboagente.SelectedValue == "0" || txtnumerolead.Text == "")
                {
                    lblaceptar.Visible = false;
                    lblerror.Visible = true;
                    txtnumerolead.Text = "";
                    lblerror.Text = "VERIFIQUE QUE TODOS LOS CAMPOS SE ENCUENTREN LLENOS";
                }
                else
                {

                    string[] buscadordelead = sn.consultarleadsquenosondemercadeo(txtnumerolead.Text);
                    int longitud = buscadordelead.Length;
                    if (roldelcrm == "7")
                    {
                        if (longitud != 0)
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "NO PUEDE REASIGNAR LEADS DE TELEMERCADEO";
                            txtnumerolead.Text = "";

                        }
                        else
                        {
                            string[] campos = { "codcrminfoprospecto", "codcrmcontrolingreso" };
                            string[] valores = { txtnumerolead.Text, comboagente.SelectedValue };
                            try
                            {
                                sn.modificartablas("crmcontrol_prospecto_agente", campos, valores);
                                logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasginación de leads", "Modificación en el registro" + txtnumerolead.Text);
                            }
                            catch (Exception err)
                            {
                                lblaceptar.Visible = false;
                                lblerror.Visible = true;
                                txtnumerolead.Text = "";
                                lblerror.Text = "SUCEDIO UN ERROR COMUNICARSE CON EL DEPARTAMENTO DE INFORMÁTICA";
                            }
                            lblaceptar.Visible = true;
                            lblerror.Visible = false;
                            txtnumerolead.Text = "";
                            lblaceptar.Text = "OPERACIÓN REALIZADA";

                        }

                    }
                    else
                    {
                        string[] campos = { "codcrminfoprospecto", "codcrmcontrolingreso" };
                        string[] valores = { txtnumerolead.Text, comboagente.SelectedValue };
                        try
                        {
                            sn.modificartablas("crmcontrol_prospecto_agente", campos, valores);
                            logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasginación de leads", "Modificación en el registro" + txtnumerolead.Text);
                        }
                        catch (Exception err)
                        {
                            lblaceptar.Visible = false;
                            lblerror.Visible = true;
                            txtnumerolead.Text = "";
                            lblerror.Text = "SUCEDIO UN ERROR COMUNICARSE CON EL DEPARTAMENTO DE INFORMÁTICA";
                        }
                        lblaceptar.Visible = true;
                        lblerror.Visible = false;
                        txtnumerolead.Text = "";
                        lblaceptar.Text = "OPERACIÓN REALIZADA";
                    }
                }
            }


        }
        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT DISTINCT crmcontrol_ingresosucursal FROM crmcontrol_ingreso where crmcontrol_ingresorol =3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Aplicacion");
                    comboagenciadar.DataSource = ds;
                    comboagenciadar.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataBind();
                    comboagenciadar.Items.Insert(0, new ListItem("[Seleccione la Agencia]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void comboagenciaagentedar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roldelcrm == "7")
            {
                comboagenciaagentedar_SelectedIndexChanged(comboagenciadar.SelectedValue);
            }
            else
            {
                comboagenciaagentemercadeodar_SelectedIndexChanged(comboagenciadar.SelectedValue);
            }
        }
        public void comboagenciaagentedar_SelectedIndexChanged(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT crmcontrol_ingresousuario,codcrmcontrolingreso FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "' AND  crmcontrol_ingresosucursal!='TELEMERCADEO' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia2");
                    comboagente.DataSource = ds;
                    comboagente.DataTextField = "crmcontrol_ingresousuario";
                    comboagente.DataValueField = "codcrmcontrolingreso";
                    comboagente.DataBind();
                    comboagente.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void comboagenciaagentemercadeodar_SelectedIndexChanged(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT crmcontrol_ingresousuario,codcrmcontrolingreso FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia2");
                    comboagente.DataSource = ds;
                    comboagente.DataTextField = "crmcontrol_ingresousuario";
                    comboagente.DataValueField = "codcrmcontrolingreso";
                    comboagente.DataBind();
                    comboagente.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
    }
}