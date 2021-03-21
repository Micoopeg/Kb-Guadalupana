
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngenerar_Click(object sender, EventArgs e) {

            generar();
        
        
        }
       
        public void generar() {

            Document doc = new Document(new iTextSharp.text.Rectangle(24, 12), 5, 5, 1, 1);

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
                    row["ID"] = "1212454878541" + i.ToString();
                    dt.Rows.Add(row);
                }
                System.Drawing.Image img1 = null;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                        doc.NewPage();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    cb1.SetFontAndSize(bf, 2.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(1.2f, 9.5f);
                    cb1.ShowText("Expedientes");
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

                    cb.SetTextMatrix(1.5f, 3.0f);
                    img.ScaleToFit(60, 5);
                    img.SetAbsolutePosition(1.5f, 1);
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



            // Document doc = new Document(PageSize.LETTER);
            //PdfWriter pw =  PdfWriter.GetInstance(doc, new FileStream("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/codigos.pdf", FileMode.Create));

            // doc.Open();


            //BarcodeQRCode barq = new BarcodeQRCode("google.com", 1000,1000,null);

            //Image codeqrimage = barq.GetImage();
            //codeqrimage.ScaleAbsolute(200,200);
            //doc.Add(codeqrimage);
            //doc.Close();

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=codigos" + ".pdf");
            //Response.Write(doc);
            //Response.Flush();
            //Response.End();



        }
    }
}