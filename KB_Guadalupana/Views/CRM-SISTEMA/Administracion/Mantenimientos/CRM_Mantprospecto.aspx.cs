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
    public partial class CRM_Mantprospecto : System.Web.UI.Page
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
                string varinc = sn.obtenerfinal("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
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
                    string QueryString = "SELECT * FROM crminfogeneral_prospecto;";
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
            txtdpi.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lbldpi") as Label).Text);
            txtnombre.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblnombre") as Label).Text);
            txtapellido.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblapellido") as Label).Text);
            txtnombrecompleto.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblnombrecompleto") as Label).Text);
            txtlistanegra.Value = Convert.ToString((gridviewmant.SelectedRow.FindControl("lblblacklist") as Label).Text);

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

            if (txtcodigo.Value == "" || txtnombrecompleto.Value == "" || txtdpi.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] valores = { txtcodigo.Value, txtdpi.Value, txtnombre.Value, txtapellido.Value, txtnombrecompleto.Value,"0"};
                try
                {
                    if (txtdpi.Value.Length == 13)
                    {
                        if (validardpi(txtdpi.Value) == true)
                        {
                            logic.insertartablas("crminfogeneral_prospecto", valores);
                            txtdpi.Value = "";
                            txtnombre.Value = "";
                            txtapellido.Value = "";
                            txtnombrecompleto.Value = "";
                            txtlistanegra.Value = "";
                            lbleror.InnerText = "";
                            string varinc = sn.obtenerfinal("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                            txtcodigo.Value = varinc;
                            llenargridviewmantenimiento();
                            logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Prospecto", "Registro guardado");
                            String script = "alert('Los datos se han ingresado correctamente');";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                        else
                        {
                            lbleror.InnerText = "*ERROR - DPI INVALIDO*";

                        }
                    }
                    else
                    {
                        String script = "alert('Verifique la cantidad de caracteres del número de DPI');";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }                  
                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Prospecto", "Intento guardadar");
                }
            }

        }
        protected void btnnuevoingreso_Click(object sender, EventArgs e)
        {

            txtcodigo.Value = "";
            txtnombre.Value = "";
            txtapellido.Value = "";
            txtnombrecompleto.Value = "";
            txtdpi.Value = "";
            txtlistanegra.Value = "";
            lbleror.InnerText = "";
            btnmodificar.Visible = false;
            btnguardar.Visible = true;
            string varinc = sn.obtenerfinal("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
            txtcodigo.Value = varinc;
            btnnuevoingreso.Visible = false;
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Value == "" || txtnombrecompleto.Value == "" || txtdpi.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] campos1 = { "codcrminfogeneralprospecto", "crminfogeneral_prospectodpi", "crminfogeneral_prospectonombre", "crminfogeneral_prospectoapellido", "crminfogeneral_prospectonombrecompleto", "crminfogeneral_prospectoblacklist" };
                string[] valores1 = { txtcodigo.Value,txtdpi.Value,txtnombre.Value,txtapellido.Value,txtnombrecompleto.Value,txtlistanegra.Value};
                try
                {
                    if (validardpi(txtdpi.Value) == true)
                    {
                        logic.modificartablas("crminfogeneral_prospecto", campos1, valores1);
                        txtdpi.Value = "";
                        txtnombre.Value = "";
                        txtapellido.Value = "";
                        txtnombrecompleto.Value = "";
                        txtlistanegra.Value = "";
                        lbleror.InnerText = "";
                        string varinc = sn.obtenerfinal("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                        txtcodigo.Value = varinc;
                        llenargridviewmantenimiento();
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Prospectos", "Registro Modificado - Correlativo:'" + txtcodigo.Value + "'");

                    }
                    else
                    {
                        lbleror.InnerText = "*ERROR - DPI INVALIDO*";
                    }
                    

                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Mantenimiento Prospectos", "Intento Modificar - Correlativo:'" + txtcodigo.Value + "'");
                }
            }
        }

        public bool validardpi(string cadenaaverificar)
        {
            int multiplicar;
            int contdescente = 9;
            int resultado;
            int subtotal = 0;
            string var = cadenaaverificar;
            char[] cadenaComoCaracteres = var.ToCharArray();
            int numero = (cadenaComoCaracteres.Length - 5);
            for (int i = 0; i < numero;)
            {

                multiplicar = (Convert.ToInt32(cadenaComoCaracteres[i]) - 48);
                resultado = multiplicar * contdescente;
                contdescente = contdescente - 1;
                subtotal = subtotal + resultado;
                i = i + 1;
            }
            int residuo = subtotal % 11;
            int total = 11 - residuo;
            int varvalidadora = (Convert.ToChar(cadenaComoCaracteres[8])-48);
            if (varvalidadora == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void llenargridviewmantenimientofiltro(string filtro)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM crminfogeneral_prospecto WHERE crminfogeneral_prospectonombrecompleto LIKE '%"+filtro+"%';";
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