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
    public partial class Av_ModTarea : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        string tarea;
        string AVTITULON;
        string AVNOMBRE;
        string AVAPELLIDO;
        string AVTELEFONO;
        string AVFECHAI;
        string AVFECHAF;
        string AVDESC, AVMONT;
        string AVTIPOTAREA, AVESTADO, AVPRIORIDAD, AVACCESOS, fechatotal1, fechatotal2;
        string Nombreuser, user;
       string rol;
        
        char delimitador2 = ' ';
        char delimitador3 = ':';
        string concat = "T";
        protected void Page_Load(object sender, EventArgs e)
        {
            string numerotarea = Convert.ToString(Session["NoTarea"]);
            tarea = numerotarea;

            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            NombreUsuario.InnerText = user;
            if (!IsPostBack)
            {

                llenarcombotipotarea();
                llenarcomboprioridad();
                llenarcomboestado();
                llenarcomboacceso();
                obtenerDatosTarea(tarea);
            }

            permisos(cav.obtenercoduser(Nombreuser));

        }
        public void permisos(string usuario)
        {
             rol= cav.consultarRol(usuario);
           
               

                if (rol == "2")
                {
                    DropDownAcceso.Visible = false;
                ASIGHOME.Visible = false;
                DropDownEstado.Visible = false;

            }
            

        }
        public void obtenerDatosTarea(string tarea)
        {

         
            string[] datos = mav.consultadatostarea(tarea);
            try
            {
                for (int i = 0; i < datos.Length; i++)
                {
                    AVTITULO.Value = Convert.ToString(datos.GetValue(2));
                    AVPNOMBRE.Value = Convert.ToString(datos.GetValue(3));
                    AVPAPELLIDO.Value = Convert.ToString(datos.GetValue(4));
                    AVTEL.Value = Convert.ToString(datos.GetValue(5));
                    Monto.Value = Convert.ToString(datos.GetValue(6));
                    string fechaini = Convert.ToString(datos.GetValue(7));
                    string fechaini2 = Convert.ToString(datos.GetValue(8));
                    AVDESCRIP.Value = Convert.ToString(datos.GetValue(11));
                    DropDownEstado.SelectedIndex = Convert.ToInt32(datos.GetValue(12));
                    DropDownPrioridad.SelectedIndex = Convert.ToInt32(datos.GetValue(13));
                    DropDownTipoTarea.SelectedIndex = Convert.ToInt32(datos.GetValue(14));
                    DropDownAcceso.SelectedIndex = Convert.ToInt32(datos.GetValue(16));
                    string[] fechasep = fechaini.Split(delimitador2);

                    string[] horai = fechasep[3].Split(delimitador3);

                    fechatotal1 = fechasep[0] +"-"+ fechasep[1] +"-"+ fechasep[2] + concat + horai[0] + ":" +horai[1];



                    string[] fechafinsep = fechaini2.Split(delimitador2);

                    string[] horaf = fechafinsep[3].Split(delimitador3);



                    fechatotal2 = fechafinsep[0] + "-" + fechafinsep[1] + "-" + fechafinsep[2] + concat + horaf[0] + ":" + horaf[1];

                    AVFECHAINI.Attributes.Add("value", fechatotal1);
                    AVFECHAFIN.Attributes.Add("value", fechatotal2);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
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

        public void modificarTarea(string tarea)
        {
            
            AVTITULON = AVTITULO.Value;
            AVNOMBRE = AVPNOMBRE.Value;
            AVAPELLIDO = AVPAPELLIDO.Value;
            AVTELEFONO = AVTEL.Value;
            AVMONT = Monto.Value;
            AVFECHAI = AVFECHAINI.Value;
            AVFECHAF = AVFECHAFIN.Value;
            AVDESC = AVDESCRIP.Value;
            AVTIPOTAREA = DropDownTipoTarea.SelectedIndex.ToString();
            AVPRIORIDAD = DropDownPrioridad.SelectedIndex.ToString();
            AVESTADO = DropDownEstado.SelectedIndex.ToString();
            AVACCESOS = DropDownAcceso.SelectedIndex.ToString();


            if (AVACCESOS == "0")
            {

                AVACCESOS = "1";
                string sql2 = "SET lc_time_names = 'es_ES'; UPDATE `av_tarea` SET`av_titulo`= '" + AVTITULON + "',`av_pnombre`= '" + AVNOMBRE + "' ,`av_papellido`='" + AVAPELLIDO + "',`av_telefono`='" + AVTELEFONO + "',`av_monto`='" + AVMONT + "' ,`av_fechaini`='" + AVFECHAI + "',`av_fechafin`='" + AVFECHAF + "',`fechaini`= DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y')  ,`fechafin`= DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y'),`av_descripcion`='" + AVDESC + "',`cod_estado`='" + AVESTADO + "',`codprioridad`='" + AVPRIORIDAD + "',`codtipotarea`='" + AVTIPOTAREA + "',`codasociado`='1',`codavpertarea`= '" + AVACCESOS + "'  WHERE codavtarea = '" + tarea + "' ;";
                cav.insertartarea(sql2);
            }
            else {
                string sql2 = "SET lc_time_names = 'es_ES'; UPDATE `av_tarea` SET`av_titulo`= '" + AVTITULON + "',`av_pnombre`= '" + AVNOMBRE + "' ,`av_papellido`='" + AVAPELLIDO + "',`av_telefono`='" + AVTELEFONO + "', `av_monto`='" + AVMONT + "' ,`av_fechaini`='" + AVFECHAI + "',`av_fechafin`='" + AVFECHAF + "',`fechaini`= DATE_FORMAT('" + AVFECHAI + "', '%d %b %Y')  ,`fechafin`= DATE_FORMAT('" + AVFECHAF + "', '%d %b %Y'),`av_descripcion`='" + AVDESC + "',`cod_estado`='" + AVESTADO + "',`codprioridad`='" + AVPRIORIDAD + "',`codtipotarea`='" + AVTIPOTAREA + "',`codasociado`='1',`codavpertarea`= '" + AVACCESOS + "'  WHERE codavtarea = '" + tarea + "' ;";
                cav.insertartarea(sql2);

            }
        


        }
        protected void modificar_Click(object sender, EventArgs e)
        {
            if (rol == "1") {
                if (AVTITULO.Value == "" || AVFECHAINI.Value == "" || AVFECHAFIN.Value == "" || DropDownAcceso.SelectedIndex == 0 || DropDownEstado.SelectedIndex == 0 || DropDownPrioridad.SelectedIndex == 0 || DropDownTipoTarea.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' La tarea debe contener al menos un Titulo, fechas, Prioridad, Tipo, Estado y Acceso ')", true);
                }
                else
                {
                    if (DropDownTipoTarea.SelectedIndex == 1)
                    {
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || Monto.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btnmodi.Enabled = false;
                            modificarTarea(tarea);
                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else
                    {
                        btnmodi.Enabled = false;
                        modificarTarea(tarea);
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
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || Monto.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btnmodi.Enabled = false;
                            modificarTarea(tarea);
                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else
                    {
                        btnmodi.Enabled = false;
                        modificarTarea(tarea);
                        Response.Redirect("AgendaPrin.aspx");


                    }
                }
            }
            else if (rol == "3")
            {
                if (AVTITULO.Value == "" || AVFECHAINI.Value == "" || AVFECHAFIN.Value == "" || DropDownAcceso.SelectedIndex == 0 || DropDownEstado.SelectedIndex == 0 || DropDownPrioridad.SelectedIndex == 0 || DropDownTipoTarea.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' La tarea debe contener al menos un Titulo, fechas, Prioridad, Tipo, Estado y Acceso ')", true);
                }
                else
                {
                    if (DropDownTipoTarea.SelectedIndex == 1)
                    {
                        if (AVPAPELLIDO.Value == "" || AVPNOMBRE.Value == "" || AVTEL.Value == "" || Monto.Value == "")
                        {

                            String script = "alert('LLene los campos Correspondientes NOMBRE, APELLIDO, TELEFONO Y MONTO ')";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else
                        {

                            btnmodi.Enabled = false;
                            modificarTarea(tarea);
                            Response.Redirect("AgendaPrin.aspx");

                        }
                    }
                    else
                    {
                        btnmodi.Enabled = false;
                        modificarTarea(tarea);
                        Response.Redirect("AgendaPrin.aspx");
                    }
                }
            }
            
       


        }


    }
}