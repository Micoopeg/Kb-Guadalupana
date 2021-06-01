using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class RequerimientoPago : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string numcredito = Session["credito"] as string;
                if (sn.etapavoucher(numcredito) == "")
                {
                    llenarformulario();
                    llenargridviewdocumentos();
                    llenarinputs();
                    llenarcombomotivo();
                    datosfactura();
                    llenarcombodocumento();
                    Otro.Visible = false;
                    voucher.Visible = false;
                    GuardarVoucher.Visible = false;
                }
                else
                {
                    llenarformulario();
                    Guardar.Visible = false;
                    Generar.Visible = false;
                    voucher.Visible = true;
                    GuardarVoucher.Visible = true;
                    Actualizar.Visible = false;
                    pfd.Visible = false;
                    llenargridviewdocumentos();
                    llenarinputs();
                    llenarcombomotivo();
                    datosfactura();
                    llenarcombodocumento();
                }
            
            }
        }

        public void llenargridviewdocumentos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento IN (1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDocumentos.DataSource = dt;
                    gridViewDocumentos.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedDocumento(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentos.SelectedRow.FindControl("lblid") as Label).Text);
                string documentoselec = sn.obtenerrutadocumento(id);
                string FilePath = Server.MapPath(documentoselec);
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
            }
            catch
            {

            }
        }

        protected void Generar_Click(object sender, EventArgs e)
        {
            if(Observaciones.Value == "" || RegistroContable.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", "Debe llenar todos los campos", true);
            }
            else
            {
                GenerarPDF();
            }
           
        }

        public void GenerarPDF()
        {
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.Open();
                doc.NewPage();
                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                doc.AddAuthor("Certificacion");
                doc.AddTitle("Caratulas");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgaortiz/Documents/Rama-Aida/Kb-Guadalupana/KB_Guadalupana/Imagenes/Imagenes_procesos/encabezado_cheque.jpg"));
                logo.ScalePercent(35f);
                logo.Alignment = Element.ALIGN_CENTER;

                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont basf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT2 = "c:/windows/fonts/arialbd.ttf";
                BaseFont basf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_subtitulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new Font(_parrafo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 11f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph("Elaborado por: " + NombreUsuario.Value, new Font(basf, 11));
                def2.Alignment = Element.ALIGN_LEFT;
                doc.Add(def2);

                iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("Asistente de Gerencia Jurídica", new Font(basf, 11));
                def4.Alignment = Element.ALIGN_LEFT;
                doc.Add(def4);
                doc.Add(new Paragraph(" ", parrafo));

                doc.Add(logo);

                iTextSharp.text.Paragraph def = new iTextSharp.text.Paragraph("Solicitud de Cheque", new Font(basf, 17));
                def.Alignment = Element.ALIGN_CENTER;
                doc.Add(def);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph(FechaActual.Value, new Font(basf, 11));
                def5.Alignment = Element.ALIGN_RIGHT;
                doc.Add(def5);
                 
                var tbl1 = new PdfPTable(new float[] { 25f, 65f }) { WidthPercentage = 100 };
                tbl1.AddCell(new PdfPCell(new Phrase("Cheque al nombre de: ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl1.AddCell(new PdfPCell(new Phrase(NombreCheque.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_LEFT });
                doc.Add(new Phrase(" "));
                tbl1.AddCell(new PdfPCell(new Phrase("Monto a pagar: ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl1.AddCell(new PdfPCell(new Phrase("Q " + ImporteTotal2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_LEFT });
                doc.Add(new Phrase(" "));
                tbl1.AddCell(new PdfPCell(new Phrase("Concepto de: ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl1.AddCell(new PdfPCell(new Phrase("Pago por gastos y honorarios profesionales por elaboración y presentación de 6 desistimientos promovidos por Cooperativa de Ahorro y Crédito Integral Parroquial Guadalupana, R.L. bajo los oficios de " + NombreCheque.Value + " en contra de los asociados responsables del impago de sus obligaciones creditícias, según cuadro adjunto", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_JUSTIFIED });
                doc.Add(new Phrase(" "));
                tbl1.AddCell(new PdfPCell(new Phrase("Observaciones: ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl1.AddCell(new PdfPCell(new Phrase(Observaciones.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_JUSTIFIED });
                doc.Add(new Phrase(" "));
                tbl1.AddCell(new PdfPCell(new Phrase("Resgistro Contable: ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl1.AddCell(new PdfPCell(new Phrase(RegistroContable.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_LEFT });
                doc.Add(new Phrase(" "));
                doc.Add(tbl1);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                iTextSharp.text.Paragraph def6 = new iTextSharp.text.Paragraph("Nota: Como Jefe Jurídico, hago constar que he leído el contenido de los documentos que respaldan el presente recibo presentado por " + NombreCheque.Value, new Font(basf, 12));
                def6.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(def6);

                doc.Add(new Phrase(" "));

                DataTable dt1 = new DataTable();

                dt1.Columns.Add("CIF");
                dt1.Columns.Add("Nombre");
                dt1.Columns.Add("Credito");
                dt1.Columns.Add("Juicio");
                dt1.Columns.Add("Juzgado");
                dt1.Columns.Add("Factura");
                dt1.Columns.Add("Importe");

                dt1 = sn.solicitudcheque(NumCredito.Value);

                PdfPTable table = new PdfPTable(dt1.Columns.Count);
                var tbl2 = new PdfPTable(dt1.Columns.Count) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("CIF", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c2 = new PdfPCell(new Phrase("Nombre", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c3 = new PdfPCell(new Phrase("Credito", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c7 = new PdfPCell(new Phrase("Juicio", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c4 = new PdfPCell(new Phrase("Juzgado", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c5 = new PdfPCell(new Phrase("Factura", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c6 = new PdfPCell(new Phrase("Importe", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };

                table.TotalWidth = 532f;

                table.LockedWidth = true;
                float[] widths = new float[] { 24f, 24f, 24f, 24f, 24f, 24f, 24f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;

                table.AddCell(c1);
                table.AddCell(c2);
                table.AddCell(c3);
                table.AddCell(c7);
                table.AddCell(c4);
                table.AddCell(c5);
                table.AddCell(c6);

                c1.Border = 0;
                c2.Border = 0;
                c3.Border = 0;
                c7.Border = 0;
                c4.Border = 0;
                c5.Border = 0;
                c6.Border = 0;


                doc.Add(table);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["CIF"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Nombre"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Credito"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Juicio"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Juzgado"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Factura"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Importe"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    doc.Add(tbl2);
                }
          
                iTextSharp.text.Paragraph def7 = new iTextSharp.text.Paragraph("Q " + ImporteTotal.Value, new Font(basf, 11));
                def7.Alignment = Element.ALIGN_RIGHT;
                doc.Add(def7);

                var tbl3 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };
                tbl3.AddCell(new PdfPCell(new Phrase("___________________________________", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("___________________________________", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Solicitado por: Lhea Sandoval", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Vo.Bo.: Daniel Fuentes", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Jefe Jurídico", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Gerente Jurídico", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(tbl3);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                var tbl4 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };
                tbl4.AddCell(new PdfPCell(new Phrase("___________________________________", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl4.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                tbl4.AddCell(new PdfPCell(new Phrase("Autorizado por: Danilo Morales", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl4.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl4.AddCell(new PdfPCell(new Phrase("Gerente Financiero", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl4.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                doc.Add(tbl4);

                //iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("El infrascrito Perito Contador de Cooperativa Parroquial de Ahorro y Crédito Integral Guadalupana, R. L., registrado en la Superintendencia de Administración Tributaria bajo el número " + Num1.Value.ToLower() + " guion " + Num2.Value.ToLower() + " (" + NumRegistro.Value + "), hace constar que:", new Font(basf, 12));
                //def4.Alignment = Element.ALIGN_JUSTIFIED;
                //doc.Add(def4);

                //doc.Add(new Paragraph(" ", parrafo));

                //iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph("En sus Registros Contables figura el préstamo a nombre de " + NombreCliente.Value + " con un monto original de " + MontoOriginalLetras.Value + " con " + MontoDecimales.Value + "/100 ( Q " + MontoOriginalEspacios.Value + "), y un saldo capital de " + SaldoActualLetras.Value + " con " + SaldoDecimales.Value + "/100 ( Q " + SaldoEspacios.Value + "), e intereses de " + InteresesLetras.Value + " con " + InteresesDecimales.Value + "/100 ( Q " + InteresesEspacio.Value + "), los cuales hacen un total de " + TotalLetras.Value + " con " + TotalDecimales.Value + "/100 ( Q " + Total.Value + ").", new Font(basf, 12));
                //def5.Alignment = Element.ALIGN_JUSTIFIED;
                //doc.Add(def5);

                //doc.Add(new Paragraph(" ", parrafo));

                //iTextSharp.text.Paragraph def6 = new iTextSharp.text.Paragraph("Y para los usos legales que a la interesada convenga, se extiende la presente a los " + DiaLetras.Value.ToLower() + " (" + Dia.Value + ") días del mes de " + MesLetras.Value.ToLower() + " (" + Mes.Value + ") del año " + AñoLetras.Value.ToLower() + " (" + Año.Value + ").", new Font(basf, 12));
                //def6.Alignment = Element.ALIGN_JUSTIFIED;
                //doc.Add(def6);

                doc.Add(new Paragraph(" ", parrafo));
                doc.Add(new Paragraph(" ", parrafo));
                doc.Add(new Paragraph(" ", parrafo));
                doc.Add(new Paragraph(" ", parrafo));
                doc.Add(new Paragraph(" ", parrafo));
                doc.Add(new Paragraph(" ", parrafo));

                //iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph("" + nombreContador.Value + "", new Font(basf, 12));
                //def2.Alignment = Element.ALIGN_CENTER;
                //doc.Add(def2);
                //iTextSharp.text.Paragraph def3 = new iTextSharp.text.Paragraph("CONTADOR(A) GENERAL", new Font(basf, 12));
                //def3.Alignment = Element.ALIGN_CENTER;
                //doc.Add(def3);

                //doc.Add(Chunk.NEWLINE);
                //string cod = exc.obtenercrdexp(dt3.Rows[i]["Nocredito"].ToString());
                //string tipocrd = exc.obtenertiponombre(dt3.Rows[i]["codgarantia"].ToString());

                //var tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                //tbl.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                //tbl.AddCell(new PdfPCell(new Phrase("NO. Expediente: " + cod + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                //tbl.AddCell(new PdfPCell(new Phrase("Tipo de expediente: Credito " + tipocrd + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                //tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                //doc.Add(tbl);

                //doc.Add(new Phrase(" "));
                //doc.Add(new Phrase(" "));

                //tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                //tbl.AddCell(new PdfPCell(new Phrase("Datos del Expediente:", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                //tbl.AddCell(new PdfPCell(new Phrase("Nombre: " + dt3.Rows[i]["nomcom"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

                //tbl.AddCell(new PdfPCell(new Phrase("CIF: " + dt3.Rows[i]["cifgeneral"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                //tbl.AddCell(new PdfPCell(new Phrase("Monto: Q" + dt3.Rows[i]["gen_monto"].ToString() + " Fecha Desembolso: " + dt3.Rows[i]["gen_fechadesembolso"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                //doc.Add(tbl);

                ////////////////////***********************************//////////////////////

                doc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename= -certificacion" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
        }

        public void llenarinputs()
        {
            string nombre = Session["Nombre"] as string;
            NombreUsuario.Value = nombre;

            string fecha = sn.fecha();
            FechaActual.Value = fecha;

            string numcredito = Session["credito"] as string;
            string importetotal = sn.importetotal(numcredito);
            ImporteTotal.Value = importetotal;
            NumCredito.Value = numcredito;
        }

        public void datosfactura()
        {
            string numcredito = Session["credito"] as string;

            string[] factura = sn.datosfactura(numcredito);

            for (int i = 0; i < factura.Length; i++)
            {
                Session["idfactura"] = factura[0];
                NumFactura.Value = factura[3];
                Serie.Value = factura[4];
                Descripcion.Value = factura[5];
                ImporteTotal2.Value = factura[6];
                string fechaestado = factura[7];
                string[] separarfechahora = fechaestado.Split(' ');
                string[] fechaestado2 = separarfechahora[0].Split('/');

                if (fechaestado2[0].Length == 1)
                {
                    FechaEmision.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + "0" + fechaestado2[0];
                }
                else
                {
                    FechaEmision.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + fechaestado2[0];
                }
                ImporteCaso.Value = factura[8];
                MotivoPago.SelectedValue = factura[9];
                if (MotivoPago.SelectedValue == "9")
                {
                    Otro.Visible = true;
                    Otro.Value = factura[10];
                }
                else
                {
                    Otro.Visible = false;
                }
                NombreCliente.Value = factura[12];
                NombreCheque.Value = factura[13];
            }
        }

        protected void MotivoPago_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (MotivoPago.SelectedValue == "9")
            {
                Otro.Visible = true;
                Guardar.Focus();
            }
            else
            {
                Otro.Visible = false;
                Guardar.Focus();
            }
        }

        public void llenarcombomotivo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_motivopago";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    MotivoPago.DataSource = ds;
                    MotivoPago.DataTextField = "pj_nombremotivo";
                    MotivoPago.DataValueField = "idpj_motivopago";
                    MotivoPago.DataBind();
                    MotivoPago.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Motivo de pago]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (Observaciones.Value == "" || RegistroContable.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", "Debe llenar todos los campos", true);
            }
            else
            {
                string numcredito = Session["credito"] as string;

                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);

                string sig = sn.siguiente("pj_requerimientopago", "idpj_requerimientopago");
                sn.insertarrequerimientopago(sig, numcredito, idusuario, Observaciones.Value, RegistroContable.Value);

                sn.cambiarestado(numcredito, "5");

                string[] campos2 = sn.obtenertipocredito(numcredito);
                string idcredito = campos2[0];
                string fecha = "";
                string numindicende = "";
                string nombrecliente = "";

                if (idcredito == null)
                {
                    string[] campos3 = sn.obtenertipotarjeta(numcredito);
                    for (int i = 0; i < campos3.Length; i++)
                    {
                        numindicende = campos3[0];
                    }
                    fecha = sn.fechacreaciontarjeta(numcredito);
                }
                else
                {
                    for (int i = 0; i < campos2.Length; i++)
                    {
                        numindicende = campos2[0];
                    }
                    fecha = sn.fechacreacioncredito(numcredito);
                }

                string[] fechaseparada = fecha.Split(' ');
                string[] fechacreacion = fechaseparada[0].Split('/');
                string diacreacion = fechacreacion[0];
                string mescreacion = fechacreacion[1];
                string añocreacion = fechacreacion[2];

                string horacreacion = fechaseparada[1];

                string fechacreacion2 = añocreacion + '-' + mescreacion + '-' + diacreacion + ' ' + horacreacion;


                string[] fechayhora = sn.fechayhora();
                string[] fecha2 = fechayhora[0].Split(' ');
                string año = fecha2[0];
                string mes = fecha2[1];
                string dia = fecha2[2];

                string hora = fechayhora[1];
                string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig5, numindicende, numcredito, NombreCliente.Value, "Recibido", "51", "34", fechahoraactual, fechacreacion2, "Recibido");

                string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig4, numindicende, numcredito, NombreCliente.Value, "Enviado", "34", "28", fechahoraactual, fechacreacion2, "Requerimiento de Pago");

                string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig2, "6", numcredito, sn.datetime(), "Enviado", idusuario, "34", NombreCliente.Value, NumeroIncidente.Value);

                String script = "alert('Se ha guardado exitosamente'); window.location.href= 'PendienteRequerimientoPago.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            string idfactura = Session["idfactura"] as string;

            if(NumFactura.Value == "" || Serie.Value == "" || Descripcion.Value == "" || ImporteTotal2.Value == "" || FechaEmision.Value == "" || ImporteCaso.Value == "" || NombreCheque.Value == "" || MotivoPago.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe completar los campos');", true);
            }
            else
            {
                if (MotivoPago.SelectedValue != "9")
                {
                    Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                }

                sn.modificarfacturaabogado(idfactura, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal2.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NombreCheque.Value);

                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se han actualizado los datos');", true);
            }
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 21";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    PTipoDocumento.DataSource = ds;
                    PTipoDocumento.DataTextField = "pj_nombretipodoc";
                    PTipoDocumento.DataValueField = "idpj_tipodocumento";
                    PTipoDocumento.DataBind();
                    PTipoDocumento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenargridviewdocumentos2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento = 21";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDocumentos2.DataSource = dt;
                    gridViewDocumentos2.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedDocumento2(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentos2.SelectedRow.FindControl("lblid") as Label).Text);
                string documentoselec = sn.obtenerrutadocumento(id);

                string nombrearchivo = sn.nombrearchivo(id);
                string[] extension = nombrearchivo.Split('.');
                int tamaño = extension.Length;
                string tipo = extension[tamaño - 1];

                string FilePath = Server.MapPath(documentoselec);
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    if (tipo.ToLower() == "pdf")
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if (tipo.ToLower() == "tif" || tipo.ToLower() == "tiff")
                    {
                        Response.ContentType = "image/tiff";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
            }
            catch
            {

            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PTipoDocumento.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {


                    if (FileUpload1.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentos();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
                    }
                }
             
            }
            catch
            {

            }
        }

        public void mostrardatos()
        {

        }

        protected void GuardarVoucher_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string voucher = sn.tipodocumentoVoucher(numcredito);

            if(voucher == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete el documento');", true);
            }
            else
            {
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);

                sn.cambiarestado(numcredito, "7");

                string[] campos2 = sn.obtenertipocredito(numcredito);
                string idcredito = campos2[0];
                string fecha = "";
                string numindicende = "";
                string nombrecliente = "";

                if (idcredito == null)
                {
                    string[] campos3 = sn.obtenertipotarjeta(numcredito);
                    for (int i = 0; i < campos3.Length; i++)
                    {
                        numindicende = campos3[0];
                    }
                    fecha = sn.fechacreaciontarjeta(numcredito);
                }
                else
                {
                    for (int i = 0; i < campos2.Length; i++)
                    {
                        numindicende = campos2[0];
                    }
                    fecha = sn.fechacreacioncredito(numcredito);
                }

                string[] fechaseparada = fecha.Split(' ');
                string[] fechacreacion = fechaseparada[0].Split('/');
                string diacreacion = fechacreacion[0];
                string mescreacion = fechacreacion[1];
                string añocreacion = fechacreacion[2];

                string horacreacion = fechaseparada[1];

                string fechacreacion2 = añocreacion + '-' + mescreacion + '-' + diacreacion + ' ' + horacreacion;


                string[] fechayhora = sn.fechayhora();
                string[] fecha2 = fechayhora[0].Split(' ');
                string año = fecha2[0];
                string mes = fecha2[1];
                string dia = fecha2[2];

                string hora = fechayhora[1];
                string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig5, numindicende, numcredito, NombreCliente.Value, "Recibido", "28", "34", fechahoraactual, fechacreacion2, "Recibido");

                string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig4, numindicende, numcredito, NombreCliente.Value, "Enviado", "34", "51", fechahoraactual, fechacreacion2, "Requerimiento de Pago (Voucher)");

                string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig2, "8", numcredito, sn.datetime(), "Enviado", idusuario, "34", NombreCliente.Value, NumeroIncidente.Value);

                String script = "alert('Se ha guardado exitosamente'); window.location.href= 'PendienteRequerimientoPago.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        public void llenarformulario()
        {

            string numcredito = Session["credito"] as string;
            string var1 = WS.buscarcredito(numcredito);
            char delimitador = '|';
            string[] campos = var1.Split(delimitador);

            if (var1.Length == 4)
            {
                Response.Write("NO HAY DATOS QUE MOSTRARA");
            }
            else
            {

                for (int i = 0; i < campos.Length; i++)
                {
                    CreditoNumero.Value = campos[1];
                    NumCif.Value = campos[19];
                    ClienteNombre.Value = campos[20];
                }

            }

            string[] campos2 = sn.obtenertipocredito(numcredito);
            string idcredito = campos2[0];
            if (idcredito == null)
            {
                Session["TipoCredito"] = "tarjeta";

                string[] campos3 = sn.obtenertipotarjeta(numcredito);
                for (int i = 0; i < campos3.Length; i++)
                {
                    NumeroIncidente.Value = campos3[0];
                }
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumeroIncidente.Value = campos2[0];
                }
            }
        }

        //protected void Generar_Click(object sender, EventArgs e)
        //{
        //    ReportParameter[] reportParameters = new ReportParameter[1];
        //    reportParameters[0] = new ReportParameter("Numero", "NumReporte.Value", false);
        //    ReporteSolicitud.LocalReport.SetParameters(reportParameters);
        //    ReporteSolicitud.LocalReport.Refresh();
        //}


    }
}