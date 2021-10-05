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
using System.IO;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class EditarCreditos : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        string documento = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewdocumentos();
                llenarformulario();
                llenarcombodocumento();
                llenarcomentarios();
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "'";
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
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'AsignarProceso.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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
                    //Interes1.Value = campos[16];
                    //Mora.Value = campos[14];
                    DescripcionDoc.Value = campos[24];
                    //Saldo1.Value = campos[15];
                    //Gastos1.Value = campos[31];
                    //GastosJudiciales.Value = campos[32];
                    //OtrosGastos.Value = campos[33];


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
                        Saldo1.Value = "0.00";
                    }
                    else
                    {
                        SaldoActual.Value = "Q " + campos[8];
                        Saldo1.Value = campos[8];
                    }
                }

            }

            string[] campos2 = sn.obtenertipocredito(numcredito);
            string idcredito = campos2[0];
            if (idcredito == null)
            {
                Session["TipoCredito"] = "tarjeta";
                tarjeta.Visible = true;
                credito.Visible = false;

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
                    string fechaestado = campos3[19];
                    string[] separarfechahora = fechaestado.Split(' ');
                    string[] fechaestado2 = separarfechahora[0].Split('/');
                    Incendio.Value = campos3[20];
                    Interes1.Value = campos3[21];
                    Mora.Value = campos3[22];

                    if (fechaestado2[0].Length == 1)
                    {
                        FechaEstadoCuenta.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + "0" + fechaestado2[0];
                    }
                    else
                    {
                        FechaEstadoCuenta.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + fechaestado2[0];
                    }
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
                    Total1.InnerHtml = "Q " + campos2[4];
                    Comentario.Value = campos2[5];
                    string fechaestado = campos2[8];
                    string[] separarfechahora = fechaestado.Split(' ');
                    string[] fechaestado2 = separarfechahora[0].Split('/');
                    Incendio.Value = campos2[9];
                    Interes1.Value = campos2[10];
                    Mora.Value = campos2[11];

                    if (fechaestado2[0].Length == 1)
                    {
                        FechaEstadoCuenta.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + "0" + fechaestado2[0];
                    }
                    else
                    {
                        FechaEstadoCuenta.Value = fechaestado2[2] + '-' + fechaestado2[1] + '-' + fechaestado2[0];
                    }

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

                string nombrearchivo = sn.nombrearchivo(id);
                string[] extension = nombrearchivo.Split('.');
                int tamaño = extension.Length;
                string tipo = extension[tamaño - 1];

                string FilePath = Server.MapPath(documentoselec);
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    if(tipo.ToLower() == "pdf")
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if(tipo.ToLower() == "tif" || tipo.ToLower() == "tiff")
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

        protected void gridViewDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    string id = (gridViewDocumentos.DataKeys[e.RowIndex].Value.ToString());
                    //string id = Convert.ToString((gridViewDocumentos.SelectedRow.FindControl("lblid") as Label).Text);
                    string documentoselec;
                    documentoselec = sn.obtenernombredocumento(id);
                    File.Delete(Server.MapPath("Subidos/DocumentosExpediente/" + documentoselec));

                    sqlCon.Open();
                    string query = "DELETE FROM pj_documento WHERE idpj_documento = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gridViewDocumentos.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();


                    llenargridviewdocumentos();

                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Documento borrado');", true);
                }
                IntegracionC.Focus();
            }
            catch
            {

            }
        }

        protected void PCBoton_Click(object sender, EventArgs e)
        {
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
            string transunion = sn.tipodocumentoTransunion(numcredito);

            if (infornet == "" || recibo == "" || dpi == "" || cartaingreso == "" || contratos == "" || solicitudcredito == "" || consultaiggs == "" || consultadicabi == "" || bitacora == "" || estadocuenta == "" || transunion == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los documentos');", true);
            }
            else
            {

                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);


                string tipocredito = Session["TipoCredito"] as string;
                string fecha;

                decimal total;
                total = Convert.ToDecimal(Saldo1.Value) + Convert.ToDecimal(Interes1.Value) + Convert.ToDecimal(Mora.Value) + Convert.ToDecimal(Gastos1.Value) + Convert.ToDecimal(GastosJudiciales.Value) + Convert.ToDecimal(OtrosGastos.Value) + Convert.ToDecimal(Incendio.Value);

                if (tipocredito == "tarjeta")
                {
                    fecha = sn.fechacreaciontarjeta(numcredito);
                    sn.editartarjeta(NumIncidente.Value, NumTarjeta.Value, NumCuenta.Value, CIF.Value, PrimerNombre.Value, SegundoNombre.Value, OtroNombre.Value, ApellidoCasada.Value, PrimerApellido.Value, SegundoApellido.Value, Limite.Value, Saldo.Value, NumPrestamo.Value, Gastos1.Value, GastosJudiciales.Value, OtrosGastos.Value, Comentario.Value, string.Format("{0:#,0.00}", total), FechaEstadoCuenta.Value, Incendio.Value, Interes1.Value, Mora.Value);
                }
                else
                {
                    fecha = sn.fechacreacioncredito(numcredito);
                    sn.editarcredito(NumIncidente.Value, Gastos1.Value, GastosJudiciales.Value, OtrosGastos.Value, string.Format("{0:#,0.00}", total), Comentario.Value, NumPrestamo.Value, FechaEstadoCuenta.Value, Incendio.Value, Interes1.Value, Mora.Value);
                }

                String script = "alert('Se realizaron los cambios exitosamente'); window.location.href= 'AsignarProceso.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }

        }

        public void llenarcomentarios()
        {
            string numcredito = Session["credito"] as string;
            string[] comentarios = sn.traerComentarios(numcredito);

            for (int i = 0; i < comentarios.Length; i++)
            {
                if (comentarios.Length == 1)
                {
                    Comentario1.Visible = true;
                    Comentario1.Value = comentarios[0];
                }
                else if (comentarios.Length == 2)
                {
                    Comentario1.Value = comentarios[0];
                    Comentario2.Value = comentarios[1];
                    Comentario1.Visible = true;
                    Comentario2.Visible = true;
                }
                else
                {
                    Comentario1.Value = comentarios[0];
                    Comentario2.Value = comentarios[1];
                    Comentario3.Value = comentarios[2];
                    Comentario1.Visible = true;
                    Comentario2.Visible = true;
                    Comentario3.Visible = true;
                }
            }
        }
    }
}