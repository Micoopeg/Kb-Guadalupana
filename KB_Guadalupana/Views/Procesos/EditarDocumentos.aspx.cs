using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class EditarDocumentos : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombodocumento();
                llenarcomboestado();
                llenarcomboorigen();
                llenarcombousuario();
                llenarcombocategoria();
                llenardatos();
            }
        }

        protected void Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombosubcategoria();
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_tipodocumento";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoDocumento.DataSource = ds;
                    TipoDocumento.DataTextField = "pro_nombretipo";
                    TipoDocumento.DataValueField = "idpro_tipodocumento";
                    TipoDocumento.DataBind();
                    TipoDocumento.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboestado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_estado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Estado.DataSource = ds;
                    Estado.DataTextField = "pro_estadonombre";
                    Estado.DataValueField = "idpro_estado";
                    Estado.DataBind();
                    Estado.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboorigen()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_origen";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Origen.DataSource = ds;
                    Origen.DataTextField = "pro_origennombre";
                    Origen.DataValueField = "idpro_origen";
                    Origen.DataBind();
                    Origen.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_tipousuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    UsuarioDirigido.DataSource = ds;
                    UsuarioDirigido.DataTextField = "pro_nombreusuario";
                    UsuarioDirigido.DataValueField = "idpro_tipousuario";
                    UsuarioDirigido.DataBind();
                    UsuarioDirigido.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombocategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_categoria";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Categoria.DataSource = ds;
                    Categoria.DataTextField = "pro_nombre";
                    Categoria.DataValueField = "idpro_categoria";
                    Categoria.DataBind();
                    Categoria.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombosubcategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpro_subcategoria, pro_nombre FROM pro_subcategoria WHERE idpro_categoria = '" + Categoria.SelectedValue + "'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Subcategoria.DataSource = ds;
                    Subcategoria.DataTextField = "pro_nombre";
                    Subcategoria.DataValueField = "idpro_subcategoria";
                    Subcategoria.DataBind();
                    Subcategoria.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenardatos()
        {
            string id = Session["id_documento"] as string;
            string[] datosdocumento = sn.obtenerdatosdocumento(id);
            string[] fecha;
            string[] fecha2;
            string dia, mes, año;

            for(int i = 0; i<datosdocumento.Length; i++)
            {
                TipoDocumento.SelectedValue = datosdocumento[1];
                Codigo.Value = datosdocumento[2];
                NombreDocumento.Value = datosdocumento[3];
                Version.Value = datosdocumento[6];
                fecha = datosdocumento[7].Split(' ');
                fecha2 = fecha[0].Split('/');
                if(fecha2[0].Length == 1)
                {
                    FechaAprobacion.Value = fecha2[2] + '-' + fecha2[1] + '-' + "0" + fecha2[0];
                }
                else
                {
                    FechaAprobacion.Value = fecha2[2] + '-' + fecha2[1] + '-' + fecha2[0];
                }
               
                Estado.SelectedValue = datosdocumento[8];
                Origen.SelectedValue = datosdocumento[9];
                UsuarioDirigido.SelectedValue = datosdocumento[10];
                Categoria.SelectedValue = datosdocumento[11];
                Subcategoria.SelectedValue = datosdocumento[12];
            }
        }

    }
}