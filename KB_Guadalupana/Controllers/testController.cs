using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace borrar01.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult creaciontest()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/test/creaciontest.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }


        }

        public ActionResult vistageneral()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/test/vistageneral.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }


        }


        public ActionResult editar()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/test/editar.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }


   



        [HttpPost]

        public ActionResult lpreguntas()
        {

            List<lpregunta> data = new List<lpregunta>();
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            string query3 = "SELECT * FROM tes_pre_list ";
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    lpregunta nuevo = new lpregunta();

                    nuevo.Id_pre = dr["id_pre"].ToString();
                    nuevo.Pre_tit = dr["pre_tit"].ToString();
                    data.Add(nuevo);

                }

            }
            catch (Exception )
            {
            }
            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);


        }



        private bool eliminargeneral(string cadena)
        {

            bool valor = false;
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(cadena, cone.conne1);

            try
            {
                comando.ExecuteNonQuery();
                valor = true;

            }
            catch (Exception)
            {

            }
            return valor;

        }
        private bool eliminardetalle(string cuando, string tabla, string criterio)
        {

            bool valor = false;
            string query = "";
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            string query3 = "select * from "+tabla+" where "+cuando+" ='" + criterio+"'";
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {
                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    valor = true;
                    query = "delete from " + tabla + " where id_reg ='"+ dr["id_reg"].ToString() +"'";
                    eliminargeneral(query);

                }


            }
            catch (Exception)
            {
            }
            cone.cerrar();

            return valor;

        }


        [HttpPost]
        public ActionResult operaciontest(List<Test> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "";
            d0 = items[0].operacion;
            d1 = items[0].nom_tes;
            d2 = items[0].obs_tes;
            d3 = items[0].fec_cre;
            d4 = items[0].fec_mod;
            d5 = items[0].id_tes;

            string fecha = "";
            fecha = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            d3 = fecha;

            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_enc_tes (nom_tes,obs_tes, fec_cre) " +
                "values (?d1, ?d2, ?d3)";
                    break;
                case "3":
                    query = "update tes_enc_tes set nom_tes=?d1,obs_tes=?d2,fec_mod=?d3" +
                        " where id_tes = '" + d5 + "'";
                    break;
                case "4":
                    query = "delete from tes_enc_tes where id_tes = '" + d5 + "'";
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

            try
            {  comando.ExecuteNonQuery(); saber = true; }
            catch (Exception) {}
            cone.cerrar();

            if (saber)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public ActionResult vistastest(List<Test> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "";
            d0 = items[0].operacion;
            d1 = items[0].nom_tes;
            d2 = items[0].obs_tes;
            d3 = items[0].fec_cre;
            d4 = items[0].fec_mod;
            d5 = items[0].id_tes;

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_enc_tes order by id_tes desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_enc_tes where id_tes= '" + d5+ "' order by id_tes desc";
                    break;
            }
            List<Test> data = new List<Test>();
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    Test nuevo = new Test();
                    nuevo.nom_tes = dr["nom_tes"].ToString();
                    nuevo.obs_tes = dr["obs_tes"].ToString();
                    nuevo.fec_cre = dr["fec_cre"].ToString();
                    nuevo.fec_mod = dr["fec_mod"].ToString();
                    nuevo.id_tes = dr["id_tes"].ToString();

                    data.Add(nuevo);

                }
            }
            catch (Exception){}

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult operaciontestd(List<Testdetalle> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_tes;
            d2 = items[0].pre_tes;
            d3 = items[0].pun_tes;
            d4 = items[0].obs_tes;
            d5 = items[0].id_pre;
            d6 = items[0].id_reg;

            string fecha = "";
            fecha = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            

            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_det_tes (id_tes,pre_tes,pun_tes,obs_tes,id_pre) " +
                "values (?d1, ?d2, ?d3, ?d4, ?d5)";
                    break;
                case "3":
                    query = "update tes_det_tes set nom_tes=?d1,obs_tes=?d2,fec_mod=?d3" +
                        " where id_reg = '" + d6 + "'";
                    break;
                case "4":
                    query = "delete from tes_det_tes where id_reg = '" + d6 + "'";
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

            try
            { comando.ExecuteNonQuery(); saber = true; }
            catch (Exception) { }
            cone.cerrar();

            if (saber)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public ActionResult vistastestd(List<Testdetalle> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_tes;
            d2 = items[0].pre_tes;
            d3 = items[0].pun_tes;
            d4 = items[0].obs_tes;
            d5 = items[0].id_pre;
            d6 = items[0].id_reg;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_det_tes order by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_det_tes where id_tes= '" + d1 + "' order by id_reg desc";
                    break;
            }
            List<Testdetalle> data = new List<Testdetalle>();
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    Testdetalle nuevo = new Testdetalle();
                    nuevo.id_tes = dr["id_tes"].ToString();
                    nuevo.pre_tes = dr["pre_tes"].ToString();
                    nuevo.pun_tes = dr["pun_tes"].ToString();
                    nuevo.obs_tes = dr["obs_tes"].ToString();
                    nuevo.id_pre = dr["id_pre"].ToString();
                    nuevo.id_reg = dr["id_reg"].ToString();

                    data.Add(nuevo);

                }
            }
            catch (Exception) { }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public class Test
        {
            public string id_tes { get; set; }
            public string nom_tes { get; set; }
            public string obs_tes { get; set; }
            public string fec_cre { get; set; }
            public string fec_mod { get; set; }

            public string operacion { get; set; }

        }

        public class Testdetalle
        {

            public string id_reg { get; set; }
            public string id_tes { get; set; }
            public string pre_tes { get; set; }
            public string pun_tes { get; set; }
            public string obs_tes { get; set; }
            public string id_pre { get; set; }
            public string operacion { get; set; }

        }




        public class pregunta
        {
            public string id_reg { get; set; }
            public string id_tes { get; set; }
            public string pre_tes { get; set; }
            public string pun_tes { get; set; }
            public string obs_tes { get; set; }
            public string id_pre { get; set; }


        }


        public class lpregunta
        {
            
            public string Id_pre { get; set; }
            public string Pre_tit { get; set; }


        }



    }
}