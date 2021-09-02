using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace KB_Guadalupana.Controllers.TEST_SISTEMA
{
    public class administracionController : Controller
    {
        // GET: administracion
        public ActionResult creararea()
        {

            try
            {


                ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
                string dato = ViewData["sessionString"].ToString();
                // bool respuesta = false;

                if (dato == "si")
                {
                    return View("~/Views/administracion/creararea.cshtml");
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("index", "Home");

            }
         

        }
        public ActionResult crearpregunta()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/crearpregunta.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }


        public ActionResult editapregunta()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/editapregunta.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }

        public ActionResult editararea()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/editararea.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        public ActionResult agregarroles()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/agregarroles.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }

        public ActionResult agregarsucursal()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/agregarsucursal.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }

        public ActionResult editarrol()
        {


            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/editarrol.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        public ActionResult editarsucursal()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/administracion/editarsucursal.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }



        [HttpPost]
        public ActionResult operacionesrol(List<roles> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "";
            d0 = items[0].operacion;
            d1 = items[0].rol_nom;
            d2 = items[0].rol_obs;
            d3 = items[0].id_are;
            d4 = items[0].nom_are;
            d5 = items[0].id_rol;
            
            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_rol_list (rol_nom,rol_obs, id_are, nom_are) " +
                "values (?d1, ?d2, ?d3, ?d4)";
                    break;
                case "3":
                    query = "update tes_rol_list set rol_nom = ?d1 ,rol_obs= ?d2 , id_are=?d3, nom_are=?d4 where id_rol  = '" + d5 + "'";
                    break;
                case "4":
                    query = "delete from tes_rol_list where id_rol = '" + d5 + "'";
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
        public ActionResult vistaroles(List<roles> items)
        {

            string query3 ="";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d1 = items[0].rol_nom;
            d2 = items[0].rol_obs;
            d3 = items[0].condicion;
            d4 = items[0].id_rol;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_rol_list order by id_rol desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_rol_list where id_rol ='"+d4+"' order by id_rol desc";
                    break;
                case "10":
                    query3 = "SELECT * FROM bd_seguridad.tes_rol_list where id_are ='" + d3 + "' order by id_rol desc";
                    break;


            }
            List<roles> data = new List<roles>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {


                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    roles nuevo = new roles();

                    nuevo.id_rol = dr["id_rol"].ToString();
                    nuevo.rol_nom = dr["rol_nom"].ToString();
                    nuevo.rol_obs = dr["rol_obs"].ToString();
                    

               

                    data.Add(nuevo);

                }


            }
            catch (Exception )
            {
            }

            cone.cerrar();

            return Json(data, JsonRequestBehavior.AllowGet);

        }




      
     

        [HttpPost]
        public ActionResult datossucursal(List<sucursales> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = ""  ;
            d0 = items[0].operacion;
            d1 = items[0].suc_nom;
            d2 = items[0].suc_dir;
            d3 = items[0].suc_tel;
            d4 = items[0].suc_cor;
            d5 = items[0].id_enc;
            d6 = items[0].id_reg;

            
            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_suc_list order by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_suc_list where id_reg ='" + d6 + "' order by id_reg desc";
                    break;
            }
            List<sucursales> data = new List<sucursales>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    sucursales nuevo = new sucursales();
                    nuevo.suc_nom = dr["suc_nom"].ToString();
                    nuevo.suc_dir = dr["suc_dir"].ToString();
                    nuevo.suc_tel = dr["suc_tel"].ToString();
                    nuevo.suc_cor = dr["suc_cor"].ToString();
                    nuevo.id_enc = dr["id_enc"].ToString();
                    nuevo.id_reg = dr["id_reg"].ToString();
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
        public ActionResult operacionsucursal(List<sucursales> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "";
            d0 = items[0].operacion;
            d1 = items[0].suc_nom;
            d2 = items[0].suc_dir;
            d3 = items[0].suc_tel;
            d4 = items[0].suc_cor;
            d5 = items[0].id_enc;
            d6 = items[0].id_reg;

            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_suc_list (suc_nom,suc_dir,suc_tel,suc_cor,id_enc) " +
                "values (?d1, ?d2, ?d3, ?d4, ?d5)";
                    break;
                case "3":
                    query = "update tes_suc_list set suc_nom= ?d1,suc_dir= ?d2,suc_tel= ?d3,suc_cor= ?d4,id_enc= ?d5" +
                        " where id_reg  = '" + d6 + "'";
                    break;
                case "4":
                    query = "delete from tes_suc_list where id_reg = '" + d6 + "'";
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
        public ActionResult datosarea(List<area> items)
        {

            string query3 = "";
            string d0 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d2 = items[0].nom_are;
            d3 = items[0].obs_are;
            d4 = items[0].id_reg;

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_are_lis order by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_are_lis where id_reg ='" + d4 + "' order by id_reg desc";
                    break;
            }
            List<area> data = new List<area>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    area nuevo = new area();
                    nuevo.nom_are = dr["nom_are"].ToString();
                    nuevo.obs_are = dr["obs_are"].ToString();
                    nuevo.id_reg = dr["id_reg"].ToString();
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
        public ActionResult operacionesarea(List<area> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "";
            d0 = items[0].operacion;
            d2 = items[0].nom_are;
            d3 = items[0].obs_are;
            d4 = items[0].id_reg;
            string query = "";
            switch (d0)
            {

                case "1":
                    query = "update tes_are_lis set nom_are ='"+d2+"', obs_are ='"+d3+"' where id_reg = '"+d4+"'";
                    break;
                case "2":
                    query = "delete from tes_are_lis where id_reg = '" + d4 + "'";
                    break;
                case "7":
                    query = "insert into tes_are_lis  (nom_are, obs_are) values (?d2,?d3)";
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
                return Json(new { success = false, ex = "something was invalid" }, JsonRequestBehavior.AllowGet);

            }


        }



      

        [HttpPost]
        public ActionResult operacionpregunta(List<pregunta> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "";
            d0 = items[0].operacion;
            d1 = items[0].pre_tit;
            d2 = items[0].pre_pun;
            d3 = items[0].id_preg;
            

            string fecha = "";
            fecha = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            

            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_pre_list (pre_tit,pre_pun) " +
                "values (?d1, ?d2)";
                    break;
                case "3":
                    query = "update tes_pre_list set pre_tit=?d1,pre_pun=?d2" +
                        " where id_pre = '" + d3 + "'";
                    break;
                case "4":
                    query = "delete from tes_pre_list where id_pre = '" + d3 + "'";
                    break;
            }
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();

            bool saber = false;

            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);

            comando.Parameters.AddWithValue("?d1", d1);
            comando.Parameters.AddWithValue("?d2", d2);
            comando.Parameters.AddWithValue("?d3", d3);
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
        public ActionResult vistapregunta(List<pregunta> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "";
            d0 = items[0].operacion;
            d1 = items[0].pre_tit;
            d2 = items[0].pre_pun;
            d3 = items[0].id_preg;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_pre_list order by id_pre desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_pre_list where  id_pre= '" + d3 + "' order by id_pre desc";
                    break;


            }
            List<pregunta> data = new List<pregunta>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    pregunta nuevo = new pregunta();
                    nuevo.pre_tit = dr["pre_tit"].ToString();
                    nuevo.pre_pun = dr["pre_pun"].ToString();
                    nuevo.id_preg = dr["id_pre"].ToString();
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
        public ActionResult operacionrespuesta(List<respuesta> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_pre;
            d2 = items[0].res_nom;
            d3 = items[0].id_reg;


            string fecha = "";
            fecha = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;


            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_res_list (id_pre,res_nom) " +
                "values (?d1, ?d2)";
                    break;
                case "3":
                    query = "update tes_res_list set id_pre=?d1, res_nom=?d2 where id_reg =?d3  ";
                    break;
                case "4":
                    query = "delete from tes_res_list where id_reg= '" + d3 + "'";
                    break;
            }
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();

            bool saber = false;
            
            cone.abrirconexion();
            MySqlCommand comando = new MySqlCommand(query, cone.conne1);

            comando.Parameters.AddWithValue("?d1", d1);
            comando.Parameters.AddWithValue("?d2", d2);
            comando.Parameters.AddWithValue("?d3", d3);
            try
            {
                comando.ExecuteNonQuery();
                saber = true;
            }
            catch (Exception)
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
        public ActionResult vistarespuesta(List<respuesta> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_pre;
            d2 = items[0].res_nom;
            d3 = items[0].id_reg;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_res_list order by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_res_list where  id_pre= '" + d1 + "' order by id_reg desc";
                    break;


            }
            List<respuesta> data = new List<respuesta>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            DateTime sfecha = DateTime.Now;
            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    respuesta nuevo = new respuesta();
                    nuevo.id_reg = dr["id_reg"].ToString();
                    nuevo.id_pre = dr["id_pre"].ToString();
                    nuevo.res_nom = dr["res_nom"].ToString();
                    nuevo.res_cor = dr["res_cor"].ToString();
                    data.Add(nuevo);

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public class area
        {
            public string id_reg { get; set; }
            public string nom_are { get; set; }
            public string obs_are { get; set; }
            public string operacion { get; set; }

        }


        public class pregunta
        {
            public string id_preg { get; set; }
       
            public string pre_tit { get; set; }
            public string pre_pun { get; set; }
        

            public string operacion { get; set; }


        }

       

        public class respuesta
        {
            public string id_reg { get; set; }
            public string id_pre { get; set; }
            public string res_nom { get; set; }
            public string res_cor { get; set; }
            public string operacion { get; set; }


        }


        public class roles
        {
            public string operacion { get; set; }
            public string id_rol { get; set; }
            public string rol_nom { get; set; }
            public string rol_obs { get; set; }
            public string id_are { get; set; }
            public string nom_are { get; set; }
            public string condicion { get; set; }


        }


        public class sucursales
        {
            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string suc_cod { get; set; }
            public string suc_nom { get; set; }
            public string suc_dir { get; set; }
            public string suc_tel { get; set; }
            public string suc_cor { get; set; }
            public string id_enc { get; set; }

        }


    }
}