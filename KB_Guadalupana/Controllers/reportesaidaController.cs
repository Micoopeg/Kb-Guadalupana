using ClosedXML.Excel;
using KB_Guadalupana.funcionalidad;
using KB_Guadalupana.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KB_Guadalupana.Controllers
{
    public class reportesaidaController : Controller
    {
        // GET: reportesaida
        
        ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
        Sentencia_juridico sn = new Sentencia_juridico();
        
        [HttpPost]
        public ActionResult reportegeneral(List<modelogeneral.modelox> items)
        {

            string[,] nueva = null;
            inyeccion operacion = new inyeccion();
            //nueva = operacion.vistageneral(" tik_tik_det as t1 join tik_tik_enc as t2 on t2.id_tik= t1.id_tik ", "  t1.id_tik,id_pro,id_env_uni,tik_env_col,tik_env_obs,DATE_FORMAT(tik_env_fec, '%Y/%m/%d %H:%i:%s') as tik_env_fec,id_rec_uni,id_rec_col , DATE_FORMAT(tik_rec_fec, '%Y/%m/%d %H:%i:%s') as tik_rec_fec, t1.tik_est, tik_nom ", " where t1.tik_est = '1' and id_rec_uni = '"+Session["unidad"].ToString()+"'");
            nueva = operacion.vistageneral("pj_bitacora ", "  DISTINCT(idpj_incidente), pj_numcredito, pj_nombre, pj_fechacreacion, DATEDIFF(now(), pj_fechacreacion) AS Dias ", " ");
            string arreglo = operacion.maquetado(nueva);
            return Json(arreglo, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult reporetegeneraldatatable(List<modelogeneral.modelox> items)
        {


            DataTable dt1 = new DataTable("Customers");
      
            




            int desiredSize = 0;

            while (dt1.Columns.Count > desiredSize)
            {
                dt1.Columns.RemoveAt(desiredSize);
            }

            dt1.Columns.Add("t1");
            dt1.Columns.Add("t2");
            dt1.Columns.Add("t3");
            dt1.Columns.Add("t4");
            dt1.Columns.Add("t5");
            dt1.Columns.Add("t6");
            dt1.Columns.Add("t7");
            dt1.Columns.Add("t8");
            dt1.Columns.Add("t9");
            dt1.Columns.Add("t10");
            dt1.Columns.Add("t11");
            dt1.Columns.Add("t12");
            dt1.Columns.Add("t13");
            dt1.Columns.Add("t14");
            dt1.Columns.Add("t15");
            dt1.Columns.Add("t16");
            dt1.Columns.Add("t17");
            dt1.Columns.Add("t18");
            dt1.Columns.Add("t19");
            dt1.Columns.Add("t20");
            dt1.Columns.Add("t21");
            dt1.Columns.Add("t22");
            dt1.Columns.Add("t23");
            dt1.Columns.Add("t24");
            dt1.Columns.Add("t25");
            dt1.Columns.Add("t26");
            dt1.Columns.Add("t27");
            dt1.Columns.Add("t28");
            dt1.Columns.Add("t29");
            dt1.Columns.Add("t30");
            dt1.Columns.Add("t31");
            dt1.Columns.Add("t32");
            dt1.Columns.Add("t33");
            dt1.Columns.Add("t34");
            dt1.Columns.Add("t35");
            dt1.Columns.Add("t36");
            dt1.Columns.Add("t37");
            dt1.Columns.Add("t38");
            dt1.Columns.Add("t39");
            dt1.Columns.Add("t40");
            dt1.Columns.Add("t41");
            dt1.Columns.Add("t42");
            dt1.Columns.Add("t43");
            dt1.Columns.Add("t44");
            dt1.Columns.Add("t45");
            dt1.Columns.Add("t46");
            dt1.Columns.Add("t47");
            dt1.Columns.Add("t48");
            dt1.Columns.Add("t49");
            dt1.Columns.Add("t50");
            dt1.Columns.Add("t51");
            dt1.Columns.Add("t52");
            dt1.Columns.Add("t53");
            dt1.Columns.Add("t54");
            dt1.Columns.Add("t55");
            dt1.Columns.Add("t56");
            dt1.Columns.Add("t57");
            dt1.Columns.Add("t58");
            dt1.Columns.Add("t59");
            dt1.Columns.Add("t60");
            dt1.Columns.Add("t61");
            dt1.Columns.Add("t62");
            dt1.Columns.Add("t63");
            dt1.Columns.Add("t64");
            dt1.Columns.Add("t65");
            dt1.Columns.Add("t66");
            dt1.Columns.Add("t67");
            dt1.Columns.Add("t68");
            dt1.Columns.Add("t69");

            dt1.Columns.Add("t70");
            dt1.Columns.Add("t71");
            dt1.Columns.Add("t72");
            dt1.Columns.Add("t73");
            dt1.Columns.Add("t74");
            dt1.Columns.Add("t75");
            dt1.Columns.Add("t76");
            dt1.Columns.Add("t77");
            dt1.Columns.Add("t78");
            dt1.Columns.Add("t79");

            dt1.Columns.Add("t80");
            dt1.Columns.Add("t81");
            dt1.Columns.Add("t82");
            dt1.Columns.Add("t83");
            dt1.Columns.Add("t84");
            dt1.Columns.Add("t85");
            dt1.Columns.Add("t86");
            dt1.Columns.Add("t87");
            dt1.Columns.Add("t88");
            dt1.Columns.Add("t89");


            dt1.Columns.Add("t90");
            dt1.Columns.Add("t91");
            dt1.Columns.Add("t92");
            dt1.Columns.Add("t93");
            dt1.Columns.Add("t94");
            dt1.Columns.Add("t95");
            dt1.Columns.Add("t96");
            dt1.Columns.Add("t97");
            dt1.Columns.Add("t98");
            dt1.Columns.Add("t99");


            dt1.Columns.Add("t100");
            dt1.Columns.Add("t101");
            dt1.Columns.Add("t102");
            dt1.Columns.Add("t103");
            dt1.Columns.Add("t104");
            dt1.Columns.Add("t105");
            dt1.Columns.Add("t106");
            dt1.Columns.Add("t107");
            dt1.Columns.Add("t108");
            dt1.Columns.Add("t109");


            dt1.Columns.Add("t110");
            dt1.Columns.Add("t111");
            dt1.Columns.Add("t112");
            dt1.Columns.Add("t113");
            dt1.Columns.Add("t114");
            dt1.Columns.Add("t115");
            dt1.Columns.Add("t116");
            dt1.Columns.Add("t117");
            dt1.Columns.Add("t118");
            dt1.Columns.Add("t119");


            dt1.Columns.Add("t120");
            dt1.Columns.Add("t121");
            dt1.Columns.Add("t122");
            dt1.Columns.Add("t123");
            dt1.Columns.Add("t124");
            dt1.Columns.Add("t125");
            dt1.Columns.Add("t126");
            dt1.Columns.Add("t127");
            dt1.Columns.Add("t128");
            dt1.Columns.Add("t129");

            dt1.Columns.Add("t130");
            dt1.Columns.Add("t131");
            dt1.Columns.Add("t132");
            dt1.Columns.Add("t133");
            dt1.Columns.Add("t134");
            dt1.Columns.Add("t135");
            dt1.Columns.Add("t136");
            dt1.Columns.Add("t137");
            dt1.Columns.Add("t138");
            dt1.Columns.Add("t139");

            dt1.Columns.Add("t140");
            dt1.Columns.Add("t141");
            dt1.Columns.Add("t142");
            dt1.Columns.Add("t143");
            dt1.Columns.Add("t144");
            dt1.Columns.Add("t145");
            dt1.Columns.Add("t146");
            dt1.Columns.Add("t147");
            dt1.Columns.Add("t148");
            dt1.Columns.Add("t149");

            dt1.Columns.Add("t150");
            dt1.Columns.Add("t151");
            dt1.Columns.Add("t152");
            dt1.Columns.Add("t153");
            dt1.Columns.Add("t154");
            dt1.Columns.Add("t155");
            dt1.Columns.Add("t156");
            dt1.Columns.Add("t157");
            dt1.Columns.Add("t158");
            dt1.Columns.Add("t159");


            dt1.Columns.Add("t160");
            dt1.Columns.Add("t161");
            dt1.Columns.Add("t162");
            dt1.Columns.Add("t163");
            dt1.Columns.Add("t164");
            dt1.Columns.Add("t165");
            dt1.Columns.Add("t166");
            dt1.Columns.Add("t167");
            dt1.Columns.Add("t168");
            dt1.Columns.Add("t169");
            dt1.Columns.Add("t170");




            string Agencia ="";
            string Instrumento = "";
            string LineaCredito = "";
            string destino =  "";
            string Garantia =  "";
            string Plazomeses = "";
            string Estado = "";
            string Tasa = "";
            string[] fecha = null ;
            string FechaSolicitud = "";
            string[] fecha2 = null;
            string FechaDesembolso1 = "";
            string[] fecha3 = null;
            string FechaUltimoDes = "";
            string[] fecha4 = null;
            string FechaVencimiento = "";
            string[] fecha5 = null;
            string FechaUltimaCuota = "";
            string[] fecha6 = null;
            string FechaActa = "";
            string NumActa = "";
            string NumPrestamo = "";
            string CreditoNumero = "";
            string DPI = "";
            string CodigoCliente = "";
            string NumCif = "";
            string NombreCliente = "";
            string ClienteNombre = "";
            string MontoOriginal = "";
            string CapitalDesem = "";
            string DescripcionDoc = "";
            string NombreOficial = "";
            string NombreOficial2 = "";
            string NombreOficial3 = "";
            string SaldoActual = "";
            string Saldo1 = "";



            string[,] nueva = null;
            string[,] nuevas = null;
            inyeccion operacion = new inyeccion();
            //nueva = operacion.vistageneral(" tik_tik_det as t1 join tik_tik_enc as t2 on t2.id_tik= t1.id_tik ", "  t1.id_tik,id_pro,id_env_uni,tik_env_col,tik_env_obs,DATE_FORMAT(tik_env_fec, '%Y/%m/%d %H:%i:%s') as tik_env_fec,id_rec_uni,id_rec_col , DATE_FORMAT(tik_rec_fec, '%Y/%m/%d %H:%i:%s') as tik_rec_fec, t1.tik_est, tik_nom ", " where t1.tik_est = '1' and id_rec_uni = '"+Session["unidad"].ToString()+"'");
            // tercera etapa vacio
            nuevas = operacion.vistageneral("pj_creditosgeneral", "pj_numcredito", " ");

            for (int ra = 0; ra < nuevas.GetLength(0); ra++)
            {

                string s1 = "", s2 = "", s3 = "", s4 = "", s5 = "", s6 = "", s7 = "", s8 = "", s9 = "", s10 = "", s11 = "", s12 = "", s13 = "", s14 = "", s15 = "", s16 = "", s17 = "", s18 = "", s19 = "", s20 = "", s21 = "", s22 = "", s23 = "";
                string s24 = "", s25 = "", s26 = "", s27 = "", s28 = "", s29 = "", s30 = "", s31 = "", s32 = "", s33 = "", s34 = "", s35 = "", s36 = "", s37 = "", s38 = "", s39 = "", s40 = "", s41 = "", s42 = "", s43 = "", s44 = "", s45 = "", s46 = "";
                string s47 = "", s48 = "", s49 = "", s50 = "", s51 = "", s52 = "", s53 = "", s54 = "", s55 = "", s56 = "", s57 = "", s58 = "", s59 = "", s60 = "", s61 = "", s62 = "", s63 = "", s64 = "", s65 = "", s66 = "", s67 = "", s68 = "", s69 = "";

                string s70 = "", s71 = "", s72 = "", s73 = "", s74 = "", s75 = "", s76 = "", s77 = "", s78 = "", s79 = "", s80 = "", s81 = "", s82 = "", s83 = "", s84 = "", s85 = "", s86 = "", s87 = "", s88 = "", s89 = "", s90 = "", s91 = "", s92 = "";
                string s93 = "", s94 = "", s95 = "", s96 = "", s97 = "", s98 = "", s99 = "", s100 = "";

                string s101 = "", s102 = "", s103 = "", s104 = "", s105 = "", s106 = "", s107 = "", s108 = "";
                string s109 = "", s110 = "", s111 = "", s112 = "", s113 = "", s114 = "", s115 = "", s116 = "";

                string s117 = "", s118 = "", s119 = "", s120 = "", s121 = "", s122 = "", s123 = "", s124 = "";
                string s125 = "", s126 = "", s127 = "", s128 = "", s129 = "", s130 = "", s131 = "", s132 = "";

                string s133 = "", s134 = "", s135 = "", s136 = "", s137 = "", s138 = "", s139 = "", s140 = "";
                string s141 = "", s142 = "", s143 = "", s144 = "", s145 = "", s146 = "", s147 = "", s148 = "";

                string s149 = "", s150 = "", s151 = "", s152 = "", s153 = "", s154 = "", s155 = "", s156 = "";

                string s157 = "", s158 = "", s159 = "", s160 = "", s161 = "", s162 = "", s163 = "", s164 = "";

                string s165 = "", s166 = "", s167 = "", s168 = "", s169 = "", s170 = "", s171 = "", s172 = "";




                string nnumero = "";
                nnumero = nuevas[ra, 0].ToString(); 

                nueva = operacion.vistageneral("pj_tipocredito ", "*", " ");

                DataRow row1 = dt1.NewRow();
                string numcredito = nnumero;
                string var1 = ws.buscarcredito(numcredito);
                char delimitador = '|';
                string[] campos = var1.Split(delimitador);

                if (var1.Length == 4)
                {
                    Response.Write("NO HAY DATOS QUE MOSTRARA");
                }
                else
                {


                    for (int i = 0; i < campos.Length; i++)
                    {
                        Agencia = campos[29];
                        Instrumento = campos[17];
                        LineaCredito = campos[18];
                        destino = campos[28];
                        Garantia = campos[22];
                        Plazomeses = campos[2];

                        Estado = campos[23];

                        Tasa = campos[13];
                        fecha = campos[3].Split(' ');
                        FechaSolicitud = fecha[0];
                        fecha2 = campos[4].Split(' ');
                        FechaDesembolso1 = fecha2[0];
                        fecha3 = campos[10].Split(' ');
                        FechaUltimoDes = fecha3[0];
                        fecha4 = campos[5].Split(' ');
                        FechaVencimiento = fecha4[0];
                        fecha5 = campos[7].Split(' ');
                        FechaUltimaCuota = fecha5[0];
                        fecha6 = campos[12].Split(' ');
                        FechaActa = fecha6[0];
                        NumActa = campos[11];
                        NumPrestamo = campos[1];
                        CreditoNumero = campos[1];
                        DPI = campos[21];
                        CodigoCliente = campos[19];
                        NumCif = campos[19];
                        NombreCliente = campos[20];
                        ClienteNombre = campos[20];
                        MontoOriginal = "Q " + campos[9];
                        CapitalDesem = "Q " + campos[9];

                        DescripcionDoc = campos[24];




                        NombreOficial = campos[25];
                        NombreOficial2 = campos[26];
                        NombreOficial3 = campos[27];

                        if (campos[8] == "            .00")
                        {
                            SaldoActual = "Q 0.00";
                            Saldo1 = "0.00";
                        }
                        else
                        {
                            SaldoActual = "Q " + campos[8];
                            Saldo1 = campos[8];
                        }
                    }

                }


                s1 = Agencia;
                s2 = Instrumento;
                s3 = LineaCredito;
                s4 = destino;
                s5 = Garantia;
                s6 = Plazomeses;
                s7 = Estado;
                s8 = Tasa;
                s9 = fecha[0].ToString();
                s10 = FechaSolicitud;
                s11 = FechaDesembolso1;
                s12 = FechaUltimoDes;
                s13 = FechaVencimiento;
                s14 = FechaUltimaCuota;
                s15 = FechaActa;
                s16 = NumActa;
                s17 = NumPrestamo;
                s18 = "";
                s19 = DPI;
                s20 = CodigoCliente;
                s21 = "";
                s22 = NombreCliente;
                s23 = "";
                s24 = MontoOriginal;
                s25 = CapitalDesem;
                s26 = DescripcionDoc;
                s27 = NombreOficial;
                s28 = NombreOficial2;
                s29 = NombreOficial3;
                s30 = SaldoActual;
                s31 = Saldo1;


                string NumIncidente = "";
                string NumeroIncidente = "";
                string NumTarjeta = "";
                string NumCuenta = "";
                string CIF = "";
                string PrimerNombre = "";
                string SegundoNombre = "";
                string OtroNombre = "";
                string ApellidoCasada = "";
                string PrimerApellido = "";
                string SegundoApellido = "";
                string Limite = "";
                string Saldo = "";
                string Gastos1 = "";
                string GastosJudiciales = "";
                string OtrosGastos = "";
                string Comentario = "";
                string Total1 = "";
                string fechaestado = "";
                string[] separarfechahora = null;
                string[] fechaestado2 = null;
                string Incendio = "";
                string Interes1 = "";
                string Mora = "";
                string FechaEstadoCuenta = "";


                string[] campos2 = sn.obtenertipocredito(numcredito);
                string idcredito = campos2[0];
                if (idcredito == null)
                {


                    string[] campos3 = sn.obtenertipotarjeta(numcredito);
                    for (int i = 0; i < campos3.Length; i++)
                    {
                        NumIncidente = campos3[0];
                        NumeroIncidente = campos3[0];
                        NumTarjeta = campos3[1];
                        NumCuenta = campos3[2];
                        CIF = campos3[3];
                        PrimerNombre = campos3[4];
                        SegundoNombre = campos3[5];
                        OtroNombre = campos3[6];
                        ApellidoCasada = campos3[7];
                        PrimerApellido = campos3[8];
                        SegundoApellido = campos3[9];
                        Limite = "Q " + campos3[10];
                        Saldo = "Q " + campos3[11];
                        Gastos1 = campos3[13];
                        GastosJudiciales = campos3[14];
                        OtrosGastos = campos3[15];
                        Comentario = campos3[16];
                        Total1 = "Q " + campos3[17];
                        fechaestado = campos3[19];
                        separarfechahora = fechaestado.Split(' ');
                        fechaestado2 = separarfechahora[0].Split('/');
                        Incendio = "pendiente";
                        Interes1 = "pendiente";
                        Mora = "pendiente";

                        if (fechaestado2[0].Length == 1)
                        {
                            FechaEstadoCuenta = fechaestado2[2] + '-' + fechaestado2[1] + '-' + "0" + fechaestado2[0];
                        }
                        else
                        {
                            FechaEstadoCuenta = fechaestado2[2] + '-' + fechaestado2[1] + '-' + fechaestado2[0];
                        }
                    }

                }
                else
                {

                    for (int i = 0; i < campos2.Length; i++)
                    {
                        NumIncidente = campos2[0];
                        NumeroIncidente = campos2[0];
                        Gastos1 = campos2[1];
                        GastosJudiciales = campos2[2];
                        OtrosGastos = campos2[3];
                        Total1 = "Q " + campos2[4];
                        Comentario = campos2[5];
                        fechaestado = campos2[8];
                        separarfechahora = fechaestado.Split(' ');
                        fechaestado2 = separarfechahora[0].Split('/');
                        Incendio = campos2[9];
                        Interes1 = campos2[10];
                        Mora = campos2[11];

                        if (fechaestado2[0].Length == 1)
                        {
                            FechaEstadoCuenta = fechaestado2[2] + '-' + fechaestado2[1] + '-' + "0" + fechaestado2[0];
                        }
                        else
                        {
                            FechaEstadoCuenta = fechaestado2[2] + '-' + fechaestado2[1] + '-' + fechaestado2[0];
                        }

                    }

                }

                s32 = NumIncidente;
                s33 = "";
                s34 = NumTarjeta;
                s35 = NumCuenta;
                s36 = CIF;
                s37 = PrimerNombre;
                s38 = SegundoNombre;
                s39 = OtroNombre;
                s40 = ApellidoCasada;
                s41 = PrimerApellido;
                s42 = SegundoApellido;
                s43 = Limite;
                s44 = Saldo;
                s45 = Gastos1;
                s46 = GastosJudiciales;
                s47 = OtrosGastos;
                s48 = Comentario;
                s49 = Total1;
                s50 = "";
                s51 = "";
                s52 = "";
                s53 = Incendio;
                s54 = Interes1;
                s55 = Mora;
                s56 = FechaEstadoCuenta;

                // segunda etapa 
                nueva = operacion.vistageneral("pj_certificacioncontable ", "  *", " where pj_numcredito = '"+ numcredito + "'");
                row1 = dt1.NewRow();
                // contador
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    s57 = "";
                    s58 = nueva[f, 1].ToString();
                    s59 = nueva[f, 2].ToString();
                    s60 = "";
                    //se corre 1
                    s61 = nueva[f, 5].ToString();
                    



                }

                // tercera etapa vacio
                nueva = operacion.vistageneral("pj_certificacionjuidico as t1 join pj_asignacionmedidas as t2 on t1.pj_numcredito = t2.pj_numcredito ", " *", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    
                    s62 = nueva[f, 1].ToString();
                    s63 = nueva[f, 3].ToString();
                    s64 = nueva[f, 6].ToString();
                    s65 = nueva[f, 7].ToString();
                    s66 = nueva[f, 9].ToString();
                    

                    switch(nueva[f, 14].ToString())
                    {
                        case "1":
                            s67 = s67+ "/" + nueva[f, 12].ToString();
                            break;
                        case "2":
                            s68 = s68+ "/" + nueva[f, 12].ToString();
                            break;

                        case "3":
                            s69 = s69 + "/" + nueva[f, 12].ToString();
                            break;
                        case "4":
                            s70 = s70 + "/" + nueva[f, 12].ToString();
                            break;

                    }

                    //////agregue 3 campos mas 

                }

                // cuarta etapa 


                nueva = operacion.vistageneral("pj_resoluciontramite as t1 join pj_facturacionabogado as t2 on t1.pj_numcredito = t2.pj_numcredito ", "*", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    //idpj_resuluciontramite  admitida
                    s71 = "";
                    s72 = nueva[f, 4].ToString();
                    s73 = nueva[f, 5].ToString();
                    s74 = "";
                    s75 = "";
                    if(s71 =="")
                    {
                        s71 = "Admitida";
                    }
                    else
                    {
                        s71 = "Rechazada";
                    }
                }






                // septima fase 
                //nueva = operacion.vistageneral("pj_solicitudcheque as t1 join pj_bancoemisor as t2 on t1.idpj_banco = t2.idpj_bancoemisor ", "  *", " where t1.pj_numcredito = '" + numcredito + "' and pj_etapa = '10'");
                nueva = operacion.vistageneral("pj_solicitudcheque as t1 join pj_bancoemisor as t2 on t1.idpj_banco = t2.idpj_bancoemisor ", "  *", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {
                    s76 = nueva[f, 3].ToString();
                    s77 = nueva[f, 4].ToString();
                    s78 = nueva[f, 6].ToString();
                    s79 = nueva[f, 7].ToString();
                    s80 = nueva[f, 10].ToString();



                }





                // novena fase 
                nueva = operacion.vistageneral("pj_sonefectivas as t1 join pj_voluntaria as t2 on t1.pj_numcredito = t2.pj_numcredito join pj_asignacionmedidas as t3 on t2.pj_numcredito = t3.pj_numcredito", "*", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {
                    //4
                    //0 5 6  9 11  12 13 15 16 17 20  21 22 23
                    s82 = "";
                    s83 = nueva[f, 6].ToString();
                    s84 = nueva[f, 9].ToString();
                    s85 ="";
                    s86 = nueva[f, 12].ToString();
                    s87 = nueva[f, 13].ToString();
                    s88 = nueva[f, 15].ToString();
                    s89 = nueva[f, 16].ToString();
                    s90 = nueva[f, 17].ToString();
                    s91 = nueva[f, 20].ToString();
                    s92 = "";
                    s93 = "";
                    s94 ="";

                }



                // novena fase ////////////////PENDIENTE

                nueva = operacion.vistageneral("pj_voluntaria as t1 join pj_hayresultados as t2 on t1.pj_numcredito = t2.pj_numcredito join pj_gestionmedida as t3 on t2.pj_numcredito  = t3.pj_credito ", "  *", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    //fecha presentacion
                    s95 = nueva[f, 2].ToString();
                    // fecha resolucion
                    s96 = nueva[f, 4].ToString();
                    // fecha notificacion
                    s97 = nueva[f, 5].ToString();
                    // observaciobes
                    s98 = nueva[f, 6].ToString();
                    // fecha
                    s99 = nueva[f, 9].ToString();
                    // hay resultado
                    s100 = nueva[f, 10].ToString();
                    // empresatrabajo
                    s101 = nueva[f, 11].ToString();
                    // fecha presentacio
                    s102 = nueva[f, 12].ToString();
                    // fecha sentencia 
                    s103 = nueva[f, 13].ToString();

                    // fecha apremio
                    s104 = nueva[f, 14].ToString();
                    // fecha 
                    s105 = nueva[f, 17].ToString();





                }


                // novena fase 
                nueva = operacion.vistageneral("pj_solicitudfacturacion as t1 join pj_aplicacionpago as t2 on t1.pj_numcredito = t2.pj_numcredito", "idpj_solicitudfacturacion, pj_honorarios, t1.pj_fecha,idpj_aplicacionpago, pj_numcheque, pj_fechaemision, pj_numrecibo, pj_monto, pj_banco, t1.pj_fecha ", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {


                    //pendiente

                    s106 = "";
                    s107 = nueva[f, 1].ToString();
                    s108 = nueva[f, 2].ToString();
                    s109 = nueva[f, 3].ToString();
                    s110 = nueva[f, 4].ToString();
                    s111 = nueva[f, 5].ToString();
                    s112 = nueva[f, 6].ToString();
                    s113 = nueva[f, 7].ToString();
                    //agregue nuevo 
                    s114 = nueva[f, 6].ToString();
                    s115 = nueva[f, 7].ToString();



                }


                // novena fase 
                nueva = operacion.vistageneral("pj_facturacionabogado", "  *", " where pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {
                    //19
                    s116 = "";
                    s117 = nueva[f, 3].ToString();
                    s118 = nueva[f, 4].ToString();
                    s119 = nueva[f, 5].ToString();
                    s120 = nueva[f, 6].ToString();
                    s121 = nueva[f, 7].ToString();
                    s122 = nueva[f, 8].ToString();
                    s123 = "";
                    s124 = nueva[f, 10].ToString();
                    s125 = nueva[f, 11].ToString();
                    s126 = nueva[f, 12].ToString();
                    s127 = nueva[f, 13].ToString();
                    s128 = nueva[f, 14].ToString();
                    s129 = "";



                }




                // novena respuesta positiva 
                nueva = operacion.vistageneral("pj_sinotificacion as t1  join pj_actitudpositiva as t2 on t1.pj_numcredito = t2.pj_numcredito", " idpj_sinotificacion, pj_fechanotificacion, pj_actituddemandado, t1.pj_fecha, idpj_actitudpositiva, pj_fechasentencia, pj_notificacionsentencia, pj_lugar, pj_observaciones ", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    s130 = "";
                    s131 = nueva[f, 1].ToString();
                    s132 = nueva[f, 2].ToString();
                    s133 = nueva[f, 3].ToString();
                    s134 = nueva[f, 4].ToString();
                    s135 = nueva[f, 5].ToString();
                    s136 = nueva[f, 6].ToString();
                    s137 = nueva[f, 7].ToString();
                    s138 = nueva[f, 8].ToString();
                    s139 = "";
                    s140 = "";


                }

                // novena respuesta negativa
                nueva = operacion.vistageneral("pj_sinotificacion as t1  join pj_actitudnegativa as t2 on t1.pj_numcredito = t2.pj_numcredito", "  idpj_sinotificacion, t1.pj_fechanotificacion, pj_actituddemandado, t1.pj_fecha, idpj_actitudnegativa, pj_fechasentencia, pj_lugar, pj_observaciones", " where t1.pj_numcredito = '" + numcredito + "'");
                row1 = dt1.NewRow();
                for (int f = 0; f < nueva.GetLength(0); f++)
                {

                    s141 = nueva[f, 0].ToString();
                    s142 = nueva[f, 1].ToString();
                    s143 = nueva[f, 2].ToString();
                    s144 = nueva[f, 3].ToString();
                    s145 = nueva[f, 4].ToString();
                    s146 = nueva[f, 5].ToString();
                    s147 = nueva[f, 6].ToString();
                    s148 = nueva[f, 7].ToString();
                    s149 = "";
                    s150 = "";


                }




                row1["t1"] = s1;
                row1["t2"] = s2;
                row1["t3"] = s3;
                row1["t4"] = s4;
                row1["t5"] = s5;
                row1["t6"] = s6;
                row1["t7"] = s7;
                row1["t8"] = s8;
                row1["t9"] = s9;
                row1["t10"] = s10;
                row1["t11"] = s11;
                row1["t12"] = s12;
                row1["t13"] = s13;
                row1["t14"] = s14;
                row1["t15"] = s15;
                row1["t16"] = s16;
                row1["t17"] = s17;
                row1["t18"] = s18;
                row1["t19"] = s19;
                row1["t20"] = s20;
                row1["t21"] = s21;
                row1["t22"] = s22;
                row1["t23"] = s23;
                row1["t24"] = s24;
                row1["t25"] = s25;
                row1["t26"] = s26;
                row1["t27"] = s27;
                row1["t28"] = s28;
                row1["t29"] = s29;
                row1["t30"] = s30;
                row1["t31"] = s31;
                row1["t32"] = s32;
                row1["t33"] = s33;
                row1["t34"] = s34;
                row1["t35"] = s35;
                row1["t36"] = s36;
                row1["t37"] = s37;
                row1["t38"] = s38;
                row1["t39"] = s39;
                row1["t40"] = s40;
                row1["t41"] = s41;
                row1["t42"] = s42;
                row1["t43"] = s43;
                row1["t44"] = s44;
                row1["t45"] = s45;
                row1["t46"] = s46;
                row1["t47"] = s47;
                row1["t48"] = s48;
                row1["t49"] = s49;
                row1["t50"] = s50;
                row1["t51"] = s51;
                row1["t52"] = s52;
                row1["t53"] = s53;
                row1["t54"] = s54;
                row1["t55"] = s55;
                row1["t56"] = s56;
                row1["t57"] = s57;
                row1["t58"] = s58;
                row1["t59"] = s59;
                row1["t60"] = s60;
                row1["t61"] = s61;
                row1["t62"] = s62;
                row1["t63"] = s63;
                row1["t64"] = s64;
                row1["t65"] = s65;
                row1["t66"] = s66;
                row1["t67"] = s67;
                row1["t68"] = s68;
                row1["t69"] = s69;

                row1["t70"] = s70;
                row1["t71"] = s71;
                row1["t72"] = s72;
                row1["t73"] = s73;
                row1["t74"] = s74;
                row1["t75"] = s75;
                row1["t76"] = s76;
                row1["t77"] = s77;
                row1["t78"] = s78;
                row1["t79"] = s79;

                row1["t80"] = s80;
                row1["t81"] = s81;
                row1["t82"] = s82;
                row1["t83"] = s83;
                row1["t84"] = s84;
                row1["t85"] = s85;
                row1["t86"] = s86;
                row1["t87"] = s87;
                row1["t88"] = s88;
                row1["t89"] = s89;


                row1["t90"] = s90;
                row1["t91"] = s91;
                row1["t92"] = s92;
                row1["t93"] = s93;
                row1["t94"] = s94;
                row1["t95"] = s95;
                row1["t96"] = s96;
                row1["t97"] = s97;
                row1["t98"] = s98;
                row1["t99"] = s99;


                row1["t100"] = s100;
                row1["t101"] = s101;
                row1["t102"] = s102;
                row1["t103"] = s103;
                row1["t104"] = s104;
                row1["t105"] = s105;
                row1["t106"] = s106;
                row1["t107"] = s107;
                row1["t108"] = s108;
                row1["t109"] = s109;


                row1["t110"] = s110;
                row1["t111"] = s111;
                row1["t112"] = s112;
                row1["t113"] = s113;
                row1["t114"] = s114;
                row1["t115"] = s115;
                row1["t116"] = s116;
                row1["t117"] = s117;
                row1["t118"] = s118;
                row1["t119"] = s119;

                row1["t120"] = s120;
                row1["t121"] = s121;
                row1["t122"] = s122;
                row1["t123"] = s123;
                row1["t124"] = s124;
                row1["t125"] = s125;
                row1["t126"] = s126;
                row1["t127"] = s127;
                row1["t128"] = s128;
                row1["t129"] = s129;

                row1["t130"] = s130;
                row1["t131"] = s131;
                row1["t132"] = s132;
                row1["t133"] = s133;
                row1["t134"] = s134;
                row1["t135"] = s135;
                row1["t136"] = s136;
                row1["t137"] = s137;
                row1["t138"] = s138;
                row1["t139"] = s139;

                row1["t140"] = s140;
                row1["t141"] = s141;
                row1["t142"] = s142;
                row1["t143"] = s143;
                row1["t144"] = s144;
                row1["t145"] = s145;
                row1["t146"] = s146;
                row1["t147"] = s147;
                row1["t148"] = s148;
                row1["t149"] = s149;

                row1["t150"] = s150;
                row1["t151"] = s151;




                dt1.Rows.Add(row1);
            }

         

            string[,] nueva2 = new string[dt1.Rows.Count,151];

            for (int ss = 0; ss<dt1.Rows.Count; ss++)

            {

                nueva2[ss, 0] = dt1.Rows[ss]["t1"].ToString();
                nueva2[ss, 1] = dt1.Rows[ss]["t2"].ToString();
                nueva2[ss, 2] = dt1.Rows[ss]["t3"].ToString();
                nueva2[ss, 3] = dt1.Rows[ss]["t4"].ToString();
                nueva2[ss, 4] = dt1.Rows[ss]["t5"].ToString();
                nueva2[ss, 5] = dt1.Rows[ss]["t6"].ToString();
                nueva2[ss, 6] = dt1.Rows[ss]["t7"].ToString();
                nueva2[ss, 7] = dt1.Rows[ss]["t8"].ToString();
                nueva2[ss, 8] = dt1.Rows[ss]["t9"].ToString();
                nueva2[ss, 9] = dt1.Rows[ss]["t10"].ToString();
                nueva2[ss, 10] = dt1.Rows[ss]["t11"].ToString();
                nueva2[ss, 11] = dt1.Rows[ss]["t12"].ToString();
                nueva2[ss, 12] = dt1.Rows[ss]["t13"].ToString();
                nueva2[ss, 13] = dt1.Rows[ss]["t14"].ToString();
                nueva2[ss, 14] = dt1.Rows[ss]["t15"].ToString();
                nueva2[ss, 15] = dt1.Rows[ss]["t16"].ToString();
                nueva2[ss, 16] = dt1.Rows[ss]["t17"].ToString();
                nueva2[ss, 17] = dt1.Rows[ss]["t18"].ToString();
                nueva2[ss, 18] = dt1.Rows[ss]["t19"].ToString();
                nueva2[ss, 19] = dt1.Rows[ss]["t20"].ToString();
                nueva2[ss, 20] = dt1.Rows[ss]["t21"].ToString();
                nueva2[ss, 21] = dt1.Rows[ss]["t22"].ToString();
                nueva2[ss, 22] = dt1.Rows[ss]["t23"].ToString();
                nueva2[ss, 23] = dt1.Rows[ss]["t24"].ToString();
                nueva2[ss, 24] = dt1.Rows[ss]["t25"].ToString();
                nueva2[ss, 25] = dt1.Rows[ss]["t26"].ToString();
                nueva2[ss, 26] = dt1.Rows[ss]["t27"].ToString();
                nueva2[ss, 27] = dt1.Rows[ss]["t28"].ToString();
                nueva2[ss, 28] = dt1.Rows[ss]["t29"].ToString();
                nueva2[ss, 29] = dt1.Rows[ss]["t30"].ToString();
                nueva2[ss, 30] = dt1.Rows[ss]["t31"].ToString();
                nueva2[ss, 31] = dt1.Rows[ss]["t32"].ToString();
                nueva2[ss, 32] = dt1.Rows[ss]["t33"].ToString();
                nueva2[ss, 33] = dt1.Rows[ss]["t34"].ToString();
                nueva2[ss, 34] = dt1.Rows[ss]["t35"].ToString();
                nueva2[ss, 35] = dt1.Rows[ss]["t36"].ToString();
                nueva2[ss, 36] = dt1.Rows[ss]["t37"].ToString();
                nueva2[ss, 37] = dt1.Rows[ss]["t38"].ToString();
                nueva2[ss, 38] = dt1.Rows[ss]["t39"].ToString();
                nueva2[ss, 39] = dt1.Rows[ss]["t40"].ToString();
                nueva2[ss, 40] = dt1.Rows[ss]["t41"].ToString();
                nueva2[ss, 41] = dt1.Rows[ss]["t42"].ToString();
                nueva2[ss, 42] = dt1.Rows[ss]["t43"].ToString();
                nueva2[ss, 43] = dt1.Rows[ss]["t44"].ToString();
                nueva2[ss, 44] = dt1.Rows[ss]["t45"].ToString();
                nueva2[ss, 45] = dt1.Rows[ss]["t46"].ToString();
                nueva2[ss, 46] = dt1.Rows[ss]["t47"].ToString();
                nueva2[ss, 47] = dt1.Rows[ss]["t48"].ToString();
                nueva2[ss, 48] = dt1.Rows[ss]["t49"].ToString();
                nueva2[ss, 49] = dt1.Rows[ss]["t50"].ToString();

                nueva2[ss, 50] = dt1.Rows[ss]["t51"].ToString();
                nueva2[ss, 51] = dt1.Rows[ss]["t52"].ToString();
                nueva2[ss, 52] = dt1.Rows[ss]["t53"].ToString();
                nueva2[ss, 53] = dt1.Rows[ss]["t54"].ToString();
                nueva2[ss, 54] = dt1.Rows[ss]["t55"].ToString();
                nueva2[ss, 55] = dt1.Rows[ss]["t56"].ToString();
                nueva2[ss, 56] = dt1.Rows[ss]["t57"].ToString();
                nueva2[ss, 57] = dt1.Rows[ss]["t58"].ToString();
                nueva2[ss, 58] = dt1.Rows[ss]["t59"].ToString();
                nueva2[ss, 59] = dt1.Rows[ss]["t60"].ToString();

                nueva2[ss, 60] = dt1.Rows[ss]["t61"].ToString();
                nueva2[ss, 61] = dt1.Rows[ss]["t62"].ToString();
                nueva2[ss, 62] = dt1.Rows[ss]["t63"].ToString();
                nueva2[ss, 63] = dt1.Rows[ss]["t64"].ToString();
                nueva2[ss, 64] = dt1.Rows[ss]["t65"].ToString();
                nueva2[ss, 65] = dt1.Rows[ss]["t66"].ToString();
                nueva2[ss, 66] = dt1.Rows[ss]["t67"].ToString();
                nueva2[ss, 67] = dt1.Rows[ss]["t68"].ToString();
                nueva2[ss, 68] = dt1.Rows[ss]["t69"].ToString();
                nueva2[ss, 69] = dt1.Rows[ss]["t70"].ToString();

                nueva2[ss, 70] = dt1.Rows[ss]["t71"].ToString();
                nueva2[ss, 71] = dt1.Rows[ss]["t72"].ToString();
                nueva2[ss, 72] = dt1.Rows[ss]["t73"].ToString();
                nueva2[ss, 73] = dt1.Rows[ss]["t74"].ToString();
                nueva2[ss, 74] = dt1.Rows[ss]["t75"].ToString();
                nueva2[ss, 75] = dt1.Rows[ss]["t76"].ToString();
                nueva2[ss, 76] = dt1.Rows[ss]["t77"].ToString();
                nueva2[ss, 77] = dt1.Rows[ss]["t78"].ToString();
                nueva2[ss, 78] = dt1.Rows[ss]["t79"].ToString();
                nueva2[ss, 79] = dt1.Rows[ss]["t80"].ToString();

                nueva2[ss, 80] = dt1.Rows[ss]["t81"].ToString();
                nueva2[ss, 81] = dt1.Rows[ss]["t82"].ToString();
                nueva2[ss, 82] = dt1.Rows[ss]["t83"].ToString();
                nueva2[ss, 83] = dt1.Rows[ss]["t84"].ToString();
                nueva2[ss, 84] = dt1.Rows[ss]["t85"].ToString();
                nueva2[ss, 85] = dt1.Rows[ss]["t86"].ToString();
                nueva2[ss, 86] = dt1.Rows[ss]["t87"].ToString();
                nueva2[ss, 87] = dt1.Rows[ss]["t88"].ToString();
                nueva2[ss, 88] = dt1.Rows[ss]["t89"].ToString();
                nueva2[ss, 89] = dt1.Rows[ss]["t90"].ToString();


                nueva2[ss, 90] = dt1.Rows[ss]["t91"].ToString();
                nueva2[ss, 91] = dt1.Rows[ss]["t92"].ToString();
                nueva2[ss, 92] = dt1.Rows[ss]["t93"].ToString();
                nueva2[ss, 93] = dt1.Rows[ss]["t94"].ToString();
                nueva2[ss, 94] = dt1.Rows[ss]["t95"].ToString();
                nueva2[ss, 95] = dt1.Rows[ss]["t96"].ToString();
                nueva2[ss, 96] = dt1.Rows[ss]["t97"].ToString();
                nueva2[ss, 97] = dt1.Rows[ss]["t98"].ToString();
                nueva2[ss, 98] = dt1.Rows[ss]["t99"].ToString();
                nueva2[ss, 99] = dt1.Rows[ss]["t100"].ToString();

                nueva2[ss, 100] = dt1.Rows[ss]["t101"].ToString();
                nueva2[ss, 101] = dt1.Rows[ss]["t102"].ToString();
                nueva2[ss, 102] = dt1.Rows[ss]["t103"].ToString();
                nueva2[ss, 103] = dt1.Rows[ss]["t104"].ToString();
                nueva2[ss, 104] = dt1.Rows[ss]["t105"].ToString();
                nueva2[ss, 105] = dt1.Rows[ss]["t106"].ToString();
                nueva2[ss, 106] = dt1.Rows[ss]["t107"].ToString();
                nueva2[ss, 107] = dt1.Rows[ss]["t108"].ToString();
                nueva2[ss, 108] = dt1.Rows[ss]["t109"].ToString();
                nueva2[ss, 109] = dt1.Rows[ss]["t110"].ToString();

                nueva2[ss, 110] = dt1.Rows[ss]["t111"].ToString();
                nueva2[ss, 111] = dt1.Rows[ss]["t112"].ToString();
                nueva2[ss, 112] = dt1.Rows[ss]["t113"].ToString();
                nueva2[ss, 113] = dt1.Rows[ss]["t114"].ToString();
                nueva2[ss, 114] = dt1.Rows[ss]["t115"].ToString();
                nueva2[ss, 115] = dt1.Rows[ss]["t116"].ToString();
                nueva2[ss, 116] = dt1.Rows[ss]["t117"].ToString();
                nueva2[ss, 117] = dt1.Rows[ss]["t118"].ToString();
                nueva2[ss, 118] = dt1.Rows[ss]["t119"].ToString();
                nueva2[ss, 119] = dt1.Rows[ss]["t120"].ToString();

                nueva2[ss, 120] = dt1.Rows[ss]["t121"].ToString();
                nueva2[ss, 121] = dt1.Rows[ss]["t122"].ToString();
                nueva2[ss, 122] = dt1.Rows[ss]["t123"].ToString();
                nueva2[ss, 123] = dt1.Rows[ss]["t124"].ToString();
                nueva2[ss, 124] = dt1.Rows[ss]["t125"].ToString();
                nueva2[ss, 125] = dt1.Rows[ss]["t126"].ToString();
                nueva2[ss, 126] = dt1.Rows[ss]["t127"].ToString();
                nueva2[ss, 127] = dt1.Rows[ss]["t128"].ToString();
                nueva2[ss, 128] = dt1.Rows[ss]["t129"].ToString();
                nueva2[ss, 129] = dt1.Rows[ss]["t130"].ToString();

                nueva2[ss, 130] = dt1.Rows[ss]["t131"].ToString();
                nueva2[ss, 131] = dt1.Rows[ss]["t132"].ToString();
                nueva2[ss, 132] = dt1.Rows[ss]["t133"].ToString();
                nueva2[ss, 133] = dt1.Rows[ss]["t134"].ToString();
                nueva2[ss, 134] = dt1.Rows[ss]["t135"].ToString();
                nueva2[ss, 135] = dt1.Rows[ss]["t136"].ToString();
                nueva2[ss, 136] = dt1.Rows[ss]["t137"].ToString();
                nueva2[ss, 137] = dt1.Rows[ss]["t138"].ToString();
                nueva2[ss, 138] = dt1.Rows[ss]["t139"].ToString();
                nueva2[ss, 139] = dt1.Rows[ss]["t140"].ToString();

                nueva2[ss, 140] = dt1.Rows[ss]["t141"].ToString();
                nueva2[ss, 141] = dt1.Rows[ss]["t142"].ToString();
                nueva2[ss, 142] = dt1.Rows[ss]["t143"].ToString();
                nueva2[ss, 143] = dt1.Rows[ss]["t144"].ToString();
                nueva2[ss, 144] = dt1.Rows[ss]["t145"].ToString();
                nueva2[ss, 145] = dt1.Rows[ss]["t146"].ToString();
                nueva2[ss, 146] = dt1.Rows[ss]["t147"].ToString();
                nueva2[ss, 147] = dt1.Rows[ss]["t148"].ToString();
                nueva2[ss, 148] = dt1.Rows[ss]["t149"].ToString();
                nueva2[ss, 149] = dt1.Rows[ss]["t150"].ToString();


                nueva2[ss, 150] = dt1.Rows[ss]["t151"].ToString();




            }

            //string arreglo = operacion.maquetado(nueva);
            string arreglo = operacion.maquetado(nueva2);
            return Json(arreglo, JsonRequestBehavior.AllowGet);

        }



        public FileResult Download2()
        {

            DataTable dt = new DataTable("Page");
            dt.Columns.AddRange(new DataColumn[21]
            {
                new DataColumn("T1"),
                new DataColumn("T2"),
                new DataColumn("T3"),
                new DataColumn("T4"),
                new DataColumn("T5"),
                new DataColumn("T6"),
                new DataColumn("T7"),
                new DataColumn("T8"),
                new DataColumn("T9"),
                new DataColumn("T10"),
                new DataColumn("T11"),
                new DataColumn("T12"),
                new DataColumn("T13"),
                new DataColumn("T14"),
                new DataColumn("T15"),
                new DataColumn("T16"),
                new DataColumn("T17"),
                new DataColumn("T18"),
                new DataColumn("T19"),
                new DataColumn("T20"),
                new DataColumn("21")
            });

            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{


            //    dt.Rows.Add(
                    

            //         dt1.Rows[i]["t1"].ToString(),
            //    dt1.Rows[i]["t2"].ToString(),
            //    dt1.Rows[i]["t3"].ToString(),
            //    dt1.Rows[i]["t4"].ToString(),
            //    dt1.Rows[i]["t5"].ToString(),
            //    dt1.Rows[i]["t6"].ToString(),
            //    dt1.Rows[i]["t7"].ToString(),
            //    dt1.Rows[i]["t8"].ToString(),
            //    dt1.Rows[i]["t9"].ToString(),
            //    dt1.Rows[i]["t10"].ToString(),
            //    dt1.Rows[i]["t11"].ToString(),
            //    dt1.Rows[i]["t12"].ToString(),
            //    dt1.Rows[i]["t13"].ToString(),
            //    dt1.Rows[i]["t14"].ToString(),
            //    dt1.Rows[i]["t15"].ToString(),
            //    dt1.Rows[i]["t16"].ToString(),
            //    dt1.Rows[i]["t17"].ToString(),
            //    dt1.Rows[i]["t18"].ToString(),
            //    dt1.Rows[i]["t19"].ToString(),
            //    dt1.Rows[i]["t20"].ToString(),
            //    dt1.Rows[i]["t21"].ToString()

            //        );


            //}

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Detalle_reporte_por_area" + DateTime.Now.Year + "" + DateTime.Now.Day + ".xlsx");
                }
            }
        }


    }
}