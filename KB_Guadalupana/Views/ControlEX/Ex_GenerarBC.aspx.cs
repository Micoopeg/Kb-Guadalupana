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
            generar2();
        }

        protected void btngenerar_Click(object sender, EventArgs e)
        {




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
                    row["ID"] = "100000000000" + i.ToString();
                    dt.Rows.Add(row);
                }
                System.Drawing.Image img1 = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                        doc.NewPage();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    cb1.SetFontAndSize(bf, 35.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(195.5f, 400.500f);
                    cb1.ShowText("Expediente");
                    cb1.EndText();



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
            //    public void generar() {


            //    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            //    try
            //    {

            //        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
            //          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes.pdf", FileMode.Create));
            //        doc.Open();

            //        DataTable dt = new DataTable();
            //        dt.Columns.Add("ID");

            //        for (int i = 0; i < 29; i++)
            //        {
            //            eancode = 1000000000000 + i;//valor traido y guardado en base de datos

            //            DataRow row = dt.NewRow();
            //            row["ID"] = eancode.ToString();
            //            dt.Rows.Add(row);


            //        }
            //        System.Drawing.Image img1 = null;

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            ctrl++;
            //            int k = i * 90;
            //            int stop = dt.Rows.Count;
            //            if (i != 0  && i<8)
            //            {



            //                iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            //                iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
            //                bc.TextAlignment = Element.ALIGN_TOP;
            //                bc.Code = dt.Rows[i]["ID"].ToString();
            //                bc.StartStopText = false;
            //                bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
            //                bc.Extended = true;

            //                iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
            //                  iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

            //                cb.SetTextMatrix(50f, 600.0f);
            //                img.ScaleToFit(200, 200);
            //                img.SetAbsolutePosition(51.5f,k);
            //                cb.AddImage(img);



            //            }
            //            if ( i >=8 && ctrl < stop  )
            //            {
            //                int r = 0;
            //                for (int j = i; j < dt.Rows.Count; j++)
            //                {


            //                    r++;
            //                    int p = r * 90;
            //                    if (ctrl<16) { 
            //                    iTextSharp.text.pdf.PdfContentByte cb1 = writer.DirectContent;
            //                    iTextSharp.text.pdf.BarcodeEAN bc1 = new BarcodeEAN();
            //                    bc1.TextAlignment = Element.ALIGN_TOP;
            //                    bc1.Code = dt.Rows[j]["ID"].ToString();
            //                    bc1.StartStopText = false;
            //                    bc1.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
            //                    bc1.Extended = true;

            //                    iTextSharp.text.Image img2 = bc1.CreateImageWithBarcode(cb1,
            //                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

            //                    cb1.SetTextMatrix(50f, 600.0f);
            //                    img2.ScaleToFit(200, 200);
            //                    img2.SetAbsolutePosition(350.5f, p);
            //                    cb1.AddImage(img2);
            //                    }
            //                    ctrl++;

            //                }

            //            }
            //        }
            //        if (dt.Rows.Count > 15)
            //        {
            //            int o = 0;
            //            doc.NewPage();
            //            for (int i = 15; i < dt.Rows.Count; i++)
            //            {
            //                ctrl2++;
            //                o++;
            //                int k = o * 90;
            //                int stop = dt.Rows.Count;
            //                if (i != 0 && i < 22)
            //                {



            //                    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            //                    iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
            //                    bc.TextAlignment = Element.ALIGN_TOP;
            //                    bc.Code = dt.Rows[i]["ID"].ToString();
            //                    bc.StartStopText = false;
            //                    bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
            //                    bc.Extended = true;

            //                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
            //                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

            //                    cb.SetTextMatrix(50f, 600.0f);
            //                    img.ScaleToFit(200, 200);
            //                    img.SetAbsolutePosition(51.5f, k);
            //                    cb.AddImage(img);



            //                }
            //                if (i >= 22 && ctrl2 < stop)
            //                {
            //                    int m = 0;
            //                    for (int j = i; j < dt.Rows.Count; j++)
            //                    {


            //                        m++;
            //                        int p = m * 90;

            //                        iTextSharp.text.pdf.PdfContentByte cb1 = writer.DirectContent;
            //                        iTextSharp.text.pdf.BarcodeEAN bc1 = new BarcodeEAN();
            //                        bc1.TextAlignment = Element.ALIGN_TOP;
            //                        bc1.Code = dt.Rows[j]["ID"].ToString();
            //                        bc1.StartStopText = false;
            //                        bc1.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
            //                        bc1.Extended = true;

            //                        iTextSharp.text.Image img2 = bc1.CreateImageWithBarcode(cb1,
            //                          iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

            //                        cb1.SetTextMatrix(50f, 600.0f);
            //                        img2.ScaleToFit(200, 200);
            //                        img2.SetAbsolutePosition(350.5f, p);
            //                        cb1.AddImage(img2);
            //                        ctrl2++;

            //                    }

            //                }
            //            }

            //        }

            //        doc.Close();
            //        System.Diagnostics.Process.Start(Environment.GetFolderPath(
            //                   Environment.SpecialFolder.Desktop) + "/codes.pdf");

            //    }
            //    catch
            //    {
            //    }




            //}
        }
    }
}