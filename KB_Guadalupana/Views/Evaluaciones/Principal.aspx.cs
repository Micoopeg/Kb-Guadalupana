using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WebForms;

namespace KB_Guadalupana.Views.Evaluaciones
{
    public partial class Principal : System.Web.UI.Page
    {
        ModeloSQ msq = new ModeloSQ();
        string fechamin, fechahora;
        char delimitador2 = ' ';
        Conexion conexiongeneral = new Conexion();
        string horamin, fechamin2, fechahora2, fechatotal1, fechatotal2;
        char delimitador = ' ';
        char delimitador3 = ':';
        char delimitador4 = '/';
        string concat = "T";
        protected void Page_Load(object sender, EventArgs e)
        {
            now();
            now2();

            if (!IsPostBack) {
                llenarcomboevaluado();
                llenarcomboevaluador();
                llenarcomboestadopregunta();
                llenarcomboevaluacion();
                llenarcomboorden();
                llenarcombotipo();
                llenarcomboestadoescala();
                llenarcomboescaladatos();
                llenarcomboestadoescaladatos();
                llenarpuestos();
                llenarevaluadores();
                llenarpreguntas();
                llenarescalas();
                llenarescala();
                llenarescalasdatos();
                llenarescalasdatos();
                llenarcomboevaluacionesmod();
                llenarestadoevalcrear();
                llenarcombotipoevalmod();
                llenarestadoevalcrea();
                llenarcombotipoevalcrear();
            }
        }

        //PREGUNTASPROGRA
        public void llenarpreguntas()
        {

            DataTable dt1 = new DataTable();

            dt1 = msq.llenarpreguntastab();
            DGVPREGUNTAS.DataSource = dt1;
            DGVPREGUNTAS.DataBind();

        }

