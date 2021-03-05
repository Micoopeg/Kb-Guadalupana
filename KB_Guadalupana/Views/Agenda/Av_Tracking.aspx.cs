using System;
using KBGuada.Controllers;
using KBGuada.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;


namespace KBGuada.Views.session
{
    public partial class Av_Tracking : System.Web.UI.Page
    {
     
        ControladorAV cav = new ControladorAV();
        string tarea;
        string Nombreuser, user,rol;
        protected void Page_Load(object sender, EventArgs e)
        {

            string numerotarea = Convert.ToString(Session["NoTarea"]);
            tarea = numerotarea;
            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            UsuarioNom.InnerText = user;
            permisos(cav.obtenercoduser(Nombreuser));
            cargaractividades(numerotarea);

        }

        public void permisos(string usuario)
        {
            rol = cav.consultarRol(usuario);



            if (rol == "2")
            {
          
                ASIGHOME.Visible = false;

            }


        }
        public void cargaractividades(string nutarea)
        {

            DataSet ds1 = cav.consultarAcReal(nutarea);




            repetirsub.DataSource = ds1;
            repetirsub.DataBind();



        }








    }
}