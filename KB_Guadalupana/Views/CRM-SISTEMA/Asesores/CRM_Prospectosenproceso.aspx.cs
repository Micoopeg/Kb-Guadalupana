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

namespace KB_Guadalupana.Views.CRM_SISTEMA.Asesores
{
    public partial class CRM_Prospectosenproceso : System.Web.UI.Page
    {
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        string codigodeleed = "";//ESTE CODIGO PERMITE MOSTAT EL DETALLE DEL PROSPECTO SELECCIONADO.
        string nombreusuario;
        string sucurusalcrm;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            sucurusalcrm = Convert.ToString(Session["sucurusalcrm"]);
            if (rolusuario == 2 || rolusuario == 5 || rolusuario == 6 || rolusuario == 3)
            {

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            switch (rolusuario)
            {
                case 2:
                    //desbloquear botones botons
                    llenargridview(nombreusuario, txtnombrecompleto.Value);
                    gridview1.Visible = false;
                    gridview2.Visible = false;
                    gridview3.Visible = false;
                    gridview4.Visible = false;
                    gridview5.Visible = false;
                    break;
                case 5:
                    //bloquear botones
                    //busqueda por sucursal
                    llenargridviewagencia(sucurusalcrm);
                    gridview1.Visible = false;
                    gridview2.Visible = false;
                    gridview3.Visible = false;
                    gridview4.Visible = false;
                    gridview5.Visible = false;
                    break;
                case 6:
                    //Desbloqeuar botones
                    llenargridview(nombreusuario, txtnombrecompleto.Value);
                    gridview1.Visible = false;
                    gridview2.Visible = false;
                    gridview3.Visible = false;
                    gridview4.Visible = false;
                    gridview5.Visible = false;
                    break;
                case 3:
                    llenargridview(nombreusuario, txtnombrecompleto.Value);
                    gridview1.Visible = false;
                    gridview2.Visible = false;
                    gridview3.Visible = false;
                    gridview4.Visible = false;
                    gridview5.Visible = false;
                    break;
                default:
                    String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    break;
            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRM_Asesores.aspx");
        }



        public void llenargridviewagencia(string sucursal)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select a.codcrminfoprospecto,b.crminfogeneral_prospectodpi,b.crminfogeneral_prospectonombrecompleto FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso WHERE a.codcrmsemaforoestado=1 AND d.crmcontrol_ingresosucursal='" + sucursal + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewprospectos.DataSource = ds3;
                    gridviewprospectos.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }

        protected void OnSelectedIndexChangedprospectos(object sender, EventArgs e)
        {

            GridViewRow row = gridviewprospectos.SelectedRow;
            codigodeleed = (gridviewprospectos.SelectedRow.FindControl("lblcodprospeto") as Label).Text;
            llenargridview1(codigodeleed);
            gridview1.Visible = true;

            llenargridview2(codigodeleed);
            gridview2.Visible = true;

            llenargridview3(codigodeleed);
            gridview3.Visible = true;

            llenargridview4(codigodeleed);
            gridview4.Visible = true;

            llenargridview5(codigodeleed);
            gridview5.Visible = true;

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtnombrecompleto.Value;
            llenargridview(nombreusuario, busqueda);
            gridviewprospectos.Visible = true;
        }

