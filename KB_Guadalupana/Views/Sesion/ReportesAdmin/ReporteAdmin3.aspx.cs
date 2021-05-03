using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.ReportesAdmin
{
    public partial class ReporteAdmin3 : System.Web.UI.Page
    {

        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string sesion;

        double caja1, cuentasQ1, CooperativasQ1, CP1, IN1, Inmuebles1, vehiculo1, maquinaria1, computo1, TotalQ1, salas1, comedor1, tele, Es1, L1, S1, Est1, Ref1, Mov1, otr1;
        double cuentasD1, CooperativasD1, TotalD1;
        double pp1, TotalQ2, patrimonio1, pres1, tc1, OD1, pas1, pass2, pass3;
        string completo, nombre1, nombre2, apellido1, apellido2;


        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarCaja();
            mostrarCuentasQ();
            mostrarCuentasD();
            mostrarCooperativasD();
            mostrarCooperativasQ();
            mostrarCP();
            mostrarIN();
            mostrarInmueble();
            mostrarVehiculo();
            mostrarMaquinaria();
            mostrarSala();
            mostrarComedor();
            mostrarComputo();
            mostrarTV();
            mostrarES();
            mostrarL();
            mostrarSec();
            mostrarEst();
            mostrarRefri();
            mostrarTel();
            mostrarOtros();
            mostrarPP();
            mostrarPrestamos();
            mostrarpasivfenainver();
            mostrarTarjeta();
            mostrarOD();
            mostrarpasivfena();
            mostrarpasivcon();
            dolaresa();
            quetzalessa();
            quetzalessp();
            patrimonio();
            mostrarUser();
            mostrarIG();

        }

        public void mostrarUser()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampoUser(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Text2.Value = Convert.ToString(var1[0]);
            }
        }

        public void mostrarIG()
        {
            sesion = Session["IDReporte1"].ToString();

            //Response.Write(cifnumero);

            string[] valores1 = new string[35];
            string[] var3 = sn.consultarinformaciong(sesion);

            for (int i = 0; i < var3.Length; i++)
            {

                nombre1 = Convert.ToString(var3[8]);
                apellido1 = Convert.ToString(var3[9]);
                apellido2 = Convert.ToString(var3[10]);
                nombre2 = Convert.ToString(var3[23]);
                completo = nombre1 + " " + nombre2 + " " + apellido1 + " " + apellido2;
                Text3.Value = completo;
            }
        }

        public void dolaresa()
        {
            TotalD1 = cuentasD1 + CooperativasD1;
            Text23.Value = TotalD1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void quetzalessa()
        {
            TotalQ1 = caja1 + cuentasQ1 + CooperativasQ1 + CP1 + IN1 + Inmuebles1 + vehiculo1 + maquinaria1 + computo1 + salas1 + comedor1 + tele + Es1 + L1 + S1 + Est1 + Ref1 + Mov1 + otr1 + pass2 + pass3;
            Text14.Value = TotalQ1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void mostrarCaja()
        {
            sesion = Session["IDReporte1"].ToString();

            //FRmE1.Value = Session["sesion_usuario"].ToString();

            string[] var1 = sn.consultarconcampoCajas(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                caja1 = Convert.ToDouble(var1[0]);
                EfectivoCaja.Value = caja1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void patrimonio()
        {
            patrimonio1 = TotalQ1 - TotalQ2;
            pat.Value = patrimonio1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void mostrarCuentasQ()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoQ(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                cuentasQ1 = Convert.ToDouble(var1[0]);
                CuentasBancos.Value = cuentasQ1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCuentasD()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoD(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                cuentasD1 = Convert.ToDouble(var1[0]);
                CuentasBancos1.Value = cuentasD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCooperativasD()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCD(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                CooperativasD1 = Convert.ToDouble(var1[0]);
                CuentasCope1.Value = CooperativasD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCooperativasQ()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCQ(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                CooperativasQ1 = Convert.ToDouble(var1[0]);
                CuentasCope.Value = CooperativasQ1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCP()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCP(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                CP1 = Convert.ToDouble(var1[0]);
                CuentasPC.Value = CP1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarIN()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoIN(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                IN1 = Convert.ToDouble(var1[0]);
                Inventario.Value = IN1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarInmueble()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoInmueble(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Inmuebles1 = Convert.ToDouble(var1[0]);
                Inmueble.Value = Inmuebles1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarVehiculo()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoVehiculo(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                vehiculo1 = Convert.ToDouble(var1[0]);
                Vehiculo.Value = vehiculo1.ToString("N1", CultureInfo.CurrentCulture); ;
            }
        }

        public void mostrarMaquinaria()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoMaquinaria(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                maquinaria1 = Convert.ToDouble(var1[0]);
                Maquinaria.Value = maquinaria1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarComputo()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoComputo(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                computo1 = Convert.ToDouble(var1[0]);
                Computo.Value = computo1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarSala()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoSala(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                salas1 = Convert.ToDouble(var1[0]);
                sala.Value = salas1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarComedor()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoComedor(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                comedor1 = Convert.ToDouble(var1[0]);
                comedor.Value = comedor1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarTV()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoTV(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                tele = Convert.ToDouble(var1[0]);
                TV.Value = tele.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarES()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoES(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Es1 = Convert.ToDouble(var1[0]);
                EquipoS.Value = Es1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarL()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoL(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                L1 = Convert.ToDouble(var1[0]);
                lava.Value = L1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarSec()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoSec(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                S1 = Convert.ToDouble(var1[0]);
                SECA.Value = S1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarEst()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoEst(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Est1 = Convert.ToDouble(var1[0]);
                Estufa.Value = Est1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarRefri()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoRefri(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Ref1 = Convert.ToDouble(var1[0]);
                Refri.Value = Ref1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarTel()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoTel(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Mov1 = Convert.ToDouble(var1[0]);
                Movil.Value = Mov1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarOtros()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoOtros(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                otr1 = Convert.ToDouble(var1[0]);
                otross.Value = otr1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        //Pasivos
        public void quetzalessp()
        {
            TotalQ2 = pp1 + pres1 + tc1 + OD1 + pas1;
            TotalPasivo.Value = TotalQ2.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void mostrarPP()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCP1(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                pp1 = Convert.ToDouble(var1[0]);
                CuentaPP.Value = pp1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarPrestamos()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentaspp(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                pres1 = Convert.ToDouble(var1[0]);
                Pres.Value = pres1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarTarjeta()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentaTarjeta(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                tc1 = Convert.ToDouble(var1[0]);
                TC.Value = tc1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarOD()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentaOD(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                OD1 = Convert.ToDouble(var1[0]);
                ode.Value = OD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarpasivcon()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentapasc(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                pas1 = Convert.ToDouble(var1[0]);
                pasc.Value = pas1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarpasivfena()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentaFena(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                pass2 = Convert.ToDouble(var1[0]);
                Text4.Value = pass2.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarpasivfenainver()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoCuentaFenaINver(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                pass3 = Convert.ToDouble(var1[0]);
                Text1.Value = pass3.ToString("N1", CultureInfo.CurrentCulture);
            }
        }
    }
}