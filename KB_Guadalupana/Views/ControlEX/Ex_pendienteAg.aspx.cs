using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text.RegularExpressions;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_pendienteAg : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        Conexion conexiongeneral = new Conexion();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        string cif;
        string rol;
        string area;
        string fechaactual;
        
    
        protected void Page_Load(object sender, EventArgs e)
        {


            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);
            now();
            if (usernombre != "" && coduser != "")
            { string permiso = exc.obtenerrol(usernombre);
                switch (permiso) {
                    //mensajeria
                    case "1":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                        //Mesa
                    case "2":
                        hallazgo.Visible = false;
                        btnhallazgo.Visible = false;
                        span3.Visible = false;
                        span1.Visible = false;
                        txtbarras.Visible = false;
                        txtcodigo.Visible = false;
                        txtbarras2.Visible = false;
                        span2.Visible = false;
                        alerta2.Visible = false;
                        envioajur.Visible = false;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = false;
                        asignado.Visible = false;
                        alerta.Visible = false;
                        alerta3.Visible = false;
                        span.Visible = false;
                        asignados.Visible = false;
                        paramesa.Visible = false;
                        encabasignados.Visible = false;
          
                        exphall.Visible = true;

                        llenardtgvmesaasignado();
                        break;
                       //juridico
                    case "3":
                       

                        txtbarras.Visible = false;
                        txtbarras2.Visible = false;
                        span2.Visible = false;
                        span1.Visible = false;
                        txtcodigo.Visible = false;
                        alerta2.Visible = true;
                        envioajur.Visible = false;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        asignados.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = false;
        
                        alerta.Visible = false;
                        alerta2.Visible = false;
                        alerta3.Visible = false;
              
                        span.Visible = false;
                        encabasignados.Visible = false;
                        btndiv.Attributes.Add("style","margin-left: -9px;");
                        ajuridico.Attributes.Add("style", "margin-top: 37px;");

                        llenardtgvjuridicoasig();


                        break;
                        //agencia
                    case "4":
                        llenardtgvw();
                        llenardtgvw2();
                        hallazgo.Visible = false;
                        btnhallazgo.Visible = false;
                        span3.Visible = false;
                        encabasignados.Visible = false;
                        txtbarras3.Visible = false;
                        txtbarras2.Visible = false;
                        span2.Visible = false;
                        span6.Visible = false;
                        paramesa.Visible = false;
                        alerta3.Visible = false;
                        txtcodigo.Visible = true;
                        alerta2.Visible = true;
                        txtcodigo.Visible = false;
                        btnorden.Visible = false;
             
                        alerta.Visible = false;
                        span.Visible = false;
                        asignados.Visible = false;
                        ajuridico.Visible = false;
                        txtbarras.Visible = false;
                        span1.Visible = false;
                        envioajur.Visible = false;
                        break;

                        //Negocios
                    case "5":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                        //jefe
                    case "6":
                    
                        span3.Visible = false;
                        txtbarras.Visible = false;
                        txtbarras2.Visible = false;
                        span1.Visible = false;
                        span2.Visible = false;
                        alerta.Visible = true;
                        alerta2.Visible = false;
                        alerta3.Visible = false;
                        paramesa.Visible = false;
                        span6.Visible = false;
                        txtbarras3.Visible = false;

                        encabasignados.Visible = false;
                        ajuridico.Visible = false;
                        asignados.Visible = false;
                        encabselec.Visible = false;
                        envioajur.Visible = false;
                   

                        llenardtgvw3();
                        break;

                    case "8":
                        hallazgo.Visible = false;
                        asignados.Visible=false;
                        btnhallazgo.Visible = false;
                        alerta5.Visible = false;
                        divbtnverificar.Visible = false;
                        
                        txtbarras.Visible = true;
                        txtcodigo.Visible = false;
                        txtbarras2.Visible = false;
                        span.Visible = false;
                        span1.Visible = true;
                        span2.Visible = false;
                        span3.Visible = false;
                        btnorden.Visible = true;
                        alerta.Visible = false;
                        alerta2.Visible = false;
                        btndivhall.Visible = false;
                       
                        encabenvio.Visible = false;
                        encabselec.Visible = true;
                        paramesa.Visible = false;
                        ajuridico.Visible = true;
                        envioajur.Visible = true;
                        exphall.Visible = true;
                        if (!IsPostBack) { llenarcomboasignado(); }
                        llenardtgvmesa();
                        llenardtgvmesaasignado();
                        llenarenviojuridico();
                        
                   

                        break;

                    case "9":
                        hallazgo.Visible = false;
               
                        btnhallazgo.Visible = false;
                        alerta5.Visible = false;
                        divbtnverificar.Visible = false;

                        txtbarras.Visible = false;
                        txtbarras2.Visible = true;
                        txtcodigo.Visible = false;
                        span.Visible = false;
                        span1.Visible = false;
                        span2.Visible = true;
                        btnorden.Visible = true;
                        alerta.Visible = false;
                        alerta2.Visible = false;
   
           
                        encabenvio.Visible = false;
                        encabselec.Visible = true;
                        asignados.Visible = false;
                        ajuridico.Visible = true;
                        paramesa.Visible = true;
                        envioajur.Visible = false;
                        if (!IsPostBack) { llenarcomboasignadojuridico(); }
                        llenardtgvjuridico();
                        llenardtgvjuridicoasig();
                        llenarenviojuridicomesa();
                        break;


                }



            }
            else
            {
                Response.Redirect("../Session/MenuBarra.aspx");

            }


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

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] +" "+ hora;

                    fechaactual = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
        public void GenerarPDF()
        {

            DataTable dt3 = new DataTable();
            

           
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.codigostablegerencia(a);


        


            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }

            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);
                try
                {

                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/codigos.pdf", FileMode.Create));
                    doc.Open();


                    //dt3.Columns.Add("ID");

                    //for (int i = 0; i < cont2; i++)
                    //{
                    //    DataRow row = dt3.NewRow();
                    //    row["ID"] = "040045789624" + i.ToString();
                    //    dt3.Rows.Add(row);
                    //}
                    System.Drawing.Image img1 = null;

                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (i != 0)
                      
                        doc.NewPage();
                        PdfContentByte cb1 = writer.DirectContent;
                        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        doc.AddAuthor("Micoope");
                        doc.AddTitle("Caratulas");
                        doc.Open();

                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                        logo.ScalePercent(45f);

                        BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                        iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                        BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                        iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                        BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                        iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                        BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                        iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));



                        doc.Add(Chunk.NEWLINE);
                        string cod = exc.obtenercrdexp(dt3.Rows[i]["Nocredito"].ToString());
                        string tipocrd = exc.obtenertiponombre(dt3.Rows[i]["codgarantia"].ToString());
                           
                        var tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                        tbl.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                        tbl.AddCell(new PdfPCell(new Phrase("NO. Expediente: "+cod+" ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tbl.AddCell(new PdfPCell(new Phrase("Tipo de expediente: Credito "+tipocrd+"", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tbl.AddCell(new PdfPCell(new Phrase("Fecha de emisión: "+ fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                        doc.Add(tbl);

                        doc.Add(new Phrase(" "));
                        doc.Add(new Phrase(" "));

                        tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                        tbl.AddCell(new PdfPCell(new Phrase("Datos del Expediente:", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                        tbl.AddCell(new PdfPCell(new Phrase("Nombre: " + dt3.Rows[i]["nomcom"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

                        tbl.AddCell(new PdfPCell(new Phrase("CIF: " + dt3.Rows[i]["cifgeneral"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                        tbl.AddCell(new PdfPCell(new Phrase("Monto: Q"+dt3.Rows[i]["gen_monto"].ToString() + " Fecha Desembolso: " + dt3.Rows[i]["gen_fechadesembolso"].ToString() + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                        doc.Add(tbl);

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

                    ////////////////////***********************************//////////////////////

                    doc.Close();
                    System.Diagnostics.Process.Start(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments) + "/codigos.pdf");
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
        public void GenerarPDF2()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.codigostablegerencia(a);
          
            if (dt3.Rows.Count < 1) { 
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);
            
            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0 ));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["Nocredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] {5f,90f}) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo ) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("NO. LOTE "+lote+"", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });

                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + ":", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Central Zona 14 ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });



                doc.Add(tbl);



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenvio(a);


                PdfPTable table = new PdfPTable(6);
                tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("Fecha/Hora Desembolso", negrita)) { Border = 0, BorderWidthBottom = 2f,  Padding = 4f };
                var c2 = new PdfPCell(new Phrase("CIF", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c3 = new PdfPCell(new Phrase("NO. Préstamo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c4 = new PdfPCell(new Phrase("Nombre", negrita)) { Border = 0, BorderWidthBottom = 2f,  Padding = 2f };
                var c5 = new PdfPCell(new Phrase("Monto", negrita)) { Border = 0, BorderWidthBottom = 2f,  Padding = 2f };
                var c6 = new PdfPCell(new Phrase("Tipo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };


                string cont = exc.contpdf(usernombre);
                int envios = Convert.ToInt32(cont);
                table.TotalWidth = 550f;

                table.LockedWidth = true;
                float[] widths = new float[] { 20f, 15f, 25f, 40f, 35f, 35f };
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

                try
                {

                    for (int j = 0; j < datos2.Length; j++)
                    {

                        /*c1.Phrase = new Phrase(Convert.ToString(datos2.GetValue(j)));*/


                        table.AddCell(Convert.ToString(datos2.GetValue(j)));
       
                    }

                    doc.Add(table);


                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                PdfPTable tablef = new PdfPTable(1);

                tablef.AddCell(new PdfPCell(new Phrase("Firma___________________" + nombrepersona, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] widthsf = new float[] { 30f};
                tablef.SetWidths(widthsf);
                tablef.HorizontalAlignment = 0;
               


                doc.Add(tablef);



                doc.Close();
              
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf");


            }
            

            
    }
        public void GenerarPDFMesa()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.llenarenviomesa();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) {  Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Jurídico ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            




                doc.Add(tbl);



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenviomesa();


                PdfPTable table = new PdfPTable(6);
                tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("Fecha/Hora Desembolso", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 4f };
                var c2 = new PdfPCell(new Phrase("CIF", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c3 = new PdfPCell(new Phrase("NO. Préstamo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c4 = new PdfPCell(new Phrase("Nombre", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c5 = new PdfPCell(new Phrase("Monto", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c6 = new PdfPCell(new Phrase("Tipo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };


                string cont = exc.contpdf(usernombre);
                int envios = Convert.ToInt32(cont);
                table.TotalWidth = 550f;

                table.LockedWidth = true;
                float[] widths = new float[] { 20f, 15f, 25f, 40f, 35f, 35f };
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

                try
                {

                    for (int j = 0; j < datos2.Length; j++)
                    {

                        /*c1.Phrase = new Phrase(Convert.ToString(datos2.GetValue(j)));*/


                        table.AddCell(Convert.ToString(datos2.GetValue(j)));

                    }

                    doc.Add(table);


                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                PdfPTable tablef = new PdfPTable(1);

                tablef.AddCell(new PdfPCell(new Phrase("Firma___________________" + nombrepersona, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] widthsf = new float[] { 30f };
                tablef.SetWidths(widthsf);
                tablef.HorizontalAlignment = 0;



                doc.Add(tablef);






                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf");



                estadomesa();
                Response.Redirect("Ex_pendienteAg.aspx");
            }
          


        }
        public void GenerarPDFjuridicomesa()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.llenarenviojuridicomesa();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
           
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + " ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: QA ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });



                doc.Add(tbl);



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenviojuridico();


                PdfPTable table = new PdfPTable(6);
                tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("Fecha/Hora Desembolso", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 4f };
                var c2 = new PdfPCell(new Phrase("CIF", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c3 = new PdfPCell(new Phrase("NO. Préstamo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c4 = new PdfPCell(new Phrase("Nombre", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c5 = new PdfPCell(new Phrase("Monto", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c6 = new PdfPCell(new Phrase("Tipo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };


                string cont = exc.contpdf(usernombre);
                int envios = Convert.ToInt32(cont);
                table.TotalWidth = 550f;

                table.LockedWidth = true;
                float[] widths = new float[] { 20f, 15f, 25f, 40f, 35f, 35f };
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

                try
                {

                    for (int j = 0; j < datos2.Length; j++)
                    {

                        /*c1.Phrase = new Phrase(Convert.ToString(datos2.GetValue(j)));*/


                        table.AddCell(Convert.ToString(datos2.GetValue(j)));

                    }

                    doc.Add(table);


                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }


                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                PdfPTable tablef = new PdfPTable(1);

                tablef.AddCell(new PdfPCell(new Phrase("Firma___________________" + nombrepersona, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] widthsf = new float[] { 30f };
                tablef.SetWidths(widthsf);
                tablef.HorizontalAlignment = 0;



                doc.Add(tablef);





                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvio.pdf");
                estadojuridicomesa();
                Response.Redirect("Ex_pendienteAg.aspx");

            }



        }



        public void GenerarPDF2ext()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.codigostablegerencia(a);

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvio2.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["Nocredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("NO. LOTE " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + ":", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Central Zona 14 ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });



                doc.Add(tbl);



                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvio2.pdf");


            }



        }
        public void GenerarPDFMesaext()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.llenarenviomesa();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvioe.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Jurídico ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });




                doc.Add(tbl);



                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvioe.pdf");



               
            }



        }
        public void GenerarPDFjuridicomesaext()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            dt3 = mex.llenarenviojuridicomesa();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cartaenvioa.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/pdfencab.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);


                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: QA ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });




                doc.Add(tbl);


                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.MyDocuments) + "/cartaenvioa.pdf");
           

            }



        }
        //llenados
        public void llenarcomboasignado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlingreso WHERE ex_controlarea = 43";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    asignado.DataSource = ds;
                    asignado.DataTextField = "nomcom" ;
                    asignado.DataValueField = "codexcontroling";
                    asignado.DataBind();
                    asignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Usuarios]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcomboasignadojuridico()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlingreso WHERE ex_controlarea = 34";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    asignado.DataSource = ds;
                    asignado.DataTextField = "nomcom";
                    asignado.DataValueField = "codexcontroling";
                    asignado.DataBind();
                    asignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Usuarios]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenardtgvw() {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarGridViewevento3(usernombre);
            DGRVWPEN.DataSource = dt1;
            DGRVWPEN.DataBind();

        }
        public void llenardtgvw2()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarGridViewevento2(usernombre);
            GDVTEMP.DataSource = dt1;
            GDVTEMP.DataBind();

        }
        public void llenardtgvw3()
        {
            string ar = exc.obtenerarea(usernombre);
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarenvio(ar);
            GDVTEMP.DataSource = dt1;
            GDVTEMP.DataBind();

        }


        // llenado mesa QA necesito llenar todos los que tengan estado 2 y etapa 2
        //llenado mesa
        public void llenardtgvmesa()
        {
       
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesa();
            DGVMESA.DataSource = dt1;
            DGVMESA.DataBind();

        }
        public void llenardtgvmesaasignado()
        {

            DataTable dt1 = new DataTable();
            string cod = exc.obtenercoduser(usernombre);
            dt1 = mex.llenarmesamesaasignado(cod);
            DGVMESASIG.DataSource = dt1;
            DGVMESASIG.DataBind();

        }

        public void llenarenviojuridico()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarenviomesa();
            DGVTEMP2.DataSource = dt1;
            DGVTEMP2.DataBind();

        }

        //llenado juridico
        public void llenardtgvjuridico()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarjuridico();
            DGVJURASIG.DataSource = dt1;
            DGVJURASIG.DataBind();

        }
        public void llenardtgvjuridicoasig()
        {

            DataTable dt1 = new DataTable();
            string cod = exc.obtenercoduser(usernombre);
            dt1 = mex.llenarjuridicoasignado(cod);
            DGVLEGALIZAR.DataSource = dt1;
            DGVLEGALIZAR.DataBind();

        }

        public void llenarenviojuridicomesa()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarenviojuridicomesa();
            DGVTEMP2.DataSource = dt1;
            DGVTEMP2.DataBind();

        }

        //mesa archivo

        //fin llenados
        public int calculocheck(string numero)
        {

            int check;
            string sp1, sp2;
            int const1 =1;
            int const2 =4;
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
        public static int calcularDecena(int decena)
        {
            return decena - (decena % 10) + 10;
        }


        public void actualizarenvio() {

            string sigenv = exc.siguiente("ex_envio", "codexenvio");
            string origen = exc.obtenerarea(usernombre);

            string rol = exc.obtenerrol(usernombre);
            string destino;

      


            switch (rol) {

             
                case "2":
                    destino = "43";
                    string envio2 = "UPDATE `ex_envio` SET `codexenvio`=[value-1],`codorigenarea`=[value-2],`codfestinoarea`=[value-3],`estado`=[value-4],`codexetapa`=[value-5],`usuario`=[value-6],`codareauser`=[value-7] WHERE 1";
                    exc.Insertar(envio2);
                    break;
                case "3":
                    destino = "43";
                    string envio3 = "INSERT INTO `ex_envio` (`codexenvio`, `codorigenarea`, `codfestinoarea`, `estado`, `codexetapa`, `usuario`, `codareauser`) VALUES ('" + sigenv + "', '" + origen + "', '" + destino + "', '2', '1', '" + coduser + "', '" + origen + "');   ";
                    exc.Insertar(envio3);
                    break;
                case "4":
                    destino = "45";
                    string envio4 = "INSERT INTO `ex_envio` (`codexenvio`, `codorigenarea`, `codfestinoarea`, `estado`, `codexetapa`, `usuario`, `codareauser`) VALUES ('" + sigenv + "', '" + origen + "', '" + destino + "', '2', '1', '" + coduser + "', '" + origen + "');   ";
                    exc.Insertar(envio4);
                    break;
                case "6":
                    destino = "1";
                    string envio6 = "INSERT INTO `ex_envio` (`codexenvio`, `codorigenarea`, `codfestinoarea`, `estado`, `codexetapa`, `usuario`, `codareauser`) VALUES ('"+sigenv+"', '" + origen + "', '" + destino + "', '2', '1', '"+coduser+"', '"+origen+"');   ";
                    exc.Insertar(envio6);
                    break;





            }
        
        }
        public void crearexp() {

            string origen = exc.obtenerarea(usernombre);

            string destino;

            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.codigostablegerencia(a);
            string numerolote = exc.siguiente2("ex_loteenvio", "numerolote");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string quien = exc.obtenercoduserexp(dt3.Rows[i]["Nocredito"].ToString());
                string tipo = exc.obtenertipo(dt3.Rows[i]["Nocredito"].ToString());
                string userext = exc.obtenercoduser(quien);
                string sig = exc.siguiente("ex_expediente","codexp");

                string sigenv = exc.siguiente("ex_envio", "codexenvio");
                string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                string siglote = exc.siguiente("ex_loteenvio","codlote");

                string expediente = "INSERT INTO `ex_expediente`(`codexp`, `codgencred`, `codusuario`, `codextipocred`, `ex_comentario`) VALUES ('"+sig+"', '" + dt3.Rows[i]["Nocredito"].ToString() + "', '"+userext+"', '"+tipo+"' , ' ')";
                exc.Insertar(expediente);
                destino = "1";
                string envio6 = "INSERT INTO `ex_envio` (`codexenvio`, `codorigenarea`, `codfestinoarea`, `estado`, `codexetapa`, `usuario`, `codareauser`, `Nocredito`) VALUES ('" + sigenv + "', '" + origen + "', '" + destino + "', '2', '1', '" + coduser + "', '" + origen + "', '"+ dt3.Rows[i]["Nocredito"].ToString() + "');   ";
                exc.Insertar(envio6);
                string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('"+sigbit+"', '"+sigenv+"', '"+sig+"', '"+fechaactual+"', 2, 1 );";
                exc.Insertar(bitacora);
                string lote = "INSERT INTO `ex_loteenvio`(`codlote`, `codexenvio`, `numerolote`, `estado`) VALUES ('" + siglote+"', '"+sigenv+"', '"+numerolote+"', 0)";
                exc.Insertar(lote);


            }


        }

   
        public void estadoenviado() {

            DataTable dt3 = new DataTable();
            dt3 = mex.codigostable(usernombre);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                
                string updateest = "UPDATE `ex_temporal1` SET `estado`=2 WHERE Nocredito = '" + dt3.Rows[i]["Nocredito"].ToString() + "'";
                exc.Insertar(updateest);
            }

        }
        public void estadomesa() {

            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.llenarenviomesa();
            if (dt3.Rows.Count != 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                    string codenv = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                    string codexp = exc.obtenercodexp(dt3.Rows[i]["gen_numcredito"].ToString());

                    string updateest = "UPDATE `ex_envio` SET `estado`= 2 ,`codexetapa`= 3 WHERE Nocredito =  '" + dt3.Rows[i]["gen_numcredito"].ToString() + "'";
                    exc.Insertar(updateest);
                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + codenv + "', '" + codexp + "', '" + fechaactual + "', 2, 3 );";
                    exc.Insertar(bitacora);

                }
            }
     


        }
        public void estadojuridicomesa()
        {

            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.llenarenviojuridicomesa();
            if (dt3.Rows.Count != 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                    string codenv = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                    string codexp = exc.obtenercodexp(dt3.Rows[i]["gen_numcredito"].ToString());

                    string updateest = "UPDATE `ex_envio` SET `estado`=2 ,`codexetapa`= 4 WHERE Nocredito =  '" + dt3.Rows[i]["gen_numcredito"].ToString() + "'";
                    exc.Insertar(updateest);
                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + codenv + "', '" + codexp + "', '" + fechaactual + "', 2, 4 );";
                    exc.Insertar(bitacora);

                }
            }



        }

        protected void DGRVWPEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DGRVWPEN.SelectedRow;
            string area = exc.obtenerarea(usernombre);
            DataTable dt1 = new DataTable();
            string cod = (DGRVWPEN.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string sig = exc.siguiente("ex_temporal1","codextemp");

            string insert = "INSERT INTO `ex_temporal1` (`codextemp`, `Nocredito`, `estado`,`codexarea` ) VALUES ('" + sig+"', '"+cod+"', '7', '"+area+"'); ";
            exc.Insertar(insert);

            Response.Redirect("Ex_pendienteAg.aspx");



        }

        protected void DGRVWPEN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGRVWPEN.PageIndex = e.NewPageIndex;
            llenardtgvw();



        }

  

        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void GDVTEMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GDVTEMP.SelectedRow;
            DataTable dt1 = new DataTable();
            string numcred = (GDVTEMP.SelectedRow.FindControl("lblnumcred") as Label).Text;

            string delete = "DELETE FROM `ex_temporal1` WHERE Nocredito = '"+numcred+"'";

            exc.Insertar(delete);
            Response.Redirect("Ex_pendienteAg.aspx");
        }
        protected void txtbarras3_TextChanged(object sender, EventArgs e)
        {
            //buscar segun codigo ingresado y cargar en dgv pendiente

            string rol = exc.obtenerrol(usernombre);

            switch(rol){

                case "2":
                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    divbtnverificar.Attributes.Add("style", "margin-left: -46%; position: absolute;margin-top: -24%;");
                    break;
                case "3":

                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    divbtnverificar.Attributes.Add("style", "margin-left: -46%; position: absolute;margin-top: -24%;");
                    break;
                case "8":

                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
               
                    break;
                case "9":

                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
      
                    break;



            }
    


        }
        protected void txtbarras_TextChanged(object sender, EventArgs e)
        {
            //buscar segun codigo ingresado y cargar en dgv pendiente



            string barras = txtbarras.Text;
            Regex regex = new Regex("");
            string[] s = regex.Split(barras);



            if (s.Length == 14)
            {

                string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] ;



                string obtener = mex.confirmarasog(numero);
                string coaexist = mex.expedienteexiste(numero, "2", "2");
                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);

                if (codenv != ""  && coaexist != "")
                {
                   
     
                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 3 );";
                    exc.Insertar(bitacoraa);
                 
                    txtbarras.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                }
                else {
                    String script = "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                     }

            }
     
            else if (s.Length == 15)
            {

                string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10] ;


                string obtener = mex.confirmarasog(numero);
                

                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);
                string coaexist = mex.expedienteexiste(numero,"2","2");
                if (codenv != "" && coaexist != "")
                {
   
                
                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 3 );";
                    exc.Insertar(bitacoraa);
                 
                    txtbarras.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else {
                    String script = "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
        }

        protected void DGVMESA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVMESA.PageIndex = e.NewPageIndex;
            llenardtgvmesa();
        }

        protected void DGVMESA_SelectedIndexChanged(object sender, EventArgs e)
        {
            encabasignados.Visible = true;
            asignado.Visible = true;
            alerta3.Visible = true;

            hallazgo.Visible = false;
            btndivhall.Visible = false;
            btndiv.Visible = false;
            span3.Visible = false;
           
        }

        protected void GDVTEMP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVMESA.PageIndex = e.NewPageIndex;
            llenardtgvw2();

        }

        protected void DGVLEGALIZAR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVLEGALIZAR.PageIndex = e.NewPageIndex;
            llenardtgvmesaasignado();

        }

        protected void DGVJURASIG_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVJURASIG.PageIndex = e.NewPageIndex;
           llenardtgvjuridicoasig();
        }

        protected void DGVJURASIG_SelectedIndexChanged(object sender, EventArgs e)
        {

            encabasignados.Visible = true;
            asignado.Visible = true;
            alerta3.Visible = true;
        }

        protected void txtbarras2_TextChanged(object sender, EventArgs e)
        {//buscar segun codigo ingresado y cargar en dgv pendiente



            string barras = txtbarras2.Text;
            Regex regex = new Regex("");
            string[] s = regex.Split(barras);



            if (s.Length == 14)
            {

                string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];



                string obtener = mex.confirmarasog(numero);
                string coasg = mex.expedienteexiste(numero, "2", "3");
                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);

                if (codenv != "" && coasg != "")
                {
                

                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 4  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 4 );";
                    exc.Insertar(bitacoraa);
                 
                    txtbarras2.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

            }

            else if (s.Length == 15)
            {

                string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                string obtener = mex.confirmarasog(numero);
                string coasg = mex.expedienteexiste(numero, "2", "3");

                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);

                if (codenv != ""  && coasg != "")
                {

                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 4  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 4 );";
                    exc.Insertar(bitacoraa);
                
                    txtbarras2.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
          
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void DGVMESASIG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DGVMESASIG_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVJURASIG.PageIndex = e.NewPageIndex;
            llenardtgvmesaasignado();

        }

        protected void DGVLEGALIZAR_SelectedIndexChanged(object sender, EventArgs e)
        {
                string numcred = (DGVLEGALIZAR.SelectedRow.FindControl("lblnumcred") as Label).Text;

            string codexpe = exc.obtenercodexp(numcred);

            string cargar = mex.obtenerhall(codexpe);

            if (codexpe != "")
            {

                hallazgo.Visible = true;
                btnhallazgo.Visible = true;
                span3.Visible = true;

        
                if (cargar == "NULL")
                {
                    num.InnerText = numcred;
                    hallazgo.Value = "";
                }
                else {
                    num.InnerText = numcred;
                    hallazgo.Value = cargar;

                }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Expediente Inválido')", true); }




        }

        protected void btnhallazgo_Click(object sender, EventArgs e)
        {
            if (hallazgo.Value != "") {

            
                string envioev = exc.obtenercodenv(num.InnerText);
                string sighall = exc.siguiente("ex_hallazgos","codexhall");
                string exped = exc.obtenercodexp(num.InnerText);
                string insertarhall = "INSERT INTO `ex_hallazgos`(`codexhall`, `codexp`, `hallazgo`, `estadohall`) VALUES ('"+sighall+"','"+exped+"', '"+hallazgo.Value+"',1 ) ;";
                exc.Insertar(insertarhall);

                //string updateretenido = "UPDATE `ex_envio` SET  `estado`= 3 WHERE codexenvio = '"+envioev+"'";
                //exc.Insertar(updateretenido);
                String script = "alert('Hallazgo Enviado '); window.location.href= 'Ex_pendienteAg.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ingrese los hallazgos o Recargue la página')", true); }
        }

        protected void DGVMESASIG_SelectedIndexChanged1(object sender, EventArgs e)
        {

            string numcred = (DGVMESASIG.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string rol = exc.obtenerrol(usernombre);
            switch (rol) {

                case "2":
                    btnhallazgo.Visible = true;
                    btndiv.Visible = true;
                    btndivhall.Visible = true;
                    hallazgo.Visible = true;
                    alerta5.Visible = true;
                    span3.Visible = true;
                    num.InnerText = numcred;
                    btndivhall.Attributes.Add("style", "margin-left: -284%; position: absolute; margin-top: 30%; ");
                    btndiv.Attributes.Add("style", "margin-left: -184%; position: absolute; margin-top: 30%; ");
                    break;
                case "8":
                    btnhallazgo.Visible = true;
                    btndiv.Visible = true;
                    btndivhall.Visible = true;
                    hallazgo.Visible = true;
                    alerta5.Visible = true;

                    span3.Visible = true;
                    alerta3.Visible = false;
                    divuserbtn.Visible = false;
                    encabasignados.Visible = false;
                    asignado.Visible = false;
                    num.InnerText = numcred;
                    break;
          
        }

    }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (num.InnerText != "")
            {
                string noexp = exc.obtenercodexp(num.InnerText);

                Session["exp"] = noexp;
                Session["nocredit"] = num.InnerText;
                Response.Redirect("Ex_verhallazgos.aspx");
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' No hay un expediente seleccionado')", true);


            }
        }

        protected void btnasignaruser_Click(object sender, EventArgs e)
        {
            string quien = asignado.SelectedValue;
            int invl = asignado.SelectedIndex;

            string rol = exc.obtenerrol(usernombre);

            switch (rol) {

                case "8":
                    GridViewRow row = DGVMESA.SelectedRow;
                    DataTable dt1 = new DataTable();
                    string numcred = (DGVMESA.SelectedRow.FindControl("lblnumcred") as Label).Text;
                    string codexp = exc.obtenercodexp(numcred);
                    string sigas = exc.siguiente("ex_asignado", "codasig");
                    if (quien != "" && invl != 0)
                    {

                        string asignar = "INSERT INTO `ex_asignado`(`codasig`, `codexp`, `codasignado`, `proceso`) VALUES ('" + sigas + "', '" + codexp + "', '" + asignado.SelectedValue + "' , 3)";
                        exc.Insertar(asignar);

                        Response.Redirect("Ex_pendienteAg.aspx");
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione a quién desea asignarle los expedientes.')", true); }

                    break;
                case "9":

                    GridViewRow row1 = DGVJURASIG.SelectedRow;
                    DataTable dt11 = new DataTable();
                    string numcred1 = (DGVJURASIG.SelectedRow.FindControl("lblnumcred") as Label).Text;
                    string codexp1 = exc.obtenercodexp(numcred1);
                    string sigas1 = exc.siguiente("ex_asignado", "codasig");
                    if (quien != "" && invl != 0)
                    {

                        string asignar = "INSERT INTO `ex_asignado`(`codasig`, `codexp`, `codasignado`, `proceso`) VALUES ('" + sigas1 + "', '" + codexp1 + "', '" + asignado.SelectedValue + "' , 4)";
                        exc.Insertar(asignar);

                        Response.Redirect("Ex_pendienteAg.aspx");
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione a quién desea asignarle los expedientes.')", true); }

                    break;


          
        }
        }

        protected void asignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            divuserbtn.Visible = true;

        }

        protected void no_Click(object sender, EventArgs e)
        {
            String script = "alert('Orden cancelada '); window.location.href= 'Ex_pendienteAg.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

        }

        protected void si_Click(object sender, EventArgs e)
        {
            string[] datos2 = mex.datosempleado(txtcodigo.Value);
            string permiso = exc.obtenerrol(usernombre);
            try
            {
                for (int i = 0; i < datos2.Length; i++)
                {
                    cif = Convert.ToString(datos2.GetValue(0));
                    area = Convert.ToString(datos2.GetValue(1));
                    rol = Convert.ToString(datos2.GetValue(2));


                }
                switch (permiso)
                {
                    //agencia jefe
                    case "6":
                        if (txtcodigo.Value != "")
                        {
                            string[] datos = mex.datosempleado(txtcodigo.Value);

                            try
                            {
                                for (int i = 0; i < datos.Length; i++)
                                {
                                    cif = Convert.ToString(datos.GetValue(0));
                                    area = Convert.ToString(datos.GetValue(1));
                                    rol = Convert.ToString(datos.GetValue(2));


                                }

                                if (rol == "1" && area == "45" && cif == txtcodigo.Value)
                                {
                                    crearexp();
                                    GenerarPDF();
                                    GenerarPDF2ext();
                                    GenerarPDF2();

                                    estadoenviado();
                                    Response.Redirect("Ex_pendienteAg.aspx");

                                }
                                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Codigo Invalido')", true); }



                            }
                            catch (Exception err)
                            {
                                Console.WriteLine(err.Message);

                            }





                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ingrese el codigo del mensajero ')", true); }

                        break;
                    //mesa encargado 8
                    case "8":
                        GenerarPDFMesaext();

                        GenerarPDFMesa();
                        break;
                    //juridico encargado
                    case "9":
                        GenerarPDFjuridicomesaext();
                        GenerarPDFjuridicomesa();


                        break;

                        //archivo



                }




            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_pendienteAg.aspx");
        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {

        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {

            string rolu = exc.obtenerrol(usernombre);

            switch (rolu) {

                case "2":
                    string barras = txtbarras3.Text;
                    Regex regex = new Regex("");
                    string[] s = regex.Split(barras);



                    if (s.Length == 14)
                    {

                        string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];

                        string tipo = mex.obtenertipocrd2(numero);

                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string etapa = mex.expedienteexiste(numero,"1","3");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);

                        if (codenv != "" && obtener != "" && coasg != "")
                        {

                            if (tipo == "3")
                            {
                                string updateres2 = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres2);
                                string sigientebt2 = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa2 = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt2 + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa2);

                                txtbarras.Text = "";
                                String script2 = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
                            }
                            else
                            {

                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 3 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }

                    else if (s.Length == 15)
                    {

                        string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                        string obtener = mex.confirmarasog(numero);

                        string tipo = mex.obtenertipocrd2(numero);
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "3");
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                        {

                            if (tipo == "3")
                            {
                                string updateres2 = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres2);
                                string sigientebt2 = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa2 = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt2 + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa2);

                                txtbarras.Text = "";
                                String script2 = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
                            }
                            else
                            {

                                string updateenv = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 3,`usuario`= '" + coduser + "' , `codareauser`= '" + a + "' WHERE Nocredito = '" + numero + "'";
                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 3 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
                case "8":
                    string barras8 = txtbarras3.Text;
                    Regex regex8 = new Regex("");
                    string[] s8 = regex8.Split(barras8);



                    if (s8.Length == 14)
                    {

                        string numero = "0" + s8[1] + s8[2] + s8[3] + s8[4] + s8[5] + s8[6] + s8[7] + s8[8] + s8[9];


                        string tipo = mex.obtenertipocrd2(numero);
                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "3");

                        if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                        {

                            if (tipo == "3")
                            {
                                string updateres2 = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres2);
                                string sigientebt2 = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa2 = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt2 + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa2);

                                txtbarras.Text = "";
                                String script2 = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
                            }
                            else
                            {

                                string updateenv = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 3,`usuario`= '" + coduser + "' , `codareauser`= '" + a + "' WHERE Nocredito = '" + numero + "'";
                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 3 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }

                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }

                    else if (s8.Length == 15)
                    {

                        string numero = s8[1] + s8[2] + s8[3] + s8[4] + s8[5] + s8[6] + s8[7] + s8[8] + s8[9] + s8[10];


                        string obtener = mex.confirmarasog(numero);
                        string tipo = mex.obtenertipocrd2(numero);

                        string a = exc.obtenerarea(usernombre);
                        string etapa = mex.expedienteexiste(numero, "1", "3");
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        if (codenv != "" && obtener != "" && coasg != "" && etapa !="")
                        {

                            if (tipo == "3")
                            {
                                string updateres2 = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres2);
                                string sigientebt2 = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa2 = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt2 + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa2);

                                txtbarras.Text = "";
                                String script2 = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
                            }
                            else
                            {
                                string updateenv = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 3,`usuario`= '" + coduser + "' , `codareauser`= '" + a + "' WHERE Nocredito = '" + numero + "'";
                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 3  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 3 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
                case "3":
                    string barras3 = txtbarras3.Text;
                    Regex regex3 = new Regex("");
                    string[] s3 = regex3.Split(barras3);



                    if (s3.Length == 14)
                    {

                        string numero = "0" + s3[1] + s3[2] + s3[3] + s3[4] + s3[5] + s3[6] + s3[7] + s3[8] + s3[9];



                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "4");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);

                        if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                        {


                            string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 4  WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 4 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }

                    else if (s3.Length == 15)
                    {

                        string numero = s3[1] + s3[2] + s3[3] + s3[4] + s3[5] + s3[6] + s3[7] + s3[8] + s3[9] + s3[10];


                        string obtener = mex.confirmarasog(numero);


                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "4");
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        if (codenv != "" && obtener != "" && coasg != "" && etapa!="")
                        {

                            
                            string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 4  WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 4 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
                case "9":

                    string barras9 = txtbarras3.Text;
                    Regex regex9 = new Regex("");
                    string[] s9 = regex9.Split(barras9);



                    if (s9.Length == 14)
                    {

                        string numero = "0" + s9[1] + s9[2] + s9[3] + s9[4] + s9[5] + s9[6] + s9[7] + s9[8] + s9[9];



                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "4");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);

                        if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                        {


                            string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 4 WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 4 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }

                    else if (s9.Length == 15)
                    {

                        string numero = s9[1] + s9[2] + s9[3] + s9[4] + s9[5] + s9[6] + s9[7] + s9[8] + s9[9] + s9[10];


                        string obtener = mex.confirmarasog(numero);

                        string etapa = mex.expedienteexiste(numero, "1", "4");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                        {

                           
                            string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 4  WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 4 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_pendienteAg.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
            
            
            }
            
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_VistaMesaQA.aspx");
        }

        protected void btnorden_Click(object sender, EventArgs e)
        {
            alerta7.Visible = true;
            divsi.Visible = true;
            divno.Visible = true;

         

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
   

      





        public string fechabitacora()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + horamin;



                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }
            return fechahora;

        }













    }
}