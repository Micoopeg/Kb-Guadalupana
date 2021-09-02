using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace borrar01.Controllers
{
    public class evaluacionesController : Controller
    {
        // GET: evaluacionesvalu
        public ActionResult enviodeevaluaciones()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/enviodeevaluaciones.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }



        }

        public ActionResult evaluacionesgenerales()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/evaluacionesgenerales.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }



        }


        public ActionResult crear()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/crear.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }
        public ActionResult vistageneralevaluaciones()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/vistageneralevaluaciones.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }


        public ActionResult evaluacionesgeneraleditar()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/evaluacionesgeneraleditar.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }

        public ActionResult evaluacionesgeneralvista()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/evaluaciones/evaluacionesgeneralvista.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }




        [HttpPost]
        public ActionResult operacionevaluaciones(List<encevaluacion> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "", d11 = "", d12 = "", d13 = "";
            string d14 = "", d15 = "", d16 = "", d17 = "", d18 = ""; ;
            d0 = items[0].operacion;
            d1 = items[0].tip_eva;
            d2 = items[0].id_suc;
            d3 = items[0].id_are;
            d4 = items[0].id_rol;
            d5 = items[0].id_col;
            d6 = items[0].id_tes;
            d7 = items[0].fec_lim;
            d8 = items[0].est_cal;
            d9 = items[0].est_env;
            d10 = items[0].est_act;
            d11 = items[0].nom_eva;
            d12 = items[0].obs_eva;

            d13 = items[0].nom_suc;
            d14 = items[0].nom_are;
            d15 = items[0].nom_rol;
            d16 = items[0].nom_col;
            d17 = items[0].nom_tes;
            d18 = items[0].id_eva;


            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_eva_enc (nom_eva,obs_eva,fec_lim) " +
                "values (?d11, ?d12, ?d7)";
                    break;
                case "3":
                    query = "update tes_eva_enc set tip_eva=?d1,id_suc=?d2,id_are=?d3,id_rol=?d4,id_col=?d5"+
                        ",id_tes=?d6,fec_lim=?d7, nom_suc=?d13, nom_are =?d14, nom_rol=?d15, nom_col=?d16, nom_tes=?d17" +
                        " where id_eva = '" + d18 + "'";
                    break;
                case "4":
                    query = "delete from tes_eva_enc where id_eva = '" + d18 + "'";
                    break;
            }
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            
            bool saber = false;

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
            comando.Parameters.AddWithValue("?d13", d13);
            comando.Parameters.AddWithValue("?d14", d14);
            comando.Parameters.AddWithValue("?d15", d15);
            comando.Parameters.AddWithValue("?d16", d16);
            comando.Parameters.AddWithValue("?d17", d17);


            try
            {

                comando.ExecuteNonQuery();
                saber = true;


            }
            catch (Exception es )
            {
            }
            cone.cerrar();

            if (saber)
            {
                // respuesta verdadera
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                // respuesta falsa
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public ActionResult vistaevaluaciones(List<encevaluacion> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "", d11 = "", d12 = "", d13 = "";
            string d14 = "", d15 = "", d16 = "", d17 = "", d18 = ""; ;
            d0 = items[0].operacion;
            d1 = items[0].tip_eva;
            d2 = items[0].id_suc;
            d3 = items[0].id_are;
            d4 = items[0].id_rol;
            d5 = items[0].id_col;
            d6 = items[0].id_tes;
            d7 = items[0].fec_lim;
            d8 = items[0].est_cal;
            d9 = items[0].est_env;
            d10 = items[0].est_act;
            d11 = items[0].nom_eva;
            d12 = items[0].obs_eva;

            d13 = items[0].nom_suc;
            d14 = items[0].nom_are;
            d15 = items[0].nom_rol;
            d16 = items[0].nom_col;
            d17 = items[0].nom_tes;
            d18 = items[0].id_eva;

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc order by id_eva desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_eva_enc where id_eva='"+d18+"' order by id_eva desc";
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
                    nuevo.tip_eva = dr["tip_eva"].ToString(); 
                    nuevo.id_suc = dr["id_suc"].ToString(); 
                    nuevo.id_are = dr["id_are"].ToString(); 
                    nuevo.id_rol = dr["id_rol"].ToString(); 
                    nuevo.id_col = dr["id_col"].ToString(); 
                    nuevo.id_tes = dr["id_tes"].ToString();
                    sfecha = Convert.ToDateTime(dr["fec_lim"].ToString()) ;
                    nuevo.fec_lim = sfecha.ToString("yyyy-MM-dd");
                    nuevo.est_cal = dr["est_cal"].ToString(); 
                    nuevo.est_env = dr["est_env"].ToString(); 
                    nuevo.est_act = dr["est_act"].ToString(); 
                    nuevo.id_eva = dr["id_eva"].ToString(); ;
                    nuevo.nom_eva = dr["nom_eva"].ToString(); 
                    nuevo.obs_eva= dr["obs_eva"].ToString();

                    nuevo.nom_suc = dr["nom_suc"].ToString();
                    nuevo.nom_are = dr["nom_are"].ToString();
                    nuevo.nom_rol = dr["nom_rol"].ToString();
                    nuevo.nom_col = dr["nom_col"].ToString();
                    nuevo.nom_tes = dr["nom_tes"].ToString();

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
        public ActionResult operaciondetalle(List<detevaluacion> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_usu;
            d3 = items[0].nom_usu;
            d4 = items[0].id_reg;


            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_eva_det (id_eva,id_usu,nom_usu) " +
                "values (?d1, ?d2, ?d3)";
                    break;
                case "3":
                    query = "update tes_eva_enc set tip_eva=?d1,id_suc=?d2,id_are=?d3,id_rol=?d4,id_col=?d5" +
                        ",id_tes=?d6,fec_lim=?d7" +
                        " where id_eva = '" + d4 + "'";
                    break;
                case "4":
                    query = "delete from tes_eva_det where id_reg = '" + d4 + "'";
                    break;
            }
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();

            bool saber = false;

            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);

            comando.Parameters.AddWithValue("?d1", d1);
            comando.Parameters.AddWithValue("?d2", d2);
            comando.Parameters.AddWithValue("?d3", d3);
            comando.Parameters.AddWithValue("?d4", d4);
           


            try
            {

                comando.ExecuteNonQuery();
                saber = true;


            }
            catch (Exception )
            {
            }
            cone.cerrar();

            if (saber)
            {
                // respuesta verdadera
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                // respuesta falsa
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult vistadetalle(List<detevaluacion> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_usu;
            d3 = items[0].nom_usu;
            d4 = items[0].id_reg;
            
            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_det by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_eva_det where id_eva='" + d1 + "' order by id_reg desc";
                    break;


            }
            List<detevaluacion> data = new List<detevaluacion>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    
                    detevaluacion nuevo = new detevaluacion();
                    
                    nuevo.id_reg = dr["id_reg"].ToString(); 
                    nuevo.id_eva= dr["id_eva"].ToString();
                    nuevo.id_usu = dr["id_usu"].ToString();
                    nuevo.nom_usu = dr["nom_usu"].ToString();


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
        public ActionResult operargeneral(List<evaluaciongeneral> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = ""; ;
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_tes;
            d3 = items[0].tit_eva;
            d4 = items[0].obs_eva;
            d5 = items[0].fec_ini;
            d6 = items[0].fec_fin;
            d7 = items[0].estado;
            d8 = items[0].nom_tes;
            d9 = items[0].nom_est;

            d5 = d5 + " 00:00:00";
            d6 = d6 + " 11:59:59";
            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_eva_enc2 (id_tes,tit_eva,obs_eva,fec_ini,fec_fin,estado, nom_tes, nom_est) " +
                "values ( ?d2, ?d3, ?d4, ?d5, ?d6, ?d7, ?d8, ?d9)";
                    break;
                case "2":
                    query = "update tes_eva_enc2 set id_tes=?d2,tit_eva=?d3,obs_eva=?d4,fec_ini=?d5,fec_fin=?d6,estado=?d7,nom_tes=?d8,nom_est=?d9" +
                        " where id_eva = '" + d1 + "'";
                    break;
                case "3":
                    query = "delete from tes_eva_enc2 where id_eva = '" + d1+ "'";
                    break;
            }
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();

            bool saber = false;

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
            try
            {

                comando.ExecuteNonQuery();
                saber = true;


            }
            catch (Exception ex)
            {
            }
            cone.cerrar();

            if (saber)
            {
                // respuesta verdadera
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                // respuesta falsa
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult vistageneral(List<evaluaciongeneral> items)
        {

            string query3 = "";
            DateTime fecha1 , fecha2;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_eva;
            d2 = items[0].id_tes;
            d3 = items[0].tit_eva;
            d4 = items[0].obs_eva;
            d5 = items[0].fec_ini;
            d6 = items[0].fec_fin;
            d7 = items[0].estado;

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc2 order by id_eva desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_eva_enc2 where id_eva='" + d1 + "' order by id_eva desc";
                    break;


            }
            List<evaluaciongeneral> data = new List<evaluaciongeneral>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    evaluaciongeneral nuevo = new evaluaciongeneral();

                    fecha1 = Convert.ToDateTime(dr["fec_ini"].ToString());
                    nuevo.fec_ini = fecha1.ToString("yyyy-MM-dd");
                    fecha2 = Convert.ToDateTime(dr["fec_fin"].ToString());
                    nuevo.fec_fin = fecha2.ToString("yyyy-MM-dd");
                    nuevo.id_eva = dr["id_eva"].ToString();
                    nuevo.id_tes = dr["id_tes"].ToString();
                    nuevo.tit_eva = dr["tit_eva"].ToString();
                    nuevo.obs_eva = dr["obs_eva"].ToString();
                    nuevo.estado = dr["estado"].ToString();
                    nuevo.nom_tes= dr["nom_tes"].ToString();
                    nuevo.nom_est = dr["nom_est"].ToString();



                    data.Add(nuevo);
                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public class encevaluacion
        {

            public string operacion { get; set; }
            public string id_eva { get; set; }
            public string tip_eva { get; set; }
            public string id_suc { get; set; }
            public string id_are { get; set; }
            public string id_rol { get; set; }
            public string id_col { get; set; }
            public string id_tes { get; set; }
            public string fec_lim { get; set; }
            public string est_cal { get; set; }
            public string est_env { get; set; }
            public string est_act { get; set; }
            public string nom_eva { get; set; }
            public string obs_eva { get; set; }
            public string nom_suc { get; set; }
            public string nom_are { get; set; }
            public string nom_rol { get; set; }
            public string nom_col { get; set; }
            public string nom_tes { get; set; }

        }


        public class evaluaciongeneral
        {

            public string operacion { get; set; }
            public string id_eva { get; set; }
            public string id_tes { get; set; }
            public string tit_eva { get; set; }
            public string obs_eva { get; set; }
            public string fec_ini { get; set; }
            public string fec_fin { get; set; }
            public string estado { get; set; }
            public string nom_tes { get; set; }
            public string nom_est { get; set; }



        }




        public class detevaluacion
        {

            public string operacion { get; set; }
            public string id_eva { get; set; }
            public string id_usu { get; set; }
            public string nom_usu { get; set; }
            public string id_reg { get; set; }

}


    }
}