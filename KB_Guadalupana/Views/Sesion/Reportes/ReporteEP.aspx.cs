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
        Conexion conexiongeneral = new Conexion();
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
            llenargridviewinversiones();
            mostrarSec();
            mostrarEstufa();
            mostrarRefri();
            mostrarTel();
            mostrarTel1();
            mostrarOtros();
            //mostrarFenafore();
            //mostrarOtros();
            mostrarOtrasDeudas();
            mostrarPasivoC();
            mostrarIngresos();
            mostrarNegocio();
            mostrarRemesas();
            mostrarEgresos();
            mostrarUser();

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

        public void mostrarCaja()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCaja(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                CajaA.Value = Convert.ToString(var1[0]);
            }
        }

        public void llenargridviewcuentasvarias()
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
                           "WHERE f.ep_informaciongeneralcif='" + cifnumero + "' and a.codeptipocuenta !='4'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewcuentasvarias.DataSource = ds4;
                    GridViewcuentasvarias.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewcuentasporcobrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioCP(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas t0 " +
                        "inner JOIN ep_informaciongeneral t1 on t0.codepinformaciongeneralcif=t1.codepinformaciongeneralcif" +
                        " where t1.ep_informaciongeneralcif='" + cifnumero + "' AND t0.codeptipocuenta=4";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewcuentasporcobrar.DataSource = ds4;
                        GridViewcuentasporcobrar.DataBind();
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

        public void mostrarInventario()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoInv(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                NombreM.Value = Convert.ToString(var1[0]);
                MontoM.Value = Convert.ToString(var1[1]);
            }
        }

        public void llenargridviewbienesinmuebles()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioIN(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble," +
                        "ep_inmueblefolio,ep_inmueblelibro,ep_inmuebledireccion,ep_inmueblevalor," +
                        "ep_inmuebledescripcion FROM ep_inmueble a INNER JOIN ep_tipoinmueble b " +
                        "INNER join ep_informaciongeneral c ON a.codeptipoinmueble=b.codeptipoinmueble" +
                        " and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif" +
                        " WHERE c.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewbienesinmuebles.DataSource = ds4;
                        GridViewbienesinmuebles.DataBind();
                    }
                    else
                    {
                        titulo1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewvehiculos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioVE(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre," +
                         "ep_vehiculomarca,ep_vehiculolinea," +
                         "ep_vehiculomodelo,ep_vehiculoplaca,a.ep_vehiculomonto " +
                         "FROM ep_vehiculo a INNER JOIN ep_tipovehiculo b " +
                         "inner join ep_informaciongeneral c ON a.codeptipovehiculo = b.codeptipovehiculo " +
                         "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif WHERE c.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewvehiculos.DataSource = ds4;
                        GridViewvehiculos.DataBind();
                    }
                    else
                    {
                        H1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewinversiones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioVE(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT d.codepinversiones,d.codeptipoinstitucion,d.codepinstitucion," +
                            " d.codeptipomoneda,a.ep_tipoinstitucionnombre,b.ep_institucionnombre," +
                            " c.ep_tipomonedanombre,d.ep_inversionesnombre,d.ep_inversionesplazo,d.ep_inversionesmonto, " +
                            "d.ep_inversionesorigen,d.ep_inversionesnumerocuenta FROM ep_inversiones d " +
                            "Inner Join ep_informaciongeneral e on d.codepinformaciongeneralcif=e.codepinformaciongeneralcif " +
                            "INNER JOIN ep_tipoinstitucion a INNER JOIN ep_institucion b " +
                            "INNER JOIN ep_tipomoneda c ON d.codeptipoinstitucion=a.codeptipoinstitucion " +
                            "AND d.codepinstitucion=b.codepinstitucion AND d.codeptipomoneda=c.codeptipomoneda " +
                            "WHERE e.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        gridviewinversiones.DataSource = ds4;
                        gridviewinversiones.DataBind();
                    }
                    else
                    {
                        H1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrarmaquinaria()
        {

            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomaq(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);


            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    TMaquinaria.Value = Convert.ToString(var1[0]);
                    TMaquinariaEs.Value = Convert.ToString(var1[1]);
                    TMaquinariaMonto.Value = Convert.ToString(var1[2]);
                }
            }
        }

        public void mostrarmenaje()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaje(cifnumero);
            string valor;
            valor = Convert.ToString(var1[0]);


            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    EComputo.Value = Convert.ToString(var1[0]);
                }
            }
        }

        public void mostrarmenaje1()
        {

            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaje1(cifnumero);
            string valor;
            valor = Convert.ToString(var1[0]);


            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    AmuebladoS.Value = Convert.ToString(var1[0]);
                }
            }
        }

        public void mostrarmenaje2()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaje2(cifnumero);
            string valor;
            valor = Convert.ToString(var1[0]);


            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    AmuebladoCom.Value = Convert.ToString(var1[0]);
                }
            }
        }

        public void mostrarTV()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenajeTV(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);

            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    TelevisorC.Value = Convert.ToString(var1[0]);
                    TelevisorM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void mostrarES()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenajeES(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    EquipoSC.Value = Convert.ToString(var1[0]);
                    EquipoSM.Value = Convert.ToString(var1[1]);

                }
            }
        }

        public void mostrarL()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenajeL(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);

            string valor1, valor2;
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    LavadoraC.Value = Convert.ToString(var1[0]);
                    LavadoraM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void llenargridviewcuentasporpagar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvacioCP1(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre," +
                       "ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto FROM ep_cuentasporpagar a " +
                       "INNER JOIN ep_tipocuentaspopagar b INNER JOIN ep_informaciongeneral c " +
                       "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar " +
                       "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif " +
                       "WHERE c.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewcuentasporpagar.DataSource = ds4;
                        GridViewcuentasporpagar.DataBind();
                    }
                    else
                    {
                        H2.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewpasivos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvaciopres(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
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
                         "WHERE e.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewpasivos.DataSource = ds4;
                        GridViewpasivos.DataBind();
                    }
                    else
                    {
                        H3.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewtarjetas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    string vacio1 = null;
                    sesion = Session["sesion_usuario"].ToString();
                    string[] var10 = sn.consultarcif(sesion);
                    string cifnumero = var10[0];
                    string[] var1 = sn.consultarvaciopretar(cifnumero);
                    vacio1 = Convert.ToString(var1[1]);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Valor: " + vacio1 + "');", true);

                    if ((vacio1 != "") && (vacio1 != null))
                    {
                        sqlCon.Open();
                        string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion, " +
                       "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz," +
                       "ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual FROM ep_tarjetadecredito a " +
                       "INNER JOIN ep_tipoinstitucion b INNER JOIN ep_institucion c " +
                       "INNER JOIN ep_informaciongeneral d ON a.codeptipoinstitucion=b.codeptipoinstitucion " +
                       "AND a.codepinstitucion=c.codepinstitucion " +
                       "AND a.codepinformaciongeneralcif=d.codepinformaciongeneralcif " +
                       "WHERE d.ep_informaciongeneralcif='" + cifnumero + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds4 = new DataTable();
                        command.Fill(ds4);
                        GridViewtarjetas.DataSource = ds4;
                        GridViewtarjetas.DataBind();
                    }
                    else
                    {
                        H4.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrarSec()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaSec(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);
            string valor1, valor2;
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    SecadoraC.Value = Convert.ToString(var1[0]);
                    SecadoraM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void mostrarEstufa()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaEST(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    EstufaC.Value = Convert.ToString(var1[0]);
                    EstufaM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void mostrarRefri()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaRefri(cifnumero);
            string valor;
            valor = Convert.ToString(var1[1]);
            string valor1, valor2;
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    RefriC.Value = Convert.ToString(var1[0]);
                    RefriM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void mostrarTel()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaTel(cifnumero);
            string valor;
            string valor1, valor2;
            valor = Convert.ToString(var1[1]);
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    TMC.Value = Convert.ToString(var1[0]);
                    TMM.Value = Convert.ToString(var1[1]);
                }
            }
        }

        public void mostrarTel1()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaFena(cifnumero);
            string valor;
            string valor1, valor2;
            valor = Convert.ToString(var1[1]);
            if ((valor != "") && (valor != null))
            {
                for (int i = 0; i < var1.Length; i++)
                {
                    //Fena1.Value = Convert.ToString(var1[0]);
                    Fena2.Value = Convert.ToString(var1[1]);
                }
            }
        }

        //public void mostrarOtros()
        //{
        //    sesion = Session["sesion_usuario"].ToString();
        //    string[] var10 = sn.consultarcif(sesion);
        //    string cifnumero = var10[0];
        //    string[] var1 = sn.consultarconcampomenaOtros(cifnumero);
        //    string valor;
        //    valor = Convert.ToString(var1[1]);
        //    string valor1, valor2;
        //    if ((valor != "") && (valor != null))
        //    {
        //        for (int i = 0; i < var1.Length; i++)
        //        {
        //            valor1 = Convert.ToString(var1[0]);
        //            valor2 = Convert.ToString(var1[0]);

        //            OC = Int32.Parse(valor1);
        //            OM = Int32.Parse(valor2);

        //            OT = OC * OM;
        //            OtrosC.Value = OC.ToString();
        //            OtrosM.Value = OM.ToString();
        //            OtrosT.Value = OT.ToString();
        //        }
        //    }
        //}

        public void mostrarOtrasDeudas()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaOD(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                EspD.Value = Convert.ToString(var1[0]);
                EspM.Value = Convert.ToString(var1[1]);
            }
        }

        public void mostrarPasivoC()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaPC(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                NombreEN.Value = Convert.ToString(var1[0]);
                NombreD.Value = Convert.ToString(var1[1]);
                RelacionD.Value = Convert.ToString(var1[2]);
                SaldoD.Value = Convert.ToString(var1[3]);
                FechaDD.Value = Convert.ToString(var1[4]);
                FechaFina.Value = Convert.ToString(var1[5]);
            }
        }

        public void mostrarOtros()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaje11(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                OtrosC.Value = Convert.ToString(var1[0]);
                OtrosM.Value = Convert.ToString(var1[1]);
            }
        }

        public void mostrarIngresos()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaIng(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                SuelB.Value = Convert.ToString(var1[0]);
                SBoni.Value = Convert.ToString(var1[1]);
                CMensua.Value = Convert.ToString(var1[2]);
            }
        }

        public void mostrarNegocio()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaNeg(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                //TipoNeg.Value = Convert.ToString(var1[0]);
                NombreNeg.Value = Convert.ToString(var1[1]);
                NoNeg.Value = Convert.ToString(var1[2]);
                EmpleNeg.Value = Convert.ToString(var1[3]);
                ObjNeg.Value = Convert.ToString(var1[4]);
                IngeNeg.Value = Convert.ToString(var1[5]);
                EgrNeg.Value = Convert.ToString(var1[6]);
                DireNeg.Value = Convert.ToString(var1[7]);
            }
        }

        public void mostrarRemesas()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaRem(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                NomRem.Value = Convert.ToString(var1[0]);
                RelaRem.Value = Convert.ToString(var1[1]);
                MontoRem.Value = Convert.ToString(var1[2]);
                //PeriRem.Value = Convert.ToString(var1[3]);
            }
        }

        public void mostrarEgresos()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];
            string[] var1 = sn.consultarconcampomenaEgres(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Alimen.Value = Convert.ToString(var1[2]);
                Gas.Value = Convert.ToString(var1[3]);
                PagoEstud.Value = Convert.ToString(var1[4]);
                Presta.Value = Convert.ToString(var1[5]);
                TarCre.Value = Convert.ToString(var1[6]);
                Vestuar.Value = Convert.ToString(var1[7]);
                Recrea.Value = Convert.ToString(var1[8]);
                Otros.Value = Convert.ToString(var1[9]);
            }
        }

    }
}