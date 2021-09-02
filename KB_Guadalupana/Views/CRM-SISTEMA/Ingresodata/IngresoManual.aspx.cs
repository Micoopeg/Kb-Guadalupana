using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.CRM_SISTEMA.Ingresodata
{
    public partial class IngresoManual : System.Web.UI.Page
    {
        CRM_Logica logic = new CRM_Logica();
        CRM_Sentencias sn = new CRM_Sentencias();
        DateTime fechaactual;
        string dpiguardar;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "" || TextBox5.Text == "" || TextBox14.Text == "" || TextBox15.Text == "" || TextBox18.Text == "" || TextBox29.Text == "")//VALIDAR QUE LOS CAMPOS QUE SON NECESARIOS SE ENCUENTREN LLENOS
            {
                lblerror.Visible = true;
                lblerror.Text = "VERIFIQUE QUE LOS CAMPOS OBLIGATORIOS SE ENCUENTREN LLENOS (*)";

            }
            else
            {
                if (validardpi(TextBox2.Text) == true)//VALIDAR QUE EL DPI SEA VALIDO
                {
                    lblerror.Visible = false;
                    string[] var7 = sn.consultarconcampo("crminfogeneral_prospecto", "crminfogeneral_prospectodpi", TextBox2.Text); ;
                    int tamañodelvar7 = var7.Length;
                    if (tamañodelvar7 != 0)//VALIDAR QUE EL DPI NO ESTE INGRESAOD EN LA BD
                    {
                        //ADVERTI QUE EL DPI QUE SE ESTA GUARDANDO SE ENCUENTRA REGISTRADO Y AÚN ASI SE GENERARA EL LEAD
                        lblerror.Visible = true;
                        lblerror.Text = "EL DPI QUE ESTA REGISTRANDO YA SE ENCUENTRA ALMACENADO ||SIN EMBARGO SE PROCEDE A CREAR EL LEAD|| ";
                        string[] regdpiguardado = sn.consultarconcampo("crminfogeneral_prospecto", "crminfogeneral_prospectodpi", TextBox2.Text);
                        dpiguardar = regdpiguardado[0];

                        String sig = logic.siguiente("crminfo_prospecto", "codcrminfoprospecto");
                        string[] valores1 = { sig,dpiguardar , TextBox8.Text, "1", "2","2","2","1",TextBox14.Text,TextBox15.Text,"0","0",Convert.ToString(TextBox18.Text),"0","0","0","2020-01-01","2020-01-01","","0",
                        "0","0","0",TextBox29.Text,""};
                        logic.insertartablas("crminfo_prospecto", valores1);

                        string sig3 = logic.siguiente("crmcontrol_prospecto_agente", "codcrmcontrolprospectoagente");
                        string[] var4 = sn.fechaactual();
                        fechaactual = Convert.ToDateTime(var4[0]);
                        string[] var5 = sn.consultaaleatroiadepersonalagencias();
                        string[] var6 = sn.consultaaleatroiadepersonaltelemercadeo();
                        double montocalculado = Convert.ToDouble(TextBox18.Text);
                        if (montocalculado >= 50000)
                        {
                            string[] valores3 = { sig3, sig, var6[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
                            logic.insertartablas("crmcontrol_prospecto_agente", valores3);
                        }
                        else
                        {
                            string[] valores3 = { sig3, sig, var5[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
                            logic.insertartablas("crmcontrol_prospecto_agente", valores3);
                        }
                        TextBox2.Text = "";
                        TextBox5.Text = "";
                        TextBox8.Text = "";
                        TextBox14.Text = "";
                        TextBox15.Text = "";
                        TextBox18.Text = "";
                        TextBox29.Text = "";

                    }
                    else
                    {
                        //ingreso normal.
                        lblerror.Visible = false;
                        string sig1 = logic.siguiente("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                        string[] valores2 = { sig1, TextBox2.Text, "", "", TextBox5.Text, "0" };
                        logic.insertartablas("crminfogeneral_prospecto", valores2);
                        dpiguardar = sig1;

                        string sig = logic.siguiente("crminfo_prospecto", "codcrminfoprospecto");
                        string[] valores1 = { sig,dpiguardar, TextBox8.Text, "1", "2","2","2","1",TextBox14.Text,TextBox15.Text,"0","0",Convert.ToString(TextBox18.Text),"0","0","0","2020-01-01","2020-01-01","","0",
                        "0","0","0",TextBox29.Text,""};
                        logic.insertartablas("crminfo_prospecto", valores1);

                        string sig3 = logic.siguiente("crmcontrol_prospecto_agente", "codcrmcontrolprospectoagente");
                        string[] var4 = sn.fechaactual();
                        fechaactual = Convert.ToDateTime(var4[0]);
                        string[] var5 = sn.consultaaleatroiadepersonalagencias();
                        string[] var6 = sn.consultaaleatroiadepersonaltelemercadeo();
                        double montocalculado = Convert.ToDouble(TextBox18.Text);
                        if (montocalculado >= 50000)
                        {
                            string[] valores3 = { sig3, sig, var6[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
                            logic.insertartablas("crmcontrol_prospecto_agente", valores3);
                        }
                        else
                        {
                            string[] valores3 = { sig3, sig, var5[0], string.Format("{0: yyyy-MM-dd}", fechaactual) };
                            logic.insertartablas("crmcontrol_prospecto_agente", valores3);
                        }
                        TextBox2.Text = "";
                        TextBox5.Text = "";
                        TextBox8.Text = "";
                        TextBox14.Text = "";
                        TextBox15.Text = "";
                        TextBox18.Text = "";
                        TextBox29.Text = "";

                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "EL DPI QUE INGRESO ES INCORRECTO";
                }
            }


        }

        public bool validardpi(string cadenaaverificar)
        {
            int multiplicar;
            int contdescente = 9;
            int resultado;
            int subtotal = 0;
            string var = cadenaaverificar;
            if (var.Length == 13)
            {
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
            else
            {
                return false;
            }

        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRM_Ingresodedatos.aspx");
        }

    }
}