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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewdocumentos();
                llenarinputs();
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento = 18";
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
            GenerarPDF();
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
                tbl1.AddCell(new PdfPCell(new Phrase(ImporteTotal.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_LEFT });
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
                dt1.Columns.Add("Juzgado");
                dt1.Columns.Add("Factura");
                dt1.Columns.Add("Importe");

                dt1 = sn.solicitudcheque(NumCredito.Value);

                PdfPTable table = new PdfPTable(dt1.Columns.Count);
                var tbl2 = new PdfPTable(dt1.Columns.Count) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("CIF", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c2 = new PdfPCell(new Phrase("Nombre", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c3 = new PdfPCell(new Phrase("Credito", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c4 = new PdfPCell(new Phrase("Juzgado", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c5 = new PdfPCell(new Phrase("Factura", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };
                var c6 = new PdfPCell(new Phrase("Importe", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 2f, HorizontalAlignment = Element.ALIGN_CENTER };

                table.TotalWidth = 532f;

                table.LockedWidth = true;
                float[] widths = new float[] { 30f, 30f, 30f, 30f, 30f, 30f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;

                table.AddCell(c1);
                table.AddCell(c2);
                table.AddCell(c3);
                table.AddCell(c4);
                table.AddCell(c5);
                table.AddCell(c6);

                c1.Border = 0;
                c2.Border = 0;
                c3.Border = 0;
                c4.Border = 0;
                c5.Border = 0;
                c6.Border = 0;


                doc.Add(table);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["CIF"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Nombre"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Credito"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Juzgado"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Factura"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl2.AddCell(new PdfPCell(new Phrase(dt1.Rows[i]["Importe"].ToString(), new Font(basf, 11))) { Border = 0, BorderColorLeft = BaseColor.BLACK, BorderWidthLeft = .5f, BorderColorRight = BaseColor.BLACK, BorderWidthRight = .5f, BorderColorTop = BaseColor.BLACK, BorderWidthTop = .5f, BorderColorBottom = BaseColor.BLACK, BorderWidthBottom = .5f, HorizontalAlignment = Element.ALIGN_CENTER });
                    doc.Add(tbl2);
                }
          
                iTextSharp.text.Paragraph def7 = new iTextSharp.text.Paragraph(ImporteTotal.Value, new Font(basf, 11));
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
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("___________________________________", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Autorizado por: Danilo Morales", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Gerente Financiero", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));

                doc.Add(tbl3);
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
        //protected void Generar_Click(object sender, EventArgs e)
        //{
        //    ReportParameter[] reportParameters = new ReportParameter[1];
        //    reportParameters[0] = new ReportParameter("Numero", "NumReporte.Value", false);
        //    ReporteSolicitud.LocalReport.SetParameters(reportParameters);
        //    ReporteSolicitud.LocalReport.Refresh();
        //}


    }
}