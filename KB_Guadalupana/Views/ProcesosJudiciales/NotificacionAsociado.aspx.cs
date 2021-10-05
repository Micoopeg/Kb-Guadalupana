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
    public partial class NotificacionAsociado : System.Web.UI.Page
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
                NoNotificacion.Visible = false;
                SiNotificacion.Visible = false;
                Positiva.Visible = false;
                Negativa.Visible = false;
                Facturacion.Visible = false;
                Otro.Visible = false;
                Sinotificacion2.Visible = false;
                llenarformulario();
                llenarcombonotificacion();
                llenarcombodocumento();
                llenarcomboresolucion();
                llenarcombosegundanotificacion();
                llenarcomboactitud();
                llenarcombosentencia();
                llenarcomentarios();
                llenarcombolugar();
                llenarcombointerexcepciones();
                llenarcombodocumentosentencia();
                llenarcomboexcepciones();
                llenarcombodocumentofactura();
                llenarcombomotivo();
                llenarcomboresolucionexcepciones();
                llenarcomboactanotarial();
                llenarcombomemorialacta();
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
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'PendienteNotificacion.aspx';";
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

        public void llenarcomentarios()
        {
            DataSet comentarios = new DataSet();
            string numcredito = Session["credito"] as string;
            comentarios = sn.consultarComentarios(numcredito);
            Repeater1.DataSource = comentarios;
            Repeater1.DataBind();
        }

        public void llenarcombonotificacion()
        {
            Notificacion.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Notificacion.Items.Insert(1, new ListItem("Si", "1"));
            Notificacion.Items.Insert(2, new ListItem("No", "2"));
        }

        protected void Notificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Notificacion.SelectedValue == "1")
            {
                SiNotificacion.Visible = true;
                NoNotificacion.Visible = false;
                Actitud.Focus();
            }
            else
            {
                NoNotificacion.Visible = true;
                SiNotificacion.Visible = false;
                FechaMemorial.Focus();
            }
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 34";
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
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
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
                gridViewDocumentos.Focus();
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 34";
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

        public void llenarcomboresolucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 35";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    DocumentoResolucion.DataSource = ds;
                    DocumentoResolucion.DataTextField = "pj_nombretipodoc";
                    DocumentoResolucion.DataValueField = "idpj_tipodocumento";
                    DocumentoResolucion.DataBind();
                    DocumentoResolucion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoResolucion.SelectedValue == "0")
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
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload2.FileName;
                            string nombredoc = siguiente + '-' + FileUpload2.FileName;
                            sn.guardardocumentoexp(siguiente, DocumentoResolucion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload2.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload2.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewResolucion();
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
                gridViewResolucion.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewResolucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 35";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewResolucion.DataSource = dt;
                    gridViewResolucion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedResolucion(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewResolucion.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombosegundanotificacion()
        {
            SegundaNotificacion.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            SegundaNotificacion.Items.Insert(1, new ListItem("Si", "1"));
            SegundaNotificacion.Items.Insert(2, new ListItem("No", "2"));
        }

        protected void SegundaNotificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SegundaNotificacion.SelectedValue == "1")
            {
                SiNotificacion.Visible = true;
                FechaNotificacion2.Visible = false;
                Sinotificacion2.Visible = true;
                Actitud.Focus();
            }
            else
            {
                SiNotificacion.Visible = false;
                Sinotificacion2.Visible = false;
                SegundaNotificacion.Focus();
            }
        }

        public void llenarcomboactitud()
        {
            Actitud.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Actitud.Items.Insert(1, new ListItem("Positiva", "1"));
            Actitud.Items.Insert(2, new ListItem("Negativa", "2"));
        }

        protected void Actitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Actitud.SelectedValue == "1")
            {
                Positiva.Visible = true;
                Facturacion.Visible = true;
                Negativa.Visible = false;
                Sentencia.Focus();
            }
            else
            {
                Negativa.Visible = true;
                Facturacion.Visible = true;
                Positiva.Visible = false;
                Excepciones.Focus();
            }
        }

        public void llenarcombosentencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 36";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Sentencia.DataSource = ds;
                    Sentencia.DataTextField = "pj_nombretipodoc";
                    Sentencia.DataValueField = "idpj_tipodocumento";
                    Sentencia.DataBind();
                    Sentencia.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sentencia.SelectedValue == "0")
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
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload3.FileName;
                            string nombredoc = siguiente + '-' + FileUpload3.FileName;
                            sn.guardardocumentoexp(siguiente, Sentencia.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload3.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload3.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewSentencia();
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
                gridViewSentencia.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewSentencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 36";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewSentencia.DataSource = dt;
                    gridViewSentencia.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedSentencia(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewSentencia.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombolugar()
        {
            Lugar.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Lugar.Items.Insert(1, new ListItem("A lugar", "1"));
            Lugar.Items.Insert(2, new ListItem("No lugar", "2"));

            Lugar2.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Lugar2.Items.Insert(1, new ListItem("A lugar", "1"));
            Lugar2.Items.Insert(2, new ListItem("No lugar", "2"));
        }

        public void llenarcombointerexcepciones()
        {
            InterExcepciones.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            InterExcepciones.Items.Insert(1, new ListItem("Si", "1"));
            InterExcepciones.Items.Insert(2, new ListItem("No", "2"));
        }

        public void llenarcomboexcepciones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipoexcepciones";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Excepciones.DataSource = ds;
                    Excepciones.DataTextField = "pj_excenombre";
                    Excepciones.DataValueField = "idpj_tipoexcepciones";
                    Excepciones.DataBind();
                    Excepciones.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombodocumentosentencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 36";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    DocumentoSentencia.DataSource = ds;
                    DocumentoSentencia.DataTextField = "pj_nombretipodoc";
                    DocumentoSentencia.DataValueField = "idpj_tipodocumento";
                    DocumentoSentencia.DataBind();
                    DocumentoSentencia.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar4_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoSentencia.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload4.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload4.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload4.FileName;
                            string nombredoc = siguiente + '-' + FileUpload4.FileName;
                            sn.guardardocumentoexp(siguiente, DocumentoSentencia.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload4.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload4.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewSentencia2();
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
                gridViewSentencia.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewSentencia2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 36";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewSentencia2.DataSource = dt;
                    gridViewSentencia2.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedSentencia2(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewSentencia2.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombodocumentofactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 37";
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
                if (FileUpload6.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload6.FileName);
                    ext = ext.ToLower();

                    if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                    {
                        string numcredito = Session["credito"] as string;
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/Factura/" + siguiente + '-' + FileUpload6.FileName;
                        string nombredoc = siguiente + '-' + FileUpload6.FileName;
                        sn.guardardocumentoexp(siguiente, TDocumentoFactura.SelectedValue, documento, nombredoc, numcredito);
                        FileUpload6.SaveAs(Server.MapPath("Subidos/Factura/" + siguiente + '-' + FileUpload6.FileName));
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
            catch
            {

            }
            gridViewFactura.Focus();
        }

        public void llenargridviewfactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 37";
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

        public void llenarcombomotivo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_motivopago";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    MotivoPago.DataSource = ds;
                    MotivoPago.DataTextField = "pj_nombremotivo";
                    MotivoPago.DataValueField = "idpj_motivopago";
                    MotivoPago.DataBind();
                    MotivoPago.Items.Insert(0, new ListItem("[Motivo de pago]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void MotivoPago_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (MotivoPago.SelectedValue == "9")
            {
                Otro.Visible = true;
                Guardar.Focus();
            }
            else
            {
                Otro.Visible = false;
                Guardar.Focus();
            }
        }

        public void llenarcomboresolucionexcepciones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 48";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ResolucionExcepciones.DataSource = ds;
                    ResolucionExcepciones.DataTextField = "pj_nombretipodoc";
                    ResolucionExcepciones.DataValueField = "idpj_tipodocumento";
                    ResolucionExcepciones.DataBind();
                    ResolucionExcepciones.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string numcredito = Session["credito"] as string;
            if (Notificacion.SelectedValue == "1")
            {
                string sig6 = sn.siguiente("pj_sinotificacion", "idpj_sinotificacion");
                sn.insertarsinotificacion(sig6, FechaIntento1.Value, FechaIntento2.Value, FechaIntento3.Value, FechaNotificacionDemandado.Value, Actitud.SelectedItem.Text, numcredito, idusuario, sn.datetime());

                if (Actitud.SelectedValue == "1")
                {
                    string sig = sn.siguiente("pj_actitudpositiva", "idpj_actitudpositiva");
                    sn.insertaractitudpositiva(sig, FechaSentencia.Value, FechaNotificacionSentencia.Value, Lugar.SelectedItem.Text, Observaciones.Value, numcredito, idusuario, sn.datetime());

                    if (MotivoPago.SelectedValue != "9")
                    {
                        Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                    }

                    string sig7 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                    sn.guardarfacturaabogado(sig7, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, ObservacionesCredito.Value, "Iniciado", "16");

                    string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                    sn.guardaretapa(sig11, "16", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                    sn.cambiarestado(numcredito, "15");

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
                    sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);

                    String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteNotificacion.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    string sig2 = sn.siguiente("pj_actitudnegativa", "idpj_actitudnegativa");
                    sn.insertaractitudnegativa(sig2, InterExcepciones.SelectedValue, FechaExcepciones.Value, FechaApertura.Value, ObservacionesNegativa.Value, FechaVista.Value, FechaSentencia2.Value, FechaNotificacionSentencia2.Value, Lugar2.SelectedItem.Text, ObservacionesLugar.Value, numcredito, idusuario, sn.datetime());

                    string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                    sn.guardaretapa(sig11, "16", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                    sn.cambiarestado(numcredito, "15");

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
                    sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);

                    String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteNotificacion.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
            }
            else
            {
                if (SegundaNotificacion.SelectedValue == "1")
                {
                    string sig12 = sn.siguiente("pj_segundanotificacioneva", "idpj_segundanotificacioneva");
                    sn.insertarsinotificacion2(sig12, FechaNotificacionActa.Value, FechaMemorialActa.Value, numcredito, sn.datetime(), idusuario);

                    if (Actitud.SelectedValue == "1")
                    {
                        string sig = sn.siguiente("pj_actitudpositiva", "idpj_actitudpositiva");
                        sn.insertaractitudpositiva(sig, FechaSentencia.Value, FechaNotificacionSentencia.Value, Lugar.SelectedItem.Text, Observaciones.Value, numcredito, idusuario, sn.datetime());

                        string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                        sn.guardaretapa(sig11, "16", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                        sn.cambiarestado(numcredito, "15");

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
                        sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                        string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                        sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);

                        String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteNotificacion.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else
                    {
                        string sig2 = sn.siguiente("pj_actitudnegativa", "idpj_actitudnegativa");
                        sn.insertaractitudnegativa(sig2, InterExcepciones.SelectedValue, FechaExcepciones.Value, FechaApertura.Value, ObservacionesNegativa.Value, FechaVista.Value, FechaSentencia2.Value, FechaNotificacionSentencia2.Value, Lugar2.SelectedItem.Text, ObservacionesLugar.Value, numcredito, idusuario, sn.datetime());

                        string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                        sn.guardaretapa(sig11, "16", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                        sn.cambiarestado(numcredito, "15");

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
                        sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                        string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                        sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);

                        String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteNotificacion.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                }
                else
                {
                    string sig3 = sn.siguiente("pj_nonotificacion", "idpj_nonotificacion");
                    sn.insertarnonotificacion(sig3, FechaMemorial.Value, NotarioPropuesto.Value, ColegiadoPropuesto.Value, FechaResolucion.Value, FechaNotificacion.Value, idusuario, numcredito, sn.datetime(), SegundaNotificacion.SelectedItem.Text);

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
                    sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                    string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig4, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);

                    String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteNotificacion.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
            }
        }

        protected void agregar5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResolucionExcepciones.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload5.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload5.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload5.FileName;
                            string nombredoc = siguiente + '-' + FileUpload5.FileName;
                            sn.guardardocumentoexp(siguiente, ResolucionExcepciones.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload5.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload5.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewResolucionExcepciones();
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
                gridViewResolucionExcepciones.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewResolucionExcepciones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 48";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewResolucionExcepciones.DataSource = dt;
                    gridViewResolucionExcepciones.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedExcepciones(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewResolucionExcepciones.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcomboactanotarial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 49";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ActaNotificacion.DataSource = ds;
                    ActaNotificacion.DataTextField = "pj_nombretipodoc";
                    ActaNotificacion.DataValueField = "idpj_tipodocumento";
                    ActaNotificacion.DataBind();
                    ActaNotificacion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar12_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActaNotificacion.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload12.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload12.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload12.FileName;
                            string nombredoc = siguiente + '-' + FileUpload12.FileName;
                            sn.guardardocumentoexp(siguiente, ActaNotificacion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload12.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload12.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewacta();
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
                gridViewNotarial.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewacta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 49";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewNotarial.DataSource = dt;
                    gridViewNotarial.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedNotarial(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewNotarial.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombomemorialacta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 54";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    MemorialActaNotarial.DataSource = ds;
                    MemorialActaNotarial.DataTextField = "pj_nombretipodoc";
                    MemorialActaNotarial.DataValueField = "idpj_tipodocumento";
                    MemorialActaNotarial.DataBind();
                    MemorialActaNotarial.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar7_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemorialActaNotarial.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload7.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload7.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload7.FileName;
                            string nombredoc = siguiente + '-' + FileUpload7.FileName;
                            sn.guardardocumentoexp(siguiente, MemorialActaNotarial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload7.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload7.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewmemorialacta();
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
                gridViewNotarial.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewmemorialacta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 54";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewMemorialActa.DataSource = dt;
                    gridViewMemorialActa.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedMemorialActa(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewMemorialActa.SelectedRow.FindControl("lblid") as Label).Text);
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

        protected void agregar8_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string sig = sn.siguiente("pj_excepciones", "idpj_excepciones");
            string sig2 = sn.siguiente("pj_actitudnegativa", "idpj_actitudnegativa");
            sn.insertarexcepciones(sig, Excepciones.SelectedValue, TipoExcepcion.Value, Observaciones2.Value, sig2, numcredito, sn.datetime(), idusuario);

            llenargridviewexcepciones();
            ResolucionExcepciones.Focus();

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se guardó exitosamente');", true);
        }

        public void llenargridviewexcepciones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpj_excepciones AS Codigo, B.pj_excenombre AS TipoExcepciones, A.pj_descripcion AS Descripcion, pj_observaciones AS Observaciones FROM pj_excepciones AS A INNER JOIN pj_tipoexcepciones AS B ON B.idpj_tipoexcepciones = A.pj_tipoexcepciones WHERE A.pj_numcredito = '" + numcredito+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewTipoExcepcion.DataSource = dt;
                    gridViewTipoExcepcion.DataBind();
                }
                catch
                {

                }
            }
        }
    }
}