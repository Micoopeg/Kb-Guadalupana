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
    public partial class DiligenciamientoMedidas : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string[] permiso = sn.puestos("32");
                //int cantidadpermiso = permiso.Length;
                //if (permiso[0] == "null" || permiso[0] == "0" || permiso[0] == "" || permiso[0] == null)
                //{
                //    //permisoempleado
                //}
                //else
                //{
                //    //permisojefe
                //}
                //Session["credito"] = "0600564056";
                llenarcombodocumento();
                llenarcomboefectivas();
                llenarcombobanco();
                llenarcombocooperativa();
                llenarcombosuficientes();
                llenarcombovoluntaria();
                llenarcombodocumentomemorial();
                llenarcombodocumentoresolucion();
                llenarcomentarios();
                llenarcomboresultado();
                llenarcombodocumentacion();
                llenarcombomemorial();
                llenarcombogestion();
                llenarformulario();
                llenargridviewvehiculos();
                llenargridviewvbieninmueble();
                llenarcombodocumentofactura();
                llenarcombomotivo();
                SiEfectivas.Visible = false;
                NoEfectivas.Visible = false;
                HayResultado.Visible = false;
                SiResultados.Visible = false;
                Suficientes.Visible = false;
                EsVoluntaria.Visible = false;
                SiSuficiente.Visible = false;
                //TransaccionVoluntaria.Visible = false;
                fechaPresentacionMemorial.Visible = false;
                InfoMonto.Visible = false;
                InfoTrabajo.Visible = false;
                infoBanco.Visible = false;
                infoCooperativa2.Visible = false;
                MemorialTransaccion.Visible = false;
                ResolucionTransaccion.Visible = false;
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
                    DiasMora.Value = campos[6];
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

        public void llenarcomboefectivas()
        {
            SonEfectivas.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            SonEfectivas.Items.Insert(1, new ListItem("Si", "1"));
            SonEfectivas.Items.Insert(2, new ListItem("No", "2"));
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 22";
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
                            documento = "Subidos/Informe/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/Informe/" + siguiente + '-' + FileUpload1.FileName));
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
                Arraigo.Focus();
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 22";
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

        public void llenarcombobanco()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_bancoemisor";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Banco.DataSource = ds;
                    Banco.DataTextField = "pj_nombrebanco";
                    Banco.DataValueField = "idpj_bancoemisor";
                    Banco.DataBind();
                    Banco.Items.Insert(0, new ListItem("[Seleccione Banco]", "0"));

                    Banco2.DataSource = ds;
                    Banco2.DataTextField = "pj_nombrebanco";
                    Banco2.DataValueField = "idpj_bancoemisor";
                    Banco2.DataBind();
                    Banco2.Items.Insert(0, new ListItem("[Seleccione Banco]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombocooperativa()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_cooperativas";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Cooperativa.DataSource = ds;
                    Cooperativa.DataTextField = "pj_nombrecoope";
                    Cooperativa.DataValueField = "idpj_cooperativas";
                    Cooperativa.DataBind();
                    Cooperativa.Items.Insert(0, new ListItem("[Seleccione Cooperativa]", "0"));

                    Cooperativa2.DataSource = ds;
                    Cooperativa2.DataTextField = "pj_nombrecoope";
                    Cooperativa2.DataValueField = "idpj_cooperativas";
                    Cooperativa2.DataBind();
                    Cooperativa2.Items.Insert(0, new ListItem("[Seleccione Cooperativa]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombosuficientes()
        {
            SonSuficientes.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            SonSuficientes.Items.Insert(1, new ListItem("Si", "1"));
            SonSuficientes.Items.Insert(2, new ListItem("No", "2"));
        }

        public void llenarcombovoluntaria()
        {
            Voluntaria.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Voluntaria.Items.Insert(1, new ListItem("Si", "1"));
            Voluntaria.Items.Insert(2, new ListItem("No", "2"));
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

        protected void SonEfectivas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LugarTrabajo.Visible = false;
            TituloTrabajo.Visible = false;
            infoBanco2.Visible = false;
            Arraigo.Visible = false;
            TituloArraigo.Visible = false;
            infoCooperativa.Visible = false;
            OficioTrabajo.Visible = false;
            OficioTrabajo2.Visible = false;

            if (SonEfectivas.SelectedValue == "1")
            {
                SiEfectivas.Visible = true;
                Suficientes.Visible = true;
                NoEfectivas.Visible = false;
                HayResultado.Visible = false;
                if (MedidasPre1.Checked)
                {
                    LugarTrabajo.Visible = true;
                    TituloTrabajo.Visible = true;
                }
                else
                {
                    LugarTrabajo.Visible = false;
                    TituloTrabajo.Visible = false;
                }

                if (MedidasPre2.Checked)
                {
                    infoBanco2.Visible = true;
                }
                else
                {
                    infoBanco2.Visible = false;
                }

                if (MedidasPre3.Checked)
                {
                    Arraigo.Visible = true;
                    TituloArraigo.Visible = true;
                    OficioTrabajo.Visible = true;
                    OficioTrabajo2.Visible = true;
                }
                else
                {
                    Arraigo.Visible = false;
                    TituloArraigo.Visible = false;
                    OficioTrabajo.Visible = false;
                    OficioTrabajo2.Visible = false;
                }

                if (MedidasPre4.Checked)
                {
                    infoCooperativa.Visible = true;
                }
                else
                {
                    infoCooperativa.Visible = false;
                }

                if (MedidasPre5.Checked)
                {

                }

                //Banco.Visible = false;
                //TituloBanco.Visible = false;
                //Cooperativa.Visible = false;
                //TituloCooperativa.Visible = false;
                //LugarTrabajo.Visible = false;
                //TituloTrabajo.Visible = false;
                //Arraigo.Visible = false;
                //TituloArraigo.Visible = false;
                //Monto.Visible = false;
                //TituloMonto.Visible = false;
                PTipoDocumento.Focus();
            }
            else
            {
                SiEfectivas.Visible = false;
                Suficientes.Visible = false;
                NoEfectivas.Visible = true;
                HayResultado.Visible = false;
                Guardar.Visible = false;
                NoEfectivas.Focus();
            }
        }

        protected void SonSuficientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SonSuficientes.SelectedValue == "1")
            {
                EsVoluntaria.Visible = false;
                SiSuficiente.Visible = true;
                NoEfectivas.Visible = false;
                HayResultado.Visible = false;
                Guardar.Visible = false;
                SolicitudCobros.Focus();
            }
            else
            {
                EsVoluntaria.Visible = false;
                NoEfectivas.Visible = true;
                HayResultado.Visible = true;
                SiSuficiente.Visible = false;
                Guardar.Visible = false;
                HayResultado.Visible = false;
                EnviarSolicitud.Focus();
            }
        }

        protected void Voluntaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Voluntaria.SelectedValue == "1")
            {
                //TransaccionVoluntaria.Visible = false;
                ResolucionTransaccion.Visible = true;
                fechaPresentacionMemorial.Visible = true;
                MemorialTransaccion.Visible = true;
                InfoTrabajo.Visible = false;
                infoBanco.Visible = false;
                infoCooperativa2.Visible = false;
                ResolucionTransaccion.Focus();

                //if (MedidasPre1.Checked)
                //{
                //    InfoTrabajo.Visible = true;
                //}
                //else
                //{
                //    InfoTrabajo.Visible = false;
                //}

                if (MedidasPre2.Checked)
                {
                    //infoBanco.Visible = true;
                    InfoMonto.Visible = true;
                }
                else
                {
                    //infoBanco.Visible = false;
                    InfoMonto.Visible = false;
                }

                //if (MedidasPre3.Checked)
                //{
                //    InfoTrabajo.Visible = false;
                //    Banco2.Visible = false;
                //    MontoTransar.Visible = false;
                //    InfoCooperativa.Visible = false;
                //}

                if (MedidasPre4.Checked)
                {
                    //infoCooperativa2.Visible = true;
                    InfoMonto.Visible = true;
                }
                else
                {
                    //infoCooperativa2.Visible = false;
                    InfoMonto.Visible = false;
                }

                //if (MedidasPre5.Checked)
                //{
                //    InfoTrabajo.Visible = false;
                //    Banco2.Visible = false;
                //    MontoTransar.Visible = false;
                //    Cooperativa2.Visible = false;
                //}

                //if (MedidasPre6.Checked)
                //{
                //    InfoTrabajo.Visible = false;
                //    Banco2.Visible = false;
                //    MontoTransar.Visible = false;
                //    Cooperativa2.Visible = false;
                //}
            }
            else
            {
                //TransaccionVoluntaria.Visible = false;
                if (MedidasPre2.Checked)
                {
                    //infoBanco.Visible = true;
                    InfoMonto.Visible = true;
                }
                else
                {
                    //infoBanco.Visible = false;
                    InfoMonto.Visible = false;
                }

                if (MedidasPre4.Checked)
                {
                    //infoCooperativa2.Visible = true;
                    InfoMonto.Visible = true;
                }
                else
                {
                    //infoCooperativa2.Visible = false;
                    InfoMonto.Visible = false;
                }

                fechaPresentacionMemorial.Visible = true;
                ResolucionTransaccion.Visible = true;
                MemorialTransaccion.Visible = true;
                InfoTrabajo.Visible = false;
                infoBanco.Visible = false;
                infoCooperativa2.Visible = false;
                ResolucionTransaccion.Focus();
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

        public void llenarcomboresultado()
        {
            Resultado.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Resultado.Items.Insert(1, new ListItem("Si", "1"));
            Resultado.Items.Insert(2, new ListItem("No", "2"));
        }

        public void llenarcombodocumentacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento IN(1,2,3,4,5,6,7,8,9,10,11,12,13)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoDocumentacion.DataSource = ds;
                    TipoDocumentacion.DataTextField = "pj_nombretipodoc";
                    TipoDocumentacion.DataValueField = "idpj_tipodocumento";
                    TipoDocumentacion.DataBind();
                    TipoDocumentacion.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
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
                if (TipoDocumentacion.SelectedValue == "0")
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
                            documento = "Subidos/Documentacion/" + siguiente + '-' + FileUpload4.FileName;
                            string nombredoc = siguiente + '-' + FileUpload4.FileName;
                            sn.guardardocumentoexp(siguiente, TipoDocumentacion.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload4.SaveAs(Server.MapPath("Subidos/Documentacion/" + siguiente + '-' + FileUpload4.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentacion();
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
                NIT.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewdocumentacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 25";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDocumentacion.DataSource = dt;
                    gridViewDocumentacion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedDocumentacion(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewDocumentacion.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombomemorial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento IN (26,27,28)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoMemorial.DataSource = ds;
                    TipoMemorial.DataTextField = "pj_nombretipodoc";
                    TipoMemorial.DataValueField = "idpj_tipodocumento";
                    TipoMemorial.DataBind();
                    TipoMemorial.Items.Insert(0, new ListItem("[Tipo Documento]", "0"));
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
                if (TipoMemorial.SelectedValue == "0")
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
                            sn.guardardocumentoexp(siguiente, TipoMemorial.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload5.SaveAs(Server.MapPath("Subidos/Memorial/" + siguiente + '-' + FileUpload5.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewmemorial();
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
                Gestion1.Focus();
            }
            catch
            {

            }
        }

        public void llenargridviewmemorial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento IN (26,27,28)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewMemorial.DataSource = dt;
                    gridViewMemorial.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedMemorial(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewMemorial.SelectedRow.FindControl("lblid") as Label).Text);
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

        public void llenarcombogestion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_gestión";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Gestion1.DataSource = ds;
                    Gestion1.DataTextField = "pj_nombregestion";
                    Gestion1.DataValueField = "idpj_gestión";
                    Gestion1.DataBind();
                    Gestion1.Items.Insert(0, new ListItem("[Seleccione Gestión]", "0"));

                    Gestion2.DataSource = ds;
                    Gestion2.DataTextField = "pj_nombregestion";
                    Gestion2.DataValueField = "idpj_gestión";
                    Gestion2.DataBind();
                    Gestion2.Items.Insert(0, new ListItem("[Seleccione Gestión]", "0"));

                    Gestion3.DataSource = ds;
                    Gestion3.DataTextField = "pj_nombregestion";
                    Gestion3.DataValueField = "idpj_gestión";
                    Gestion3.DataBind();
                    Gestion3.Items.Insert(0, new ListItem("[Seleccione Gestión]", "0"));

                    Gestion4.DataSource = ds;
                    Gestion4.DataTextField = "pj_nombregestion";
                    Gestion4.DataValueField = "idpj_gestión";
                    Gestion4.DataBind();
                    Gestion4.Items.Insert(0, new ListItem("[Seleccione Gestión]", "0"));

                    Gestion5.DataSource = ds;
                    Gestion5.DataTextField = "pj_nombregestion";
                    Gestion5.DataValueField = "idpj_gestión";
                    Gestion5.DataBind();
                    Gestion5.Items.Insert(0, new ListItem("[Seleccione Gestión]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Resultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Resultado.SelectedValue == "1")
            {
                SiResultados.Visible = true;
                ActualizarVehiculo.Visible = false;
                Cancelar.Visible = false;
                ActualizarBienes.Visible = false;
                Cancelar2.Visible = false;

                AgregarVehiculo.Focus();

                if (MedidasPre1.Checked)
                {
                    Empresa.Visible = true;
                }
                else
                {
                    Empresa.Visible = false;
                }

                if (MedidasPre5.Checked)
                {
                    Vehiculos.Visible = true;
                    Bienes.Visible = true;
                }
                else
                {
                    Vehiculos.Visible = false;
                    Bienes.Visible = false;
                }
            }
            else
            {
                SiResultados.Visible = false;
                AgregarVehiculo.Focus();
            }
        }

        protected void OnSelectedIndexChangedVehiculo(object sender, EventArgs e)
        {
            string id = Convert.ToString((gridViewVehiculo.SelectedRow.FindControl("lblid") as Label).Text);
            string[] datos = sn.datosvehiculo(id);
            Session["idvehiculo"] = id;

            NIT.Value = datos[1];
            Placa.Value = datos[2];
            Modelo.Value = datos[3];
            Marca.Value = datos[4];

            ActualizarVehiculo.Visible = true;
            Cancelar.Visible = true;
            AgregarVehiculo.Visible = false;

            gridViewVehiculo.Focus();
        }

        protected void OnSelectedIndexChangedBienes(object sender, EventArgs e)
        {
            string id = Convert.ToString((gridViewBienes.SelectedRow.FindControl("lblid") as Label).Text);
            string[] datos = sn.datosbienes(id);
            Session["idbienes"] = id;

            AgregarBienes.Visible = false;
            ActualizarBienes.Visible = true;
            Cancelar2.Visible = true;

            Finca.Value = datos[1];
            Folio.Value = datos[2];
            Libro.Value = datos[3];

            gridViewBienes.Focus();
        }

        protected void AgregarVehiculo_Click(object sender, EventArgs e)
        {
            if(NIT.Value == "" || Placa.Value == "" || Modelo.Value == "" || Marca.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete todos los datos');", true);
            }
            else
            {
                string numcredito = Session["credito"] as string;
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string sig = sn.siguiente("pj_vehiculo", "idpj_vehiculo");
                sn.insertarvehiculo(sig, NIT.Value, Placa.Value, Modelo.Value, Marca.Value, numcredito, idusuario);
                llenargridviewvehiculos();
                gridViewVehiculo.Focus();
            }
        }

        public void llenargridviewvehiculos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT idpj_vehiculo AS Codigo, pj_nit AS Nit, pj_placa AS Placa, pj_modelo AS Modelo, pj_marca AS Marca FROM pj_vehiculo WHERE pj_numcredito = '"+numcredito+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewVehiculo.DataSource = dt;
                    gridViewVehiculo.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void AgregarBienes_Click(object sender, EventArgs e)
        {
            if(Finca.Value == "" || Folio.Value == "" || Libro.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete todos los datos');", true);
            }
            else
            {
                string numcredito = Session["credito"] as string;
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string sig = sn.siguiente("pj_bienesinmuebles", "idpj_bienesinmuebles");
                sn.insertarbieninmueble(sig, Finca.Value, Folio.Value, Libro.Value, numcredito, idusuario);
                TipoMemorial.Focus();
                llenargridviewvbieninmueble();
            }
        }

        public void llenargridviewvbieninmueble()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT idpj_bienesinmuebles AS Codigo, pj_finca AS Finca, pj_folio AS Folio, pj_libro AS Libro FROM pj_bienesinmuebles";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewBienes.DataSource = dt;
                    gridViewBienes.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void ActualizarVehiculo_Click(object sender, EventArgs e)
        {
            string id = Session["idvehiculo"] as string;

            if(NIT.Value == "" || Placa.Value == "" || Modelo.Value == "" || Marca.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
            }
            else
            {
                sn.actualizarvehiculo(id, NIT.Value, Placa.Value, Modelo.Value, Marca.Value);
                AgregarVehiculo.Visible = true;
                ActualizarVehiculo.Visible = false;
                Cancelar.Visible = false;
                NIT.Value = "";
                Placa.Value = "";
                Modelo.Value = "";
                Marca.Value = "";
                llenargridviewvehiculos();
                gridViewVehiculo.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se actualizó exitosamente');", true);
            }
        }

        protected void CancelarVehiculo_Click(object sender, EventArgs e)
        {
            AgregarVehiculo.Visible = true;
            ActualizarVehiculo.Visible = false;
            Cancelar.Visible = false;
            NIT.Value = "";
            Placa.Value = "";
            Modelo.Value = "";
            Marca.Value = "";
            gridViewVehiculo.Focus();
        }

        protected void ActualizarBienes_Click(object sender, EventArgs e)
        {
            string id = Session["idbienes"] as string;

            if(Finca.Value == "" || Folio.Value == "" || Libro.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
            }
            else
            {
                sn.actualizarbien(id, Finca.Value, Folio.Value, Libro.Value);
                AgregarBienes.Visible = true;
                ActualizarBienes.Visible = false;
                Cancelar2.Visible = false;
                Finca.Value = "";
                Folio.Value = "";
                Libro.Value = "";
                llenargridviewvbieninmueble();
                gridViewBienes.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Actualizado exitosamente');", true);
            }
        }

        protected void Cancelar2_Click(object sender, EventArgs e)
        {
            AgregarBienes.Visible = true;
            ActualizarBienes.Visible = false;
            Cancelar2.Visible = false;
            Finca.Value = "";
            Folio.Value = "";
            Libro.Value = "";
            gridViewBienes.Focus();
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string fecha = sn.datetime();
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            if (SonEfectivas.SelectedValue == "1")
            {
                string sig = sn.siguiente("pj_sonefectivas", "idpj_sonefectivas");
                sn.insertarsonefectivas(sig, Banco.SelectedValue, MontoEmbargado.Value, Cooperativa.SelectedValue, MontoEmbargado2.Value, LugarTrabajo.Value, Arraigo.Value, numcredito, idusuario, fecha, OficioTrabajo2.Value);

                if(SonSuficientes.SelectedValue == "1")
                {
                    if (MotivoPago.SelectedValue != "9")
                    {
                        Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                    }

                    string sig2 = sn.siguiente("pj_voluntaria", "idpj_voluntaria");
                    sn.insertarvoluntaria(sig2, Voluntaria.SelectedValue, FechaPresentacion.Value, MontoTransar.Value, FechaResolucion.Value, FechaNotificacion.Value, Observaciones.Value, numcredito, idusuario, fecha);
                    string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                    sn.guardaretapa(sig11, "9", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                    sn.cambiarestado(numcredito, "8");

                    if (MedidasPre1.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito, "4");
                    }
                    if (MedidasPre2.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito, "4");
                    }
                    if (MedidasPre3.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito, "4");
                    }
                    if (MedidasPre4.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito, "4");
                    }
                    if (MedidasPre6.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "6", OtrasMedidas.Value, numcredito, "4");
                    }
                    if (MedidasPre5.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "5", "Embargo de bienes", numcredito, "4");
                    }

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
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "26", fechahoraactual, fechacreacion2, Observaciones.Value);


                    String script = "alert('Guardado exitosamente'); window.location.href= 'PendienteDiligenciamiento.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    string sig11 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                    sn.guardaretapa(sig11, "9", numcredito, sn.datetime(), "Investigacion", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                    sn.cambiarestado(numcredito, "8");

                    if (MedidasPre1.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito, "4");
                    }
                    if (MedidasPre2.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito, "4");
                    }
                    if (MedidasPre3.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito, "4");
                    }
                    if (MedidasPre4.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito, "4");
                    }
                    if (MedidasPre6.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "6", OtrasMedidas.Value, numcredito, "4");
                    }
                    if (MedidasPre5.Checked)
                    {
                        string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                        sn.insertarmedidaspre(sig6, "5", "Embargo de bienes", numcredito, "4");
                    }

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
                    sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Comentario.Value);

                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Investigacion", "51", "26", fechahoraactual, fechacreacion2, Comentario.Value);


                    //SE COLOCA CUANDO COBROS REGRESE LA INVESTIGACION
                    //if(Resultado.SelectedValue == "1")
                    //{
                    //    string sig4 = sn.siguiente("pj_hayresultados", "idpj_hayresultados");
                    //    sn.insertarhayresultados(sig4, EmpresaLabora.Value, FechaMemorial.Value, FechaSolicitud.Value, FechaPresentacionApremio.Value, numcredito, idusuario, fecha);

                    //    string sig6 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                    //    sn.insertargestionmedidas(sig6, "1", Gestion1.SelectedValue, numcredito, sig4);

                    //    string sig7 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                    //    sn.insertargestionmedidas(sig7, "2", Gestion2.SelectedValue, numcredito, sig4);

                    //    string sig8 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                    //    sn.insertargestionmedidas(sig8, "3", Gestion3.SelectedValue, numcredito, sig4);

                    //    string sig9 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                    //    sn.insertargestionmedidas(sig9, "4", Gestion4.SelectedValue, numcredito, sig4);

                    //    string sig10 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                    //    sn.insertargestionmedidas(sig10, "5", Gestion5.SelectedValue, numcredito, sig4);

                    //}
                    //else
                    //{

                    //}
                }
            }
            else
            {
                string sig12 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig12, "9", numcredito, sn.datetime(), "Investigacion", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
                sn.cambiarestado(numcredito, "8");

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
                sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Comentario.Value);

                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Investigacion", "51", "26", fechahoraactual, fechacreacion2, Comentario.Value);


                //SE COLOCA CUANDO COBROS REGRESE LA INVESTIGACION
                //if (Resultado.SelectedValue == "1")
                //{
                //    string sig4 = sn.siguiente("pj_hayresultados", "idpj_hayresultados");
                //    sn.insertarhayresultados(sig4, EmpresaLabora.Value, FechaMemorial.Value, FechaSolicitud.Value, FechaPresentacionApremio.Value, numcredito, idusuario, fecha);

                //    string sig6 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                //    sn.insertargestionmedidas(sig6, "1", Gestion1.SelectedValue, numcredito, sig4);

                //    string sig7 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                //    sn.insertargestionmedidas(sig7, "2", Gestion2.SelectedValue, numcredito, sig4);

                //    string sig8 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                //    sn.insertargestionmedidas(sig8, "3", Gestion3.SelectedValue, numcredito, sig4);

                //    string sig9 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                //    sn.insertargestionmedidas(sig9, "4", Gestion4.SelectedValue, numcredito, sig4);

                //    string sig10 = sn.siguiente("pj_gestionmedida", "idpj_gestionmedida");
                //    sn.insertargestionmedidas(sig10, "5", Gestion5.SelectedValue, numcredito, sig4);

                //}
                //else
                //{

                //}
            }
        }

        protected void EnviarSolicitud_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string fecha = sn.datetime();
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string sig12 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
            sn.cambiarestado(numcredito, "8");

            int diasmora = Convert.ToInt32(DiasMora.Value);

            if(diasmora < 360)
            {
                sn.guardaretapa(sig12, "9", numcredito, sn.datetime(), "Investigacion", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
            }
            else
            {
                sn.guardaretapa(sig12, "9", numcredito, sn.datetime(), "Investigacion (Cartera Depurada)", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
            }
            
            

            if (SonEfectivas.SelectedValue == "1")
            {
                string sig = sn.siguiente("pj_sonefectivas", "idpj_sonefectivas");
                sn.insertarsonefectivas(sig, Banco.SelectedValue, MontoEmbargado.Value, Cooperativa.SelectedValue, MontoEmbargado2.Value, LugarTrabajo.Value, Arraigo.Value, numcredito, idusuario, fecha, OficioTrabajo2.Value);
            }

                if (MedidasPre1.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito, "4");
            }
            if (MedidasPre2.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito, "4");
            }
            if (MedidasPre3.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito, "4");
            }
            if (MedidasPre4.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito, "4");
            }
            if (MedidasPre6.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "6", OtrasMedidas.Value, numcredito, "4");
            }
            if (MedidasPre5.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "5", "Embargo de bienes", numcredito, "4");
            }

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
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Comentario.Value);

            if(diasmora < 360)
            {
                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Investigacion", "51", "26", fechahoraactual, fechacreacion2, Comentario.Value);
            }
            else
            {
                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Investigacion", "51", "24", fechahoraactual, fechacreacion2, Comentario.Value);
            }
           


            String script = "alert('Enviado exitosamente'); window.location.href= 'PendienteDiligenciamiento.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        public void llenarcombodocumentofactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 31";
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
                if (FileUpload3.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload3.FileName);
                    ext = ext.ToLower();

                    if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                    {
                        string numcredito = Session["credito"] as string;
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/Diligenciamiento/" + siguiente + '-' + FileUpload3.FileName;
                        string nombredoc = siguiente + '-' + FileUpload3.FileName;
                        sn.guardardocumentoexp(siguiente, TDocumentoFactura.SelectedValue, documento, nombredoc, numcredito);
                        FileUpload3.SaveAs(Server.MapPath("Subidos/Diligenciamiento/" + siguiente + '-' + FileUpload3.FileName));
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

        public void llenargridviewfactura()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string numcredito = Session["credito"] as string;
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 31";
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

        protected void SolicitudCobros_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string fecha = sn.datetime();
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string sig = sn.siguiente("pj_sonefectivas", "idpj_sonefectivas");
            sn.insertarsonefectivas(sig, Banco.SelectedValue, MontoEmbargado.Value, Cooperativa.SelectedValue, MontoEmbargado2.Value, LugarTrabajo.Value, Arraigo.Value, numcredito, idusuario, fecha, OficioTrabajo2.Value);


            string sig12 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
            sn.guardaretapa(sig12, "9", numcredito, sn.datetime(), "Medidas suficientes", idusuario, "51", NombreCliente.Value, NumIncidente.Value);
            sn.cambiarestado(numcredito, "8");

            if (MedidasPre1.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito, "4");
            }
            if (MedidasPre2.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito, "4");
            }
            if (MedidasPre3.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito, "4");
            }
            if (MedidasPre4.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito, "4");
            }
            if (MedidasPre6.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "6", OtrasMedidas.Value, numcredito, "4");
            }
            if (MedidasPre5.Checked)
            {
                string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                sn.insertarmedidaspre(sig6, "5", "Embargo de bienes", numcredito, "4");
            }

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
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, Comentario2.Value);

            string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Medidas suficientes", "51", "26", fechahoraactual, fechacreacion2, Comentario2.Value);


            String script = "alert('Enviado exitosamente'); window.location.href= 'PendienteDiligenciamiento.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }
    }
}