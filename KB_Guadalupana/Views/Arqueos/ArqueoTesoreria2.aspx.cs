using System;
using SA_Arqueos.Controllers;
using SA_Arqueos.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoTesoreria2 : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Logica_arqueos logic2 = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string id, fecha, año, mes, dia;
        char delimitador2 = ' ';
        char delimitador = ':';
        string concat = "T";
        string fechatotal1, siguiente;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NombreFirma.InnerHtml = Session["Nombre"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                id = Session["idtesoreria"] as string;
                TDFechayhora.Value = Session["fecha"] as string;
                TDAgencia.SelectedValue = Session["agencia2"] as string;
                TDCodigoagencia.Value = Session["codigoagencia"] as string;
                TDNombreop.Value = Session["nombreop"] as string;
                TDNumoperador.Value = Session["numoperador"] as string;
                TDPuestooperador.Value = Session["puestooperador"] as string;
                TDNombreencargado.Value = Session["nombreencargado"] as string;
                TDPuestoencargado.Value = Session["puestoencargado"] as string;
                operar.Enabled = true;
                NombreFirma2.InnerHtml = Session["nombreop"] as string;
                puesto2.InnerHtml = Session["puestooperador"] as string;
                puesto3.InnerHtml = Session["puestoencargado"] as string;
                operar.Visible = true;

                llenarcomboagencia();

                siguiente = Session["siguiente2"] as string;
                if (siguiente == "1")
                {
                    mostrartesoreria();
                    mostrardetalle();
                    mostrarcheques();
                    operar.Visible = false;
                }
                   
            }
        }

        protected void TDAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TDCodigoagencia.Value = sn.nombreagencia(TDAgencia.SelectedValue);
        }
        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sa_agencia";
                    MySqlConnection conect = cn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Agencia");
                    TDAgencia.DataSource = ds;
                    TDAgencia.DataTextField = "idsa_agencia";
                    TDAgencia.DataValueField = "idsa_agencia";
                    TDAgencia.DataBind();
                    TDAgencia.Items.Insert(0, new ListItem("[Código Agencia]", "0"));
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        protected void atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArqueoTesoreria.aspx");
        }

        protected void operar_Click(object sender, EventArgs e)
        {
            try
            {
                //SUBTOTAL BILLETES
                decimal subtotalb1, subtotalb2, subtotalb3, subtotalb4, subtotalb5, subtotalb6, subtotalb7;
                subtotalb1 = Convert.ToDecimal(200.00) * Convert.ToDecimal(TDCantidadb1.Value);
                //TDSubtotalb1.Value = Convert.ToString(subtotalb1);
                subtotalb2 = Convert.ToDecimal(100.00) * Convert.ToDecimal(TDCantidadb2.Value);
                //TDSubtotalb2.Value = Convert.ToString(subtotalb2);
                subtotalb3 = Convert.ToDecimal(50.00) * Convert.ToDecimal(TDCantidadb3.Value);
                //TDSubtotalb3.Value = Convert.ToString(subtotalb3);
                subtotalb4 = Convert.ToDecimal(20.00) * Convert.ToDecimal(TDCantidadb4.Value);
                //TDSubtotalb4.Value = Convert.ToString(subtotalb4);
                subtotalb5 = Convert.ToDecimal(10.00) * Convert.ToDecimal(TDCantidadb5.Value);
                //TDSubtotalb5.Value = Convert.ToString(subtotalb5);
                subtotalb6 = Convert.ToDecimal(5.00) * Convert.ToDecimal(TDCantidadb6.Value);
                //TDSubtotalb6.Value = Convert.ToString(subtotalb6);
                subtotalb7 = Convert.ToDecimal(1.00) * Convert.ToDecimal(TDCantidadb7.Value);
                //TDSubtotalb7.Value = Convert.ToString(subtotalb7);

                //TOTAL BILLETES
                decimal totalbilletes;
                totalbilletes = Convert.ToDecimal(subtotalb1) + Convert.ToDecimal(subtotalb2) + Convert.ToDecimal(subtotalb3) + Convert.ToDecimal(subtotalb4) +
                                Convert.ToDecimal(subtotalb5) + Convert.ToDecimal(subtotalb6) + Convert.ToDecimal(subtotalb7);
                //TDTtotalb.Value = Convert.ToString(totalbilletes);

                //SUBTOTAL MONEDAS
                decimal subtotalm1, subtotalm2, subtotalm3, subtotalm4, subtotalm5, subtotalm6;
                subtotalm1 = Convert.ToDecimal(1.00) * Convert.ToDecimal(TDCantidadm1.Value);
                //TDSubtotalm1.Value = Convert.ToString(subtotalm1);
                subtotalm2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(TDCantidadm2.Value);
                //TDSubtotalm2.Value = Convert.ToString(subtotalm2);
                subtotalm3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(TDCantidadm3.Value);
                //TDSubtotalm3.Value = Convert.ToString(subtotalm3);
                subtotalm4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(TDCantidadm4.Value);
                //TDSubtotalm4.Value = Convert.ToString(subtotalm4);
                subtotalm5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(TDCantidadm5.Value);
                //TDSubtotalm5.Value = Convert.ToString(subtotalm5);
                subtotalm6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(TDCantidadm6.Value);
                //TDSubtotalm6.Value = Convert.ToString(subtotalm6);

                //TOTAL MONEDAS
                decimal totalmonedas;
                totalmonedas = Convert.ToDecimal(subtotalm1) + Convert.ToDecimal(subtotalm2) + Convert.ToDecimal(subtotalm3) +
                               Convert.ToDecimal(subtotalm4) + Convert.ToDecimal(subtotalm5) + Convert.ToDecimal(subtotalm6);
                //TDTotalm.Value = Convert.ToString(totalmonedas);

                //TOTAL EFECTIVO
                decimal totalefectivo;
                totalefectivo = Convert.ToDecimal(totalbilletes) + Convert.ToDecimal(totalmonedas);
                //TDTotal.Value = Convert.ToString(totalefectivo);

                //DEPOSITO
                decimal deposito;
                deposito = Convert.ToDecimal(totalefectivo) + Convert.ToDecimal(TDRemesa.Value);
                //TDDeposito.Value = Convert.ToString(deposito);

                //CANTIDAD CHEQUES
                int cantidad;
                cantidad = Convert.ToInt32(TDChequesp.Value) + Convert.ToInt32(TDChequesa.Value);
                //TDTotalcheques.Value = Convert.ToString(cantidad);

                //TOTAL MONTO CHEQUES
                decimal monto;
                monto = Convert.ToDecimal(TDMontoa.Value) + Convert.ToDecimal(TDMontop.Value);
                //TDTotalmonto.Value = Convert.ToString(monto);

                //INSERTAR ENCABEZADO
                id = Session["idtesoreria"] as string;
                sn.modificarencabezado(TDTesoreria.Value, id);
                
                //string sig = logic.siguiente("sa_encabezadotesoreria", "idsa_encabezadotesoreria");
                //string[] valores = { sig, "2", TDFechayhora.Value, TDAgencia.SelectedValue, TDNombreop.Value, TDNumoperador.Value, TDNombreencargado.Value, TDPuestoencargado.Value, "", TDTesoreria.Value };
                //logic.insertartablas("sa_encabezadotesoreria", valores);

                //INSERTAR DETALLE
                string sig1 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores1 = { sig1, "2", "1", TDCantidadb1.Value, Convert.ToString(subtotalb1), Convert.ToString(totalbilletes), "1", TDCantidadm1.Value, Convert.ToString(subtotalm1), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores1);
                string sig2 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores2 = { sig2, "2", "2", TDCantidadb2.Value, Convert.ToString(subtotalb2), Convert.ToString(totalbilletes), "2", TDCantidadm2.Value, Convert.ToString(subtotalm2), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores2);
                string sig3 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores3 = { sig3, "2", "3", TDCantidadb3.Value, Convert.ToString(subtotalb3), Convert.ToString(totalbilletes), "3", TDCantidadm3.Value, Convert.ToString(subtotalm3), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores3);
                string sig4 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores4 = { sig4, "2", "4", TDCantidadb4.Value, Convert.ToString(subtotalb4), Convert.ToString(totalbilletes), "4", TDCantidadm4.Value, Convert.ToString(subtotalm4), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores4);
                string sig5 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores5 = { sig5, "2", "5", TDCantidadb5.Value, Convert.ToString(subtotalb5), Convert.ToString(totalbilletes), "5", TDCantidadm5.Value, Convert.ToString(subtotalm5), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores5);
                string sig6 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores6 = { sig6, "2", "6", TDCantidadb6.Value, Convert.ToString(subtotalb6), Convert.ToString(totalbilletes), "6", TDCantidadm6.Value, Convert.ToString(subtotalm6), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores6);
                string sig7 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores7 = { sig7, "2", "7", TDCantidadb7.Value, Convert.ToString(subtotalb7), Convert.ToString(totalbilletes), "8", "0", "0", Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), "0", "0", "0", TDRemesa.Value, Convert.ToString(deposito), id };
                logic.insertartablas("sa_detalletesoreria", valores7);

                //INSERTAR CHEQUE
                string sig8 = logic.siguiente("sa_chequestesoreria", "idsa_chequestesoreria");
                string[] valores8 = { sig8, "1", "2", TDChequesp.Value, TDMontop.Value, Convert.ToString(cantidad), Convert.ToString(monto), id };
                logic.insertartablas("sa_chequestesoreria", valores8);
                string sig9 = logic.siguiente("sa_chequestesoreria", "idsa_chequestesoreria");
                string[] valores9 = { sig9, "2", "2", TDChequesa.Value, TDMontoa.Value, Convert.ToString(cantidad), Convert.ToString(monto), id };
                logic.insertartablas("sa_chequestesoreria", valores9);

                String script = "alert('Se han guardado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                operar.Enabled = false;

                //NombreFirma.InnerHtml = Session["Nombre"] as string;
                //NombreFirma2.InnerHtml = TDNombreencargado.Value;
                //puesto2.InnerHtml = TDPuestoencargado.Value;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { cn.desconectar(); } catch { } }
        }

        public void mostrartesoreria()
        {
            string[] var = sn.mostrarencabezadoT2(id);
            for (int i = 0; i < var.Length; i++)
            {
                id = Convert.ToString(var[0]);
                string fechaenc = Convert.ToString(var[1]);
                TDAgencia.SelectedValue = Convert.ToString(var[2]);
                TDCodigoagencia.Value = Convert.ToString(sn.nombreagencia(var[2]));
                TDNombreop.Value = Convert.ToString(var[3]);
                TDNumoperador.Value = Convert.ToString(var[4]);
                TDPuestooperador.Value = Convert.ToString(var[5]);
                TDNombreencargado.Value = Convert.ToString(var[6]);
                TDPuestoencargado.Value = Convert.ToString(var[7]);
                TDTesoreria.Value = Convert.ToString(var[9]);
                //string idcajero1 = id.ToString();
                //Session["idcajero1"] = idcajero1.ToString();

                string[] fechasep = fechaenc.Split(delimitador2);
                string[] horai = fechasep[3].Split(delimitador);
                fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + ' ' + horai[0] + ":" + horai[1];
                TDFechayhora.Attributes.Add("value", fechatotal1);

                NombreFirma2.InnerHtml = TDNombreop.Value;
                NombreFirma.InnerHtml = TDNombreencargado.Value;
                puesto2.InnerHtml = TDPuestooperador.Value;
                puesto3.InnerHtml = TDPuestoencargado.Value;
            }
        }

        public void mostrardetalle()
        {
            mostrardetalle1();
            mostrardetalle2();
            mostrardetalle3();
            mostrardetalle4();
            mostrardetalle5();
            mostrardetalle6();
            mostrardetalle7();
        }

        public void mostrardetalle1()
        {
            string[] var = sn.mostrardetalleTD1(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb1.Value = Convert.ToString(var[3]);
                TDSubtotalb1.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm1.Value = Convert.ToString(var[7]);
                TDSubtotalm1.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleTD2(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb2.Value = Convert.ToString(var[3]);
                TDSubtotalb2.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm2.Value = Convert.ToString(var[7]);
                TDSubtotalm2.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleTD3(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb3.Value = Convert.ToString(var[3]);
                TDSubtotalb3.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm3.Value = Convert.ToString(var[7]);
                TDSubtotalm3.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleTD4(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb4.Value = Convert.ToString(var[3]);
                TDSubtotalb4.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm4.Value = Convert.ToString(var[7]);
                TDSubtotalm4.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleTD5(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb5.Value = Convert.ToString(var[3]);
                TDSubtotalb5.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm5.Value = Convert.ToString(var[7]);
                TDSubtotalm5.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleTD6(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb6.Value = Convert.ToString(var[3]);
                TDSubtotalb6.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDCantidadm6.Value = Convert.ToString(var[7]);
                TDSubtotalm6.InnerHtml = Convert.ToString(var[8]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleTD7(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDCantidadb7.Value = Convert.ToString(var[3]);
                TDSubtotalb7.InnerHtml = Convert.ToString(var[4]);
                TDTtotalb.InnerHtml = Convert.ToString(var[5]);
                TDTotalm.InnerHtml = Convert.ToString(var[9]);
                TDTotal.InnerHtml = Convert.ToString(var[10]);
                TDRemesa.Value = Convert.ToString(var[14]);
                TDDeposito.InnerHtml = Convert.ToString(var[15]);
            }
        }

        public void mostrarcheques()
        {
            mostrarcheque1();
            mostrarcheque2();
        }

        public void mostrarcheque1()
        {
            string[] var = sn.mostrarchequesTD1(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDChequesp.Value = Convert.ToString(var[3]);
                TDMontop.Value = Convert.ToString(var[4]);
                TDTotalcheques.InnerHtml = Convert.ToString(var[5]);
                TDTotalmonto.InnerHtml = Convert.ToString(var[6]);
            }
        }

        public void mostrarcheque2()
        {
            string[] var = sn.mostrarchequesTD2(id);
            for (int i = 0; i < var.Length; i++)
            {
                TDChequesa.Value = Convert.ToString(var[3]);
                TDMontoa.Value = Convert.ToString(var[4]);
                TDTotalcheques.InnerHtml = Convert.ToString(var[5]);
                TDTotalmonto.InnerHtml = Convert.ToString(var[6]);
            }
        }
    }
}