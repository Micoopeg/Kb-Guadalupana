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

namespace KB_Guadalupana.Views.Procesos
{
    public partial class MenuCategorias : System.Web.UI.Page
    {
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //llenarrepeater1();
                //llenarrepeater2();
                //llenarrepeater3();
                //llenarrepeater4();
                //llenarrepeater5();
                //llenarrepeatercategoria();
                
                NombreUsuario.InnerText = Session["Nombre"] as string;
                string usuario = Session["sesion_usuario"] as string;
                string idusuario = sn.obteneridusuario(usuario);
                string tipousuario = sn.tipousuario(idusuario);
                Session["nivel_usuario"] = tipousuario;
                string categoria = sn.categoriausuario(idusuario);
                Session["categoria_usuario"] = categoria;
                string subcategoria = sn.subcategoriausuario(idusuario);
                Session["subcategoria_usuario"] = subcategoria;
            }
        }

        //public void llenarrepeater1()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("4");
        //    RepeaterSubcategoria1.DataSource = subcategoria;
        //    RepeaterSubcategoria1.DataBind();
        //}

        //public void llenarrepeater2()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("7");
        //    RepeaterSubcategoria2.DataSource = subcategoria;
        //    RepeaterSubcategoria2.DataBind();
        //}

        //public void llenarrepeater3()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("3");
        //    RepeaterSubcategoria3.DataSource = subcategoria;
        //    RepeaterSubcategoria3.DataBind();
        //}

        //public void llenarrepeater4()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("1");
        //    RepeaterSubcategoria4.DataSource = subcategoria;
        //    RepeaterSubcategoria4.DataBind();
        //}

        //public void llenarrepeater5()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("2");
        //    RepeaterSubcategoria5.DataSource = subcategoria;
        //    RepeaterSubcategoria5.DataBind();
        //}

        //public void llenarrepeatercategoria()
        //{
        //    DataSet categoria = new DataSet();
        //    categoria = sn.categorias();
        //    RepeaterCategoria.DataSource = categoria;
        //    RepeaterCategoria.DataBind();
        //}


        public void llenarrepeatersubcategoria()
        {
            
        }

        protected void subcategoria1_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria1")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id2 = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id2;
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void subcategoria2_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria2")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia de Negocios y Mercadeo";
            string id2 = sn.idcategoria("Gerencia de Negocios y Mercadeo");
            Session["id_categoria"] = id2;
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void subcategoria3_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria3")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia Jurídica";
            string id2 = sn.idcategoria("Gerencia Jurídica");
            Session["id_categoria"] = id2;
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void subcategoria4_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria4")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia Financiera";
            string id2 = sn.idcategoria("Gerencia Financiera");
            Session["id_categoria"] = id2;
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void subcategoria5_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria5")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia General";
            string id2 = sn.idcategoria("Gerencia General");
            Session["id_categoria"] = id2;
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void categoria_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Unidad de Cumplimiento";
            string id = sn.idcategoria("Unidad de Cumplimiento");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria2_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Comisión de Vigilancia";
            string id = sn.idcategoria("Comisión de Vigilancia");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria3_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Gerencia General";
            string id = sn.idcategoria("Gerencia General");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria4_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Consejo de Administración";
            string id = sn.idcategoria("Consejo de Administración");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria5_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Auditoría Interna";
            string id = sn.idcategoria("Auditoría Interna");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                     Repeater r = e.Item.FindControl("RepeaterSubcategoria") as Repeater;
            HtmlGenericControl area = (HtmlGenericControl)e.Item.FindControl("Categorias");
            string idcategoria = sn.idcategoria(area.ToString());
            DataSet ds2 = sn.subcategorias1(idcategoria);
            if (r != null)
            {
                r.DataSource = ds2;
                r.DataBind();
            }
            }
       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Auditoría Interna";
            string id = sn.idcategoria("Auditoría Interna");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Comisión de Vigilancia";
            string id = sn.idcategoria("Comisión de Vigilancia");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Consejo de Administración";
            string id = sn.idcategoria("Consejo de Administración");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Capacitación y Desarrollo";
            string id2 = sn.idsubcategoria("Capacitación y Desarrollo");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Mantenimiento e Infraestructura";
            string id2 = sn.idsubcategoria("Mantenimiento e Infraestructura");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Procesos y aseguramiento de calidad";
            string id2 = sn.idsubcategoria("Procesos y aseguramiento de calidad");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Recepción";
            string id2 = sn.idsubcategoria("Recepción");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Seguridad";
            string id2 = sn.idsubcategoria("Seguridad");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string tipodoc = sender.ToString();
            Session["nombre_categoria"] = "Gerencia Administrativa";
            string id = sn.idcategoria("Gerencia Administrativa");
            Session["id_categoria"] = id;
            Session["nombre_subcategoria"] = "Talento Humano";
            string id2 = sn.idsubcategoria("Talento Humano");
            Session["id_subcategoria"] = id2;
            Response.Redirect("Busqueda.aspx");
        }
    }
}