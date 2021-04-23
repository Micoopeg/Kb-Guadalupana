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
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombodocumento();
                llenarformulario();
                llenargridviewdocumentos();
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

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                    ext = ext.ToLower();

                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf');", true);
                    }
                    else
                    {
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName;
                        string nombredoc = siguiente + '-' + FileUpload1.FileName;
                        sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, "1234567891");
                        FileUpload1.SaveAs(Server.MapPath("Subidos/DocumentosExpediente/" + siguiente + '-' + FileUpload1.FileName));
                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se ha guardado el archivo');", true);
                        llenargridviewdocumentos();
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
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento";
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
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento";
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
            string numcredito = Session["credito_asignado"] as string;
            string[] campos = sn.obtenerinforcredito(numcredito);

            for (int i = 0; i < campos.Length; i++)
            {
                Agencia.Value = campos[1];
                Instrumento.Value = campos[2];
                LineaCredito.Value = campos[3];
                destino.Value = campos[4];
                Garantia.Value = campos[5];
                Plazomeses.Value = campos[6];
                Metodocalculo.Value = campos[7];
                Estado.Value = campos[8];
                Moneda.Value = campos[9];
                Tasa.Value = campos[10];
                string[] fecha = campos[11].Split(' ');
                FechaSolicitud.Value = fecha[0];
                string[] fecha2 = campos[12].Split(' ');
                FechaDesembolso1.Value = fecha2[0];
                string[] fecha3 = campos[13].Split(' ');
                FechaUltimoDes.Value = fecha3[0];
                string[] fecha4 = campos[14].Split(' ');
                FechaVencimiento.Value = fecha4[0];
                string[] fecha5 = campos[15].Split(' ');
                FechaUltimaCuota.Value = fecha5[0];
                FechaActa.Value = campos[16];
                NumActa.Value = campos[17];
                OficialNombre1.Value = campos[18];
                OficialNombre2.Value = campos[19];
                OficialApellido1.Value = campos[20];
                OficialApellido2.Value = campos[21];
                NumPrestamo.Value = campos[22];
                AgenciaCliente.Value = campos[23];
                CodigoCliente.Value = campos[24];
                ClienteNombre1.Value = campos[25];
                ClienteNombre2.Value = campos[26];
                ClienteApellido1.Value = campos[27];
                ClienteApellido2.Value = campos[28];
                MontoOriginal.Value = campos[29];
                CapitalDesem.Value = campos[30];
                SaldoActual.Value = campos[31];
                DescripcionDoc.Value = campos[34];
            }
        }
    }
}