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

namespace KB_Guadalupana.Views.Sesion.ReportesAdmin
{
    public partial class ReporteAdmin1 : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string completo, nombre1, nombre2, apellido1, apellido2;
        string sesion;
        string nombre;

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarIG();
            mostrarIE();
            mostrarIO();
            llenargridviewcelulares();
            llenargridviewhijos();
            llenargridviewestudios();

            //CIF.Value = Session["cif"].ToString();
            //Response.Write(subcadena+" "+ subcadena1+" "+ subcadena3);
        }

        public void mostrarIG()
        {
            sesion = Session["IDReporte1"].ToString();

            //Response.Write(cifnumero);

            string[] valores1 = new string[35];
            string[] var3 = sn.consultarinformaciong(sesion);

            for (int i = 0; i < var3.Length; i++)
            {
                CIF.Value = sesion;
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
            sesion = Session["IDReporte1"].ToString();

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Usuario" + sesion + "');", true);

            MySqlDataReader mostrar = logic.consultarIE("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
            try
            {
                if (mostrar.Read())
                {
                    EstadoCIF.Value = Convert.ToString(mostrar.GetString(0));
                    NombreCF.Value = Convert.ToString(mostrar.GetString(1));
                    OcupacionCIF.Value = Convert.ToString(mostrar.GetString(2));
                    ApellidoCIF.Value = Convert.ToString(mostrar.GetString(3));
                    FechaBIF.Value = Convert.ToString(mostrar.GetString(4));
                    FechaCIF.Value = Convert.ToString(mostrar.GetString(5));
                    NombreEC.Value = Convert.ToString(mostrar.GetString(6));
                    NumeroEC.Value = Convert.ToString(mostrar.GetString(7));
                    ParentescoEC.Value = Convert.ToString(mostrar.GetString(8));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        //Estudios Universitarios
        public void mostrarIO()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarIO("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
            try
            {
                if (mostrar.Read())
                {
                    CarreraEU.Value = Convert.ToString(mostrar.GetString(0));
                    SemestreEU.Value = Convert.ToString(mostrar.GetString(1));
                    AñoEU.Value = Convert.ToString(mostrar.GetString(2));
                    IdiomaEU.Value = Convert.ToString(mostrar.GetString(3));
                    UniverEU.Value = Convert.ToString(mostrar.GetString(4));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        //Celulares
        public void llenargridviewcelulares()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();
                string cif;

                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + cif + "');", true);
                        string QueryString = "SELECT a.codeptelefono,a.codeptipotelefono,b.ep_tipotelefononombre,a.ep_telefononumero " +
                            "FROM ep_telefono a " +
                            "INNER JOIN ep_tipotelefono b " +
                            "ON a.codeptipotelefono=b.codeptipotelefono " +
                            "inner join ep_informaciongeneral c ON a.codepinformaciongeneralcif = c.codepinformaciongeneralcif " +
                            "WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                        // "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='"+cifactual+"';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds3 = new DataTable();
                        myCommand.Fill(ds3);
                        GridViewcelular.DataSource = ds3;
                        GridViewcelular.DataBind();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
        }

        //Hijos
        public void llenargridviewhijos()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();

                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hijos: " + cif + "');", true);
                string QueryString = "select t1.codepinfofamiliar,t1.ep_infofamiliarnombrehijos,t1.ep_infofamiliarocupacionhijos," +
                    " t1.ep_infofamiliarcomentario, t1.ep_infofamiliarfechanacimientohijo " +
                    "from ep_informaciongeneral t0 " +
                    "inner join ep_infofamiliar t1 " +
                    "on t0.codepinformaciongeneralcif = t1.codepinformaciongeneralcif " +
                    "where t0.ep_informaciongeneralcif='" + sesion + "'";
                //  "WHERE codepinformaciongeneralcif='"+cifactual+"';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewhijos.DataSource = ds4;
                GridViewhijos.DataBind();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        //Otros Estudios
        public void llenargridviewestudios()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();

                string cif;
                 string QueryString = "SELECT * FROM ep_estudio t0 inner join ep_informaciongeneral t1 on t0.codepinformaciongeneralcif=t1.codepinformaciongeneralcif " +
                            "where t1.ep_informaciongeneralcif='" + sesion + "'  AND t0.ep_estudiotipo=1";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewEstudios.DataSource = ds4;
                        GridViewEstudios.DataBind();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
    }
}