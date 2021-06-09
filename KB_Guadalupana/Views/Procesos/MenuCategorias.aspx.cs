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
    public partial class MenuCategorias : System.Web.UI.Page
    {
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarrepeater1();
                llenarrepeater2();
                llenarrepeater3();
                llenarrepeater4();
            }
        }

        public void llenarrepeater1()
        {
            DataSet subcategoria = new DataSet();
            subcategoria = sn.subcategorias1("1");
            Repeater1.DataSource = subcategoria;
            Repeater1.DataBind();
        }

        public void llenarrepeater2()
        {
            DataSet subcategoria = new DataSet();
            subcategoria = sn.subcategorias1("2");
            Repeater2.DataSource = subcategoria;
            Repeater2.DataBind();
        }

        public void llenarrepeater3()
        {
            DataSet subcategoria = new DataSet();
            subcategoria = sn.subcategorias1("3");
            Repeater3.DataSource = subcategoria;
            Repeater3.DataBind();
        }

        public void llenarrepeater4()
        {
            DataSet subcategoria = new DataSet();
            subcategoria = sn.subcategorias1("4");
            Repeater4.DataSource = subcategoria;
            Repeater4.DataBind();
        }

        protected void subcategoria1_Click(object sender, EventArgs e)
        {
            string idc;
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Button)item.FindControl("subcategoria1")).Text;
            Session["nombre_subcategoria"] = idc;
            Session["nombre_categoria"] = "Gerencia Administrativa";
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
            string url = sn.url(idc);
            string id = sn.idsubcategoria(idc);
            Session["id_subcategoria"] = id;

            Response.Redirect(url);
        }

        protected void categoria_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Unidad de Cumplimiento";
            string id = sn.idsubcategoria("Unidad de Cumplimiento");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria2_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Comisión de Vigilancia";
            string id = sn.idsubcategoria("Comisión de Vigilancia");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria3_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Gerencia General";
            string id = sn.idsubcategoria("Gerencia General");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria4_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Consejo de Administración";
            string id = sn.idsubcategoria("Consejo de Administración");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }

        protected void categoria5_Click(object sender, EventArgs e)
        {
            Session["nombre_categoria"] = "Auditoría Interna";
            string id = sn.idsubcategoria("Auditoría Interna");
            Session["id_categoria"] = id;
            Response.Redirect("BusquedaCategorias.aspx");
        }
    }
}