using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Asesores
{
    public partial class CRM_Crearreferido : System.Web.UI.Page
    {
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        string nombreusuario;
        string registrodpiremplazable;
        string dpiguardar="";
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario == 3 || rolusuario == 6)
            {

            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            if (!IsPostBack)
            {
                // llenarsucursalmascercana();
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (txtnumerodpi.Value == "" || txtnombrecompleto.Value == "" || txttelefono.Value == "" ||
                   txtemail.Value == "" || txtdpidereferido.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                if (txtnumerodpi.Value.Length == 13 && txtdpidereferido.Value.Length == 13)
                {
                    if (validardpi(txtnumerodpi.Value) == true)
                    {
                        if (comprobardpiexistente(txtnumerodpi.Value))  //DPI EXISTENTE 
                        {
                            // Response.Write("el nuevo" + registrodpiremplazable);
                            string[] regdpiguardado = sn.consultarconcampo("crminfogeneral_prospecto", "crminfogeneral_prospectodpi", registrodpiremplazable);
                            dpiguardar = regdpiguardado[0];
                        }
                        else
                        {
                            string sig1 = logic.siguiente("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                            string[] valores2 = { sig1, txtnumerodpi.Value, "", "", txtnombrecompleto.Value, "0" };
                            logic.insertartablas("crminfogeneral_prospecto", valores2);
                            dpiguardar = sig1;


                        }
                        //INSERTAR DATOS
                        string sig = logic.siguiente("crminfo_prospecto", "codcrminfoprospecto");
                        string[] valores1 = { sig, dpiguardar, "1", "1", "2",
                        "1","1","1","0",txtemail.Value,"0","0","0","0","0","","2021-04-17","2021-04-17",exampleFormControlTextarea1.Value,"0",
                        "0","0","0","Referenciado",txtdpidereferido.Value};
                        logic.insertartablas("crminfo_prospecto", valores1);
                        logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Aplicación Asesores", "Creación del referido - Correlativo: '" + txtnumerodpi.Value + "'");
                        string sig3 = logic.siguiente("crmcontrol_prospecto_agente", "codcrmcontrolprospectoagente");
                        string[] var4 = sn.fechaactual();
                        DateTime fechaactual = Convert.ToDateTime(var4[0]);
                        string[] agenteacargo = sn.consultarcontrolingreso(nombreusuario);
                        string[] valores3 = { sig3, sig, agenteacargo[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
                        logic.insertartablas("crmcontrol_prospecto_agente", valores3);
                        txtdpidereferido.Value = "";
                        txtemail.Value = "";
                        txtnombrecompleto.Value = "";
                        txtnumerodpi.Value = "";
                        txttelefono.Value = "";
                        exampleFormControlTextarea1.Value = "";
                        String script = "alert('Los datos se han ingresado correctamente');";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else
                    {
                        String script = "alert('El número de DPI ingresado no es correcto');";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                    }
                }            
                else
                {
                    String script = "alert('El Número de DPI no cumple con la cantidad de caracteres necesarios');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }

            }
        }
        public bool comprobardpiexistente(string dpiacomprobar)
        {
            string[] var2 = sn.consultardpiexistente();

            int cont = 0;
            while (cont != var2.Length)
            {
                string dpiextraido = Convert.ToString(var2[cont]);

                if (dpiacomprobar != dpiextraido)
                {
                    cont = cont + 1;

                }
                else
                {
                    registrodpiremplazable = dpiacomprobar;

                    return true;
                }

            }
            return false;
        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRM_Asesores.aspx");
        }

        public bool validardpi(string cadenaaverificar)
        {
            int multiplicar;
            int contdescente = 9;
            int resultado;
            int subtotal = 0;
            string var = cadenaaverificar;
            char[] cadenaComoCaracteres = var.ToCharArray();
            int numero = (cadenaComoCaracteres.Length - 5);
            for (int i = 0; i < numero;)
            {

                multiplicar = (Convert.ToInt32(cadenaComoCaracteres[i]) - 48);
                resultado = multiplicar * contdescente;
                contdescente = contdescente - 1;
                subtotal = subtotal + resultado;
                i = i + 1;
            }
            int residuo = subtotal % 11;
            int total = 11 - residuo;
            int varvalidadora = (Convert.ToChar(cadenaComoCaracteres[8]) - 48);
            if (varvalidadora == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}