using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Administracion.Reasignaciones
{
    public partial class Reasignar_prospecto : System.Web.UI.Page
    {
        string Nombresesion;
        string sucurusalcrm;
        string usuariodelcrm;
        string roldelcrm;
        string controlingresocrm;
        int centinela1 = 0;
        int centinela2 = 0;

        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Conexion cn = new CRM_Conexion();
        CRM_Logica logic = new CRM_Logica();


        protected void Page_Load(object sender, EventArgs e)
        {
            //Buscar todos los asociados dependiendo     
            Session["sesion_usuario"] = "pggteo";

            Nombresesion = Session["sesion_usuario"].ToString();
            obtenciondeinformacion();
            Session["controlingreso"] = controlingresocrm;
            Session["usuariodelcrm"] = usuariodelcrm;
            Session["sucurusalcrm"] = sucurusalcrm;
            Session["roldelcrm"] = roldelcrm;
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            comboagenciadar.Visible = false;
            comboagenciarecibir.Visible = false;
            comboagentedar.Visible = false;
            comboagenterecibir.Visible = false;
            comboagenciaegenterecibir.Visible = false;
            comboagenciaagentedar.Visible = false;

            if (!IsPostBack)
            {

                if (roldelcrm == "7" || roldelcrm == "6" || roldelcrm == "2")
                {

                    switch (rolusuario)
                    {
                        case 7:
                            //Ingreso para coordinador de agencia
                            llenarsucursalorigen_cooragencia();
                            llenarsucursaldestino_cooragencia();
                            break;
                        case 6:
                            //Ingreso para superusuario
                            llenarsucursaldestino();
                            llenarsucursalorigen();
                            break;
                        case 2:
                            //Ingreso para jefes
                            llenarsucursaldestino();
                            llenarsucursalorigen();
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
            String script = "window.location.href= '../../MenuPrincipal/CRM_MenuPrincipal.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);


        }
        protected void btnasignarleed_Click(object sender, EventArgs e)
        {
            String script = "window.location.href= 'Asignacionporlead.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            //Asignar Leads


        }


        protected void btnaceptar_Click(object sender, EventArgs e)
        {

            if (chkagenica.Checked == true && chkagente.Checked == true)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione unicamente una opción";
            }
            else if (chkagenica.Checked == true)
            {
                //logic.bitacoraingreso("usuario","CRM","Ingreso");
                //logic.bitacoraingresoprocedimientos("usuario","CRM","ingreso de datos","insericon de datos");

                asignarparasucursales();
                lblaceptar.Visible = true;
                lblaceptar.Text = "Ha registrado el proceso para transeferenica de Leeds hacia agencias";
            }
            else if (chkagente.Checked == true)
            {
                asignarparaagente();
                lblaceptar.Visible = true;
                lblaceptar.Text = "Ha registrado el proceso para transeferenica de Leeds hacia un agente en especifico";
            }
            else if (chkagente.Checked == false && chkagenica.Checked == false)
            {
                lblerror.Visible = true;
                lblerror.Text = "No se ha realizado ninguna acción";
                lblaceptar.Visible = false;

            }


        }

        protected void chkagenica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkagente.Checked == true)
            {
                lblerror.Visible = true;
                lblerror.Text = "Vuelva a seleccionar unicamente una opción";
                lblaceptar.Visible = false;
                chkagenica.Checked = false;
                chkagente.Checked = false;
            }
            else if (chkagenica.Checked == false && chkagente.Checked == false)
            {
                comboagenciaegenterecibir.Visible = false;
                comboagenciaagentedar.Visible = false;
                comboagenterecibir.Visible = false;
                comboagentedar.Visible = false;
                comboagenciadar.Visible = false;
                comboagenciarecibir.Visible = false;
                lblerror.Visible = false;
                lblaceptar.Visible = false;

            }
            else
            {
                comboagenciadar.Visible = true;
                comboagenciarecibir.Visible = true;
                comboagentedar.Visible = false;
                comboagenterecibir.Visible = false;
                comboagenciaegenterecibir.Visible = false;
                comboagenciaagentedar.Visible = false;
                lblerror.Visible = false;
                lblaceptar.Visible = false;

            }

        }

        protected void chkagente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkagenica.Checked == true)
            {
                lblerror.Visible = true;
                lblerror.Text = "Vuelva a seleccionar unicamente una opción";
                lblaceptar.Visible = false;
                chkagente.Checked = false;
                chkagenica.Checked = false;
            }
            else if (chkagenica.Checked == false && chkagente.Checked == false)
            {
                comboagenciaegenterecibir.Visible = false;
                comboagenciaagentedar.Visible = false;
                comboagenterecibir.Visible = false;
                comboagentedar.Visible = false;
                comboagenciadar.Visible = false;
                comboagenciarecibir.Visible = false;
                lblerror.Visible = false;
                lblaceptar.Visible = false;
            }
            else
            {
                comboagenciaegenterecibir.Visible = true;
                comboagenciaagentedar.Visible = true;
                comboagenterecibir.Visible = true;
                comboagentedar.Visible = true;
                comboagenciadar.Visible = false;
                comboagenciarecibir.Visible = false;
                lblerror.Visible = false;
                lblaceptar.Visible = false;

            }

        }

        public void llenarsucursalorigen()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT DISTINCT crmcontrol_ingresosucursal FROM crmcontrol_ingreso where crmcontrol_ingresorol =3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciadestino12");
                    comboagenciadar.DataSource = ds;
                    comboagenciadar.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataBind();
                    comboagenciadar.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));


                    comboagenciaagentedar.DataSource = ds;
                    comboagenciaagentedar.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciaagentedar.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciaagentedar.DataBind();
                    comboagenciaagentedar.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarsucursaldestino()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT DISTINCT crmcontrol_ingresosucursal FROM crmcontrol_ingreso where crmcontrol_ingresorol =3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciadestino21");
                    comboagenciarecibir.DataSource = ds;
                    comboagenciarecibir.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciarecibir.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciarecibir.DataBind();
                    comboagenciarecibir.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));



                    comboagenciaegenterecibir.DataSource = ds;
                    comboagenciaegenterecibir.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciaegenterecibir.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciaegenterecibir.DataBind();
                    comboagenciaegenterecibir.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarsucursalorigen_cooragencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT DISTINCT crmcontrol_ingresosucursal FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal!='telemercadeo';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciaorigen1");
                    comboagenciadar.DataSource = ds;
                    comboagenciadar.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciadar.DataBind();
                    comboagenciadar.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));

                    comboagenciaagentedar.DataSource = ds;
                    comboagenciaagentedar.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciaagentedar.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciaagentedar.DataBind();
                    comboagenciaagentedar.Items.Insert(0, new ListItem("[-Agencia Fuente-]", "0"));

                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarsucursaldestino_cooragencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT DISTINCT crmcontrol_ingresosucursal FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal!='telemercadeo';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "agenciadestino2");
                    comboagenciarecibir.DataSource = ds;
                    comboagenciarecibir.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciarecibir.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciarecibir.DataBind();
                    comboagenciarecibir.Items.Insert(0, new ListItem("[-Agencia Destino-]", "0"));

                    comboagenciaegenterecibir.DataSource = ds;
                    comboagenciaegenterecibir.DataTextField = "crmcontrol_ingresosucursal";
                    comboagenciaegenterecibir.DataValueField = "crmcontrol_ingresosucursal";
                    comboagenciaegenterecibir.DataBind();
                    comboagenciaegenterecibir.Items.Insert(0, new ListItem("[-Agencia Destino-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenaragentesucursalfuente(string agencia)
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
                    comboagentedar.DataSource = ds;
                    comboagentedar.DataTextField = "crmcontrol_ingresousuario";
                    comboagentedar.DataValueField = "codcrmcontrolingreso";
                    comboagentedar.DataBind();
                    comboagentedar.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenaragentesucursaldestino(string agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codcrmcontrolingreso,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia221");
                    comboagenterecibir.DataSource = ds;
                    comboagenterecibir.DataTextField = "crmcontrol_ingresousuario";
                    comboagenterecibir.DataValueField = "codcrmcontrolingreso";
                    comboagenterecibir.DataBind();
                    comboagenterecibir.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenaragentesucursalfuente_cooragencia(long agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "' AND  crmcontrol_ingresosucursal!='TELEMERCADEO' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia2");
                    comboagenciarecibir.DataSource = ds;
                    comboagenciarecibir.DataTextField = "crmcontrol_ingresousuario";
                    comboagenciarecibir.DataValueField = "crmcontrol_ingresousuario";
                    comboagenciarecibir.DataBind();
                    comboagenciarecibir.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenaragentesucursaldestino_cooragencia(long agencia)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol =3 AND crmcontrol_ingresosucursal='" + agencia + "' AND  crmcontrol_ingresosucursal!='TELEMERCADEO' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarioagencia2");
                    comboagenciarecibir.DataSource = ds;
                    comboagenciarecibir.DataTextField = "crmcontrol_ingresousuario";
                    comboagenciarecibir.DataValueField = "crmcontrol_ingresousuario";
                    comboagenciarecibir.DataBind();
                    comboagenciarecibir.Items.Insert(0, new ListItem("[-Seleccione Agente-]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void comboagenciaagentedar_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaragentesucursalfuente(comboagenciaagentedar.SelectedValue);

            comboagenciaagentedar.Visible = true;
            comboagentedar.Visible = true;
            comboagenciaegenterecibir.Visible = true;
            comboagenterecibir.Visible = true;

        }
        protected void comboagenciagenterecibir_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaragentesucursaldestino(comboagenciaegenterecibir.SelectedValue);
            comboagenciaagentedar.Visible = true;
            comboagentedar.Visible = true;
            comboagenciaegenterecibir.Visible = true;
            comboagenterecibir.Visible = true;
        }


        public void asignarparasucursales()
        {
            string[] var1 = sn.consultaporsucursal(comboagenciadar.SelectedValue);
            string[] var2 = sn.consultaparasimultaneasucursal(comboagenciarecibir.SelectedValue);
            for (int i = 0; i < var1.Length; i++)
            {
                string id1 = var1[centinela1];
                if (centinela2 == var2.Length)
                {
                    centinela2 = 0;
                }
                string id2 = var2[centinela2];
                centinela2 = centinela2 + 3;
                centinela1 = centinela1 + 2;
                i = centinela1;
                // Response.Write(id1 + id2);
                string[] campos1 = { "codcrmcontrolingreso", "codcrmcontrolingreso" };
                string[] valores1 = { id1, id2 };
                try
                {
                    //logic.modificartablas("crmcontrol_prospecto_agente", campos1, valores1);
                    logic.modificarregistrodeagente(id1, id2);
                    logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasignar Prospecto", "Asignación para sucursales");
                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                    logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasignar Prospecto", "Fallo Asignación para sucursales");
                }
            }
        }

        public void asignarparaagente()
        {
            try
            {
                logic.modificarregistrodeagente(comboagentedar.SelectedValue, comboagenterecibir.SelectedValue);
                logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasignar Prospecto", "Asignación para agentes");
            }
            catch
            {
                Console.WriteLine("dejo de funcionar");
                logic.bitacoraingresoprocedimientos(Nombresesion, "CRM", "Reasignar Prospecto", "Fallo Asignación para agentes");
            }
        }

        protected void btnmenuprincipal_Click1(object sender, EventArgs e)
        {

        }
    }
}
