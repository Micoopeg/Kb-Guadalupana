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

            //Nombre = Session["nombre"].ToString();
            //usuario = Session["sesion_usuario"].ToString();
        }

        public void mostrarCaja()
        {

            sesion = Session["IDReporte1"].ToString();
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Caja" + sesion + "');", true);
           
            try
            {
                /*ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + cifnumero+ "');", true);*/
                MySqlDataReader mostrar = logic.consultarCaja("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

        public void llenargridviewcuentasvarias()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                
                //Response.Write(cifnumero);
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + cifnumero + "');", true);
                string QueryString = "SELECT codepcuentas,a.codeptipocuenta,a.codepinstitucion," +
                            "a.codeptipoestatuscuenta,a.codeptipomoneda,b.ep_tipocuentanombre," +
                            "c.ep_institucionnombre,d.ep_tipoestatuscuentanombre," +
                            "e.ep_tipomonedanombre,ep_cuentasmonto,ep_cuentasorigen " +
                            "FROM ep_cuentas a INNER JOIN ep_tipocuenta b " +
                            "INNER JOIN ep_institucion c INNER JOIN ep_tipoestatuscuenta d " +
                            "INNER JOIN ep_tipomoneda e " +
                            "inner join ep_informaciongeneral f ON a.codeptipocuenta=b.codeptipocuenta " +
                            "AND a.codepinstitucion=c.codepinstitucion " +
                            "AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta " +
                            "AND a.codeptipomoneda=e.codeptipomoneda and a.codepinformaciongeneralcif=f.codepinformaciongeneralcif " +
                            "WHERE f.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasvarias.DataSource = ds4;
                GridViewcuentasvarias.DataBind();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewcuentasporcobrar()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
               
                string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas t0 " +
                    "inner JOIN ep_informaciongeneral t1 on t0.codepinformaciongeneralcif=t1.codepinformaciongeneralcif" +
                    " where t1.ep_informaciongeneralcif='" + sesion + "' AND t0.codeptipocuenta=4";
                //  string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif='"+cifactual+"';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasporcobrar.DataSource = ds4;
                GridViewcuentasporcobrar.DataBind();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarInventario()
        {

            sesion = Session["IDReporte1"].ToString();
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);

            MySqlDataReader mostrar = logic.consultarInv("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void llenargridviewbienesinmuebles()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
             
                string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble," +
                    "ep_inmueblefolio,ep_inmueblelibro,ep_inmuebledireccion,ep_inmueblevalor," +
                    "ep_inmuebledescripcion FROM ep_inmueble a INNER JOIN ep_tipoinmueble b " +
                    "INNER join ep_informaciongeneral c ON a.codeptipoinmueble=b.codeptipoinmueble" +
                    " and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif" +
                    " WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewbienesinmuebles.DataSource = ds4;
                GridViewbienesinmuebles.DataBind();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewvehiculos()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
               

                string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre," +
                    "ep_vehiculomarca,ep_vehiculolinea," +
                    "ep_vehiculomodelo,ep_vehiculoplaca " +
                    "FROM ep_vehiculo a INNER JOIN ep_tipovehiculo b " +
                    "inner join ep_informaciongeneral c ON a.codeptipovehiculo = b.codeptipovehiculo " +
                    "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewvehiculos.DataSource = ds4;
                GridViewvehiculos.DataBind();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarmaquinaria()
        {

            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmaquinaria("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarmenaje()
        {

            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmenaje("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarmenaje1()
        {

            sesion = Session["IDReporte1"].ToString();
            MySqlDataReader mostrar = logic.consultarmenaje1("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarmenaje2()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmenaje2("ep_informaciongeneral", "codepinformaciongeneralcif",sesion);
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

        public void mostrarTV()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarTV("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarES()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarES("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarL()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarL("ep_informaciongeneral", "codepinformaciongeneralcif",sesion);
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

        public void llenargridviewcuentasporpagar()
        {
            try
            {
                  sesion = Session["IDReporte1"].ToString();

                string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre," +
                    "ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto FROM ep_cuentasporpagar a " +
                    "INNER JOIN ep_tipocuentaspopagar b INNER JOIN ep_informaciongeneral c " +
                    "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar " +
                    "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif " +
                    "WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasporpagar.DataSource = ds4;
                GridViewcuentasporpagar.DataBind();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewpasivos()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();

                string QueryString = "SELECT codepprestamo,a.codeptipoprestamo,a.codepinstitucion,a.codeptipoinstitucion," +
                    "b.ep_tipoprestamonombre,d.ep_tipoinstitucionnombre," +
                    "c.ep_institucionnombre,ep_prestamomomentoinicial," +
                    "ep_prestamosaldoactual,ep_prestamodestino,ep_prestamofechadesembolso," +
                    "ep_prestamofechadefinalizacion FROM ep_prestamo a " +
                    "INNER JOIN ep_tipoprestamo b INNER JOIN ep_institucion c " +
                    "INNER JOIN ep_tipoinstitucion d " +
                    "INNER JOIN ep_informaciongeneral e " +
                    "ON a.codeptipoprestamo=b.codeptipoprestamo " +
                    "AND a.codepinstitucion=c.codepinstitucion " +
                    "AND a.codeptipoinstitucion=d.codeptipoinstitucion " +
                    "AND a.codepinformaciongeneralcif=e.codepinformaciongeneralcif " +
                    "WHERE e.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewpasivos.DataSource = ds4;
                GridViewpasivos.DataBind();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void llenargridviewtarjetas()
        {
            try
            {
                sesion = Session["IDReporte1"].ToString();


                string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion, " +
                    "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz," +
                    "ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual FROM ep_tarjetadecredito a " +
                    "INNER JOIN ep_tipoinstitucion b INNER JOIN ep_institucion c " +
                    "INNER JOIN ep_informaciongeneral d ON a.codeptipoinstitucion=b.codeptipoinstitucion " +
                    "AND a.codepinstitucion=c.codepinstitucion " +
                    "AND a.codepinformaciongeneralcif=d.codepinformaciongeneralcif " +
                    "WHERE d.ep_informaciongeneralcif='" + sesion + "'";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewtarjetas.DataSource = ds4;
                GridViewtarjetas.DataBind();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrarSec()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarSec("ep_informaciongeneral", "codepinformaciongeneralcif",sesion);
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

        public void mostrarEstufa()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarEst("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarRefri()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarRefri("ep_informaciongeneral", "codepinformaciongeneralcif",sesion);
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

        public void mostrarTel()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarTel("ep_informaciongeneral", "codepinformaciongeneralcif",sesion);
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

        public void mostrarOtros()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarOtros("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarOtrasDeudas()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarOD("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarPasivoC()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmostrarPC("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarIngresos()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmostrarIng("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarNegocio()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmostrarNeg("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarRemesas()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmostrarRem("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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

        public void mostrarEgresos()
        {
            sesion = Session["IDReporte1"].ToString();

            MySqlDataReader mostrar = logic.consultarmostrarEgres("ep_informaciongeneral", "codepinformaciongeneralcif", sesion);
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
}