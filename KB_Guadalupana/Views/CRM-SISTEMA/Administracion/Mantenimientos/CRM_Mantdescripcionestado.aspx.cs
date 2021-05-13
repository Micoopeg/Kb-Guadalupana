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

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Mantenimientos
{
    public partial class CRM_Mantdescripcionestado : System.Web.UI.Page
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
                llenargridviewmantenimiento();

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                string varinc = sn.obtenerfinal("crmestado_descripcion", "codcrmestadodescripcion");
                txtcodigo.Value = varinc;
                btnmodificar.Visible = false;
                btnnuevoingreso.Visible = false;
                lennarcomboestado();

            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }
        public void lennarcomboestado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmsemaforo_estado;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "comboestado");
                    comboestado.DataSource = ds;
                    comboestado.DataTextField = "crmsemaforo_estadodescripcion";
                    comboestado.DataValueField = "codcrmsemaforoestado";
                    comboestado.DataBind();
                    comboestado.Items.Insert(0, new ListItem("[Tipo de servicio]", "0"));
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
                    string QueryString = "SELECT a.codcrmestadodescripcion,a.codcrmsemaforoestado,b.crmsemaforo_estadodescripcion,a.crmestado_descripcionnombre FROM crmestado_descripcion a INNER JOIN crmsemaforo_estado b ON a.codcrmsemaforoestado=b.codcrmsemaforoestado;";
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
            txtcodigo.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblcodigodescripcion") as Label).Text);
            comboestado.SelectedValue = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblcodigoestado") as Label).Text);
            txtnombre.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblnombrefinalidad") as Label).Text);
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

            if (txtcodigo.Value == "" || txtnombre.Value == "" || comboestado.SelectedValue == "0")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] valores = { txtcodigo.Value, comboestado.SelectedValue, txtnombre.Value };
                try
                {
                    logic.insertartablas("crmestado_descripcion", valores);
                    txtnombre.Value = "";
                    comboestado.ClearSelection();
                    string varinc = sn.obtenerfinal("crmestado_descripcion", "codcrmestadodescripcion");
                    txtcodigo.Value = varinc;
                    llenargridviewmantenimiento();
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Descripción de estado", "Registro guardado");
                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Descripción de estado", "Intento guardadar");
                }
            }

        }
        protected void btnnuevoingreso_Click(object sender, EventArgs e)
        {

            txtcodigo.Value = "";
            txtnombre.Value = "";
            comboestado.ClearSelection();
            btnmodificar.Visible = false;
            btnguardar.Visible = true;
            string varinc = sn.obtenerfinal("crmestado_descripcion", "codcrmestadodescripcion");
            txtcodigo.Value = varinc;
            btnnuevoingreso.Visible = false;
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Value == "" || txtcodigo.Value == "" || comboestado.SelectedValue == "0")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] campos1 = { "codcrmestadodescripcion", "codcrmsemaforoestado", "crmestado_descripcionnombre" };
                string[] valores1 = { txtcodigo.Value, comboestado.SelectedValue, txtnombre.Value, };
                try
                {
                    logic.modificartablas("crmestado_descripcion", campos1, valores1);
                    txtnombre.Value = "";
                    string varinc = sn.obtenerfinal("crmestado_descripcion", "codcrmestadodescripcion");
                    txtcodigo.Value = varinc;
                    llenargridviewmantenimiento();
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Descripción de estado", "Registro Modificado - Correlativo:'" + txtcodigo.Value + "'");

                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Descripción de estado", "Intento Modificar - Correlativo:'" + txtcodigo.Value + "'");
                }
            }
        }
        public void llenargridviewmantenimientofiltro(string filtro)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT a.codcrmestadodescripcion,a.codcrmsemaforoestado,b.crmsemaforo_estadodescripcion,a.crmestado_descripcionnombre FROM crmestado_descripcion a INNER JOIN crmsemaforo_estado b ON a.codcrmsemaforoestado=b.codcrmsemaforoestado WHERE a.crmestado_descripcionnombre LIKE '%"+filtro+"%';";
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
            llenargridviewmantenimientofiltro(txtbusqueda.Value);
        }
    }
}