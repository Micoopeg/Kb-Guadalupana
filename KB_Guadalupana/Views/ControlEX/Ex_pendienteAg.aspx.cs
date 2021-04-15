using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_pendienteAg : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        protected void Page_Load(object sender, EventArgs e)
        {
            llenardtgvw();

            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);

            if (usernombre != "")
            {
                coduser = exc.obtenercoduser(usernombre);

                if (!IsPostBack)
                {

                    llenarcombotipocred();
                }
            }
            else
            {
                Response.Redirect("../Session/MenuBarra.aspx");

            }


        }


        public void llenardtgvw() {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarGridViewevento();
            DGRVWPEN.DataSource = dt1;
            DGRVWPEN.DataBind();

        }

        protected void DGRVWPEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DGRVWPEN.SelectedRow;
            DataTable dt1 = new DataTable();
            string cod = (DGRVWPEN.SelectedRow.FindControl("lblcodex") as Label).Text;
            correcto.Visible = false;
            modificado.Visible = false;


            string[] fecha = mex.datosexpedientependiente(cod);
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    CODEX.Value = Convert.ToString(fecha.GetValue(1));
                    tipocredito.SelectedIndex = Convert.ToInt32(fecha.GetValue(3));
                    NOCRED.Value = Convert.ToString(fecha.GetValue(5));
                    MONTO.Value = Convert.ToString(fecha.GetValue(6));
                    CIF.Value = Convert.ToString(fecha.GetValue(7));
                    PNOM.Value = Convert.ToString(fecha.GetValue(8));
                    SNOM.Value = Convert.ToString(fecha.GetValue(9));
                    PAPELL.Value = Convert.ToString(fecha.GetValue(10));
                    SAPELL.Value = Convert.ToString(fecha.GetValue(11));





                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }




        }

        protected void DGRVWPEN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGRVWPEN.PageIndex = e.NewPageIndex;
            llenardtgvw();



        }

        protected void DGRVW2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = DGRVW2.SelectedRow;

            //string cod = (DGRVW2.SelectedRow.FindControl("lblcod2tbl") as Label).Text;
            //Session["varenv"] = cod ;



        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked)
            {

                barrascodigo.Disabled = false;

            }
            else {

                barrascodigo.Disabled = true;

            }

        }

        public void llenarcombotipocred()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {

                    sqlCon.Open();
                    string QueryString = "select * from ex_tipocredito;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Credito");
                    tipocredito.DataSource = ds;
                    tipocredito.DataTextField = "ex_nomtipo";
                    tipocredito.DataValueField = "codextipocred";
                    tipocredito.DataBind();
                    tipocredito.Items.Insert(0, new ListItem("[Tipo Expediente]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }


        public void modificardatosexp() {

            string codaso = exc.obtenercodporcif(CIF.Value);
            string modificar = "UPDATE `ex_asociado` SET `ex_cif`='" + CIF.Value + "',`ex_pnombre`='" + PNOM.Value + "',`ex_snombre`='" + SNOM.Value + "',`ex_papell`='" + PAPELL.Value + "',`ex_sapell`='" + SAPELL.Value + "' WHERE codexasociado = '" + codaso + "'";
            exc.Insertar(modificar);

            string modificar2 = "UPDATE `ex_expediente` SET `codextipocred`= '" + tipocredito.SelectedIndex + "' WHERE codexp = '" + CODEX.Value + "'";
            exc.Insertar(modificar2);


            string cred = exc.obtenercodcred(CODEX.Value);
            string modificar3 = "UPDATE `ex_creditos` SET `ex_monto`= '" + MONTO.Value + "' ,`ex_montodes`='" + MONTODES.Value + "',`ex_numcredito`= '" + NOCRED.Value + "' WHERE codexcrd = '" + cred + "'";

            exc.Insertar(modificar3);





        }
        public string fechabitacora()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + horamin;



                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }
            return fechahora;

        }

        public void ExBitacora(string ex)
        {

            string ean = exc.obtenerean13(ex);

            string cant = barrascodigo.Value;

            int cont = cant.Length;
            if (cont == 13)
            {
                if (ean == barrascodigo.Value)
                {



                    string sig = exc.siguiente("ex_bitacora", "codexbit");

                    string date = fechabitacora();

                    string sql4 = "INSERT INTO ex_bitacora (codexbit, codexp, ex_fechaev, codusuario, codexevento) VALUES ('" + sig + "','" + ex + "', '" + date + "', '" + coduser + "', '2');";

                    exc.Insertar(sql4);

                    string actualestado = "UPDATE `ex_expediente` SET `ex_tipoevento`= 2 WHERE  codexp = '" + ex + "' ;";
                    exc.Insertar(actualestado);

                }
                else {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El codigo de barras no corresponde al expediente seleccionado ')", true);
                }
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Numero de caracteres invalido ')", true);


            }


        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {


            if (CODEX.Value != "" && NOCRED.Value != "" && CIF.Value != "" && MONTO.Value != "" && PNOM.Value != "" && SNOM.Value != "" && PAPELL.Value != "" && SAPELL.Value != "" && tipocredito.SelectedIndex != 0 && barrascodigo.Value != "")
            {

                modificardatosexp();
                modificado.Visible = true;
            }

            else {

                correcto.Visible = true;

            }


        }

        public void limpiar(){

            CODEX.Value = "" ;
            tipocredito.SelectedIndex = 0;
            NOCRED.Value = "";
            MONTO.Value = "";
            CIF.Value = "";
            PNOM.Value = "";
            SNOM.Value = "";
            PAPELL.Value = "";
            SAPELL.Value = "";


        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (CODEX.Value != "" && NOCRED.Value != "" && CIF.Value != "" && MONTO.Value != "" && PNOM.Value != "" && SNOM.Value != "" && PAPELL.Value != "" && SAPELL.Value != "" && tipocredito.SelectedIndex != 0 && barrascodigo.Value != "")
            {
                ExBitacora(CODEX.Value);
                limpiar();

            }
        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {
            if (CODEX.Value != "" && NOCRED.Value != "" && CIF.Value != "" && MONTO.Value != "" && PNOM.Value != "" && SNOM.Value != "" && PAPELL.Value != "" && SAPELL.Value != "" && tipocredito.SelectedIndex != 0 && barrascodigo.Value != "")
            {
                btnguardar.Visible = true;
                correcto.Visible = false;
            }
            else {

                correcto.Visible = true;
                btnguardar.Visible = false;
            }
        }

       

        
    }
}