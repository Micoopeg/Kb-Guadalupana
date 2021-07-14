using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.MantenimientosControl
{
    public partial class ControlProcesos : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombousuarios();
                llenarcombocategoria();
                llenarcombosubcategoria();
                llenarcombotipousuario();
                llenarcomboestado();
                llenarcombopuesto();
            }
        }

        public void llenarcombousuarios()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_usuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    UsuarioPJ.DataSource = ds;
                    UsuarioPJ.DataTextField = "gen_usuarionombre";
                    UsuarioPJ.DataValueField = "codgenusuario";
                    UsuarioPJ.DataBind();
                    UsuarioPJ.Items.Insert(0, new ListItem("[Usuario]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcombocategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pro_categoria";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    Categoria.DataSource = ds;
                    Categoria.DataTextField = "pro_nombre";
                    Categoria.DataValueField = "idpro_categoria";
                    Categoria.DataBind();
                    Categoria.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcombosubcategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pro_subcategoriaregistro";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    Subcategoria.DataSource = ds;
                    Subcategoria.DataTextField = "pro_nombre";
                    Subcategoria.DataValueField = "idpro_subcategoria";
                    Subcategoria.DataBind();
                    Subcategoria.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcombotipousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pro_tipousuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    TipoUsuario.DataSource = ds;
                    TipoUsuario.DataTextField = "pro_nombreusuario";
                    TipoUsuario.DataValueField = "idpro_tipousuario";
                    TipoUsuario.DataBind();
                    TipoUsuario.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcomboestado()
        {
            Estado.Items.Insert(0, new ListItem("[Estado]", "0"));
            Estado.Items.Insert(1, new ListItem("Activo", "1"));
            Estado.Items.Insert(2, new ListItem("Desactivo", "2"));
        }

        protected void BuscarUsuario_Click(object sender, EventArgs e)
        {
            string[] campos = sn.buscarcontrolprocesos(UsuarioPJ.SelectedValue);
            for (int i = 0; i < campos.Length; i++)
            {
                if (campos[0] == null)
                {
                    Actualizar.Visible = false;
                    btninsert.Visible = true;
                    String script = "alert('Usuario no encontrado');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    Actualizar.Visible = true;
                    btninsert.Visible = false;

                    TipoUsuario.SelectedValue = campos[2];
                    Categoria.SelectedValue = campos[3];
                    Subcategoria.SelectedValue = campos[5];
                    Puesto.SelectedValue = campos[6];
                    string estado = "";
                    if (campos[4] == "Activo")
                    {
                        estado = "1";
                    }
                    else
                    {
                        estado = "2";
                    }
                    Estado.SelectedValue = estado;
                }
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            string estado;
            if (Estado.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Desactivo";
            }
            string sig = sn.siguiente("pro_registroingreso", "idpro_registroingreso");
            sn.insertaringresoprocesos(sig, UsuarioPJ.SelectedValue, TipoUsuario.SelectedValue, Categoria.SelectedValue, Subcategoria.SelectedValue, estado, Puesto.SelectedValue);
            String script = "alert('Usuario Guardado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (Estado.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Desactivo";
            }
            sn.modificaringresoprocesos(UsuarioPJ.SelectedValue, TipoUsuario.SelectedValue, Categoria.SelectedValue, Subcategoria.SelectedValue, estado, Puesto.SelectedValue);
            String script = "alert('Usuario Modificado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        public void llenarcombopuesto()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_puestos";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Puesto");
                    TipoUsuario.DataSource = ds;
                    TipoUsuario.DataTextField = "gen_puestosnombre";
                    TipoUsuario.DataValueField = "codgenpuestos";
                    TipoUsuario.DataBind();
                    TipoUsuario.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

    }
}