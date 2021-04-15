using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System.Data;
namespace KB_Guadalupana.Views.MantenimientosControl
{
    public partial class controlAgenda : System.Web.UI.Page
    {
   
        Sentencia_seguridad SNS = new Sentencia_seguridad();
        string user, id;
        Conexion conexiongeneral = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            mantarea.Visible = false;

            if (!IsPostBack)
            {
                llenarcomboaplicacion();
                llenarcomboarea();
                llenarcomborol();
                llenarcombotipositio();
            }




        }

        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_controlingreso";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    DDUSER.DataSource = ds;
                    DDUSER.DataTextField = "av_controlusuario";
                    DDUSER.DataValueField = "codavcontroling";
                    DDUSER.DataBind();
                    DDUSER.Items.Insert(0, new ListItem("[Usuario]", "0"));
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
                    string QueryString = "select * from av_roles";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Rol");
                    DDROL.DataSource = ds;
                    DDROL.DataTextField = "av_rolnombre";
                    DDROL.DataValueField = "av_codrol";
                    DDROL.DataBind();
                    DDROL.Items.Insert(0, new ListItem("[Rol]", "0"));
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
                    string QueryString = "select * from av_controlsitio";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    DDAREA.DataSource = ds;
                    DDAREA.DataTextField = "av_nombre";
                    DDAREA.DataValueField = "codavcontolsitio";
                    DDAREA.DataBind();
                    DDAREA.Items.Insert(0, new ListItem("[Area]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipositio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM av_tipositio";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "sitio");
                    DDTIPO.DataSource = ds;
                    DDTIPO.DataTextField = "av_sitio";
                    DDTIPO.DataValueField = "codavtipositio";
                    DDTIPO.DataBind();
                    DDTIPO.Items.Insert(0, new ListItem("[Sucursal]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void btninicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/Seguridad1.aspx");
        }
        protected void btnmoduloscrear_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/SeguridadMod.aspx");
        }
        protected void btnappuser_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/AsignacionAplicacion.aspx");
        }
        protected void btnModapp_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/ModificarModulo.aspx");
        }
        protected void btnmodulospermisos_Clicl(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/Seguridad2.aspx");
        }
        public void usuarionuevo() {



            string sig = SNS.obtenerfinal("av_controlingreso", "codavcontroling");
            string sql = "INSERT INTO `av_controlingreso`(`codavcontroling`, `av_controlusuario`, `av_controlarea`, `av_controlrol`, `avcifgeneral`) VALUES ('"+sig+"', '"+NUEVOUSER.Value+"', '"+DDAREA.SelectedIndex+"', '"+DDROL.SelectedIndex+"', '"+CIF.Value+"')";
            SNS.Insertar(sql);
        
        }
        public void modificaruser() {

            string couser =  SNS.obteneridusuarioav(DDUSER.SelectedItem.Text);
            string sql2 = "UPDATE `av_controlingreso` SET `av_controlarea`= '"+DDAREA.SelectedIndex+"',`av_controlrol`= '"+DDROL.SelectedIndex+"',`avcifgeneral`='"+CIF.Value+"' WHERE codavcontroling = '"+couser+"'";
            SNS.Insertar(sql2);

        }
        protected void SGuardar_Click(object sender, EventArgs e)
        {

            if (chk.Checked )
            {
                if (DDAREA.SelectedIndex != 0 && DDROL.SelectedIndex != 0 && NUEVOUSER.Value != "") { usuarionuevo();

                    NUEVOUSER.Value = "";
                    DDAREA.SelectedIndex = 0;
                    DDROL.SelectedIndex = 0;
                    CIF.Value = "";
                
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos    ')", true);

                }
            }
            else if ( chk.Checked== false)
            {
                if(DDUSER.SelectedIndex != 0 && DDAREA.SelectedIndex != 0 && DDROL.SelectedIndex != 0 ) { modificaruser();

                    NUEVOUSER.Value = "";
                    DDAREA.SelectedIndex = 0;
                    DDROL.SelectedIndex = 0;
                    CIF.Value = "";
                }

                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos    ')", true);

                }



            }
         

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked) {

                if (DDROL.SelectedIndex != 0 || DDAREA.SelectedIndex != 0 || CIF.Value != "")
                {

                    NUEVOUSER.Disabled = false;
                    DDUSER.Enabled = false;

                    DDROL.SelectedIndex = 0;
                    DDAREA.SelectedIndex = 0;
                    CIF.Value = "";

                }
                else {
                    NUEVOUSER.Disabled = false;
                    DDUSER.Enabled = false;

                   

                }

            }
            else {

                NUEVOUSER.Disabled = true;
                DDUSER.Enabled = true;
            }
        }

        protected void DDUSER_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DDUSER.SelectedIndex != 0 ) {
                string couser = SNS.obteneridusuarioav(DDUSER.SelectedItem.Text);
                string[] fecha = SNS.datosusuarioav(couser);
                try
                {
                    for (int i = 0; i < fecha.Length; i++)
                    {
                        DDAREA.SelectedIndex = Convert.ToInt32(fecha.GetValue(2));
                        DDROL.SelectedIndex = Convert.ToInt32(fecha.GetValue(3));
                        CIF.Value = Convert.ToString(fecha.GetValue(4));


                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }

            }


           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sig = SNS.obtenerfinal("av_roles","av_rolnombre");
            string sig2 = SNS.obtenerfinal("av_controlsitio","codavcontolsitio");
            if (AREA.Value == "" && ROL.Value == "" && DDTIPO.SelectedIndex == 0)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos ')", true);



            }

            if (ROL.Value != "")
            {
                

                string sqlarea = "INSERT INTO `av_roles`(`av_codrol`, `av_rolnombre`) VALUES ('" + sig + "','" + ROL.Value + "')";

                SNS.Insertar(sqlarea);
                mantarea.Visible = true;
                Button1.Visible = false;
                Button2.Visible = true;

            }
            if (AREA.Value != "" && DDTIPO.SelectedIndex != 0)
            {
                string sqlrol = "INSERT INTO `av_controlsitio`(`codavcontolsitio`, `av_nombre`, `av_tipositio`) VALUES ('" + sig2 + "', '" + AREA.Value + "', '" + DDTIPO.SelectedIndex + "')";
                SNS.Insertar(sqlrol);

                mantarea.Visible = true;
                Button1.Visible = false;
                Button2.Visible = true;
            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos areas ')", true); mantarea.Visible = true; chkusers.Checked = false; }

        }

        protected void checkarea_CheckedChanged(object sender, EventArgs e)
        {
            if (checkarea.Checked) {

                mantuser.Visible = false;
                mantarea.Visible = true;
                Button1.Visible = true;
                Button2.Visible = false;
                checkarea.Checked = false;

                
            }
        }

        protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {
            if (chkusers.Checked) {

                mantuser.Visible = true;
                Button2.Visible = true;
                Button1.Visible = false;
                mantarea.Visible = false;
                chkusers.Checked = false;
            
            }
        }

        protected void CheckBox1_CheckedChanged2(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                ROL.Disabled = false;

                mantuser.Visible = false;
                Button2.Visible = false;
                Button1.Visible = true;
                mantarea.Visible = true;
                chkusers.Checked = false;
            }
            else {

                ROL.Disabled = true;

                mantuser.Visible = false;
                Button2.Visible = false;
                Button1.Visible = true;
                mantarea.Visible = true;
                chkusers.Checked = false;
            }
        }

        protected void btnestadouser_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/ModificarEstado.aspx");
        }
    }
}