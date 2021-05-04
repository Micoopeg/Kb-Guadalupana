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
    public partial class CertificacionJuridico : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewdocumentos();
                llenarformulario();
                validado.Visible = false;
                Enviar.Visible = false;
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
                    string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "'";
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
                    Agencia.Value = campos[29];
                    Instrumento.Value = campos[17];
                    LineaCredito.Value = campos[18];
                    destino.Value = campos[28];
                    Garantia.Value = campos[22];
                    Plazomeses.Value = campos[2];
                    //Metodocalculo.Value = campos[7];
                    Estado.Value = campos[23];
                    Moneda.Value = "Quetzales";
                    Tasa.Value = campos[13];
                    string[] fecha = campos[3].Split(' ');
                    FechaSolicitud.Value = fecha[0];
                    string[] fecha2 = campos[4].Split(' ');
                    FechaDesembolso1.Value = fecha2[0];
                    string[] fecha3 = campos[10].Split(' ');
                    FechaUltimoDes.Value = fecha3[0];
                    string[] fecha4 = campos[5].Split(' ');
                    FechaVencimiento.Value = fecha4[0];
                    string[] fecha5 = campos[7].Split(' ');
                    FechaUltimaCuota.Value = fecha5[0];
                    string[] fecha6 = campos[12].Split(' ');
                    FechaActa.Value = fecha6[0];
                    NumActa.Value = campos[11];
                    NumPrestamo.Value = campos[1];
                    DPI.Value = campos[21];
                    CodigoCliente.Value = campos[19];
                    NombreCliente.Value = campos[20];
                    MontoOriginal.Value = "Q " + campos[9];
                    CapitalDesem.Value = "Q " + campos[9];
                    Interes1.Value = campos[16];
                    Mora.Value = campos[14];
                    DescripcionDoc.Value = campos[24];
                    Saldo1.Value = campos[15];
                    //Gastos1.Value = campos[31];
                    //GastosJudiciales.Value = campos[32];
                    //OtrosGastos.Value = campos[33];


                    if (campos[25] == "VACIO")
                    {
                        Oficial1.Visible = false;
                        NombreOficial.Visible = false;
                    }
                    if (campos[26] == "VACIO")
                    {
                        Oficial2.Visible = false;
                        NombreOficial2.Visible = false;
                    }
                    if (campos[27] == "VACIO")
                    {
                        Oficial3.Visible = false;
                        NombreOficial3.Visible = false;
                    }

                    NombreOficial.Value = campos[25];
                    NombreOficial2.Value = campos[26];
                    NombreOficial3.Value = campos[27];

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
                tarjeta.Visible = true;
                credito.Visible = true;

                string[] campos3 = sn.obtenertipotarjeta(numcredito);
                for (int i = 0; i < campos3.Length; i++)
                {
                    NumIncidente.Value = campos3[0];
                    NumTarjeta.Value = campos3[1];
                    NumCuenta.Value = campos3[2];
                    CIF.Value = campos3[3];
                    PrimerNombre.Value = campos3[4];
                    SegundoNombre.Value = campos3[5];
                    OtroNombre.Value = campos3[6];
                    ApellidoCasada.Value = campos3[7];
                    PrimerApellido.Value = campos3[8];
                    SegundoApellido.Value = campos3[9];
                    Limite.Value = "Q " + campos3[10];
                    Saldo.Value = "Q " + campos3[11];
                    Gastos1.Value = campos3[13];
                    GastosJudiciales.Value = campos3[14];
                    OtrosGastos.Value = campos3[15];
                    Comentario.Value = campos3[16];
                    Total1.InnerText = "Q " + campos3[17];
                }

            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumIncidente.Value = campos2[0];
                    Gastos1.Value = campos2[1];
                    GastosJudiciales.Value =campos2[2];
                    OtrosGastos.Value = campos2[3];
                    Total1.InnerHtml = "Q " + campos2[4];
                    Comentario.Value = campos2[5];
                }
                credito.Visible = true;
                tarjeta.Visible = false;
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

        protected void Regresar_Click(object sender, EventArgs e)
        {
            validado.Visible = true;
            Enviar.Visible = true;
            Validar.Visible = false;
            Regresar.Visible = false;
        }

        protected void Validar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string sig = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");

            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            sn.guardaretapa(sig, "3", numcredito, sn.datetime(), "Enviado", idusuario, "34", NombreCliente.Value);
            sn.cambiarestado(numcredito, "2");

            string tipocredito = Session["TipoCredito"] as string;
            string id = "";
            string tabla = "";
            string fecha;

            if (tipocredito == "tarjeta")
            {
                id = "idpj_tipotarjeta";
                tabla = "pj_tipotarjeta";
                fecha = sn.fechacreaciontarjeta(numcredito);
            }
            else
            {
                id = "idpj_tipocredito";
                tabla = "pj_tipocredito";
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

            string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "28", "34", fechahoraactual, fechacreacion2, "Sin comentarios");

            string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "34", "52", fechahoraactual, fechacreacion2, "Sin comentarios");


            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se guardó exitosamente');", true);
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            string sig = sn.siguiente("pj_certificacionjuridicodevolver", "pj_certificacionjuridicodevolver");
            string numcredito = Session["credito"] as string;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            sn.devolvercertificacionjuridico(sig, numcredito, Observaciones.Value, idusuario);
            sn.estadodevuelto(numcredito, "34", "2");

            string tipocredito = Session["TipoCredito"] as string;
            string id = "";
            string tabla = "";
            string fecha;

            if (tipocredito == "tarjeta")
            {
                id = "idpj_tipotarjeta";
                tabla = "pj_tipotarjeta";
                fecha = sn.fechacreaciontarjeta(numcredito);
            }
            else
            {
                id = "idpj_tipocredito";
                tabla = "pj_tipocredito";
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

            string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "28", "34", fechahoraactual, fechacreacion2, "Sin comentarios");

            string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
            sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Devuelto", "34", "26", fechahoraactual, fechacreacion2, Observaciones.Value);

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El crédito regresa a Cobros');", true);
        }
    }
}