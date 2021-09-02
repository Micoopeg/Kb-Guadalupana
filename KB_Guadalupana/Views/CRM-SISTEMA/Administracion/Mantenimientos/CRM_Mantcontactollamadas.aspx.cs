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
    public partial class CRM_Mantcontactollamadas : System.Web.UI.Page
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
                string varinc = sn.obtenerfinal("crmcontacto_llamadas", "codcrmcontactollamadas");
                txtcodigo.Value = varinc;
                btnmodificar.Visible = false;
                btnnuevoingreso.Visible = false;

            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }

        public void llenargridviewmantenimiento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM crmcontacto_llamadas;";
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
            txtcodigo.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblcodigo") as Label).Text);
            txtnombre.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblnombre") as Label).Text);
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
           
            if (txtcodigo.Value=="" || txtnombre.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else{
                string[] valores = {txtcodigo.Value,txtnombre.Value };
                try
                {
                    logic.insertartablas("crmcontacto_llamadas", valores);
                    txtnombre.Value = "";
                    string varinc = sn.obtenerfinal("crmcontacto_llamadas", "codcrmcontactollamadas");
                    txtcodigo.Value = varinc;
                    llenargridviewmantenimiento();
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Contacto llamadas", "Registro guardado");
                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Contacto llamadas", "Intento guardadar");
                }
            }

        }        
       protected void btnnuevoingreso_Click(object sender, EventArgs e)
        {
           
            txtcodigo.Value = "";
            txtnombre.Value = "";
            btnmodificar.Visible = false;
            btnguardar.Visible = true;
            string varinc = sn.obtenerfinal("crmcontacto_llamadas", "codcrmcontactollamadas");
            txtcodigo.Value = varinc;
            btnnuevoingreso.Visible = false;
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Value == "" || txtnombre.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] campos1 = { "codcrmcontactollamadas", "crmcontacto_llamadasnombre" };
                string[] valores1 = { txtcodigo.Value, txtnombre.Value, };
                try
                {
                    logic.modificartablas("crmcontacto_llamadas", campos1, valores1);
                    txtnombre.Value = "";
                    string varinc = sn.obtenerfinal("crmcontacto_llamadas", "codcrmcontactollamadas");
                    txtcodigo.Value = varinc;
                    llenargridviewmantenimiento();
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Contacto llamadas", "Registro Modificado - Correlativo:'"+txtcodigo.Value+"'");

                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Contacto llamadas", "Intento Modificar - Correlativo:'" + txtcodigo.Value + "'");
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
                    string QueryString = "SELECT * FROM crmcontacto_llamadas WHERE crmcontacto_llamadasnombre LIKE '%"+filtro+"%';";
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