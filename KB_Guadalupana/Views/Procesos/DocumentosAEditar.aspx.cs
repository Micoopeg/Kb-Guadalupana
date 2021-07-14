using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class DocumentosAEditar : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string documento = "";
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewdocumentos();
            }
        }

        public void llenargridviewdocumentos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, A.pro_fechaaprobacion AS Fecha, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen, E.pro_nombreusuario AS Usuario, F.pro_nombre AS Categoria FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento "
                                    + "INNER JOIN pro_estado AS C ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria";
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

        protected void documento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDocumentos.PageIndex = e.NewPageIndex;
            llenargridviewdocumentos();
        }

        protected void OnSelectedIndexChangedDocumento(object sender, EventArgs e)
        {
            string id = Convert.ToString((gridViewDocumentos.SelectedRow.FindControl("lblid") as Label).Text);
            Session["id_documento"] = id;
            Response.Redirect("EditarDocumentos.aspx");
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            llenargridviewdocumentosnombre();
        }

        public void llenargridviewdocumentosnombre()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpro_registro AS Id, A.pro_codigo AS Codigo, B.pro_nombretipo AS TipoDocumento, A.pro_nombredocumento AS Nombre, A.pro_version AS Version, A.pro_fechaaprobacion AS Fecha, C.pro_estadonombre AS Estado, D.pro_origennombre AS Origen, E.pro_nombreusuario AS Usuario, F.pro_nombre AS Categoria FROM pro_registro AS A INNER JOIN pro_tipodocumento AS B ON B.idpro_tipodocumento = A.idpro_tipodocumento "
                                    + "INNER JOIN pro_estado AS C ON C.idpro_estado = A.idpro_estado INNER JOIN pro_origen AS D ON D.idpro_origen = A.idpro_origen INNER JOIN pro_tipousuario AS E ON E.idpro_tipousuario = A.idpro_tipousuario INNER JOIN pro_categoria AS F ON F.idpro_categoria = A.idpro_categoria WHERE A.pro_nombredocumento LIKE '%" + NombreDocumento.Value + "%'";
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
            llenargridviewdocumentos();
        }
    }
}