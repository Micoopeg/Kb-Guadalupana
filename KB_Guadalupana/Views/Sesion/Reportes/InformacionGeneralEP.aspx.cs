using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.Reportes
{
    public partial class InformacionGeneralEP : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string completo, nombre1, nombre2, apellido1, apellido2;
        string sesion;


        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarIG();
            mostrarIE();
            mostrarIO();
            llenargridviewcelulares();
            llenargridviewhijos();
            llenargridviewestudios();
            mostrarUser();

            //CIF.Value = Session["cif"].ToString();
            //Response.Write(subcadena+" "+ subcadena1+" "+ subcadena3);
        }

        //InformacionGeneral
        public void mostrarIG()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] valores1 = new string[35];
            string[] var3 = sn.consultarinformaciong(cifnumero);

            for (int i = 0; i < var3.Length; i++)
            {
                CIF.Value = cifnumero;
                AgenciaIG.Value = Convert.ToString(var3[0]);
                TipoIdeIG.Value = Convert.ToString(var3[2]);
                DepaIG.Value = Convert.ToString(var3[3]);
                MuniIG.Value = Convert.ToString(var3[4]);
                ZonaIG.Value = Convert.ToString(var3[5]);
                AreaIG.Value = Convert.ToString(var3[6]);

                nombre1 = Convert.ToString(var3[8]);
                apellido1 = Convert.ToString(var3[9]);
                apellido2 = Convert.ToString(var3[10]);
                FechaIG.Value = Convert.ToString(var3[12]);
                NoDocIG.Value = Convert.ToString(var3[13]);
                NacionalidadIG.Value = Convert.ToString(var3[14]);
                DireccIG.Value = Convert.ToString(var3[15]);
                EstaturaIG.Value = Convert.ToString(var3[16]);
                PesoIG.Value = Convert.ToString(var3[17]);
                ReligionIG.Value = Convert.ToString(var3[18]);
                CorreoIG.Value = Convert.ToString(var3[19]);
                Nit1IG.Value = Convert.ToString(var3[21]);
                Nit2IG.Value = Convert.ToString(var3[21]);
                PuestoIG.Value = Convert.ToString(var3[22]);
                nombre2 = Convert.ToString(var3[23]);

                PNombreIG.Value = nombre1;
                SNombreIG.Value = nombre2;
                PApellidoIG.Value = apellido1;
                SApellidoIG.Value = apellido2;
                completo = nombre1 + " " + nombre2 + " " + apellido1 + " " + apellido2;
                NombreC.Value = completo;
            }
        }

        //InformacionFamliar
        public void mostrarIE()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);

            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoIE(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                EstadoCIF.Value = Convert.ToString(var1[0]);
                NombreCF.Value = Convert.ToString(var1[1]);
                OcupacionCIF.Value = Convert.ToString(var1[2]);
                ApellidoCIF.Value = Convert.ToString(var1[3]);
                FechaBIF.Value = Convert.ToString(var1[4]);
                FechaCIF.Value = Convert.ToString(var1[5]);
                NombreEC.Value = Convert.ToString(var1[6]);
                NumeroEC.Value = Convert.ToString(var1[7]);
                ParentescoEC.Value = Convert.ToString(var1[8]);
            }
        }

        ////Estudios Universitarios
        public void mostrarIO()
        {
            sesion = Session["sesion_usuario"].ToString();

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);

            string[] var10 = sn.consultarcif(sesion);

            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoIO(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                CarreraEU.Value = Convert.ToString(var1[0]);
                SemestreEU.Value = Convert.ToString(var1[1]);
                AñoEU.Value = Convert.ToString(var1[2]);
                UniverEU.Value = Convert.ToString(var1[4]);
            }
        }

        //Celulares
        public void llenargridviewcelulares()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sesion = Session["sesion_usuario"].ToString();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    sqlCon.Open();
                    string QueryString = "SELECT a.codeptelefono,a.codeptipotelefono,b.ep_tipotelefononombre,a.ep_telefononumero " +
                           "FROM ep_telefono a " +
                           "INNER JOIN ep_tipotelefono b " +
                           "ON a.codeptipotelefono=b.codeptipotelefono " +
                           "inner join ep_informaciongeneral c ON a.codepinformaciongeneralcif = c.codepinformaciongeneralcif " +
                           "WHERE c.ep_informaciongeneralcif='" + cifnumero + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewcelular.DataSource = ds3;
                    GridViewcelular.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        //////Hijos
        public void llenargridviewhijos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioH(cifnumero);
                    vacio = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Sesion: " + vacio + "');", true);

                    if (vacio != "")
                    {
                        sqlCon.Open();
                        string QueryString = "select t1.codepinfofamiliar,t1.ep_infofamiliarnombrehijos,t1.ep_infofamiliarocupacionhijos," +
                                   " t1.ep_infofamiliarcomentario, t1.ep_infofamiliarfechanacimientohijo " +
                                   "from ep_informaciongeneral t0 " +
                                   "inner join ep_infofamiliar t1 " +
                                   "on t0.codepinformaciongeneralcif = t1.codepinformaciongeneralcif " +
                                   "where t0.ep_informaciongeneralcif='" + cifnumero + "'  AND t1.ep_infofamiliarfechanacimientohijo !='2020-04-08' ";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewhijos.DataSource = ds4;
                        GridViewhijos.DataBind();
                    }
                    else
                    {
                        titulo.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        //////Otros Estudios
        public void llenargridviewestudios()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioE(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra If');", true);
                        sqlCon.Open();
                        string QueryString = "SELECT * FROM ep_estudio t0 inner join ep_informaciongeneral t1 on t0.codepinformaciongeneralcif=t1.codepinformaciongeneralcif " +
                                "where t1.ep_informaciongeneralcif='" + cifnumero + "'  AND t0.ep_estudiotipo=1";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewEstudios.DataSource = ds4;
                        GridViewEstudios.DataBind();
                    }
                    else
                    {
                        Titulo1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        //Confirmar EP
        public void confirmarep_Click(object sender, EventArgs e)
        {
            string nombre;
            sesion = "";
            sesion = Session["sesion_usuario"].ToString();
            nombre = Session["Nombre"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero1 = var10[0];
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Sesion: " + cifnumero1 + "');", true);
            //string[] campos = { "codepinformaciongeneralcif", "codeptipoestado" };
            //string[] datos = { cifnumero1, "3" };
            sn.updateestadofinal(cifnumero1);

            string mensaje = "alert('Gracias " + nombre + ",tus datos han sido confirmados. '); window.location.href= '../CerrarSesion.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", mensaje, true);

        }

        public void mostrarUser()
        {
            string sesion1, sesion2;

            sesion1 = Session["sesion_usuario"].ToString();
            sesion2 = Session["Nombre"].ToString();
            Text2.Value = sesion1;
            Text1.Value = sesion2;

        }
    }
}