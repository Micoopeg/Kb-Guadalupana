using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;

using MySql.Data.MySqlClient;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_hallazgosmesa : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        Conexion conexiongeneral = new Conexion();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;

        protected void Page_Load(object sender, EventArgs e)
        {

            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            string rolex = exc.obtenerrol(usernombre);

            switch (rolex)
            {




            }

            if (!IsPostBack)
            {

                llenarcomboasignadojuridico();
                llenarcombocred();

            }


        }




        public void llenarporcredito()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenardgvnegocios(dgvnumcred.SelectedItem.Text);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }
        public void llenarporcombo()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarporareaage(asignado.SelectedValue);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }
        protected void DGRVWPEN_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void DGRVWPEN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (dgvnumcred.SelectedIndex != 0) {
                DGVCONHALLAZGO.PageIndex = e.NewPageIndex;
                llenarporcredito();

            }

            if (asignado.SelectedIndex!=0) {
                dgvnumcred.SelectedIndex = 0;
                DGVCONHALLAZGO.PageIndex = e.NewPageIndex;
                llenarporcombo();
            }

            if (asignado.SelectedIndex != 0 && dgvnumcred.SelectedIndex != 0 ) {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Elemento no encontrao, intente seleccionando solo agencias o numero de crédito')", true);
            }




        }

        protected void asignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (asignado.SelectedIndex != 0)
            {
                llenarporcombo();
            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione una Agencia o Area')", true); }

        }

        public void llenarcomboasignadojuridico()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlarea WHERE extipoarea = 1";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    asignado.DataSource = ds;
                    asignado.DataTextField = "ex_nombrea";
                    asignado.DataValueField = "codexcontrolarea";
                    asignado.DataBind();
                    asignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Agencia]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void dgvnumcred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvnumcred.SelectedIndex != 0)
            {
                llenarporcredito();
            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione un numero de credito')", true); }


        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex_Principal.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");
        }

        public void llenarcombocred()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_expediente ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    dgvnumcred.DataSource = ds;
                    dgvnumcred.DataTextField = "codgencred";
                    dgvnumcred.DataValueField = "codexp";
                    dgvnumcred.DataBind();
                    dgvnumcred.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[No CRD]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }
        protected void btnpendiente(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }




    }
}