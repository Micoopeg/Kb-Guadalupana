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
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombousuarios();
                llenarcombocategoria();
                llenarcombosubcategoria2();
                llenarcombotipousuario();
                llenarcomboestado();
                llenarcombopuesto();
                datos.Visible = false;
                Actualizar.Visible = false;
                btninsert.Visible = false;
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

        public void llenarcombosubcategoria2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpro_subcategoria, pro_nombre FROM pro_subcategoria";
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
                    Puesto.DataSource = ds;
                    Puesto.DataTextField = "gen_puestosnombre";
                    Puesto.DataValueField = "codgenpuestos";
                    Puesto.DataBind();
                    Puesto.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        protected void Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombosubcategoria();
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
                    datos.Visible = true;
                    BuscarUsuario.Visible = false;
                    String script = "alert('Usuario no encontrado');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    Actualizar.Visible = true;
                    btninsert.Visible = false;
                    datos.Visible = true;

                    Session["id_registro_usuario"] = campos[0];
                    TipoUsuario.SelectedValue = campos[2];
                    Categoria.SelectedValue = campos[3];
                    Subcategoria.SelectedValue = campos[4];
                    Puesto.SelectedValue = campos[6];
                    string estado = "";
                    if (campos[5] == "Activo")
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
            if (UsuarioPJ.SelectedValue == "0" || Categoria.SelectedValue == "0" || Subcategoria.SelectedValue == "0" || Puesto.SelectedValue == "0" || TipoUsuario.SelectedValue == "0" || Estado.SelectedValue == "0")
            {
                String script2 = "alert('Complete los campos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
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
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if (UsuarioPJ.SelectedValue == "0" || Categoria.SelectedValue == "0" || Subcategoria.SelectedValue == "0" || Puesto.SelectedValue == "0" || TipoUsuario.SelectedValue == "0" || Estado.SelectedValue == "0")
            {
                String script2 = "alert('Complete los campos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
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
                string id = Session["id_registro_usuario"] as string;
                sn.modificaringresoprocesos(id, TipoUsuario.SelectedValue, Categoria.SelectedValue, Subcategoria.SelectedValue, estado, Puesto.SelectedValue);
                String script = "alert('Usuario Modificado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }
    }
}