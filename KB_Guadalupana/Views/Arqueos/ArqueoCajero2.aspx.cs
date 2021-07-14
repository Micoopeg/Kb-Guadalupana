using System;
using SA_Arqueos.Controllers;
using SA_Arqueos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoCajero2 : System.Web.UI.Page
    {
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string id;
        string siguiente;
        protected void Page_Load(object sender, EventArgs e)
        {
            operadorDescripción.InnerHtml = Session["operador"] as string;
            usuarioDescripcion.InnerHtml = Session["nombreoperador"] as string;
            NombreUsuario.InnerHtml = Session["Nombre"] as string;
            Nombrefirma2.InnerHtml = Session["nombreoperador"] as string;
            NombreFirma.InnerHtml = Session["jefe"] as string;
            puesto2.InnerHtml = Session["puestooperador"] as string;
            puesto.InnerHtml = Session["puesto"] as string;
            id = Session["idcajero1"] as string;
            siguiente = Session["siguiente"] as string;
            operar.Enabled = true;
            if (siguiente == "1")
            {
                mostrardetalle();
                operar.Visible = false;
            }
           
        }

        protected void anterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoCajero.aspx");
            
        }

        protected void operar_Click(object sender, EventArgs e)
        {
            try
            {
                //TOTALES DE MONTO QUETZALES
                decimal totalquetzales;
                totalquetzales = Convert.ToDecimal(CPMonto.Value) + Convert.ToDecimal(CAMonto.Value);
                //CQTotal.Value = totalquetzales.ToString();

                //TOTALES DE MONTO DOLARES
                decimal totaldolares;
                totaldolares = Convert.ToDecimal(CPMontoDo.Value) + Convert.ToDecimal(CAMontoDo.Value);
                //CDTotal.Value = totaldolares.ToString();

                //INSERTAR DATOS DE CHEQUES
                string idencabezado = Session["id"] as string;
                //CQTotal.Value = idencabezado.ToString();
                string sig = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores2 = { sig, "1", "1", CPCantidad.Value, CPMonto.Value, Convert.ToString(totaldolares), Convert.ToString(totalquetzales), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores2);

                string sig2 = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores3 = { sig2, "1", "2", CPCantidadDo.Value, CPMontoDo.Value, Convert.ToString(totaldolares), Convert.ToString(totalquetzales), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores3);

                string sig3 = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores4 = { sig3, "2", "1", CACantidad.Value, CAMonto.Value, Convert.ToString(totaldolares), Convert.ToString(totalquetzales), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores4);

                string sig4 = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores5 = { sig4, "2", "2", CACantidadDo.Value, CAMontoDo.Value, Convert.ToString(totaldolares), Convert.ToString(totalquetzales), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores5);

                NombreFirma.InnerHtml = Session["Nombre"] as string;
                Nombrefirma2.InnerHtml = Session["nombreoperador"] as string;
                puesto2.InnerHtml = Session["puestooperador"] as string;
                puesto.InnerHtml = puesto.InnerHtml = Session["puesto"] as string;

                String script = "alert('Se han guardado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                operar.Enabled = false;
            }

            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            finally { try { cn.desconectar(); } catch { } }
        }

        public void mostrardetalle()
        {
            mostrardetalle1();
            mostrardetalle2();
            mostrardetalle3();
            mostrardetalle4();
            operar.Visible = true;
            NombreFirma.InnerHtml = Session["jefe"] as string;
            Nombrefirma2.InnerHtml = Session["nombreoperador"] as string;
            puesto2.InnerHtml = Session["puestooperador"] as string;
            puesto.InnerHtml = Session["puesto"] as string;
            usuarioDescripcion.InnerHtml = Session["nombreoperador"] as string;
            operadorDescripción.InnerHtml = Session["operador"] as string;
            operar.Visible = false;
        }

        public void mostrardetalle1()
        {
            string[] var = sn.mostrarchequeC1(id);
            for (int i = 0; i < var.Length; i++)
            {
                CPCantidad.Value = Convert.ToString(var[3]);
                CPMonto.Value = Convert.ToString(var[4]);
                CDTotal.InnerHtml = Convert.ToString(var[5]);
                CQTotal.InnerHtml = Convert.ToString(var[6]);
                CBUtilizadas.Value = Convert.ToString(var[7]);
                CBReservadas.Value = Convert.ToString(var[8]);
                CBAnuladas.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrarchequeC2(id);
            for (int i = 0; i < var.Length; i++)
            {
                CPCantidadDo.Value = Convert.ToString(var[3]);
                CPMontoDo.Value = Convert.ToString(var[4]);
                CDTotal.InnerHtml = Convert.ToString(var[5]);
                CQTotal.InnerHtml = Convert.ToString(var[6]);
                CBUtilizadas.Value = Convert.ToString(var[7]);
                CBReservadas.Value = Convert.ToString(var[8]);
                CBAnuladas.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrarchequeC3(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad.Value = Convert.ToString(var[3]);
                CAMonto.Value = Convert.ToString(var[4]);
                CDTotal.InnerHtml = Convert.ToString(var[5]);
                CQTotal.InnerHtml = Convert.ToString(var[6]);
                CBUtilizadas.Value = Convert.ToString(var[7]);
                CBReservadas.Value = Convert.ToString(var[8]);
                CBAnuladas.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrarchequeC4(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidadDo.Value = Convert.ToString(var[3]);
                CAMontoDo.Value = Convert.ToString(var[4]);
                CDTotal.InnerHtml = Convert.ToString(var[5]);
                CQTotal.InnerHtml = Convert.ToString(var[6]);
                CBUtilizadas.Value = Convert.ToString(var[7]);
                CBReservadas.Value = Convert.ToString(var[8]);
                CBAnuladas.Value = Convert.ToString(var[9]);
            }
        }
    }
}