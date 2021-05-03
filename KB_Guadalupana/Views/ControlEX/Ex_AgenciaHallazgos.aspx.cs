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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text.RegularExpressions;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_AgenciaHallazgos : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        string cif;
        string rol;
        string area;
        string fechaactual;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);
            llenarexphall();
            btndivhall.Visible = false;

            string rolex = exc.obtenerrol(usernombre);

            switch (rolex) {

                
                case "6":
                    legalizados.Visible = false;

                    break;
             
            }


        }
        public void llenarexphall()
        {

            DataTable dt1 = new DataTable();

            string area = exc.obtenerarea(usernombre);
            dt1 = mex.llenarexphall(area);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;


            if (numcred != "")
            {
                string noexp = exc.obtenercodexp(numcred);

                Session["exp"] = noexp;
                Session["nocredit"] = numcred;
                Response.Redirect("Ex_verhallazgos.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' No hay un expediente seleccionado')", true);


            }
        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_VistaMesaQA.aspx");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }
        protected void btncerrar_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/CerrarSesion.aspx");

        }
        protected void DGVCONHALLAZGO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVCONHALLAZGO.PageIndex = e.NewPageIndex;
            llenarexphall();
        }

        protected void DGVCONHALLAZGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;
            btndivhall.Visible = true;
            numcredito.InnerText = numcred;

        }
    }
}