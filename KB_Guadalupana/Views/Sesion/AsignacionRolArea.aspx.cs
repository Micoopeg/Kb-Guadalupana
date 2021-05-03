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
    public partial class AsignacionRolArea : System.Web.UI.Page
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
           
        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        void PopulateGridview()
        {
            try
            {


                string QueryString = "SELECT * FROM gen_usuario;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
                //(gvPhoneBook.SelectedRow.FindControl("txtFirstNameFooter") as TextBox).Text = Convert.ToString(logic.siguiente("ep_tipovehiculo", "codeptipovehiculo"));
                //(gvPhoneBook.FindControl("txtFirstNameFooter") as TextBox).Text = RVCodigo.Value;

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
                    string query = "UPDATE gen_usuario SET gen_area_codgenarea=@Contact,gen_roles_codgenroles=@Contact2 WHERE codgenusuario = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact2") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact2", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact3") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Registro modificado exitosamente";
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
          
        }

        public DataSet GetCategoryNames()
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM gen_usuario;", conn.conectar());
            DataSet ds = new DataSet();
            ad.Fill(ds, "Nombre");
            return ds;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM gen_usuario WHERE gen_usuarionombre='" + TextBox1.Text + "';";
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
                string QueryString = "SELECT * FROM gen_usuario;";
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