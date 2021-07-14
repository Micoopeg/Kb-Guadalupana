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
    public partial class MantenimientoAreas : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_proceso sn = new Sentencia_proceso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcomboaccion();
                llenarcombocategoria();
                llenarcombosubcategoria();
                CrearCategoria.Visible = false;
                CrearSubcategoria.Visible = false;
                GuardarCategoria.Visible = false;
                ActualizarCategoria.Visible = false;
                GuardarSubcategoria.Visible = false;
                ActualizarSubcategoria.Visible = false;
                actualizarcat.Visible = false;
                actualizarsub.Visible = false;
            }
        }

        public void llenarcomboaccion()
        {
            Accion.Items.Insert(0, new ListItem("[Seleccione opción]", "0"));
            Accion.Items.Insert(1, new ListItem("Crear Categoría", "1"));
            Accion.Items.Insert(2, new ListItem("Editar Categoría", "2"));
            Accion.Items.Insert(3, new ListItem("Crear Subcategoría", "3"));
            Accion.Items.Insert(4, new ListItem("Editar Subcategoría", "4"));
        }

        protected void Accion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Accion.SelectedValue == "1")
            {
                CrearCategoria.Visible = true;
                GuardarCategoria.Visible = true;
                actualizarcat.Visible = false;

                ActualizarCategoria.Visible = false;
                CrearSubcategoria.Visible = false;
                GuardarSubcategoria.Visible = false;
                CrearSubcategoria.Visible = false;
                ActualizarSubcategoria.Visible = false;
                actualizarsub.Visible = false;
            }
            else if(Accion.SelectedValue == "2")
            {
                CrearCategoria.Visible = true;
                actualizarcat.Visible = true;
                ActualizarCategoria.Visible = true;

                CrearSubcategoria.Visible = false;
                GuardarSubcategoria.Visible = false;
                ActualizarSubcategoria.Visible = false;
                actualizarsub.Visible = false;
                GuardarCategoria.Visible = false;
            }
            else if (Accion.SelectedValue == "3")
            {
                CrearSubcategoria.Visible = true;
                GuardarSubcategoria.Visible = true;
                actualizarsub.Visible = false;

                actualizarcat.Visible = false;
                ActualizarCategoria.Visible = false;
                ActualizarSubcategoria.Visible = false;
                CrearCategoria.Visible = false;
                GuardarCategoria.Visible = false;
            }
            else if (Accion.SelectedValue == "4")
            {
                CrearSubcategoria.Visible = true;
                ActualizarSubcategoria.Visible = true;
                actualizarsub.Visible = true;

                actualizarcat.Visible = false;
                ActualizarCategoria.Visible = false;
                GuardarSubcategoria.Visible = false;
                CrearCategoria.Visible = false;
                GuardarCategoria.Visible = false;
            }
        }

        public void llenarcombocategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pro_categoria";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    Categoria.DataSource = ds;
                    Categoria.DataTextField = "pro_nombre";
                    Categoria.DataValueField = "idpro_categoria";
                    Categoria.DataBind();
                    Categoria.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                    CategoriaBuscar.DataSource = ds;
                    CategoriaBuscar.DataTextField = "pro_nombre";
                    CategoriaBuscar.DataValueField = "idpro_categoria";
                    CategoriaBuscar.DataBind();
                    CategoriaBuscar.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        public void llenarcombosubcategoria()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from pro_subcategoria";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Subcategoria");
                    SubcategoriaBuscar.DataSource = ds;
                    SubcategoriaBuscar.DataTextField = "pro_nombre";
                    SubcategoriaBuscar.DataValueField = "idpro_subcategoria";
                    SubcategoriaBuscar.DataBind();
                    SubcategoriaBuscar.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        protected void BuscarCategoria_Click(object sender, EventArgs e)
        {
            if(CategoriaBuscar.SelectedValue == "0")
            {
                String script2 = "alert('Seleccione una categoria');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
            {
                string nombrecat = sn.nombrecategoria(CategoriaBuscar.SelectedValue);
                NombreCategoria.Value = nombrecat;
            }
        }

        protected void ActualizarCategoria_Click(object sender, EventArgs e)
        {
            if (CategoriaBuscar.SelectedValue == "0" || NombreCategoria.Value == "")
            {
                Response.Redirect("BusquedaCategorias.aspx");
            }
            else
            {
                sn.editarcategoria(CategoriaBuscar.SelectedValue, NombreCategoria.Value);
                String script2 = "alert('Categoría Actualizada');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
        }

        protected void GuardarCategoria_Click(object sender, EventArgs e)
        {
            if (NombreCategoria.Value == "")
            {
                String script2 = "alert('Ingrese nombre');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
            {
                string sig = sn.siguiente("pro_categoria", "idpro_categoria");
                sn.insertarcategoria(sig, NombreCategoria.Value);

                string sig2 = sn.siguiente("pro_subcategoria", "idpro_subcategoria");
                sn.insertarsubcategoria(sig2, "Ninguna", sig);

                int num = Convert.ToInt32(sn.numdocumento());
                for (int i = 1; i <= num; i++)
                {
                    string sig3 = sn.siguiente("pro_controlDocumentos", "idpro_control");
                    sn.insertarsubcategoria2(sig3, sig, sig2, i.ToString());
                }

                String script2 = "alert('Categoria guardada');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
        }

        protected void BuscarSubcategoria_Click(object sender, EventArgs e)
        {
            if(SubcategoriaBuscar.SelectedValue == "0")
            {
                String script2 = "alert('Seleccione opción');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
            {
                string[] subcategoria = sn.obtenersubcategorias(SubcategoriaBuscar.SelectedValue);
                for(int i = 0; i<subcategoria.Length; i++)
                {
                    IdSub.Value = subcategoria[0];
                    Subcategoria.Value = subcategoria[1];
                    Categoria.SelectedValue = subcategoria[2];
                }
            }
        }

        protected void ActualizarSubcategoria_Click(object sender, EventArgs e)
        {
            if (SubcategoriaBuscar.SelectedValue == "0" || Subcategoria.Value == "" || Categoria.SelectedValue == "0")
            {
                String script2 = "alert('Complete datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
            {
                sn.editarsubcategoria(SubcategoriaBuscar.SelectedValue, Subcategoria.Value, Categoria.SelectedValue);
                sn.editarsubcategoria2(SubcategoriaBuscar.SelectedValue, Categoria.SelectedValue);

                String script2 = "alert('Subcategoría Actualizada');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
        }

        protected void GuardarSubcategoria_Click(object sender, EventArgs e)
        {
            if (SubcategoriaBuscar.SelectedValue == "0" || Subcategoria.Value == "" || Categoria.SelectedValue == "0")
            {
                String script2 = "alert('Complete datos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
            else
            {
                string sig = sn.siguiente("pro_subcategoria", "idpro_subcategoria");
                sn.insertarsubcategoria(sig, Subcategoria.Value, Categoria.SelectedValue);

                int num = Convert.ToInt32(sn.numdocumento());
                for (int i=1; i<=num; i++)
                {
                    string sig2 = sn.siguiente("pro_controlDocumentos", "idpro_control");
                    sn.insertarsubcategoria2(sig2, Categoria.SelectedValue, sig, i.ToString());
                }

                String script2 = "alert('Subcategoria guardada');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script2, true);
            }
        }
    }
}