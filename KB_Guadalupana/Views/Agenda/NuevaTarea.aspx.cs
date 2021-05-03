using System;
using System.Data;
using KBGuada.Controllers;
using KBGuada.Models;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KBGuada.Views.session
{
    public partial class NuevaTarea : System.Web.UI.Page
    {

        //variables
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        Conexion conexiongeneral = new Conexion();
        string AVTITULON;
        string AVNOMBRE;
        string AVAPELLIDO;
        string AVTELEFONO;
        string AVFECHAI;
        string AVFECHAF, fechamin, horamin, fechahora;
        string AVDESC;
        string AVTIPOTAREA, AVPRIORIDAD, AVESTADO, AVACCESO, AVMONTO;
        string codigoloteactual;
        string cifactual;
        int num;
        string tarea;
        string concat = "T";
        char delimitador = ':';
        char delimitador2 = ' ';
        string Nombreuser, user;
        string rol;
        
        protected void Page_Load(object sender, EventArgs e)
        {


            string numerotarea = Convert.ToString(Session["NoTarea"]);

            tarea = numerotarea;

            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            NombreUsuario.InnerText = user;
            if (Nombreuser != "")
            {
                now();

                permisos(cav.obtenercoduser(Nombreuser));
                if (!IsPostBack)
                {

                    llenarcombotipotarea();
                    llenarcomboprioridad();
                    llenarcomboestado();
                    llenarcomboacceso();


                }

            }
            else {
                Response.Redirect("Error 401.aspx");


            }

        }
        //LLENADO DE COMBOS
        public void permisos(string usuario)
        {
            rol = cav.consultarRol(usuario);
          
               

                if (rol == "2")
                {
                    DropDownAcceso.Visible = false;
                ASIGHOME.Visible = false;
                DropDownEstado.Visible = false;
                }

            
            }
        public void llenarcombotipotarea()
        {
           
           
           
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_tipotarea;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Tarea");
                    DropDownTipoTarea.DataSource = ds;
                    DropDownTipoTarea.DataTextField = "tipotarea";
                    DropDownTipoTarea.DataValueField = "codtipotarea";
                    DropDownTipoTarea.DataBind();
                    DropDownTipoTarea.Items.Insert(0, new ListItem("[Tipo Tarea]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboprioridad()
        {
           
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_prioridad;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Prioridad");
                    DropDownPrioridad.DataSource = ds;
                    DropDownPrioridad.DataTextField = "av_prioridad";
                    DropDownPrioridad.DataValueField = "codprioridad";
                    DropDownPrioridad.DataBind();
                    DropDownPrioridad.Items.Insert(0, new ListItem("[Prioridad]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboestado() 
        {
    
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_estado;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Estado");
                    DropDownEstado.DataSource = ds;
                    DropDownEstado.DataTextField = "av_estado";
                    DropDownEstado.DataValueField = "codestado";
                    DropDownEstado.DataBind();
                    DropDownEstado.Items.Insert(0, new ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcomboacceso()
        {
            
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_permisostarea;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Accesos");
                    DropDownAcceso.DataSource = ds;
                    DropDownAcceso.DataTextField = "av_pertarea";
                    DropDownAcceso.DataValueField = "codavpertarea";
                    DropDownAcceso.DataBind();
                    DropDownAcceso.Items.Insert(0, new ListItem("[Acceso]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        //------FIN DE LLENADO//

        public void insertusertarea(string tareano)
        {




          
            string user = cav.obtenercoduser(Nombreuser);
            string cif = cav.obtenercif(user);
            string sql2 = "INSERT INTO av_controlasignado VALUES ('" + user + "', '" + tareano + "', '" + cif + "' ); ";
            cav.insertartarea(sql2);


        }

      
        public void InsertarNTarea() {

            AVTITULON = AVTITULO.Value;
            AVNOMBRE = AVPNOMBRE.Value;
            AVAPELLIDO = AVPAPELLIDO.Value;
            AVTELEFONO = AVTEL.Value;
            AVMONTO = MONTO.Value;
            AVFECHAI = AVFECHAINI.Value;
            AVFECHAF = AVFECHAFIN.Value;
            AVDESC = AVDESCRIP.Value;
            AVTIPOTAREA = DropDownTipoTarea.SelectedIndex.ToString();
            AVPRIORIDAD = DropDownPrioridad.SelectedIndex.ToString();
            AVESTADO = DropDownEstado.SelectedIndex.ToString();
            AVACCESO = DropDownAcceso.SelectedIndex.ToString();

            if (AVACCESO == "0")
            {
                AVACCESO = "1";
                string agenda = cav.consultaragenda(cav.obtenercoduser(Nombreuser));
                string sig = cav.siguiente("av_tarea", "codavtarea");
                string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`,`av_monto`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + AVTITULON + "','" + AVNOMBRE + "','" + AVAPELLIDO + "',  '" + AVTELEFONO + "','" + AVMONTO + "','" + AVFECHAI + "','" + AVFECHAF + "', DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y'),  DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y') , '" + AVDESC + "', '" + AVESTADO + "' , '" + AVPRIORIDAD + "' ,'" + AVTIPOTAREA + "',1, '" + AVACCESO + "' ); ";

                cav.insertartarea(sql);

                insertusertarea(sig);

            }
            else {

                string agenda = cav.consultaragenda(cav.obtenercoduser(Nombreuser));
                string sig = cav.siguiente("av_tarea", "codavtarea");
                string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`,`av_monto`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + AVTITULON + "','" + AVNOMBRE + "','" + AVAPELLIDO + "','" + AVTELEFONO + "','" + AVMONTO + "','" + AVFECHAI + "','" + AVFECHAF + "', DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y'),  DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y') , '" + AVDESC + "', '" + AVESTADO + "' , '" + AVPRIORIDAD + "' ,'" + AVTIPOTAREA + "',1, '" + AVACCESO + "' ); ";

                cav.insertartarea(sql);

                insertusertarea(sig);
            }

        }
        public void limpiar(){

            AVTITULO.Value = "";
            AVPNOMBRE.Value="";
            AVPAPELLIDO.Value = "";
            AVTEL.Value = "";
            AVFECHAINI.Value = "";
            AVFECHAFIN.Value = "";
            AVDESCRIP.Value = "";



        }
        public void now() {

            string[] fecha = mav.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
         
                    string[] valores2 = fechamin.Split(delimitador2);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador);
                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + concat + horas[0]+":"+horas[1];

                    AVFECHAINI.Attributes.Add("min",fechahora);
                    AVFECHAFIN.Attributes.Add("min",fechahora);

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }

        //click

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string usuario = cav.obtenercoduser(Nombreuser);
              rol = cav.consultarRol(usuario);
            if (rol == "1")
            {
                if (AVTITULO.Value == "" || AVFECHAINI.Value == "" || AVFECHAFIN.Value == "" || DropDownAcceso.SelectedIndex == 0 || DropDownEstado.SelectedIndex == 0 || DropDownPrioridad.SelectedIndex == 0 || DropDownTipoTarea.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' La tarea debe contener al menos un Titulo, fechas, Prioridad, Tipo, Estado y Acceso ')", true);
                }
                else
                {
                    if (DropDownTipoTarea.SelectedIndex == 1)
                    {
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || MONTO.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btninsertar.Enabled = false;
                            InsertarNTarea();
                            limpiar();


                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else
                    {
                        btninsertar.Enabled = false;
                        InsertarNTarea();
                        limpiar();

                        Response.Redirect("AgendaPrin.aspx");
                    }
                }
            }
            else if (rol == "2")
            {
                DropDownAcceso.SelectedIndex = 1;
                DropDownEstado.SelectedIndex = 1;
                if (AVTITULO.Value == "" || AVFECHAINI.Value == "" || AVFECHAFIN.Value == "" || DropDownPrioridad.SelectedIndex == 0 || DropDownTipoTarea.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' La tarea debe contener al menos un Titulo, fechas, Prioridad y Tipo ')", true);
                }
                else
                {
                    if (DropDownTipoTarea.SelectedIndex == 1)
                    {
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || MONTO.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btninsertar.Enabled = false;
                            InsertarNTarea();
                            limpiar();


                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else
                    {
                        btninsertar.Enabled = false;
                        InsertarNTarea();
                        limpiar();

                        Response.Redirect("AgendaPrin.aspx");
                    }
                }
            }
            else if (rol == "3") {
                if (AVTITULO.Value == "" || AVFECHAINI.Value == "" || AVFECHAFIN.Value == "" || DropDownAcceso.SelectedIndex == 0 || DropDownEstado.SelectedIndex == 0 || DropDownPrioridad.SelectedIndex == 0 || DropDownTipoTarea.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' La tarea debe contener al menos un Titulo, fechas, Prioridad, Tipo, Estado y Acceso ')", true);
                }
                else {
                    if (DropDownTipoTarea.SelectedIndex == 1)
                    {
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || MONTO.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btninsertar.Enabled = false;
                            InsertarNTarea();
                            limpiar();


                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else {
                        btninsertar.Enabled = false;
                        InsertarNTarea();
                        limpiar();

                        Response.Redirect("AgendaPrin.aspx");
                    }
                }
            }
            } 

    }
}