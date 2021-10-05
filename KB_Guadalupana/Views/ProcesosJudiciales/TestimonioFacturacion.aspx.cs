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

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class TestimonioFacturacion : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombotestimonio();
                llenarformulario();
                llenarcombofactura();
                Otro.Visible = false;
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
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'PendienteNotificacionApremio.aspx';";
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
                }
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumIncidente.Value = campos2[0];
                    NumeroIncidente.Value = campos2[0];
                }
            }
        }

        public void llenarcombotestimonio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 46";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Testimonio.DataSource = ds;
                    Testimonio.DataTextField = "pj_nombretipodoc";
                    Testimonio.DataValueField = "idpj_tipodocumento";
                    Testimonio.DataBind();
                    Testimonio.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar10_Click(object sender, EventArgs e)
        {
            try
            {
                if (Testimonio.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload10.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload10.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload10.FileName;
                            string nombredoc = siguiente + '-' + FileUpload10.FileName;
                            sn.guardardocumentoexp(siguiente, Testimonio.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload10.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload10.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewtestimonio();
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
                gridViewTestimonio.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewtestimonio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 46";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewTestimonio.DataSource = dt;
                    gridViewTestimonio.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedTestimonio(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewTestimonio.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombofactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 62";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TDocumentoFactura.DataSource = ds;
                    TDocumentoFactura.DataTextField = "pj_nombretipodoc";
                    TDocumentoFactura.DataValueField = "idpj_tipodocumento";
                    TDocumentoFactura.DataBind();
                    TDocumentoFactura.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void AgregarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (TDocumentoFactura.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload11.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload11.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Factura/" + siguiente + '-' + FileUpload11.FileName;
                            string nombredoc = siguiente + '-' + FileUpload11.FileName;
                            sn.guardardocumentoexp(siguiente, TDocumentoFactura.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload11.SaveAs(Server.MapPath("Subidos/Factura/" + siguiente + '-' + FileUpload11.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewfactura();
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
                gridViewFactura.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewfactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 62";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewFactura.DataSource = dt;
                    gridViewFactura.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedFactura(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewFactura.SelectedRow.FindControl("lblid") as Label).Text);
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

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string numcredito = Session["credito"] as string;

            sn.cambiarestado(numcredito, "39");
            string sig3 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
            sn.guardaretapa(sig3, "27", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);

            if (MotivoPago.SelectedValue != "9")
            {
                Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
            }

            string sig4 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
            sn.guardarfacturaabogado(sig4, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion2.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, ObservacionesCredito.Value, "Iniciado", "27");

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
            string año1 = fecha2[0];
            string mes2 = fecha2[1];
            string dia3 = fecha2[2];

            string hora = fechayhora[1];
            string fechahoraactual = año1 + '-' + mes2 + '-' + dia3 + ' ' + hora;

            string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig5, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);

            string sig6 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig6, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);


            String script = "alert('Se guardó exitosamente'); window.location.href= 'PendienteNotificacionApremio.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void MotivoPago_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(MotivoPago.SelectedValue == "9")
            {
                Otro.Visible = true;
            }
            else
            {
                Otro.Visible = false;
            }
        }
    }
}