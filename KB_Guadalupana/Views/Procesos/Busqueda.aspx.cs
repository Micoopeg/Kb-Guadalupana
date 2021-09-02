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
using System.Drawing;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class Busqueda : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string tipousuario = sn.tipousuario(idusuario);
                Session["nivel_usuario"] = tipousuario;
                string categoria2 = sn.categoriausuario(idusuario);
                Session["categoria_usuario"] = categoria2;
                string subcategoria = sn.subcategoriausuario(idusuario);
                Session["subcategoria_usuario"] = subcategoria;
                string subcategorianombre = sn.subcategoriausuarionombre(idusuario);

                NombreCategoria.InnerText = Session["nombre_categoria"] as string;
                NombreSubcategoria.InnerText = Session["nombre_subcategoria"] as string;
                string idsubcategoria = Session["id_subcategoria"] as string;
                string categoria = Session["id_categoria"] as string;
                color.InnerText = categoria;
                string iddocumento = Session["id_documento"] as string;
                string nivelusuario = Session["nivel_usuario"] as string;
                string subcategoriausuario = Session["subcategoria_usuario"] as string;
                string categoriausuario = Session["categoria_usuario"] as string;

                if (subcategoriausuario == idsubcategoria)
                {
                    llenarcombonombrenivel3();
                    llenargridviewdocumentosnivel3();
                }
                else if (subcategorianombre != "Ninguna")
                {
                    if(nivelusuario == "1")
                    {
                        llenarcombonombrenivel1();
                        llenargridviewdocumentosnivel1();
                    }
                    else if(nivelusuario == "2")
                    {
                        llenarcombonombrenivel2();
                        llenargridviewdocumentosnivel2();
                    }
                    else if(nivelusuario == "3")
                    {
                        llenarcombonombrenivel3();
                        llenargridviewdocumentosnivel3();
                    }
                }

               
            }
        }

        public void llenarcombonombrenivel1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string idsubcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT idpro_registro, pro_nombredocumento FROM pro_registro WHERE idpro_subcategoria = '"+idsubcategoria+ "' AND idpro_tipodocumento = '"+iddocumento+"' AND idpro_estado = 1 AND idpro_tipousuario = 1 AND idpro_restriccion = 1 AND idpro_origen = 1";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    NombreDocumento.DataSource = ds;
                    NombreDocumento.DataTextField = "pro_nombredocumento";
                    NombreDocumento.DataValueField = "idpro_registro";
                    NombreDocumento.DataBind();
                    NombreDocumento.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombonombrenivel2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string idsubcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT idpro_registro, pro_nombredocumento FROM pro_registro WHERE idpro_subcategoria = '" + idsubcategoria + "' AND idpro_tipodocumento = '" + iddocumento + "' AND idpro_estado IN (1,2) AND idpro_tipousuario IN (1,2) AND idpro_restriccion = 1 AND idpro_origen IN (1,2)";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    NombreDocumento.DataSource = ds;
                    NombreDocumento.DataTextField = "pro_nombredocumento";
                    NombreDocumento.DataValueField = "idpro_registro";
                    NombreDocumento.DataBind();
                    NombreDocumento.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        public void llenarcombonombrenivel3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string idsubcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT idpro_registro, pro_nombredocumento FROM pro_registro WHERE idpro_subcategoria = '" + idsubcategoria + "' AND idpro_tipodocumento = '" + iddocumento + "'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds);
                    NombreDocumento.DataSource = ds;
                    NombreDocumento.DataTextField = "pro_nombredocumento";
                    NombreDocumento.DataValueField = "idpro_registro";
                    NombreDocumento.DataBind();
                    NombreDocumento.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
                }
                catch
                {

                }
            }
        }

        protected void documento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDocumentos.PageIndex = e.NewPageIndex;
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string idsubcategoria = Session["id_subcategoria"] as string;
            string categoria = Session["id_categoria"] as string;
            string nivelusuario = Session["nivel_usuario"] as string;
            string subcategoriausuario = Session["subcategoria_usuario"] as string;
            string categoriausuario = Session["categoria_usuario"] as string;
            string subcategorianombre = sn.subcategoriausuarionombre(idusuario);


            if (subcategoriausuario == idsubcategoria)
            {
                llenarcombonombrenivel3();
                llenargridviewdocumentosnivel3();
            }
            else if (subcategorianombre != "Ninguna")
            {
                if (nivelusuario == "1")
                {
                    llenarcombonombrenivel1();
                    llenargridviewdocumentosnivel1();
                }
                else if (nivelusuario == "2")
                {
                    llenarcombonombrenivel2();
                    llenargridviewdocumentosnivel2();
                }
                else if (nivelusuario == "3")
                {
                    llenarcombonombrenivel3();
                    llenargridviewdocumentosnivel3();
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
                    else if (tipo.ToLower() == "docx")
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if (tipo.ToLower() == "xlsx" || tipo.ToLower() == "xls")
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if (tipo.ToLower() == "png")
                    {
                        Response.ContentType = "image/png";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else if (tipo.ToLower() == "jpeg" || tipo.ToLower() == "jpg")
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

        public void llenargridviewdocumentosnivel1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_subcategoria = '"+ subcategoria + "' AND A.idpro_tipodocumento = '" + iddocumento + "' AND A.idpro_estado = 1 AND A.idpro_tipousuario = 1 AND A.idpro_restriccion = 1 AND A.idpro_origen = 1";
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

        public void llenargridviewdocumentosnivel2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_subcategoria = '" + subcategoria + "' AND A.idpro_tipodocumento = '" + iddocumento + "' AND A.idpro_estado IN (1,2) AND A.idpro_tipousuario IN (1,2) AND A.idpro_restriccion = 1 AND A.idpro_origen IN (1,2)";
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

        public void llenargridviewdocumentosnivel3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["id_subcategoria"] as string;
                    string iddocumento = Session["id_documento"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, A.pro_fechaaprobacion AS Fecha, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen, E.pro_nombreusuario AS Usuario, F.pro_nombre AS Categoria, G.pro_nombreres AS Restriccion, H.pro_nombre AS Subcategoria FROM pro_registro AS A"
                                    + " INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F"
                                    + " ON F.idpro_categoria = A.idpro_categoria INNER JOIN pro_restriccion AS G ON A.idpro_restriccion = G.idpro_restriccion INNER JOIN pro_subcategoria AS H ON H.idpro_subcategoria = A.idpro_subcategoria WHERE A.idpro_subcategoria = '"+ subcategoria + "' AND A.idpro_tipodocumento = '" + iddocumento + "'";
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

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if(NombreDocumento.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe seleccionar nombre de documento');", true);
            }
            else
            {
                llenargridviewdocumentosnombre();
            }
        }

        public void llenargridviewdocumentosnombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["id_subcategoria"] as string;

                    string nombredo = sn.nombredoc(subcategoria, NombreDocumento.SelectedValue);
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_registro = '" + NombreDocumento.SelectedValue + "'";
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

        protected void VerTodo_Click(object sender, EventArgs e)
        {
            string usuario = Session["sesion_usuario"] as string;
            string idusuario = sn.obteneridusuario(usuario);
            string idsubcategoria = Session["id_subcategoria"] as string;
            string categoria = Session["id_categoria"] as string;
            string nivelusuario = Session["nivel_usuario"] as string;
            string subcategoriausuario = Session["subcategoria_usuario"] as string;
            string categoriausuario = Session["categoria_usuario"] as string;
            string subcategorianombre = sn.subcategoriausuarionombre(idusuario);


            if (subcategoriausuario == idsubcategoria)
            {
                llenarcombonombrenivel3();
                llenargridviewdocumentosnivel3();
            }
            else if (subcategorianombre != "Ninguna")
            {
                if (nivelusuario == "1")
                {
                    llenarcombonombrenivel1();
                    llenargridviewdocumentosnivel1();
                }
                else if (nivelusuario == "2")
                {
                    llenarcombonombrenivel2();
                    llenargridviewdocumentosnivel2();
                }
                else if (nivelusuario == "3")
                {
                    llenarcombonombrenivel3();
                    llenargridviewdocumentosnivel3();
                }
            }

        }
    }
}