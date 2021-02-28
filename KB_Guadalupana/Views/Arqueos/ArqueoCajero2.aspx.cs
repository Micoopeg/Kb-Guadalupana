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
            usuarioDescripcion.InnerHtml = Session["Nombre"] as string;
            NombreUsuario.InnerHtml = Session["Nombre"] as string;
            Nombrefirma2.InnerHtml = Session["jefe"] as string;
            NombreFirma.InnerHtml = Session["Nombre"] as string;
            puesto2.InnerHtml = Session["puesto"] as string;
            id = Session["idcajero1"] as string;
            siguiente = Session["siguiente"] as string;
            if(siguiente == "1")
            {
                mostrardetalle();
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
                string[] valores3 = { sig2, "1", "2", CPCantidadDo.Value, CPMontoDo.Value, Convert.ToString(totaldolares), Convert.ToString(totaldolares), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores3);

                string sig3 = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores4 = { sig3, "2", "1", CACantidad.Value, CAMonto.Value, Convert.ToString(totaldolares), Convert.ToString(totalquetzales), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores4);

                string sig4 = logic.siguiente("sa_chequescajero", "idsa_chequescajero");
                string[] valores5 = { sig4, "2", "2", CACantidadDo.Value, CAMontoDo.Value, Convert.ToString(totaldolares), Convert.ToString(totaldolares), CBUtilizadas.Value, CBReservadas.Value, CBAnuladas.Value, idencabezado.ToString() };
                logic.insertartablas("sa_chequescajero", valores5);

                NombreFirma.InnerHtml = Session["Nombre"] as string;
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
            NombreFirma.InnerHtml = Session["Nombre"] as string;
            Nombrefirma2.InnerHtml = Session["jefe"] as string;
            puesto2.InnerHtml = Session["puesto"] as string;
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