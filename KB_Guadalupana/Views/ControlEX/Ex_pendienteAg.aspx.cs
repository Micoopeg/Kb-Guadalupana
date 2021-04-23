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
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        string cif;
        string rol;
        string area;
        protected void Page_Load(object sender, EventArgs e)
        {


            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);
            if (usernombre != "" && coduser != "")
            { string permiso = exc.obtenerrol(usernombre);
                switch (permiso) {
                    case "1":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                    case "2":

                        txtcodigo.Visible = false;
                        break;
                    case "3":

                        txtcodigo.Visible = false;
                        break;
                    case "4":
                        llenardtgvw();
                        llenardtgvw2();
                        txtcodigo.Visible = true;
                        break;
                    case "5":
                        Response.Redirect("Ex_Principal.aspx");
                        break;



                }



            }
            else
            {
                Response.Redirect("../Session/MenuBarra.aspx");

            }


        }

        public void GenerarPDF2()
        {
            DataTable dt3 = new DataTable();
            dt3 = mex.codigostable(usernombre);
            if (dt3.Rows.Count < 1) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true); }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/cartaenvio.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
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

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


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



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenvio(usernombre);


                PdfPTable table = new PdfPTable(6);
                tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 800 };
                var c1 = new PdfPCell(new Phrase("Fecha/Hora Desembolso", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 4f };
                var c2 = new PdfPCell(new Phrase("CIF", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 2f };
                var c3 = new PdfPCell(new Phrase("NO. Préstamo", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 2f };
                var c4 = new PdfPCell(new Phrase("Nombre", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 2f };
                var c5 = new PdfPCell(new Phrase("Monto", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 2f };
                var c6 = new PdfPCell(new Phrase("Tipo", negrita)) { Border = 0, BorderWidthBottom = 2f, BorderColor = new BaseColor(0, 69, 161), Padding = 2f };


                string cont = exc.contpdf(usernombre);
                int envios = Convert.ToInt32(cont);
                table.TotalWidth = 400f;

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








                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/cartaenvio.pdf");


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
        public void GenerarPDF()
        {

            DataTable dt3 = new DataTable();
            dt3 = mex.codigostable(usernombre);
            if (dt3.Rows.Count < 1) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true); }

            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);
                try
                {

                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codigos.pdf", FileMode.Create));
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

                        tbl.AddCell(new PdfPCell(new Phrase("Nombre: " + dt3.Rows[i]["nomcom"].ToString() + " ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_CENTER });

                        tbl.AddCell(new PdfPCell(new Phrase("CIF: " + dt3.Rows[i]["cifgeneral"].ToString() + " ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                        tbl.AddCell(new PdfPCell(new Phrase("Monto: " + dt3.Rows[i]["gen_monto"].ToString() + " , Fecha Desembolso: " + dt3.Rows[i]["gen_fechadesembolso"].ToString() + " ", parrafo)) { BorderColor = new BaseColor(0, 69, 161), BorderWidthTop = 0, HorizontalAlignment = Element.ALIGN_CENTER });


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
                               Environment.SpecialFolder.Desktop) + "/codigos.pdf");
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
        protected void DGRVWPEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DGRVWPEN.SelectedRow;
            DataTable dt1 = new DataTable();
            string cod = (DGRVWPEN.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string sig = exc.siguiente("ex_temporal1","codextemp");

            string insert = "INSERT INTO `ex_temporal1` (`codextemp`, `Nocredito`, `estado`) VALUES ('"+sig+"', '"+cod+"', '7'); ";
            exc.Insertar(insert);

            Response.Redirect("Ex_pendienteAg.aspx");



        }

        protected void DGRVWPEN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGRVWPEN.PageIndex = e.NewPageIndex;
            llenardtgvw();



        }

        protected void DGRVW2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = DGRVW2.SelectedRow;

            //string cod = (DGRVW2.SelectedRow.FindControl("lblcod2tbl") as Label).Text;
            //Session["varenv"] = cod ;



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

        protected void btnorden_Click(object sender, EventArgs e)
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
                switch (permiso) {
                    //agencia
                    case "4":
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

                                    GenerarPDF();

                                    GenerarPDF2();
                                  
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
                //mesa
                    case "2":
                        GenerarPDF();
                        break;
                    //juridico
                    case "3":
                        GenerarPDF();
                        break;

                //archivo
                
                
                
                }
              



            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }

         

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {


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