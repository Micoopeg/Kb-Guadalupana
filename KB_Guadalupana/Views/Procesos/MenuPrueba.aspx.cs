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
    public partial class MenuPrueba : System.Web.UI.Page
    {
        Sentencia_proceso sn = new Sentencia_proceso();
        string idcontenedor;
       
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                llenarrepeatercategoria();
                llenarrepeatersubcategoria();

            }
                
            
        }

        //public void llenar()
        //{
        //    DataSet subcategoria = new DataSet();
        //    subcategoria = sn.subcategorias1("1");
        //    RepeaterSubCategoria.DataSource = subcategoria;
        //    RepeaterSubCategoria.DataBind();
        //}
        public void llenarrepeatersubcategoria()
        {
            DataSet subcategoria = new DataSet();
            subcategoria = sn.subcategorias1("1");
            repeatercontenedor.DataSource = subcategoria;
            repeatercontenedor.DataBind();
        }

        public void llenarrepeatercategoria()
        {
      

            DataSet categoria = new DataSet();
            categoria = sn.categorias();
            RepeaterCategoria.DataSource = categoria;
            RepeaterCategoria.DataBind();

        }

        protected void repeatercontenedor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater r = (Repeater)e.Item.FindControl("RepeaterSubCategoria");
                HtmlGenericControl id = (HtmlGenericControl)e.Item.FindControl("London");

                
                DataSet subcategoria = new DataSet();
                subcategoria = sn.subcategorias1("1");
                r.DataSource = subcategoria;
                r.DataBind();

               

                Session["idbtns"] = id.ClientID;
               
            }
        }

        protected void RepeaterCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlButton btn = (HtmlButton)e.Item.FindControl("BotonCategoria");
                string dato = Convert.ToString(Session["idbtns"]);

                btn.Attributes.Add("onmouseover", "openCity(event, '" + dato + "')");
            } 
        }
    }
}