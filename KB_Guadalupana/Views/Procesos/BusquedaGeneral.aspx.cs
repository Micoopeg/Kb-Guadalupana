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

namespace KB_Guadalupana.Views.Procesos
{
    public partial class BusquedaGeneral : System.Web.UI.Page
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
                Session["nombrecategoria_usuario"] = sn.nombrecategoria(categoria2);
                string subcategoria = sn.subcategoriausuario(idusuario);
                Session["subcategoria_usuario"] = subcategoria;
                Session["nombresubcategoria_usuario"] = sn.nombresubcategoria(subcategoria);
                string subcategorianombre = sn.subcategoriausuarionombre(idusuario);

               if (subcategorianombre == "Ninguna")
                {
                    if (tipousuario == "1")
                    {
                        llenargridviewsubcategorian1();
                        llenargridviewareacategoria();
                    }
                    else if (tipousuario == "2")
                    {
                        llenargridviewsubcategorian2();
                        llenargridviewareacategoria();
                    }
                    else if (tipousuario == "3")
                    {
                        llenargridviewsubcategorian3();
                    }
                }
                else
                {
                    if (tipousuario == "1")
                    {
                        llenargridviewsubcategorian1();
                        llenargridviewareasubcategoria();
                    }
                    else if (tipousuario == "2")
                    {
                        llenargridviewsubcategorian2();
                        llenargridviewareasubcategoria();
                    }
                    else if (tipousuario == "3")
                    {
                        llenargridviewsubcategorian3();
                    }
                }
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if (NombreDocumento.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe seleccionar nombre de documento');", true);
            }
            else
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

                if (subcategorianombre == "Ninguna")
                {
                    if (tipousuario == "1")
                    {
                        llenargridviewsubcategorian1nombre();
                        llenargridviewareacategoria();
                        DocumentosArea.InnerText = Session["categoria_usuario"] as string;
                    }
                    else if (tipousuario == "2")
                    {
                        llenargridviewcategorian2nombre();
                        llenargridviewareacategoria();
                        DocumentosArea.InnerText = Session["categoria_usuario"] as string;
                    }
                    else if (tipousuario == "3")
                    {
                        llenargridviewsubcategorian3nombre();
                    }
                }
                else
                {
                    if (tipousuario == "1")
                    {
                        llenargridviewsubcategorian1nombre();
                        llenargridviewareasubcategoria();
                        DocumentosArea.InnerText = Session["subcategoria_usuario"] as string;
                    }
                    else if (tipousuario == "2")
                    {
                        llenargridviewcategorian2nombre();
                        llenargridviewareasubcategoria();
                        DocumentosArea.InnerText = Session["subcategoria_usuario"] as string;
                    }
                    else if (tipousuario == "3")
                    {
                        llenargridviewsubcategorian3nombre();
                    }
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

        protected void documento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDocumentos.PageIndex = e.NewPageIndex;
            //llenargridviewdocumentos();
        }

        public void llenargridviewsubcategorian1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_estado = 1 AND A.idpro_tipousuario = 1 AND A.idpro_restriccion = 1 AND A.idpro_origen = 1";
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

        public void llenargridviewsubcategorian2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_estado IN (1,2) AND A.idpro_tipousuario IN (1,2) AND A.idpro_restriccion = 1 AND A.idpro_origen IN (1,2)";
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

        public void llenargridviewsubcategorian3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria";
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

