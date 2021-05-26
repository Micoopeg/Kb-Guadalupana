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
            if (!IsPostBack)
            {
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

            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No hay datos para generar');", true);
            }
            else
            {
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
            }
        }

        private DataTable obtenerdatos()
        {
            DataTable dt = new DataTable();

            dt = sn.reporteabogados2(Abogados.SelectedValue);

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
            dt = sn.reporteabogados3(Abogados.SelectedValue);

            if (Abogados.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe generar reporte antes');", true);
            }
            else if(FechaEntrega.Value == "")
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
                        sn.insertarreporteabogado(sig3, idusuario, FechaEntrega.Value, PTipoDocumento.SelectedValue, documento, nombredoc);

                        string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");


                        string numeroc = "";
                        string nombrec = "";

                        string credito2;
                        string nombre2;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            credito2 = dt.Rows[i]["Credito"].ToString();
                            nombre2 = dt.Rows[i]["Nombre"].ToString();
                            sn.cambiarestado(credito2, "3");
                            sn.guardaretapa(sig2, "4", credito2, sn.datetime(), "Enviado", idusuario, "34", nombre2);
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
    }
}