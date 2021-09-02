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
    public partial class SolicitudCheque : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarformulario();
                llenarcombodocumento();
                llenarcombobanco();
                llenarcomentarios();
            }
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 20";
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento = 20";
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
                            documento = "Subidos/Cheque/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/Cheque/" + siguiente + '-' + FileUpload1.FileName));
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
                
            }
            catch
            {

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
                    Banco.Items.Insert(0, new ListItem("[Selecccione Banco]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string cheque = sn.tipodocumentoCheque(numcredito);
            if (cheque == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir el documento');", true);
            }
            else if(NumCheque.Value == "" || FechaEmision.Value == "" || Banco.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
            }
            else
            {
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);

                string sig = sn.siguiente("pj_solicitudcheque", "idpj_solicitudcheque");
                sn.insertarsolicitudcheque(sig, numcredito, idusuario, NumCheque.Value, FechaEmision.Value, Banco.SelectedValue, ObservacionesCredito.Value, Monto.Value);

               


                string[] campos2 = sn.obtenertipocredito(numcredito);
                string idcredito = campos2[0];
                string fecha = "";
                string numindicende = "";
                string nombrecliente = "";

                if (idcredito == null)
                {
                    string[] campos3 = sn.obtenertipotarjeta(numcredito);
                    for (int i = 0; i < campos3.Length; i++)
                    {
                        numindicende = campos3[0];
                    }
                    fecha = sn.fechacreaciontarjeta(numcredito);
                }
                else
                {
                    for (int i = 0; i < campos2.Length; i++)
                    {
                        numindicende = campos2[0];
                    }
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
                string año = fecha2[0];
                string mes = fecha2[1];
                string dia = fecha2[2];

                string hora = fechayhora[1];
                string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                string var1 = WS.buscarcredito(numcredito);
                char delimitador = '|';
                string[] campos = var1.Split(delimitador);
                string nombrecliente2 = "";

                if (var1.Length == 4)
                {
                    Response.Write("NO HAY DATOS QUE MOSTRARA");
                }
                else
                {
                   
                    for (int i = 0; i < campos.Length; i++)
                    {
                        nombrecliente2 = campos[20];
                    }
                }

                string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig5, numindicende, numcredito, nombrecliente2, "Recibido", "34", "28", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);

                string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig4, numindicende, numcredito, nombrecliente2, "Enviado", "34", "28", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);

                sn.cambiarestado(numcredito, "6");

                string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
                sn.guardaretapa(sig2, "7", numcredito, sn.datetime(), "Cargar Voucher", idusuario, "28", nombrecliente2, NumeroIncidente.Value);

                String script = "alert('Se guardó exitosamente'); window.location.href= 'PendienteSolicitudCheque.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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
                Response.Write("NO HAY DATOS QUE MOSTRAR");
            }
            else
            {

                for (int i = 0; i < campos.Length; i++)
                {
                    CreditoNumero.Value = campos[1];
                    NumCif.Value = campos[19];
                    ClienteNombre.Value = campos[20];
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
                    NumeroIncidente.Value = campos3[0];
                }
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
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
    }
}