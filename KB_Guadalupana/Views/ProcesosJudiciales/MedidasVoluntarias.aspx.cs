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
    public partial class MedidasVoluntarias : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["credito"] = "0600107239";
                InfoMonto.Visible = false;
                //Otro.Visible = false;
                llenarcombodocumentomemorial();
                llenarcombodocumentoresolucion();
                //llenarcombodocumentofactura();
                //llenarcombomotivo();
                llenarformulario();
                llenarmedidas();
                llenarcomentarios();
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
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'PendienteDiligenciamiento.aspx';";
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

        public void llenarcombodocumentomemorial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 23";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoDocumentoMemorial.DataSource = ds;
                    TipoDocumentoMemorial.DataTextField = "pj_nombretipodoc";
                    TipoDocumentoMemorial.DataValueField = "idpj_tipodocumento";
                    TipoDocumentoMemorial.DataBind();
                    TipoDocumentoMemorial.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        //protected void AgregarFactura_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (FileUpload6.HasFile)
        //        {
        //            string ext = System.IO.Path.GetExtension(FileUpload6.FileName);
        //            ext = ext.ToLower();

        //            if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
        //            {
        //                string numcredito = Session["credito"] as string;
        //                string siguiente = sn.siguiente("pj_documento", "idpj_documento");
        //                documento = "Subidos/Diligenciamiento/" + siguiente + '-' + FileUpload6.FileName;
        //                string nombredoc = siguiente + '-' + FileUpload6.FileName;
        //                sn.guardardocumentoexp(siguiente, TDocumentoFactura.SelectedValue, documento, nombredoc, numcredito);
        //                FileUpload6.SaveAs(Server.MapPath("Subidos/Diligenciamiento/" + siguiente + '-' + FileUpload6.FileName));
        //                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
        //                llenargridviewfactura();
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    gridViewFactura.Focus();
        //}

        protected void agregar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoDocumentoResolucion.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload3.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload3.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Transaccion/" + siguiente + '-' + FileUpload3.FileName;
                            string nombredoc = siguiente + '-' + FileUpload3.FileName;
                            sn.guardardocumentoexp(siguiente, TipoDocumentoResolucion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload3.SaveAs(Server.MapPath("Subidos/Transaccion/" + siguiente + '-' + FileUpload3.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentoresolucion();
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
                FechaResolucion.Focus();
            }
            catch
            {

            }
        }

        protected void agregar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoDocumentoMemorial.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload2.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload2.FileName;
                            string nombredoc = siguiente + '-' + FileUpload2.FileName;
                            sn.guardardocumentoexp(siguiente, TipoDocumentoMemorial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload2.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload2.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentomemorial();
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
                TipoDocumentoResolucion.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewdocumentomemorial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 23";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDocumentoMemorial.DataSource = dt;
                    gridViewDocumentoMemorial.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedDocumentoMemorial(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentoMemorial.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombodocumentoresolucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 24";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoDocumentoResolucion.DataSource = ds;
                    TipoDocumentoResolucion.DataTextField = "pj_nombretipodoc";
                    TipoDocumentoResolucion.DataValueField = "idpj_tipodocumento";
                    TipoDocumentoResolucion.DataBind();
                    TipoDocumentoResolucion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenargridviewdocumentoresolucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 24";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDocumentoResolucion.DataSource = dt;
                    gridViewDocumentoResolucion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedDocumentoResolucion(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentoResolucion.SelectedRow.FindControl("lblid") as Label).Text);
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

        //public void llenarcombodocumentofactura()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 31";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds);
        //            TDocumentoFactura.DataSource = ds;
        //            TDocumentoFactura.DataTextField = "pj_nombretipodoc";
        //            TDocumentoFactura.DataValueField = "idpj_tipodocumento";
        //            TDocumentoFactura.DataBind();
        //            TDocumentoFactura.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //public void llenargridviewfactura()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            string numcredito = Session["credito"] as string;
        //            sqlCon.Open();
        //            string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 31";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataTable dt = new DataTable();
        //            myCommand.Fill(dt);
        //            gridViewFactura.DataSource = dt;
        //            gridViewFactura.DataBind();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void OnSelectedIndexChangedFactura(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString((gridViewFactura.SelectedRow.FindControl("lblid") as Label).Text);
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

        //public void llenarcombomotivo()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string query = "SELECT * FROM pj_motivopago";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds);
        //            MotivoPago.DataSource = ds;
        //            MotivoPago.DataTextField = "pj_nombremotivo";
        //            MotivoPago.DataValueField = "idpj_motivopago";
        //            MotivoPago.DataBind();
        //            MotivoPago.Items.Insert(0, new ListItem("[Motivo de pago]", "0"));
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void MotivoPago_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    if (MotivoPago.SelectedValue == "9")
        //    {
        //        Otro.Visible = true;
        //        Guardar.Focus();
        //    }
        //    else
        //    {
        //        Otro.Visible = false;
        //        Guardar.Focus();
        //    }
        //}

        public void llenarmedidas()
        {
            string numcredito = Session["credito"] as string;
            string[] medidas = sn.medidasautorizadas(numcredito, "4");

            for (int i = 0; i < medidas.Length; i++)
            {
                if (medidas[i] == "2")
                {
                    InfoMonto.Visible = true;
                }
                else
                {
                    InfoMonto.Visible = false;
                }
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string estado = Session["estado"] as string;
            string esvoluntaria = "0";
            string fecha = sn.datetime();
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string memorial = sn.tipodocumentoMemorialTransaccion(numcredito);
            string resolucion = sn.tipodocumentoResolucionTransaccion(numcredito);
            string facturacion = sn.tipodocumentoFacturacionMemorial(numcredito);

            if(memorial == "" || resolucion == "" || FechaResolucion.Value == "" || FechaNotificacion.Value == "" || Observaciones.Value == "" || facturacion == "" || FechaPresentacion.Value == "")
            {
                String script = "alert('Complete los datos')";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                if(estado == "Transaccion voluntaria")
                {
                    esvoluntaria = "1";
                }
                else
                {
                    esvoluntaria = "2";
                }

                //if (MotivoPago.SelectedValue != "9")
                //{
                //    Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                //}

                string sig2 = sn.siguiente("pj_voluntaria", "idpj_voluntaria");
                sn.insertarvoluntaria(sig2, esvoluntaria, FechaPresentacion.Value, MontoTransar.Value, FechaResolucion.Value, FechaNotificacion.Value, Observaciones.Value, numcredito, idusuario, fecha);

                sn.cambiarestadovoluntaria(numcredito, "9");

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
                sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "26", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "26", fechahoraactual, fechacreacion2, Observaciones.Value);


                String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteDiligenciamiento.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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
    }
}