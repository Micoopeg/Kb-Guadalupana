using System;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class AsignarProceso : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        Conexion conexiongeneral = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formulario.Visible = false;
                Session["confirmar"] = "0";
            }
        }

        protected void APBuscar_Click(object sender, EventArgs e)
        {
            if (NumCredito.Value == "" && PrimerNombre.Value == "" && PrimerApellido.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe ingresar al menos un dato');", true);
            }
            else
            {
                string[] campos = sn.obtenerinforcredito(NumCredito.Value);
                if (campos[0] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se encuentra crédito con esos datos');", true);
                }
                else
                {
                    Session["confirmar"] = "1";
                    formulario.Visible = true;
                    for (int i = 0; i < campos.Length; i++)
                    {
                        Agencia.Value = campos[1];
                        Instrumento.Value = campos[2];
                        LineaCredito.Value = campos[3];
                        destino.Value = campos[4];
                        Garantia.Value = campos[5];
                        Plazomeses.Value = campos[6];
                        Metodocalculo.Value = campos[7];
                        Estado.Value = campos[8];
                        Moneda.Value = campos[9];
                        Tasa.Value = campos[10];
                        string[] fecha = campos[11].Split(' ');
                        FechaSolicitud.Value = fecha[0];
                        string[] fecha2 = campos[12].Split(' ');
                        FechaDesembolso1.Value = fecha2[0];
                        string[] fecha3 = campos[13].Split(' ');
                        FechaUltimoDes.Value = fecha3[0];
                        string[] fecha4 = campos[14].Split(' ');
                        FechaVencimiento.Value = fecha4[0];
                        string[] fecha5 = campos[15].Split(' ');
                        FechaUltimaCuota.Value = fecha5[0];
                        FechaActa.Value = campos[16];
                        NumActa.Value = campos[17];
                        OficialNombre1.Value = campos[18];
                        OficialNombre2.Value = campos[19];
                        OficialApellido1.Value = campos[20];
                        OficialApellido2.Value = campos[21];
                        NumPrestamo.Value = campos[22];
                        AgenciaCliente.Value = campos[23];
                        CodigoCliente.Value = campos[24];
                        ClienteNombre1.Value = campos[25];
                        ClienteNombre2.Value = campos[26];
                        ClienteApellido1.Value = campos[27];
                        ClienteApellido2.Value = campos[28];
                        MontoOriginal.Value = campos[29];
                        CapitalDesem.Value = campos[30];
                        SaldoActual.Value = campos[31];
                        DescripcionDoc.Value = campos[34];
                    }
                }
            }
        }

        protected void APAsignar_Click(object sender, EventArgs e)
        {
            string confirmar = Session["confirmar"] as string;
            if (confirmar == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe confirmar antes los datos');", true);
            }
            else
            {
                string fechaactual = sn.datetime();
                string[] fecha = fechaactual.Split(' ');
                string año = fecha[0];
                string mes = fecha[1];
                string dia = fecha[2];

                string fechafinal = año + '-' + mes + '-' + dia;

                string sig = sn.siguiente("pj_asignacion_juridico", "idpj_asignacion_jutidico");
                sn.asignarcreditojuridico(sig, NumPrestamo.Value, fechafinal, "Pendiente");
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se asignó el crédito');", true);
            }
        }

    }
}