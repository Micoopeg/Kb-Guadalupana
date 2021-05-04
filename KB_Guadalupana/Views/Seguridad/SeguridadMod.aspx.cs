using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBGuada.Controllers;
using KBGuada.Models;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class SeguridadMod : System.Web.UI.Page
    {
        ControladorAV cav = new ControladorAV();
        Conexion conexiongeneral = new Conexion();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        string NOMAPP, URL, ABRAPP, OP, op2;
        


        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["sesion_usuario"]);
            string respuesta = sn.obtenerpermisoseguridad(user);

            if (respuesta == "0" || respuesta == null || respuesta == "" || respuesta == "False")
            {
                String script = "alert('El usuario no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            if (!IsPostBack)
            {
                llenarcomboarea();
            }
        }

        public void ingresar()
        {
            NOMAPP = nommodul.Value;
            URL = url1.Value;
            ABRAPP = abrmodulo.Value;
            OP = seleccion.Value;
            switch (OP)
            {

                case "Activo":
                
                    op2 = "1";
                    string sig = cav.siguiente("gen_aplicacion", "codgenapp");

                    string sql = "INSERT INTO gen_aplicacion  VALUES('" + sig + "', '" + ABRAPP + "', '" + NOMAPP + "', '" + URL + "', '" + op2 + "');";
                    cav.Insertar(sql);

                    string sig1 = cav.siguiente("gen_areaapp", "codeareaapp");
                    string sql1 = "INSERT INTO gen_areaapp VALUES ('" + sig1 + "', '" + SArea.SelectedValue + "', '" + sig + "', '" + Urlmodulo.Value + "')";
                    cav.Insertar(sql1);

                    break;
                case "Inactivo":

                 
                    op2 = "0";
                    string sig2 = cav.siguiente("gen_aplicacion", "codgenapp");

                    string sql2 = "INSERT INTO gen_aplicacion  VALUES('" + sig2 + "', '" + ABRAPP + "', '" + NOMAPP + "', '" + URL + "', '" + op2 + "');";
                    cav.Insertar(sql2);

                    string sig3 = cav.siguiente("gen_areaapp", "codeareaapp");
                    string sql3 = "INSERT INTO gen_areaapp VALUES ('" + sig3 + "', '" + SArea.SelectedValue + "', '" + sig2 + "', '" + Urlmodulo.Value + "')";
                    cav.Insertar(sql3);

                    break;

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
                    myCommand.Fill(ds, "Área");
                    SArea.DataSource = ds;
                    SArea.DataTextField = "gen_areanombre";
                    SArea.DataValueField = "codgenarea";
                    SArea.DataBind();
                    SArea.Items.Insert(0, new ListItem("[Área]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

            NOMAPP = nommodul.Value;
            URL = url1.Value;
            ABRAPP = abrmodulo.Value;
            OP = seleccion.Value;
            if (NOMAPP != null || URL != null || ABRAPP != null || seleccion.Value != "Estado")
            {
                ingresar();
                Response.Redirect("AsignacionAplicacion.aspx");
            }

            else
            {

                String script = "alert('Llene todos los campos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }

        protected void btninicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad1.aspx");
        }
        protected void btnmoduloscrear_Click(object sender, EventArgs e)
        {

            Response.Redirect("SeguridadMod.aspx");
        }
        protected void btnappuser_Click(object sender, EventArgs e)
        {

            Response.Redirect("AsignacionAplicacion.aspx");
        }
        protected void btnModapp_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarModulo.aspx");
        }
        protected void btnmodulospermisos_Clicl(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad2.aspx");
        }
        protected void btnestadouser_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarEstado.aspx");
        }
    }
}