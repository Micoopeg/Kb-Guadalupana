using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion
{
    public partial class MantenimientoTelefono : System.Web.UI.Page
    {
        Logica logic = new Logica();
        Conexion conn = new Conexion();
        Conexion conexiongeneral = new Conexion();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
            RTCodigo.Value = logic.siguiente("ep_tipotelefono", "codeptipotelefono");
            RTCodigo.Disabled = false;
        }

        protected void gvPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO ep_tipotelefono (codeptipotelefono,ep_tipotelefononombre) VALUES (@FirstName,@Contact)";
                        MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        void PopulateGridview()
        {
            try
            {


                string QueryString = "SELECT * FROM ep_tipotelefono;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch
            {
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    sqlCon.Open();
                    string query = "UPDATE ep_tipotelefono SET codeptipotelefono=@FirstName,ep_tipotelefononombre=@Contact WHERE codeptipotelefono = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM ep_tipotelefono WHERE codeptipotelefono = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        public DataSet GetCategoryNames()
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM ep_tipotelefono;", conn.conectar());
            DataSet ds = new DataSet();
            ad.Fill(ds, "Nombre");
            return ds;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM ep_tipotelefono WHERE ep_tipotelefononombre='" + TextBox1.Text + "';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch { }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM ep_tipotelefono;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch { }
        }
    }
}