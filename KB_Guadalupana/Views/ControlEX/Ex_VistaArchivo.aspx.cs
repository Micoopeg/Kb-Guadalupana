using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.Hosting;
using System.Text.RegularExpressions;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_VistaArchivo : System.Web.UI.Page
    {
        private readonly HostingEnvironment env;
        ModeloEX mex = new ModeloEX();
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarPDF2();
        }
        public void separar()
        {
            string input = "841258451254";


        }
        public int calculocheck(string numero)
        {

            int check;
            string sp1, sp2;
            string[] resultado1;
            int n0, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11;
            char[] delimitadorn = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            //

            Regex regex = new Regex("");
            string[] substrings = regex.Split(numero);

            sp1 = substrings[0];
            n0 = Convert.ToInt32(substrings[1]);
            n1 = Convert.ToInt32(substrings[2]);
            n2 = Convert.ToInt32(substrings[3]);
            n3 = Convert.ToInt32(substrings[4]);
            n4 = Convert.ToInt32(substrings[5]);
            n5 = Convert.ToInt32(substrings[6]);
            n6 = Convert.ToInt32(substrings[7]);
            n7 = Convert.ToInt32(substrings[8]);
            n8 = Convert.ToInt32(substrings[9]);
            n9 = Convert.ToInt32(substrings[10]);
            n10 = Convert.ToInt32(substrings[11]);
            n11 = Convert.ToInt32(substrings[12]);
            sp2 = substrings[13];
            //suma de pares
            int respar = n0 + n2 + n4 + n6 + n8 + n10;

            //suma de impares
            int resimp = n1 + n3 + n5 + n7 + n9 + n11;
            //*3 resultado de impares
            int resimp2 = resimp * 3;
            //sumar pares al resultado anterior
            int respar2 = respar + resimp2;
            //redondeo de valor a decena superior

            int redondeo = calcularDecena(respar2);
            //restar redondeo menos punto 4

            check = redondeo - respar2;
            return check;


        }
        public static int calcularDecena(int decena)
        {
            return decena - (decena % 10) + 10;
        }
        //public void generar2()
        //{

        //    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);

        //    try
        //    {

        //        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
        //          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));
        //        doc.Open();




        //                doc.NewPage();
        //            PdfContentByte cb1 = writer.DirectContent;
        //            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        //            cb1.SetFontAndSize(bf, 35.0f);
        //            cb1.BeginText();
        //            cb1.SetTextMatrix(195.5f, 400.500f);
        //            cb1.ShowText("Expediente");
        //            cb1.EndText();



        //            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
        //            iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
        //            bc.TextAlignment = Element.ALIGN_LEFT;
        //            bc.Code = dt.Rows[i]["ID"].ToString();
        //            bc.StartStopText = false;
        //            bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
        //            bc.Extended = true;

        //            iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
        //              iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);


        //            cb.SetTextMatrix(50f, 600.0f);
        //            img.ScaleToFit(200, 200);
        //            img.SetAbsolutePosition(190.5f, 300);
        //            cb.AddImage(img);

        //        doc.Close();
        //        System.Diagnostics.Process.Start(Environment.GetFolderPath(
        //                   Environment.SpecialFolder.Desktop) + "/codes.pdf");
        //        //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        doc.Close();
        //    }

        //}
        public void GenerarPDF()
        {

            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                 Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));

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
            tbl.AddCell(new PdfPCell(new Phrase("NO. 0002458", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

            doc.Add(tbl);

            doc.Add(new Phrase(" "));
            doc.Add(new Phrase(" "));

            tbl = new PdfPTable(new float[] { 30f, 40f, 30f }) { WidthPercentage = 100 };
            tbl.AddCell(new PdfPCell(new Phrase("MINI AG C.C PRADERA:", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            tbl.AddCell(new PdfPCell(new Phrase("OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase("CENTRAL ZONA 14", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            tbl.AddCell(new PdfPCell(new Phrase("Ciudad de Guatemala, GT 01014:", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_RIGHT });


            doc.Add(tbl);
        }

        public void GenerarPDF2()
        {

            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                 Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));

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
            tbl.AddCell(new PdfPCell(new Phrase("NO. 0002458", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

            doc.Add(tbl);

            doc.Add(new Phrase(" "));
            doc.Add(new Phrase(" "));

            tbl = new PdfPTable(new float[] { 30f, 40f, 30f }) { WidthPercentage = 100 };
            tbl.AddCell(new PdfPCell(new Phrase("MINI AG C.C PRADERA:", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            tbl.AddCell(new PdfPCell(new Phrase("OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            tbl.AddCell(new PdfPCell(new Phrase("CENTRAL ZONA 14", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            tbl.AddCell(new PdfPCell(new Phrase("Ciudad de Guatemala, GT 01014:", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_RIGHT });


            doc.Add(tbl);


            PdfPTable table = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            table.AddCell(cell);

            table.AddCell("Col 1 Row 1");

            table.AddCell("Col 2 Row 1");

            table.AddCell("Col 3 Row 1");

            table.AddCell("Col 1 Row 2");

            table.AddCell("Col 2 Row 2");

            table.AddCell("Col 3 Row 2");

            doc.Add(table);
            //string[] datos2 = mex.cartaenvio(usernombre);

            //try
            //{
            //    for (int i = 0; i < datos2.Length; i++)
            //    {
            //        PdfPTable table = new PdfPTable(6);

            //        table.AddCell(Convert.ToString(datos2.GetValue(0)));
            //        table.AddCell(Convert.ToString(datos2.GetValue(1)));
            //        table.AddCell(Convert.ToString(datos2.GetValue(2)));
            //        table.AddCell(Convert.ToString(datos2.GetValue(3)));
            //        table.AddCell(Convert.ToString(datos2.GetValue(4)));
            //        table.AddCell(Convert.ToString(datos2.GetValue(5)));


            //        // Esta es la primera fila

            //        doc.Add(table);
            //    }





            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine(err.Message);

            //}



            //tbl2.WriteSelectedRows(0, 50, doc.Left + 30, doc.Top - 10, writer.DirectContent);
            ////tbl.AddCell(new PdfPCell(new Phrase("MINI AG C.C PRADERA:", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            ////tbl.AddCell(new PdfPCell(new Phrase("OFICINAS CENTRALES · 14 Avenida 1-65 Zona 14, ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            ////tbl.AddCell(new PdfPCell(new Phrase("CENTRAL ZONA 14", detalle)) { Border = 0, BackgroundColor = new BaseColor(0, 69, 161), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

            //tbl2.AddCell(new PdfPCell(new Phrase("Firma: ____________________", parrafo)) { Border= 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_BOTTOM });


            //doc.Add(tbl2);





            doc.Close();
            System.Diagnostics.Process.Start(Environment.GetFolderPath(
                       Environment.SpecialFolder.Desktop) + "/codes.pdf");






        }
    }
}