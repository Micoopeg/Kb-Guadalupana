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
            sesion = Session["Nombre"].ToString();
            nombre = Session["IDReporte1"].ToString();

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra Mostrar" + nombre + "');", true);

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];

            //Response.Write(cifnumero);

            string[] valores1 = new string[35];
            string[] var3 = sn.consultarinformaciong(nombre);
            for (int i = 0; i < var3.Length; i++)
            {
                CIF.Value = nombre;
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

        public void mostrarIE()
        {
            sesion = Session["Nombre"].ToString();
            nombre = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];

            MySqlDataReader mostrar = logic.consultarIE("ep_informaciongeneral", "codepinformaciongeneralcif", nombre);
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

        public void mostrarIO()
        {
            sesion = Session["Nombre"].ToString();
            nombre = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];

            MySqlDataReader mostrar = logic.consultarIO("ep_informaciongeneral", "codepinformaciongeneralcif", nombre);
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

        public void llenargridviewcelulares()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                nombre = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];

                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;

                MySqlDataReader mostrar = logic.consultarcif(nombre);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT a.codeptelefono,a.codeptipotelefono,b.ep_tipotelefononombre,a.ep_telefononumero " +
                        "FROM ep_telefono a " +
                        "INNER JOIN ep_tipotelefono b " +
                        "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='" + cif + "';";
                        // "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='"+cifactual+"';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds3 = new DataTable();
                        myCommand.Fill(ds3);
                        GridViewcelular.DataSource = ds3;
                        GridViewcelular.DataBind();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch
            {
            }
        }

        public void llenargridviewhijos()
        {

            try
            {
                sesion = Session["Nombre"].ToString();
                nombre = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];

                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;

                MySqlDataReader mostrar = logic.consultarcif(nombre);
                try
                {
                    cif = Convert.ToString(mostrar.GetString(0));

                    string QueryString = "SELECT codepinfofamiliar,ep_infofamiliarnombrehijos,ep_infofamiliarocupacionhijos,ep_infofamiliarfechanacimientohijo,ep_infofamiliarcomentario " +
                        "FROM ep_infofamiliar " +
                        "WHERE codepinformaciongeneralcif='" + cif + "';";
                    //  "WHERE codepinformaciongeneralcif='"+cifactual+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewhijos.DataSource = ds4;
                    GridViewhijos.DataBind();

                }
                catch
                {
                }
            }
            catch
            {
            }


        }

        public void llenargridviewestudios()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                nombre = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];

                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;

                MySqlDataReader mostrar = logic.consultarcif(nombre);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT * FROM ep_estudio where codepinformaciongeneralcif='" + cif + "'  AND ep_estudiotipo=1;";
                        //string QueryString = "SELECT * FROM ep_estudio where codepinformaciongeneralcif='"+cifactual+"'  AND ep_estudiotipo=1;";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewEstudios.DataSource = ds4;
                        GridViewEstudios.DataBind();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            catch
            {
            }
        }
    }
}