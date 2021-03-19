using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

namespace Login_Web
{
    public partial class Control : System.Web.UI.Page
    {
        Conexion conn = new Conexion();
        Sentencia sn = new Sentencia();
        Logica lg = new Logica();
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            int rol=0;
            int area=0;
            string abre;
            try
            {
                if (Session.IsNewSession)
                {
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Favor ingresar su Usuario y Contraseña');", true);
                    Response.Redirect("MenuBarra.aspx");
                }

                else
                {
                    try
                    {
                        nombreuser.InnerText = Session["Nombre"].ToString();
                        abre = Session["sesion_usuario"].ToString();
                        string resultado = abre.Substring(2, 2);
                        string mayus = resultado.ToUpper();
                        abreuser.InnerText = mayus;
                        Button3.Visible = false;
                        //icono.Visible = false;                       
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Sesion expirada: " + err.Message);
                        Response.Redirect("../../Index.aspx");
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Sesion expirada: " + err.Message);
                Response.Redirect("login.aspx");
            }
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        protected void cerrarsession_Click(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra If');", true);
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void tickets_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tickets.aspx");
        } 
        protected void inicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void estadoPatrimonial_Click(object sender, EventArgs e)
        {
            Response.Redirect("EP_InformacionGeneral.aspx");
        }

        protected void areaAdministrativa_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuBarraMantenimientos.aspx");
        }

        protected void seguridad_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoAreas.aspx");
        }
    }
}