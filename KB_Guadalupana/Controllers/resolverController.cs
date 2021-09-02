using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace borrar01.Controllers
{
    public class resolverController : Controller
    {
        // GET: resolver
        public static string xx ="";
        public static string sid_col, sid_eva, snom_eva, sobs_eva, snom_col, snom_tes, snom_usu, sid_usu, sfec_lim, sid_tes;
        public static string idcalificacion="no";
        public ActionResult Index()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();

                ViewData["idusu"] = System.Web.HttpContext.Current.Session["idusu"] as String;
                xx = ViewData["idusu"].ToString();

                // bool respuesta = false;

                if (dato == "si")
                {
                    return View("~/Views/Home/inicio.cshtml");
                }
                else if (dato == "resolver")
                {
                    datosevaluador("2",xx);
                    datoseva();
                    return View("~/Views/resolver/index.cshtml");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }

            }
            catch(Exception)
            {
                return RedirectToAction("index", "Home");

            }

        }

        public ActionResult editarusuario()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();

                ViewData["idusu"] = System.Web.HttpContext.Current.Session["idusu"] as String;
                xx = ViewData["idusu"].ToString();

                // bool respuesta = false;

                if (dato == "si")
                {
                    return View("~/Views/Home/inicio.cshtml");
                }
                else if (dato == "resolver")
                {
                    datosevaluador("2", xx);
                    datoseva();
                    return View("~/Views/resolver/editarusuario.cshtml");
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

        public ActionResult resolvertest()
        {
            try
            {

                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                ViewData["calificadorx"] = System.Web.HttpContext.Current.Session["calificadorx"] as String;
                ViewData["calificado"] = System.Web.HttpContext.Current.Session["calificado"] as String;
                ViewData["test"] = System.Web.HttpContext.Current.Session["test"] as String;
                ViewData["evaluacion"] = System.Web.HttpContext.Current.Session["evaluacion"] as String;
                
                string dato = ViewData["sessionString"].ToString();
                string calificador = ViewData["calificadorx"].ToString();
                string evaluado = ViewData["calificado"].ToString();
                string test = ViewData["test"].ToString();
                string evaluacion = ViewData["evaluacion"].ToString();


                // bool respuesta = false;

                if (dato == "si")
                {
                    return View("~/Views/Home/inicio.cshtml");
                }
                else if (dato == "resolver")
                {

                    datosevaluador("2", calificador);
                    datosevaenc("1",evaluacion);
                    datosevaluado("2", evaluado);

                    return View("~/Views/resolver/resolvertest.cshtml");
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

        public ActionResult preguntas(string evaluacion, string persona)
        {
            datosenc(evaluacion, persona);

          
            ViewBag.sidcol = sid_col;
            ViewBag.sideva = sid_eva;
            ViewBag.snomeva = snom_eva;
            ViewBag.sobseva = sobs_eva;
            ViewBag.snomcol = snom_col;
            ViewBag.snomtes = snom_tes;
            ViewBag.snomusu = snom_usu;
            ViewBag.sidusu = sid_usu;
            ViewBag.sfeclim = sfec_lim;
            ViewBag.sidtes = sid_tes;

            return View();
        }



        [HttpPost]
        public ActionResult vistaevaluacion(List<encevaluacion> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d1 = items[0].fec_lim;
            d2 = items[0].nom_col;
            d3 = items[0].nom_tes;
            d4 = items[0].id_eva;

            switch (d0)
            {
                case "1":
                   query3 = "SELECT t1.id_eva, id_col as evaluador, fec_lim, nom_eva,id_tes, nom_tes, id_usu as evaluado, nom_usu FROM tes_eva_enc as t1 join tes_eva_det as t2 on t1.id_eva = t2.id_eva where t1.id_col = '" + xx + "'";
                    break;
            }
            List<encevaluacion> data = new List<encevaluacion>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    encevaluacion nuevo = new encevaluacion();
                    
                    nuevo.id_eva = dr["id_eva"].ToString();
                    nuevo.evaluador = dr["evaluador"].ToString();
                    nuevo.nom_eva = dr["nom_eva"].ToString();
                    nuevo.evaluado = dr["evaluado"].ToString();
                    nuevo.nom_usu = dr["nom_usu"].ToString();
                    nuevo.id_tes = dr["id_tes"].ToString();
                    sfecha = Convert.ToDateTime(dr["fec_lim"].ToString());
                    nuevo.fec_lim = sfecha.ToString("yyyy-MM-dd");
 
                    data.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult llenar()
        {

           

            string query3 = "";
            
            xx = this.Session["idusu"].ToString();
            query3 = "SELECT nom_usu, usu_pas, usu_cpa, id_are, id_suc, id_rol, nom_are, nom_suc, nom_rol FROM tes_usu_list as t1 join test_col_list as t2 on t1.id_col = t2.col_id where t1.id_col ='" + xx + "' ";
            List<usuario> data = new List<usuario>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {


                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    usuario nuevo = new usuario();
                    nuevo.nom_usu= dr["nom_usu"].ToString();
                    nuevo.usu_pas = dr["usu_pas"].ToString();
                    nuevo.usu_cpa = dr["usu_cpa"].ToString();

                    nuevo.id_are = dr["id_are"].ToString();
                    nuevo.id_suc= dr["id_suc"].ToString();
                    nuevo.id_rol = dr["id_rol"].ToString();
                    nuevo.nom_are = dr["nom_are"].ToString();
                    nuevo.nom_suc= dr["nom_suc"].ToString();
                    nuevo.nom_rol = dr["nom_rol"].ToString();


                    data.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }
            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);


        }



        [HttpPost]
        public ActionResult actusu(List<usuario> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "", d11 = "", d12 = "";

            d0 = items[0].operacion;
            d1 = items[0].id_reg;
            d2 = items[0].id_col;
            d3 = items[0].nom_usu;
            d4 = items[0].usu_pas;
            d5 = items[0].usu_cpa;

            d6 = items[0].nom_are;
            d7 = items[0].nom_suc;
            d8 = items[0].nom_rol;
            d9 = items[0].id_are;
            d10 = items[0].id_suc;
            d11 = items[0].id_rol;
            d12 = items[0].fec_nac;
            bool saber = false;
            bool saber2 = false;
            string query = "";


            query = "update tes_usu_list set usu_pas=?d4,usu_cpa=?d5 where id_reg = '" + saberusu(xx) + "'";
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);

            comando.Parameters.AddWithValue("?d1", d1);
            comando.Parameters.AddWithValue("?d2", d2);
            comando.Parameters.AddWithValue("?d3", d3);
            comando.Parameters.AddWithValue("?d4", d4);
            comando.Parameters.AddWithValue("?d5", d5);
            comando.Parameters.AddWithValue("?d6", d6);
            comando.Parameters.AddWithValue("?d7", d7);
            comando.Parameters.AddWithValue("?d8", d8);
            comando.Parameters.AddWithValue("?d9", d9);
            comando.Parameters.AddWithValue("?d10", d10);
            comando.Parameters.AddWithValue("?d11", d11);
            comando.Parameters.AddWithValue("?d12", d12);



            try
            {

                comando.ExecuteNonQuery();
                saber = true;


            }
            catch (Exception ex)
            {
            }
            cone.cerrar();




            query = "update test_col_list set id_are = '"+d9+"', id_suc = '"+d10+"', id_rol = '"+d11+"', nom_are = '"+d6+"', nom_suc = '"+d7+"', nom_rol = '"+d8+"' where col_id = '"+xx+"'";
            KB_Guadalupana.conexion.conexion00 cone2 = new KB_Guadalupana.conexion.conexion00();

            cone2.abrirconexion();
            MySqlCommand comando2 = new MySqlCommand(query, cone2.conne1);

            comando2.Parameters.AddWithValue("?d1", d1);
            comando2.Parameters.AddWithValue("?d2", d2);
            comando2.Parameters.AddWithValue("?d3", d3);
            comando2.Parameters.AddWithValue("?d4", d4);
            comando2.Parameters.AddWithValue("?d5", d5);
            comando2.Parameters.AddWithValue("?d6", d6);
            comando2.Parameters.AddWithValue("?d7", d7);
            comando2.Parameters.AddWithValue("?d8", d8);
            comando2.Parameters.AddWithValue("?d9", d9);
            comando2.Parameters.AddWithValue("?d10", d10);
            comando2.Parameters.AddWithValue("?d11", d11);
            comando2.Parameters.AddWithValue("?d12", d12);



            try
            {

                comando2.ExecuteNonQuery();
                saber2 = true;


            }
            catch (Exception ex)
            {
            }
            cone2.cerrar();



            if (saber&&saber2)
            {
                // respuesta verdadera
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                // respuesta falsa
                return Json(new { success = false, ex = "Error al actualizar" }, JsonRequestBehavior.AllowGet);

            }
        }


        private string saberusu(string col)
        {
            string dato = "";
            string query3 = "";

            query3 = "SELECT id_reg FROM tes_usu_list where id_col='" + xx + "' order by id_reg desc";
            
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {


                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {

                    dato= dr["id_reg"].ToString();
              

                }
            }
            catch (Exception)
            {
            }
            cone.cerrar();



            return dato;
        }

        [HttpPost]
        public ActionResult vistaprueba(List<test> items)
        {

            string query3 = "";
            string d0 = "";
            d0 = items[0].evaluador;


            query3 = "SELECT * FROM tes_det_tes where id_tes='" + sabertest(d0) + "'";

            List<test> data = new List<test>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    test nuevo = new test();

                    nuevo.id_reg = dr["id_reg"].ToString();
                    nuevo.id_tes = dr["id_tes"].ToString();
                    nuevo.pre_tes = dr["pre_tes"].ToString();
                    nuevo.pun_tes = dr["pun_tes"].ToString();
                    nuevo.obs_tes = dr["obs_tes"].ToString();
                    nuevo.id_pre = dr["id_pre"].ToString();

                    data.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult obtenerrespuestas(List<respuestas> items)
        {

            string query3 = "";
            string d0 = "";
            d0 = items[0].id_pre;


            query3 = "SELECT * FROM tes_res_list where id_pre ='"+d0+"'";

            List<respuestas> data = new List<respuestas>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    respuestas nuevo = new respuestas();

                    nuevo.id_pre = dr["id_pre"].ToString();
                    nuevo.id_reg = dr["id_reg"].ToString();
                    nuevo.res_nom = dr["res_nom"].ToString();
                    

                    data.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult terminar(List<string[]> items)
        {

            var resultado = items;
            string d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", observacion="";
            bool saber = false;
            int valores = 0;
            string query = "";
            valores = items.Count;
            string idcal = "";
            observacion= items[0][11];

            if (estadoevaluacion(items[0][0], items[0][4], items[0][6]))
            {
                for (int i = 0; i < valores; i++)

                {
                    d1 = items[i][0];
                    d2 = items[i][4];
                    d3 = items[i][6];
                    d4 = items[i][8];
                    d5 = items[i][10];
                    d6 = items[i][9];
                    idcal = obtenercalificacion(d1, d2, d3);
                    saber = false;

                    query = "insert into tes_cal_det (id_cal,id_pre,nom_pre, cal_pre) " +
                "values (?d1, ?d2, ?d3,?d4)";


                      KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();



                    cone.abrirconexion();
                    MySqlCommand comando = new MySqlCommand(query, cone.conne1);

                    comando.Parameters.AddWithValue("?d1", idcal);
                    comando.Parameters.AddWithValue("?d2", d4);
                    comando.Parameters.AddWithValue("?d3", d6);
                    comando.Parameters.AddWithValue("?d4", d5);


                    try
                    {

                        comando.ExecuteNonQuery();
                        saber = true;


                    }
                    catch (Exception es)
                    {
                    }
                    cone.cerrar();


                }



                if (saber)
                {
                    // respuesta verdadera

                    if (actualizarcalificacion(idcal, observacion))
                    {
                        // respuesta verdadera
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        // respuesta falsa
                        return Json(new { success = false, ex = "Algo salio mal :(" }, JsonRequestBehavior.AllowGet);

                    }


                }
                else
                {
                    // respuesta falsa
                    return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {

                return Json(new { success = false, ex = "Colaborador ya calificado" }, JsonRequestBehavior.AllowGet);

            }

        }

        private string sabertest(string evaluacion)
        {

            string query3 = "", examen = "";
            query3 = "SELECT id_eva,id_tes FROM tes_eva_enc2 where estado='" + "1"+"'";


              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    examen = dr["id_tes"].ToString();


                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return examen;
        }

        private bool actualizarcalificacion(string calificacion, string obs)
        {

            string query3 = "";
            bool saber = false;
            query3 = "update tes_cal_enc set est_cal = '0' , observaciones = '"+obs+"' where id_reg ='"+calificacion+"'";


              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                saber = true;
                
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return saber;
        }


        private void datosenc(string eva, string evaluado)
        {
            string query3 = "";
            query3 = "SELECT id_col,t1.id_eva,nom_eva,id_tes, obs_eva, nom_col,nom_tes, nom_usu, id_usu, fec_lim FROM tes_eva_enc as t1 join tes_eva_det as t2 on t1.id_eva = t2.id_eva where t1.id_eva = " + eva+" and id_usu = '"+ evaluado + "'";


              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    sid_col = dr["id_col"].ToString();
                    sid_eva = dr["id_eva"].ToString();
                    snom_eva = dr["nom_eva"].ToString();
                    sobs_eva = dr["obs_eva"].ToString();
                    snom_col = dr["nom_col"].ToString();
                    snom_tes = dr["nom_tes"].ToString();
                    snom_usu = dr["nom_usu"].ToString();
                    sid_usu = dr["id_usu"].ToString();
                    sfec_lim= dr["fec_lim"].ToString();
                    sid_tes= dr["id_tes"].ToString();



                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();



        }

        private void datosevaluador(string d0, string quien)
        {

            string query3 = "";
          

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc2 order by id_eva desc";
                    break;

                case "2":
                    query3 = "SELECT id_reg,nom_usu, id_cat, col_id, col_1no, col_1ap, nom_are FROM tes_usu_list as t1 join test_col_list"+
                              " as t2 on t1.id_col = t2.col_id where t2.col_id = '"+quien+"'";
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

                    ViewBag.nombre = dr["col_1no"].ToString()+" "+dr["col_1ap"].ToString();
                    ViewBag.nom_usu = dr["nom_usu"].ToString();
                    ViewBag.nom_are = dr["nom_are"].ToString();
                    ViewBag.colaborador = dr["col_id"].ToString();

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
           
        }


        private void datosevaenc(string d0, string quien)
        {

            string query3 = "";
            DateTime fecha1;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc2 where estado = '1' and id_eva = '"+quien+"'";
                    break;

                case "2":
                    query3 = "SELECT id_reg,nom_usu, id_cat, col_id, col_1no, col_1ap, nom_are FROM tes_usu_list as t1 join test_col_list" +
                              " as t2 on t1.id_col = t2.col_id where t2.col_id = '" + quien + "'";
                    break;


            }

              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            ViewBag.id_eva = "No se pudo cargar la información";
            ViewBag.id_tes = "No se pudo cargar la información";
            ViewBag.tit_eva = "No se pudo cargar la información";
            ViewBag.obs_eva = "No se pudo cargar la información";
            ViewBag.nom_tes = "No se pudo cargar la información";

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    ViewBag.id_eva = dr["id_eva"].ToString();
                    ViewBag.id_tes = dr["id_tes"].ToString();
                    ViewBag.tit_eva = dr["tit_eva"].ToString();
                    fecha1 = Convert.ToDateTime(dr["fec_fin"].ToString());
                    ViewBag.fec_fin = fecha1.ToString("yyyy-MM-dd");
                    ViewBag.obs_eva = dr["obs_eva"].ToString();
                    ViewBag.nom_tes = dr["nom_tes"].ToString();
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

        }

        private void datosevaluado(string d0, string quien)
        {

            string query3 = "";


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc2 order by id_eva desc";
                    break;

                case "2":
                    query3 = "SELECT id_reg,nom_usu, id_cat, col_id, col_1no, col_1ap, nom_are FROM tes_usu_list as t1 join test_col_list" +
                              " as t2 on t1.id_col = t2.col_id where t2.col_id = '" + quien + "'";
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

                    ViewBag.evaluadonombre = dr["col_1no"].ToString() + " " + dr["col_1ap"].ToString();
                    ViewBag.evaluadousu = dr["nom_usu"].ToString();
                    ViewBag.evaluadoarea = dr["nom_are"].ToString();
                    ViewBag.evaluadoid = dr["col_id"].ToString();

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

        }



        private void datoseva()
        {

            string query3 = "";


            query3 = "SELECT * FROM tes_eva_enc2 where estado = '1' ";

              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            DateTime fecha1;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    ViewBag.id_eva = dr["id_eva"].ToString() ;
                    ViewBag.id_tes = dr["id_tes"].ToString();
                    ViewBag.tit_eva = dr["tit_eva"].ToString();
                    fecha1 = Convert.ToDateTime(dr["fec_fin"].ToString());
                    ViewBag.fec_fin = fecha1.ToString("yyyy-MM-dd");
                    ViewBag.obs_eva= dr["obs_eva"].ToString();
                    ViewBag.nom_tes = dr["nom_tes"].ToString();

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

        }


        [HttpPost]
        public ActionResult operar_tes_cal_enc(List<tes_cal_enc> items)
        {

            string mensaje = "";
            bool saber = false;

            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d9 = ""; ;
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_tes;
            d3 = items[0].id_calificador;
            d4 = items[0].id_calificado;
            d9 = items[0].id_reg;
            string sfecha = "";
            string año = "", mes = "", dia = "", hora = "", minutos = "", segundos = "";
            
            

            año = "" + DateTime.Now.Year;
            mes = "" + DateTime.Now.Month;
            dia = "" + DateTime.Now.Day;
            hora = "" + DateTime.Now.Hour;
            minutos = "" + DateTime.Now.Minute;
            segundos = "" + DateTime.Now.Second; ;

            sfecha = año+"-"+mes.PadLeft(2, '0')+"-"+ dia.PadLeft(2, '0')+" "+ hora.PadLeft(2, '0')+":"+ minutos.PadLeft(2, '0')+":"+segundos.PadLeft(2, '0');
            if (permitir(sfecha, d1))
            {

                string query = "";

                switch (d0)
                {

                    case "1":
                        query = "insert into tes_cal_enc (id_eva,id_tes,id_calificador,id_calificado) " +
                    "values ( ?d1, ?d2, ?d3, ?d4)";
                        break;
                    case "2":
                        query = "update tes_eva_enc2f set id_tes=?d2,tit_eva=?d3,obs_eva=?d4,fec_ini=?d5,fec_fin=?d6,estado=?d7,nom_tes=?d8,nom_est=?d9" +
                            " where id_eva = '" + d1 + "'";
                        break;
                    case "3":
                        query = "delete from tes_eva_enc2f where id_eva = '" + d1 + "'";
                        break;
                }

                if (existeevaluacion(d1, d3, d4))
                {
                    if (estadoevaluacion(d1, d3, d4))
                    {

                        saber = true;
                        System.Web.HttpContext.Current.Session["calificadorx"] = d3;
                        System.Web.HttpContext.Current.Session["calificado"] = d4;
                        System.Web.HttpContext.Current.Session["test"] = d2;
                        System.Web.HttpContext.Current.Session["evaluacion"] = d1;
                        mensaje = "Actualizando Informacion";
                    }
                    else
                    {
                        saber = false;
                        mensaje = "La evaluacion para esta persona ha terminado";

                    }

                }
                else
                {
                      KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();


                    cone.abrirconexion();
                    MySqlCommand comando = new MySqlCommand(query, cone.conne1);

                    comando.Parameters.AddWithValue("?d1", d1);
                    comando.Parameters.AddWithValue("?d2", d2);
                    comando.Parameters.AddWithValue("?d3", d3);
                    comando.Parameters.AddWithValue("?d4", d4);


                    try
                    {

                        System.Web.HttpContext.Current.Session["calificadorx"] = d3;
                        System.Web.HttpContext.Current.Session["calificado"] = d4;
                        System.Web.HttpContext.Current.Session["test"] = d2;
                        System.Web.HttpContext.Current.Session["evaluacion"] = d1;
                        comando.ExecuteNonQuery();
                        saber = true;
                        mensaje = "Listo";

                    }
                    catch (Exception ex)
                    {
                    }
                    cone.cerrar();


                }
                if (saber)
                {
                    return Json(new { success = true, ex = mensaje }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, ex = mensaje }, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                mensaje = "Evaluacion fuera de tiempo";
                return Json(new { success = false, ex = mensaje }, JsonRequestBehavior.AllowGet);
            }

        }

        private bool existeevaluacion(string evaluacion, string calificador, string evaluado)
        {
            bool respuesta = false;
            string query3 = "";
            query3 = "select * from tes_cal_enc where id_eva = '"+evaluacion+"' and id_calificador = '"+calificador+"' and id_calificado = '"+ evaluado + "' ";

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    respuesta = true;
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return respuesta;

        }

        private bool permitir(string fecha, string eva)
        {
            bool respuesta = false;
            string query3 = "";
            query3 = "select * from tes_eva_enc2 where id_eva='" + eva+ "' and fec_fin > '" + fecha+"'";

              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    respuesta = true;
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return respuesta;

        }
        private bool estadoevaluacion(string evaluacion, string calificador, string evaluado)
        {
            bool respuesta = false;
            string query3 = "";
            query3 = "select * from tes_cal_enc where id_eva = '" + evaluacion + "' and id_calificador = '" + calificador + "' and id_calificado = '" + evaluado + "' and est_cal = '1' ";

              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                   
                    respuesta = true;
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return respuesta;

        }

        private string obtenercalificacion(string evaluacion, string calificador, string evaluado)
        {
           
            string query3 = "";
            query3 = "select * from tes_cal_enc where id_eva = '" + evaluacion + "' and id_calificador = '" + calificador + "' and id_calificado = '" + evaluado + "' and est_cal = '1' ";

              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    idcalificacion = dr["id_reg"].ToString(); 
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return idcalificacion;

        }

        public class encevaluacion
        {

            public string operacion { get; set; }
            public string evaluador { get; set; }
            public string evaluado { get; set; }
            public string nom_usu { get; set; }
            public string fec_lim { get; set; }
            public string nom_col { get; set; }
            public string nom_tes { get; set; }
            public string id_col { get; set; }
            public string nom_eva { get; set; }
            public string id_eva { get; set; }
            public string id_tes { get; set; }

        }

        public class test
        {

            public string evaluador { get; set; }
            public string id_reg { get; set; }
            public string id_tes { get; set; }
            public string pre_tes { get; set; }
            public string pun_tes { get; set; }
            public string obs_tes { get; set; }
            public string id_pre { get; set; }

        }

        public class respuestas
        {

            public string id_reg { get; set; }
            public string id_pre { get; set; }
            public string res_nom { get; set; }
         

        }

        public class tes_cal_enc
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_eva { get; set; }
            public string id_tes { get; set; }
            public string id_calificador { get; set; }
            public string id_calificado { get; set; }
            public string est_cal { get; set; }

        }



        public class usuario
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_col { get; set; }
            public string nom_usu { get; set; }
            public string usu_pas { get; set; }
            public string usu_cpa { get; set; }
            
            public string nom_are { get; set; }
            public string nom_suc { get; set; }
            public string nom_rol { get; set; }

            public string id_are { get; set; }
            public string id_suc { get; set; }
            public string id_rol { get; set; }

            public string fec_nac { get; set; }





        }


        private bool validar()


        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            bool respuesta = false;

            if (dato == "si")
            {

                respuesta = true;
            }
            else if (dato == "resolver")
            {

                respuesta = true;


            }

            return respuesta;


        }

        public ActionResult regresar()
        {

            return RedirectToAction("index", "Home");

        }





    }
}