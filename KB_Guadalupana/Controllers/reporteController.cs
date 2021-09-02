using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace borrar01.Controllers
{
    public class reporteController : Controller
    {
        // GET: reporte
        
        public ActionResult porarea()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();

              
                if (dato == "si")
                {
                    return View("~/Views/reporte/porarea.cshtml");
                }
                else if (dato == "resolver")
                {

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }
        public ActionResult porsuc()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();


                if (dato == "si")
                {
                    return View("~/Views/reporte/porsuc.cshtml");
                }
                else if (dato == "resolver")
                {

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }

        public ActionResult porfec()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();


                if (dato == "si")
                {
                    return View("~/Views/reporte/porfec.cshtml");
                }
                else if (dato == "resolver")
                {

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }

        public ActionResult poreva()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();


                if (dato == "si")
                {
                    return View("~/Views/reporte/poreva.cshtml");
                }
                else if (dato == "resolver")
                {

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }

        public ActionResult porareageneral()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();


                if (dato == "si")
                {
                    return View("~/Views/reporte/porareageneral.cshtml");
                }
                else if (dato == "resolver")
                {

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }
        public static List<areageneral> mareageneral = new List<areageneral>();
        public static List<filtroareaenc> dataenc = new List<filtroareaenc>();
        public static List<mfiltroareadet> data2 = new List<mfiltroareadet>();
        public static List<evaluacionesincluidas> encfechas = new List<evaluacionesincluidas>();
        public static List<mfiltrofechadet> detfechas = new List<mfiltrofechadet>();
        [HttpPost]
        public ActionResult filtroarea(List<filtroareaenc> items)
        {

            dataenc.Clear();
            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_tes;
            d3 = items[0].id_cal;
            d4 = items[0].id_evalu;
            d5 = items[0].obs_cal;
            d6 = items[0].nom_eva;
            d7 = items[0].id_are;
            d8 = items[0].est_cal;
            d9 = items[0].id_reg;



            switch (d0)
            {
                case "1":
                    query3 = "SELECT id_reg,id_eva,id_tes, id_calificador as calificador, id_calificado as evaluado, observaciones," +
                    "concat(col_1no, ' ', col_1ap) as nombre, id_are as areacol, est_cal" +
                    " FROM tes_cal_enc as t1 " +
                    " join " +
                    " test_col_list as t2 " +
                    " on id_calificado = col_id where id_are = '"+d7+"' and id_eva = '"+d1+"'";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_eva_enc where id_eva='" + d0 + "' order by id_eva desc";
                    break;


            }

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    filtroareaenc nuevo = new filtroareaenc();

                    nuevo.id_reg = dr["id_reg"].ToString();
                    nuevo.id_eva = saberevaluacion( dr["id_eva"].ToString());
                    nuevo.id_tes =sabertest( dr["id_tes"].ToString());
                    nuevo.id_cal =sabercalificador( dr["calificador"].ToString());
                    nuevo.id_evalu =saberevaluado( dr["evaluado"].ToString());
                    nuevo.obs_cal = dr["observaciones"].ToString();
                    nuevo.nom_eva = dr["nombre"].ToString();
                    nuevo.id_are = saberarea(dr["areacol"].ToString());
                    //string estados = dr["est_cal"].ToString();
                    string estados ="";
                    

                    //estados = dr["est_cal"].ToString()== "1" ? "Listo" : "Pendiente";
                    estados = dr["est_cal"].ToString() == "1" ? "Pendiente" : "Listo";

                    nuevo.est_cal = estados;
                    dataenc.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            
            return Json(dataenc, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult filtrofecha(List<evaluacionesincluidas> items)
        {

            encfechas.Clear();
            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_tes;
            d3 = items[0].tit_eva;
            d4 = items[0].obs_eva;
            d5 = items[0].fec_ini + " 00:00:00";
            d6 = items[0].fec_fin + " 11:59:59";
            d7 = items[0].nom_tes;
            d8 = items[0].nom_est;
          
            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc2 where fec_ini > '"+d5+"' and fec_fin < '"+d6+"'";
                    break;
            }

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    evaluacionesincluidas nuevo = new evaluacionesincluidas();

                    nuevo.id_eva = dr["id_eva"].ToString();
                    nuevo.id_tes = dr["id_tes"].ToString();
                    nuevo.tit_eva = dr["tit_eva"].ToString();
                    nuevo.obs_eva = dr["obs_eva"].ToString();
                    nuevo.fec_ini = dr["fec_ini"].ToString();
                    nuevo.fec_fin = dr["fec_fin"].ToString();
                    nuevo.nom_tes = dr["nom_tes"].ToString();
                    nuevo.nom_est = dr["nom_est"].ToString();

                    //estados = dr["est_cal"].ToString()== "1" ? "Listo" : "Pendiente";
                    //estados = dr["est_cal"].ToString() == "1" ? "Pendiente" : "Listo";


                    encfechas.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

            return Json(encfechas, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public ActionResult filtrofechadet(List<mfiltrofechadet> items)
        {

            string query3 = "";

            detfechas.Clear();

            mfiltrofechadet nuevo = new mfiltrofechadet();
            double a = 0.0, b = 0.0, r = 0.0;
            int cont = 0;
            for (int i = 0; i < encfechas.Count; i++)
            {

                query3 = "SELECT * FROM tes_cal_enc where id_eva='" + encfechas[i].id_eva + "'";

                KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
                cone.abrirconexion();
                MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

                try
                {
                    MySqlDataReader dr = comannd.ExecuteReader();
                    while (dr.Read())
                    {
                       string cal= dr["id_reg"].ToString();
                        string eva = dr["id_eva"].ToString();


                        string query4 = "SELECT * FROM tes_cal_det where id_cal='" + cal + "'";

                        
                        cone.abrirconexion();
                        MySqlCommand comannd2 = new MySqlCommand(query4, cone.conne1);

                        int result = Convert.ToInt32(comannd2.ExecuteScalar());
                        try
                        {
                            if (result > 0)
                            {
                                MySqlDataReader dr2 = comannd2.ExecuteReader();

                                a = 0.0; b = 0.0; r = 0.0;
                                cont = 0;
                                while (dr2.Read())
                                {
                                    cont++;
                                    nuevo = new mfiltrofechadet();
                                    //enca
                                    nuevo.id_eva = dr["id_eva"].ToString() + "/" + saberevaluacion(dr["id_eva"].ToString());
                                    nuevo.id_are_cal = infocolare(dr["id_calificador"].ToString()) + "/" + saberarea(infocolare(dr["id_calificador"].ToString()));
                                    nuevo.nom_calificador = sabercalificador(dr["id_calificador"].ToString());
                                    nuevo.id_are_eva = infocolare(dr["id_calificado"].ToString()) + "/" + saberarea(infocolare(dr["id_calificado"].ToString()));
                                    nuevo.id_evaluado = dr["id_calificado"].ToString();
                                    nuevo.nom_evaluado = dr["id_calificado"].ToString()+"/"+saberevaluado(dr["id_calificado"].ToString()); ;
                                    nuevo.id_calificacion = cal+"/"+eva;

                                    //det
                                    nuevo.id_reg_det = dr2["id_reg"].ToString();
                                    nuevo.id_pre = dr2["id_pre"].ToString();
                                    nuevo.tit_pre = dr2["nom_pre"].ToString();
                                    a = (Convert.ToDouble(dr2["cal_pre"].ToString())) * 2;
                                    nuevo.punteo =""+ a;

                                    b = b + a;
                                    detfechas.Add(nuevo);

                                }
                                r = (b / (cont * 10)) * 100;

                                nuevo = new mfiltrofechadet();
                                //enca
                                nuevo.id_eva = "";
                                nuevo.id_calificacion =  "";
                                nuevo.id_are_cal = "";
                                nuevo.nom_calificador = "";
                                nuevo.id_are_eva = "";
                                nuevo.id_evaluado = "";
                                nuevo.nom_evaluado = "TOTAL";
                                //det
                                nuevo.id_reg_det = "";
                                nuevo.id_pre = "";
                                nuevo.tit_pre = "";

                                nuevo.punteo = ""+Math.Round(r,2);


                                detfechas.Add(nuevo);
                            }
                        }
                        catch (Exception)
                        {
                        }
                 



                    }
                }
                catch (Exception)
                {
                }

                cone.cerrar();
               
            }

            //sergio

            return Json(detfechas, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult filtroareadet(List<areageneral> items)
        {

            mareageneral.Clear();
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_calificado;
            d3 = items[0].id_pre;
            d4 = items[0].nom_pre;
            d5 = items[0].punteo;
            d6 = items[0].cant_preg;
            d7 = items[0].calificador_cuantos;
            d8 = items[0].id_are;
            d9 = items[0].promedio_ind;
            d10 = items[0].promedio_gen;


            /*
             * 
             * 
             operacion 
            id_eva 
            id_calificado 
            id_pre 
            nom_pre
            punteo
            cant_preg 
            calificador_cuantos
            id_are 
            promedio_ind 
            promedio_gen 



            
            */
            string query3 = "";
            int cpregunta = 0;
            double promedioindividual = 0.0;
            double promediopregunta = 0.0;
            double punteo = 0.0;
            double promediogeneral = 0.0;
            double total = 0.0;
            int contgen = 0;

            areageneral nuevo = new areageneral();
            double a = 0.0, b = 0.0, r = 0.0;
            int cont = 0;
            query3 = "SELECT id_eva, id_calificado as evaluado, id_are as areacol FROM tes_cal_enc as t1 " +
                    " join " +
                    " test_col_list as t2 " +
                    " on id_calificado = col_id where id_are = '" + d8 + "' and id_eva = '" + d1 + "' group by id_eva, evaluado";


            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                
                cont = 0;
                while (dr.Read())
                {
                    string evaluado = dr["evaluado"].ToString();
                    string evaluacion = dr["id_eva"].ToString();
                    
                    
                    //string query4 = "SELECT t1.id_reg, id_eva, id_calificador, id_calificado, id_cal, id_pre, nom_pre,cal_pre, sum(cal_pre)*2 as punteo, count(id_pre) as cant_preg, count(id_calificador) as calificador_cuantos FROM bd_seguridad.tes_cal_enc as t1 join tes_cal_det as t2 on t1.id_reg=id_cal " +
                        //"where id_eva ='" + evaluacion + "' and id_calificado= '" + evaluado + "' group by id_pre";
                    string query4 = " SELECT id_eva, id_calificado, id_pre, nom_pre, sum(cal_pre)*2 as punteo, count(id_pre) as cant_preg, count(id_calificador) as calificador_cuantos FROM tes_cal_enc as t1 join tes_cal_det as t2 on t1.id_reg = id_cal " +
                        "where id_eva ='" + evaluacion + "' and id_calificado= '" + evaluado + "'  group by id_pre,nom_pre";
                    cpregunta = 0;
                    promediopregunta = 0.0;
                    punteo = 0.0;
                    cone.abrirconexion();
                    MySqlCommand comannd2 = new MySqlCommand(query4, cone.conne1);

                    int result = Convert.ToInt32(comannd2.ExecuteScalar());
                    try
                    {
                        if (result > 0)
                        {
                            contgen++;
                            MySqlDataReader dr2 = comannd2.ExecuteReader();

                            a = 0.0; b = 0.0; r = 0.0;
                            cont = 0;
                            while (dr2.Read())
                            {
                                cont++;
                                nuevo = new areageneral();
                                nuevo.id_eva = dr2["id_eva"].ToString();
                                nuevo.id_calificado = saberevaluado( dr2["id_calificado"].ToString());
                                nuevo.id_pre = dr2["id_pre"].ToString();
                                nuevo.nom_pre = dr2["nom_pre"].ToString();
                                
                                cpregunta = Convert.ToInt32( dr2["cant_preg"].ToString());
                                punteo = Convert.ToDouble(dr2["punteo"].ToString());
                                promediopregunta = (punteo / (cpregunta * 10)) * 100;
                                promedioindividual = saberpromedio(evaluacion, evaluado)  * 10;
                                nuevo.punteo = ""+punteo;
                                nuevo.cant_preg =""+ cpregunta;
                                nuevo.calificador_cuantos = dr2["cant_preg"].ToString();
                                nuevo.id_are = dr["areacol"].ToString();
                                nuevo.promedio_ind = "" + Math.Round(promediopregunta, 2);
                                nuevo.promedio_gen = ""+ Math.Round( promedioindividual,2);

                                mareageneral.Add(nuevo);

                            }
                            promediogeneral += promedioindividual;

                        }
                        
                    }
                    catch (Exception)
                    {
                    }
                    

                }
                nuevo = new areageneral();
                nuevo.id_eva = "";
                nuevo.id_calificado = "";
                nuevo.id_pre = "";
                nuevo.nom_pre = "";
                nuevo.punteo = "";
                nuevo.cant_preg = "";
                nuevo.calificador_cuantos = "";
                nuevo.id_are = "";
                nuevo.promedio_ind = "Promedio total por Área";
                total = (promediogeneral / (contgen * 100)) * 100;
                nuevo.promedio_gen = "" + Math.Round(total,2) ;
                mareageneral.Add(nuevo);
            }
            catch (Exception)
            {
            }
            cone.cerrar();


            return Json(mareageneral, JsonRequestBehavior.AllowGet);
        }


        private double saberpromedio(string xeva, string xcalificado)

        {

            double promedio = 0.0;
            int contador = 0;
            //string query4 = "SELECT t1.id_reg, id_eva, id_calificador, id_calificado, id_cal, id_pre, nom_pre,cal_pre, sum(cal_pre)*2 as punteo, count(id_pre) as cant_preg, count(id_calificador) as calificador_cuantos, ((sum(cal_pre)*2)/(count(id_pre)*10))*100 as promedio  FROM bd_seguridad.tes_cal_enc as t1 join tes_cal_det as t2 on t1.id_reg=id_cal where id_eva ='"+xeva+"' and id_calificado= '"+xcalificado+"' group by id_pre";
            string query4 = "SELECT  id_eva, id_calificado, id_pre, nom_pre, sum(cal_pre)*2 as punteo, count(id_pre) as cant_preg, count(id_calificador) as calificador_cuantos, ((sum(cal_pre)*2)/(count(id_pre)*10))*100 as promedio  FROM tes_cal_enc as t1 join tes_cal_det as t2 on t1.id_reg=id_cal where id_eva ='" + xeva + "' and id_calificado= '" + xcalificado + "' group by id_pre,nom_pre";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd2 = new MySqlCommand(query4, cone.conne1);

            int result = Convert.ToInt32(comannd2.ExecuteScalar());
            try
            {
                if (result > 0)
                {
                    promedio = 0;
                    MySqlDataReader dr2 = comannd2.ExecuteReader();

                   
                    while (dr2.Read())
                    {
                        contador++;
                        promedio+= Convert.ToDouble( dr2["promedio"].ToString());
           
                    }


                }
            }
            catch (Exception)
            {
            }
            cone.cerrar();
            promedio = promedio / (contador * 10);
            return promedio;
        }


        private string saberevaluacion(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT tit_eva FROM tes_eva_enc2 where id_eva='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["tit_eva"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }

        private string saberarea(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT nom_are FROM tes_are_lis where id_reg='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["nom_are"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }


        private string sabertest(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT nom_tes FROM tes_enc_tes where id_tes='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["nom_tes"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }

        private string sabercalificador(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT col_1no , col_1ap FROM test_col_list where col_id='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["col_1no"].ToString()+" "+ dr["col_1ap"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }

        private string infocolare(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT id_are FROM test_col_list where col_id='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["id_are"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }


        private string saberevaluado(string dato)
        {

            string query3 = "", examen = "";
            query3 = "SELECT col_1no , col_1ap FROM test_col_list where col_id='" + dato + "'";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["col_1no"].ToString() + " " + dr["col_1ap"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }


        [HttpPost]
        public ActionResult filtroareageneral(List<mfiltrofechadet> items)
        {

            string query3 = "";

            detfechas.Clear();

            mfiltrofechadet nuevo = new mfiltrofechadet();
            double a = 0.0, b = 0.0, r = 0.0;
            int cont = 0;
            for (int i = 0; i < encfechas.Count; i++)
            {

                query3 = "SELECT * FROM tes_cal_enc where id_eva='" + encfechas[i].id_eva + "'";

                KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
                cone.abrirconexion();
                MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

                try
                {
                    MySqlDataReader dr = comannd.ExecuteReader();
                    while (dr.Read())
                    {
                        string cal = dr["id_reg"].ToString();
                        string eva = dr["id_eva"].ToString();


                        string query4 = "SELECT * FROM tes_cal_det where id_cal='" + cal + "'";


                        cone.abrirconexion();
                        MySqlCommand comannd2 = new MySqlCommand(query4, cone.conne1);

                        int result = Convert.ToInt32(comannd2.ExecuteScalar());
                        try
                        {
                            if (result > 0)
                            {
                                MySqlDataReader dr2 = comannd2.ExecuteReader();

                                a = 0.0; b = 0.0; r = 0.0;
                                cont = 0;
                                while (dr2.Read())
                                {
                                    cont++;
                                    nuevo = new mfiltrofechadet();
                                    //enca
                                    nuevo.id_eva = dr["id_eva"].ToString() + "/" + saberevaluacion(dr["id_eva"].ToString());
                                    nuevo.id_are_cal = infocolare(dr["id_calificador"].ToString()) + "/" + saberarea(infocolare(dr["id_calificador"].ToString()));
                                    nuevo.nom_calificador = sabercalificador(dr["id_calificador"].ToString());
                                    nuevo.id_are_eva = infocolare(dr["id_calificado"].ToString()) + "/" + saberarea(infocolare(dr["id_calificado"].ToString()));
                                    nuevo.id_evaluado = dr["id_calificado"].ToString();
                                    nuevo.nom_evaluado = dr["id_calificado"].ToString() + "/" + saberevaluado(dr["id_calificado"].ToString()); ;
                                    nuevo.id_calificacion = cal + "/" + eva;

                                    //det
                                    nuevo.id_reg_det = dr2["id_reg"].ToString();
                                    nuevo.id_pre = dr2["id_pre"].ToString();
                                    nuevo.tit_pre = dr2["nom_pre"].ToString();
                                    a = (Convert.ToDouble(dr2["cal_pre"].ToString())) * 2;
                                    nuevo.punteo = "" + a;

                                    b = b + a;
                                    detfechas.Add(nuevo);

                                }
                                r = (b / (cont * 10)) * 100;

                                nuevo = new mfiltrofechadet();
                                //enca
                                nuevo.id_eva = "";
                                nuevo.id_calificacion = "";
                                nuevo.id_are_cal = "";
                                nuevo.nom_calificador = "";
                                nuevo.id_are_eva = "";
                                nuevo.id_evaluado = "";
                                nuevo.nom_evaluado = "TOTAL";
                                //det
                                nuevo.id_reg_det = "";
                                nuevo.id_pre = "";
                                nuevo.tit_pre = "";

                                nuevo.punteo = "" + Math.Round(r, 2);


                                detfechas.Add(nuevo);
                            }
                        }
                        catch (Exception)
                        {
                        }




                    }
                }
                catch (Exception)
                {
                }

                cone.cerrar();

            }

            //sergio

            return Json(detfechas, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult filtroareadet1(List<mfiltroareadet> items)
        {

            string query3 = "";

            data2.Clear();

            mfiltroareadet nuevo = new mfiltroareadet();
            double a = 0.0, b = 0.0, r = 0.0;
            int cont = 0;
            for (int i = 0; i < dataenc.Count; i++)
            {
                query3 = "SELECT * FROM tes_cal_det where id_cal='" + dataenc[i].id_reg + "'";

                KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
                cone.abrirconexion();
                MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


                try
                {

                    MySqlDataReader dr = comannd.ExecuteReader();
                    a = 0.0; b = 0.0; r = 0.0;
                    cont = 0;
                    while (dr.Read())
                    {
                        cont++;
                        nuevo = new mfiltroareadet();
                        nuevo.id_reg = dr["id_reg"].ToString();
                        nuevo.id_cal = dr["id_cal"].ToString();
                        nuevo.id_pre = dr["id_pre"].ToString();
                        nuevo.nom_pre = dr["nom_pre"].ToString();
                        //nota
                        nuevo.id_cali = dataenc[i].id_cal;
                        nuevo.id_are = dataenc[i].id_are;
                        nuevo.id_eva = dataenc[i].id_eva;
                        nuevo.nom_eva = dataenc[i].nom_eva;
                        a = (Convert.ToDouble(dr["cal_pre"].ToString())) * 2;
                        b = b + a;
                        nuevo.cal_pre = "" + a;
                        data2.Add(nuevo);
                    }
                    r = (b / (cont * 10)) * 100;
                    nuevo = new mfiltroareadet();
                    nuevo.id_cali = "";
                    nuevo.id_are = "";
                    nuevo.id_eva = "";
                    nuevo.nom_eva = "";
                    nuevo.id_reg = "";
                    nuevo.id_cal = "";
                    nuevo.id_pre = "";
                    nuevo.nom_pre = "Total";
                    nuevo.cal_pre = "" + Math.Round(r, 2) + "%";
                    data2.Add(nuevo);
                }
                catch (Exception)
                {
                }
                cone.cerrar();

            }
            return Json(data2, JsonRequestBehavior.AllowGet);
        }


        public class filtroareaenc
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_eva { get; set; }
            public string id_tes { get; set; }
            public string id_cal { get; set; }
            public string id_evalu { get; set; }
            public string obs_cal { get; set; }
            public string nom_eva { get; set; }
            public string id_are { get; set; }
            public string est_cal { get; set; }
        }

        public class mfiltroareadet
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_cal { get; set; }
            public string id_pre { get; set; }
            public string nom_pre { get; set; }
            public string cal_pre { get; set; }
            //nota
            public string id_cali { get; set; }
            public string id_are { get; set; }
            public string id_eva { get; set; }
            public string nom_eva { get; set; }



        }

        public class areageneral 
        {

            public string operacion { get; set; }
            public string id_eva { get; set; }
            public string id_calificado { get; set; }
            public string id_pre { get; set; }
            public string nom_pre { get; set; }
            public string punteo { get; set; }
            public string cant_preg { get; set; }
            public string calificador_cuantos { get; set; }
            public string id_are { get; set; }
            public string promedio_ind { get; set; }
            public string promedio_gen { get; set; }

         

        }


        public class mfiltrofechadet
        {

            public string operacion { get; set; }
            public string id_calificacion { get; set; }
            public string id_reg_det { get; set; }
            public string id_eva { get; set; }
            public string id_pre { get; set; }
            public string tit_pre { get; set; }

            
            public string id_are_cal { get; set; }
            public string nom_calificador { get; set; }

            public string id_are_eva { get; set; }
            public string id_evaluado { get; set; }
            public string nom_evaluado { get; set; }

            public string punteo { get; set; }



        }




        public class evaluacionesincluidas
        {

            public string operacion { get; set; }
            public string id_eva { get; set; }
            public string id_tes { get; set; }
            public string tit_eva { get; set; }
            public string obs_eva { get; set; }
            public string fec_ini { get; set; }
            //nota
            
            public string fec_fin { get; set; }
            public string nom_tes { get; set; }
            public string nom_est { get; set; }
            
            



        }

     
        public FileResult Download()
        {
            
            DataTable dt = new DataTable("Page");
            dt.Columns.AddRange(new DataColumn[10] 
            { 
                new DataColumn("ID Calificacion"),
                new DataColumn("ID evaluacion"),
                new DataColumn("ID Test"),
                new DataColumn("ID Calificador"),
                new DataColumn("ID Evaluado"),
                new DataColumn("Observaciones"),
                new DataColumn("Nombre Evaluado"),
                new DataColumn("ID Area"),
                new DataColumn("Estado"),
                new DataColumn("Punteo") 
            });

            for (int i = 0; i < dataenc.Count; i++)
            {


                dt.Rows.Add(
                    dataenc[i].id_reg,
                    dataenc[i].id_eva, 
                    dataenc[i].id_tes,
                    dataenc[i].id_cal,
                    dataenc[i].id_evalu,
                    dataenc[i].obs_cal,
                    dataenc[i].nom_eva,
                    dataenc[i].id_are,
                    dataenc[i].est_cal
                    );

              
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Resumn_por_area"+DateTime.Now.Year+""+DateTime.Now.Day+".xlsx");
                }
            }
        }

        public FileResult Download2()
        {

            DataTable dt = new DataTable("Page");
            dt.Columns.AddRange(new DataColumn[9]
            {
                new DataColumn("ID Registro"),
                new DataColumn("ID Evaluación"),
                new DataColumn("ID Pregunta"),
                new DataColumn("Pregunta"),
                new DataColumn("Calificador"),
                new DataColumn("Área"),
                new DataColumn("Evaluaciòn"),
                new DataColumn("Evaluado"),
                new DataColumn("Punteo")
            });

            for (int i = 0; i < data2.Count; i++)
            {


                dt.Rows.Add(
                    data2[i].id_reg,
                    data2[i].id_cal,
                    data2[i].id_pre,
                    data2[i].nom_pre,
                    data2[i].id_cali, //sfda
                    data2[i].id_are,
                    data2[i].id_eva,
                    data2[i].nom_eva,
                    data2[i].cal_pre
                    );
               

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Detalle_reporte_por_area"+ DateTime.Now.Year + "" + DateTime.Now.Day+".xlsx");
                }
            }
        }

        //mareageneral
        public FileResult desdetalle()
        {

            DataTable dt = new DataTable("Page");
            dt.Columns.AddRange(new DataColumn[9]
            {
                new DataColumn("ED registro"),
                new DataColumn("Reg/Eva"),
                new DataColumn("Evaluación"),
                new DataColumn("Pregunta"),
                new DataColumn("Área Evaluador"),
                new DataColumn("Evaluador"),
                new DataColumn("Área Evaluado"),
                new DataColumn("Evaluado"),
                new DataColumn("Punteo")
            });

            for (int i = 0; i < detfechas.Count; i++)
            {


                dt.Rows.Add(
                    detfechas[i].id_reg_det,
                    detfechas[i].id_calificacion,
                    detfechas[i].id_eva,
                    detfechas[i].id_pre +"/" + detfechas[i].tit_pre,
                    detfechas[i].id_are_cal, //sfda
                    detfechas[i].nom_calificador,
                    detfechas[i].id_are_eva,
                    detfechas[i].nom_evaluado,
                    detfechas[i].punteo
                    );
             



            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Detalle_reporte_por_fechas" + DateTime.Now.Year + "" + DateTime.Now.Day + ".xlsx");
                }
            }
        }


        public FileResult dmareageneral()
        {

            DataTable dt = new DataTable("Page");
            dt.Columns.AddRange(new DataColumn[10]
            {
                new DataColumn("Evaluación"),
                new DataColumn("Evaluado"),
                new DataColumn("ID pregunta"),
                new DataColumn("Pregunta"),
                new DataColumn("Punteo"),
                new DataColumn("Cant. "),
                new DataColumn("Cant Eval."),
                new DataColumn("ID Área"),
                new DataColumn("Promedio P/P"),
                new DataColumn("Promedio individual")
            });

            /*
             
                   '<tr>' +
                    '<th scope="row">' + item.id_eva + '</th>' +
                    '<td>' + item.id_calificado + '</td>' +
                    '<td>' + item.id_pre + '</td>' +
                    '<td>' + item.nom_pre + '</td>' +
                    '<td>' + item.punteo + '</td>' +
                    '<td>' + item.cant_preg + '</td>' +
                    '<td>' + item.calificador_cuantos + '</td>' +
                    '<td>' + item.id_are + '</td>' +
                    '<td>' + item.promedio_ind + '</td>' +
                    '<td>' + item.promedio_gen + '</td>' +
                    
            */

            for (int i = 0; i < mareageneral.Count; i++)
            {


                dt.Rows.Add(
                    mareageneral[i].id_eva,
                    mareageneral[i].id_calificado,
                    mareageneral[i].id_pre,
                    mareageneral[i].nom_pre,
                    mareageneral[i].punteo, //sfda
                    mareageneral[i].cant_preg,
                    mareageneral[i].calificador_cuantos,
                    mareageneral[i].id_are,
                    mareageneral[i].promedio_ind,
                    mareageneral[i].promedio_gen
                    );




            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Detalle_reporte_por_fechas" + DateTime.Now.Year + "" + DateTime.Now.Day + ".xlsx");
                }
            }
        }

    }
}