using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace KB_Guadalupana.Controllers
{
    public class HomeController : Controller
    {
        
        //public ActionResult Index()
        //{
        //    System.Web.HttpContext.Current.Session["sessionString"] = "no";
        //    System.Web.HttpContext.Current.Session["idusu"] = "";
        //    return View();
        //}

        public ActionResult inicio()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato=="si")
            {
                return View("~/Views/Home/inicio.cshtml");
            }
            else if(dato=="resolver")
            {
                 return RedirectToAction("Index", "resolver");
                
            }
            else
            {

                return RedirectToAction("index", "Home");
            }
            

            
            
        }


        [HttpPost]
        public ActionResult vistausuario(List<usuario> items)
        {

         

            bool saber = false;
            string query3 = "";
            string categoria = "";
            string idcol = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_col;
            d2 = items[0].nom_usu;
            d3 = items[0].id_are;
            d4 = items[0].id_suc;
            d5 = items[0].id_rol;
            d6 = items[0].usu_pas;
            d7 = items[0].usu_cpa;
            d9 = items[0].id_cat;
            d8 = items[0].id_reg;

            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_eva_enc order by id_eva desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_usu_list where nom_usu='"+d2+"' and usu_pas ='"+d6+"'";
                    break;


            }
            List<usuario> data = new List<usuario>();
              KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {
                    saber = true;
                  

                    categoria= dr["id_cat"].ToString();
                    idcol = dr["id_col"].ToString();



                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();
            if (saber)
            {
                // respuesta verdadera
                if(categoria=="1")
                {
                    System.Web.HttpContext.Current.Session["sessionString"] = "si";
                    
                }
               
                else
                {
                    System.Web.HttpContext.Current.Session["sessionString"] = "resolver";

                }
                System.Web.HttpContext.Current.Session["idusu"] = idcol;

                //return View("~/Views/Home/inicio.cshtml");
                // respuesta verdadera
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                // respuesta falsa
                return Json(new { success = false, ex = "Operacion invalida" }, JsonRequestBehavior.AllowGet);

            }

        }

        public class usuario
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_col { get; set; }
            public string nom_usu { get; set; }
            public string id_are { get; set; }
            public string id_suc { get; set; }
            public string id_rol { get; set; }
            public string usu_pas { get; set; }
            public string usu_cpa { get; set; }
            public string id_cat { get; set; }
        }


        public ActionResult validar()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            if (dato == "si")
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else if (dato == "resolver")
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, ex = "Inicie sesión." }, JsonRequestBehavior.AllowGet);
            }

        }

    




    }
}