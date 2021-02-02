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
    public partial class ReporteEP : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string cifactual;
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

        protected void Page_Load(object sender, EventArgs e)
        {

            mostrarIG();
            mostrarIE();
            mostrarIO();
            llenargridviewcelulares();
            llenargridviewhijos();
            llenargridviewestudios();
            mostrarCaja();
            llenargridviewcuentasvarias();
            llenargridviewcuentasencoperativa();
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

            NombreC.Value = Session["nombre"].ToString();
            Nombre = Session["nombre"].ToString();
            usuario = Session["sesion_usuario"].ToString();


            FRmE.Value = usuario;
            FRmE1.Value = Nombre;
        }

        public void mostrarIG()
        {

            string[] valores1 = new string[35];
            string[] var3 = sn.consultarconcampo("ep_informaciongeneral", "codepinformaciongeneralcif", cifactual);
            for (int i = 0; i < var3.Length; i++)
            {
                CIF.Value = Convert.ToString(var3[0]);
                PuestoIG.Value = Convert.ToString(var3[1]);
                AgenciaIG.Value = Convert.ToString(var3[2]);
                AreaIG.Value = Convert.ToString(var3[3]);
                PApellidoIG.Value = Convert.ToString(var3[4]);
                SApellidoIG.Value = Convert.ToString(var3[5]);
                PNombreIG.Value = Convert.ToString(var3[6]);
                SNombreIG.Value = Convert.ToString(var3[7]);
                DepaIG.Value = Convert.ToString(var3[8]);
                MuniIG.Value = Convert.ToString(var3[9]);
                ZonaIG.Value = Convert.ToString(var3[10]); 
                DireccIG.Value = Convert.ToString(var3[11]);
                TipoIdeIG.Value = Convert.ToString(var3[12]);
                NoDocIG.Value = Convert.ToString(var3[13]);
                FechaIG.Value = Convert.ToString(var3[14]);
                Nit1IG.Value = Convert.ToString(var3[15]);
                Nit2IG.Value = Convert.ToString(var3[16]);
                NacionalidadIG.Value = Convert.ToString(var3[17]);
                ReligionIG.Value = Convert.ToString(var3[18]);
                EstaturaIG.Value = Convert.ToString(var3[19]);
                PesoIG.Value = Convert.ToString(var3[20]);
                CorreoIG.Value = Convert.ToString(var3[21]);
            }

        }

        public void mostrarIE()
        {
            MySqlDataReader mostrar = logic.consultarIE("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarIO("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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

                string QueryString = "SELECT a.codeptelefono,a.codeptipotelefono,b.ep_tipotelefononombre,a.ep_telefononumero " +
                    "FROM ep_telefono a " +
                    "INNER JOIN ep_tipotelefono b " +
                    "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='1';";
                // "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='"+cifactual+"';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridViewcelular.DataSource = ds3;
                GridViewcelular.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewhijos()
        {
            try
            {

                string QueryString = "SELECT codepinfofamiliar,ep_infofamiliarnombrehijos,ep_infofamiliarocupacionhijos,ep_infofamiliarfechanacimientohijo,ep_infofamiliarcomentario " +
                    "FROM ep_infofamiliar " +
                    "WHERE codepinformaciongeneralcif=1;";
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

        public void llenargridviewestudios()
        {
            try
            {

                string QueryString = "SELECT * FROM ep_estudio where codepinformaciongeneralcif=1  AND ep_estudiotipo=1;";
                //string QueryString = "SELECT * FROM ep_estudio where codepinformaciongeneralcif='"+cifactual+"'  AND ep_estudiotipo=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewEstudios.DataSource = ds4;
                GridViewEstudios.DataBind();
            }
            catch
            {
            }
        }

        public void mostrarCaja()
        {
            MySqlDataReader mostrar = logic.consultarCaja("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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

        public void llenargridviewcuentasvarias()
        {
            try
            {

                string QueryString = "SELECT codepcuentas,a.codeptipocuenta,a.codepinstitucion,a.codeptipoestatuscuenta,a.codeptipomoneda," +
                    "b.ep_tipocuentanombre,c.ep_institucionnombre,d.ep_tipoestatuscuentanombre,e.ep_tipomonedanombre,ep_cuentasmonto,ep_cuentasorigen " +
                    "FROM ep_cuentas a " +
                    "INNER JOIN ep_tipocuenta b " +
                    "INNER JOIN ep_institucion c " +
                    "INNER JOIN ep_tipoestatuscuenta d " +
                    "INNER JOIN ep_tipomoneda e ON a.codeptipocuenta=b.codeptipocuenta AND a.codepinstitucion=c.codepinstitucion " +
                    "AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta  AND a.codeptipomoneda=e.codeptipomoneda " +
                    "WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasvarias.DataSource = ds4;
                GridViewcuentasvarias.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewcuentasencoperativa()
        {
            try
            {

                string QueryString = "SELECT a.codepcuentas,a.codepinstitucion,a.codeptipomoneda,a.codeptipoestatuscuenta," +
                    " b.ep_institucionnombre,c.ep_tipomonedanombre,d.ep_tipoestatuscuentanombre,ep_cuentasmonto,ep_cuentasorigen " +
                    "FROM ep_cuentas a" +
                    " INNER JOIN ep_institucion b " +
                    "INNER JOIN ep_tipomoneda c" +
                    " INNER JOIN ep_tipoestatuscuenta d " +
                    "ON a.codepinstitucion=b.codepinstitucion AND a.codeptipomoneda=c.codeptipomoneda AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta " +
                    "WHERE b.codeptipoinstitucion=3 AND codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentascooperativa.DataSource = ds4;
                GridViewcuentascooperativa.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewcuentasporcobrar()
        {
            try
            {

                string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif=1 AND codeptipocuenta=4;";
                //  string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif='"+cifactual+"';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasporcobrar.DataSource = ds4;
                GridViewcuentasporcobrar.DataBind();

            }
            catch
            {
            }
        }

        public void mostrarInventario()
        {
            MySqlDataReader mostrar = logic.consultarInv("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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

                string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble,ep_inmueblefolio,ep_inmueblelibro,ep_inmuebledireccion,ep_inmueblevalor,ep_inmuebledescripcion" +
                    " FROM ep_inmueble a " +
                    "INNER JOIN ep_tipoinmueble b " +
                    "ON a.codeptipoinmueble=b.codeptipoinmueble WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewbienesinmuebles.DataSource = ds4;
                GridViewbienesinmuebles.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewvehiculos()
        {
            try
            {

                string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre,ep_vehiculomarca,ep_vehiculolinea,ep_vehiculomodelo,ep_vehiculoplaca " +
                    "FROM ep_vehiculo a " +
                    "INNER JOIN ep_tipovehiculo b " +
                    "ON a.codeptipovehiculo = b.codeptipovehiculo WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewvehiculos.DataSource = ds4;
                GridViewvehiculos.DataBind();

            }
            catch
            {
            }
        }

        public void mostrarmaquinaria()
        {
            MySqlDataReader mostrar = logic.consultarmaquinaria("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmenaje("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmenaje1("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmenaje2("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarTV("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarES("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarL("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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

                string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre,ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto" +
                    " FROM ep_cuentasporpagar a " +
                    "INNER JOIN ep_tipocuentaspopagar b " +
                    "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewcuentasporpagar.DataSource = ds4;
                GridViewcuentasporpagar.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewpasivos()
        {
            try
            {

                string QueryString = "SELECT codepprestamo,a.codeptipoprestamo,a.codepinstitucion,a.codeptipoinstitucion,b.ep_tipoprestamonombre,d.ep_tipoinstitucionnombre,c.ep_institucionnombre,ep_prestamomomentoinicial,ep_prestamosaldoactual,ep_prestamodestino,ep_prestamofechadesembolso,ep_prestamofechadefinalizacion " +
                    "FROM ep_prestamo a " +
                    "INNER JOIN ep_tipoprestamo b " +
                    "INNER JOIN ep_institucion c " +
                    "INNER JOIN ep_tipoinstitucion d " +
                    "ON a.codeptipoprestamo=b.codeptipoprestamo AND a.codepinstitucion=c.codepinstitucion AND a.codeptipoinstitucion=d.codeptipoinstitucion  " +
                    "WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewpasivos.DataSource = ds4;
                GridViewpasivos.DataBind();

            }
            catch
            {
            }
        }

        public void llenargridviewtarjetas()
        {
            try
            {

                string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion," +
                    "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz,ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual " +
                    "FROM ep_tarjetadecredito a " +
                    "INNER JOIN ep_tipoinstitucion b " +
                    "INNER JOIN ep_institucion c " +
                    "ON a.codeptipoinstitucion=b.codeptipoinstitucion AND a.codepinstitucion=c.codepinstitucion  WHERE codepinformaciongeneralcif=1;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, cn.conectar());
                DataTable ds4 = new DataTable();
                myCommand.Fill(ds4);
                GridViewtarjetas.DataSource = ds4;
                GridViewtarjetas.DataBind();

            }
            catch
            {
            }
        }

        public void mostrarSec()
        {
            MySqlDataReader mostrar = logic.consultarSec("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarEst("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarRefri("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarTel("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarOtros("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarOD("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmostrarPC("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmostrarIng("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmostrarNeg("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmostrarRem("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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
            MySqlDataReader mostrar = logic.consultarmostrarEgres("ep_informaciongeneral", "codepinformaciongeneralcif", "1");
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