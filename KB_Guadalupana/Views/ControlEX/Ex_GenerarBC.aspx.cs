using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Mvc;
using Image = iTextSharp.text.Image;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_GenerarBC1 : System.Web.UI.Page
    {
        long eancode;
        int ctrl = 0;
        int ctrl2 = 15;
        protected void Page_Load(object sender, EventArgs e)
        {
   
            GenerarPDF();
        }

        protected void btngenerar_Click(object sender, EventArgs e)
        {




        }

        public void GenerarPDF()
        {

            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);
             try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));
                doc.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");

                for (int i = 0; i < 10; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = "4070071967072";
                    dt.Rows.Add(row);
                }
                System.Drawing.Image img1 = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                        doc.NewPage();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    doc.AddAuthor("Micoope");
                    doc.AddTitle("Expedientes");
                    doc.Open();

                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/F1.png"));
                    logo.ScalePercent(45f);

                    BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                    iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                    BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                    iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                    BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                    iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                    BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                    iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255));



                    doc.Add(Chunk.NEWLINE);

                    var tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                    tbl.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                    tbl.AddCell(new PdfPCell(new Phrase("NO. Expediente: 04 ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase("Tipo de expediente: Credito Fiduciario", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                    doc.Add(tbl);

                    doc.Add(new Phrase(" "));
                    doc.Add(new Phrase(" "));

                    tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                    tbl.AddCell(new PdfPCell(new Phrase("Datos del Expediente:", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                    tbl.AddCell(new PdfPCell(new Phrase("Nombre: Edgar Ruben Casasola Bachez", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                  
                    tbl.AddCell(new PdfPCell(new Phrase("CIF: 458789", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl.AddCell(new PdfPCell(new Phrase("Monto: 45000, Fecha desembolso: 14/04/2021", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_CENTER });


                    doc.Add(tbl);


                    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                    iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
                    bc.TextAlignment = Element.ALIGN_LEFT;
                    bc.Code = dt.Rows[i]["ID"].ToString();
                    bc.StartStopText = false;
                    bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
                    bc.Extended = true;

                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                  
                                 cb.SetTextMatrix(70f, 600.0f);
                                 img.ScaleToFit(80, 80);
                                  img.SetAbsolutePosition(190.5f,400);
                                  cb.AddImage(img);
                }

                ////////////////////***********************************//////////////////////

                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/codes.pdf");

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=foo.pdf");
                Response.TransmitFile("~/Desktop/codigos.pdf");
                Response.End();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=codigos" + ".pdf");
                //Response.TransmitFile(Server.MapPath("~/Desktop/codigos.pdf"));
                //Response.Write(doc);
                //Response.Flush();
                //Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
            finally
            {
                doc.Close();
            }



      

         

          




        }
        public void generar2()
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));
                doc.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");

                for (int i = 0; i < 10; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = "040045789624" + i.ToString();
                    dt.Rows.Add(row);
                }
                System.Drawing.Image img1 = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                        doc.NewPage();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    //numero de expediente
                    cb1.SetFontAndSize(bf, 35.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 500.500f);
                    cb1.ShowText("Expediente NO. 4 ");
                    cb1.EndText();
                    //nombre del asociado
                    cb1.SetFontAndSize(bf, 25.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 400.500f);
                    cb1.ShowText("Edgar Ruben Casasola Bachez");
                    cb1.EndText();
                    //cif
                    cb1.SetFontAndSize(bf, 25.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 250.500f);
                    cb1.ShowText("CIF: 254875");
                    cb1.EndText();
                    //monto desembolsado y fecha
                    cb1.SetFontAndSize(bf, 25.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 200.500f);
                    cb1.ShowText("Q 45,000 14/04/2021 15:25:30");
                    cb1.EndText();
                    //tipo de credito
                    cb1.SetFontAndSize(bf, 25.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 100.500f);
                    cb1.ShowText("Fiduciario");
                    cb1.EndText();
                    //


                    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                    iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
                    bc.TextAlignment = Element.ALIGN_LEFT;
                    bc.Code = dt.Rows[i]["ID"].ToString();
                    bc.StartStopText = false;
                    bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
                    bc.Extended = true;

                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                  
                                 cb.SetTextMatrix(50f, 600.0f);
                                 img.ScaleToFit(200, 200);
                                  img.SetAbsolutePosition(190.5f,300);
                                  cb.AddImage(img);
                }

                ////////////////////***********************************//////////////////////

                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/codes.pdf");
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
            finally
            {
                doc.Close();
            }
         
        }
    }
}