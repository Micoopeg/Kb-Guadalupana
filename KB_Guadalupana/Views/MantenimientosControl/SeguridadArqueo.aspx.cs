using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class SeguridadArqueo : System.Web.UI.Page
    {
        Sentencia_seguridad sn = new Sentencia_seguridad();
        Conexion_seguridad cn = new Conexion_seguridad();
        Conexion conexiongeneral = new Conexion();
        string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombopuesto();
                llenarcombousuarios();
                llenarcomboestado();
            }
            
        }

        public void llenarcombopuesto()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sa_puesto";
                    MySqlConnection conect = cn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Puesto");
                    Puesto.DataSource = ds;
                    Puesto.DataTextField = "sa_puestonombre";
                    Puesto.DataValueField = "idsa_puesto";
                    Puesto.DataBind();
                    Puesto.Items.Insert(0, new ListItem("[Puesto]", "0"));
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
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
                    UsuarioSA.DataSource = ds;
                    UsuarioSA.DataTextField = "gen_usuarionombre";
                    UsuarioSA.DataValueField = "codgenusuario";
                    UsuarioSA.DataBind();
                    UsuarioSA.Items.Insert(0, new ListItem("[Usuario]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcomboestado()
        {
            EstadoU.Items.Insert(0, new ListItem("[Estado]", "0"));
            EstadoU.Items.Insert(1, new ListItem("Activo", "1"));
            EstadoU.Items.Insert(2, new ListItem("Desactivo", "2"));
        }


        protected void BuscarUsuario_Click(object sender, EventArgs e)
        {
            string[] campos = sn.buscarcontrolarqueos(UsuarioSA.SelectedValue);
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

                    Puesto.SelectedValue = campos[2];
                    string estado = "";
                    if (campos[3] == "Activo")
                    {
                        estado = "1";
                    }
                    else
                    {
                        estado = "2";
                    }
                    EstadoU.SelectedValue = estado;
                }
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            string estado;
            if (EstadoU.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Desactivo";
            }
            string sig = sn.siguiente("sa_control_ingreso", "cod_controlingreso");
            sn.insertarcontrolarqueos(sig, UsuarioSA.SelectedValue, Puesto.SelectedValue, estado);
            String script = "alert('Usuario Guardado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (EstadoU.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Desactivo";
            }
            sn.modificarcontrolarqueos(UsuarioSA.SelectedValue, Puesto.SelectedValue, estado);
            String script = "alert('Usuario Modificado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }
    }
}