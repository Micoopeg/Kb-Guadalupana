using System;
using KB_Guadalupana.Models;
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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoCajeroAutomatico : System.Web.UI.Page
    {
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        Logica lg = new Logica();
        string fecha;
        string id;
        int cont = 0;
        char delimitador2 = ' ';
        char delimitador = ':';
        char delimitador3 = '-';
        string concat = "T";
        char concat2 = 'T';
        string numarqueo;
        string fechamin, horamin, fechahora, fechatotal1, año, mes, dia, dia2, usuario, puesto, idusuario, idusuario2;
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                puesto = Session["puesto_usuario"] as string;
                usuario = Session["sesion_usuario"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                NombreFirma.InnerHtml = Session["Nombre"] as string;
                llenarcomboagencia();
                llenarcombousuario();

                EBuscar.Visible = false;
                arqueo.Visible = false;
                now();
                visualizar.Visible = false;
                imprimir.Visible = false;
            }
        }

        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sa_agencia";
                    //MySqlConnection conect = cn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Agencia");
                    CAAgencia.DataSource = ds;
                    CAAgencia.DataTextField = "idsa_agencia";
                    CAAgencia.DataValueField = "idsa_agencia";
                    CAAgencia.DataBind();
                    CAAgencia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Código Agencia]", "0"));
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_usuario";
                    //MySqlConnection conect = cn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    CAUsuario.DataSource = ds;
                    CAUsuario.DataTextField = "gen_usuarionombre";
                    CAUsuario.DataValueField = "codgenusuario";
                    CAUsuario.DataBind();
                    CAUsuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Usuario]", "0"));
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void llenarcomboarqueos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "";
                    fecha = CABuscarfecha.Value;

                    string[] fechasep2 = fecha.Split(delimitador3);
                    año = fechasep2[0];
                    mes = fechasep2[1];
                    dia = fechasep2[2];
                    puesto = Session["puesto_usuario"] as string;
                    usuario = Session["sesion_usuario"] as string;
                    idusuario = sn.obteneridusuario(usuario);

                   
                    if (puesto == "1")
                    {
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadocajeroaut WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '"+ año +"' AND DATE_FORMAT(sa_fechayhora,  '%m') = '"+ mes +"' AND DATE_FORMAT(sa_fechayhora,  '%d') = '"+ dia +"' AND idsa_usuario = '"+ idusuario +"'";
                    }
                    else
                    {
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadocajeroaut WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + CAUsuario.SelectedValue + "'";
                    }
                    
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Arqueo");
                    DropNumarqueo.DataSource = ds;
                    DropNumarqueo.DataTextField = "sa_numarqueo";
                    DropNumarqueo.DataValueField = "sa_numarqueo";
                    DropNumarqueo.DataBind();
                    DropNumarqueo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Numero de arqueo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        protected void CAAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CACodigoagencia.Value = sn.nombreagencia(CAAgencia.SelectedValue);
        }

        protected void CAUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboarqueos();
        }
        protected void operar_Click(object sender, EventArgs e)
        {
            try
            {
                //SUBTOTAL BILLETES
                decimal subtotalb1, subtotalb2, subtotalb3, subtotalb4, subtotalb5, subtotalb6, subtotalb7;
                subtotalb1 = 200 * Convert.ToDecimal(CACantidad1.Value);
                //CASubtotalb1.Value = Convert.ToString(subtotalb1);
                subtotalb2 = 100 * Convert.ToDecimal(CACantidad2.Value);
                //CASubtotalb2.Value = Convert.ToString(subtotalb2);
                subtotalb3 = 50 * Convert.ToDecimal(CACantidad3.Value);
                //CASubtotalb3.Value = Convert.ToString(subtotalb3);
                subtotalb4 = 20 * Convert.ToDecimal(CACantidad4.Value);
                //CASubtotalb4.Value = Convert.ToString(subtotalb4);
                subtotalb5 = 10 * Convert.ToDecimal(CACantidad5.Value);
                //CASubtotalb5.Value = Convert.ToString(subtotalb5);
                subtotalb6 = 5 * Convert.ToDecimal(CACantidad6.Value);
                //CASubtotalb6.Value = Convert.ToString(subtotalb6);
                subtotalb7 = 1 * Convert.ToDecimal(CACantidad7.Value);
                //CASubtotalb7.Value = Convert.ToString(subtotalb7);

                //TOTAL BILLETES
                decimal totalb;
                totalb = Convert.ToDecimal(subtotalb1) + Convert.ToDecimal(subtotalb2) + Convert.ToDecimal(subtotalb3) + Convert.ToDecimal(subtotalb4) +
                         Convert.ToDecimal(subtotalb5) + Convert.ToDecimal(subtotalb6) + Convert.ToDecimal(subtotalb7);
                //CATotalb.Value = Convert.ToString(totalb);

                //SUBTOTAL MONEDAS
                decimal subtotalm1, subtotalm2, subtotalm3, subtotalm4, subtotalm5, subtotalm6;
                subtotalm1 = 1 * Convert.ToDecimal(CACantidadm1.Value);
                //CASubtotalm1.Value = Convert.ToString(subtotalm1);
                subtotalm2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(CACantidadm2.Value);
                //CASubtotalm2.Value = Convert.ToString(subtotalm2);
                subtotalm3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(CACantidadm3.Value);
                //CASubtotalm3.Value = Convert.ToString(subtotalm3);
                subtotalm4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(CACantidadm4.Value);
                //CASubtotalm4.Value = Convert.ToString(subtotalm4);
                subtotalm5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(CACantidadm5.Value);
                //CASubtotalm5.Value = Convert.ToString(subtotalm5);
                subtotalm6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(CACantidadm6.Value);
                //CASubtotalm6.Value = Convert.ToString(subtotalm6);

                //TOTAL MONEDAS
                decimal totalm;
                //totalm = subtotalm1 + subtotalm2 + subtotalm3 + subtotalm4 + subtotalm5 + subtotalm6;
                totalm = Convert.ToDecimal(subtotalm1) + Convert.ToDecimal(subtotalm2) + Convert.ToDecimal(subtotalm3) +
                         Convert.ToDecimal(subtotalm4) + Convert.ToDecimal(subtotalm5) + Convert.ToDecimal(subtotalm6);
                //CATotalm.Value = Convert.ToString(totalm);

                //TOTAL EFECTIVO
                decimal totalefectivo;
                totalefectivo = Convert.ToDecimal(totalb) + Convert.ToDecimal(totalm);
                //CATotalefectivo.Value = totalefectivo.ToString();

                //DIFERENCIA
                decimal diferencia;
                diferencia = Convert.ToDecimal(totalefectivo) - Convert.ToDecimal(CAEfectivoreporte.Value);
                //CADiferencia.Value = diferencia.ToString();

                //INSERTAR ENCABEZADO
                fecha = CAFecha.Value;
                string numeroarqueo = "";

                string[] fechasep2 = fecha.Split(delimitador3);
                año = fechasep2[0];
                mes = fechasep2[1];
                dia2 = fechasep2[2];

                string[] fechadia = dia2.Split(concat2);
                dia = fechadia[0];
                puesto = Session["puesto_usuario"] as string;

                string[] fechadia2 = dia2.Split(delimitador2);
                string dia3 = fechadia2[0];
                string hora = fechadia2[1];

                string[] horayfecha = hora.Split(delimitador);
                string hora1 = horayfecha[0];
                string minutos = horayfecha[1];

                string fechayhora2 = dia3 + '-' + mes + '-' + año + ' ' + hora1 + ':' + minutos;

                usuario = Session["sesion_usuario"] as string;
                idusuario = sn.obteneridusuario(usuario);
                numeroarqueo = sn.numarqueoCA(dia3, mes, año, idusuario);

                string sig = logic.siguiente("sa_encabezadocajeroaut", "idsa_encabezadocajeroaut");
                string[] valores1 = { sig, numeroarqueo, idusuario, fechayhora2, CAAgencia.SelectedValue, CAOperador.Value, CANumperador.Value, CAPuestooperador.Value, CANombreencargado.Value, CAPuestoencargado.Value, CAAtm.Value };
                logic.insertartablas("sa_encabezadocajeroaut", valores1);
                lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Ingreso de datos", "Creación de arqueo Cajero Automático");

                //INSERTAR DETALLE
                string sig2 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores2 = { sig2, "1", CACantidad1.Value, Convert.ToString(subtotalb1), Convert.ToString(totalb), "1", CACantidadm1.Value, Convert.ToString(subtotalm1), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores2);
                string sig3 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores3 = { sig3, "2", CACantidad2.Value, Convert.ToString(subtotalb2), Convert.ToString(totalb), "2", CACantidadm2.Value, Convert.ToString(subtotalm2), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores3);
                string sig4 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores4 = { sig4, "3", CACantidad3.Value, Convert.ToString(subtotalb3), Convert.ToString(totalb), "3", CACantidadm3.Value, Convert.ToString(subtotalm3), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores4);
                string sig5 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores5 = { sig5, "4", CACantidad4.Value, Convert.ToString(subtotalb4), Convert.ToString(totalb), "4", CACantidadm4.Value, Convert.ToString(subtotalm4), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores5);
                string sig6 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores6 = { sig6, "5", CACantidad5.Value, Convert.ToString(subtotalb5), Convert.ToString(totalb), "5", CACantidadm5.Value, Convert.ToString(subtotalm5), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores6);
                string sig7 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores7 = { sig7, "6", CACantidad6.Value, Convert.ToString(subtotalb6), Convert.ToString(totalb), "6", CACantidadm6.Value, Convert.ToString(subtotalm5), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores7);
                string sig8 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores8 = { sig8, "7", CACantidad7.Value, Convert.ToString(subtotalb7), Convert.ToString(totalb), "8", "0", "0", Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores8);

                NombreFirma2.InnerHtml = CAOperador.Value;
                puesto2.InnerHtml = CAPuestooperador.Value;
                puesto3.InnerHtml = CAPuestoencargado.Value;

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

        protected void buscar_Click(object sender, EventArgs e)
        {
            if(CABuscarfecha.Value == "")
            {
                String script = "alert('Debe ingresar la fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                numarqueo = DropNumarqueo.SelectedValue;
                mostrarcajeroauto();
                if (cont == 1)
                {
                    arqueo.Visible = false;
                    EBuscar.Visible = false;
                }
                else
                {
                    mostrardetalle();
                    arqueo.Visible = true;
                    Creararqueo.Visible = false;
                    Buscararqueo.Visible = false;
                    visualizar.Visible = true;
                    imprimir.Visible = true;
                    operar.Visible = false;
                    EBuscar.Visible = false;
                }
            }
        }

        public void mostrarcajeroauto()
        {
            numarqueo = DropNumarqueo.SelectedValue;
            fecha = CABuscarfecha.Value;

            string[] fechasep2 = fecha.Split(delimitador3);
            año = fechasep2[0];
            mes = fechasep2[1];
            dia = fechasep2[2];
            CAFecha.Attributes.Add("value", fechatotal1);
            puesto = Session["puesto_usuario"] as string;
            usuario = Session["sesion_usuario"] as string;
            idusuario = sn.obteneridusuario(usuario);
            lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Consulta de datos", "Búsqueda de arqueo Cajero Automático");

            string[] var;
            if (puesto == "1")
            {
                var = sn.mostrarencabezadoCA(año, mes, dia, idusuario, numarqueo);
            }
            else
            {
                var = sn.mostrarencabezadoCA(año, mes, dia, CAUsuario.SelectedValue, numarqueo);
            }
            
            if (var[1] == null)
            {
                String script = "alert('No existe arqueo con esa fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                cont = 1;
            }
            else
            {
                for (int i = 0; i < var.Length; i++)
                {
                    id = Convert.ToString(var[0]);
                    string fechaenc = Convert.ToString(var[1]);
                    //CAFecha.Value = Convert.ToString(var[1]);
                    CAAgencia.SelectedValue = Convert.ToString(var[2]);
                    CACodigoagencia.Value = Convert.ToString(sn.nombreagencia(var[2]));
                    CAOperador.Value = Convert.ToString(var[3]);
                    CANumperador.Value = Convert.ToString(var[4]);
                    CAPuestooperador.Value = Convert.ToString(var[5]);
                    CANombreencargado.Value = Convert.ToString(var[6]);
                    CAPuestoencargado.Value = Convert.ToString(var[7]);
                    CAAtm.Value = Convert.ToString(var[8]);
                    NombreFirma2.InnerText = Convert.ToString(var[3]);
                    NombreFirma.InnerHtml = Convert.ToString(var[6]);
                    puesto2.InnerHtml = Convert.ToString(var[5]);
                    puesto3.InnerHtml = Convert.ToString(var[7]);

                    string[] fechasep = fechaenc.Split(delimitador2);
                    string[] horai = fechasep[3].Split(delimitador);
                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + ' ' + horai[0] + ":" + horai[1];
                    CAFecha.Attributes.Add("value", fechatotal1);
                }
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            String script = "alert('FUNCIONA');";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //panelPDF.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
            //HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            //pdfDoc.Open();
            //htmlParser.Parse(sr);
            //pdfDoc.Close();

            //Response.Write(pdfDoc);
            //Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        //protected void prueba_Click(object sender, EventArgs e)
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
        //    Response.ClearContent();
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    panelPDF.RenderControl(hw);
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
        //    HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //    pdfDoc.Open();
        //    htmlParser.Parse(sr);
        //    pdfDoc.Close();

        //    Response.Write(pdfDoc);
        //    Response.End();
        //}

        public void mostrardetalle1()
        {
            string[] var = sn.mostrardetalleCA1(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad1.Value = Convert.ToString(var[2]);
                CASubtotalb1.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm1.Value = Convert.ToString(var[6]);
                CASubtotalm1.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleCA2(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad2.Value = Convert.ToString(var[2]);
                CASubtotalb2.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm2.Value = Convert.ToString(var[6]);
                CASubtotalm2.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleCA3(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad3.Value = Convert.ToString(var[2]);
                CASubtotalb3.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm3.Value = Convert.ToString(var[6]);
                CASubtotalm3.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleCA4(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad4.Value = Convert.ToString(var[2]);
                CASubtotalb4.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm4.Value = Convert.ToString(var[6]);
                CASubtotalm4.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleCA5(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad5.Value = Convert.ToString(var[2]);
                CASubtotalb5.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm5.Value = Convert.ToString(var[6]);
                CASubtotalm5.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleCA6(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad6.Value = Convert.ToString(var[2]);
                CASubtotalb6.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm6.Value = Convert.ToString(var[6]);
                CASubtotalm6.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleCA7(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad7.Value = Convert.ToString(var[2]);
                CASubtotalb7.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        protected void creararqueo_Click(object sender, EventArgs e)
        {
            string usuario3, consulta;
            usuario3 = Session["sesion_usuario"] as string;
            idusuario2 = sn.obteneridusuario(usuario3);
            consulta = sn.consultararqueoCA(idusuario2);

            arqueo.Visible = true;
            Creararqueo.Visible = false;
            Buscararqueo.Visible = false;
            visualizar.Visible = true;
            imprimir.Visible = true;
            CANombreencargado.Value = Session["Nombre"] as string;
            NombreFirma.InnerHtml = Session["Nombre"] as string;
            operar.Enabled = true;
            EBuscar.Visible = false;





            //if (consulta == "")
            //{
            //    arqueo.Visible = true;
            //    Creararqueo.Visible = false;
            //    Buscararqueo.Visible = false;
            //    visualizar.Visible = true;
            //    imprimir.Visible = true;
            //    CANombreencargado.Value = Session["Nombre"] as string;
            //    NombreFirma.InnerHtml = Session["Nombre"] as string;
            //}
            //else
            //{
            //    String script = "alert('Ya tiene un arqueo creado por el dia de hoy');";
            //    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            //    arqueo.Visible = false;
            //    EBuscar.Visible = false;
            //    visualizar.Visible = false;
            //    imprimir.Visible = false;
            //}

        }

        protected void buscararqueo_Click(object sender, EventArgs e)
        {
            puesto = Session["puesto_usuario"] as string;
            EBuscar.Visible = true;
            visualizar.Visible = false;
            imprimir.Visible = false;

            if (puesto == "1")
            {
                CAUsuario.Visible = false;
                TituloUsuario.Visible = false;
            }
            else if (puesto == "2")
            {
                CAUsuario.Visible = true;
            }


        }


        protected void btnArqueos_Click(object sender, EventArgs e)
        {
            llenarcomboarqueos();
        }

        public void now()
        {

            string[] fecha = sn.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador);
                    fechahora = valores2[2] + "-" + valores2[1] + "-" + valores2[0] + delimitador2 + horas[0] + ":" + horas[1];

                    CAFecha.Attributes.Add("value", fechahora);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}