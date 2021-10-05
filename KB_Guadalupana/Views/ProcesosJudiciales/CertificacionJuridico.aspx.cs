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
        string documento = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcomentarios();
                llenargridviewdocumentos();
                llenarformulario();
                validado.Visible = false;
                Enviar.Visible = false;
                Documentos.Visible = false;
                GuardarC.Visible = false;
                OtroProceso.Visible = false;
                llenarcomboarea();
                llenarcombodocumento();
                llenarcomboabogado();
                llenarcombotipoproceso();
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

        public void llenarcomboarea()
        {
            AreaCredito.Items.Insert(0, new ListItem("[Área]", "0"));
            AreaCredito.Items.Insert(1, new ListItem("Cobros", "1"));
            AreaCredito.Items.Insert(2, new ListItem("Contabilidad", "2"));
        }

        public void llenarformulario()
        {
            string numcredito = Session["credito"] as string;
            string var1 = WS.buscarcredito(numcredito);
            char delimitador = '|';
            string[] campos = var1.Split(delimitador);

            if (var1.Length == 4)
            {
                String script = "alert('Se perdió la conexión, intente más tarde'); window.location.href= 'CreditosCertificacionJuridico.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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
                    CreditoNumero.Value = campos[1];
                    DPI.Value = campos[21];
                    CodigoCliente.Value = campos[19];
                    NumCif.Value = campos[19];
                    NombreCliente.Value = campos[20];
                    ClienteNombre.Value = campos[20];
                    MontoOriginal.Value = "Q " + campos[9];
                    CapitalDesem.Value = "Q " + campos[9];
                    //Interes1.Value = campos[16];
                    //Mora.Value = campos[14];
                    DescripcionDoc.Value = campos[24];
                    //Saldo1.Value = campos[15];
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
                        Saldo1.Value = "Q 0.00";
                    }
                    else
                    {
                        SaldoActual.Value = "Q " + campos[8];
                        Saldo1.Value = "Q " + campos[8];
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
                    NumeroIncidente.Value = campos3[0];
                    NumTarjeta.Value = campos3[1];
                    NumCuenta.Value = campos3[2];
                    CIF.Value = campos3[3];
                    PrimerNombre.Value = campos3[4];
                    SegundoNombre.Value = campos3[5];
                    OtroNombre.Value = campos3[6];
                    ApellidoCasada.Value = campos3[7];
                    PrimerApellido.Value = campos3[8];
                    SegundoApellido.Value = campos3[9];
                    Limite.Value = campos3[10];
                    Saldo.Value = campos3[11];
                    Gastos1.Value = campos3[13];
                    GastosJudiciales.Value = campos3[14];
                    OtrosGastos.Value = campos3[15];
                    Comentario.Value = campos3[16];
                    Total1.InnerText = "Q " + campos3[17];
                    Incendio.Value = campos3[20];
                    Interes1.Value = campos3[21];
                    Mora.Value = campos3[22];
                }
                credito.Visible = true;
                tarjeta.Visible = true;
            }
            else
            {
                Session["TipoCredito"] = "credito";
                for (int i = 0; i < campos2.Length; i++)
                {
                    NumIncidente.Value = campos2[0];
                    NumeroIncidente.Value = campos2[0];
                    Gastos1.Value = campos2[1];
                    GastosJudiciales.Value = campos2[2];
                    OtrosGastos.Value = campos2[3];
                    Total1.InnerHtml = "Q " + campos2[4];
                    Comentario.Value = campos2[5];
                    Incendio.Value = campos2[9];
                    Interes1.Value = campos2[10];
                    Mora.Value = campos2[11];
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

        protected void Regresar_Click(object sender, EventArgs e)
        {
            validado.Visible = true;
            Enviar.Visible = true;
            Validar.Visible = false;
            Regresar.Visible = false;
            Enviar.Focus();
        }

        protected void GuardarC_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;
            string sig = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");

            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            if (NombreAbogado.SelectedValue == "0" || TipoProceso.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe completar los datos');", true);
            }
            else
            {
                sn.guardaretapa(sig, "3", numcredito, sn.datetime(), "Enviado", idusuario, "34", NombreCliente.Value, NumIncidente.Value);
                sn.cambiarestado(numcredito, "2");

                if (MedidasPre1.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito, "1");
                }
                if (MedidasPre2.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito, "1");
                }
                if (MedidasPre3.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito, "1");
                }
                if (MedidasPre4.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito, "1");
                }
                if (MedidasPre6.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "6", OtrasMedidas.Value, numcredito, "1");
                }
                if (MedidasPre5.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "5", "Embargo de bienes", numcredito, "1");
                }

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

                if(TipoProceso.SelectedValue != "4")
                {
                    OtroProceso.Value = sn.tipoProceso(TipoProceso.SelectedValue);
                }

                string sig2 = sn.siguiente("pj_certificacionjuidico", "idpj_certificacionjuidico");
                sn.insertarcertificacionjuridico(sig2, NombreAbogado.SelectedValue, TipoProceso.SelectedValue, OtroProceso.Value, numcredito, idusuario, fechahoraactual, NombreCliente.Value, CodigoCliente.Value, ObservacionesCredito.Value);

                string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "28", "34", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);

                string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Pendiente reporte", "34", "34", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);


                String script = "alert('Se guardó exitosamente'); window.location.href= 'CreditosCertificacionJuridico.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            if(AreaCredito.SelectedValue == "" || Observaciones.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione un área');", true);
            }
            else
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

                if(AreaCredito.SelectedValue == "1")
                {
                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Devuelto", "34", "26", fechahoraactual, fechacreacion2, Observaciones.Value);

                    String script = "alert('El crédito regresa a Cobros'); window.location.href= 'CreditosCertificacionJuridico.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    string sig3 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                    sn.insertarbitacora(sig3, NumIncidente.Value, numcredito, NombreCliente.Value, "Devuelto", "34", "28", fechahoraactual, fechacreacion2, Observaciones.Value);

                    String script = "alert('El crédito regresa a Contabilidad'); window.location.href= 'CreditosCertificacionJuridico.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
           }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PTipoDocumento.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de dpcumento');", true);
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
                            documento = "Subidos/CertificacionContable/" + siguiente + '-' + FileUpload1.FileName;
                            string nombredoc = siguiente + '-' + FileUpload1.FileName;
                            sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                            FileUpload1.SaveAs(Server.MapPath("Subidos/CertificacionContable/" + siguiente + '-' + FileUpload1.FileName));
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
                            llenargridviewdocumentos();
                            Saldo1.Focus();
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
                Saldo1.Focus();
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
                    string query = "SELECT * FROM pj_tipodocumento WHERE idpj_tipodocumento = 14";
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

        //public void llenargridviewdocumentos2()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            string numcredito = Session["credito"] as string;
        //            sqlCon.Open();
        //            string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_documento.idpj_tipodocumento IN (14,15)";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataTable dt = new DataTable();
        //            myCommand.Fill(dt);
        //            gridViewDocumentos2.DataSource = dt;
        //            gridViewDocumentos2.DataBind();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void OnSelectedIndexChangedDocumento2(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString((gridViewDocumentos2.SelectedRow.FindControl("lblid") as Label).Text);
        //        string documentoselec = sn.obtenerrutadocumento(id);
        //        string FilePath = Server.MapPath(documentoselec);
        //        WebClient User = new WebClient();
        //        Byte[] FileBuffer = User.DownloadData(FilePath);
        //        if (FileBuffer != null)
        //        {
        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //            Response.BinaryWrite(FileBuffer);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        public void llenarcomboabogado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_abogado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    NombreAbogado.DataSource = ds;
                    NombreAbogado.DataTextField = "pj_nombreabogado";
                    NombreAbogado.DataValueField = "idpj_abogado";
                    NombreAbogado.DataBind();
                    NombreAbogado.Items.Insert(0, new ListItem("[Abogado]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombotipoproceso()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipoproceso";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoProceso.DataSource = ds;
                    TipoProceso.DataTextField = "pj_nombreproceso";
                    TipoProceso.DataValueField = "idpj_tipoproceso";
                    TipoProceso.DataBind();
                    TipoProceso.Items.Insert(0, new ListItem("[Tipo proceso]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void ValidarCredito_Click(object sender, EventArgs e)
        {
            Documentos.Visible = true;
            Enviar.Visible = false;
            Validar.Visible = false;
            Regresar.Visible = false;
            GuardarC.Visible = true;
            GuardarC.Focus();
        }

        protected void Nombreabogado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NumColgiado.Value = NombreAbogado.SelectedValue;
                GuardarC.Focus();
            }
            catch
            {

            }
        }

        protected void TipoProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoProceso.SelectedValue == "4")
            {
                OtroProceso.Visible = true;
                GuardarC.Focus();
            }
            else
            {
                OtroProceso.Visible = false;
                GuardarC.Focus();
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