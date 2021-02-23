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
    public partial class ReporteAdmin2 : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string cifactual;
        string sesion;
        int TVC = 0, TVM = 0, TVT = 0;
        int ESC = 0, ESM = 0, EST = 0;
        int LC = 0, LM = 0, LT = 0;
        int SC = 0, SM = 0, ST = 0;
        int EC = 0, EM = 0, ET = 0;
        int RC = 0, RM = 0, RT = 0;
        int CC = 0, CM = 0, CT = 0;
        int OC = 0, OM = 0, OT = 0;
        string firma;
        string Nombre, usuario;
        string cifnom;

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarCaja();
            llenargridviewcuentasvarias();
            //llenargridviewcuentasencoperativa();
            llenargridviewcuentasporcobrar();
            mostrarInventario();
            llenargridviewbienesinmuebles();
            llenargridviewvehiculos();
            mostrarmaquinaria();
            mostrarmenaje();
            mostrarmenaje1();
            mostrarmenaje2();
            mostrarTV();
            mostrarES();
            mostrarL();
            llenargridviewcuentasporpagar();
            llenargridviewpasivos();
            llenargridviewtarjetas();
            mostrarSec();
            mostrarEstufa();
            mostrarRefri();
            mostrarTel();
            mostrarOtros();
            mostrarOtrasDeudas();
            mostrarPasivoC();
            mostrarIngresos();
            mostrarNegocio();
            mostrarRemesas();
            mostrarEgresos();

            Nombre = Session["nombre"].ToString();
            usuario = Session["sesion_usuario"].ToString();
        }

        public void mostrarCaja()
        {

            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarCaja("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            CajaA.Value = Convert.ToString(mostrar.GetString(0));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

        public void llenargridviewcuentasvarias()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepcuentas,a.codeptipocuenta,a.codepinstitucion,a.codeptipoestatuscuenta,a.codeptipomoneda," +
                   "b.ep_tipocuentanombre,c.ep_institucionnombre,d.ep_tipoestatuscuentanombre,e.ep_tipomonedanombre,ep_cuentasmonto,ep_cuentasorigen " +
                   "FROM ep_cuentas a " +
                   "INNER JOIN ep_tipocuenta b " +
                   "INNER JOIN ep_institucion c " +
                   "INNER JOIN ep_tipoestatuscuenta d " +
                   "INNER JOIN ep_tipomoneda e ON a.codeptipocuenta=b.codeptipocuenta AND a.codepinstitucion=c.codepinstitucion " +
                   "AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta  AND a.codeptipomoneda=e.codeptipomoneda " +
                   "WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewcuentasvarias.DataSource = ds4;
                        GridViewcuentasvarias.DataBind();

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

        //public void llenargridviewcuentasencoperativa()
        //{
        //    try
        //    {
        //        sesion = Session["Nombre"].ToString();
        //        string[] partes = sesion.Split(' ');
        //        string nombre1 = partes[0];
        //        string nombre2 = partes[1];
        //        string apellido1 = partes[2];
        //        //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
        //        string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
        //        string cifnumero = var10[0];
        //        string cif;
        //        //Response.Write(cifnumero);

        //        MySqlDataReader mostrar = logic.consultarcif(cifnumero);
        //        try
        //        {
        //            if (mostrar.Read())
        //            {
        //                cif = Convert.ToString(mostrar.GetString(0));

        //                string QueryString = "SELECT a.codepcuentas,a.codepinstitucion,a.codeptipomoneda,a.codeptipoestatuscuenta," +
        //                " b.ep_institucionnombre,c.ep_tipomonedanombre,d.ep_tipoestatuscuentanombre,ep_cuentasmonto,ep_cuentasorigen " +
        //                "FROM ep_cuentas a" +
        //                " INNER JOIN ep_institucion b " +
        //                "INNER JOIN ep_tipomoneda c" +
        //                " INNER JOIN ep_tipoestatuscuenta d " +
        //                "ON a.codepinstitucion=b.codepinstitucion AND a.codeptipomoneda=c.codeptipomoneda AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta " +
        //                "WHERE b.codeptipoinstitucion=3 AND codepinformaciongeneralcif='"+cif+"';";
        //                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
        //                DataTable ds4 = new DataTable();
        //                myCommand.Fill(ds4);
        //                GridViewcuentascooperativa.DataSource = ds4;
        //                GridViewcuentascooperativa.DataBind();

        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            Console.WriteLine(err.Message);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        public void llenargridviewcuentasporcobrar()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif='" + cif + "' AND codeptipocuenta=4;";
                        //  string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif='"+cifactual+"';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewcuentasporcobrar.DataSource = ds4;
                        GridViewcuentasporcobrar.DataBind();
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

        public void mostrarInventario()
        {

            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarInv("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            NombreM.Value = Convert.ToString(mostrar.GetString(0));
                            MontoM.Value = Convert.ToString(mostrar.GetString(1));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewbienesinmuebles()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble,ep_inmueblefolio,ep_inmueblelibro,ep_inmuebledireccion,ep_inmueblevalor,ep_inmuebledescripcion" +
                        " FROM ep_inmueble a " +
                        "INNER JOIN ep_tipoinmueble b " +
                        "ON a.codeptipoinmueble=b.codeptipoinmueble WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewbienesinmuebles.DataSource = ds4;
                        GridViewbienesinmuebles.DataBind();

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

        public void llenargridviewvehiculos()
        {

            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();

                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre,ep_vehiculomarca,ep_vehiculolinea,ep_vehiculomodelo,ep_vehiculoplaca " +
                   "FROM ep_vehiculo a " +
                   "INNER JOIN ep_tipovehiculo b " +
                   "ON a.codeptipovehiculo = b.codeptipovehiculo WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewvehiculos.DataSource = ds4;
                        GridViewvehiculos.DataBind();

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

        public void mostrarmaquinaria()
        {

            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmaquinaria("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            TMaquinaria.Value = Convert.ToString(mostrar.GetString(0));
                            TMaquinariaEs.Value = Convert.ToString(mostrar.GetString(1));
                            TMaquinariaMonto.Value = Convert.ToString(mostrar.GetString(2));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarmenaje()
        {

            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();

            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmenaje("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            EComputo.Value = Convert.ToString(mostrar.GetString(0));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarmenaje1()
        {

            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmenaje1("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            AmuebladoS.Value = Convert.ToString(mostrar.GetString(0));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarmenaje2()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmenaje2("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            AmuebladoCom.Value = Convert.ToString(mostrar.GetString(0));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarTV()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarTV("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            TVC = Convert.ToInt32(mostrar.GetString(0));
                            TVM = Convert.ToInt32(mostrar.GetString(1));

                            TVT = TVC * TVM;
                            TelevisorC.Value = TVC.ToString();
                            TelevisorM.Value = TVM.ToString();
                            TelevisorT.Value = TVT.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarES()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarES("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            ESC = Convert.ToInt32(mostrar.GetString(0));
                            ESM = Convert.ToInt32(mostrar.GetString(1));

                            EST = ESC * ESM;
                            EquipoSC.Value = ESC.ToString();
                            EquipoSM.Value = ESM.ToString();
                            EquipoST.Value = EST.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarL()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarL("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            LC = Convert.ToInt32(mostrar.GetString(0));
                            LM = Convert.ToInt32(mostrar.GetString(1));

                            LT = LC * LM;
                            LavadoraC.Value = LC.ToString();
                            LavadoraM.Value = LM.ToString();
                            LavadoraT.Value = LT.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewcuentasporpagar()
        {

            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();
                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre,ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto" +
                   " FROM ep_cuentasporpagar a " +
                   "INNER JOIN ep_tipocuentaspopagar b " +
                   "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewcuentasporpagar.DataSource = ds4;
                        GridViewcuentasporpagar.DataBind();

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

        public void llenargridviewpasivos()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();
                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));

                        string QueryString = "SELECT codepprestamo,a.codeptipoprestamo,a.codepinstitucion,a.codeptipoinstitucion,b.ep_tipoprestamonombre,d.ep_tipoinstitucionnombre,c.ep_institucionnombre,ep_prestamomomentoinicial,ep_prestamosaldoactual,ep_prestamodestino,ep_prestamofechadesembolso,ep_prestamofechadefinalizacion " +
                    "FROM ep_prestamo a " +
                    "INNER JOIN ep_tipoprestamo b " +
                    "INNER JOIN ep_institucion c " +
                    "INNER JOIN ep_tipoinstitucion d " +
                    "ON a.codeptipoprestamo=b.codeptipoprestamo AND a.codepinstitucion=c.codepinstitucion AND a.codeptipoinstitucion=d.codeptipoinstitucion  " +
                    "WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewpasivos.DataSource = ds4;
                        GridViewpasivos.DataBind();

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

        public void llenargridviewtarjetas()
        {
            try
            {
                sesion = Session["Nombre"].ToString();
                cifnom = Session["IDReporte1"].ToString();
                string[] partes = sesion.Split(' ');
                string nombre1 = partes[0];
                string nombre2 = partes[1];
                string apellido1 = partes[2];
                //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);
                string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
                string cifnumero = var10[0];
                string cif;
                //Response.Write(cifnumero);

                MySqlDataReader mostrar = logic.consultarcif(cifnom);
                try
                {
                    if (mostrar.Read())
                    {
                        cif = Convert.ToString(mostrar.GetString(0));


                        string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion," +
                            "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz,ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual " +
                            "FROM ep_tarjetadecredito a " +
                            "INNER JOIN ep_tipoinstitucion b " +
                            "INNER JOIN ep_institucion c " +
                            "ON a.codeptipoinstitucion=b.codeptipoinstitucion AND a.codepinstitucion=c.codepinstitucion  WHERE codepinformaciongeneralcif='" + cif + "';";
                        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                        DataTable ds4 = new DataTable();
                        myCommand.Fill(ds4);
                        GridViewtarjetas.DataSource = ds4;
                        GridViewtarjetas.DataBind();

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

        public void mostrarSec()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarSec("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            SC = Convert.ToInt32(mostrar.GetString(0));
                            SM = Convert.ToInt32(mostrar.GetString(1));

                            ST = SC * SM;
                            SecadoraC.Value = SC.ToString();
                            SecadoraM.Value = SM.ToString();
                            SecadoraT.Value = ST.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarEstufa()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarEst("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            EC = Convert.ToInt32(mostrar.GetString(0));
                            EM = Convert.ToInt32(mostrar.GetString(1));

                            ET = EC * EM;
                            EstufaC.Value = EC.ToString();
                            EstufaM.Value = EM.ToString();
                            EstufaT.Value = ET.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarRefri()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarRefri("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            RC = Convert.ToInt32(mostrar.GetString(0));
                            RM = Convert.ToInt32(mostrar.GetString(1));

                            RT = RC * RM;
                            RefriC.Value = RC.ToString();
                            RefriM.Value = RM.ToString();
                            RefriT.Value = RT.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarTel()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarTel("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            CC = Convert.ToInt32(mostrar.GetString(0));
                            CM = Convert.ToInt32(mostrar.GetString(1));

                            CT = CC * CM;
                            TMC.Value = CC.ToString();
                            TMM.Value = CM.ToString();
                            TMT.Value = CT.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

        public void mostrarOtros()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarOtros("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            OC = Convert.ToInt32(mostrar.GetString(0));
                            OM = Convert.ToInt32(mostrar.GetString(1));

                            OT = OC * OM;
                            OtrosC.Value = OC.ToString();
                            OtrosM.Value = OM.ToString();
                            OtrosT.Value = OT.ToString();

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarOtrasDeudas()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarOD("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            EspD.Value = Convert.ToString(mostrar.GetString(0));
                            EspM.Value = Convert.ToString(mostrar.GetString(1));

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarPasivoC()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmostrarPC("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            NombreEN.Value = Convert.ToString(mostrar.GetString(0));
                            NombreD.Value = Convert.ToString(mostrar.GetString(1));
                            RelacionD.Value = Convert.ToString(mostrar.GetString(2));
                            SaldoD.Value = Convert.ToString(mostrar.GetString(3));
                            FechaDD.Value = Convert.ToString(mostrar.GetString(4));
                            FechaFina.Value = Convert.ToString(mostrar.GetString(5));

                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarIngresos()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmostrarIng("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            SuelB.Value = Convert.ToString(mostrar.GetString(0));
                            SBoni.Value = Convert.ToString(mostrar.GetString(1));
                            CMensua.Value = Convert.ToString(mostrar.GetString(2));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarNegocio()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnumero);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmostrarNeg("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            TipoNeg.Value = Convert.ToString(mostrar.GetString(0));
                            NombreNeg.Value = Convert.ToString(mostrar.GetString(1));
                            NoNeg.Value = Convert.ToString(mostrar.GetString(2));
                            EmpleNeg.Value = Convert.ToString(mostrar.GetString(3));
                            ObjNeg.Value = Convert.ToString(mostrar.GetString(4));
                            IngeNeg.Value = Convert.ToString(mostrar.GetString(5));
                            EgrNeg.Value = Convert.ToString(mostrar.GetString(6));
                            DireNeg.Value = Convert.ToString(mostrar.GetString(7));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

        public void mostrarRemesas()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmostrarRem("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            NomRem.Value = Convert.ToString(mostrar.GetString(0));
                            RelaRem.Value = Convert.ToString(mostrar.GetString(1));
                            MontoRem.Value = Convert.ToString(mostrar.GetString(2));
                            PeriRem.Value = Convert.ToString(mostrar.GetString(3));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarEgresos()
        {
            sesion = Session["Nombre"].ToString();
            cifnom = Session["IDReporte1"].ToString();
            string[] partes = sesion.Split(' ');
            string nombre1 = partes[0];
            string nombre2 = partes[1];
            string apellido1 = partes[2];

            //Response.Write(nombre1 + " " + nombre2 + " " + apellido1);

            string[] var10 = sn.consultarcif(nombre1, nombre2, apellido1);
            string cifnumero = var10[0];
            string cif;
            //Response.Write(cifnumero);

            MySqlDataReader mostrars = logic.consultarcif(cifnom);
            try
            {
                if (mostrars.Read())
                {
                    cif = Convert.ToString(mostrars.GetString(0));

                    MySqlDataReader mostrar = logic.consultarmostrarEgres("ep_informaciongeneral", "codepinformaciongeneralcif", cif);
                    try
                    {
                        if (mostrar.Read())
                        {
                            Alimen.Value = Convert.ToString(mostrar.GetString(2));
                            Gas.Value = Convert.ToString(mostrar.GetString(3));
                            PagoEstud.Value = Convert.ToString(mostrar.GetString(4));
                            Presta.Value = Convert.ToString(mostrar.GetString(5));
                            TarCre.Value = Convert.ToString(mostrar.GetString(6));
                            Vestuar.Value = Convert.ToString(mostrar.GetString(7));
                            Recrea.Value = Convert.ToString(mostrar.GetString(8));
                            Otros.Value = Convert.ToString(mostrar.GetString(9));
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}