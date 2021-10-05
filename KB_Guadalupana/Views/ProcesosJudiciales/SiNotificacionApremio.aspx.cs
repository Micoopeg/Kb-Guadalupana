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
    public partial class SiNotificacionApremio : System.Web.UI.Page
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
                //Monto.Visible = true;
                actitudNegativa.Visible = false;
                llenarformulario();
                llenarcomentarios();
                llenarcombopagoedictos();
                llenarcomboedictos();
                llenarcomboactanotarial();
                llenarcombomemorialacta();
                llenarcomboresolucionacta();
                llenarcomboremate();
                llenarcomboaudenciaremate();
                llenarcomboproyectoloquidacion();
                llenarcomboresolucionliquidacion();
                llenarcombormemorialnotario();
                llenarcomboresolucionnotario();
                llenarcombotestimonio();
                llenarcombofactura();
                llenarcomboadjudicado();
                llenarcomboactitud();
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

        public void llenarcomentarios()
        {
            DataSet comentarios = new DataSet();
            string numcredito = Session["credito"] as string;
            comentarios = sn.consultarComentarios(numcredito);
            Repeater1.DataSource = comentarios;
            Repeater1.DataBind();
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string numcredito = Session["credito"] as string;

            string edictos = sn.tipodocumentoEdictos(numcredito);
            string pagoedictos = sn.tipodocumentoPagoEdictos(numcredito);
            string actanotarial = sn.tipodocumentoactanotarial(numcredito);
            string memorialnotarial = sn.tipodocumentomemorialnotarial(numcredito);
            string memorialliquidacion = sn.tipodocumentomemorialliquidacion(numcredito);
            string resolucionliquidacion = sn.tipodocumentoresolucionliquidacion(numcredito);
            string memorialnotario = sn.tipodocumentonotariocartulante(numcredito);
            string resolucionnotario = sn.tipodocumentoresolucionnotario(numcredito);
            string testimonio = sn.tipodocumentotestimonio(numcredito);

            if (edictos == "" || FechaSolicitud.Value == "" || Monto.Value == "" || Descripcion.Value == "" || pagoedictos == "" || FechaPublicacion1.Value == "" || FechaPublicacion2.Value == "" || FechaPublicacion3.Value == "" || actanotarial == "" || FechaRemate.Value == "" || ObservacionesRemate.Value == "" || memorialnotarial == "" || DropAdjudicado.SelectedValue == "0" || memorialliquidacion == "" || FechaPresentacion.Value == "" || resolucionliquidacion == "" || FechaResolucion2.Value == "" || FechaNotificacionResolucion.Value == "" || memorialnotario == "" || FechaPresentacion2.Value == "" || NombreAbogado.Value == "" || NumColegiado.Value == "" || resolucionnotario == "" || FechaResolucion3.Value == "" || FechaNotificacion2.Value == "" || NumEscritura.Value == "" || FechaEscritura.Value == "" || Honorario.Value == "" || Impuesto.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
            }
            else
            {
                string sig = sn.siguiente("pj_sinotificacioneva", "idpj_sinotificacioneva");
                sn.insertarsinotificacioneva(sig, FechaSolicitud.Value, Monto.Value, Descripcion.Value, FechaPublicacion1.Value, FechaPublicacion2.Value, FechaPublicacion3.Value, numcredito, idusuario, sn.datetime());

                string sig2 = sn.siguiente("pj_audenciaremate", "idpj_audenciaremate");
                sn.insertaraudiencia(sig2, FechaActaNotarial.Value, FechaMemorialActa.Value, FechaResolucionActa.Value, FechaRemate.Value, ObservacionesRemate.Value, DropAdjudicado.SelectedItem.Text, Monto2.Value, FechaPresentacion.Value, FechaResolucion2.Value, FechaNotificacionResolucion.Value, FechaPresentacion2.Value, NombreAbogado.Value, NumColegiado.Value, FechaResolucion3.Value, FechaNotificacion2.Value, NumEscritura.Value, FechaEscritura.Value, Honorario.Value, Impuesto.Value, numcredito, idusuario, sn.datetime());

                sn.cambiarestado(numcredito, "20");
                string sig3 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig3, "25", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);

                if (MotivoPago.SelectedValue != "9")
                {
                    Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                }

                decimal total;
                total = Convert.ToDecimal(Honorario.Value) + Convert.ToDecimal(Impuesto.Value);

                string sig7 = sn.siguiente("pj_solicitudnotificacion", "idpj_solicitudnotificacion");
                sn.insertarsolicitudchequehonorario(sig7, total.ToString(), NombreAbogado.Value, numcredito, sn.datetime(), idusuario);

                //string sig4 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                //sn.guardarfacturaabogado(sig4, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, ObservacionesCredito.Value, "Iniciado", "21");

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
        }

        public void llenarcombopagoedictos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 41";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    DocumentoPagoEdictos.DataSource = ds;
                    DocumentoPagoEdictos.DataTextField = "pj_nombretipodoc";
                    DocumentoPagoEdictos.DataValueField = "idpj_tipodocumento";
                    DocumentoPagoEdictos.DataBind();
                    DocumentoPagoEdictos.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
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
                if (DocumentoPagoEdictos.SelectedValue == "0")
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
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload4.FileName;
                            string nombredoc = siguiente + '-' + FileUpload4.FileName;
                            sn.guardardocumentoexp(siguiente, DocumentoPagoEdictos.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload4.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload4.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewPagoEdictos();
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
                gridViewPagoEdictos.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewPagoEdictos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 41";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewPagoEdictos.DataSource = dt;
                    gridViewPagoEdictos.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedPagoEdictos(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewPagoEdictos.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenargridviewEdictos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 40";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewEdictos.DataSource = dt;
                    gridViewEdictos.DataBind();
                }
                catch
                {

                }
            }
        }

        public void llenarcomboedictos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 40";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    DocumentoEdictos.DataSource = ds;
                    DocumentoEdictos.DataTextField = "pj_nombretipodoc";
                    DocumentoEdictos.DataValueField = "idpj_tipodocumento";
                    DocumentoEdictos.DataBind();
                    DocumentoEdictos.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
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
                if (DocumentoEdictos.SelectedValue == "0")
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
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload3.FileName;
                            string nombredoc = siguiente + '-' + FileUpload3.FileName;
                            sn.guardardocumentoexp(siguiente, DocumentoEdictos.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload3.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload3.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewEdictos();
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
                gridViewEdictos.Focus();
            }
            catch
            {

            }
        }

        protected void OnSelectedIndexChangedEdictos(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewEdictos.SelectedRow.FindControl("lblid") as Label).Text);
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
                    ActaNotarial.DataSource = ds;
                    ActaNotarial.DataTextField = "pj_nombretipodoc";
                    ActaNotarial.DataValueField = "idpj_tipodocumento";
                    ActaNotarial.DataBind();
                    ActaNotarial.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar15_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActaNotarial.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload15.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload15.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload15.FileName;
                            string nombredoc = siguiente + '-' + FileUpload15.FileName;
                            sn.guardardocumentoexp(siguiente, ActaNotarial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload15.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload15.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewactanotarial();
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
                gridViewActaNotarial.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewactanotarial()
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
                    gridViewActaNotarial.DataSource = dt;
                    gridViewActaNotarial.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedActaNotarial(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewActaNotarial.SelectedRow.FindControl("lblid") as Label).Text);
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
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 50";
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

        protected void agregar16_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemorialActaNotarial.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload16.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload16.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Memorial/" + siguiente + '-' + FileUpload16.FileName;
                            string nombredoc = siguiente + '-' + FileUpload16.FileName;
                            sn.guardardocumentoexp(siguiente, MemorialActaNotarial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload16.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload16.FileName));
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
                gridViewMemorialActa.Focus();
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 50";
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

        public void llenarcomboresolucionacta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 55";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ResolucionActaNotarial.DataSource = ds;
                    ResolucionActaNotarial.DataTextField = "pj_nombretipodoc";
                    ResolucionActaNotarial.DataValueField = "idpj_tipodocumento";
                    ResolucionActaNotarial.DataBind();
                    ResolucionActaNotarial.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar17_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResolucionActaNotarial.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload17.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload17.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload17.FileName;
                            string nombredoc = siguiente + '-' + FileUpload17.FileName;
                            sn.guardardocumentoexp(siguiente, ResolucionActaNotarial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload17.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload17.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewresolucionacta();
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
                gridViewResolucionActa.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewresolucionacta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 55";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewResolucionActa.DataSource = dt;
                    gridViewResolucionActa.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedResolucionActa(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewResolucionActa.SelectedRow.FindControl("lblid") as Label).Text);
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

        protected void agregar18_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string sig = sn.siguiente("pj_excepciones", "idpj_excepciones");
            string sig2 = sn.siguiente("pj_actitudnegativa", "idpj_actitudnegativa");
            sn.insertarexcepciones(sig, Excepciones.SelectedValue, TipoExcepcion.Value, Observaciones2.Value, sig2, numcredito, sn.datetime(), idusuario);

            llenargridviewexcepciones();
            gridViewTipoExcepcion.Focus();

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
                    string query = "SELECT A.idpj_excepciones AS Codigo, B.pj_excenombre AS TipoExcepciones, A.pj_descripcion AS Descripcion, pj_observaciones AS Observaciones FROM pj_excepciones AS A INNER JOIN pj_tipoexcepciones AS B ON B.idpj_tipoexcepciones = A.pj_tipoexcepciones WHERE A.pj_numcredito = '" + numcredito + "'";
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

        public void llenarcomboremate()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 52";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Remate.DataSource = ds;
                    Remate.DataTextField = "pj_nombretipodoc";
                    Remate.DataValueField = "idpj_tipodocumento";
                    Remate.DataBind();
                    Remate.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar14_Click(object sender, EventArgs e)
        {
            try
            {
                if (Remate.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload14.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload14.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload14.FileName;
                            string nombredoc = siguiente + '-' + FileUpload14.FileName;
                            sn.guardardocumentoexp(siguiente, Remate.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload14.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload14.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewremate();
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
                gridViewMemorialNotario.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewremate()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 52";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewRemate.DataSource = dt;
                    gridViewRemate.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedRemate(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewRemate.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcomboaudenciaremate()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 61";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ActaAudienciaRemate.DataSource = ds;
                    ActaAudienciaRemate.DataTextField = "pj_nombretipodoc";
                    ActaAudienciaRemate.DataValueField = "idpj_tipodocumento";
                    ActaAudienciaRemate.DataBind();
                    ActaAudienciaRemate.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActaAudienciaRemate.SelectedValue == "0")
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
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload5.FileName;
                            string nombredoc = siguiente + '-' + FileUpload5.FileName;
                            sn.guardardocumentoexp(siguiente, ActaAudienciaRemate.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload5.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload5.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewaudienciaremate();
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
                gridViewAudiencia.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewaudienciaremate()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 61";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewAudiencia.DataSource = dt;
                    gridViewAudiencia.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedAudiencia(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewRemate.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcomboproyectoloquidacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 42";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    MemorialLiquidacion.DataSource = ds;
                    MemorialLiquidacion.DataTextField = "pj_nombretipodoc";
                    MemorialLiquidacion.DataValueField = "idpj_tipodocumento";
                    MemorialLiquidacion.DataBind();
                    MemorialLiquidacion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemorialLiquidacion.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload6.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload6.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload6.FileName;
                            string nombredoc = siguiente + '-' + FileUpload6.FileName;
                            sn.guardardocumentoexp(siguiente, MemorialLiquidacion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload6.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload6.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewproyectoloquidacion();
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
                gridViewMemorialLiquidacion.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewproyectoloquidacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 42";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewMemorialLiquidacion.DataSource = dt;
                    gridViewMemorialLiquidacion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedMemorialLiquidacion(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewMemorialLiquidacion.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcomboresolucionliquidacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 43";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ResolucionLiquidacion.DataSource = ds;
                    ResolucionLiquidacion.DataTextField = "pj_nombretipodoc";
                    ResolucionLiquidacion.DataValueField = "idpj_tipodocumento";
                    ResolucionLiquidacion.DataBind();
                    ResolucionLiquidacion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
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
                if (ResolucionLiquidacion.SelectedValue == "0")
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
                            sn.guardardocumentoexp(siguiente, ResolucionLiquidacion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload7.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload7.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewresolucionliquidacion();
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
                gridViewResolucionMemorial.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewresolucionliquidacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 43";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewResolucionMemorial.DataSource = dt;
                    gridViewResolucionMemorial.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedResolucionMemorial(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewResolucionMemorial.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombormemorialnotario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 44";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    NotarioCartulante.DataSource = ds;
                    NotarioCartulante.DataTextField = "pj_nombretipodoc";
                    NotarioCartulante.DataValueField = "idpj_tipodocumento";
                    NotarioCartulante.DataBind();
                    NotarioCartulante.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar8_Click(object sender, EventArgs e)
        {
            try
            {
                if (NotarioCartulante.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload8.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload8.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload8.FileName;
                            string nombredoc = siguiente + '-' + FileUpload8.FileName;
                            sn.guardardocumentoexp(siguiente, NotarioCartulante.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload8.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload8.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewmemorialnotario();
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
                gridViewMemorialNotario.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewmemorialnotario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 44";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewMemorialNotario.DataSource = dt;
                    gridViewMemorialNotario.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedMemorialNotario(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewMemorialNotario.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcomboresolucionnotario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 45";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    ResolucionNotario.DataSource = ds;
                    ResolucionNotario.DataTextField = "pj_nombretipodoc";
                    ResolucionNotario.DataValueField = "idpj_tipodocumento";
                    ResolucionNotario.DataBind();
                    ResolucionNotario.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void agregar9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResolucionNotario.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
                }
                else
                {
                    if (FileUpload9.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload9.FileName);
                        ext = ext.ToLower();

                        if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                        {
                            string numcredito = Session["credito"] as string;
                            string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                            documento = "Subidos/Resolucion/" + siguiente + '-' + FileUpload9.FileName;
                            string nombredoc = siguiente + '-' + FileUpload9.FileName;
                            sn.guardardocumentoexp(siguiente, ResolucionNotario.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload9.SaveAs(Server.MapPath("Subidos/Resolucion/" + siguiente + '-' + FileUpload9.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewmemorialnotario();
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
                gridViewMemorialNotario.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewresolucionnotario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 45";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewResolucionNotario.DataSource = dt;
                    gridViewResolucionNotario.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedResolucionNotario(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewResolucionNotario.SelectedRow.FindControl("lblid") as Label).Text);
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
                gridViewMemorialNotario.Focus();
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

        public void llenarcomboadjudicado()
        {
            DropAdjudicado.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            DropAdjudicado.Items.Insert(1, new ListItem("Adjudicado", "1"));
            DropAdjudicado.Items.Insert(2, new ListItem("No adjudicado", "2"));
        }

        protected void DropAdjudicado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Monto.Visible = true;
            Monto.Focus();
        }

        public void llenarcomboactitud()
        {
            Actitud.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Actitud.Items.Insert(1, new ListItem("Positiva", "1"));
            Actitud.Items.Insert(2, new ListItem("Negativa", "2"));
        }

        protected void Actitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Actitud.SelectedValue == "1")
            {
                actitudNegativa.Visible = false;
                Remate.Focus();
            }
            else
            {
                actitudNegativa.Visible = true;
                Remate.Focus();
            }
        }

        protected void EnviarSolicitud_Click(object sender, EventArgs e)
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string numcredito = Session["credito"] as string;

            decimal total;
            total = Convert.ToDecimal(Honorario.Value) + Convert.ToDecimal(Impuesto.Value);

            string sig = sn.siguiente("pj_solicitudnotificacion", "idpj_solicitudnotificacion");
            sn.insertarsolicitudchequehonorario(sig, total.ToString(), NombreAbogado.Value, numcredito, sn.datetime(), idusuario);

            sn.cambiarestado(numcredito, "24");
            string sig3 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
            sn.guardaretapa(sig3, "25", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);

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
            sn.insertarbitacora(sig6, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Enviado", "51", "51", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);


            String script = "alert('Se guardó exitosamente'); window.location.href= 'PendienteNotificacionApremio.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void MotivoPago_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}