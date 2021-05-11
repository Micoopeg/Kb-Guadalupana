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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iText.Layout.Properties;
using System.Globalization;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class CertificacionContable : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                credito.Visible = false;
                tarjeta.Visible = false;
                Guardar.Visible = false;
                Regresar.Visible = false;
                llenargridviewdocumentos();
                llenarformulario();
                validado.Visible = false;
                fechaactual();
                convertirnumeros();
                string sig3 = sn.siguiente("pj_certificacioncontable", "idpj_certificacioncontable");
                idcertidicacion.Value = sig3;
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento = 11";
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
                gridview1.DataSource = WS.buscarresponsables(numcredito);
                gridview1.DataBind();

                for (int i = 0; i < campos.Length; i++)
                {
                    Agencia.Value = campos[29];
                    Instrumento.Value = campos[17];
                    LineaCredito.Value = campos[18];
                    destino.Value = campos[28];
                    Garantia.Value = campos[22];
                    Plazomeses.Value = campos[2];
                    //Metodocalculo.Value = campos[7];
                    Estado.Value = campos[23];
                    Moneda.Value = "Quetzales";
                    Tasa.Value = campos[13];
                    string[] fecha = campos[3].Split(' ');
                    FechaSolicitud.Value = fecha[0];
                    string[] fecha2 = campos[4].Split(' ');
                    FechaDesembolso1.Value = fecha2[0];
                    string[] fecha3 = campos[10].Split(' ');
                    FechaUltimoDes.Value = fecha3[0];
                    string[] fecha4 = campos[5].Split(' ');
                    FechaVencimiento.Value = fecha4[0];
                    string[] fecha5 = campos[7].Split(' ');
                    FechaUltimaCuota.Value = fecha5[0];
                    string[] fecha6 = campos[12].Split(' ');
                    FechaActa.Value = fecha6[0];
                    NumActa.Value = campos[11];
                    NumPrestamo.Value = campos[1];
                    CreditoNumero.Value = campos[1];
                    DPI.Value = campos[21];
                    CodigoCliente.Value = campos[19];
                    NumCif.Value = campos[19];
                    NombreCliente.Value = campos[20];
                    ClienteNombre.Value = campos[20];
                    MontoOriginal.Value = "Q " + campos[9];
                    CapitalDesem.Value = "Q " + campos[9];
                    Interes1.Value = campos[16];
                    Intereses2.Value = campos[16];
                    Mora.Value = campos[14];
                    DescripcionDoc.Value = campos[24];
                    Saldo1.Value = campos[15];

                    if (campos[25] == "VACIO")
                    {
                        Oficial1.Visible = false;
                        NombreOficial.Visible = false;
                    }
                    if (campos[26] == "VACIO")
                    {
                        Oficial2.Visible = false;
                        NombreOficial2.Visible = false;
                    }
                    if (campos[27] == "VACIO")
                    {
                        Oficial3.Visible = false;
                        NombreOficial3.Visible = false;
                    }

                    NombreOficial.Value = campos[25];
                    NombreOficial2.Value = campos[26];
                    NombreOficial3.Value = campos[27];

                    if (campos[8] == "            .00")
                    {
                        SaldoActual.Value = "Q 0.00";
                    }
                    else
                    {
                        SaldoActual.Value = "Q " + campos[8];
                    }
                }

            }

            //for (int i = 0; i < campos.Length; i++)
            //{
            //    Agencia.Value = campos[1];
            //    Instrumento.Value = campos[2];
            //    LineaCredito.Value = campos[3];
            //    destino.Value = campos[4];
            //    Garantia.Value = campos[5];
            //    Plazomeses.Value = campos[6];
            //    Metodocalculo.Value = campos[7];
            //    Estado.Value = campos[8];
            //    Moneda.Value = campos[9];
            //    Tasa.Value = campos[10];
            //    string[] fecha = campos[11].Split(' ');
            //    FechaSolicitud.Value = fecha[0];
            //    string[] fecha2 = campos[12].Split(' ');
            //    FechaDesembolso1.Value = fecha2[0];
            //    string[] fecha3 = campos[13].Split(' ');
            //    FechaUltimoDes.Value = fecha3[0];
            //    string[] fecha4 = campos[14].Split(' ');
            //    FechaVencimiento.Value = fecha4[0];
            //    string[] fecha5 = campos[15].Split(' ');
            //    FechaUltimaCuota.Value = fecha5[0];
            //    string[] fecha6 = campos[16].Split(' ');
            //    FechaActa.Value = fecha6[0];
            //    NumActa.Value = campos[17];
            //    NombreOficial.Value = campos[18];
            //    NumPrestamo.Value = campos[19];
            //    AgenciaCliente.Value = campos[20];
            //    CodigoCliente.Value = campos[21];
            //    NombreCliente.Value = campos[22];
            //    MontoOriginal.Value = "Q " + campos[23];
            //    CapitalDesem.Value = "Q " + campos[24];
            //    SaldoActual.Value = "Q " + campos[25];
            //    Interes1.Value = "Q " + campos[26];
            //    Mora.Value = "Q " + campos[27];
            //    DescripcionDoc.Value = campos[28];
            //    Saldo1.Value = "Q " + campos[30];
            //}

            string[] campos2 = sn.obtenertipocredito(numcredito);
            string idcredito = campos2[0];
            if (idcredito == null)
            {
                Session["TipoCredito"] = "tarjeta";
                tarjeta.Visible = true;
                credito.Visible = true;

                string[] campos3 = sn.obtenertipotarjeta(numcredito);
                for (int i = 0; i < campos3.Length; i++)
                {
                    NumIncidente.Value = campos3[0];
                    NumeroIncidente.Value = campos3[0];
                    NumTarjeta.Value = campos3[1];
                    NumCuenta.Value = campos3[2];
                    CIF.Value = campos3[3];
                    PrimerNombre.Value = campos3[4];
                    SegundoNombre.Value = campos3[5];
                    OtroNombre.Value = campos3[6];
                    ApellidoCasada.Value = campos3[7];
                    PrimerApellido.Value = campos3[8];
                    SegundoApellido.Value = campos3[9];
                    Limite.Value = "Q " + campos3[10];
                    Saldo.Value = "Q " + campos3[11];
                    Gastos1.Value = campos3[13];
                    GastosJudiciales.Value = campos3[14];
                    OtrosGastos.Value = campos3[15];
                    Comentario.Value = campos3[16];
                    Total1.InnerText = "Q " + campos3[17];
                }
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumIncidente.Value = campos2[0];
                    NumeroIncidente.Value = campos2[0];
                    Gastos1.Value = campos2[1];
                    GastosJudiciales.Value = campos2[2];
                    OtrosGastos.Value = campos2[3];
                    Comentario.Value = campos2[5];
                    Total1.InnerText = "Q " + campos2[4];
                }
                credito.Visible = true;
                tarjeta.Visible = false;
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

        protected void Validar_Click(object sender, EventArgs e)
        {
            validado.Visible = true;
            Regresar.Visible = false;
            Validar.Visible = false;
            Guardar.Visible = true;
            Regresar2.Visible = false;
            Razones.Visible = false;
            Guardar.Focus();
        }

        protected void VerDocumento_Click(object sender, EventArgs e)
        {
            if(nombreContador.Value == "" | NumRegistro.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ingrese nombre del contador(a) general');", true);
            }
            else
            {
                string[] numeroregistrado = NumRegistro.Value.Split('-');
                string num1 = NumeroALetras((double)Convert.ToDecimal(numeroregistrado[0]));
                string num2 = NumeroALetras((double)Convert.ToDecimal(numeroregistrado[1]));
                Num1.Value = num1;
                Num2.Value = num2;
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

                //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/F1.png"));
                //logo.ScalePercent(45f);
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

                    //decimal total;
                    //total = Convert.ToDecimal(SaldoActual.Value) + Convert.ToDecimal(Interes1.Value);



                    //string fechaactual = sn.datetime();
                    //string[] fecha = fechaactual.Split('-');
                    //string año = fecha[0];
                    //string mes = fecha[1];
                    //string dia = fecha[2];
                    iTextSharp.text.Paragraph def = new iTextSharp.text.Paragraph("Certificación", new Font(basf, 17));
                    def.Alignment = Element.ALIGN_CENTER;
                    doc.Add(def);
                    doc.Add(new Paragraph(" ", parrafo));

                    iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("El infrascrito Perito Contador de Cooperativa Parroquial de Ahorro y Crédito Integral Guadalupana, R. L., registrado en la Superintendencia de Administración Tributaria bajo el número "+Num1.Value.ToLower()+" guion "+Num2.Value.ToLower()+" ("+NumRegistro.Value+"), hace constar que:", new Font(basf, 12));
                    def4.Alignment = Element.ALIGN_JUSTIFIED;
                    doc.Add(def4);

                    doc.Add(new Paragraph(" ", parrafo));

                    iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph("En sus Registros Contables figura el préstamo a nombre de " + NombreCliente.Value + " con un monto original de " + MontoOriginalLetras.Value+ " con "+MontoDecimales.Value + "/100 ( Q " + MontoOriginalEspacios.Value + "), y un saldo capital de " + SaldoActualLetras.Value + " con "+SaldoDecimales.Value+ "/100 ( Q " + SaldoEspacios.Value + "), e intereses de " + InteresesLetras.Value + " con " + InteresesDecimales.Value + "/100 ( Q " + InteresesEspacio.Value + "), los cuales hacen un total de " +TotalLetras.Value+ " con " +TotalDecimales.Value+"/100 ( Q " + Total.Value + ").", new Font(basf, 12));
                    def5.Alignment = Element.ALIGN_JUSTIFIED;
                    doc.Add(def5);

                    doc.Add(new Paragraph(" ", parrafo));

                    iTextSharp.text.Paragraph def6 = new iTextSharp.text.Paragraph("Y para los usos legales que a la interesada convenga, se extiende la presente a los " + DiaLetras.Value.ToLower() + " (" + Dia.Value + ") días del mes de " + MesLetras.Value.ToLower() + " (" + Mes.Value + ") del año " + AñoLetras.Value.ToLower() + " (" + Año.Value + ").", new Font(basf, 12));
                    def6.Alignment = Element.ALIGN_JUSTIFIED;
                    doc.Add(def6);

                    doc.Add(new Paragraph(" ", parrafo));
                    doc.Add(new Paragraph(" ", parrafo));
                    doc.Add(new Paragraph(" ", parrafo));
                    doc.Add(new Paragraph(" ", parrafo));
                    doc.Add(new Paragraph(" ", parrafo));
                    doc.Add(new Paragraph(" ", parrafo));

                    iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph(""+nombreContador.Value+"", new Font(basf, 12));
                    def2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(def2);
                    iTextSharp.text.Paragraph def3 = new iTextSharp.text.Paragraph("CONTADOR(A) GENERAL", new Font(basf, 12));
                    def3.Alignment = Element.ALIGN_CENTER;
                    doc.Add(def3);

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
                Response.AddHeader("content-disposition", "attachment;filename= " + idcertidicacion.Value + "-certificacion" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
                catch
                {
                }
        }

        public void fechaactual()
        {
            string fechaactual = sn.datetime();
            string[] fecha = fechaactual.Split('-');
            string año = fecha[0];
            string mes = fecha[1];
            string dia = fecha[2];

            Año.Value = año;
            Mes.Value = mes;
            Dia.Value = dia;

        }

        private string obtenerNombreMesNumero(int numeroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }

        private static string NumeroALetras(double value)
        {
            string num2Text = ""; 
            value = Math.Truncate(value);

            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        
        }

        public void convertirnumeros()
        {
            decimal total;
            string saldofinal = "";
            if(Saldo1.Value == "")
            {
                saldofinal = "0.00";
            }
            else
            {

                string[] saldo = Saldo1.Value.Split(' ');
                int numero2 = saldo.Length;
                string[] saldoactual = saldo[numero2 - 1].Split(',');
                SaldoEspacios.Value = saldo[numero2 - 1];


                for (int i = 0; i < saldoactual.Length; i++)
                {
                    saldofinal = saldofinal + saldoactual[i];
                }
            }

            string interesesfinal = "";
            if (Intereses2.Value == "")
            {
                interesesfinal = "0.00";
            }
            else
            {
                string[] intereses = Intereses2.Value.Split(' ');
                int numero = intereses.Length;
                string[] interesesactual = intereses[numero - 1].Split(',');

                InteresesEspacio.Value = intereses[numero - 1];

                for (int i = 0; i < interesesactual.Length; i++)
                {
                    interesesfinal = interesesfinal + interesesactual[i];
                }
            }

            total = Convert.ToDecimal(saldofinal) + Convert.ToDecimal(interesesfinal);
            Total.Value = string.Format("{0:#,0.00}", total);

            string saldoLetras;
            saldoLetras = NumeroALetras((double)Convert.ToDecimal(total));
            TotalLetras.Value = saldoLetras.ToString();
            string[] decimalesTotal = total.ToString().Split('.');
            TotalDecimales.Value = decimalesTotal[1].ToString();


            string saldoactualetras;
            saldoactualetras = NumeroALetras((double)Convert.ToDecimal(saldofinal));
            SaldoActualLetras.Value = saldoactualetras;
            string[] decimalesSaldo = saldofinal.Split('.');
            SaldoDecimales.Value = decimalesSaldo[1].ToString();

            string interesesletras;
            interesesletras = NumeroALetras((double)Convert.ToDecimal(interesesfinal));
            InteresesLetras.Value = interesesletras;
            string[] decimalesInteres = interesesfinal.Split('.');
            InteresesDecimales.Value = decimalesInteres[1].ToString();

            string mes;
            mes = obtenerNombreMesNumero(Convert.ToInt32(Mes.Value));
            MesLetras.Value = mes;

            string dia;
            dia = NumeroALetras((double)Convert.ToDecimal(Dia.Value));
            DiaLetras.Value = dia;

            string año;
            año = NumeroALetras((double)Convert.ToDecimal(Año.Value));
            AñoLetras.Value = año;


            string[] monto = MontoOriginal.Value.Split(' ');
            int numero3 = monto.Length;
            string[] montoactual = monto[numero3 - 1].Split(',');
            string montofinal = "";
            MontoOriginalEspacios.Value = monto[numero3 - 1];

            for (int i = 0; i < montoactual.Length; i++)
            {
                montofinal = montofinal + montoactual[i];
            }

            string montooriginalletras;
            montooriginalletras = NumeroALetras((double)Convert.ToDecimal(montofinal));
            MontoOriginalLetras.Value = montooriginalletras;
            string[] decimalesMonto = montofinal.Split('.');
            MontoDecimales.Value = decimalesMonto[1].ToString();

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            //PENDIENTE GUARDAR DOCUMENTO

            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");

            string sig3 = sn.siguiente("pj_certificacioncontable", "idpj_certificacioncontable");
            sn.guardarcreditocontable(sig3, NumRegistro.Value,nombreContador.Value, numcredito, idusuario, Observaciones.Value);
            sn.guardaretapa(sig2, "2", numcredito, sn.datetime(), "Enviado", idusuario, "28", NombreCliente.Value);
            sn.cambiarestado(numcredito, "1");

            string tipocredito = Session["TipoCredito"] as string;
            string fecha;

            if (tipocredito == "tarjeta")
            {
                fecha = sn.fechacreaciontarjeta(numcredito);
            }
            else
            {
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
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "26", "28", fechahoraactual, fechacreacion2, "Recibido");

            string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig4, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "28", "34", fechahoraactual, fechacreacion2, Observaciones.Value);


            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se guardó exitosamente');", true);
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Validar.Visible = false;
            Regresar.Visible = false;
            certificacion.Visible = false;
            Contador.Visible = false;

            string numcredito = Session["credito"] as string;
            sn.estadodevuelto(numcredito, "28", "1");
            

            string tipocredito = Session["TipoCredito"] as string;
            string id = "";
            string tabla = "";
            string fecha;

            if(tipocredito == "tarjeta")
            {
                id = "idpj_tipotarjeta";
                tabla = "pj_tipotarjeta";
                fecha = sn.fechacreaciontarjeta(numcredito);
            }
            else
            {
                id = "idpj_tipocredito";
                tabla = "pj_tipocredito";
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
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "26", "28", fechahoraactual, fechacreacion2, "Sin comentarios");

            string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Devuelto", "28", "26", fechahoraactual, fechacreacion2, RazonesRechazo.Value);


            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El crédito regresó a cobros');", true);
        }

        protected void Regresar2_Click(object sender, EventArgs e)
        {
            Validar.Visible = false;
            Regresar2.Visible = false;
            certificacion.Visible = false;
            Regresar.Visible = true;
            Guardar.Visible = false;
            validado.Visible = true;
            comentario2.Visible = false;
            Contador.Visible = false;
            Razones.Visible = true;
            Regresar.Focus();
        }
    }
}