using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.MenuPrincipal
{
    public partial class CRM_MenuPrincipal : System.Web.UI.Page
    {
        string Nombresesion;
        string sucurusalcrm;
        string usuariodelcrm;
        string roldelcrm;
        string controlingresocrm;

        CRM_Sentencias sn = new CRM_Sentencias();
        Random rnd = new Random();
        CRM_Logica logic = new CRM_Logica();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Buscar todos los asociados dependiendo     
            // Session["sesion_usuario"] = "pggteo";

            Nombresesion = Session["sesion_usuario"].ToString();
            obtenciondeinformacion();
            Session["controlingreso"] = controlingresocrm;
            Session["usuariodelcrm"] = usuariodelcrm;
            Session["sucurusalcrm"] = sucurusalcrm;
            Session["roldelcrm"] = roldelcrm;
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            switch (rolusuario)
            {

                case 0:
                    String script = "alert('ERROR DEL APLICATIVO COMUNICAR CON EL DEPARTAMENTO DE INFORMATICA ÁREA DE PROGRAMACIÓN');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    break;
                case 1:
                    //INGRESO DE DATOS PARA ALIMENTAR CRM
                    btningresodedatos.Visible = true;
                    btncarteraasociados.Visible = false;
                    btncatalogodeclientes.Visible = false;
                    btnmantenimientos.Visible = false;
                    btncharts.Visible = false;
                    btndashboards.Visible = false;
                    btnasignacionforzosa.Visible = false;
                    break;
                case 2:
                    //INGRESO DE CLIENTES PARA CRM - AGENTES
                    btningresodedatos.Visible = false;
                    btncarteraasociados.Visible = false;
                    btncatalogodeclientes.Visible = true;
                    btnmantenimientos.Visible = true;
                    btncharts.Visible = true;
                    btndashboards.Visible = true;
                    btnasignacionforzosa.Visible = true;
                    break;
                case 3:
                    //INGRESO PARA GRAFICAS DEL CRM
                    btningresodedatos.Visible = false;
                    btncarteraasociados.Visible = true;
                    btncatalogodeclientes.Visible = false;
                    btnmantenimientos.Visible = false;
                    btncharts.Visible = false;
                    btndashboards.Visible = false;
                    btnasignacionforzosa.Visible = false;
                    break;
                case 4:
                    //INGRESO PARA ADMINISTRADOR
                    btningresodedatos.Visible = false;
                    btncarteraasociados.Visible = false;
                    btncatalogodeclientes.Visible = false;
                    btnmantenimientos.Visible = true;
                    btncharts.Visible = false;
                    btndashboards.Visible = false;
                    btnasignacionforzosa.Visible = false;
                    break;
                case 5:
                    //INGRESO PARA JEFE DE AGENCIAS
                    btningresodedatos.Visible = false;
                    btncarteraasociados.Visible = false;
                    btncatalogodeclientes.Visible = true;
                    btnmantenimientos.Visible = false;
                    btncharts.Visible = true;
                    btndashboards.Visible = false;
                    btnasignacionforzosa.Visible = false;
                    break;
                case 6:
                    //INGRESO PARA SUPERUSUARIO
                    btningresodedatos.Visible = true;
                    btncarteraasociados.Visible = true;
                    btncatalogodeclientes.Visible = true;
                    btnmantenimientos.Visible = true;
                    btncharts.Visible = true;
                    btndashboards.Visible = true;
                    btnasignacionforzosa.Visible = true;
                    break;
                case 7:
                    //INGRESO PARA COORDINADOR DE AGENCIAS
                    btningresodedatos.Visible = false;
                    btncarteraasociados.Visible = false;
                    btncatalogodeclientes.Visible = false;
                    btnmantenimientos.Visible = false;
                    btncharts.Visible = true;
                    btndashboards.Visible = false;
                    btnasignacionforzosa.Visible = true;
                    break;
                default:
                    String script1 = "alert('ERROR DEL APLICATIVO COMUNICAR CON EL DEPARTAMENTO DE INFORMATICA');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script1, true);
                    break;

            }
            int numerofrase = rnd.Next(1, 4);
            string[] varfrase = sn.consultarconcampo("crm_frasesdeldia", "idcrm_frasesdeldia", Convert.ToString(numerofrase));
            string frase = varfrase[1];
            lblfrase.Text = frase;
        }
        protected void obtenciondeinformacion()
        {

            string[] var1 = sn.consultarconcampoingresocrm("crmcontrol_ingreso", "crmcontrol_ingresousuario", Nombresesion);
            if (var1[0] == "0")
            {
                String script = "alert('El usuario no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else
            {
                controlingresocrm = var1[0];
                sucurusalcrm = var1[1];
                usuariodelcrm = var1[2];
                roldelcrm = var1[3];
            }
        }

        protected void btncerrarsesion_ServerClick(object sender, EventArgs e)
        {
            logic.bitacoraingreso(Nombresesion, "CRM", "Egreso");
            Response.Redirect("../../Sesion/MenuBarra.aspx");

        }
    }
}