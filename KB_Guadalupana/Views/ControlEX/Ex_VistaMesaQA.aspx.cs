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
    public partial class Ex_VistaMesaQA : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        KB_Rutas ruta = new KB_Rutas();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        string cif;
        string rol;
        string area;
        string fechaactual;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {

            now();
            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);
            if (usernombre != "" && coduser != "")
            {
                string permiso = exc.obtenerrol(usernombre);
                switch (permiso)
                {
                    //mensajeria
                    case "1":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                    //Mesa
                    
                    //juridico
                    case "2":


                        txtbarras.Visible = false;

                        txtbarras2.Visible = true;
                        span1.Visible = false;
                        span3.Visible = false;
                        alerta2.Visible = false;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = false;
                        
                        alerta.Visible = false;
                        span.Visible = false;
                        span4.Visible = false;
                        txtlotes.Visible = false;
                        txtcodigo.Visible = false;


                        encabasignados.Visible = false;
                        ajuridico.Attributes.Add("style", "margin-top: 70px;");
                        alerta2.Attributes.Add("style", "font-size:15px; color: lawngreen; text-align: initial; margin-left: -116px");
                        llenardthallazgo();
                        llenardtgasignado();
                      

                        break;

                    //Negocios
                    case "5":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                   

             

                    case "8":
                        txtbarras.Visible = true;
                        txtbarras2.Visible = true;

                        span1.Visible = true;
        
                        btnorden.Visible = true;
                        
                        alerta.Visible = false;
                        alerta2.Visible = false;
                        span.Visible = false;
                        span4.Visible = false;
                        txtlotes.Visible = false;
                        txtcodigo.Visible = false;
                     
                        encabenvio.Visible = true;
                        encabselec.Visible = true;
             
                        ajuridico.Visible = true;
                     
                        if (!IsPostBack) { }
                        //llenardtgvmesa();
                        llenardtgasignado();
                
                        llenarlistos();
                        break;
                    case "7":
                        txtbarras.Visible = true;
                
                        hallazgo.Visible = false;
                        span1.Visible = true;
                        span2.Visible = false;
                        span3.Visible = false;
             
                        alerta2.Visible = false;
                        txtbarras2.Visible = false;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = true;
                        btnorden.Text = "Comprobante";
                        pendientes.Visible = false;
                        alerta.Visible = false;
                 
                    
                        encabasignados.Visible = false;
                        llenararch();

                        break;

                }



            }
            else
            {
                Response.Redirect("../Session/MenuBarra.aspx");

            }


        }

        public void GenerarPDFjuridicomesa()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
          
            dt3 = mex.llenarenviomesaarch();

            if (dt3.Rows.Count < 1)
            {
                String script = "alert('Ningun elemento Seleccionado  '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
              

            }
            else
            {
                crearlotesalida();
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
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

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote2(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("NO. LOTE de Salida " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });

                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Archivo ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                doc.Add(tbl);



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenviomesaarch();


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


                        table.AddCell(new PdfPCell(new Phrase(Convert.ToString(datos2.GetValue(j)), detalletbl)) { Border = 1, BorderWidthLeft = 1, BorderWidthRight = 1, HorizontalAlignment = Element.ALIGN_JUSTIFIED });

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


                doc.NewPage();
                doc.Add(Chunk.NEWLINE);

                var tblj = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                tblj.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                tblj.AddCell(new PdfPCell(new Phrase("NO. LOTE de Salida " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tblj.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tblj.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                tblj.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                doc.Add(tblj);


                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };

                tbl.AddCell(new PdfPCell(new Phrase("Datos del Envío ", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
                tbl.AddCell(new PdfPCell(new Phrase("Origen: " + noma + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tbl.AddCell(new PdfPCell(new Phrase("Destino: Archivo ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                doc.Add(tbl);






                doc.Close();
                estadomesaarch();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=OrdenMesa" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
              
     

            }



        }
        public void GenerarPDFsolvencia()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            string cod = mex.aleatoriovalido(txtcodigo.Value);

            if (cod == "1")
            {
                dt3 = mex.repolotes(txtcodigo.Value);

                if (dt3.Rows.Count < 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

                }
                else
                {
                   
                    Document doc = new Document(PageSize.LETTER);
                    doc.SetMargins(40f, 40f, 40f, 40f);

                    PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                    doc.AddAuthor("Micoope");
                    doc.AddTitle("Carta");
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

                    //obtener el lote al que pertenece 1 exp
                    string lote = mex.mensajeronom(txtcodigo.Value);
                    int cant = dt3.Rows.Count;
                    string cant2 = Convert.ToString(cant);
                    doc.Add(Chunk.NEWLINE);

                    var tbl = new PdfPTable(new float[] { 5f, 90f }) { WidthPercentage = 100 };
                    tbl.AddCell(new PdfPCell(logo) { Border = 1, Rowspan = 6, VerticalAlignment = Element.ALIGN_LEFT });
                    tbl.AddCell(new PdfPCell(new Phrase("Mensajero: " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                    tbl.AddCell(new PdfPCell(new Phrase("Cantidad Recibida: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                    tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });
                    tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: " + fechaactual, parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP });

                    doc.Add(tbl);

                    doc.Add(new Phrase(" "));
                    doc.Add(new Phrase(" "));


                    string[] datos2 = mex.solvenciaarchivomensajeria(txtcodigo.Value);


                    PdfPTable table = new PdfPTable(2);
                    tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 100 };
                    var c1 = new PdfPCell(new Phrase("Mensajero", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 4f };
                    var c2 = new PdfPCell(new Phrase("Lote", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
            


 
           
                    table.TotalWidth = 550f;

                    table.LockedWidth = true;
                    float[] widths = new float[] { 25f, 25f };
                    table.SetWidths(widths);
                    table.HorizontalAlignment = 0;

                    table.AddCell(c1);
                    table.AddCell(c2);
           

                    c1.Border = 0;
                    c2.Border = 0;
              
                    try
                    {

                        for (int j = 0; j < datos2.Length; j++)
                        {

                            /*c1.Phrase = new Phrase(Convert.ToString(datos2.GetValue(j)));*/


                            table.AddCell(new PdfPCell(new Phrase(Convert.ToString(datos2.GetValue(j)), detalletbl)) { Border = 1, BorderWidthLeft = 1, BorderWidthRight = 1, HorizontalAlignment = Element.ALIGN_JUSTIFIED });

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
                  
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=comprobante" + ".pdf");
                    HttpContext.Current.Response.Write(doc);
                    Response.Flush();
                    Response.End();



                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Código inválido')", true);
                txtcodigo.Value = "";

            }


        }

        public void crearlotesalida()
        {

         

            DataTable dt3 = new DataTable();
    
            dt3 = mex.llenarenviomesaarch();
            string numerolote = exc.siguiente2("ex_lotesalida", "numerolote");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {


                string codex =exc.obtenercodexp( dt3.Rows[i]["gen_numcredito"].ToString());

                string envio = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                string siglote = exc.siguiente("ex_lotesalida", "codlote");

             
                string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + envio + "', '" + codex + "', '" + fechaactual + "', 2, 5 );";
                exc.Insertar(bitacora);
                string lote = "INSERT INTO `ex_lotesalida`(`codlote`, `codexp`, `numerolote`, `estado`) VALUES ('" + siglote + "', '" + codex + "', '" + numerolote + "', 0)";
                exc.Insertar(lote);


            }


        }
        public void estadomesaarch()
        {

            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.llenarenviomesaarch();
            if (dt3.Rows.Count != 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                    string codenv = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                    string codexp = exc.obtenercodexp(dt3.Rows[i]["gen_numcredito"].ToString());

                    string updateest = "UPDATE `ex_envio` SET `estado`=2 ,`codexetapa`= 5 WHERE Nocredito =  '" + dt3.Rows[i]["gen_numcredito"].ToString() + "'";
                    exc.Insertar(updateest);
                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + codenv + "', '" + codexp + "', '" + fechaactual + "', 2, 5 );";
                    exc.Insertar(bitacora);

                }
            }



        }
        protected void btnorden_Click(object sender, EventArgs e)
        {
            string rol = exc.obtenerrol(usernombre);
            switch (rol) {


                case "7":
                    alerta7.Visible = true;
                    alerta7.InnerText = "¿Desea Generar El Comprobante?";
                    divsi.Visible = true;
                    divno.Visible = true;

                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    hallazgo.Visible = false;
                    span3.Visible = false;
                    btndiv.Visible = false;
                    break;
                case "8":
                    alerta7.Visible = true;
                    alerta7.InnerText = "¿Desea Generar la carta de transporte con los expedientes seleccionados?";
                    divsi.Visible = true;
                    divno.Visible = true;

                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    hallazgo.Visible = false;
                    span3.Visible = false;
                    btndiv.Visible = false;


                    break;
          



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

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + hora;

                    fechaactual = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
        public void llenardtgvmesa()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesaarch();
            DGVSELECT.DataSource = dt1;
            DGVSELECT.DataBind();

        }
        public void llenararch()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenararch();
            DGVAMARCAR.DataSource = dt1;
            DGVAMARCAR.DataBind();

        }

        public void llenardthallazgo()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesarchasignadohall(coduser);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }
        public void llenardtgasignado()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesarchasignado(coduser);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }

        protected void DGVSELECT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVSELECT.PageIndex = e.NewPageIndex;
            llenardtgvmesa();
        }

        protected void DGVSELECT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string quien = asignado.SelectedValue;
            //int invl = asignado.SelectedIndex;


            //GridViewRow row = DGVSELECT.SelectedRow;
            //DataTable dt1 = new DataTable();
            //string numcred = (DGVSELECT.SelectedRow.FindControl("lblnumcred") as Label).Text;
            //string codexp = exc.obtenercodexp(numcred);
            //string sigas = exc.siguiente("ex_asignado", "codasig");
            //if (quien != "" && invl != 0)
            //{

            //    string asignar = "INSERT INTO `ex_asignado`(`codasig`, `codexp`, `codasignado`, `proceso`) VALUES ('" + sigas + "', '" + codexp + "', '" + asignado.SelectedValue + "' , 5)";
            //    exc.Insertar(asignar);

            //    Response.Redirect("Ex_VistaMesaQA.aspx");
            //}
            //else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione a quién desea asignarle los expedientes.')", true); }



        }

        protected void DGVCONHALLAZGO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVCONHALLAZGO.PageIndex = e.NewPageIndex;
            llenardtgasignado();

        }

        protected void DGVCONHALLAZGO_SelectedIndexChanged(object sender, EventArgs e)
        {


            string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string rol = exc.obtenerrol(usernombre);
            switch (rol)
            {

                case "2":
                    btnhallazgo.Visible = true;
                    btndiv.Visible = true;
                    btndivhall.Visible = true;
                    hallazgo.Visible = true;
                    alerta5.Visible = true;
                    span3.Visible = true;
                    num.InnerText = numcred;
                    btndivhall.Attributes.Add("style", "margin-left: -284%; position: absolute; margin-top: 18%; ");
                    btndiv.Attributes.Add("style", "margin-left: -184%; position: absolute; margin-top: 18%; ");
                    break;
                case "8":
                    btnhallazgo.Visible = true;
                    btndiv.Visible = true;
                    btndivhall.Visible = true;
                    hallazgo.Visible = true;
                    alerta5.Visible = true;

                    alerta7.Visible = false;
                    divsi.Visible = false;
                    divno.Visible = false;

                    span3.Visible = true;
           
                    divuserbtn.Visible = false;
                    encabasignados.Visible = false;
    
                    num.InnerText = numcred;
                    break;

                    //string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;


                    //string codexpe = exc.obtenercodexp(numcred);
                    //string cargar = mex.obtenerhall(codexpe);
                    //if (codexpe != "")
                    //{

                    //    hallazgo.Visible = true;
                    //    hallazgo.Disabled = true;
                    //    span3.Visible = true;
                    //    if (cargar == "NULL")
                    //    {
                    //        num.InnerText = numcred;
                    //        hallazgo.Value = "No se registraron hallazgos. Puede enviarlo.";
                    //    }
                    //    else
                    //    {
                    //        num.InnerText = numcred;
                    //        hallazgo.Value = cargar;

                    //    }

                    //}
                    //else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Expediente Inválido')", true); }


            }
        }

        protected void txtbarras_TextChanged(object sender, EventArgs e)
        {
            //buscar segun codigo ingresado y cargar en dgv pendiente

            string roler = exc.obtenerrol(usernombre);

            switch(roler){

                case "8":
                    string barras = txtbarras.Text;
                    Regex regex = new Regex("");
                    string[] s = regex.Split(barras);



                    if (s.Length == 14)
                    {

                        string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];



                        string obtener = mex.confirmarasog(numero);
                        string coaexist = mex.expedienteexiste(numero, "2", "4");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);

                        if (dthall.Rows.Count != 0)
                        {
                            if (codenv != "" && coaexist != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }
                        }
                        else {

                            if (codenv != "" && coaexist != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

                        }
                    }

                    else if (s.Length == 15)
                    {

                        string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                        string obtener = mex.confirmarasog(numero);


                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string coaexist = mex.expedienteexiste(numero, "2", "4");
                        DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);

                        if (dthall.Rows.Count != 0)
                        {
                            if (codenv != "" && coaexist != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }
                        }
                        else
                        {

                            if (codenv != "" && coaexist != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

                        }
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;

                case "7":
                    string barrasarc = txtbarras.Text;
                    Regex regexarc = new Regex("");
                    string[] sarc = regexarc.Split(barrasarc);



                    if (sarc.Length == 14)
                    {

                        string numero = "0" + sarc[1] + sarc[2] + sarc[3] + sarc[4] + sarc[5] + sarc[6] + sarc[7] + sarc[8] + sarc[9];


                        string coaexist = mex.expedienteexiste(numero, "9", "6");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);

                        if (codenv != "" && coaexist != "")
                        {


                            string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 7  WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 7 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

                    }

                    else if (sarc.Length == 15)
                    {

                        string numero = sarc[1] + sarc[2] + sarc[3] + sarc[4] + sarc[5] + sarc[6] + sarc[7] + sarc[8] + sarc[9] + sarc[10];




                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string coaexist = mex.expedienteexiste(numero, "9", "6");
                        if (codenv != "" && coaexist != "")
                        {


                            string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 7  WHERE Nocredito = '" + numero + "'";
                            exc.Insertar(updateres);
                            string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                            string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 7 );";
                            exc.Insertar(bitacoraa);

                            txtbarras.Text = "";
                            String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a un expediente existente o ya fué ingresado')", true); }

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;

            
            
            }

            
        }

        protected void DGVAMARCAR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVAMARCAR.PageIndex = e.NewPageIndex;
            llenardtgasignado();
        }

        protected void DGVOREN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVOREN.PageIndex = e.NewPageIndex;
            llenarlistos();
        }

        protected void txtbarras2_TextChanged(object sender, EventArgs e)
        {


            string rol = exc.obtenerrol(usernombre);

            switch (rol)
            {

                case "2":
                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    span3.Visible = false;
                    hallazgo.Visible = false;
                    btndiv.Visible = false;
                    divbtnverificar.Attributes.Add("style", "margin-left: -46%; position: absolute;margin-top: -24%;");
                    break;
  
                case "8":

                    divbtnverificar.Visible = true;
                    alerta5.Visible = false;
                    btndivhall.Visible = false;
                    span3.Visible = false;
                    hallazgo.Visible = false;
                    btndiv.Visible = false;

                    break;
             



            }





        }

        protected void btnlimpiar_Click(object sender, EventArgs e)
        {
            if (num.InnerText != "")
            {

                string codexp = exc.obtenercodexp(num.InnerText);
        

                string insertarhall = "UPDATE `ex_expediente` SET `ex_comentario`='' WHERE codexp = '" + codexp + "'";
                exc.Insertar(insertarhall);

               
                String script = "alert('Expediente Listo '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione el Expediente)", true); }
        }

        protected void txtbarras3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnhallazgo_Click(object sender, EventArgs e)
        {
            if (hallazgo.Value != "")
            {


                string envioev = exc.obtenercodenv(num.InnerText);
                string sighall = exc.siguiente("ex_hallazgos", "codexhall");
                string exped = exc.obtenercodexp(num.InnerText);
                string insertarhall = "INSERT INTO `ex_hallazgos`(`codexhall`, `codexp`, `hallazgo`, `estadohall`) VALUES ('" + sighall + "','" + exped + "', '" + hallazgo.Value + "',1 ) ;";
                exc.Insertar(insertarhall);

                //string updateretenido = "UPDATE `ex_envio` SET  `estado`= 3 WHERE codexenvio = '"+envioev+"'";
                //exc.Insertar(updateretenido);
                String script = "alert('Hallazgo Enviado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ingrese los hallazgos o Recargue la página')", true); }

        }

        protected void consultahall_Click(object sender, EventArgs e)
        {
            string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;
            if (numcred != "")
            {
                string noexp = exc.obtenercodexp(numcred);

                Session["exp"] = noexp;
                Session["nocredit"] = numcred;
                Response.Redirect("Ex_verhallazgos.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' No hay un expediente seleccionado')", true);


            }
        }

        protected void btnasignaruser_Click(object sender, EventArgs e)
        {

        }

        protected void si_Click(object sender, EventArgs e)
        {
            string permiso = exc.obtenerrol(usernombre);
            try
            {

                switch (permiso)
                {
                    //agencia jefe

                    //mesa encargado 8
                    case "8":

                        
                        GenerarPDFjuridicomesa();
                        Response.Redirect("Ex_VistaMesaQA.aspx");

                        break;
                    case "7":
                        GenerarPDFsolvencia();

                            break;




                }




            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }

        }

        protected void no_Click(object sender, EventArgs e)
        {
            String script = "alert('Orden cancelada '); window.location.href= 'Ex_VistaMesaQA.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_pendienteAg.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");
        }

        protected void btnmensajero_Click(object sender, EventArgs e)
        {
            string verifica = mex.aleatoriovalido(txtcodigo.Value);
            string verifica2 = mex.lotevalidado2(txtlotes.Text).Trim();
            if (verifica == "1" )
            {
                if (txtlotes.Text != "")
                {

                    switch (verifica2)
                    {

                        case "2":
                        
                            DataTable dt4 = new DataTable();
                            dt4 = mex.lotesinfo2(txtlotes.Text);
                            string siginfo = exc.siguiente("ex_lotemensajero", "codexlotemensajero");
                            string repoinfo = "INSERT INTO `ex_lotemensajero`(`codexlotemensajero`, `ex_mensajerocod`, `ex_lote`, `estado`) VALUES ('" + siginfo + "','" + txtcodigo.Value + "','" + txtlotes.Text + "',1)";
                            exc.Insertar(repoinfo);

                            if (dt4.Rows.Count != 0)
                            {
                                for (int i = 0; i < dt4.Rows.Count; i++)
                                {

                                    string numeroenv = dt4.Rows[i]["codexp"].ToString();
                                    string codexp = exc.obtenercodexp(dt4.Rows[i]["codgencred"].ToString());
                                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                                  

                                    string updatelote = "UPDATE `ex_lotesalida` SET  `estado`= 3 WHERE numerolote = '" + txtlotes.Text + "' ";
                                    exc.Insertar(updatelote);
                                    string updateenviolote = "UPDATE `ex_envio` SET `estado`= 9,`codexetapa`= 6 WHERE codexenvio = '" + numeroenv + "' ";
                                    exc.Insertar(updateenviolote);

                                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 9, 6 );";
                                    exc.Insertar(bitacora);

                                  
                                    txtlotes.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                                }
                            }
                            else { txtlotes.Text = ""; ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }



                            break;
                        case "3":
                            txtlotes.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote ya fué recibido en archivo')", true);

                            break;

                        default:
                            txtlotes.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote no Existe')", true);
                            break;


                    }
                }
                else {
                    String script = "alert('Ingrese el número de lote  '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);


                }
            }
            else {

                String script = "alert('El código del mensajero es inválido  '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);


            }
        }

        protected void txtlotes_TextChanged(object sender, EventArgs e)
        {
            
                    divrecib.Attributes.Add("style", " margin-top: 3%;");
            divrecib.Visible = true;
        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {

            string rolu = exc.obtenerrol(usernombre);

            switch (rolu)
            {

                case "2":
                    string barras = txtbarras2.Text;
                    Regex regex = new Regex("");
                    string[] s = regex.Split(barras);



                    if (s.Length == 14)
                    {

                        string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];



                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "5");
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);
                        if (dthall.Rows.Count == 0)
                        {
                            if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }
                        }
                        else {
                            String script = "alert('El expediente no puede ser enviado al archivo porque tiene hallazgos '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                        }


                    }

                    else if (s.Length == 15)
                    {

                        string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                        string obtener = mex.confirmarasog(numero);


                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "5");
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);

                             DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);
                        if (dthall.Rows.Count == 0)
                        {
                            if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }
                        }
                        else
                        {
                            String script = "alert('El expediente no puede ser enviado al archivo porque tiene hallazgos '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
                case "8":
                    string barras8 = txtbarras2.Text;
                    Regex regex8 = new Regex("");
                    string[] s8 = regex8.Split(barras8);



                    if (s8.Length == 14)
                    {

                        string numero = "0" + s8[1] + s8[2] + s8[3] + s8[4] + s8[5] + s8[6] + s8[7] + s8[8] + s8[9];



                        string obtener = mex.confirmarasog(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        string a = exc.obtenerarea(usernombre);
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string etapa = mex.expedienteexiste(numero, "1", "5");

                        DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);
                        if (dthall.Rows.Count == 0)
                        {
                            if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                            {

                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }
                        }
                        else
                        {
                            String script = "alert('El expediente no puede ser enviado al archivo porque tiene hallazgos '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                    }

                    else if (s8.Length == 15)
                    {

                        string numero = s8[1] + s8[2] + s8[3] + s8[4] + s8[5] + s8[6] + s8[7] + s8[8] + s8[9] + s8[10];


                        string obtener = mex.confirmarasog(numero);


                        string a = exc.obtenerarea(usernombre);
                        string etapa = mex.expedienteexiste(numero, "1", "5");
                        string codenv = exc.obtenercodenv(numero);
                        string codexpe = exc.obtenercodexp(numero);
                        string coasg = mex.confirmarareaasig2(numero);
                        DataTable dthall = new DataTable();
                        dthall = mex.llenarhallazgos(codexpe);
                        if (dthall.Rows.Count == 0)
                        {
                            if (codenv != "" && obtener != "" && coasg != "" && etapa != "")
                            {


                                string updateres = "UPDATE `ex_envio` SET `estado`= 8 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                                exc.Insertar(updateres);
                                string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                                string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 8, 5 );";
                                exc.Insertar(bitacoraa);

                                txtbarras.Text = "";
                                String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente ')", true); }
                        }
                        else
                        {
                            String script = "alert('El expediente no puede ser enviado al archivo porque tiene hallazgos '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
                    break;
              

            }
        }

        public void llenarlistos()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarenviomesaarch();
            DGVOREN.DataSource = dt1;
            DGVOREN.DataBind();

        }
        //public void llenarcomboasignadojuridico()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string QueryString = "select * from ex_controlingreso WHERE ex_controlarea = 43";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds, "usuarios");
        //            asignado.DataSource = ds;
        //            asignado.DataTextField = "nomcom";
        //            asignado.DataValueField = "codexcontroling";
        //            asignado.DataBind();
        //            asignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Usuarios]", "0"));
        //        }
        //        catch { Console.WriteLine("Verifique los campos"); }
        //    }
        //}

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }
    }
}