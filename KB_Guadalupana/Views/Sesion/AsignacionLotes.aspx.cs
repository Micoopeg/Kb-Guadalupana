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
    public partial class AsignacionLotes : System.Web.UI.Page
    {
        int rol;
        Logica logic = new Logica();
        Conexion conn = new Conexion();
        Sentencia sn = new Sentencia();
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview1();
                PopulateGridview2();
                PopulateGridview3();
            }
            try
            {


                string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_informaciongeneral.ep_informaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif ORDER BY ep_control.codepcontrol; ";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridView2.DataSource = ds3;
                GridView2.DataBind();
                GridView2.HeaderRow.Cells[0].Text = "Código";
                GridView2.HeaderRow.Cells[1].Text = "Nombre";
                GridView2.HeaderRow.Cells[2].Text = "Correo";
                GridView2.HeaderRow.Cells[3].Text = "CIF";

            }
            catch
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_informaciongeneral.ep_informaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif WHERE ep_informaciongeneral.ep_informaciongeneralcif = '" + TextBox1.Text + "' ORDER BY ep_control.codepcontrol; ";
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
            DataTable ds3 = new DataTable();
            myCommand.Fill(ds3);
            GridView2.DataSource = ds3;
            GridView2.DataBind();
            GridView2.HeaderRow.Cells[0].Text = "Código";
            GridView2.HeaderRow.Cells[1].Text = "Nombre";
            GridView2.HeaderRow.Cells[2].Text = "Correo";
            GridView2.HeaderRow.Cells[3].Text = "CIF";

            string cif = sn.consultarCodigoCif(TextBox1.Text);

            string QueryString2 = "SELECT codgenusuario, codepadministracionlote FROM ep_control WHERE codepinformaciongeneralcif = " + cif + "; ";
            MySqlDataAdapter myCommand2 = new MySqlDataAdapter(QueryString2, conn.conectar());
            DataTable ds2 = new DataTable();
            myCommand2.Fill(ds2);
            GridView3.DataSource = ds2;
            GridView3.DataBind();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_informaciongeneral.ep_informaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif ORDER BY ep_control.codepcontrol; ";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridView2.DataSource = ds3;
                GridView2.DataBind();
                GridView2.HeaderRow.Cells[0].Text = "Código";
                GridView2.HeaderRow.Cells[1].Text = "Nombre";
                GridView2.HeaderRow.Cells[2].Text = "Correo";
                GridView2.HeaderRow.Cells[3].Text = "CIF";

                PopulateGridview3();

                TextBox1.Text = "";
            }
            catch { }
        }

        void PopulateGridview2()
        {
            try
            {
                string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_informaciongeneral.ep_informaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif ORDER BY ep_control.codepcontrol; ";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridView2.DataSource = ds3;
                GridView2.DataBind();
                GridView2.HeaderRow.Cells[0].Text = "Código";
                GridView2.HeaderRow.Cells[1].Text = "Nombre";
                GridView2.HeaderRow.Cells[2].Text = "Correo";
                GridView2.HeaderRow.Cells[3].Text = "CIF";
            }
            catch
            {
            }
        }

        //TABLA CREACION DE LOTES
        void PopulateGridview1()
        {
            try
            {


                string QueryString = "SELECT * FROM ep_administracionlote WHERE ep_administracionloteestado=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridView1.DataSource = ds3;
                GridView1.DataBind();

            }
            catch
            {
            }
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    sqlCon.Open();
                    //string query = "UPDATE ep_control SET codepadministracionlote=@FirstName WHERE codepcontrol = @id";

                    string query = "INSERT INTO ep_control VALUES('',4,@FirstName,'')";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Contact", (GridView2.Rows[e.RowIndex].FindControl("txtContact") as Label).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FirstName", (GridView2.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value.ToString()));
                    //Convert.ToString(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()) = RVCodigo.Value;
                    //Response.Write(prueba);
                    //TextBox1.Text = prueba;
                    sqlCmd.ExecuteNonQuery();
                    GridView2.EditIndex = -1;
                    PopulateGridview2();
                    //lblSuccessMessage.Text = "Selected Record Updated";
                    //lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                //lblSuccessMessage.Text = "";
                //lblErrorMessage.Text = ex.Message;
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            PopulateGridview2();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            PopulateGridview2();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        void PopulateGridview3()
        {
            try
            {


                string QueryString = "SELECT * FROM ep_control;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridView3.DataSource = ds3;
                GridView3.DataBind();
            }
            catch
            {
            }
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    string sig = logic.siguiente("ep_control", "codepcontrol");
                    string codusuario = (GridView3.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim();
                    string[] codigocif = sn.obtenerCif(codusuario);

                    //string codigocif = sn.consultarCodigoCif();
                    sqlCon.Open();
                    string query = "INSERT INTO ep_control VALUES('" + sig + "',@Contact,@FirstName,'" + codigocif[0] + "')";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Contact", (GridView3.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FirstName", (GridView3.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value.ToString()));
                    //Convert.ToString(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()) = RVCodigo.Value;
                    //Response.Write(prueba);
                    //TextBox1.Text = prueba;
                    sqlCmd.ExecuteNonQuery();
                    GridView3.EditIndex = -1;
                    PopulateGridview3();
                    string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_informaciongeneral.ep_informaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif ORDER BY ep_control.codepcontrol; ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                    DataTable ds3 = new DataTable();
                    myCommand.Fill(ds3);
                    GridView2.DataSource = ds3;
                    GridView2.DataBind();
                    GridView2.HeaderRow.Cells[0].Text = "Código";
                    GridView2.HeaderRow.Cells[1].Text = "Nombre";
                    GridView2.HeaderRow.Cells[2].Text = "Correo";
                    GridView2.HeaderRow.Cells[3].Text = "CIF";
                    //string QueryString = "SELECT ep_control.codepcontrol, gen_usuario.gen_usuarionombre, gen_usuario.gen_usuariocorreo, ep_control.codepinformaciongeneralcif FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario ORDER BY ep_control.codepcontrol; ";
                    //MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                    //DataTable ds3 = new DataTable();
                    //myCommand.Fill(ds3);
                    //GridView2.DataSource = ds3;
                    //GridView2.DataBind();
                    //GridView2.HeaderRow.Cells[0].Text = "Código";
                    //GridView2.HeaderRow.Cells[1].Text = "Nombre";
                    //GridView2.HeaderRow.Cells[2].Text = "Correo";
                    //GridView2.HeaderRow.Cells[3].Text = "CIF";
                    //lblSuccessMessage.Text = "Selected Record Updated";
                    //lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                //lblSuccessMessage.Text = "";
                //lblErrorMessage.Text = ex.Message;
            }
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            PopulateGridview3();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            PopulateGridview3();
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}