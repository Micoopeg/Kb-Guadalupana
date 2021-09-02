using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();

        protected void Page_Load(object sender, EventArgs e)
        {
            Crear.Visible = false;
            Consultar.Visible = false;
            Matriz.Visible = false;
            Consulta.Visible = false;
            Mantenimiento.Visible = false;
            permisos();
        }

        public void permisos()
        {
            string sesionuser = Session["sesion_usuario"].ToString();

            string[] var1 = sen.consultarUsuario(sesionuser);
            string valor = Convert.ToString(var1[0]);

            string[] var2 = sen.consultarRol(valor);
            string valor1 = Convert.ToString(var2[0]);

            if (valor1 == "5" || valor1 == "1")
            {
                Crear.Visible = true;
                Consultar.Visible = true;
                Matriz.Visible = true;
                Consulta.Visible = true;
                Mantenimiento.Visible = true;
            }
            else
            {
                Crear.Visible = false;
                Consultar.Visible = false;
                Matriz.Visible = false;
                Consulta.Visible = true;
                Mantenimiento.Visible = false;
            }
        }
    }
}