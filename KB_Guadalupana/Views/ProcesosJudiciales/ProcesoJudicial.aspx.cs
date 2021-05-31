using System;
using KB_Guadalupana.Controllers;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class ProcesoJudicial : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        Conexion conexiongeneral = new Conexion();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombodocumento();
                llenarformulario();
                llenarcombotipocredito();
                credito.Visible = false;
                tarjeta.Visible = false;
                OtroDocumento.Visible = false;
            }
        }


        protected void OnSelectedIndexChangedDocumento(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentos.SelectedRow.FindControl("lblid") as Label).Text);
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

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PTipoDocumento.SelectedValue == "0")
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
                            documento = "Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName));
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
                IntegracionC.Focus();
            }
            catch
            {

            }
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento IN (1,2,3,4,5,6,7,8,9,10,11,12,13)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    PTipoDocumento.DataSource = ds;
                    PTipoDocumento.DataTextField = "pj_nombretipodoc";
                    PTipoDocumento.DataValueField = "idpj_tipodocumento";
                    PTipoDocumento.DataBind();
                    PTipoDocumento.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '"+ numcredito + "'";
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
            //string numcredito = Session["credito"] as string;
            //string[] campos = sn.obtenerinforcredito(numcredito);

            string numcredito = Session["credito"] as string;
            string var1 = WS.buscarcredito(numcredito);
            char delimitador = '|';
            string[] campos = var1.Split(delimitador);
            string sig = sn.siguiente("pj_tipocredito", "idpj_tipocredito");
            string sig2 = sn.siguiente("pj_tipotarjeta", "idpj_tipotarjeta");

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
                    NumIncidente.Value = sig;
                    NumeroIncidente.Value = sig;
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
                    Mora.Value = campos[14];
                    DescripcionDoc.Value = campos[24];
                    Saldo1.Value = campos[15];

                    if(campos[25] == "VACIO")
                    {
                        Oficial1.Visible = false;
                        NombreOficial.Visible = false;
                    }
                    if(campos[26] == "VACIO")
                    {
                        Oficial2.Visible = false;
                        NombreOficial2.Visible = false;
                    }
                    if(campos[27] == "VACIO")
                    {
                        Oficial3.Visible = false;
                        NombreOficial3.Visible = false;
                    }

                    NombreOficial.Value = campos[25];
                    NombreOficial2.Value = campos[26];
                    NombreOficial3.Value = campos[27];

                    if(campos[8] == "            .00")
                    {
                        SaldoActual.Value = "Q 0.00";
                    }
                    else
                    {
                        SaldoActual.Value = "Q " + campos[8];
                    }
                    //Gastos1.Value = campos[31];
                    //GastosJudiciales.Value = campos[32];
                    //OtrosGastos.Value = campos[33];
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
            //    Interes1.Value = campos[26];
            //    Mora.Value = campos[27];
            //    DescripcionDoc.Value = campos[28];
            //    Saldo1.Value = campos[30];
            //    Gastos1.Value = campos[31];
            //    GastosJudiciales.Value = campos[32];
            //    OtrosGastos.Value = campos[33];
            //    //Total1.Value = campos[34];
            //}
        }

        public void llenarcombotipocredito()
        {
            TipoCredito.Items.Insert(0, new ListItem("[Tipo de demanda]", "0"));
            TipoCredito.Items.Insert(1, new ListItem("Crédito", "1"));
            TipoCredito.Items.Insert(2, new ListItem("Tarjeta", "2"));
        }

        protected void TipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sig = sn.siguiente("pj_tipocredito", "idpj_tipocredito");
            string sig2 = sn.siguiente("pj_tipotarjeta", "idpj_tipotarjeta");
            if (TipoCredito.SelectedValue == "1")
            {
                credito.Visible = true;
                tarjeta.Visible = false;
                NumIncidente.Value = sig;
            }
            else if(TipoCredito.SelectedValue == "2")
            {
                tarjeta.Visible = true;
                credito.Visible = true;
                NumIncidente.Value = sig2;
            }

            PCBoton.Focus();
        }

        protected void PCBoton_Click(object sender, EventArgs e)
        {
            //gridviewprospectos.DataSource = WS.buscarresponsables("9900642409");
            //gridviewprospectos.DataBind();

            //gridview2.DataSource = WS.buscarcreditosasociados("SAGASTUME MONZON,EDGAR ERNESTO");
            //gridview2.DataBind();

            string numcredito = Session["credito"] as string;

            string infornet = sn.tipodocumentoInfornet(numcredito);
            string recibo = sn.tipodocumentoRecibo(numcredito);
            string dpi = sn.tipodocumentoDPI(numcredito);
            string cartaingreso = sn.tipodocumentoCartaIngreso(numcredito);
            string contratos = sn.tipodocumentoContratos(numcredito);
            string solicitudcredito = sn.tipodocumentoSolicitudCredito(numcredito);
            string consultaiggs = sn.tipodocumentoConsultaIggs(numcredito);
            string consultadicabi = sn.tipodocumentoConsultaDicabi(numcredito);
            string bitacora = sn.tipodocumentoBitacora(numcredito);
            string estadocuenta = sn.tipodocumentoEstadoCuenta(numcredito);
            string avaluo = sn.tipodocumentoAvaluo(numcredito);
            string transunion = sn.tipodocumentoTransunion(numcredito);

            if(infornet == "" || recibo == "" || dpi == "" || cartaingreso == "" || contratos == "" || solicitudcredito == "" || consultaiggs == "" || consultadicabi == "" || bitacora == "" || estadocuenta == "" || avaluo == "" || transunion == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los documentos');", true);
            }
            else if (TipoCredito.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete tipo de crédito');", true);
            }
            else
            {
                string[] fechayhora = sn.fechayhora();
                string[] fecha = fechayhora[0].Split(' ');
                string año = fecha[0];
                string mes = fecha[1];
                string dia = fecha[2];

                string hora = fechayhora[1];
                string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                if (TipoCredito.SelectedValue == "1")
                {
                    decimal total;
                    total = Convert.ToDecimal(Saldo1.Value) + Convert.ToDecimal(Interes1.Value) + Convert.ToDecimal(Mora.Value) + Convert.ToDecimal(Gastos1.Value) + Convert.ToDecimal(GastosJudiciales.Value) + Convert.ToDecimal(OtrosGastos.Value);

                    string sig = sn.siguienteCredito("pj_tipocredito", "idpj_tipocredito");
                    string id = sig + CodigoCliente.Value;
                    sn.guardartipocredito(id, Gastos1.Value, GastosJudiciales.Value, OtrosGastos.Value, string.Format("{0:#,0.00}", total), Comentario.Value, numcredito, fechahoraactual, FechaEstadoCuenta.Value, Observaciones.Value);
                    NumIncidente.Value = sig;

                    string usuario = Session["sesion_usuario"] as string;
                    string idusuario = sn.obteneridusuario(usuario);

                    string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                    sn.guardaretapa(sig2, "1", numcredito, sn.datetime(), "Enviado", idusuario, "28", NombreCliente.Value, sig);

                    
                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, sig, numcredito, NombreCliente.Value, "Enviado", "26", "28", fechahoraactual, fechahoraactual, Observaciones.Value);

                    String script = "alert('Se ha guardado exitosamente'); window.location.href= 'AsignarProceso.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else if (TipoCredito.SelectedValue == "2")
                {
                    if (NumTarjeta.Value == "" || NumCuenta.Value == "" || CIF.Value == "" || PrimerNombre.Value == "" || SegundoNombre.Value == "" || PrimerApellido.Value == "" || SegundoApellido.Value == "" || Limite.Value == "" || Saldo.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
                    }
                    else
                    {
                        decimal total;
                        total = Convert.ToDecimal(Saldo1.Value) + Convert.ToDecimal(Interes1.Value) + Convert.ToDecimal(Mora.Value) + Convert.ToDecimal(Gastos1.Value) + Convert.ToDecimal(GastosJudiciales.Value) + Convert.ToDecimal(OtrosGastos.Value);
                        string sig = sn.siguienteTarjeta("pj_tipotarjeta", "idpj_tipotarjeta");
                        string id = sig + CodigoCliente.Value;
                        sn.guardartipotarjeta(id, NumTarjeta.Value, NumCuenta.Value, CIF.Value, PrimerNombre.Value, SegundoNombre.Value, OtroNombre.Value, ApellidoCasada.Value, PrimerApellido.Value, SegundoApellido.Value, Limite.Value, Saldo.Value, numcredito, Gastos1.Value, GastosJudiciales.Value, OtrosGastos.Value, Comentario.Value, string.Format("{0:#,0.00}", total), fechahoraactual, FechaEstadoCuenta.Value, Observaciones.Value);
                        NumIncidente.Value = sig;

                        string usuario = Session["sesion_usuario"] as string;
                        string idusuario = sn.obteneridusuario(usuario);

                        string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                        sn.guardaretapa(sig2, "1", numcredito, sn.datetime(), "Enviado", idusuario, "26", NombreCliente.Value, sig);

                        string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                        sn.insertarbitacora(sig3, sig, numcredito, NombreCliente.Value, "Enviado", "26", "28", fechahoraactual, fechahoraactual, Observaciones.Value);

                        String script = "alert('Se ha guardado exitosamente'); window.location.href= 'AsignarProceso.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                }

              
            }
        }

        protected void PTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PTipoDocumento.SelectedValue == "13")
            {
                OtroDocumento.Visible = true;
            }
            else
            {
                OtroDocumento.Visible = false;
            }
        }

        //protected void OnSelectedIndexChangedprospectos(object sender, EventArgs e)
        //{
        //    string codigo;
        //    GridViewRow row = gridviewprospectos.SelectedRow;
        //    codigo = (gridviewprospectos.SelectedRow.FindControl("lblcodprospeto") as Label).Text;
        //    //mostrar los otros datos
        //}


    }
}