        public void ingresarpregunta()
        {

            if (titulopregunta.Value != "" && infoextrapregunta.Value != "" && dropestado.SelectedIndex == 0 && dropeval.SelectedIndex == 0 && droporden.SelectedIndex == 0 && droptipo.SelectedIndex == 0)
            {
                string sig2 = msq.obtenerfinal("sq_preguntas", "codsqpregunta");
                string sql = "INSERT INTO `sq_preguntas`(`codsqpregunta`, `pregunta`, `InfoExtrapregunta`, `codsqeval`, `codsqtipopregunta`, `ordenpregunta`, `estado`, `codsqescala`) VALUES ('" + sig2+"','"+titulopregunta.Value+"','"+infoextrapregunta.Value+"','"+dropeval.SelectedValue+"','"+droptipo.SelectedValue+"','"+droporden.SelectedValue+"','"+dropestado.SelectedValue+"', '"+dropescala.SelectedValue+"');";

                msq.Insertar(sql);
                titulopregunta.Value = "";
                infoextrapregunta.Value = "";
                droptipo.SelectedIndex = 0;
                droporden.SelectedIndex = 0;
                dropeval.SelectedIndex = 0;
                dropestado.SelectedIndex = 0;
                dropescala.SelectedIndex = 0;
                llenarpreguntas();
            }
            else
            {
                String script = "alert('Llene los datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }
        public void llenarcomboestadopregunta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_estadopregunta`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropestado.DataSource = ds;
                    dropestado.DataTextField = "estado";
                    dropestado.DataValueField = "codsqestadopregunta";
                    dropestado.DataBind();
                    dropestado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_tipopregunta`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    droptipo.DataSource = ds;
                    droptipo.DataTextField = "tipopregunta";
                    droptipo.DataValueField = "codqstipopregunta";
                    droptipo.DataBind();
                    droptipo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Tipo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboevaluacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_evaluacion`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropeval.DataSource = ds;
                    dropeval.DataTextField = "nombreevaluacion";
                    dropeval.DataValueField = "codsqeval";
                    dropeval.DataBind();
                    dropeval.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Fecha de evaluación]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboorden()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_orden`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    droporden.DataSource = ds;
                    droporden.DataTextField = "ordenes";
                    droporden.DataValueField = "codsqorden";
                    droporden.DataBind();
                    droporden.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Orden]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarescala()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_escalapregunta`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropescala.DataSource = ds;
                    dropescala.DataTextField = "nombreescala";
                    dropescala.DataValueField = "codsqescala";
                    dropescala.DataBind();
                    dropescala.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Escala]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void btninsertpregunta_Click(object sender, EventArgs e)
        {

            ingresarpregunta();

        }

        protected void DGVPREGUNTAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codpuesto = (DGVPREGUNTAS.SelectedRow.FindControl("idpregunta") as Label).Text;
            string[] datos2 = msq.preguntas(codpuesto);
            btnmodpregunta.Visible = true;
            btneliminarpregunta.Visible = true;
            btnpreguntasinsert.Visible = false;
            for (int j = 0; j < datos2.Length; j++)
            {
                titulopregunta.Value = Convert.ToString(datos2.GetValue(1));
                infoextrapregunta.Value = Convert.ToString(datos2.GetValue(2));
                dropeval.SelectedValue = Convert.ToString(datos2.GetValue(3));
                droptipo.SelectedValue = Convert.ToString(datos2.GetValue(4));
                droporden.SelectedValue   = Convert.ToString(datos2.GetValue(5));
                dropestado.SelectedValue = Convert.ToString(datos2.GetValue(6));
                dropescala.SelectedValue = Convert.ToString(datos2.GetValue(7));





            }

        }

        protected void DGVPREGUNTAS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVPREGUNTAS.PageIndex = e.NewPageIndex;
            llenarpreguntas();
        }

        protected void btnmodificarpregunta_Click(object sender, EventArgs e)
        {
            string codpregunta = (DGVPREGUNTAS.SelectedRow.FindControl("idpregunta") as Label).Text;
            if (codpregunta != "" && titulopregunta.Value != "" && infoextrapregunta.Value != "" && dropestado.SelectedIndex != 0 && dropeval.SelectedIndex != 0 && droporden.SelectedIndex != 0 && droptipo.SelectedIndex != 0)
            {
                string mod = "UPDATE `sq_preguntas` SET `pregunta`= '" + titulopregunta.Value + "',`InfoExtrapregunta`= '" + infoextrapregunta.Value + "' ,`codsqeval`= '" + dropeval.SelectedValue + "',`codsqtipopregunta`= '" + droptipo.SelectedValue + "',`ordenpregunta`='" + droporden.SelectedValue+"',`estado`= '"+dropestado.SelectedValue+ "' ,`codsqescala`= '"+dropescala.SelectedValue+"' WHERE codsqpregunta = '" + codpregunta+"'  ";
                msq.Insertar(mod);
                titulopregunta.Value = "";
                infoextrapregunta.Value = "";
                droptipo.SelectedIndex = 0;
                droporden.SelectedIndex = 0;
                dropeval.SelectedIndex = 0;
                dropestado.SelectedIndex = 0;
                btnmodpregunta.Visible = false;
                btneliminarpregunta.Visible = false;
                btnpreguntasinsert.Visible = true;
                llenarpreguntas();
            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        protected void btneliminarpregunta_Click(object sender, EventArgs e)
        {
            string codpregunta = (DGVPREGUNTAS.SelectedRow.FindControl("idpregunta") as Label).Text;
            if (codpregunta != "")
            {
                string updatedelete = "UPDATE `sq_preguntas` SET `estado`= 0 WHERE codsqpregunta = '" + codpregunta + "' ";
                msq.Insertar(updatedelete);
                btnmodpregunta.Visible = false;
                btneliminarpregunta.Visible = false;
                btnpreguntasinsert.Visible = true;
                titulopregunta.Value = "";
                infoextrapregunta.Value = "";
                droptipo.SelectedIndex = 0;
                droporden.SelectedIndex = 0;
                dropeval.SelectedIndex = 0;
                dropestado.SelectedIndex = 0;
                llenarpreguntas();

            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        }



        //EVALUADORPROGRA
        public void llenarevaluadores()
        {

            DataTable dt1 = new DataTable();

            dt1 = msq.llenarasignadosevaluadores();
            dgvevaluadores.DataSource = dt1;
            dgvevaluadores.DataBind();

        }
        public void llenarcomboevaluador()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_puestoseval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dgvevaluador.DataSource = ds;
                    dgvevaluador.DataTextField = "puestodescrip";
                    dgvevaluador.DataValueField = "codsqpuesto";
                    dgvevaluador.DataBind();
                    dgvevaluador.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Puestos]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboevaluado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_puestoseval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dgvevaluado.DataSource = ds;
                    dgvevaluado.DataTextField = "puestodescrip";
                    dgvevaluado.DataValueField = "codsqpuesto";
                    dgvevaluado.DataBind();
                    dgvevaluado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Puestos]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        void insertarevaluadores() {

            if (dgvevaluado.SelectedIndex != 0 || dgvevaluador.SelectedIndex != 0)
            {
                string sig = msq.obtenerfinal("sq_organigrama", "codsqorganigrama");
                string inst = "INSERT INTO `sq_organigrama`(`codsqorganigrama`, `codsqpuesto`, `organisup`) VALUES ( '"+sig+"', '"+dgvevaluador.SelectedValue+"','"+dgvevaluado.SelectedValue+"'  )";
                msq.Insertar(inst);
                dgvevaluado.SelectedIndex = 0;
                dgvevaluador.SelectedIndex = 0;
                llenarevaluadores();
            }
            else {
                String script = "alert('Seleccione ambos datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        
        }
        protected void btninsertarevalua_Click(object sender, EventArgs e)
        {
            insertarevaluadores();

        }

        protected void btnmodevalua_Click(object sender, EventArgs e)
        {
            string codasignado = (dgvevaluadores.SelectedRow.FindControl("idasignado") as Label).Text;
            {
                if (dgvevaluado.SelectedIndex != 0 || dgvevaluador.SelectedIndex != 0)
                {
                    string sig = msq.obtenerfinal("sq_organigrama", "codsqorganigrama");
                    string inst = "UPDATE `sq_organigrama` SET `codsqpuesto`= '"+dgvevaluador.SelectedValue+"',`organisup`= '"+dgvevaluado.SelectedValue+"' WHERE codsqorganigrama = '"+codasignado+"' ";
                    msq.Insertar(inst);
                    btninsertarevalua.Visible = true;
                    btneliminarevalua.Visible = false;
                    btnmodevalua.Visible = false;
                    dgvevaluado.SelectedIndex = 0;
                    dgvevaluador.SelectedIndex = 0;
                    llenarevaluadores();
                }
                else
                {
                    String script = "alert('Seleccione ambos datos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                }
            }
        }
        protected void btneliminarevalua_Click(object sender, EventArgs e)
        {
            string codasignado = (dgvevaluadores.SelectedRow.FindControl("idasignado") as Label).Text;
            if (dgvevaluado.SelectedIndex != 0 || dgvevaluador.SelectedIndex != 0)
            {
                string sig = msq.obtenerfinal("sq_organigrama", "codsqorganigrama");
                string inst = "DELETE FROM `sq_organigrama` WHERE codsqorganigrama = '" + codasignado + "' ";
                msq.Insertar(inst);
                btninsertarevalua.Visible = true;
                btneliminarevalua.Visible = false;
                btnmodevalua.Visible = false;
                dgvevaluado.SelectedIndex = 0;
                dgvevaluador.SelectedIndex = 0;
                llenarevaluadores();
            }
            else
            {
                String script = "alert('Seleccione ambos datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        }

        protected void dgvevaluadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvevaluadores.PageIndex = e.NewPageIndex;
            llenarevaluadores();

        }
        protected void dgvevaluadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codasignado = (dgvevaluadores.SelectedRow.FindControl("idasignado") as Label).Text;
            string[] datos2 = msq.datosasignado(codasignado);
            btnmodevalua.Visible = true;
            btneliminarevalua.Visible = true;
            btninsertarevalua.Visible = false;
            for (int j = 0; j < datos2.Length; j++)
            {
                dgvevaluador.SelectedValue = Convert.ToString(datos2.GetValue(1));
                dgvevaluado.SelectedValue = Convert.ToString(datos2.GetValue(2));




            }

        }
        //PUESTOSPROGRA
        public void llenarpuestos()
        {

            DataTable dt1 = new DataTable();
       
            dt1 = msq.llenarmesamesaasignado();
            DGVPUESTOS.DataSource = dt1;
            DGVPUESTOS.DataBind();

        }
        public void ingresarpuesto()
        {

            if (puesto.Value != "" || cantidad.Value != "")
            {
                string sig = msq.obtenerfinal("sq_puestoseval", "codsqpuesto");
                string sql = "INSERT INTO `sq_puestoseval`(`codsqpuesto`, `puestodescrip`, `puestocant`) VALUES ( '" + sig + "','" + puesto.Value + "','" + cantidad.Value + "' );";

                msq.Insertar(sql);
                puesto.Value = "";
                cantidad.Value = "";
                llenarpuestos();
            }
            else {
                String script = "alert('Llene los datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }
        protected void btnpuestos_Click(object sender, EventArgs e)
        {

            ingresarpuesto();

        }

        protected void DGVPUESTOS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVPUESTOS.PageIndex = e.NewPageIndex;
            llenarpuestos();
        }

        protected void DGVPUESTOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codpuesto = (DGVPUESTOS.SelectedRow.FindControl("idpuesto") as Label).Text;
            string[] datos2 = msq.datospuesto(codpuesto);
            btnmodificar.Visible = true;
            btneliminar.Visible = true;
            btninserta.Visible = false;
            for (int j = 0; j < datos2.Length; j++)
            {
                puesto.Value = Convert.ToString(datos2.GetValue(1));
                cantidad.Value = Convert.ToString(datos2.GetValue(2));




            }

        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            string codpuesto = (DGVPUESTOS.SelectedRow.FindControl("idpuesto") as Label).Text;
            if (codpuesto!="" && puesto.Value!="" && cantidad.Value!= "") {
                string mod = "UPDATE `sq_puestoseval` SET  `puestodescrip`= '" + puesto.Value + "' ,`puestocant`= '" + cantidad.Value + "' WHERE codsqpuesto =  '" + codpuesto + "'  ";
                msq.Insertar(mod);
                puesto.Value = "";
                cantidad.Value = "";
                btnmodificar.Visible = false;
                btneliminar.Visible = false;
                btninserta.Visible = true;
                llenarpuestos(); }
            else {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

   

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            string codpuesto = (DGVPUESTOS.SelectedRow.FindControl("idpuesto") as Label).Text;
            if (codpuesto != "")
            {
                string updatedelete = "DELETE FROM `sq_puestoseval` WHERE 	codsqpuesto = '" + codpuesto + "' ; ";
                msq.Insertar(updatedelete);
                btnmodificar.Visible = false;
                btneliminar.Visible = false;
                btninserta.Visible = true;
                puesto.Value = "";
                cantidad.Value = "";
                llenarpuestos();

            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        }


        //DASHBOARDPROGRA
        public void now()
        {

            string[] fecha = msq.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[2] + "/" + valores2[1] + "/" + valores2[0];

                    Date.InnerText = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }

      



        //ESCALASPROGRA

        public void llenarescalas()
        {

            DataTable dt1 = new DataTable();

            dt1 = msq.llenarescalas();
            DGVESCALAS.DataSource = dt1;
            DGVESCALAS.DataBind();

        }

        protected void DGVESCALAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codpuesto = (DGVESCALAS.SelectedRow.FindControl("idescala") as Label).Text;
            string[] datos2 = msq.datosescala(codpuesto);
            btnmodescala.Visible = true;
            btnelimescala.Visible = true;
            btninsertescala.Visible = false;
            for (int j = 0; j < datos2.Length; j++)
            {
                nombreescala.Value = Convert.ToString(datos2.GetValue(1));
                dropestadoescala.SelectedValue = Convert.ToString(datos2.GetValue(2));




            }

        }

        protected void btninsertescala_Click(object sender, EventArgs e)
        {
            if (dropestadoescala.SelectedIndex != 0 && nombreescala.Value != "")
            {
                string sig = msq.obtenerfinal("sq_escalapregunta", "codsqescala");
                string inst = "INSERT INTO `sq_escalapregunta`(`codsqescala`, `nombreescala`, `estadoescala`) VALUES ( '"+sig+"','"+nombreescala.Value+"','"+dropestadoescala.SelectedValue+"')";
                msq.Insertar(inst);
                dropestadoescala.SelectedIndex = 0;
                nombreescala.Value = "";
                llenarescalas();
            }
            else
            {
                String script = "alert('Complete los  datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }

        }

        protected void btnmodescala_Click(object sender, EventArgs e)
        {
            string codescala = (DGVESCALAS.SelectedRow.FindControl("idescala") as Label).Text;
            if (codescala != "" && dropestadoescala.SelectedIndex != 0 && nombreescala.Value != "")
            {
                string mod = "UPDATE `sq_escalapregunta` SET `nombreescala`= '"+nombreescala.Value+"',`estadoescala`= '"+dropestadoescala.SelectedValue+"' WHERE  codsqescala = '"+codescala+"' ";
                msq.Insertar(mod);
                dropestadoescala.SelectedIndex = 0;
                nombreescala.Value = "";
                btnmodescala.Visible = false;
                btnelimescala.Visible = false;
                btninsertescala.Visible = true;
                llenarescalas();
            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        protected void btnelimescala_Click(object sender, EventArgs e)
        {
            string codescala = (DGVESCALAS.SelectedRow.FindControl("idescala") as Label).Text;
            if (codescala != "" && dropestadoescala.SelectedIndex != 0 && nombreescala.Value != "")
            {
                string mod = "UPDATE `sq_escalapregunta` SET `estadoescala`= 2 WHERE  codsqescala = '" + codescala + "' ";
                msq.Insertar(mod);
                dropestadoescala.SelectedIndex = 0;
                nombreescala.Value = "";
                btnmodescala.Visible = false;
                btnelimescala.Visible = false;
                btninsertescala.Visible = true;
                llenarescalas();
            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }

        protected void DGVESCALAS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVESCALAS.PageIndex = e.NewPageIndex;
            llenarescalas();
        }

       
        public void llenarcomboestadoescala()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_estadoeval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropestadoescala.DataSource = ds;
                    dropestadoescala.DataTextField = "estadoeval";
                    dropestadoescala.DataValueField = "codsqlesteval";
                    dropestadoescala.DataBind();
                    dropestadoescala.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        //ESCALADATOSPROGRA
        public void llenarescalasdatos()
        {

            DataTable dt1 = new DataTable();

            dt1 = msq.llenarescalasdatos();
            DGVDATOSESC.DataSource = dt1;
            DGVDATOSESC.DataBind();

        }
        public void llenarcomboestadoescaladatos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_estadoeval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropestadodatos.DataSource = ds;
                    dropestadodatos.DataTextField = "estadoeval";
                    dropestadodatos.DataValueField = "codsqlesteval";
                    dropestadodatos.DataBind();
                    dropestadodatos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboescaladatos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_escalapregunta`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropescaladatos.DataSource = ds;
                    dropescaladatos.DataTextField = "nombreescala";
                    dropescaladatos.DataValueField = "codsqescala";
                    dropescaladatos.DataBind();
                    dropescaladatos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Escala]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void DGVDATOSESC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codpuesto = (DGVDATOSESC.SelectedRow.FindControl("idescaladatos") as Label).Text;
            string[] datos2 = msq.datosescaladatos(codpuesto);
            btnmodescaladatos.Visible = true;
            btneliminarescaladatos.Visible = true;
            btninsertescaladatos.Visible = false;
            for (int j = 0; j < datos2.Length; j++)
            {
                dropescaladatos.SelectedValue = Convert.ToString(datos2.GetValue(1));
                rangonumerico.Value = Convert.ToString(datos2.GetValue(2));
                valortextual.Value = Convert.ToString(datos2.GetValue(3));
                dropestadodatos.SelectedValue = Convert.ToString(datos2.GetValue(4));
            



            }
        }

