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
                llenarcomentarios();
                NombreCheque.Value = Session["Nombre"] as string;
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
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 32";
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 32";
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
                gridViewDocumentos.Focus();
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
            Guardar.Focus();
        }

        public void llenarformulario()
        {

            string numcredito = Session["credito"] as string;
            string var1 = WS.buscarcredito(numcredito);
            char delimitador = '|';
            string[] campos = var1.Split(delimitador);

            if (var1.Length == 4)
            {
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'PendienteFacturacionAbogado.aspx';";
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
                    //sn.guardarfacturaabogado(sig, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, ClienteNombre.Value, NumCif.Value);
                    string etapa = Session["etapa"] as string;

                    if (MotivoPago.SelectedValue != "9")
                    {
                        Otro.Value = sn.motivopago(MotivoPago.SelectedValue);
                    }

                    if (etapa == "10")
                    {
                        sn.guardaretapa(sig2, "11", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);
                        sn.cambiarestado(numcredito, "10");
                        string sig3 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                        sn.guardarfacturaabogado(sig3, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, Observaciones.Value, "Iniciado", "11");
                    }
                    else if (etapa == "33")
                    {
                        sn.guardaretapa(sig2, "34", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);
                        sn.cambiarestado(numcredito, "33");
                        string sig3 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                        sn.guardarfacturaabogado(sig3, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, Observaciones.Value, "Iniciado", "34");
                    }
                    else
                    {
                        sn.guardaretapa(sig2, "27", numcredito, sn.datetime(), "Enviado", idusuario, "51", ClienteNombre.Value, NumeroIncidente.Value);
                        sn.cambiarestado(numcredito, "25");
                        string sig3 = sn.siguiente("pj_facturacionabogado", "idpj_facturacionabogado");
                        sn.guardarfacturaabogado(sig3, numcredito, idusuario, NumFactura.Value, Serie.Value, Descripcion.Value, ImporteTotal.Value, FechaEmision.Value, ImporteCaso.Value, MotivoPago.SelectedValue, Otro.Value, NumCif.Value, ClienteNombre.Value, NombreCheque.Value, Observaciones.Value, "Iniciado", "27");
                    }


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
                    sn.insertarbitacora(sig5, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Recibido", "26", "51", fechahoraactual, fechacreacion2, Observaciones.Value);

                    string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig4, NumeroIncidente.Value, numcredito, ClienteNombre.Value, "Enviado", "51", "34", fechahoraactual, fechacreacion2, Observaciones.Value);


                    String script = "alert('Se guardó exitosamente'); window.location.href= 'PendienteFacturacionAbogado.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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