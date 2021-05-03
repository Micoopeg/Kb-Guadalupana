using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion
{
    public partial class Reporte : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        string valor1;
        Logica logic = new Logica();
        Conexion conn = new Conexion();
        Sentencia sn = new Sentencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewreporte();
            }
        }

        public void llenargridviewreporte()
        {
            valor1 = Session["Valor"].ToString();
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "SELECT ep_control.codepinformaciongeneralcif, gen_usuario.gen_usuarionombre, " +
                        "ep_informaciongeneral.ep_informaciongeneralcif, " +
                        "CASE when ep_informaciongeneral.codeptipoestado = '1' " +
                        "THEN 'Nuevo' when ep_informaciongeneral.codeptipoestado = '2' " +
                        "THEN 'En Proceso' when ep_informaciongeneral.codeptipoestado = '3' " +
                        "THEN 'Terminado' END AS 'Tipo' FROM ep_control INNER JOIN gen_usuario " +
                        "ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral " +
                        "ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif " +
                        "WHERE ep_informaciongeneral.codeptipoestado='" + valor1 + "' ORDER BY ep_control.codepcontrol";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporte.DataSource = ds3;
                    GridViewReporte.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        protected void iniciarsesion_Click(object sender, EventArgs e)
        {
            Session["IDReporte"] = RCif.Value;
            string nombre;
            string id;
            nombre = Session["IDReporte"].ToString();

            string[] var1 = sn.consultarCIF(nombre);
            for (int i = 0; i < var1.Length; i++)
            {
                id = Convert.ToString(var1[0]);
                Session["IDReporte1"] = id;
                Response.Redirect("ReportesAdmin/ReporteAdmin1.aspx");
            }
        }

        protected void OnSelectedIndexChangedReporte(object sender, EventArgs e)
        {
            GridViewRow row = GridViewReporte.SelectedRow;
            Text6.Value = (GridViewReporte.SelectedRow.FindControl("lblnombre") as Label).Text;
            RCif.Value = Convert.ToString((GridViewReporte.SelectedRow.FindControl("lblcif") as Label).Text);

        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            valor1 = Session["Valor"].ToString();

            int valor = Convert.ToInt32(valor1);
            string prueba;
            DataTable dt1 = new DataTable();
            dt1 = logic.buscarCIF(RBuscarcif.Value, valor1);

            string[] var1 = sn.consultarCIF1(RBuscarcif.Value, valor1);
            prueba = Convert.ToString(var1[0]);

            if (prueba == null)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra If: "+valor+"');", true);
                switch (valor)
                {
                    case 1:
                        Texto.Visible = true;
                        GridViewReporte.DataSource = dt1;
                        GridViewReporte.DataBind();
                        break;
                    case 2:
                        Texto1.Visible = true;
                        GridViewReporte.DataSource = dt1;
                        GridViewReporte.DataBind();
                        break;
                    case 3:
                        Texto2.Visible = true;
                        GridViewReporte.DataSource = dt1;
                        GridViewReporte.DataBind();
                        break;
                }
            }
            else
            {
                Texto.Visible = false;
                Texto1.Visible = false;
                Texto2.Visible = false;
                GridViewReporte.DataSource = dt1;
                GridViewReporte.DataBind();
            }
            //try
            //{
            //    string QueryString = "SELECT gen_usuarionombre, codepinformaciongeneralcif FROM gen_usuario INNER JOIN ep_control ON gen_usuario.codgenusuario = ep_control.codgenusuario WHERE codepinformaciongeneralcif='" + RBuscarcif.Value + "'";
            //    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
            //    DataTable ds3 = new DataTable();
            //    myCommand.Fill(ds3);
            //    GridViewReporte.DataSource = ds3;
            //    GridViewReporte.DataBind();
            //}
            //catch { }
        }

        protected void VerTodos_Click(object sender, EventArgs e)
        {
            Texto.Visible = false;
            Texto1.Visible = false;
            Texto2.Visible = false;
            llenargridviewreporte();
        }
    }
}