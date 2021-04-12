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
    public partial class MantenimientoLotes : System.Web.UI.Page
    {
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();
        Conexion conn = new Conexion();
        string fecha, año, mes, dia, fecha2, fechafin, fechafin2, año2, mes2, dia2, año3, mes3, dia3, fecha3, año4, mes4, dia4, fecha4;
        char delimitador3 = '/';
        Conexion conexiongeneral = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
            RLCodigo.Value = logic.siguiente("ep_administracionlote", "codepadministracionlote");
            RLCodigo.Disabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM ep_administracionlote WHERE ep_administracionlotefechainicio='" + TextBox1.Text + "';";
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
                string QueryString = "SELECT * FROM ep_administracionlote;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch { }
        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string ingreso;
                ingreso = (gvPhoneBook.FooterRow.FindControl("txtContactFooter3") as TextBox).Text.Trim();
                string estado;
                estado = sn.estadoLote();
                if (estado == "True" && ingreso == "1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ya existe un lote activo');", true);
                }
                else
                {
                    if (e.CommandName.Equals("AddNew"))
                    {
                        using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                        {
                            fecha = (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim();
                            string[] fechasep2 = fecha.Split(delimitador3);
                            dia = fechasep2[0];
                            mes = fechasep2[1];
                            año = fechasep2[2];
                            fecha2 = año + "-" + mes + "-" + dia;

                            fechafin = (gvPhoneBook.FooterRow.FindControl("txtContactFooter2") as TextBox).Text.Trim();
                            string[] fechasep = fechafin.Split(delimitador3);
                            dia2 = fechasep[0];
                            mes2 = fechasep[1];
                            año2 = fechasep[2];
                            fechafin2 = año2 + "-" + mes2 + "-" + dia2;

                            string id = (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim();
                            string estadodelote = (gvPhoneBook.FooterRow.FindControl("txtContactFooter3") as TextBox).Text.Trim();

                            string[] valores = { id, fecha2, fechafin2, estadodelote };
                            sn.insertartablas("ep_administracionlote", valores);
                            PopulateGridview();

                            //sqlCon.Open();
                            //string query = "INSERT INTO ep_administracionlote (codepadministracionlote,ep_administracionlotefechainicio, ep_administracionfechafin, ep_administracionloteestado) VALUES (@FirstName, '" + fecha2 + "', '" + fechafin2 + "', @Contact3)";
                            //MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                            //sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                            ////sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                            ////sqlCmd.Parameters.AddWithValue("@Contact2", (gvPhoneBook.FooterRow.FindControl("txtContactFooter2") as TextBox).Text.Trim());
                            //sqlCmd.Parameters.AddWithValue("@Contact3", (gvPhoneBook.FooterRow.FindControl("txtContactFooter3") as TextBox).Text.Trim());
                            ////sqlCmd.Parameters.AddWithValue("@FirstName", (logic.siguiente("ep_tipovehiculo", "codeptipovehiculo")));

                            //try
                            //{
                            //    //sqlCmd.ExecuteNonQuery();
                            //    //PopulateGridview();
                            //    //(gvPhoneBook.SelectedRow.FindControl("txtFirstNameFooter") as TextBox).Text = Convert.ToString(logic.siguiente("ep_administracionlote", "codepadministracionlote"));
                            //}
                            //catch
                            //{
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe llenar todos los campos');", true);
                            //}

                        }
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


                string QueryString = "SELECT codepadministracionlote, ep_administracionlotefechainicio, ep_administracionfechafin, CASE ep_administracionloteestado WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ep_administracionloteestado FROM ep_administracionlote  WHERE codepadministracionlote != 'NULL'   AND ep_administracionfechafin != '0000-00-00' AND ep_administracionlotefechainicio != '0000-00-00'";
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
                string ingreso2;
                ingreso2 = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim();
                string estado2;
                estado2 = sn.estadoLote();

                if (estado2 == "True" && ingreso2 == "1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ya existe un lote activo');", true);
                }
                else
                {
                    using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
                    {
                        string estado3 = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim();

                        if (estado3 == "0" || estado3 == "1")
                        {
                            string fecha1 = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName2") as TextBox).Text.Trim();
                            string[] fechasep3 = fecha1.Split(delimitador3);
                            dia3 = fechasep3[0];
                            mes3 = fechasep3[1];
                            año3 = fechasep3[2];
                            fecha3 = año3 + "-" + mes3 + "-" + dia3;

                            string fecha2 = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName3") as TextBox).Text.Trim();
                            string[] fechasep4 = fecha2.Split(delimitador3);
                            dia4 = fechasep4[0];
                            mes4 = fechasep4[1];
                            año4 = fechasep4[2];
                            fecha4 = año4 + "-" + mes4 + "-" + dia4;

                            string estado = (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim();
                            string id = (gvPhoneBook.DataKeys[e.RowIndex].Value.ToString());

                            sn.modificarLote(fecha4, fecha3, estado, id);
                            //PopulateGridview();

                            //sqlCon.Open();
                            //string query = "UPDATE ep_administracionlote SET ep_administracionfechafin='"+fecha3+"' ep_administracionloteestado=@FirstName WHERE codepadministracionlote = @id";
                            //MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                            //sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                            //sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                            ////Convert.ToString(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()) = RVCodigo.Value;
                            ////Response.Write(prueba);
                            ////TextBox1.Text = prueba;
                            //sqlCmd.ExecuteNonQuery();
                            gvPhoneBook.EditIndex = -1;
                            PopulateGridview();
                            lblSuccessMessage.Text = "Selected Record Updated";
                            lblErrorMessage.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe ingresar únicamente un 0 o 1');", true);
                        }

                    }
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
                    string query = "DELETE FROM ep_administracionlote WHERE codepadministracionlote = @id";
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
            MySqlDataAdapter ad = new MySqlDataAdapter("SELECT codepadministracionlote, ep_administracionlotefechainicio, ep_administracionfechafin, CASE ep_administracionloteestado WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS Estado FROM ep_administracionlote; ", conn.conectar());
            DataSet ds = new DataSet();
            ad.Fill(ds, "Nombre");
            return ds;
        }
    }
}