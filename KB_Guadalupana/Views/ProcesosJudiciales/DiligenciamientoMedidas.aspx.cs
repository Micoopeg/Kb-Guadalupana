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
                SiEfectivas.Visible = false;
                NoEfectivas.Visible = false;
                HayResultado.Visible = false;
                SiResultados.Visible = false;
                Suficientes.Visible = false;
                EsVoluntaria.Visible = false;
                TransaccionVoluntaria.Visible = false;
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
                Response.Write("NO HAY DATOS QUE MOSTRARA");
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
            Banco.Visible = false;
            TituloBanco.Visible = false;
            Monto.Visible = false;
            TituloMonto.Visible = false;
            Arraigo.Visible = false;
            TituloArraigo.Visible = false;
            Cooperativa.Visible = false;
            TituloCooperativa.Visible = false;

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
                    Banco.Visible = true;
                    TituloBanco.Visible = true;
                    Monto.Visible = true;
                    TituloMonto.Visible = true;
                }
                else
                {
                    Banco.Visible = false;
                    TituloBanco.Visible = false;
                    Monto.Visible = false;
                    TituloMonto.Visible = false;
                }

                if (MedidasPre3.Checked)
                {
                    Arraigo.Visible = true;
                    TituloArraigo.Visible = true;
                }
                else
                {
                    Arraigo.Visible = false;
                    TituloArraigo.Visible = false;
                }

                if (MedidasPre4.Checked)
                {
                    Cooperativa.Visible = true;
                    TituloBanco.Visible = true;
                    Monto.Visible = true;
                    TituloMonto.Visible = true;
                }
                else
                {
                    Cooperativa.Visible = false;
                    TituloCooperativa.Visible = false;
                    Monto.Visible = false;
                    TituloMonto.Visible = false;
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
                HayResultado.Visible = true;
                HayResultado.Focus();
            }
        }

        protected void SonSuficientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SonSuficientes.SelectedValue == "1")
            {
                EsVoluntaria.Visible = true;
                NoEfectivas.Visible = false;
                HayResultado.Visible = false;
                EsVoluntaria.Focus();
            }
            else
            {
                EsVoluntaria.Visible = false;
                NoEfectivas.Visible = true;
                HayResultado.Visible = true;
                HayResultado.Focus();
            }
        }

        protected void Voluntaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Voluntaria.SelectedValue == "1")
            {
                TransaccionVoluntaria.Visible = true;
                ResolucionTransaccion.Visible = true;
                ResolucionTransaccion.Focus();

                if (MedidasPre1.Checked)
                {
                    InfoTrabajo.Visible = true;
                }
                else
                {
                    InfoTrabajo.Visible = false;
                }

                if (MedidasPre2.Checked)
                {

                }
            }
            else
            {
                TransaccionVoluntaria.Visible = true;
                ResolucionTransaccion.Visible = true;
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
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 25";
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
                AgregarVehiculo.Focus();
            }
            else
            {
                SiResultados.Visible = false;
                AgregarVehiculo.Focus();
            }
        }

        protected void OnSelectedIndexChangedVehiculo(object sender, EventArgs e)
        {

        }

        protected void OnSelectedIndexChangedBienes(object sender, EventArgs e)
        {

        }
    }
}