        protected void btninsertescaladatos_Click(object sender, EventArgs e)
        {
            if (rangonumerico.Value !="" && valortextual.Value != "" && dropescaladatos.SelectedIndex != 0 && dropestadodatos.SelectedIndex != 0)
            {
                string sig = msq.obtenerfinal("sq_escala", "codsqescalaid");
                string inst = "INSERT INTO `sq_escala`(`codsqescalaid`, `codsqescala`, `rangonumerico`, `valortexto`, `estado`) VALUES ('"+sig+"','"+dropescaladatos.SelectedValue+"', '"+rangonumerico.Value+"','"+valortextual.Value+"' ,'"+dropestadodatos.SelectedValue+"') ";
                msq.Insertar(inst);
                rangonumerico.Value = "";
                valortextual.Value = "";
               
                dropestadodatos.SelectedIndex = 0;
                llenarescalasdatos();
            }
            else
            {
                String script = "alert('Complete los Campos datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }

        }

        protected void btnmodescaladatos_Click(object sender, EventArgs e)
        {
            string codescala = (DGVDATOSESC.SelectedRow.FindControl("idescaladatos") as Label).Text;
            if (codescala != "" && rangonumerico.Value != "" && valortextual.Value != "" && dropescaladatos.SelectedIndex != 0 && dropestadodatos.SelectedIndex != 0)
            {
                string mod = "UPDATE `sq_escala` SET `codsqescala`='"+dropescaladatos.SelectedValue+"',`rangonumerico`='"+rangonumerico.Value+"',`valortexto`= '"+valortextual.Value+"',`estado`='"+dropestadodatos.SelectedValue+"' WHERE codsqescalaid = '" + codescala + "' ";
                msq.Insertar(mod);
                valortextual.Value = "";
                rangonumerico.Value = "";
                dropestadodatos.SelectedIndex = 0;
                dropescaladatos.SelectedIndex = 0;
                btnmodescaladatos.Visible = false;
                btneliminarescaladatos.Visible = false;
                btninsertescaladatos.Visible = true;
                llenarescalasdatos();
            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        protected void btnelimescaladatos_Click(object sender, EventArgs e)
        {
            string codescala = (DGVDATOSESC.SelectedRow.FindControl("idescaladatos") as Label).Text;
            if (codescala != "" && rangonumerico.Value != "" && valortextual.Value != "" && dropescaladatos.SelectedIndex != 0 && dropestadodatos.SelectedIndex != 0)
            {
                string mod = "UPDATE `sq_escala` SET `estado`='" + dropestadodatos.SelectedValue + "' WHERE codsqescalaid = '" + codescala + "' ";
                msq.Insertar(mod);
                valortextual.Value = "";
                rangonumerico.Value = "";
                dropestadodatos.SelectedIndex = 0;
                dropescaladatos.SelectedIndex = 0;
                btnmodescaladatos.Visible = false;
                btneliminarescaladatos.Visible = false;
                btninsertescaladatos.Visible = true;
                llenarescalasdatos();
            }
            else
            {
                String script = "alert('Ningun registro seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }


        public void buscardatosescala() {
            DataTable dtb = new DataTable();
            string buscar = "SELECT sqe.codsqescalaid, sqep.nombreescala,sqe.rangonumerico, sqe.valortexto ,sqeval.estadoeval FROM sq_escala sqe INNER JOIN sq_escalapregunta sqep ON sqe.codsqescala = sqep.codsqescala INNER JOIN sq_estadoeval sqeval ON sqeval.codsqlesteval = sqe.estado WHERE sqe.rangonumerico LIKE '%" + bbuscar.Text.Trim() + "%' AND sqe.valortexto LIKE '%" + buscartexto.Text.Trim() + "%' AND sqep.nombreescala LIKE '%" + escalanombrebus.Text.Trim() + "%'  ";
            dtb = msq.buscarentablas(buscar);
            DGVDATOSESC.DataSource = dtb;
            DGVDATOSESC.DataBind();

        }
        protected void buscardatos_Click(object sender, EventArgs e)
        {

            buscardatosescala();
        }

        protected void DGVDATOSESC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVDATOSESC.PageIndex = e.NewPageIndex;
            buscardatosescala();
        }

        //CREARECALUACIONPROGRA

        public void llenarestadoevalcrea()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_estadoeval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropestadoevaluacion.DataSource = ds;
                    dropestadoevaluacion.DataTextField = "estadoeval";
                    dropestadoevaluacion.DataValueField = "codsqlesteval";
                    dropestadoevaluacion.DataBind();
                    dropestadoevaluacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipoevalcrear()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_tipoevaluacion`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    droptipoevalmod.DataSource = ds;
                    droptipoevalmod.DataTextField = "tipoevaluacion";
                    droptipoevalmod.DataValueField = "codsqtipoeval";
                    droptipoevalmod.DataBind();
                    droptipoevalmod.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Tipo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }




        //MODEVALUAPROGRA

        public void now2()
        {

            string[] fecha = msq.datetime2();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin2 = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador3);
                    fechahora2 = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + concat + horas[0] + ":" + horas[1];

                    fechainicial.Attributes.Add("min", fechahora2);
                    fechafinal.Attributes.Add("min", fechahora2);

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }


        public void llenarcomboevaluacionesmod()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_evaluacion`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropevaluacionexistente.DataSource = ds;
                    dropevaluacionexistente.DataTextField = "nombreevaluacion";
                    dropevaluacionexistente.DataValueField = "codsqeval";
                    dropevaluacionexistente.DataBind();
                    dropevaluacionexistente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Evaluación]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void dropevaluacionexistente_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerDatoseval(dropevaluacionexistente.SelectedValue);

        }
        private DataTable obtenernotas()
        {
            DataTable dt3 = new DataTable();






            dt3 = msq.repodatanotas();






            return dt3;



        }
        private DataTable obtenerpendientes()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            dt4.Columns.Add("COD");
            dt4.Columns.Add("CIF");
            dt4.Columns.Add("NOMBRE");
            dt4.Columns.Add("PUESTO");
            dt4.Columns.Add("GERENCIA");
            dt4.Columns.Add("EVALUACIONES_A_CARGO");
            dt4.Columns.Add("EVALUACION_PROPIA");
            dt4.Columns.Add("EVALUACION_JEFE");
            dt4.Columns.Add("EVALUACIONES_COMPLETADAS");

            dt3 = msq.reportependientes();

            foreach (DataRow dtRow in dt3.Rows)
            {
                // On all tables' columns
                DataRow row = dt4.NewRow();
                var dato = dtRow["PUESTO"].ToString();
                if (dato == "COORDINADOR DE AGENCIAS")
                {



                    row["COD"] = dtRow["COD"].ToString();
                    row["CIF"] = dtRow["CIF"].ToString();
                    row["NOMBRE"] = dtRow["NOMBRE"].ToString();
                    row["PUESTO"] = dtRow["PUESTO"].ToString();
                    row["GERENCIA"] = dtRow["GERENCIA"].ToString();
                    row["EVALUACIONES_A_CARGO"] = "20";
                    row["EVALUACION_PROPIA"] = dtRow["EVALUACION_PROPIA"].ToString();
                    row["EVALUACION_JEFE"] = dtRow["EVALUACION_JEFE"].ToString();
                    row["EVALUACIONES_COMPLETADAS"] = dtRow["EVALUACIONES_COMPLETADAS"].ToString();





                    dt4.Rows.Add(row);




                }
                else
                {
                    row["COD"] = dtRow["COD"].ToString();
                    row["CIF"] = dtRow["CIF"].ToString();
                    row["NOMBRE"] = dtRow["NOMBRE"].ToString();
                    row["PUESTO"] = dtRow["PUESTO"].ToString();
                    row["GERENCIA"] = dtRow["GERENCIA"].ToString();
                    row["EVALUACIONES_A_CARGO"] = dtRow["EVALUACIONES_A_CARGO"].ToString();
                    row["EVALUACION_PROPIA"] = dtRow["EVALUACION_PROPIA"].ToString();
                    row["EVALUACION_JEFE"] = dtRow["EVALUACION_JEFE"].ToString();
                    row["EVALUACIONES_COMPLETADAS"] = dtRow["EVALUACIONES_COMPLETADAS"].ToString();
                    dt4.Rows.Add(row);

                }

            }






            return dt4;



        }



       


        private DataTable notastodos2()
        {
            double notauto, notajefe, notasubal;
            double notafin;
            double[] notassubs;
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt3 = msq.notastodos();
            dt4.Columns.Add("cod");
            dt4.Columns.Add("EVALUADO");
            dt4.Columns.Add("unidadoperativa");
            dt4.Columns.Add("gerencia");
            dt4.Columns.Add("PUESTO_EVALUADO");
            dt4.Columns.Add("Fecha_Ingreso");
            dt4.Columns.Add("auto");
            dt4.Columns.Add("subal");
            dt4.Columns.Add("jefeinmed");
            dt4.Columns.Add("NOTAFINAL");

            dt3 = msq.notastodos();

            string[] usuarios = msq.obtenerusuariosrepofinal();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow row = dt4.NewRow();

                string iduser = Convert.ToString(usuarios.GetValue(i));



                string notaauto15 = Convert.ToString(msq.autototal15(iduser));
                string notaauto613 = Convert.ToString(msq.autototal613(iduser));
                string notaauto1420 = Convert.ToString(msq.autototal1420(iduser));

                string notajefe15 = Convert.ToString(msq.jefetotal15(iduser));
                string notajefe613 = Convert.ToString(msq.jefetotal613(iduser));
                string notajefe1420 = Convert.ToString(msq.jefetotal1420(iduser));

                string notasubal15 = Convert.ToString(msq.subaltotal15(iduser));
                string notasubal613 = Convert.ToString(msq.subaltotal613(iduser));
                string notasubal1420 = Convert.ToString(msq.subaltotal1420(iduser));


                if (notaauto15 == "" || notaauto613 == "" || notajefe15 == "" || notajefe613 == "")
                {


                    notauto = 0;

                }
                if (notaauto1420 == "" && notaauto15 != "" && notaauto613 != "" && notajefe15 != "" && notajefe613 != "" && notajefe1420 == "")
                {
                    notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613)) / 2;
                    notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613)) / 2;
                    notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2)) / 2;

                    row["cod"] = dt3.Rows[i][0].ToString();
                    row["EVALUADO"] = dt3.Rows[i][1].ToString();
                    row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                    row["gerencia"] = dt3.Rows[i][3].ToString();
                    row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                    row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                    row["auto"] = Math.Round(notauto, 2);
                    row["subal"] = "0";
                    row["jefeinmed"] = Math.Round(notajefe, 2);
                    row["NOTAFINAL"] = Math.Round(notafin, 2);
                    dt4.Rows.Add(row);


                }

                if (notaauto1420 != "" && notaauto613 != "" && notaauto15 != "" && notajefe1420 != "" && notajefe613 != "" && notajefe15 != "")
                {
                    notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613) + Convert.ToDouble(notaauto1420)) / 3;
                    notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613) + Convert.ToDouble(notajefe1420)) / 3;
                    notasubal = (Convert.ToDouble(notasubal15) + Convert.ToDouble(notasubal613) + Convert.ToDouble(notasubal1420)) / 3;
                    notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2) + Math.Round(notasubal, 2)) / 3;
                    row["cod"] = dt3.Rows[i][0].ToString();
                    row["EVALUADO"] = dt3.Rows[i][1].ToString();
                    row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                    row["gerencia"] = dt3.Rows[i][3].ToString();
                    row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                    row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                    row["auto"] = Math.Round(notauto, 2);
                    row["subal"] = Math.Round(notasubal, 2);
                    row["jefeinmed"] = Math.Round(notajefe, 2);
                    row["NOTAFINAL"] = Math.Round(notafin, 2);
                    dt4.Rows.Add(row);

                }








            }











            return dt4;



        }

        private DataTable notastodos3()
        {
            double notauto, notajefe, notasubal;
            double notafin;
            double[] notassubs;
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt3 = msq.notastodos();
            dt4.Columns.Add("cod");
            dt4.Columns.Add("EVALUADO");
            dt4.Columns.Add("unidadoperativa");
            dt4.Columns.Add("gerencia");
            dt4.Columns.Add("PUESTO_EVALUADO");
            dt4.Columns.Add("Fecha_Ingreso");
            dt4.Columns.Add("auto");
            dt4.Columns.Add("subal");
            dt4.Columns.Add("jefeinmed");
            dt4.Columns.Add("NOTAFINAL");

            dt3 = msq.notastodos();

            string[] usuarios = msq.obtenerusuariosrepofinal();

            int dato = usuarios.Length;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                notauto = 0;
                notajefe = 0;
                notasubal = 0;
                notafin = 0;
                DataRow row = dt4.NewRow();
               
                string iduser = Convert.ToString(usuarios.GetValue(i));
                string puestos = msq.obtenerpuestoid(iduser);
                if (puestos == "83" || puestos == "76")
                {
                    string notaauto15 = Convert.ToString(msq.autototal15(iduser));
                    string notaauto613 = Convert.ToString(msq.autototal613(iduser));
                    string notaauto1420 = Convert.ToString(msq.autototal1420(iduser));

                    string notajefe15 = Convert.ToString(msq.jefetotal15mod(iduser));
                    string notajefe613 = Convert.ToString(msq.jefetotal613mod(iduser));
                    string notajefe1420 = Convert.ToString(msq.jefetotal1420mod(iduser));

                    string notasubal15 = Convert.ToString(msq.subaltotal15(iduser));
                    string notasubal613 = Convert.ToString(msq.subaltotal613(iduser));
                    string notasubal1420 = Convert.ToString(msq.subaltotal1420(iduser));



                    if (notaauto1420 == "" && notaauto15 != "" && notaauto613 != "" && notajefe15 != "" && notajefe613 != "" && notajefe1420 == "")
                    {
                        notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613)) / 2;
                        notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613)) / 2;
                        notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2)) / 2;
                        if (notauto != 0 && notajefe != 0 && notafin != 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = Math.Round(notauto, 2);
                            row["subal"] = "0";
                            row["jefeinmed"] = Math.Round(notajefe, 2);
                            row["NOTAFINAL"] = Math.Round(notafin, 2);
                            dt4.Rows.Add(row);
                        }
                        if (notauto == 0 || notajefe == 0 || notafin == 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = "0";
                            row["subal"] = "0";
                            row["jefeinmed"] = "0";
                            row["NOTAFINAL"] = "0";
                            dt4.Rows.Add(row);
                        }

                    }

                    if (notaauto1420 != "" && notaauto613 != "" && notaauto15 != "" && notajefe1420 != "" && notajefe613 != "" && notajefe15 != "")
                    {
                        notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613) + Convert.ToDouble(notaauto1420)) / 3;
                        notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613) + Convert.ToDouble(notajefe1420)) / 3;
                        notasubal = (Convert.ToDouble(notasubal15) + Convert.ToDouble(notasubal613) + Convert.ToDouble(notasubal1420)) / 3;
                        notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2) + Math.Round(notasubal, 2)) / 3;
                        if (notauto != 0 && notajefe != 0 && notasubal != 0 && notafin != 0)
                        {

                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = Math.Round(notauto, 2);
                            row["subal"] = Math.Round(notasubal, 2);
                            row["jefeinmed"] = Math.Round(notajefe, 2);
                            row["NOTAFINAL"] = Math.Round(notafin, 2);
                            dt4.Rows.Add(row);
                        }
                        if (notauto == 0 || notajefe == 0 || notasubal == 0 || notafin == 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = "0";
                            row["subal"] = "0";
                            row["jefeinmed"] = "0";
                            row["NOTAFINAL"] = "0";
                            dt4.Rows.Add(row);


                        }
                    }

                    if (notaauto1420 == "" && notaauto613 == "" && notaauto15 == "" && notajefe1420 == "" && notajefe613 == "" && notajefe15 == "" && notasubal15 == "" && notasubal613 == "" && notasubal1420 == "")
                    {
                        row["cod"] = dt3.Rows[i][0].ToString();
                        row["EVALUADO"] = dt3.Rows[i][1].ToString();
                        row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                        row["gerencia"] = dt3.Rows[i][3].ToString();
                        row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                        row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                        row["auto"] = "0";
                        row["subal"] = "0";
                        row["jefeinmed"] = "0";
                        row["NOTAFINAL"] = "0";
                        dt4.Rows.Add(row);


                    }

                    if (notaauto1420 == "" && notaauto613 == "" && notaauto15 == "" && notajefe613 != "" && notajefe15 != "" && notasubal15 == "" && notasubal613 == "" && notasubal1420 == "")
                    {
                        row["cod"] = dt3.Rows[i][0].ToString();
                        row["EVALUADO"] = dt3.Rows[i][1].ToString();
                        row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                        row["gerencia"] = dt3.Rows[i][3].ToString();
                        row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                        row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                        row["auto"] = "0";
                        row["subal"] = "0";
                        row["jefeinmed"] = "0";
                        row["NOTAFINAL"] = "0";
                        dt4.Rows.Add(row);


                    }

         





                }
                else
                {

                    string notaauto15 = Convert.ToString(msq.autototal15(iduser));
                    string notaauto613 = Convert.ToString(msq.autototal613(iduser));
                    string notaauto1420 = Convert.ToString(msq.autototal1420(iduser));

                    string notajefe15 = Convert.ToString(msq.jefetotal15(iduser));
                    string notajefe613 = Convert.ToString(msq.jefetotal613(iduser));
                    string notajefe1420 = Convert.ToString(msq.jefetotal1420(iduser));

                    string notasubal15 = Convert.ToString(msq.subaltotal15(iduser));
                    string notasubal613 = Convert.ToString(msq.subaltotal613(iduser));
                    string notasubal1420 = Convert.ToString(msq.subaltotal1420(iduser));



                    if (notaauto1420 == "" && notaauto15 != "" && notaauto613 != "" && notajefe15 != "" && notajefe613 != "" && notajefe1420 == "")
                    {
                        notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613)) / 2;
                        notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613)) / 2;
                        notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2)) / 2;
                        if (notauto != 0 && notajefe != 0 && notafin != 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = Math.Round(notauto, 2);
                            row["subal"] = "0";
                            row["jefeinmed"] = Math.Round(notajefe, 2);
                            row["NOTAFINAL"] = Math.Round(notafin, 2);
                            dt4.Rows.Add(row);
                        }
                        if (notauto == 0 || notajefe == 0 || notafin == 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = "0";
                            row["subal"] = "0";
                            row["jefeinmed"] = "0";
                            row["NOTAFINAL"] = "0";
                            dt4.Rows.Add(row);
                        }

                    }

                    if (notaauto1420 != "" && notaauto613 != "" && notaauto15 != "" && notajefe1420 != "" && notajefe613 != "" && notajefe15 != "")
                    {
                        notauto = (Convert.ToDouble(notaauto15) + Convert.ToDouble(notaauto613) + Convert.ToDouble(notaauto1420)) / 3;
                        notajefe = (Convert.ToDouble(notajefe15) + Convert.ToDouble(notajefe613) + Convert.ToDouble(notajefe1420)) / 3;
                        notasubal = (Convert.ToDouble(notasubal15) + Convert.ToDouble(notasubal613) + Convert.ToDouble(notasubal1420)) / 3;
                        notafin = (Math.Round(notauto, 2) + Math.Round(notajefe, 2) + Math.Round(notasubal, 2)) / 3;
                        if (notauto != 0 && notajefe != 0 && notasubal != 0 && notafin != 0)
                        {

                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = Math.Round(notauto, 2);
                            row["subal"] = Math.Round(notasubal, 2);
                            row["jefeinmed"] = Math.Round(notajefe, 2);
                            row["NOTAFINAL"] = Math.Round(notafin, 2);
                            dt4.Rows.Add(row);
                        }
                        if (notauto == 0 || notajefe == 0 || notasubal == 0 || notafin == 0)
                        {
                            row["cod"] = dt3.Rows[i][0].ToString();
                            row["EVALUADO"] = dt3.Rows[i][1].ToString();
                            row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                            row["gerencia"] = dt3.Rows[i][3].ToString();
                            row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                            row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                            row["auto"] = "0";
                            row["subal"] = "0";
                            row["jefeinmed"] = "0";
                            row["NOTAFINAL"] = "0";
                            dt4.Rows.Add(row);


                        }
                    }

                    if (notaauto1420 == "" && notaauto613 == "" && notaauto15 == "" && notajefe1420 == "" && notajefe613 == "" && notajefe15 == "" && notasubal15 == "" && notasubal613 == "" && notasubal1420 == "")
                    {
                        row["cod"] = dt3.Rows[i][0].ToString();
                        row["EVALUADO"] = dt3.Rows[i][1].ToString();
                        row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                        row["gerencia"] = dt3.Rows[i][3].ToString();
                        row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                        row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                        row["auto"] = "0";
                        row["subal"] = "0";
                        row["jefeinmed"] = "0";
                        row["NOTAFINAL"] = "0";
                        dt4.Rows.Add(row);


                    }
                    if (notaauto1420 == "" && notaauto613 == "" && notaauto15 == "" && notajefe613 != "" && notajefe15 != "" && notasubal15 == "" && notasubal613 == "" && notasubal1420 == "")
                    {
                        row["cod"] = dt3.Rows[i][0].ToString();
                        row["EVALUADO"] = dt3.Rows[i][1].ToString();
                        row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                        row["gerencia"] = dt3.Rows[i][3].ToString();
                        row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                        row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                        row["auto"] = "0";
                        row["subal"] = "0";
                        row["jefeinmed"] = "0";
                        row["NOTAFINAL"] = "0";
                        dt4.Rows.Add(row);


                    }

                    if (notaauto613 != "" && notaauto15 != "" && notajefe613 == "" && notajefe15 == "" && notasubal15 == "" && notasubal613 == "" && notasubal1420 == "")
                    {
                        row["cod"] = dt3.Rows[i][0].ToString();
                        row["EVALUADO"] = dt3.Rows[i][1].ToString();
                        row["unidadoperativa"] = dt3.Rows[i][2].ToString();
                        row["gerencia"] = dt3.Rows[i][3].ToString();
                        row["PUESTO_EVALUADO"] = dt3.Rows[i][4].ToString();
                        row["Fecha_Ingreso"] = dt3.Rows[i][5].ToString();
                        row["auto"] = "0";
                        row["subal"] = "0";
                        row["jefeinmed"] = "0";
                        row["NOTAFINAL"] = "0";
                        dt4.Rows.Add(row);


                    }








                }



            }











            return dt4;



        }


        protected void notastodos_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("resultados", notastodos3());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/ReporteResultados.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }

        protected void generarrepo_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("reportependientes", obtenerpendientes());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }

        protected void generarreponotas_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("resultados", obtenernotas());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/Report2.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }
        public void obtenerDatoseval(string evaluacion)
        {


            string[] datos = msq.datosevaluacion(evaluacion);
            try
            {
                for (int i = 0; i < datos.Length; i++)
                {


                    comentariomod.Value = Convert.ToString(datos.GetValue(0));
                    nombreeval.Value = Convert.ToString(datos.GetValue(1));
                    string fechaini = Convert.ToString(datos.GetValue(2));
                    string fechaini2 = Convert.ToString(datos.GetValue(3));
                    dropevaluaciontipomod.SelectedValue= Convert.ToString(datos.GetValue(4));
                    dropestadoevalestadomod.SelectedValue = Convert.ToString(datos.GetValue(5));


                    string[] fechasep = fechaini.Split(delimitador2);

                    string[] horai = fechasep[3].Split(delimitador3);

                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horai[0] + ":" + horai[1];



                    string[] fechafinsep = fechaini2.Split(delimitador2);

                    string[] horaf = fechafinsep[3].Split(delimitador3);



                    fechatotal2 = fechafinsep[0] + "-" + fechafinsep[1] + "-" + fechafinsep[2] + concat + horaf[0] + ":" + horaf[1];

                    fechainicialmodeval.Attributes.Add("value", fechatotal1);
                    fechafinalmodeval.Attributes.Add("value", fechatotal2);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }


        public void llenarestadoevalcrear()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_estadoeval`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropestadoevalestadomod.DataSource = ds;
                    dropestadoevalestadomod.DataTextField = "estadoeval";
                    dropestadoevalestadomod.DataValueField = "codsqlesteval";
                    dropestadoevalestadomod.DataBind();
                    dropestadoevalestadomod.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipoevalmod()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `sq_tipoevaluacion`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dropevaluaciontipomod.DataSource = ds;
                    dropevaluaciontipomod.DataTextField = "tipoevaluacion";
                    dropevaluaciontipomod.DataValueField = "codsqtipoeval";
                    dropevaluaciontipomod.DataBind();
                    dropevaluaciontipomod.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Tipo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

    }
}