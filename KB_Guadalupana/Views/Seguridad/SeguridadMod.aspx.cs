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

        string NOMAPP, URL, ABRAPP, OP, op2;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ingresar()
        {

            nommodul.Value = NOMAPP;
            url1.Value = URL;
            abrmodulo.Value = ABRAPP;
            seleccion.Value = OP;
            string sig = cav.siguiente("gen_aplicacion", "codgenapp");

            string sql = "INSERT INTO gen_aplicacion  VALUES('" + sig + "', '" + ABRAPP + "', '" + NOMAPP + "', '" + URL + "');";
            cav.Insertar(sql);
            //    switch (OP) {

            //        case "Activo":
            //            break;
            //        case "Inactivo":
            //            break;

            //}

        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            nommodul.Value = NOMAPP;
            url1.Value = URL;
            abrmodulo.Value = ABRAPP;
            seleccion.Value = OP;

            if (NOMAPP != null || URL != null || ABRAPP != null || seleccion.Value == "Estado")
            {
               
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('LLene todos los campos ')", true);
            }

            else
            {
                ingresar();
            }

        }
    }
}