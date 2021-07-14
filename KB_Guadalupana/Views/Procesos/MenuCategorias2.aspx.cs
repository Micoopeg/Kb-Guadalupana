using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace KB_Guadalupana.Views.Procesos
{
    public partial class MenuCategorias2 : System.Web.UI.Page
    {
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string[] usuarioregistro = sn.obtenerusuarioregistro(idusuario);

                if (usuarioregistro[0] == "" || usuarioregistro[0] == null)
                {
                    String script2 = "alert('Solicitar con procesos acceso al sistema'); window.location.href= '../Sesion/MenuBarra.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
                }
                else
                {
                    llenarrepeatercategoria();
                    string tipousuario = sn.tipousuario(idusuario);
                    Session["nivel_usuario"] = tipousuario;
                    string categoria2 = sn.categoriausuario(idusuario);
                    Session["categoria_usuario"] = categoria2;
                    string subcategoria = sn.subcategoriausuario(idusuario);
                    Session["subcategoria_usuario"] = subcategoria;
                    color.InnerText = categoria2;
                }
            }
            
        }

        public void llenarrepeatercategoria()
        {
            DataSet categoria = new DataSet();
            categoria = sn.categorias();
            RepeaterCategoria.DataSource = categoria;
            RepeaterCategoria.DataBind();
        }

        protected void RepeaterCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string prueba = sender.ToString();
                Repeater r = e.Item.FindControl("RepeaterSubcategoria") as Repeater;
                Button btn = (Button)e.Item.FindControl("BotonCategoria");
                Button btn2 = (Button)e.Item.FindControl("Documento");
                string idcategoria = sn.idcategoria(btn.Text);
                DataSet ds2 = sn.subcategorias1(idcategoria);
                DataSet ds3 = sn.documentosSub(idcategoria);
                //string tipo = ds2.Tables[0].Rows[0][0].ToString();

                if (r != null)
                {
                    if (ds2.Tables[0].Rows[0][0].ToString() == "Ninguna")
                    {
                        r.DataSource = ds3;
                        r.DataBind();
                    }
                    else
                    {
                        r.DataSource = ds2;
                        r.DataBind();
                    }
                }
                Session["nombre_categoria"] = btn.Text;
            }
            
        }

        protected void RepeaterSubcategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater r = e.Item.FindControl("RepeaterDocumento") as Repeater;
            Button btn = (Button)e.Item.FindControl("BotonSubcategoria");
            string subcategoria = btn.Text;
            string idsubcategoria = sn.idsubcategoria(subcategoria);
            DataSet ds2 = sn.documentos(idsubcategoria);
            string[] documentos = sn.obtenerdocumentos(idsubcategoria);
            int cont= 0;

            if (r != null)
            {
                for(int i = 0; i < documentos.Length; i++)
                {
                    if (subcategoria == documentos[i])
                    {
                        cont = 1;
                        break;
                    }
                    else
                    {
                        cont = 2;
                    }
                }

                if(cont != 1)
                {
                    r.DataSource = ds2;
                    r.DataBind();
                }
            }
            Session["nombre_subcategoria"] = btn.Text;
        }

        //protected void documento_Click(object sender, EventArgs e)
        //{
        //    HtmlButton btn = (HtmlButton)FindControl("BotonSubcategoria");
        //    HtmlButton btn2 = (HtmlButton)FindControl("BotonCategoria");
        //}

        protected void categoria_Click(object sender, EventArgs e)
        {
            string prueba;
            prueba = "1";
        }

        protected void documento2_Click(object sender, EventArgs e)
        {
            string idc, idcat, idsub, nombrecategoria, nombresubcategoria, iddocumento;
            Button btn3 = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn3.NamingContainer;
            idc = ((Button)item.FindControl("Documento")).Text;
            idcat = ((Button)item.FindControl("IdCategoria")).Text;
            idsub = ((Button)item.FindControl("IdSubcategoria")).Text;
            iddocumento = ((Button)item.FindControl("IdDocumento")).Text;
            nombrecategoria = sn.nombrecategoria(idcat);
            nombresubcategoria = sn.nombresubcategoria(idsub);

            Session["nombre_categoria"] = nombrecategoria;
            Session["id_categoria"] = idcat;
            Session["nombre_subcategoria"] = nombresubcategoria;
            Session["id_subcategoria"] = idsub;
            Session["nombre_documento"] = idc;
            Session["id_documento"] = iddocumento;

            Response.Redirect("Busqueda.aspx");
            //string categoria = Session["nombre_categoria"] as string;
            //string subcategoria = Session["nombre_subcategoria"] as string;
            //Button btn = (Button)e.Item.FindControl("BotonSubcategoria");
            //categoria = RepeaterCategoria.Items.ToString();
            //HtmlButton btn2 = (HtmlButton) FindControl("Documento");
            //string prueba;
            //prueba = btn2.InnerText;
            //prueba = "1";
        }

        protected void documentoSub_Click(object sender, EventArgs e)
        {
            string idc, idcat, idsub, nombrecategoria, nombresubcategoria, iddocumento;
            Button btn3 = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn3.NamingContainer;
            idc = ((Button)item.FindControl("BotonSubcategoria")).Text;
            idcat = ((Button)item.FindControl("IdCategoria2")).Text;
            idsub = ((Button)item.FindControl("IdSubcategoria2")).Text;
            iddocumento = ((Button)item.FindControl("IdDocumento2")).Text;
            nombrecategoria = sn.nombrecategoria(idcat);

            Session["nombre_categoria"] = nombrecategoria;
            Session["id_categoria"] = idcat;
            Session["nombre_documento"] = idc;
            Session["id_documento"] = iddocumento;

            string[] documentos = sn.obtenerdocumentos(idsub);
            int cont = 0;

            for (int i = 0; i < documentos.Length; i++)
            {
                if (idc == documentos[i])
                {
                    cont = 1;
                    break;
                }
                else
                {
                    cont = 2;
                }
            }

            if(cont == 1)
            {
                Response.Redirect("BusquedaCategorias.aspx");
            }
            else
            {
                String script2 = "alert('Seleccione tipo de documento');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            
            //string categoria = Session["nombre_categoria"] as string;
            //string subcategoria = Session["nombre_subcategoria"] as string;
            //Button btn = (Button)e.Item.FindControl("BotonSubcategoria");
            //categoria = RepeaterCategoria.Items.ToString();
            //HtmlButton btn2 = (HtmlButton) FindControl("Documento");
            //string prueba;
            //prueba = btn2.InnerText;
            //prueba = "1";
        }
        protected void categoria_hover(object sender, EventArgs e)
        {
            Button btn3 = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn3.NamingContainer;
            string idc1 = ((Button)item.FindControl("BotonSubcategoria")).Text;
        }

        protected void documento_Click(object sender, EventArgs e)
        {
            string prueba;
            prueba = "1";
        }
    }
}