        public void llenargridviewareacategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '"+categoria+"'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewArea.DataSource = dt;
                    gridViewArea.DataBind();
                    if (gridViewArea.Rows.Count != 0)
                    {
                        DocumentosArea.InnerText = Session["nombrecategoria_usuario"] as string;
                    }
                }
                catch
                {

                }
            }
        }

        public void llenargridviewareacategorianombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '" + categoria + "' AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewArea.DataSource = dt;
                    gridViewArea.DataBind();
                }
                catch
                {

                }
            }
        }
        public void llenargridviewareasubcategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_subcategoria = '" + subcategoria + "'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewArea.DataSource = dt;
                    gridViewArea.DataBind();
                    if (gridViewArea.Rows.Count != 0)
                    {
                        DocumentosArea.InnerText = Session["nombresubcategoria_usuario"] as string;
                    }

                }
                catch
                {

                }
            }
        }

        public void llenargridviewareasubcategorianombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_subcategoria = '" + subcategoria + "' AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewArea.DataSource = dt;
                    gridViewArea.DataBind();
                }
                catch
                {

                }
            }
        }


        protected void OnSelectedIndexChangedArea(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString((gridViewArea.SelectedRow.FindControl("lblid") as Label).Text);
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

        protected void area_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewArea.PageIndex = e.NewPageIndex;
            //llenargridviewdocumentos();
        }



        public void llenargridviewcategorian1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '" + categoria + "' AND A.idpro_estado = 1 AND A.idpro_tipousuario = 1 AND idpro_restriccion = 1 AND idpro_origen = 1";
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

        public void llenargridviewcategorian2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '" + categoria + "' AND idpro_estado IN (1,2) AND idpro_tipousuario IN (1,2) AND idpro_restriccion = 1 AND idpro_origen IN (1,2)";
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

        public void llenargridviewdocumentosnombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.pro_nombredocumento LIKE '%"+NombreDocumento.Value+"%'";
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

        public void llenargridviewsubcategorian1nombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_estado = 1 AND A.idpro_tipousuario = 1 AND idpro_restriccion = 1 AND idpro_origen = 1 AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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

        public void llenargridviewsubcategorian2nombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE idpro_estado IN (1,2) AND idpro_tipousuario IN (1,2) AND idpro_restriccion = 1 AND idpro_origen IN (1,2) AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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

        public void llenargridviewsubcategorian3nombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string subcategoria = Session["subcategoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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

        public void llenargridviewcategorian1nombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '" + categoria + "' AND A.idpro_estado = 1 AND A.idpro_tipousuario = 1 AND idpro_restriccion = 1 AND idpro_origen = 1 AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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

        public void llenargridviewcategorian2nombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string categoria = Session["categoria_usuario"] as string;
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento INNER JOIN pro_estado AS C "
                                    + "ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.idpro_categoria = '" + categoria + "' AND idpro_estado IN (1,2) AND idpro_tipousuario IN (1,2) AND idpro_restriccion = 1 AND idpro_origen IN (1,2) AND A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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
            string tipousuario = sn.tipousuario(idusuario);
            Session["nivel_usuario"] = tipousuario;
            string categoria2 = sn.categoriausuario(idusuario);
            Session["categoria_usuario"] = categoria2;
            string subcategoria = sn.subcategoriausuario(idusuario);
            Session["subcategoria_usuario"] = subcategoria;
            string subcategorianombre = sn.subcategoriausuarionombre(idusuario);

            if (subcategorianombre == "Ninguna")
            {
                if (tipousuario == "1")
                {
                    llenargridviewsubcategorian1();
                    llenargridviewareacategoria();
                    DocumentosArea.InnerText = Session["categoria_usuario"] as string;
                }
                else if (tipousuario == "2")
                {
                    llenargridviewsubcategorian2();
                    llenargridviewareacategoria();
                    DocumentosArea.InnerText = Session["categoria_usuario"] as string;
                }
                else if (tipousuario == "3")
                {
                    llenargridviewsubcategorian3();
                }
            }
            else
            {
                if (tipousuario == "1")
                {
                    llenargridviewsubcategorian1();
                    llenargridviewareasubcategoria();
                    DocumentosArea.InnerText = Session["subcategoria_usuario"] as string;
                }
                else if (tipousuario == "2")
                {
                    llenargridviewsubcategorian2();
                    llenargridviewareasubcategoria();
                    DocumentosArea.InnerText = Session["subcategoria_usuario"] as string;
                }
                else if (tipousuario == "3")
                {
                    llenargridviewsubcategorian3();
                }
            }
        }
    }
}