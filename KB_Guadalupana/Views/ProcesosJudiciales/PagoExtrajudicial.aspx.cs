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
    public partial class PagoExtrajudicial : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["credito"] = "0600564056";
                FechaActual.Value = sn.datetime();
                llenarformulario();
                llenarcomentarios();
                llenarcombointegracion();
                //llenarcomborecibo();
                llenarcombotipopago();
                //TotalidadDeuda.Visible = false;
                //SaldoVencido.Visible = false;
                integracion.Visible = false;
                datos.Visible = false;
                fechas.Visible = false;
                tabladatos.Visible = false;
                pagosextras.Visible = false;
                Generar.Visible = false;
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
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'MenuPrincipalProcesos.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                gridview1.DataSource = WS.buscarresponsables(numcredito);
                gridview1.DataBind();

                for (int i = 0; i < campos.Length; i++)
                {
                    //DiasMora.Value = campos[6];
                    NumPrestamo.Value = campos[1];
                    CreditoNumero.Value = campos[1];
                    DPI.Value = campos[21];
                    CodigoCliente.Value = campos[19];
                    NumCif.Value = campos[19];
                    NombreCliente.Value = campos[20];
                    ClienteNombre.Value = campos[20];
                    MontoOriginal.Value = "Q " + campos[9];
                    CapitalDesem.Value = "Q " + campos[9];
                    Estado.Value = campos[23];
                    Garantia.Value = campos[22];
                    Morosidad.Value = campos[6];

                    if (campos[8] == "            .00")
                    {
                        SaldoActual.Value = "Q 0.00";
                        CapitalSaldo.Value = "0.00";
                    }
                    else
                    {
                        SaldoActual.Value = "Q " + campos[8];
                        CapitalSaldo.Value = campos[8];
                    }
                }
            }

            string[] campos2 = sn.obtenertipocredito(numcredito);
            string idcredito = campos2[0];
            if (idcredito == null)
            {
                Session["TipoCredito"] = "tarjeta";

                string[] campos3 = sn.obtenertipotarjeta(numcredito);
                for (int i = 0; i < campos3.Length; i++)
                {
                    NumIncidente.Value = campos3[0];
                    NumeroIncidente.Value = campos3[0];
                    InteresesSaldo.Value = campos3[21];
                    MoraSaldo.Value = campos3[22];
                }
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumIncidente.Value = campos2[0];
                    NumeroIncidente.Value = campos2[0];
                    InteresesSaldo.Value = campos2[10];
                    MoraSaldo.Value = campos2[11];
                }
            }
        }

        public void llenarcomentarios()
        {
            DataSet comentarios = new DataSet();
            string numcredito = Session["credito"] as string;
            comentarios = sn.consultarComentarios(numcredito);
            Repeater1.DataSource = comentarios;
            Repeater1.DataBind();
        }

        public void llenarcombointegracion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 56";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    DocumentoIntegracion.DataSource = ds;
                    DocumentoIntegracion.DataTextField = "pj_nombretipodoc";
                    DocumentoIntegracion.DataValueField = "idpj_tipodocumento";
                    DocumentoIntegracion.DataBind();
                    DocumentoIntegracion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoIntegracion.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload1.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, DocumentoIntegracion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload1.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentos();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
                    }
                }
                gridViewIntegracion.Focus();
            }
            catch
            {

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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 56";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIntegracion.DataSource = dt;
                    gridViewIntegracion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedIntegracion(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewIntegracion.SelectedRow.FindControl("lblid") as Label).Text);
                string documentoselec = sn.obtenerrutadocumento(id);

                string nombrearchivo = sn.nombrearchivo(id);
                string[] extension = nombrearchivo.Split('.');
                int tamaño = extension.Length;
                string tipo = extension[tamaño - 1];

                string FilePath = Server.MapPath(documentoselec);
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    if (tipo.ToLower() == "pdf")
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if (tipo.ToLower() == "tif" || tipo.ToLower() == "tiff")
                    {
                        Response.ContentType = "image/tiff";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
            }
            catch
            {

            }
        }

        //public void llenarcomborecibo()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 57";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds);
        //            DocumentoRecibo.DataSource = ds;
        //            DocumentoRecibo.DataTextField = "pj_nombretipodoc";
        //            DocumentoRecibo.DataValueField = "idpj_tipodocumento";
        //            DocumentoRecibo.DataBind();
        //            DocumentoRecibo.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void agregar2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (DocumentoRecibo.SelectedValue == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
        //        }
        //        else
        //        {
        //            if (FileUpload2.HasFile)
        //            {
        //                string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
        //                ext = ext.ToLower();

        //                if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
        //                {
        //                    string numcredito = Session["credito"] as string;
        //                    string siguiente = sn.siguiente("pj_documento", "idpj_documento");
        //                    documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload2.FileName;
        //                    string nombredoc = siguiente + '-' + FileUpload2.FileName;
        //                    sn.guardardocumentoexp(siguiente, DocumentoRecibo.SelectedValue, documento, nombredoc, numcredito);
        //                    FileUpload2.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload2.FileName));
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
        //                    llenargridviewrecibo();
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
        //            }
        //        }
        //        gridViewIntegracion.Focus();
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void llenargridviewrecibo()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            string numcredito = Session["credito"] as string;
        //            sqlCon.Open();
        //            string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 57";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataTable dt = new DataTable();
        //            myCommand.Fill(dt);
        //            gridViewRecibo.DataSource = dt;
        //            gridViewRecibo.DataBind();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void OnSelectedIndexChangedRecibo(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString((gridViewRecibo.SelectedRow.FindControl("lblid") as Label).Text);
        //        string documentoselec = sn.obtenerrutadocumento(id);

        //        string nombrearchivo = sn.nombrearchivo(id);
        //        string[] extension = nombrearchivo.Split('.');
        //        int tamaño = extension.Length;
        //        string tipo = extension[tamaño - 1];

        //        string FilePath = Server.MapPath(documentoselec);
        //        WebClient User = new WebClient();
        //        Byte[] FileBuffer = User.DownloadData(FilePath);
        //        if (FileBuffer != null)
        //        {
        //            if (tipo.ToLower() == "pdf")
        //            {
        //                Response.ContentType = "application/pdf";
        //                Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //                Response.BinaryWrite(FileBuffer);
        //            }
        //            else if (tipo.ToLower() == "tif" || tipo.ToLower() == "tiff")
        //            {
        //                Response.ContentType = "image/tiff";
        //                Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //                Response.BinaryWrite(FileBuffer);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        protected void Solicitud_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string integraciondoc = sn.tipodocumentointegracion(numcredito);

            //if(integraciondoc == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe completar los datos');", true);
            //}
            
                //sn.cambiarestado(numcredito, "31");
                string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig11, "31", numcredito, sn.datetime(), "Enviado", idusuario, "26", NombreCliente.Value, NumIncidente.Value);

                string tipocredito = Session["TipoCredito"] as string;
                string fecha5;

                if (tipocredito == "tarjeta")
                {
                    fecha5 = sn.fechacreaciontarjeta(numcredito);
                }
                else
                {
                    fecha5 = sn.fechacreacioncredito(numcredito);
                }

                string[] fechaseparada = fecha5.Split(' ');
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
                sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "26", "26", fechahoraactual, fechacreacion2, Observaciones.Value);

                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "26", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                String script = "alert('Guardado exitosamente'); window.location.href= 'MenuPrincipalProcesos.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            
        }

        public void llenarcombotipopago()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipopago";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoPago.DataSource = ds;
                    TipoPago.DataTextField = "pj_nombretipo";
                    TipoPago.DataValueField = "idpj_tipopago";
                    TipoPago.DataBind();
                    TipoPago.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void TipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoPago.SelectedValue == "1")
            {
                //TotalidadDeuda.Visible = true;
                //SaldoVencido.Visible = false;
                datos.Visible = true;
                fechas.Visible = false;
                tabladatos.Visible = true;
                pagosextras.Visible = true;
                Generar.Visible = true;


                //if(Estado.Value == "VENCIDO EN COBRO JUDICIAL")
                //{
                //    pagosextras.Visible = true;
                //    TipoPago.Focus();
                //}
                //else
                //{
                //    pagosextras.Visible = false;
                //    TipoPago.Focus();
                //}
            }
            else
            {
                //TotalidadDeuda.Visible = false;
                //SaldoVencido.Visible = true;
                datos.Visible = true;
                fechas.Visible = true;
                tabladatos.Visible = true;
                pagosextras.Visible = true;
                Generar.Visible = true;

                //if (Estado.Value == "VENCIDO EN COBRO JUDICIAL")
                //{
                //    pagosextras.Visible = true;
                //    TipoPago.Focus();
                //}
                //else
                //{
                //    pagosextras.Visible = true;
                //    TipoPago.Focus();
                //}
            }
        }

        public void GenerarPDF()
        {
            string estado = Session["etapa"] as string;
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.Open();
                doc.NewPage();
                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                doc.AddAuthor("Integracion");
                doc.AddTitle("Integracion");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgaortiz/Documents/Rama-Aida/Kb-Guadalupana/KB_Guadalupana/Imagenes/Imagenes_procesos/encabezado_cheque.jpg"));
                logo.ScalePercent(35f);
                logo.Alignment = Element.ALIGN_CENTER;

                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont basf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT2 = "c:/windows/fonts/arialbd.ttf";
                BaseFont basf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT3 = "c:/windows/fonts/arial.ttf";
                BaseFont basf3 = BaseFont.CreateFont(FONT3, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font _basf3 = new iTextSharp.text.Font(basf3, 20f, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255));

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_subtitulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new Font(_parrafo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 11f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph("Asociado/CIF: " + NombreCliente.Value + " / " + CodigoCliente.Value, new Font(basf, 11));
                def2.Alignment = Element.ALIGN_LEFT;
                doc.Add(def2);

                iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("Préstamo BankWorks: " + NumPrestamo.Value, new Font(basf, 11));
                def4.Alignment = Element.ALIGN_LEFT;
                doc.Add(def4);

                iTextSharp.text.Paragraph def1 = new iTextSharp.text.Paragraph("Garantía: " + Garantia.Value, new Font(basf, 11));
                def1.Alignment = Element.ALIGN_LEFT;
                doc.Add(def1);

                iTextSharp.text.Paragraph def3 = new iTextSharp.text.Paragraph("Días de morosidad: " + Morosidad.Value, new Font(basf, 11));
                def3.Alignment = Element.ALIGN_LEFT;
                doc.Add(def3);

                iTextSharp.text.Paragraph def8 = new iTextSharp.text.Paragraph("Estado: " + Estado.Value, new Font(basf, 11));
                def8.Alignment = Element.ALIGN_LEFT;
                doc.Add(def8);

                iTextSharp.text.Paragraph def9 = new iTextSharp.text.Paragraph("Cartera: " + Cartera.Value, new Font(basf, 11));
                def9.Alignment = Element.ALIGN_LEFT;
                doc.Add(def9);

                iTextSharp.text.Paragraph def10 = new iTextSharp.text.Paragraph("Concentración: " + Concentracion.Value, new Font(basf, 11));
                def10.Alignment = Element.ALIGN_LEFT;
                doc.Add(def10);

                doc.Add(new Paragraph(" ", parrafo));

                //doc.Add(logo);

                //iTextSharp.text.Paragraph def = new iTextSharp.text.Paragraph("Solicitud de Cheque", new Font(basf, 17));
                //def.Alignment = Element.ALIGN_CENTER;
                //doc.Add(def);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph("Integracion de saldos al " + FechaActual.Value, new Font(basf, 11));
                def5.Alignment = Element.ALIGN_LEFT;
                doc.Add(def5);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def11 = new iTextSharp.text.Paragraph("Saldo vencido", new Font(basf2, 12));
                def11.Alignment = Element.ALIGN_LEFT;
                doc.Add(def11);

                

                var tbl3 = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100 };
                tbl3.AddCell(new PdfPCell(new Phrase("Monto desembolsado", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(CapitalDesem.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo Capital Actual", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(SaldoActual.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Rubro", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo real", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Descuento", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Porcentaje", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo a pagar", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Capital vencido", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + Capitalporcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Intereses vencidos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesPorcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Mora", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraPorcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Gastos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosPorcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Cobranza", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaPorcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Total", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalSaldo2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalDescuento2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPorcentaje2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));

                doc.Add(tbl3);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                
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
                Response.AddHeader("content-disposition", "attachment;filename= Integracion" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
        }

        public void GenerarPDF2()
        {
            string estado = Session["etapa"] as string;
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.Open();
                doc.NewPage();
                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                doc.AddAuthor("Integracion");
                doc.AddTitle("Integracion");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgaortiz/Documents/Rama-Aida/Kb-Guadalupana/KB_Guadalupana/Imagenes/Imagenes_procesos/encabezado_cheque.jpg"));
                logo.ScalePercent(35f);
                logo.Alignment = Element.ALIGN_CENTER;

                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont basf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT2 = "c:/windows/fonts/arialbd.ttf";
                BaseFont basf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT3 = "c:/windows/fonts/arial.ttf";
                BaseFont basf3 = BaseFont.CreateFont(FONT3, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font _basf3 = new iTextSharp.text.Font(basf3, 20f, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255));

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_subtitulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new Font(_parrafo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 11f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph("Asociado/CIF: " + NombreCliente.Value + " / " + CodigoCliente.Value, new Font(basf, 11));
                def2.Alignment = Element.ALIGN_LEFT;
                doc.Add(def2);

                iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("Préstamo BankWorks: " + NumPrestamo.Value, new Font(basf, 11));
                def4.Alignment = Element.ALIGN_LEFT;
                doc.Add(def4);

                iTextSharp.text.Paragraph def1 = new iTextSharp.text.Paragraph("Garantía: " + Garantia.Value, new Font(basf, 11));
                def1.Alignment = Element.ALIGN_LEFT;
                doc.Add(def1);

                iTextSharp.text.Paragraph def3 = new iTextSharp.text.Paragraph("Días de morosidad: " + Morosidad.Value, new Font(basf, 11));
                def3.Alignment = Element.ALIGN_LEFT;
                doc.Add(def3);

                iTextSharp.text.Paragraph def8 = new iTextSharp.text.Paragraph("Estado: " + Estado.Value, new Font(basf, 11));
                def8.Alignment = Element.ALIGN_LEFT;
                doc.Add(def8);

                iTextSharp.text.Paragraph def9 = new iTextSharp.text.Paragraph("Cartera: " + Cartera.Value, new Font(basf, 11));
                def9.Alignment = Element.ALIGN_LEFT;
                doc.Add(def9);

                iTextSharp.text.Paragraph def10 = new iTextSharp.text.Paragraph("Concentración: " + Concentracion.Value, new Font(basf, 11));
                def10.Alignment = Element.ALIGN_LEFT;
                doc.Add(def10);

                doc.Add(new Paragraph(" ", parrafo));

                //doc.Add(logo);

                //iTextSharp.text.Paragraph def = new iTextSharp.text.Paragraph("Solicitud de Cheque", new Font(basf, 17));
                //def.Alignment = Element.ALIGN_CENTER;
                //doc.Add(def);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph("Integracion de saldos al " + FechaActual.Value, new Font(basf, 11));
                def5.Alignment = Element.ALIGN_LEFT;
                doc.Add(def5);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def11 = new iTextSharp.text.Paragraph("Saldo vencido", new Font(basf, 12));
                def11.Alignment = Element.ALIGN_LEFT;
                doc.Add(def11);
                doc.Add(new Paragraph(" ", parrafo));



                var tbl3 = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100 };
                tbl3.AddCell(new PdfPCell(new Phrase("Monto desembolsado", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(CapitalDesem.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo Capital Actual", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(SaldoActual.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Rubro", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo real", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Descuento", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Porcentaje", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo a pagar", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Capital vencido", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(Capitalporcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Intereses vencidos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(InteresesPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Mora", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(MoraPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Gastos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(GastosPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Cobranza", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(CobranzaPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Subtotal", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalSaldo2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalDescuento2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Honorarios profesionales", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(HonorariosPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Costas y gastos judiciales", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(CostasPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Desistimiento", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(DesistimientoPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Total", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalSaldo3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalDescuento3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPorcentaje3.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalPagar3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));

                doc.Add(tbl3);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


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
                Response.AddHeader("content-disposition", "attachment;filename= Integracion" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
        }

        public void GenerarPDF3()
        {
            string estado = Session["etapa"] as string;
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(40f, 40f, 40f, 40f);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                doc.Open();
                doc.NewPage();
                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                doc.AddAuthor("Integracion");
                doc.AddTitle("Integracion");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgaortiz/Documents/Rama-Aida/Kb-Guadalupana/KB_Guadalupana/Imagenes/Imagenes_procesos/encabezado_cheque.jpg"));
                logo.ScalePercent(35f);
                logo.Alignment = Element.ALIGN_CENTER;

                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont basf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT2 = "c:/windows/fonts/arialbd.ttf";
                BaseFont basf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string FONT3 = "c:/windows/fonts/arial.ttf";
                BaseFont basf3 = BaseFont.CreateFont(FONT3, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font _basf3 = new iTextSharp.text.Font(basf3, 20f, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255));

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_subtitulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new Font(_parrafo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 11f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                iTextSharp.text.Paragraph def2 = new iTextSharp.text.Paragraph("Asociado/CIF: " + NombreCliente.Value + " / " + CodigoCliente.Value, new Font(basf, 11));
                def2.Alignment = Element.ALIGN_LEFT;
                doc.Add(def2);

                iTextSharp.text.Paragraph def4 = new iTextSharp.text.Paragraph("Préstamo BankWorks: " + NumPrestamo.Value, new Font(basf, 11));
                def4.Alignment = Element.ALIGN_LEFT;
                doc.Add(def4);

                iTextSharp.text.Paragraph def1 = new iTextSharp.text.Paragraph("Garantía: " + Garantia.Value, new Font(basf, 11));
                def1.Alignment = Element.ALIGN_LEFT;
                doc.Add(def1);

                iTextSharp.text.Paragraph def3 = new iTextSharp.text.Paragraph("Días de morosidad: " + Morosidad.Value, new Font(basf, 11));
                def3.Alignment = Element.ALIGN_LEFT;
                doc.Add(def3);

                iTextSharp.text.Paragraph def8 = new iTextSharp.text.Paragraph("Estado: " + Estado.Value, new Font(basf, 11));
                def8.Alignment = Element.ALIGN_LEFT;
                doc.Add(def8);

                iTextSharp.text.Paragraph def9 = new iTextSharp.text.Paragraph("Cartera: " + Cartera.Value, new Font(basf, 11));
                def9.Alignment = Element.ALIGN_LEFT;
                doc.Add(def9);

                iTextSharp.text.Paragraph def10 = new iTextSharp.text.Paragraph("Concentración: " + Concentracion.Value, new Font(basf, 11));
                def10.Alignment = Element.ALIGN_LEFT;
                doc.Add(def10);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def13 = new iTextSharp.text.Paragraph("Para cubrir cuotas de: " + FechaInicio.Value + " a " + FechaFin.Value, new Font(basf, 11));
                def13.Alignment = Element.ALIGN_LEFT;
                doc.Add(def13);
                doc.Add(new Paragraph(" ", parrafo));

                //doc.Add(logo);

                //iTextSharp.text.Paragraph def = new iTextSharp.text.Paragraph("Solicitud de Cheque", new Font(basf, 17));
                //def.Alignment = Element.ALIGN_CENTER;
                //doc.Add(def);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def5 = new iTextSharp.text.Paragraph("Integracion de saldos al " + FechaActual.Value, new Font(basf, 11));
                def5.Alignment = Element.ALIGN_LEFT;
                doc.Add(def5);
                doc.Add(new Paragraph(" ", parrafo));

                iTextSharp.text.Paragraph def11 = new iTextSharp.text.Paragraph("Saldo vencido", new Font(basf, 12));
                def11.Alignment = Element.ALIGN_LEFT;
                doc.Add(def11);
                doc.Add(new Paragraph(" ", parrafo));



                var tbl3 = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100 };
                tbl3.AddCell(new PdfPCell(new Phrase("Monto desembolsado", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(CapitalDesem.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(" ", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo Capital Actual", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase(SaldoActual.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Rubro", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo real", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Descuento", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Porcentaje", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Saldo a pagar", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Capital vencido", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(Capitalporcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CapitalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Intereses vencidos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(InteresesPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + InteresesPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Mora", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(MoraPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + MoraPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Gastos", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(GastosPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + GastosPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Cobranza", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(CobranzaPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CobranzaPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Subtotal", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalSaldo2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalDescuento2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Honorarios profesionales", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(HonorariosPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + HonorariosPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Costas y gastos judiciales", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(CostasPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + CostasPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Desistimiento", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoSaldo.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoDescuento.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(DesistimientoPorcentaje2.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + DesistimientoPagar2.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));
                tbl3.AddCell(new PdfPCell(new Phrase("Total", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.GREEN, HorizontalAlignment = Element.ALIGN_CENTER });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalSaldo3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalDescuento3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase(TotalPorcentaje3.Value + " %", new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl3.AddCell(new PdfPCell(new Phrase("Q " + TotalPagar3.Value, new Font(basf, 11))) { Border = 0, BorderWidthBottom = .5f, BorderWidthTop = .5f, BorderWidthLeft = .5f, BorderWidthRight = .5f, Padding = 4f, BackgroundColor = BaseColor.BLUE, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(new Phrase(" "));

                doc.Add(tbl3);
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));


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
                Response.AddHeader("content-disposition", "attachment;filename= Integracion" + ".pdf");
                HttpContext.Current.Response.Write(doc);
                Response.Flush();
                Response.End();
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
        }

        protected void Generar_Click(object sender, EventArgs e)
        {
            
            if(TipoPago.SelectedValue == "1")
            {
                llenartotales();
                GenerarPDF2();
            }
            else
            {
                llenartotales();
                GenerarPDF3();
            }
            //if (Estado.Value == "VENCIDO EN COBRO JUDICIAL")
            //{
            //    llenartotales();
            //    GenerarPDF2();
            //    integracion.Visible = true;
            //}
            //else
            //{
            //    string prueba = inSubtotalSaldo.Value;
            //    llenartotales();
            //    GenerarPDF();
            //    integracion.Visible = true;
            //}
        }

        public void llenartotales()
        {
            decimal capitalporcentaje = 0, interesesporcentaje = 0, moraporcentaje = 0, gastosporcentaje = 0, cobranzaporcentaje = 0;
            decimal capitalpagar = 0, interesespagar = 0, morapagar = 0, gastospagar = 0, cobranzapagar = 0;
            decimal totalporcentaje = 0, totalpagar = 0, totalsaldo = 0, totaldescuento = 0;
            decimal honorariosporcentaje = 0, costasporcentaje = 0, desistimientoporcentaje = 0;
            decimal honorariospagar = 0, costaspagar = 0, desistimientopagar = 0;
            decimal totalporcentaje2 = 0, totalpagar2 = 0, totalsaldo2 = 0, totaldescuento2 = 0;

            if (CapitalSaldo.Value == "0")
            {
                Capitalporcentaje2.Value = "0";
            }
            else
            {
                capitalporcentaje = (Convert.ToDecimal(CapitalDescuento.Value) / Convert.ToDecimal(CapitalSaldo.Value)) * Convert.ToDecimal(100);
                Capitalporcentaje2.Value = capitalporcentaje.ToString();
            }
            
            if(InteresesSaldo.Value == "0")
            {
                InteresesPorcentaje2.Value = "0";
            }
            else
            {
                interesesporcentaje = (Convert.ToDecimal(InteresesDescuento.Value) / Convert.ToDecimal(InteresesSaldo.Value)) * Convert.ToDecimal(100);
                InteresesPorcentaje2.Value = interesesporcentaje.ToString();
            }
            
            if(MoraSaldo.Value == "0")
            {
                MoraPorcentaje2.Value = "0";
            }
            else
            {
                moraporcentaje = (Convert.ToDecimal(MoraDescuento.Value) / Convert.ToDecimal(MoraSaldo.Value)) * Convert.ToDecimal(100);
                MoraPorcentaje2.Value = moraporcentaje.ToString();
            }
            
            if(GastosSaldo.Value == "0")
            {
                GastosPorcentaje2.Value = "0";
            }
            else
            {
                gastosporcentaje = (Convert.ToDecimal(GastosDescuento.Value) / Convert.ToDecimal(GastosSaldo.Value)) * Convert.ToDecimal(100);
                GastosPorcentaje2.Value = gastosporcentaje.ToString();
            }
            
            if(CobranzaSaldo.Value == "0")
            {
                CobranzaPorcentaje2.Value = "0";
            }
            else
            {
                cobranzaporcentaje = (Convert.ToDecimal(CobranzaDescuento.Value) / Convert.ToDecimal(CobranzaSaldo.Value)) * Convert.ToDecimal(100);
                CobranzaPorcentaje2.Value = cobranzaporcentaje.ToString();
            }
            


            if(HonorariosSaldo.Value == "0")
            {
                HonorariosPorcentaje2.Value = "0";
            }
            else
            {
                honorariosporcentaje = (Convert.ToDecimal(HonorariosDescuento.Value) / Convert.ToDecimal(HonorariosSaldo.Value)) * Convert.ToDecimal(100);
                HonorariosPorcentaje2.Value = honorariosporcentaje.ToString();
            }
            
            if (CostasSaldo.Value == "0")
            {
                CostasPorcentaje2.Value = "0";
            }
            else
            {
                costasporcentaje = (Convert.ToDecimal(CostasDescuento.Value) / Convert.ToDecimal(CostasSaldo.Value)) * Convert.ToDecimal(100);
                CostasPorcentaje2.Value = costasporcentaje.ToString();
            }
            
            if (DesistimientoSaldo.Value == "0")
            {
                DesistimientoPorcentaje2.Value = "0";
            }
            else
            {
                desistimientoporcentaje = (Convert.ToDecimal(DesistimientoDescuento.Value) / Convert.ToDecimal(DesistimientoSaldo.Value)) * Convert.ToDecimal(100);
                DesistimientoPorcentaje2.Value = desistimientoporcentaje.ToString();
            }
            

            capitalpagar = Convert.ToDecimal(CapitalSaldo.Value) - Convert.ToDecimal(CapitalDescuento.Value);
            CapitalPagar2.Value = capitalpagar.ToString();
            interesespagar = Convert.ToDecimal(InteresesSaldo.Value) - Convert.ToDecimal(InteresesDescuento.Value);
            InteresesPagar2.Value = interesespagar.ToString();
            morapagar = Convert.ToDecimal(MoraSaldo.Value) - Convert.ToDecimal(MoraDescuento.Value);
            MoraPagar2.Value = morapagar.ToString();
            gastospagar = Convert.ToDecimal(GastosSaldo.Value) - Convert.ToDecimal(GastosDescuento.Value);
            GastosPagar2.Value = gastospagar.ToString();
            cobranzapagar = Convert.ToDecimal(CobranzaSaldo.Value) - Convert.ToDecimal(CobranzaDescuento.Value);
            CobranzaPagar2.Value = cobranzapagar.ToString();

            honorariospagar = Convert.ToDecimal(HonorariosSaldo.Value) - Convert.ToDecimal(HonorariosDescuento.Value);
            HonorariosPagar2.Value = honorariospagar.ToString();
            costaspagar = Convert.ToDecimal(CostasSaldo.Value) - Convert.ToDecimal(CostasDescuento.Value);
            CostasPagar2.Value = costaspagar.ToString();
            desistimientopagar = Convert.ToDecimal(DesistimientoSaldo.Value) - Convert.ToDecimal(DesistimientoDescuento.Value);
            DesistimientoPagar2.Value = desistimientopagar.ToString();

            totalporcentaje = capitalporcentaje + interesesporcentaje + moraporcentaje + gastosporcentaje + cobranzapagar;
            TotalPorcentaje2.Value = totalporcentaje.ToString();

            totalpagar = capitalpagar + interesespagar + morapagar + gastospagar + cobranzapagar;
            TotalPagar2.Value = totalpagar.ToString();

            totalsaldo = Convert.ToDecimal(CapitalSaldo.Value) + Convert.ToDecimal(InteresesSaldo.Value) + Convert.ToDecimal(MoraSaldo.Value) + Convert.ToDecimal(GastosSaldo.Value) + Convert.ToDecimal(CobranzaSaldo.Value);
            TotalSaldo2.Value = totalsaldo.ToString();

            totaldescuento = Convert.ToDecimal(CapitalDescuento.Value) + Convert.ToDecimal(InteresesDescuento.Value) + Convert.ToDecimal(MoraSaldo.Value) + Convert.ToDecimal(GastosDescuento.Value) + Convert.ToDecimal(CobranzaDescuento.Value);
            TotalDescuento2.Value = totaldescuento.ToString();

            totalporcentaje2 = totalporcentaje + honorariosporcentaje + costasporcentaje + desistimientoporcentaje;
            TotalPorcentaje3.Value = totalporcentaje2.ToString();

            totalpagar2 = totalpagar + honorariospagar + costaspagar + desistimientopagar;
            TotalPagar3.Value = totalpagar2.ToString();

            totalsaldo2 = totalsaldo + Convert.ToDecimal(HonorariosSaldo.Value) + Convert.ToDecimal(CostasSaldo.Value) + Convert.ToDecimal(DesistimientoSaldo.Value);
            TotalSaldo3.Value = totalsaldo2.ToString();

            totaldescuento2 = totaldescuento + Convert.ToDecimal(HonorariosDescuento.Value) + Convert.ToDecimal(CostasDescuento.Value) + Convert.ToDecimal(DesistimientoDescuento.Value);
            TotalDescuento3.Value = totaldescuento2.ToString();
        }
    }
}