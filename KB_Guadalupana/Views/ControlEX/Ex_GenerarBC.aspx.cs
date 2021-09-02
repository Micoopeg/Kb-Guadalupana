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
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Image = iTextSharp.text.Image;
using System.Text.RegularExpressions;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_GenerarBC1 : System.Web.UI.Page
    {
        long eancode;
        int ctrl = 0;
        int ctrl2 = 15;
        string fechaactual;
        char delimitador2 = ' ';
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        Conexion conexiongeneral = new Conexion();
        KB_Rutas ruta = new KB_Rutas();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            string rol = mex.obtenerrol(usernombre);
            if (!IsPostBack) { 
            llenarestadi();
            llenaretapa();

            }


            if (rol != "8")
            {


                Response.Redirect("../../Index.aspx");
            }
        }

        protected void btngenerar_Click(object sender, EventArgs e)
        {


            //string estado = WS.buscarcreditoexpedientes(TextBox1.Text);

            //Label1.Text = estado;

        }
        public void now()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    string hora = Convert.ToString(fecha.GetValue(1));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + hora;

                    fechaactual = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }

        protected void generarcaratula_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }


        public void llenarestadi()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `ex_tipoevento` WHERE codexevento =1 OR codexevento=2 OR codexevento=8";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    estatus.DataSource = ds;
                    estatus.DataTextField = "ex_evento";
                    estatus.DataValueField = "codexevento";
                    estatus.DataBind();
                    estatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[ESTADO]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenaretapa()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `ex_etapa` WHERE codexetapa = 3 OR codexetapa = 5 ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    etapa.DataSource = ds;
                    etapa.DataTextField = "etapa_actual";
                    etapa.DataValueField = "codexetapa";
                    etapa.DataBind();
                    etapa.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[ETAPA]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void btncambio_Click(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            dt3 = mex.codigosunidades(TextBox1.Text);
            if (dt3.Rows.Count != 0)
            {
                string updateest = "UPDATE `ex_envio` SET `estado`='" + estatus.SelectedValue + "', codexetapa='" + etapa.SelectedValue + "'  WHERE Nocredito = '" + TextBox1.Text + "'";
                exc.Insertar(updateest);
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El numero de crédito es inválido')", true);
            }

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
                dt.Columns.Add("fecha_desembolso");
                dt.Columns.Add("CIF");
                dt.Columns.Add("");
                dt.Columns.Add("CIF");
                dt.Columns.Add("CIF");
                dt.Columns.Add("CIF");


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
        public static int calcularDecena(int decena)
        {
            return decena - (decena % 10) + 10;
        }
        public int calculocheck(string numero)
        {

            int check;
            string sp1, sp2;
            int const1 = 1;
            int const2 = 4;
            int n0, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11;

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
            n10 = const1;
            n11 = const2;

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


        public void GenerarPDF2()
        {

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("Nocredito");
            dt3.Columns.Add("nomcom");
            dt3.Columns.Add("cifgeneral");
            dt3.Columns.Add("gen_monto");
            dt3.Columns.Add("gen_fechadesembolso");
            dt3.Columns.Add("ex_nomtipo");


            string a = TextBox2.Text.Trim();
            dt4 = mex.codigosunidades(a);
            if (dt4.Rows.Count != 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                    char delimitador = '|';
                    string[] valoresprocesados = estado.Split(delimitador);

                    if (estado.Length != 4)
                    {

                     

                            if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                            {

                                DataRow row = dt3.NewRow();

                                row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                                row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                                row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                                row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                                row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                                row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();




                                dt3.Rows.Add(row);
                            }






                        





                    }


                }
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El numero de crédito es inválido')", true);
            }





            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El numero de crédito es inválido')", true);

            }

            else
            {



                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.SetMargins(40f, 40f, 40f, 40f);



                doc.AddAuthor("Micoope");
                doc.AddTitle("Caratulas");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine(ruta.rutaexpedientes()));

                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));
                BaseFont _detalletbl = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalletbl = new iTextSharp.text.Font(_detalletbl, 8f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));

                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));
                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                try
                {


                    doc.Open();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    System.Drawing.Image img1 = null;

                    for (int i = 0; i < 1; i++)
                    {
                        if (i != 0)

                            doc.NewPage();


                        doc.Add(Chunk.NEWLINE);
                        string cod = exc.obtenercrdexp(dt3.Rows[i]["Nocredito"].ToString());


                        var tbl1 = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                        tbl1.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                        tbl1.AddCell(new PdfPCell(new Phrase("NO. Expediente: " + cod + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tbl1.AddCell(new PdfPCell(new Phrase("Tipo de expediente: Credito " + dt3.Rows[i]["ex_nomtipo"].ToString() + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tbl1.AddCell(new PdfPCell(new Phrase("Fecha de emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                        doc.Add(tbl1);

                        doc.Add(new Phrase(" "));
                        doc.Add(new Phrase(" "));

                        tbl1 = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                        tbl1.AddCell(new PdfPCell(new Phrase("Datos del Expediente:", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                        tbl1.AddCell(new PdfPCell(new Phrase("Nombre: " + dt3.Rows[i]["nomcom"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

                        tbl1.AddCell(new PdfPCell(new Phrase("CIF: " + dt3.Rows[i]["cifgeneral"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                        tbl1.AddCell(new PdfPCell(new Phrase("Monto: " + dt3.Rows[i]["gen_monto"].ToString() + " Fecha Desembolso: " + dt3.Rows[i]["gen_fechadesembolso"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                        doc.Add(tbl1);

                        int checksum = calculocheck(dt3.Rows[i]["Nocredito"].ToString());


                        string datoheck = Convert.ToString(checksum);
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                        iTextSharp.text.pdf.BarcodeEAN bc = new BarcodeEAN();
                        bc.TextAlignment = Element.ALIGN_LEFT;
                        bc.Code = dt3.Rows[i]["Nocredito"].ToString() + "14" + datoheck;
                        bc.StartStopText = false;
                        bc.CodeType = iTextSharp.text.pdf.BarcodeEAN.EAN13;
                        bc.Extended = true;

                        iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                          iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);



                        cb.SetTextMatrix(70f, 600.0f);
                        img.ScaleToFit(200, 200);
                        img.SetAbsolutePosition(190.5f, 400);
                        cb.AddImage(img);


                    }









                    doc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=AgenciaEnvio" + ".pdf");
                    HttpContext.Current.Response.Write(doc);

                    Response.Flush();
                    Response.End();
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
}