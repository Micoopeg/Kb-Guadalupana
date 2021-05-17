﻿using System;
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
    public partial class PresentacionDemanda : System.Web.UI.Page
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
                llenarformulario();
                llenarcombonotificador();
                llenarcombodepartamento();
                llenarcombooficial();
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
                        string numcredito = Session["credito"] as string;
                        string siguiente = sn.siguiente("pj_documento", "idpj_documento");
                        documento = "Subidos/Demanda/" + siguiente + '-' + FileUpload1.FileName;
                        string nombredoc = siguiente + '-' + FileUpload1.FileName;
                        sn.guardardocumentoexp(siguiente, PTipoDocumento.SelectedValue, documento, nombredoc, numcredito);
                        FileUpload1.SaveAs(Server.MapPath("Subidos/Demanda/" + siguiente + '-' + FileUpload1.FileName));
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras se sube el archivo');", true);
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
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_tipodocumento  WHERE idpj_tipodocumento = 16";
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

        public void llenarcombonotificador()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "SELECT * FROM pj_notificador";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                DataSet ds = new DataSet();
                myCommand.Fill(ds);
                Notificador.DataSource = ds;
                Notificador.DataTextField = "pj_nombrenotificador";
                Notificador.DataValueField = "idpj_notificador";
                Notificador.DataBind();
                Notificador.Items.Insert(0, new ListItem("[Notificador]", "0"));
            }
        }

        public void llenarcombodepartamento()
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_departamento";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Departamento.DataSource = ds;
                    Departamento.DataTextField = "pj_departamentonombre";
                    Departamento.DataValueField = "idpj_departamento";
                    Departamento.DataBind();
                    Departamento.Items.Insert(0, new ListItem("[Departamento]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pj_municipio WHERE idpj_departamento = '"+Departamento.SelectedValue+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Municipio.DataSource = ds;
                    Municipio.DataTextField = "pj_municipionombre";
                    Municipio.DataValueField = "idpj_municipio";
                    Municipio.DataBind();
                    Municipio.Items.Insert(0, new ListItem("[Municipio]", "0"));
                }
                catch
                {

                }
            }
            Guardar.Focus();
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string numcredito = Session["credito"] as string;

            string memorial = sn.tipodocumentoMemorial(numcredito);
            if (memorial == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir el memorial');", true);
            }
            else
            {
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string sig2 = sn.siguiente("pj_etapa_credito", "idpj_correlativo_etapa");

                string fechaactual = fechaText();

                string sig3 = sn.siguiente("pj_presentaciondemanda", "idpj_presentaciondemanda");
                sn.insertarpresentaciondemanda(sig3, NumIncidente.Value, fechaactual, numcredito, Oficial.SelectedValue, Notificador.SelectedValue, NumJuzgado.Value, NombreJuzgado.Value, Departamento.SelectedValue, Municipio.SelectedValue, idusuario);
                sn.guardaretapa(sig2, "4", numcredito, sn.datetime(), "Enviado", idusuario, "51", NombreCliente.Value);
                sn.cambiarestado(numcredito, "3");

                if (MedidasPre1.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "1", "Embargo de Salario", numcredito);
                }
                if (MedidasPre2.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "2", "Embargo de cuentas bancarias", numcredito);
                }
                if (MedidasPre3.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "3", "Arraigo", numcredito);
                }
                if (MedidasPre4.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "4", "Embargo en cooperativas", numcredito);
                }
                if (MedidasPre5.Checked)
                {
                    string sig6 = sn.siguiente("pj_asignacionmedidas", "idpj_asignacionmedidas");
                    sn.insertarmedidaspre(sig6, "5", OtrasMedidas.Value, numcredito);
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
                string año = fecha2[0];
                string mes = fecha2[1];
                string dia = fecha2[2];

                string hora = fechayhora[1];
                string fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;

                string sig5 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig5, NumIncidente.Value, numcredito, NombreCliente.Value, "Recibido", "34", "51", fechahoraactual, fechacreacion2, "Recibido");

                string sig4 = sn.siguiente("pj_bitacora", "idpj_bitacora");
                sn.insertarbitacora(sig4, NumIncidente.Value, numcredito, NombreCliente.Value, "Enviado", "51", "51", fechahoraactual, fechacreacion2, "Resolución de trámite");


                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se guardó exitosamente');", true);
            }
        }

        public string fechaText()
        {
            string fechahoraactual = "";
            try
            {
                string fechayhora = FechaPresentacion.Value;
                string[] fecha = fechayhora.Split('/');
                string dia = fecha[0];
                string mes = fecha[1];
                string año = fecha[2];

                fechahoraactual = año + '-' + mes + '-' + dia;
            }
            catch { }
            return fechahoraactual;
        }

        public string fechaactualBD()
        {
            string fechahoraactual = "";
            try
            {
                string[] fechayhora = sn.fechayhora();
                string[] fecha = fechayhora[0].Split(' ');
                string año = fecha[0];
                string mes = fecha[1];
                string dia = fecha[2];

                string hora = fechayhora[1];
                fechahoraactual = año + '-' + mes + '-' + dia + ' ' + hora;
            }
            catch { }
            return fechahoraactual;
        }

        public void llenarcombooficial()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                sqlCon.Open();
                string query = "SELECT * FROM pj_oficial";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                DataSet ds = new DataSet();
                myCommand.Fill(ds);
                Oficial.DataSource = ds;
                Oficial.DataTextField = "pj_nombre";
                Oficial.DataValueField = "idpj_oficial";
                Oficial.DataBind();
                Oficial.Items.Insert(0, new ListItem("[Oficial]", "0"));
            }
        }
    }
}