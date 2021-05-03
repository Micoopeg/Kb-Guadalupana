using System;
using System.Data;
using KBGuada.Controllers;
using KBGuada.Models;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KBGuada.Views.session
{
    public partial class Av_AsignarTarea : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        ControladorAV cav = new ControladorAV();
        Conexion cn = new Conexion();
        ModeloAV mav = new ModeloAV();
        string AVTITULON;
        string AVNOMBRE;
        string AVAPELLIDO;
        string AVTELEFONO;
        string AVFECHAI;
        string AVFECHAF, fechamin, horamin, fechahora;
        string AVDESC;
        string AVTIPOTAREA, AVPRIORIDAD, AVESTADO, AVACCESO, NOMUSERW, AVMONTO;
        string codigoloteactual;
        string cifactual;
        int num;
        string varestadoprocesocif;
        string cifantiguo;
        string Nombresesion;
        string tarea;
        string concat = "T";
        char delimitador = ':';
        char delimitador2 = ' ';
        string Nombreuser, user;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            NombreUsuario.InnerText = user;
            now();
            if (!IsPostBack)
            {

                llenarcombotipotarea();
                llenarcomboprioridad();
                llenarcomboestado();
                llenarcomboacceso();


            }
        }


        //LLENADO DE COMBOS
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
        public void now()
        {

            string[] fecha = mav.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador);
                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + concat + horas[0] + ":" + horas[1];

                    AVFECHAINI.Attributes.Add("min", fechahora);
                    AVFECHAFIN.Attributes.Add("min", fechahora);

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }

        public void InsertarNTarea()
        {
            if (NOMUSER.Value != "" && CIF.Value != "") {

                string codusuario = cav.obtenercoduser(NOMUSER.Value);

                if (codusuario != "")
                {

                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {

                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }

                    NOMUSERW = NOMUSER.Value;
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
                    string agenda = cav.consultaragenda(cav.obtenercoduser(NOMUSERW));
                    string sig = cav.siguiente("av_tarea", "codavtarea");
                    string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`,`av_monto`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + AVTITULON + "','" + AVNOMBRE + "','" + AVAPELLIDO + "','" + AVTELEFONO + "','" + AVMONTO + "','" + AVFECHAI + "','" + AVFECHAF + "', DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y'),  DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y') , '" + AVDESC + "', '" + AVESTADO + "' , '" + AVPRIORIDAD + "' ,'" + AVTIPOTAREA + "',1, '" + AVACCESO + "' ); ";
                    //string[] tareas = { "", AVTITULON, AVNOMBRE, AVAPELLIDO, AVTELEFONO, AVFECHAI, AVFECHAF, AVDESC, "1", "1", AVTIPOTAREA, "1" };
                    //cav.insertartablas("av_tarea", tareas);
                    cav.insertartarea(sql);

                    insertusertarea(sig, NOMUSERW);
                    //for ( int i = 0; i< tareas.Length; i++) {
                    //    Response.Write(tareas[i]);

                    //}

                }
                else
                {
                    string usher = NOMUSER.Value;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " + usher + " no existe ')", true);
                }
            }
            if (NOMUSER.Value != "" && CIF.Value == "") {

                string codusuario = cav.obtenercoduser(NOMUSER.Value);
              
                if (codusuario != "")
                {

                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {

                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }

                    NOMUSERW = NOMUSER.Value;
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
                    string agenda = cav.consultaragenda(cav.obtenercoduser(NOMUSERW));
                    string sig = cav.siguiente("av_tarea", "codavtarea");
                    string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`,`av_monto`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + AVTITULON + "','" + AVNOMBRE + "','" + AVAPELLIDO + "','" + AVTELEFONO + "','" + AVMONTO + "','" + AVFECHAI + "','" + AVFECHAF + "', DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y'),  DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y') , '" + AVDESC + "', '" + AVESTADO + "' , '" + AVPRIORIDAD + "' ,'" + AVTIPOTAREA + "',1, '" + AVACCESO + "' ); ";
                    //string[] tareas = { "", AVTITULON, AVNOMBRE, AVAPELLIDO, AVTELEFONO, AVFECHAI, AVFECHAF, AVDESC, "1", "1", AVTIPOTAREA, "1" };
                    //cav.insertartablas("av_tarea", tareas);
                    cav.insertartarea(sql);

                    insertusertarea(sig, NOMUSERW);
                    //for ( int i = 0; i< tareas.Length; i++) {
                    //    Response.Write(tareas[i]);

                    //}

                }
                else {
                    string usher = NOMUSER.Value;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " + usher + " no existe ')", true);
                }

            }
            if (NOMUSER.Value == "" && CIF.Value != "") {


                string codusuario = cav.buscarusercif(CIF.Value);

                if (codusuario != "")
                {
                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {

                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }
                    NOMUSERW = NOMUSER.Value;
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
                    string agenda = cav.consultaragenda(cav.obtenercoduser(Nombresesion));
                    string sig = cav.siguiente("av_tarea", "codavtarea");
                    string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`,`av_monto`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + AVTITULON + "','" + AVNOMBRE + "','" + AVAPELLIDO + "','" + AVTELEFONO + "','" + AVMONTO + "','" + AVFECHAI + "','" + AVFECHAF + "', DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y'),  DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y') , '" + AVDESC + "', '" + AVESTADO + "' , '" + AVPRIORIDAD + "' ,'" + AVTIPOTAREA + "',1, '" + AVACCESO + "' ); ";
                    //string[] tareas = { "", AVTITULON, AVNOMBRE, AVAPELLIDO, AVTELEFONO, AVFECHAI, AVFECHAF, AVDESC, "1", "1", AVTIPOTAREA, "1" };
                    //cav.insertartablas("av_tarea", tareas);
                    cav.insertartarea(sql);

                    insertusertarea(sig, Nombresesion);
                    //for ( int i = 0; i< tareas.Length; i++) {
                    //    Response.Write(tareas[i]);

                    //}

                }
                else
                {
                    string usher = Nombresesion;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " + usher + " no existe ')", true);
                }





            }

          


        }
        public void limpiar()
        {

            AVTITULO.Value = "";
            AVPNOMBRE.Value = "";
            AVPAPELLIDO.Value = "";
            AVTEL.Value = "";
            AVFECHAINI.Value = "";
            AVFECHAFIN.Value = "";
            AVDESCRIP.Value = "";



        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {


            if (NOMUSER.Value == "" && CIF.Value == "") { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Debe llenar el campo CIF o el nombre de usuario que incia con PG ')", true); }
            else
            {

                if (DropDownTipoTarea.SelectedIndex == 1)
                {
                    if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || MONTO.Value == "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' LLene los campos Correspondientes NOMBRE, APELLIDO Y TELEFONO ')", true);


                    }
                    else
                    {
                        InsertarNTarea();
                        limpiar();


                        Response.Redirect("AgendaPrin.aspx");

                    }
                }
                else
                {
                    InsertarNTarea();
                    limpiar();

                    Response.Redirect("AgendaPrin.aspx");
                }

            }



        }
        public void insertusertarea(string tareano, string asignado)
        {





            string user = cav.obtenercoduser(asignado);
            string cif = cav.obtenercif(user);
            string sql2 = "INSERT INTO av_controlasignado VALUES ('" + user + "', '" + tareano + "', '" + cif + "' ); ";
            cav.insertartarea(sql2);


        }


    }
}