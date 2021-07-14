using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class RegistroDocumento : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombodocumento();
                llenarcomboestado();
                llenarcomboorigen();
                llenarcombousuario();
                llenarcombocategoria();
                llenarcomborestriccion();
                llenargridviewdocumentos();
                //Session["sesion_usuario"] = "pgaortiz";
            }
        }

        public void llenarcombodocumento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_tipodocumento";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoDocumento.DataSource = ds;
                    TipoDocumento.DataTextField = "pro_nombretipo";
                    TipoDocumento.DataValueField = "idpro_tipodocumento";
                    TipoDocumento.DataBind();
                    TipoDocumento.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboestado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_estado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Estado.DataSource = ds;
                    Estado.DataTextField = "pro_estadonombre";
                    Estado.DataValueField = "idpro_estado";
                    Estado.DataBind();
                    Estado.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcomboorigen()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_origen";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Origen.DataSource = ds;
                    Origen.DataTextField = "pro_origennombre";
                    Origen.DataValueField = "idpro_origen";
                    Origen.DataBind();
                    Origen.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_tipousuario";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    UsuarioDirigido.DataSource = ds;
                    UsuarioDirigido.DataTextField = "pro_nombreusuario";
                    UsuarioDirigido.DataValueField = "idpro_tipousuario";
                    UsuarioDirigido.DataBind();
                    UsuarioDirigido.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombocategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_categoria";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Categoria.DataSource = ds;
                    Categoria.DataTextField = "pro_nombre";
                    Categoria.DataValueField = "idpro_categoria";
                    Categoria.DataBind();
                    Categoria.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombosubcategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpro_subcategoria, pro_nombre FROM pro_subcategoria WHERE idpro_categoria = '"+Categoria.SelectedValue+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    Subcategoria.DataSource = ds;
                    Subcategoria.DataTextField = "pro_nombre";
                    Subcategoria.DataValueField = "idpro_subcategoria";
                    Subcategoria.DataBind();
                    Subcategoria.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void documento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDocumentos.PageIndex = e.NewPageIndex;
            llenargridviewdocumentos();
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
                    else if(tipo.ToLower() == "docx")
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if(tipo.ToLower() == "xls" || tipo.ToLower() == "xlsx")
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if(tipo.ToLower() == "png")
                    {
                        Response.ContentType = "image/png";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if(tipo.ToLower() == "jpeg" || tipo.ToLower() == "jpg")
                    {
                        Response.ContentType = "image/jpeg";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
            }
            catch
            {

            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (File.Exists(Server.MapPath("Subidos/" + FileUpload1.FileName)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El documento ya existe, cambie el nombre del archivo');", true);
                }
                else
                {
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                    ext = ext.ToLower();

                    if (ext == ".pdf" || ext == ".tiff" || ext == ".tif" || ext == ".docx" || ext == ".xlsx" || ext == ".xls" || ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                    {
                        string siguiente = sn.siguiente("pro_registro", "idpro_registro");
                        documento = "Subidos/" + siguiente + '-' + FileUpload1.FileName;
                        string nombredoc = siguiente + '-' + FileUpload1.FileName;
                        string usuario = Session["sesion_usuario"] as string;
                        string idusuario = sn.obteneridusuario(usuario);
                        sn.insertardocumento(siguiente, TipoDocumento.SelectedValue, Codigo.Value, NombreDocumento.Value, nombredoc, documento, Version.Value, FechaAprobacion.Value, Estado.SelectedValue, Origen.SelectedValue, UsuarioDirigido.SelectedValue, Categoria.SelectedValue, Subcategoria.SelectedValue, idusuario, TipoRestriccion.SelectedValue);
                        FileUpload1.SaveAs(Server.MapPath("Subidos/" + siguiente + '-' + FileUpload1.FileName));
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se guardó el documento exitosamente');", true);
                        llenargridviewdocumentos();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Formato no permitido');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe subir un archivo');", true);
            }
        }

        public void llenargridviewdocumentos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, A.pro_fechaaprobacion AS Fecha, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen, E.pro_nombreusuario AS Usuario, F.pro_nombre AS Categoria, G.pro_nombreres AS Restriccion, H.pro_nombre AS Subcategoria FROM pro_registro AS A"
                                    + " INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F"
                                    + " ON F.idpro_categoria = A.idpro_categoria INNER JOIN pro_restriccion AS G ON A.idpro_restriccion = G.idpro_restriccion INNER JOIN pro_subcategoria AS H ON H.idpro_subcategoria = A.idpro_subcategoria";
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

        protected void Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombosubcategoria();
        }

        public void llenarcomborestriccion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM pro_restriccion";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    TipoRestriccion.DataSource = ds;
                    TipoRestriccion.DataTextField = "pro_nombreres";
                    TipoRestriccion.DataValueField = "idpro_restriccion";
                    TipoRestriccion.DataBind();
                    TipoRestriccion.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }
    }
}