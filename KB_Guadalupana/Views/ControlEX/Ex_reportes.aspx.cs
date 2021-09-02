using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using Microsoft.Reporting.WebForms;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_reportes : System.Web.UI.Page
    {
        ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        Conexion conexiongeneral = new Conexion();
        KB_Rutas ruta = new KB_Rutas();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = '/';
        char delimitador3 = ' ';
        string cif;
        string rol;
        string area;
        string fechaactual;


        protected void Imprimir_Click(object sender, EventArgs e)
        {

            DateTime fechainicial = fechain.SelectedDate;
            DateTime fechafinal = fechafi.SelectedDate;

            string fi = Convert.ToString(fechainicial);
            string ff = Convert.ToString(fechafinal);
            if (fi != "1/01/0001 00:00:00" && ff != "1/01/0001 00:00:00")
            {
                string[] valores2 = fi.Split(delimitador3);
                string[] valores3 = valores2[0].Split(delimitador2);

                string[] valores4 = ff.Split(delimitador3);
                string[] valores5 = valores4[0].Split(delimitador2);




                if (valores3[0].Length != 1 && valores3[1].Length != 1 && valores5[0].Length != 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-" + valores5[0];

                }
                if (valores3[0].Length == 1 && valores3[1].Length != 1 && valores5[0].Length != 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length == 1 && valores5[0].Length != 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-0" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length == 1 && valores5[0].Length != 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-0" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length != 1 && valores5[0].Length == 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length != 1 && valores5[0].Length == 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length == 1 && valores5[0].Length == 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-0" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length == 1 && valores5[0].Length == 1 && valores5[1].Length != 1)
                {

                    fechahora = valores3[2] + "-0" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length != 1 && valores5[0].Length != 1 && valores5[1].Length == 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length != 1 && valores5[0].Length != 1 && valores5[1].Length == 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length == 1 && valores5[0].Length != 1 && valores5[1].Length == 1)
                {
                    fechahora = valores3[2] + "-0" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length == 1 && valores5[0].Length != 1 && valores5[1].Length == 1)
                {

                    fechahora = valores3[2] + "-0" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length != 1 && valores5[0].Length == 1 && valores5[1].Length == 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length != 1 && valores5[0].Length == 1 && valores5[1].Length == 1)
                {

                    fechahora = valores3[2] + "-" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length == 1 && valores3[1].Length == 1 && valores5[0].Length == 1 && valores5[1].Length == 1)
                {
                    fechahora = valores3[2] + "-0" + valores3[1] + "-0" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-0" + valores5[0];
                }
                if (valores3[0].Length != 1 && valores3[1].Length == 1 && valores5[0].Length == 1 && valores5[1].Length == 1)
                {
                    fechahora = valores3[2] + "-0" + valores3[1] + "-" + valores3[0];
                    fechaactual = valores5[2] + "-0" + valores5[1] + "-0" + valores5[0];
                }


                ReportViewer1.Reset();

                ReportDataSource fuente = new ReportDataSource("ARCHDATA", generarreposfecha(fechahora, fechaactual));



                ReportViewer1.LocalReport.DataSources.Add(fuente);


                ReportViewer1.LocalReport.ReportPath = "Views/ControlEX/Report1.rdlc";

                ReportViewer1.LocalReport.Refresh();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Elija un rango de fechas')", true);

            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);

            if (!IsPostBack)
            {
                llenaragencia();
                llenargarantia();
                llenarestados();
                llenaretapabwk();
            }

        }

        public void criterios()
        {
            DateTime fechainicial = fechain.SelectedDate;
            DateTime fechafinal = fechafi.SelectedDate;

            string fi = Convert.ToString(fechainicial);
            string ff = Convert.ToString(fechafinal);
            if (agenciass.SelectedIndex != 0 || estados.SelectedIndex != 0 || estatus.SelectedIndex != 0 || garantias.SelectedIndex != 0)
            {
                if (agenciass.SelectedIndex == 0 && estados.SelectedIndex == 0 && estatus.SelectedIndex != 0 && garantias.SelectedIndex == 0)
                {

                    ReportViewer1.Reset();
                    ReportDataSource fuente = new ReportDataSource("ARCHDATA", generarreposvigentes(estatus.SelectedValue));



                    ReportViewer1.LocalReport.DataSources.Add(fuente);


                    ReportViewer1.LocalReport.ReportPath = "Views/ControlEX/Report1.rdlc";

                    ReportViewer1.LocalReport.Refresh();



                }
                if (agenciass.SelectedIndex == 0 && estados.SelectedIndex != 0 && estatus.SelectedIndex == 0 && garantias.SelectedIndex == 0)
                {

                    ReportViewer1.Reset();
                    ReportDataSource fuente = new ReportDataSource("ARCHDATA", generarrepospendientes(""));



                    ReportViewer1.LocalReport.DataSources.Add(fuente);


                    ReportViewer1.LocalReport.ReportPath = "Views/ControlEX/Report1.rdlc";

                    ReportViewer1.LocalReport.Refresh();



                }




            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione un parametro')", true);

            }








        }

        protected void imprimirtodos_Click(object sender, EventArgs e)
        {


            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("ARCHDATA", generarrepos());



            ReportViewer1.LocalReport.DataSources.Add(fuente);


            ReportViewer1.LocalReport.ReportPath = "Views/ControlEX/Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();
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

        public void llenaragencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM ex_controlarea WHERE extipoarea = 1";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    agenciass.DataSource = ds;
                    agenciass.DataTextField = "ex_nombrea";
                    agenciass.DataValueField = "codexcontrolarea";
                    agenciass.DataBind();
                    agenciass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[AGENCIA]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenargarantia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM ex_tipocredito";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    garantias.DataSource = ds;
                    garantias.DataTextField = "ex_nomtipo";
                    garantias.DataValueField = "codextipocred";
                    garantias.DataBind();
                    garantias.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[GARANTÍA]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void imprimirporcriterios_Click(object sender, EventArgs e)
        {
            criterios();
        }

        public void llenarestados()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `ex_tipoevento` where codexevento = 7 OR codexevento = 1 OR  codexevento = 6";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    estados.DataSource = ds;
                    estados.DataTextField = "ex_evento";
                    estados.DataValueField = "codexevento";
                    estados.DataBind();
                    estados.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[ETAPA]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenaretapabwk()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM `ex_estatuscred`";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    estatus.DataSource = ds;
                    estatus.DataTextField = "estatus";
                    estatus.DataValueField = "codest";
                    estatus.DataBind();
                    estatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[ESTADO]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void agenciasrepo_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("agencias", generarrepoareagencias());



            ReportViewer1.LocalReport.DataSources.Add(fuente);


            ReportViewer1.LocalReport.ReportPath = "Views/ControlEX/Report2.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }

        private DataTable generarreposvigentes(string parametro)
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("Nocredito");
            dt3.Columns.Add("nomcom");
            dt3.Columns.Add("cifgeneral");
            dt3.Columns.Add("gen_monto");
            dt3.Columns.Add("gen_fechadesembolso");
            dt3.Columns.Add("ex_nomtipo");
            dt3.Columns.Add("estatus");

            if (parametro == "1")
            {





                dt4 = mex.reportearchivo();

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                    char delimitador = '|';
                    string[] valoresprocesados = estado.Split(delimitador);
                    if (estado.Length != 4)
                    {
                        if (valoresprocesados[2] == "VIGENTE AL DIA")
                        {
                            if (estado.Length != 4)
                            {


                                if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                                {

                                    DataRow row = dt3.NewRow();

                                    row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                                    row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                                    row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                                    row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                                    row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                                    row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                                    row["estatus"] = valoresprocesados[2].ToString();



                                    dt3.Rows.Add(row);
                                }












                            }
                        }
                    }
                }


            }

            if (parametro == "2")
            {

                dt4 = mex.reportearchivo();

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                    char delimitador = '|';
                    string[] valoresprocesados = estado.Split(delimitador);
                    if (valoresprocesados[2] == "CANCELADO")
                    {
                        if (estado.Length != 4)
                        {


                            if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                            {

                                DataRow row = dt3.NewRow();

                                row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                                row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                                row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                                row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                                row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                                row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                                row["estatus"] = valoresprocesados[2].ToString();



                                dt3.Rows.Add(row);
                            }












                        }
                    }

                }


            }








            return dt3;


        }

        private DataTable generarrepos()
        {


            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("Nocredito");
            dt3.Columns.Add("nomcom");
            dt3.Columns.Add("cifgeneral");
            dt3.Columns.Add("gen_monto");
            dt3.Columns.Add("gen_fechadesembolso");
            dt3.Columns.Add("ex_nomtipo");
            dt3.Columns.Add("estatus");




            dt4 = mex.reportearchivo();

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                char delimitador = '|';
                string[] valoresprocesados = estado.Split(delimitador);

                if (estado.Length != 4)
                {


                    if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                    {

                        DataRow row = dt3.NewRow();

                        row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                        row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                        row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                        row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                        row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                        row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                        row["estatus"] = valoresprocesados[2].ToString();



                        dt3.Rows.Add(row);
                    }












                }


            }


            return dt3;


        }

        private DataTable generarrepoareagencias()
        {


            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("ex_nombrea");
            dt3.Columns.Add("cargados");
            dt3.Columns.Add("mensajeria");
            dt3.Columns.Add("mesa");
            dt3.Columns.Add("juridico");
            dt3.Columns.Add("archivo");

            string[] agenciaas = mex.agencias();



            for (int i = 0; i < agenciaas.Length; i++)
            {


                DataRow row = dt3.NewRow();

                row["ex_nombrea"] = mex.nombreagencia(agenciaas[i]);
                row["cargados"] = mex.cargados(agenciaas[i]).ToString();
                row["mensajeria"] = mex.mensajeria(agenciaas[i]).ToString();
                row["mesa"] = mex.mesa(agenciaas[i]).ToString();
                row["juridico"] = mex.juridico(agenciaas[i]).ToString();
                row["archivo"] = mex.archivo(agenciaas[i]).ToString();




                dt3.Rows.Add(row);













            }





            return dt3;


        }
        private DataTable generarrepospendientes(string parametro)
        {


            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("Nocredito");
            dt3.Columns.Add("nomcom");
            dt3.Columns.Add("cifgeneral");
            dt3.Columns.Add("gen_monto");
            dt3.Columns.Add("gen_fechadesembolso");
            dt3.Columns.Add("ex_nomtipo");
            dt3.Columns.Add("estatus");




            dt4 = mex.reportearchivopendientes();


            if (parametro == "1")
            {





                dt4 = mex.reportearchivo();


                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                    char delimitador = '|';
                    string[] valoresprocesados = estado.Split(delimitador);

                    if (estado.Length != 4)
                    {


                        if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                        {

                            DataRow row = dt3.NewRow();

                            row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                            row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                            row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                            row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                            row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                            row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                            row["estatus"] = valoresprocesados[2].ToString();



                            dt3.Rows.Add(row);
                        }












                    }


                }

            }

            if (parametro == "2")
            {

                dt4 = mex.reportearchivo();

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                    char delimitador = '|';
                    string[] valoresprocesados = estado.Split(delimitador);
                    if (valoresprocesados[2] == "CANCELADO")
                    {
                        if (estado.Length != 4)
                        {


                            if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                            {

                                DataRow row = dt3.NewRow();

                                row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                                row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                                row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                                row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                                row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                                row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                                row["estatus"] = valoresprocesados[2].ToString();



                                dt3.Rows.Add(row);
                            }












                        }
                    }

                }


            }

            return dt3;


        }
        //private DataTable generarreposfecha(string fechaii, string fechaff)
        //{


        //    DataTable dt3 = new DataTable();
        //    DataTable dt4 = new DataTable();


        //    dt3.Columns.Add("Nocredito");
        //    dt3.Columns.Add("nomcom");
        //    dt3.Columns.Add("cifgeneral");
        //    dt3.Columns.Add("gen_monto");
        //    dt3.Columns.Add("gen_fechadesembolso");
        //    dt3.Columns.Add("ex_nomtipo");
        //    dt3.Columns.Add("estatus");




        //    dt4 = mex.reportearchivofecha(fechaii, fechaff);

        //    for (int i = 0; i < dt4.Rows.Count; i++)
        //    {
        //        string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
        //        char delimitador = '|';
        //        string[] valoresprocesados = estado.Split(delimitador);

        //        if (estado.Length != 4)
        //        {


        //            if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
        //            {

        //                DataRow row = dt3.NewRow();

        //                row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
        //                row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
        //                row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
        //                row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
        //                row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
        //                row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
        //                row["estatus"] = valoresprocesados[2].ToString();



        //                dt3.Rows.Add(row);
        //            }












        //        }


        //    }


        //    return dt3;


        //}

        private DataTable generarreposfecha(string fechaii, string fechaff)
        {


            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();


            dt3.Columns.Add("Nocredito");
            dt3.Columns.Add("nomcom");
            dt3.Columns.Add("cifgeneral");
            dt3.Columns.Add("gen_monto");
            dt3.Columns.Add("gen_fechadesembolso");
            dt3.Columns.Add("fecha_creacion");
            dt3.Columns.Add("ex_nomtipo");
            dt3.Columns.Add("ex_nombrea");
            dt3.Columns.Add("estatus");




            dt4 = mex.reportearchivofecha(fechaii, fechaff);

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                string estado = WS.buscarcreditoexpedientes(dt4.Rows[i]["Nocredito"].ToString());
                char delimitador = '|';
                string[] valoresprocesados = estado.Split(delimitador);

                if (estado.Length != 4)
                {


                    if (valoresprocesados[1] == dt4.Rows[i]["ex_nomtipo"].ToString())
                    {

                        DataRow row = dt3.NewRow();

                        row["Nocredito"] = dt4.Rows[i]["Nocredito"].ToString();
                        row["nomcom"] = dt4.Rows[i]["nomcom"].ToString();
                        row["cifgeneral"] = dt4.Rows[i]["cifgeneral"].ToString();
                        row["gen_monto"] = dt4.Rows[i]["gen_monto"].ToString();
                        row["gen_fechadesembolso"] = dt4.Rows[i]["gen_fechadesembolso"].ToString();
                        row["fecha_creacion"] = dt4.Rows[i]["fecha_creacion"].ToString();
                        row["ex_nomtipo"] = dt4.Rows[i]["ex_nomtipo"].ToString();
                        row["ex_nombrea"] = dt4.Rows[i]["ex_nombrea"].ToString();
                        row["estatus"] = valoresprocesados[2].ToString();



                        dt3.Rows.Add(row);
                    }












                }


            }


            return dt3;


        }

    }
}