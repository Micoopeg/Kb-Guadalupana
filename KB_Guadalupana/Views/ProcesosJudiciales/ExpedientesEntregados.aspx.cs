using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class ExpedientesEntregados : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        string documento = "";
        string[] credito;
        string[] nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreusuario = Session["Nombre"] as string;
            NombreUsuario.InnerHtml = nombreusuario;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            string area = sn.area(idusuario);
            string rol = sn.rolusuario(idusuario);

            //if (rol == "1")
            //{
            //    if (area == "26")
            //    {
            //        MenuCobros.Visible = true;
            //        Cobros.Visible = true;
            //        MenuConta.Visible = false;
            //        MenuJuridico.Visible = false;
            //        MenuAbogado.Visible = false;
            //        MenuAsistente.Visible = false;
            //    }
            //    else if (area == "28")
            //    {
            //        MenuCobros.Visible = false;
            //        MenuConta.Visible = true;
            //        Certificacion.Visible = true;
            //        Solicitud.Visible = false;
            //        MenuJuridico.Visible = false;
            //        MenuAbogado.Visible = false;
            //        MenuAsistente.Visible = false;
            //    }
            //    else if (area == "34")
            //    {
            //        MenuCobros.Visible = false;
            //        MenuConta.Visible = false;
            //        MenuJuridico.Visible = true;
            //        Expedientes.Visible = true;
            //        Reporte.Visible = false;
            //        MenuAbogado.Visible = false;
            //        MenuAsistente.Visible = false;
            //    }
            //}
            //else
            //{
            //    MenuCobros.Visible = true;
            //    Cobros.Visible = true;
            //    MenuConta.Visible = true;
            //    Certificacion.Visible = true;
            //    MenuJuridico.Visible = true;
            //    Expedientes.Visible = true;
            //    Solicitud.Visible = false;
            //    MenuAbogado.Visible = false;
            //    MenuAsistente.Visible = false;
            //    Reporte.Visible = false;
            //}
            if (!IsPostBack)
            {
                AreaReporte.Visible = false;
                ReporteSubir.Visible = false;
                Guardar.Visible = false;
                llenarcomboabogados();
                llenarcombodocumento();

                string sig3 = sn.siguiente("pj_reporteabogado", "idpj_reporteabogado");
                NumReporte.Value = sig3;
            }
        }

        //protected void agregar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (PTipoDocumento.SelectedValue == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione tipo de documento');", true);
        //        }
        //        else
        //        {


        //            if (FileUpload1.HasFile)
        //            {
        //                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
        //                ext = ext.ToLower();

        //                if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
        //                {
        //                    string numcredito = Session["credito"] as string;
        //                    string siguiente = sn.siguiente("pj_documento", "idpj_documento");
        //                    documento = "Subidos/ReporteAbogado/" + siguiente + '-' + FileUpload1.FileName;
        //                    string nombredoc = siguiente + '-' + FileUpload1.FileName;
        //                    sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
        //                    FileUpload1.SaveAs(Server.MapPath("Subidos/ReporteAbogado/" + siguiente + '-' + FileUpload1.FileName));
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
        //                    llenargridviewdocumentos();
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
        //            }
        //        }
        //        Guardar.Focus();
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void llenargridviewdocumentos()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
        //    {
        //        try
        //        {
        //            string numcredito = Session["credito"] as string;
        //            sqlCon.Open();
        //            string query = "SELECT pj_documento.idpj_documento AS Codigo, pj_tipodocumento.pj_nombretipodoc AS TipoDocumento, pj_documento.pj_nombrearchivo AS Nombre FROM pj_documento INNER JOIN pj_tipodocumento ON pj_documento.idpj_tipodocumento = pj_tipodocumento.idpj_tipodocumento WHERE idpj_credito = '" + numcredito + "' AND pj_tipodocumento.idpj_tipodocumento = 19";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
        //            DataTable dt = new DataTable();
        //            myCommand.Fill(dt);
        //            gridViewDocumentos.DataSource = dt;
        //            gridViewDocumentos.DataBind();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        //protected void OnSelectedIndexChangedDocumento(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString((gridViewDocumentos.SelectedRow.FindControl("lblid") as Label).Text);
        //        string documentoselec = sn.obtenerrutadocumento(id);

        //        string nombrearchivo = sn.nombrearchivo(id);
        //        string[] extension = nombrearchivo.Split('.');
        //        int tamaño = extension.Length;
        //        string tipo = extension[tamaño - 1];

        //        string FilePath = Server.MapPath(documentoselec);
        //        WebClient User = new WebClient();
        //        Byte[] FileBuffer = User.DownloadData(FilePath);
        //        if (FileBuffer != null)
        //        {
        //            if (tipo.ToLower() == "pdf")
        //            {
        //                Response.ContentType = "application/pdf";
        //                Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //                Response.BinaryWrite(FileBuffer);
        //            }
        //            else if (tipo.ToLower() == "tif" || tipo.ToLower() == "tiff")
        //            {
        //                Response.ContentType = "image/tiff";
        //                Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //                Response.BinaryWrite(FileBuffer);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        public void llenarcomboabogados()
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
                    Abogados.DataSource = ds;
                    Abogados.DataTextField = "pj_nombreabogado";
                    Abogados.DataValueField = "idpj_abogado";
                    Abogados.DataBind();
                    Abogados.Items.Insert(0, new ListItem("[Abogado]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Generar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sn.reporteabogados3(Abogados.SelectedValue);

            DataTable dt2 = new DataTable();
            dt2 = sn.reporteabogados3Todo(Abogados.SelectedValue, Fecha.Value);


            DataTable dt3 = new DataTable();
            dt3 = sn.reporteabogados3Fecha(Fecha.Value);

            string credito2;
            string nombre2;
            string incidente;

            string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");

            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            if (Abogados.SelectedValue != "0" && Fecha.Value != "")
            {
                if (dt2.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No hay datos para generar');", true);
                }
                else
                {
                    Session["tabla"] = "Todo";
                    ReporteAbogados.Reset();
                    ReportDataSource fuente = new ReportDataSource("DataSetAbogado2", obtenerdatos());
                    ReportDataSource fuente2 = new ReportDataSource("DataSetFecha", fechaactual());
                    ReportDataSource fuente3 = new ReportDataSource("DataSetNombre", nombreabogado());
                    ReportDataSource fuente4 = new ReportDataSource("DataSetDpi", dpi());
                    ReportDataSource fuente5 = new ReportDataSource("DataSetNombreUsuario", nombreusuario());

                    ReporteAbogados.LocalReport.DataSources.Add(fuente);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente2);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente3);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente4);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente5);
                    ReporteAbogados.LocalReport.ReportPath = "Views/ProcesosJudiciales/Reportes/Report1.rdlc";
                    ReporteAbogados.LocalReport.Refresh();


                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        credito2 = dt2.Rows[i]["Credito"].ToString();
                        nombre2 = dt2.Rows[i]["Nombre"].ToString();
                        incidente = dt2.Rows[i]["Incidente"].ToString();
                        sn.cambiarestado(credito2, "3");
                        sn.guardaretapa(sig2, "4", credito2, sn.datetime(), "Pendiente", idusuario, "34", nombre2, incidente);
                    }
                }
            }
            else if(Abogados.SelectedValue != "0" && Fecha.Value == "")
            {
                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No hay datos para generar');", true);
                }
                else
                {
                    Session["tabla"] = "Abogado";
                    ReporteAbogados.Reset();
                    ReportDataSource fuente = new ReportDataSource("DataSetAbogado1", obtenerdatosAbogado());
                    ReportDataSource fuente2 = new ReportDataSource("DataSetFecha", fechaactual());
                    ReportDataSource fuente3 = new ReportDataSource("DataSetNombreAbogado", nombreabogado());

                    ReporteAbogados.LocalReport.DataSources.Add(fuente);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente2);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente3);
                    ReporteAbogados.LocalReport.ReportPath = "Views/ProcesosJudiciales/Reportes/ReportAbogado.rdlc";
                    ReporteAbogados.LocalReport.Refresh();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        credito2 = dt.Rows[i]["Credito"].ToString();
                        nombre2 = dt.Rows[i]["Nombre"].ToString();
                        incidente = dt.Rows[i]["Incidente"].ToString();
                        sn.cambiarestado(credito2, "3");
                        sn.guardaretapa(sig2, "4", credito2, sn.datetime(), "Pendiente", idusuario, "34", nombre2, incidente);
                    }
                }
            }
            else if (Abogados.SelectedValue == "0" && Fecha.Value != "")
            {
                if (dt3.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No hay datos para generar');", true);
                }
                else
                {
                    Session["tabla"] = "Fecha";
                    ReporteAbogados.Reset();
                    ReportDataSource fuente = new ReportDataSource("DataSetAbgadoSoloFecha", obtenerdatosFecha());
                    ReportDataSource fuente2 = new ReportDataSource("DataSetFecha", fechaactual());

                    ReporteAbogados.LocalReport.DataSources.Add(fuente);
                    ReporteAbogados.LocalReport.DataSources.Add(fuente2);
                    ReporteAbogados.LocalReport.ReportPath = "Views/ProcesosJudiciales/Reportes/ReportFecha.rdlc";
                    ReporteAbogados.LocalReport.Refresh();

                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        credito2 = dt3.Rows[i]["Credito"].ToString();
                        nombre2 = dt3.Rows[i]["Nombre"].ToString();
                        incidente = dt3.Rows[i]["Incidente"].ToString();
                        sn.cambiarestado(credito2, "3");
                        sn.guardaretapa(sig2, "4", credito2, sn.datetime(), "Pendiente", idusuario, "34", nombre2, incidente);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe seleccionar un filtro');", true);
            }

        }

        private DataTable obtenerdatos()
        {
            DataTable dt = new DataTable();

            dt = sn.reporteabogados2(Abogados.SelectedValue, Fecha.Value);

            return dt;
        }

        private DataTable obtenerdatosAbogado()
        {
            DataTable dt = new DataTable();

            dt = sn.reporteabogadosNombre(Abogados.SelectedValue);

            return dt;
        }

        private DataTable obtenerdatosFecha()
        {
            DataTable dt = new DataTable();

            dt = sn.reporteabogadosFecha(Fecha.Value);

            return dt;
        }

        private DataTable fechaactual()
        {
            DataTable dt = new DataTable();

            dt = sn.fechaactual();

            return dt;
        }

        private DataTable nombreabogado()
        {
            DataTable dt = new DataTable();

            dt = sn.nombreabogado(Abogados.SelectedValue);

            return dt;
        }

        private DataTable dpi()
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            DataTable dt = new DataTable();

            dt = sn.dpi(idusuario);

            return dt;
        }

        private DataTable nombreusuario()
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);

            DataTable dt = new DataTable();

            dt = sn.nombreUsuario(idusuario);

            return dt;
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 19";
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

        protected void Guardar_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            string tabla;
            tabla = Session["tabla"] as string;

            dt = sn.actualizarcreditosreporte();
         

           if(FechaEntrega.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete los datos');", true);
            }
            else if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No hay datos para generar');", true);
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                    ext = ext.ToLower();

                    if (ext == ".pdf" || ext == ".tiff" || ext == ".tif")
                    {
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/ReporteAbogado/" + siguiente + '-' + FileUpload1.FileName;
                        string nombredoc = siguiente + '-' + FileUpload1.FileName;
                        FileUpload1.SaveAs(Server.MapPath("Subidos/ReporteAbogado/" + siguiente + '-' + FileUpload1.FileName));


                        string usuario = Session["sesion_usuario"] as string;
                        string idusuario = sn.obteneridusuario(usuario);
                        string sig3 = sn.siguiente("pj_reporteabogado", "idpj_reporteabogado");
                        sn.insertarreporteabogado(sig3, idusuario, FechaEntrega.Value, PTipoDocumento.SelectedValue, documento, nombredoc, ObservacionesCredito.Value);

                        string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");


                        string numeroc = "";
                        string nombrec = "";

                        string[] fechayhora = sn.fechayhora();
                        string[] fecha2 = fechayhora[0].Split(' ');
                        string año = fecha2[0];
                        string mes = fecha2[1];
                        string dia = fecha2[2];

                        string hora = fechayhora[1];
                        string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                        string credito2;
                        string nombre2;
                        string incidente;
                        string fecha;
                        string fechacreacion2;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            credito2 = dt.Rows[i]["Credito"].ToString();
                            nombre2 = dt.Rows[i]["Nombre"].ToString();
                            incidente = dt.Rows[i]["Incidente"].ToString();

                            string[] campos2 = sn.obtenertipocredito(credito2);
                            string idcredito = campos2[0];
                            if (idcredito == null)
                            {
                                fecha = sn.fechacreaciontarjeta(credito2);
                                string[] fechaseparada = fecha.Split(' ');
                                string[] fechacreacion = fechaseparada[0].Split('/');
                                string diacreacion = fechacreacion[0];
                                string mescreacion = fechacreacion[1];
                                string añocreacion = fechacreacion[2];

                                string horacreacion = fechaseparada[1];

                                fechacreacion2 = añocreacion + '-' + mescreacion + '-' + diacreacion + ' ' + horacreacion;
                            }
                            else
                            {
                                fecha = sn.fechacreacioncredito(credito2);
                                string[] fechaseparada = fecha.Split(' ');
                                string[] fechacreacion = fechaseparada[0].Split('/');
                                string diacreacion = fechacreacion[0];
                                string mescreacion = fechacreacion[1];
                                string añocreacion = fechacreacion[2];

                                string horacreacion = fechaseparada[1];

                                fechacreacion2 = añocreacion + '-' + mescreacion + '-' + diacreacion + ' ' + horacreacion;
                            }

                            sn.actualizaretapareporte(credito2, "4");
                            string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                            sn.insertarbitacora(sig5, incidente, credito2, nombre2, "Enviado", "34", "51", fechahoraactual, fechacreacion2, ObservacionesCredito.Value);
                        }

                        String script = "alert('Se guardó exitosamente'); window.location.href= 'MenuPrincipalProcesos.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo debe ser en formato pdf o tif');", true);
                    }
                }

            }
        }

        protected void GenerarNuevoReporte_Click(object sender, EventArgs e)
        {
            AreaReporte.Visible = true;
            ReporteSubir.Visible = false;
            Guardar.Visible = false;
            Opciones.Visible = false;
        }

        protected void SubirReporte_Click(object sender, EventArgs e)
        {
            AreaReporte.Visible = false;
            ReporteSubir.Visible = true;
            Guardar.Visible = true;
            Opciones.Visible = false;
        }
    }
}