        public void llenargridview1(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select e.crmtipo_servicionombre,k.crm_finalidaddescripcion,f.crmcontacto_llamadasnombre,g.crmsemaforo_estadodescripcion,l.crmestado_descripcionnombre,a.crminfo_prospectomonto FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b  INNER JOIN crmcontrol_prospecto_agente c  INNER JOIN crmcontrol_ingreso d  INNER JOIN crmtipo_servicio e INNER JOIN crmcontacto_llamadas f INNER JOIN crmsemaforo_estado g INNER JOIN crmestado_descripcion i INNER JOIN crmtipo_domicilio j INNER JOIN crm_finalidadservicio k INNER JOIN crmestado_descripcion l ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso AND a.codcrmtiposervicio = e.codcrmtiposervicio AND a.codcrmcontactollamadas = f.codcrmcontactollamadas AND a.codcrmsemaforoestado = g.codcrmsemaforoestado AND a.codcrmestadodescripcion = i.codcrmestadodescripcion AND a.codcrmtipodomicilio = j.codcrmtipodomicilio AND a.codcrmfinalidadservicio = k.codcrmfinalidadservicio AND a.codcrmestadodescripcion= l.codcrmestadodescripcion WHERE a.codcrminfoprospecto='" + codigo + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridview1.DataSource = ds3;
                    gridview1.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }
        }
        public void llenargridview2(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select j.crmtipo_domicilionombre,a.crminfo_prospectoañosdomicilio,a.crminfo_prospectotelefono,a.crminfo_prospectoemail,a.crminfo_prospectoingresos,a.crminfo_prospectoegresos FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d INNER JOIN crmtipo_servicio e INNER JOIN crmcontacto_llamadas f INNER JOIN crmsemaforo_estado g INNER JOIN crmestado_descripcion i INNER JOIN crmtipo_domicilio j INNER JOIN crm_finalidadservicio k ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso AND a.codcrmtiposervicio = e.codcrmtiposervicio AND a.codcrmcontactollamadas = f.codcrmcontactollamadas AND a.codcrmsemaforoestado = g.codcrmsemaforoestado AND a.codcrmestadodescripcion = i.codcrmestadodescripcion AND a.codcrmtipodomicilio = j.codcrmtipodomicilio AND A.codcrmfinalidadservicio = k.codcrmfinalidadservicio WHERE a.codcrminfoprospecto='" + codigo + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridview2.DataSource = ds3;
                    gridview2.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }
        }
        public void llenargridview3(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select a.crminfo_prospectoañoslaborados,IF(a.crminfo_prospectotrabajaactualmente = 1, 'Si', 'No') AS crminfo_prospectotrabajaactualmente,a.crminfo_prospectodescripciontrabajoactual FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d INNER JOIN crmtipo_servicio e INNER JOIN crmcontacto_llamadas f INNER JOIN crmsemaforo_estado g INNER JOIN crmestado_descripcion i INNER JOIN crmtipo_domicilio j INNER JOIN crm_finalidadservicio k ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso  AND a.codcrmtiposervicio = e.codcrmtiposervicio AND a.codcrmcontactollamadas = f.codcrmcontactollamadas AND a.codcrmsemaforoestado = g.codcrmsemaforoestado AND a.codcrmestadodescripcion = i.codcrmestadodescripcion AND a.codcrmtipodomicilio = j.codcrmtipodomicilio AND A.codcrmfinalidadservicio = k.codcrmfinalidadservicio WHERE a.codcrminfoprospecto='" + codigo + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridview3.DataSource = ds3;
                    gridview3.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }
        }
        public void llenargridview4(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select a.crminfo_prospectofechaprimerllamada,a.crminfo_prospectofechaultimallamada,a.crminfo_prospectodescripcion,a.crminfo_prospectosucursalcerca FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d INNER JOIN crmtipo_servicio e INNER JOIN crmcontacto_llamadas f INNER JOIN crmsemaforo_estado g INNER JOIN crmestado_descripcion i INNER JOIN crmtipo_domicilio j INNER JOIN crm_finalidadservicio k ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso  AND a.codcrmtiposervicio = e.codcrmtiposervicio AND a.codcrmcontactollamadas = f.codcrmcontactollamadas AND a.codcrmsemaforoestado = g.codcrmsemaforoestado AND a.codcrmestadodescripcion = i.codcrmestadodescripcion AND a.codcrmtipodomicilio = j.codcrmtipodomicilio AND A.codcrmfinalidadservicio = k.codcrmfinalidadservicio WHERE a.codcrminfoprospecto='" + codigo + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridview4.DataSource = ds3;
                    gridview4.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }
        }
        public void llenargridview5(string codigo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select IF(a.crminfo_prospectocuentaconigss = 1, 'Si', 'No') AS crminfo_prospectocuentaconigss,IF(a.crminfo_prospectocuentaencooperativa = 1, 'Si', 'No') AS crminfo_prospectocuentaencooperativa,a.crminfo_contactadopor,a.crminfo_prospectoreferenciado,d.crmcontrol_ingresosucursal,d.crmcontrol_ingresousuario FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c  INNER JOIN crmcontrol_ingreso d  INNER JOIN crmtipo_servicio e INNER JOIN crmcontacto_llamadas f INNER JOIN crmsemaforo_estado g INNER JOIN crmestado_descripcion i INNER JOIN crmtipo_domicilio j INNER JOIN crm_finalidadservicio k ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso AND a.codcrmtiposervicio = e.codcrmtiposervicio AND a.codcrmcontactollamadas = f.codcrmcontactollamadas AND a.codcrmsemaforoestado = g.codcrmsemaforoestado AND a.codcrmestadodescripcion = i.codcrmestadodescripcion AND a.codcrmtipodomicilio = j.codcrmtipodomicilio AND A.codcrmfinalidadservicio = k.codcrmfinalidadservicio WHERE a.codcrminfoprospecto='" + codigo + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridview5.DataSource = ds3;
                    gridview5.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }
        }
        public void llenargridview(string usuario, string busqueda)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select a.codcrminfoprospecto,b.crminfogeneral_prospectodpi,b.crminfogeneral_prospectonombrecompleto FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso WHERE d.crmcontrol_ingresousuario='" + usuario + "' AND a.codcrmsemaforoestado=1 AND crminfogeneral_prospectonombrecompleto LIKE '%" + busqueda + "%' ;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewprospectos.DataSource = ds3;
                    gridviewprospectos.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");
        }
    }
}