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
    public partial class Ex_verhallazgos : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        string codexp,no;
        string fechaactual; char delimitador2 = ' ';



        protected void DGVHALL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVHALL.PageIndex = e.NewPageIndex;
            llenarhall();
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void DGVHALL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numhall = (DGVHALL.SelectedRow.FindControl("lblnumhall") as Label).Text;

            string datos = mex.obtenerhallazgo(numhall);
            datoshall.InnerText = datos;

            divbtnverificar.Visible = true;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            codexp = Convert.ToString(Session["exp"]);
            no = Convert.ToString(Session["nocredit"]);

            string agencia = mex.buscaragencia(no);
            string noexp = mex.buscarnoexp(no);
            now();
            
            numeroexp.InnerText = "Expediente: " + noexp + "," + agencia;
            procesoesp.InnerText = "Hallazgos del expediente";
            nocred.InnerText = "No. Credito " + no;
            string rol = exc.obtenerrol(usernombre);
            switch (rol) {
                case "6":
                    llenarhallvista();
                    nota.Visible = false;
                    exphall.Visible= false;
                    break;

                case "8":
                    llenarhall();
                    exphall.Visible = true;
                    break;
                case "2":
                    llenarhall();
                    exphall.Visible = true;
                    break;
                default:

                    Response.Redirect("Ex_Principal.aspx");
                    break;

            
            
            
            }
          


        }

        protected void DGVHALLVISTA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVHALLVISTA.PageIndex = e.NewPageIndex;
            llenarhallvista();

        }

        protected void btnlisto_Click(object sender, EventArgs e)
        {
            string numhall = (DGVHALL.SelectedRow.FindControl("lblnumhall") as Label).Text;

            string hall = "UPDATE `ex_hallazgos` SET  `estadohall`= 0 WHERE codexhall = '"+numhall+" '";
            exc.Insertar(hall);
            String script = "alert('Hallazgo corregido '); window.location.href= 'EX_verhallazgos.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);


        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Sesion/CerrarSesion.aspx");
        }
        public void now()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    string hora = Convert.ToString(fecha.GetValue(1));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + hora;

                    fechaactual = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
        protected void DGVHALLVISTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numhall = (DGVHALLVISTA.SelectedRow.FindControl("lblnumhall") as Label).Text;
            string sig = exc.siguiente("ex_bitacorahallazgos", "codexhallax");
            string update = "UPDATE `ex_hallazgos` SET `estadohall`= 2 WHERE codexhall = '" +numhall+"' ";
                exc.Insertar(update);
            string bitacora = "INSERT INTO `ex_bitacorahallazgos`(`codexhallax`, `codhall`, `estadomomento`, `fecha`) VALUES ('"+sig+"','"+numhall+"',2,'"+fechaactual+"')";
            exc.Insertar(bitacora);

            String script = "alert('Hallazgo Enviado '); window.location.href= 'EX_verhallazgos.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }


        protected void gridViewIncidente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "estadohall").ToString();

                switch (_estado) {
                    case "1":
                        e.Row.BackColor = System.Drawing.Color.IndianRed;
                        break;
                    case "2":
                        e.Row.BackColor = System.Drawing.Color.ForestGreen;
                        break;

                }
             
            }
        }
        protected void gridViewIncidente_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "estadohall").ToString();

                switch (_estado)
                {
                    case "1":
                        e.Row.BackColor = System.Drawing.Color.IndianRed;
                        break;
                    case "2":
                        e.Row.BackColor = System.Drawing.Color.ForestGreen;
                        break;

                }
            }
        }


        public void llenarhall()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarhallazgos(codexp);
            DGVHALL.DataSource = dt1;
            DGVHALL.DataBind();

        }
        public void llenarhallvista()
        {
            DataTable dt1 = new DataTable();
            dt1 = mex.llenarhallazgos2(codexp);
            DGVHALLVISTA.DataSource = dt1;
            DGVHALLVISTA.DataBind();

        }
        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_VistaMesaQA.aspx");

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