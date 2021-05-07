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
    public partial class AsignarProceso : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        Conexion conexiongeneral = new Conexion();
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divgridviewprospectos2.Visible = false;
                Session["confirmar"] = "0";
                //llenarcombonombre();
                llenargridviewcredito();
            }
        }

        protected void APBuscar_Click(object sender, EventArgs e)
        {
            divgridviewprospectos2.Visible = true;
            if (NumCredito.Value == "" && PrimerNombre.Value == "" && SegundoNombre.Value == "" && PrimerApellido.Value == "" && SegundoApellido.Value == "" && CIF.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe ingresar al menos un dato');", true);
            }
            else
            {
                if (NumCredito.Value != "")
                {
                    string var1 = WS.buscarcredito(NumCredito.Value);
                    char delimitador = '|';
                    string[] valoresprocesados = var1.Split(delimitador);
                    if (var1.Length == 4)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                    }
                    else
                    {
                        Session["credito"] = NumCredito.Value;
                        Response.Redirect("ProcesoJudicial.aspx");
                    }
                }
                else if (CIF.Value != "")
                {
                    if (WS.buscarcreditoporcif(CIF.Value).Tables[0].Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                    }
                    else
                    {
                        gridview2.DataSource = WS.buscarcreditoporcif(CIF.Value);
                        gridview2.DataBind();
                    }
                }
                else if (PrimerApellido.Value != "" && PrimerNombre.Value != "")
                {
                    if (SegundoNombre.Value == "" || SegundoApellido.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete nombre y apellido');", true);
                    }
                    else
                    {
                        string nombres = PrimerApellido.Value + " " + SegundoApellido.Value + "," + PrimerNombre.Value + " " + SegundoNombre.Value;
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                    }
                }
                else if (SegundoApellido.Value != "" && SegundoNombre.Value != "")
                {
                    if (PrimerApellido.Value == "" || PrimerNombre.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Complete nombre y apellido');", true);
                    }
                    else
                    {
                        string nombres = PrimerApellido.Value + " " + SegundoApellido.Value + "," + PrimerNombre.Value + " " + SegundoNombre.Value;
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                    }
                }
                else if (PrimerNombre.Value != "")
                {
                    if(SegundoNombre.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ingresar los dos nombres');", true);
                    }
                    else
                    {
                        string nombres = PrimerNombre.Value + " " + SegundoNombre.Value;
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                       
                    }
                }
                else if (SegundoNombre.Value != "")
                {
                    if (PrimerNombre.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ingresar los dos nombres');", true);
                    }
                    else
                    {
                        string nombres = PrimerNombre.Value + " " + SegundoNombre.Value;
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                    }
                }
                else if (PrimerApellido.Value != "")
                {
                    if (SegundoApellido.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ingresar los dos apellidos');", true);
                    }
                    else
                    {
                        string nombres = PrimerApellido.Value + " " + SegundoApellido.Value;
                        string stado = Convert.ToString(WS.State);
                        
                        Response.Write(stado);
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                    }
                }
                else if (SegundoApellido.Value != "")
                {
                    if (PrimerApellido.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Ingresar los dos apellidos');", true);
                    }
                    else
                    {
                        string nombres = PrimerApellido.Value + " " + SegundoApellido.Value;
                        if (WS.buscarcreditosasociados(nombres).Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                        }
                        else
                        {
                            gridview2.DataSource = WS.buscarcreditosasociados(nombres);
                            gridview2.DataBind();
                        }
                    }
                }
                

                //----SEGUNDO----
                //if (Apellidos.Value != "" && Nombres.Value != "")
                //{
                //    string nombre = Apellidos.Value + "," + Nombres.Value;
                //    gridview2.DataSource = WS.buscarcreditosasociados(nombre);
                //    gridview2.DataBind();
                //}
                //else if (Apellidos.Value != "")
                //{
                //    gridview2.DataSource = WS.buscarcreditosasociados(Apellidos.Value);
                //    gridview2.DataBind();
                //}
                //else if (Nombres.Value != "")
                //{
                //    gridview2.DataSource = WS.buscarcreditosasociados(Nombres.Value);
                //    gridview2.DataBind();
            }

                //----PRIMERA----
                //    string var1 = WS.buscarcredito(NumCredito.Value);
                //    char delimitador = '|';
                //    string[] valoresprocesados = var1.Split(delimitador);
                //    if (var1.Length == 4)
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Crédito no encontrado');", true);
                //    }
                //    else
                //    {
                //        Session["credito"] = NumCredito.Value;
                //        Response.Redirect("ProcesoJudicial.aspx");
                //    }
                //}


                //if (NumCredito.Value == "" && Nombres.Value == "" && Apellidos.Value == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe ingresar al menos un dato');", true);
                //}
                //else
                //{
                //    string[] campos = sn.obtenerdatoscredito(NumCredito.Value, Nombres.Value, Apellidos.Value);
                //    string numcredito = campos[0];
                //    if (numcredito == null)
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se encuentra crédito con esos datos');", true);
                //    }
                //    else
                //    {

                //        llenargridviewcredito();
                //        tablaC.Visible = true;
                //        //llamarwebservice();

                //    }
                //}
            //}
        }

        protected void OnSelectedIndexChangedprospectos(object sender, EventArgs e)
        {
            string codigo;
            GridViewRow row = gridview2.SelectedRow;
            codigo = (gridview2.SelectedRow.FindControl("lblnumerocred") as Label).Text;
            //mostrar los otros datos
            Session["credito"] = codigo;
            Response.Redirect("ProcesoJudicial.aspx");
        }

        //protected void APAsignar_Click(object sender, EventArgs e)
        //{
        //    string confirmar = Session["confirmar"] as string;
        //    if (confirmar == "0")
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe confirmar antes los datos');", true);
        //    }
        //    else
        //    {
        //        string fechaactual = sn.datetime();
        //        string[] fecha = fechaactual.Split(' ');
        //        string año = fecha[0];
        //        string mes = fecha[1];
        //        string dia = fecha[2];

        //        string fechafinal = año + '-' + mes + '-' + dia;

        //        string sig = sn.siguiente("pj_asignacion_juridico", "idpj_asignacion_jutidico");
        //        sn.asignarcreditojuridico(sig, NumPrestamo.Value, fechafinal, "Pendiente");
        //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Se asignó el crédito');", true);
        //    }
        //}

        protected void Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void llenargridviewcredito()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT A.idpj_credito AS Credito, A.pj_nombrecliente AS Nombre, A.pj_status AS Estado, B.gen_areanombre AS DeArea, C.pj_comentario AS Comentario, A.pj_fecha AS Fecha FROM pj_etapa_credito AS A INNER JOIN pj_area AS B ON A.gen_area = B.codgenarea INNER JOIN pj_bitacora AS C ON(C.pj_numcredito = A.idpj_credito AND C.pj_estado = A.pj_status AND A.gen_area = C.pj_deArea) WHERE A.pj_status = 'Devuelto' ";
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
            Response.Redirect("DevueltosCobros.aspx");
        }

        public void llamarwebservice()
        {
            string var1 = WS.buscarcredito("9900687687");
            char delimitador = '|';
            string[] valoresprocesados = var1.Split(delimitador);
            if (var1.Length == 1)
            {
                Response.Write("NO HAY DATOS QUE MOSTRARA");
            }
            else
            {
                for (int i = 0; i < valoresprocesados.Length; i++)
                {
                    Response.Write(valoresprocesados[i] + "<br>");
                }

            }
        }

        protected void Prueba_Click(object sender, EventArgs e)
        {
            llamarwebservice();
        }
    }
}