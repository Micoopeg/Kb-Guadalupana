using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Views.MantenimientosControl
{
    public partial class controlExpedientes : System.Web.UI.Page
    {
        Sentencia_seguridad SNS = new Sentencia_seguridad();
        string user, id;
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                llenarcomboaplicacion();
                llenarcomboarea();
                llenarcomborol();
           
            }
        }


        public void usuarionuevo()
        {



            string sig = SNS.obtenerfinal("ex_controlingreso", "codexcontroling");
            string sql = "INSERT INTO `ex_controlingreso` (`codexcontroling`, `ex_controlusuario`, `ex_controlarea`, `ex_controlrol`, `ex_cifgeneral`, `nomcom`) VALUES ('" + sig + "', '" + NUEVOUSER.Value + "', '" + DDAREA.SelectedValue + "', '" + DDROL.SelectedValue + "', '" + CIF.Value + "', '"+NOMCOM.Value+"')";
            SNS.Insertar(sql);

        }
        public void modificaruser()
        {

            string sql2 = "UPDATE `ex_controlingreso` SET `ex_controlarea`= '" + DDAREA.SelectedIndex + "',`ex_controlrol`= '" + DDROL.SelectedIndex + "',`ex_cifgeneral`='" + CIF.Value + "' WHERE codexcontroling = '" + DDUSER.SelectedValue + "'";
            SNS.Insertar(sql2);

        }
        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlingreso";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    DDUSER.DataSource = ds;
                    DDUSER.DataTextField = "nomcom";
                    DDUSER.DataValueField = "codexcontroling";
                    DDUSER.DataBind();
                    DDUSER.Items.Insert(0, new ListItem("[Usuario]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void SGuardar_Click(object sender, EventArgs e)
        {

            if (chk.Checked)
            {
                if (DDAREA.SelectedIndex != 0 && DDROL.SelectedIndex != 0 && NUEVOUSER.Value != "")
                {
                    usuarionuevo();

                    NUEVOUSER.Value = "";
                    DDAREA.SelectedIndex = 0;
                    DDROL.SelectedIndex = 0;
                    CIF.Value = "";
                    NOMCOM.Value = "";

                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos    ')", true);

                }
            }
            else if (chk.Checked == false)
            {
                if (DDUSER.SelectedIndex != 0 && DDAREA.SelectedIndex != 0 && DDROL.SelectedIndex != 0)
                {
                    modificaruser();

                    NUEVOUSER.Value = "";
                    DDAREA.SelectedIndex = 0;
                    DDROL.SelectedIndex = 0;
                    CIF.Value = "";
                    NOMCOM.Value = "";
                }

                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' ingrese los campos completos    ')", true);

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
                    string QueryString = "select * from ex_roles";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Rol");
                    DDROL.DataSource = ds;
                    DDROL.DataTextField = "ex_nomrol";
                    DDROL.DataValueField = "codexrol";
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
                    string QueryString = "select * from ex_controlarea";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    DDAREA.DataSource = ds;
                    DDAREA.DataTextField = "ex_nombrea";
                    DDAREA.DataValueField = "codexcontrolarea";
                    DDAREA.DataBind();
                    DDAREA.Items.Insert(0, new ListItem("[Area]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {

                if (DDROL.SelectedIndex != 0 || DDAREA.SelectedIndex != 0 || CIF.Value != "")
                {

                    NUEVOUSER.Disabled = false;
                    NOMCOM.Disabled = false;
                    DDUSER.Enabled = false;

                    DDROL.SelectedIndex = 0;
                    DDAREA.SelectedIndex = 0;
                    CIF.Value = "";
                    NOMCOM.Value = "";
                    DDUSER.SelectedIndex = 0;

                }
                else
                {
                    NUEVOUSER.Disabled = false;
                    DDUSER.Enabled = false;
                    NOMCOM.Disabled = false;


                }

            }
            else
            {

                NUEVOUSER.Disabled = true;
                DDUSER.Enabled = true;
 
                NOMCOM.Disabled = true;
            }
        }

        protected void DDUSER_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DDUSER.SelectedIndex != 0)
           {
              
                string[] fecha = SNS.datosusuarioex(DDUSER.SelectedValue);
                try
                {
                    for (int i = 0; i < fecha.Length; i++)
                    {
                        DDAREA.SelectedIndex = Convert.ToInt32(fecha.GetValue(2));
                        DDROL.SelectedIndex = Convert.ToInt32(fecha.GetValue(3));
                        CIF.Value = Convert.ToString(fecha.GetValue(4));
                        NOMCOM.Value = Convert.ToString(fecha.GetValue(5));

                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }

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
        protected void btnestadouser_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Seguridad/ModificarEstado.aspx");
        }
    }
}