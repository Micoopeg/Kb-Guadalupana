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

namespace KB_Guadalupana.Views.MantenimientosControl
{
    public partial class controlCRM : System.Web.UI.Page
    {
        string nombreusuario;
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        protected void Page_Load(object sender, EventArgs e)
        {

            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            llenargridviewmantenimiento();
            if (!IsPostBack)
            {
                string varinc = sn.obtenerfinal("crmcontrol_ingreso", "codcrmcontrolingreso");
                txtcodigo.Value = varinc;
                btnmodificar.Visible = false;
                btnnuevoingreso.Visible = false;
                llenaragencias();
                llenarusuario();

            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Seguridad/Seguridad1.aspx");
        }
        public void llenaragencias()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_genagencias;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Agencias");
                    comboagencia.DataSource = ds;
                    comboagencia.DataTextField = "crm_genagenciasnombre";
                    comboagencia.DataValueField = "crm_genagenciasnombre";
                    comboagencia.DataBind();
                    comboagencia.Items.Insert(0, new ListItem("[Agencia", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarusuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_usuario;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuarios");
                    combousuario.DataSource = ds;
                    combousuario.DataTextField = "gen_usuarionombre";
                    combousuario.DataValueField = "gen_usuarionombre";
                    combousuario.DataBind();
                    combousuario.Items.Insert(0, new ListItem("[Usuario", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenargridviewmantenimiento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM crmcontrol_ingreso;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewmant.DataSource = ds3;
                    gridviewmant.DataBind();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }
        protected void OnSelectedIndexChangedmantenimiento(object sender, EventArgs e)
        {

            GridViewRow row = gridviewmant.SelectedRow;
            txtcodigo.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblcodigousuario") as Label).Text);
            comboagencia.SelectedValue = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblagencia") as Label).Text);
            combousuario.SelectedValue = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblusuario") as Label).Text);
            comboroles.SelectedValue = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblrol") as Label).Text);
            btnguardar.Visible = false;
            btnnuevoingreso.Visible = true;
            btnmodificar.Visible = true;
        }
        protected void gridviewmantenimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewmant.PageIndex = e.NewPageIndex;
            llenargridviewmantenimiento();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Value == "" || comboagencia.SelectedValue == "0" || combousuario.SelectedValue == "0" || comboroles.SelectedValue == "0")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string var1 = sn.validarusuariocrm("crmcontrol_ingreso", "crmcontrol_ingresousuario", combousuario.SelectedValue);
                if (var1.Length == 0)
                {

                    string[] valores = { txtcodigo.Value, comboagencia.SelectedValue, combousuario.SelectedValue, comboroles.SelectedValue };
                    try
                    {
                        logic.insertartablas("crmcontrol_ingreso", valores);
                        comboagencia.ClearSelection();
                        combousuario.ClearSelection();
                        comboroles.ClearSelection();
                        string varinc = sn.obtenerfinal("crmcontrol_ingreso", "codcrmcontrolingreso");
                        txtcodigo.Value = varinc;
                        llenargridviewmantenimiento();
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Control de usuario", "Registro guardado");
                    }
                    catch
                    {
                        Console.WriteLine("dejo de funcionar");
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Control de usuario", "Intento guardadar");
                    }

                }
                else
                {

                    if (combousuario.SelectedValue == var1)
                    {
                        String script = "alert('El usuario que desea asignar ya se encuentra asignado');";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else
                    {
                        String script = "alert('El usuario que desea asignar ya se encuentra asignado');";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                }

            }

        }
        protected void btnnuevoingreso_Click(object sender, EventArgs e)
        {

            txtcodigo.Value = "";
            comboagencia.ClearSelection();
            combousuario.ClearSelection();
            comboroles.ClearSelection();
            btnmodificar.Visible = false;
            btnguardar.Visible = true;
            string varinc = sn.obtenerfinal("crmcontrol_ingreso", "codcrmcontrolingreso");
            txtcodigo.Value = varinc;
            btnnuevoingreso.Visible = false;
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Value == "" || comboagencia.SelectedValue == "0" || combousuario.SelectedValue == "0" || comboroles.SelectedValue == "0")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] campos1 = { "codcrmcontrolingreso", "crmcontrol_ingresosucursal", "crmcontrol_ingresousuario", "crmcontrol_ingresorol" };
                string[] valores1 = { txtcodigo.Value, comboagencia.SelectedValue, combousuario.SelectedValue, comboroles.SelectedValue };
                try
                {
                    logic.modificartablas("crmcontrol_ingreso", campos1, valores1);
                    comboagencia.ClearSelection();
                    combousuario.ClearSelection();
                    comboroles.ClearSelection();
                    string varinc = sn.obtenerfinal("crmcontrol_ingreso", "codcrmcontrolingreso");
                    txtcodigo.Value = varinc;
                    llenargridviewmantenimiento();
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Control usuario", "Registro Modificado - Correlativo:'" + txtcodigo.Value + "'");

                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Control usuario", "Intento Modificar - Correlativo:'" + txtcodigo.Value + "'");
                }
            }
        }
        public void llenargridviewmantenimientobusqueda(string filtro)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM crmcontrol_ingreso WHERE crmcontrol_ingresousuario LIKE '%" + filtro + "%' ;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewmant.DataSource = ds3;
                    gridviewmant.DataBind();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }
        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            llenargridviewmantenimientobusqueda(txtbusqueda.Value);
        }
    }
}