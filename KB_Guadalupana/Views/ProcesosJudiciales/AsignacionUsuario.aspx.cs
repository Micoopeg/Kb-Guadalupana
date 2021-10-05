using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class AsignacionUsuario : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombousuarios();
                llenarcomboarea();
                llenarcomborol();
                llenarcomboestado();
                llenarcombopuesto();
                llenarcomboaplicacion();
                infoUsuario.Visible = false;
                Guardar.Visible = false;
                Actualizar.Visible = false;
            }
        }

        public void llenarcombousuarios()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT codgenusuario, gen_usuarionombre FROM gen_usuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Usuario.DataSource = ds;
                    Usuario.DataTextField = "gen_usuarionombre";
                    Usuario.DataValueField = "codgenusuario";
                    Usuario.DataBind();
                    Usuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboarea()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT codgenarea, gen_areanombre FROM gen_area";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Area.DataSource = ds;
                    Area.DataTextField = "gen_areanombre";
                    Area.DataValueField = "codgenarea";
                    Area.DataBind();
                    Area.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomborol()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_rol";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Rol.DataSource = ds;
                    Rol.DataTextField = "pj_rolnombre";
                    Rol.DataValueField = "idpj_rol";
                    Rol.DataBind();
                    Rol.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboestado()
        {
            Estado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
            Estado.Items.Insert(1, new System.Web.UI.WebControls.ListItem("Activo", "1"));
            Estado.Items.Insert(2, new System.Web.UI.WebControls.ListItem("Inactivo", "2"));
        }

        public void llenarcombopuesto()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM gen_puestos";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Puesto.DataSource = ds;
                    Puesto.DataTextField = "gen_puestosnombre";
                    Puesto.DataValueField = "codgenpuestos";
                    Puesto.DataBind();
                    Puesto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_menuopciones";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Aplicacion.DataSource = ds;
                    Aplicacion.DataTextField = "pj_nombreopcion";
                    Aplicacion.DataValueField = "idpj_menuopciones";
                    Aplicacion.DataBind();
                    Aplicacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenargridviewopciones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT B.gen_usuarionombre AS Usuario, C.pj_nombreopcion AS Opcion, A.pj_estado AS Estado FROM pj_asignacionmenu AS A INNER JOIN gen_usuario AS B ON B.codgenusuario = A.idpj_usuario INNER JOIN pj_menuopciones AS C ON C.idpj_menuopciones = A.idpj_opcion WHERE idpj_usuario = '"+Usuario.SelectedValue+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewAsignacion.DataSource = dt;
                    gridViewAsignacion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            string[] infousuarios = sn.obtenerusuarios(Usuario.SelectedValue);

            if(infousuarios[0] == "" || infousuarios[0] == null)
            {
                infoUsuario.Visible = true;
                Guardar.Visible = true;
                Actualizar.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Usuario no encontrado, crear el usuario');", true);
            }
            else
            {
                infoUsuario.Visible = true;
                Area.SelectedValue = infousuarios[2];
                Rol.SelectedValue = infousuarios[3];
                if(infousuarios[4] == "Activo")
                {
                    Estado.SelectedValue = "1";
                }
                else
                {
                    Estado.SelectedValue = "2";
                }

                Puesto.SelectedValue = infousuarios[5];
                Actualizar.Visible = true;
                Guardar.Visible = false;
                llenargridviewopciones();
            }
        }

        protected void Asignar_Click(object sender, EventArgs e)
        {
            string id = sn.siguiente("pj_asignacionmenu", "idpj_asignacionmenu");
            sn.asignaraplicacion(id, Usuario.SelectedValue, Aplicacion.SelectedValue, "Activo");
            llenargridviewopciones();
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Opción asignada');", true);
        }

        protected void Desasignar_Click(object sender, EventArgs e)
        {
            sn.actualizarasignacion(Usuario.SelectedValue, Aplicacion.SelectedValue, "Inactivo");
            llenargridviewopciones();
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Opción asignada');", true);
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string id = sn.siguiente("pj_controlingreso", "idpj_controlingreso");
            string estado;
            if(Estado.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }

            sn.agregarcontrolingreso(id, Usuario.SelectedValue, Area.SelectedValue, Rol.SelectedValue, estado, Puesto.SelectedValue);

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se ha guardado exitosamente');", true);
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            string estado;

            if(Estado.SelectedValue == "1")
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }

            sn.actualizarcontrolingreso(Usuario.SelectedValue, Area.SelectedValue, Rol.SelectedValue, estado, Puesto.SelectedValue);

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se ha actualizado exitosamente');", true);
        }
    }
}