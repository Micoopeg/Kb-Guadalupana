using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class FacturacionAbogado : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombodocumento();
                llenarcombomotivo();
                Otro.Visible = false;
                llenarformulario();
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

                    if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                    {
                        string numcredito = Session["credito"] as string;
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/Demanda/" + siguiente + '-' + FileUpload1.FileName;
                        string nombredoc = siguiente + '-' + FileUpload1.FileName;
                        sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                        FileUpload1.SaveAs(Server.MapPath("Subidos/Demanda/" + siguiente + '-' + FileUpload1.FileName));
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
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 18";
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 16";
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

        public void llenarcombomotivo()
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
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

        protected void MotivoPago_SelectedIndexChanged(object sender, EventArgs e)
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
                for (int i = 0; i < campos.Length; i++)
                {
                    CreditoNumero.Value = campos[1];
                    NumCif.Value = campos[19];
                    ClienteNombre.Value = campos[20];
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
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");
            string factura = sn.tipodocumentoFactura(numcredito);

            if(factura == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe cargar la factura');", true);
            }
            else
            {
                if (NumFactura.Value == "" || Serie.Value == "" || Descripcion.Value == "" || ImporteTotal.Value == "" || FechaEmision.Value == "" || ImporteCaso.Value == "" || MotivoPago.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe completar los datos');", true);
                }
                else
                {
                    //string[] fechaemision = FechaEmision.Value.Split('/');
                    //string dia = fechaemision[0];
                    //string mes = fechaemision[1];
                    //string año = fechaemision[2];
                    //string fechabd = año + '-' + mes + '-' + dia;

                    string sig = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                    sn.guardarfacturaabogado(sig, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, ClienteNombre.Value, NumCif.Value);
                    sn.guardaretapa(sig2, "6", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value);
                    sn.cambiarestado(numcredito, "5");

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
                    sn.insertarbitacora(sig5, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Recibido", "51", "51", fechahoraactual, fechacreacion2, "Recibido");

                    string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig4, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, "Facturación");


                    String script = "alert('Se guardó exitosamente'); window.location.href= 'PendienteFacturacionAbogado.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
            }
        }
    }
}