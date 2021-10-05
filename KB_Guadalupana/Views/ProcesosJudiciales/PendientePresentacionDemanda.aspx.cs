using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class PendientePresentacionDemanda : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewcreditos();
            llenargridviewcredito();
            if (gridViewCreditos.Rows.Count == 0)
            {
                tablaC.Visible = false;
                CreditosDevueltos.Visible = false;
            }
        }

        public void llenargridviewcreditos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_credito AS Credito, pj_nombrecliente AS Nombre, pj_status, pj_numincidente AS Incidente, pj_fecha AS Fecha FROM pj_etapa_credito WHERE idpj_etapa = 4 AND pj_status IN ('Enviado','Reingreso', 'Rechazado', 'Diligenciamiento') ";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewDemanda.DataSource = dt;
                    gridViewDemanda.DataBind();
                }
                catch
                {

                }
            }

        }

        protected void OnSelectedIndexChangedDemanda(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewDemanda.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;

            string estado = Convert.ToString((gridViewDemanda.SelectedRow.FindControl("lblestado") as Label).Text);
            Session["estado"] = estado;

            string tipoproceso = sn.tipoproceso(numcredito);

            if(tipoproceso == "1" || tipoproceso == "2")
            {
                Response.Redirect("PresentacionDemanda.aspx");
            }
            else
            {

            }
        }

        protected void gridViewCertificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "pj_status").ToString();

                if (_estado == "Reingreso")
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                else
                    e.Row.BackColor = System.Drawing.Color.White;
            }
        }

        public void llenargridviewcredito()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpj_credito AS Credito, A.pj_numincidente AS Incidente, A.pj_nombrecliente AS Nombre, A.pj_status AS Estado, B.gen_areanombre AS DeArea, C.pj_comentario AS Comentario, A.pj_fecha AS Fecha FROM pj_etapa_credito AS A INNER JOIN pj_area AS B ON A.gen_area = B.codgenarea INNER JOIN pj_bitacora AS C ON(C.pj_numcredito = A.idpj_credito AND C.pj_estado = A.pj_status AND A.gen_area = C.pj_deArea) WHERE A.pj_status = 'Devuelto' AND C.pj_paraArea = 34 AND A.idpj_etapa = 5";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);

                    gridViewCreditos.DataSource = dt;
                    gridViewCreditos.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedCreditos(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewCreditos.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            string area = Convert.ToString((gridViewCreditos.SelectedRow.FindControl("lbldeArea") as Label).Text);
            Session["area"] = area;
            Response.Redirect(".aspx");
        }

        public void llenargridviewresolucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpj_credito AS Credito, A.pj_numincidente AS Incidente, A.pj_nombrecliente AS Nombre, A.pj_status AS Estado, B.gen_areanombre AS DeArea, C.pj_comentario AS Comentario, A.pj_fecha AS Fecha FROM pj_etapa_credito AS A INNER JOIN pj_area AS B ON A.gen_area = B.codgenarea INNER JOIN pj_bitacora AS C ON(C.pj_numcredito = A.idpj_credito AND C.pj_estado = A.pj_status AND A.gen_area = C.pj_deArea) WHERE A.pj_status = 'Facturacion' AND A.idpj_etapa = 5";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);

                    gridViewResolucion.DataSource = dt;
                    gridViewResolucion.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedResolucion(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewResolucion.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            string area = Convert.ToString((gridViewResolucion.SelectedRow.FindControl("lbldeArea") as Label).Text);
            Session["area"] = area;
            Response.Redirect("PrimeraResolucion.aspx");
        }
    }
}