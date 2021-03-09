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
        Sentencias sn = new Sentencias();
        Logica logic = new Logica();
        Conexion cn = new Conexion();
        string connectionString = @"Server=localhost;Database=mydb;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
                    combotiposervicio.Items.Insert(0, new ListItem("[Tipo de servicio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombofinalidadservicio(long codtiposervicio)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
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



    }
}