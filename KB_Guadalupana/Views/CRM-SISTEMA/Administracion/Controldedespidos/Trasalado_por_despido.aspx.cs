using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Controldedespidos
{

    public partial class Trasalado_por_despido : System.Web.UI.Page
    {
        string nombreusuario;
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        protected void Page_Load(object sender, EventArgs e)
        {

            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 4 || rolusuario == 6 || rolusuario == 2)
            {


            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                string varinc = sn.obtenerfinal("crm_finalidadservicio", "codcrmfinalidadservicio");
                llenaragenciafuente();
                llenaragenciadestino();
                llenarusuarioadministrativo();

                lblerror.Visible = false;
                lblusuarioadm.Visible = false;
                lblagenciafuente.Visible = false;
                lblagenciadestino.Visible = false;
                lblusuariofuente.Visible = false;
                lblusuariodestino.Visible = false;
                combousuarioadministrativo.Visible = false;
                comboagenciadestino.Visible = false;
                comboagenciafuente.Visible = false;
                combousuariodestino.Visible = false;
                combousuariofuente.Visible = false;
            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }
        public void llenaragenciafuente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_genagencias where crm_genagenciasestado=1;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciasdelcrm");
                    comboagenciafuente.DataSource = ds;
                    comboagenciafuente.DataTextField = "crm_genagenciasnombre";
                    comboagenciafuente.DataValueField = "crm_genagenciasnombre";
                    comboagenciafuente.DataBind();
                    comboagenciafuente.Items.Insert(0, new ListItem("[Agencia Fuente]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenaragenciadestino()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_genagencias where crm_genagenciasestado=1;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciasdelcrm");
                    comboagenciadestino.DataSource = ds;
                    comboagenciadestino.DataTextField = "crm_genagenciasnombre";
                    comboagenciadestino.DataValueField = "crm_genagenciasnombre";
                    comboagenciadestino.DataBind();
                    comboagenciadestino.Items.Insert(0, new ListItem("[Agencia Fuente]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarusuarioadministrativo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codcrmcontrolingreso,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol!=3";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuariosdelcrmactivos");
                    combousuarioadministrativo.DataSource = ds;
                    combousuarioadministrativo.DataTextField = "crmcontrol_ingresousuario";
                    combousuarioadministrativo.DataValueField = "codcrmcontrolingreso";
                    combousuarioadministrativo.DataBind();
                    combousuarioadministrativo.Items.Insert(0, new ListItem("[Seleccione el usuario]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void comboagenciafuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarasesorfuente(comboagenciafuente.SelectedValue);
        }
        protected void comboagenciadestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarasesordestino(comboagenciadestino.SelectedValue);
        }
        public void llenarasesorfuente(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codcrmcontrolingreso,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia133");
                    combousuariofuente.DataSource = ds;
                    combousuariofuente.DataTextField = "crmcontrol_ingresousuario";
                    combousuariofuente.DataValueField = "codcrmcontrolingreso";
                    combousuariofuente.DataBind();
                    combousuariofuente.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarasesordestino(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codcrmcontrolingreso,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia133");
                    combousuariodestino.DataSource = ds;
                    combousuariodestino.DataTextField = "crmcontrol_ingresousuario";
                    combousuariodestino.DataValueField = "codcrmcontrolingreso";
                    combousuariodestino.DataBind();
                    combousuariodestino.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (chkadministrativo.Checked == false && chkasesores.Checked == false)
            {
                lblerror.Text = "POR MOTIVOS DE SEGURIDAD SELECCIONE UNA OPCION AL MOMENTO DE HACER SU ELECCIÓN";
            }
            else if (chkadministrativo.Checked == true)
            {
                if (combousuarioadministrativo.SelectedValue == "0")
                {
                    String script = "alert('Verifique que todos los campos se encuentren llenos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    string[] valores = { combousuarioadministrativo.SelectedValue };
                    try
                    {
                        sn.despidocrm(combousuarioadministrativo.SelectedValue);
                        combousuarioadministrativo.ClearSelection();
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Traslado por despido", "Despido realizado hacia el usuario con codigo '" + combousuarioadministrativo.SelectedValue + "'");
                    }
                    catch
                    {
                        Console.WriteLine("dejo de funcionar");
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Traslado por despido", "Despido realizado hacia el usuario con codigo '" + combousuarioadministrativo.SelectedValue + "'");
                    }
                }
            }
            else if (chkasesores.Checked == true)
            {
                sn.trasladodeleadspordespido(comboagenciafuente.SelectedValue, comboagenciadestino.SelectedValue);
                sn.despidocrm(combousuariofuente.SelectedValue);
                comboagenciafuente.ClearSelection();
                comboagenciadestino.ClearSelection();
                combousuariofuente.ClearSelection();
                combousuariodestino.ClearSelection();
                logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Traslado por despido", "Despido realizado hacia el usuario con codigo '" + combousuariodestino.SelectedValue + "'");
            }
            else
            {
                lblerror.Text = "SE ENCONTRO UN ERROR DENTRO DEL APLICATIVO COMUNICARSE CON INFORMATICA";
            }
        }
        protected void chkadministrativo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkasesores.Checked == true)
            {
                lblerror.Visible = true;
                lblerror.Text = "Vuelva a seleccionar unicamente una opción";
                chkadministrativo.Checked = false;
                chkasesores.Checked = false;
                lblusuarioadm.Visible = false;
                lblagenciafuente.Visible = false;
                lblagenciadestino.Visible = false;
                lblusuariofuente.Visible = false;
                lblusuariodestino.Visible = false;
                combousuarioadministrativo.Visible = false;
                comboagenciadestino.Visible = false;
                comboagenciafuente.Visible = false;
                combousuariodestino.Visible = false;
                combousuariofuente.Visible = false;
            }
            else
            {
                lblerror.Visible = false;
                lblusuarioadm.Visible = true;
                lblagenciafuente.Visible = false;
                lblagenciadestino.Visible = false;
                lblusuariofuente.Visible = false;
                lblusuariodestino.Visible = false;
                comboagenciadestino.Visible = false;
                comboagenciafuente.Visible = false;
                combousuariodestino.Visible = false;
                combousuariofuente.Visible = false;
                combousuarioadministrativo.Visible = true;
            }

        }

        protected void chkasesores_CheckedChanged(object sender, EventArgs e)
        {
            if (chkadministrativo.Checked == true)
            {
                lblerror.Visible = true;
                lblerror.Text = "Vuelva a seleccionar unicamente una opción";
                chkadministrativo.Checked = false;
                chkasesores.Checked = false;
                lblusuarioadm.Visible = false;
                lblagenciafuente.Visible = false;
                lblagenciadestino.Visible = false;
                lblusuariofuente.Visible = false;
                lblusuariodestino.Visible = false;
                combousuarioadministrativo.Visible = false;
                comboagenciadestino.Visible = false;
                comboagenciafuente.Visible = false;
                combousuariodestino.Visible = false;
                combousuariofuente.Visible = false;
            }
            else
            {
                lblerror.Visible = false;
                lblusuarioadm.Visible = false;
                lblagenciafuente.Visible = true;
                lblagenciadestino.Visible = true;
                lblusuariofuente.Visible = true;
                lblusuariodestino.Visible = true;
                comboagenciadestino.Visible = true;
                comboagenciafuente.Visible = true;
                combousuariodestino.Visible = true;
                combousuariofuente.Visible = true;
                combousuarioadministrativo.Visible = false;
            }
        }
    }
}