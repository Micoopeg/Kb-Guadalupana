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
    public partial class controlProcesosJudiciales : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombousuarios();
                llenarcomboarea();
                llenarcomborol();
                llenarcomboestado();
                llenarcombopuesto2();
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

        public void llenarcomboarea()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_area";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Area");
                    Area.DataSource = ds;
                    Area.DataTextField = "gen_areanombre";
                    Area.DataValueField = "codgenarea";
                    Area.DataBind();
                    Area.Items.Insert(0, new ListItem("[Area]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcomborol()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pj_rol";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Rol");
                    Rol.DataSource = ds;
                    Rol.DataTextField = "pj_rolnombre";
                    Rol.DataValueField = "idpj_rol";
                    Rol.DataBind();
                    Rol.Items.Insert(0, new ListItem("[Rol]", "0"));
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

        public void llenarcombopuesto(string area)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select codgenpuestos, gen_puestosnombre from gen_puestos WHERE codgenarea= '" + area+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Puesto");
                    Puesto.DataSource = ds;
                    Puesto.DataTextField = "gen_puestosnombre";
                    Puesto.DataValueField = "codgenpuestos";
                    Puesto.DataBind();
                    Puesto.Items.Insert(0, new ListItem("[Puesto]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombopuesto2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select codgenpuestos, gen_puestosnombre from gen_puestos";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Puesto");
                    Puesto.DataSource = ds;
                    Puesto.DataTextField = "gen_puestosnombre";
                    Puesto.DataValueField = "codgenpuestos";
                    Puesto.DataBind();
                    Puesto.Items.Insert(0, new ListItem("[Puesto]", "0"));
                }
                catch
                {

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
            string sig = sn.siguiente("pj_controlingreso", "idpj_controlingreso");
            sn.insertaringresojuridico(sig, UsuarioPJ.SelectedValue, Area.SelectedValue, Rol.SelectedValue, estado, Puesto.SelectedValue);
            String script = "alert('Usuario Guardado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if(EstadoU.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Desactivo";
            }
            sn.modificaringresojuridico(UsuarioPJ.SelectedValue, Area.SelectedValue, Rol.SelectedValue, estado, Puesto.SelectedValue);
            String script = "alert('Usuario Modificado');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void BuscarUsuario_Click(object sender, EventArgs e)
        {
            string[] campos = sn.buscarcontroljuridico(UsuarioPJ.SelectedValue);
            for (int i = 0; i < campos.Length; i++)
            {
                if(campos[0] == null)
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

                    Area.SelectedValue = campos[2];
                    Rol.SelectedValue = campos[3];
                    Puesto.SelectedValue = campos[5];
                    string estado = "";
                    if (campos[4] == "Activo")
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

        protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            string area = Area.SelectedValue;
            llenarcombopuesto(area);
        }
    }
}