using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_VistaNegocios : System.Web.UI.Page
    {

        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        protected void Page_Load(object sender, EventArgs e)
        {

            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
        }




        public void llenardtgvw()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenardgvnegocios(usernombre);
            DGRVWPEN.DataSource = dt1;
            DGRVWPEN.DataBind();

        }
        protected void DGRVWPEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DGRVWPEN.SelectedRow;
            string area = exc.obtenerarea(usernombre);
            DataTable dt1 = new DataTable();
            string cod = (DGRVWPEN.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string sig = exc.siguiente("ex_temporal1", "codextemp");

            string insert = "INSERT INTO `ex_temporal1` (`codextemp`, `Nocredito`, `estado`,`codexarea` ) VALUES ('" + sig + "', '" + cod + "', '7', '" + area + "'); ";
            exc.Insertar(insert);

            Response.Redirect("Ex_pendienteAg.aspx");



        }

        protected void DGRVWPEN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGRVWPEN.PageIndex = e.NewPageIndex;
            llenardtgvw();



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
    }
}