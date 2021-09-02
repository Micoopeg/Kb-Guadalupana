using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace borrar01.Controllers
{
    
    public class usuarioController : Controller
    {
        // GET: usuario

        public ActionResult registrocolaborador()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/usuario/registrocolaborador.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }



        }


        public ActionResult prueba()
        {

           
                return View();
           


        }


        public ActionResult vistageneral()
        {
            
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/usuario/vistageneral.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }

        public ActionResult agregarusuario()
        {
            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/usuario/agregarusuario.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }


        public ActionResult editarcolaborador()
        {


            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/usuario/editarcolaborador.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }


        }
        public ActionResult editarusuario()
        {



            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
              
                return View("~/Views/usuario/editarusuario.cshtml");
                
            }
            else
            {
                return RedirectToAction("index", "Home");
            }




        }


        public ActionResult vistausuarios()
        {

            ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String;
            string dato = ViewData["sessionString"].ToString();
            // bool respuesta = false;

            if (dato == "si")
            {
                return View("~/Views/usuario/vistausuarios.cshtml");
            }
            else
            {
                return RedirectToAction("index", "Home");
            }


        }



        [HttpPost]
        public ActionResult operacioncolaborador(List<colaboradores> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "", d11 = "", d12 = "", d13 = "", d14 = "", d15 = "", d16 = "";
          

            d0 = items[0].operacion;
            d1 = items[0].col_dpi;
            d2 = items[0].col_cif;
            d3 = items[0].col_1no;
            d4 = items[0].col_2no;
            d5 = items[0].col_1ap;
            d6 = items[0].col_2ap;
            d7 = items[0].col_tel;
            d8 = items[0].col_ema;
            d9 = items[0].col_nac;
            d10 = items[0].id_are;
            d11 = items[0].id_suc;
            d12 = items[0].id_rol;
            d13 = items[0].nom_are;
            d14 = items[0].nom_suc;
            d15 = items[0].nom_rol;
            d16 = items[0].col_id;

            string query = "";

            switch (d0)
            {
                 
                case "1":
                    query = "insert into test_col_list (col_dpi,col_cif,col_1no,col_2no,col_1ap,col_2ap,col_tel,col_ema,col_nac,id_are,id_suc,id_rol,nom_are,nom_suc,nom_rol) " +
                "values (?d1, ?d2,?d3,?d4,?d5,?d6,?d7,?d8,?d9,?d10,?d11,?d12,?d13,?d14,?d15)";
                    break;
                case "3":
                    query = "update test_col_list set col_dpi=?d1,col_cif=?d2,col_1no=?d3,col_2no=?d4,col_1ap=?d5,col_2ap=?d6,col_tel=?d7,col_ema=?d8,col_nac=?d9,id_are=?d10"+
                        ",id_suc=?d11,id_rol=?d12,nom_are=?d13,nom_suc=?d14,nom_rol=?d15 "+
                        "where col_id=?d16";
                    break;
                case "4":
                    query = "delete from test_col_list where col_id = '" + d16 + "'";
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


            try
            {
                comando.ExecuteNonQuery();
                saber = true;
            }
            catch (Exception es )
            {}
            cone.cerrar();

            if (saber)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, ex = "something was invalid" }, JsonRequestBehavior.AllowGet);

            }
        }



        [HttpPost]
        public ActionResult vistacolaboador(List<colaboradores> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "", d8 = "", d9 = "", d10 = "", d11 = "", d12 = "", d13 = "", d14 = "", d15 = "", d16 = "";

            d0 = items[0].operacion;
            d1 = items[0].col_dpi;
            d2 = items[0].col_cif;
            d3 = items[0].col_1no;
            d4 = items[0].col_2no;
            d5 = items[0].col_1ap;
            d6 = items[0].col_2ap;
            d7 = items[0].col_tel;
            d8 = items[0].col_ema;
            d9 = items[0].col_nac;
            d10 = items[0].id_are;
            d11 = items[0].id_suc;
            d12 = items[0].id_rol;
            d13 = items[0].nom_are;
            d14 = items[0].nom_suc;
            d15 = items[0].nom_rol;
            d16 = items[0].col_id;



            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM test_col_list order by col_1no";
                    break;

                case "2":
                    query3 = "SELECT * FROM test_col_list where col_id='" + d16 + "' order by col_1no";
                    break;
                case "10":
                    query3 = "select * from test_col_list where id_are = '" + d10 + "' order by col_1no";
                    break;


            }
            List<colaboradores> data = new List<colaboradores>();
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {


                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    colaboradores nuevo = new colaboradores();
                    nuevo.col_dpi = dr["col_dpi"].ToString();
                    nuevo.col_cif = dr["col_cif"].ToString();
                    nuevo.col_1no = dr["col_1no"].ToString();
                    nuevo.col_2no = dr["col_2no"].ToString();
                    nuevo.col_1ap = dr["col_1ap"].ToString();
                    nuevo.col_2ap = dr["col_2ap"].ToString();
                    nuevo.col_tel = dr["col_tel"].ToString();
                    nuevo.col_ema = dr["col_ema"].ToString();
                    nuevo.col_nac = dr["col_nac"].ToString();
                    nuevo.col_id = dr["col_id"].ToString();

                    nuevo.nom_are = dr["nom_are"].ToString();
                    nuevo.nom_suc = dr["nom_suc"].ToString();
                    nuevo.nom_rol = dr["nom_rol"].ToString();
                    nuevo.id_are = dr["id_are"].ToString();
                    nuevo.id_suc = dr["id_suc"].ToString();
                    nuevo.id_rol = dr["id_rol"].ToString();
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
        public ActionResult operacionusuario(List<usuario> items)
        {
            var resultado = items;
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "";

            d0 = items[0].operacion;
            d1 = items[0].id_col;
            d2 = items[0].nom_usu;
            d3 = items[0].usu_pas;
            d4 = items[0].usu_cpa;
            d5 = items[0].id_cat;
            d6 = items[0].nom_cat;
            d7 = items[0].id_reg;



            string query = "";

            switch (d0)
            {

                case "1":
                    query = "insert into tes_usu_list (id_col,nom_usu,usu_pas,usu_cpa,id_cat,nom_cat) " +
                "values (?d1, ?d2,?d3,?d4,?d5,?d6)";
                    break;
                case "2":
                    query = "update tes_usu_list set nom_usu=?d2,usu_pas=?d3,usu_cpa=?d4,id_cat=?d5,nom_cat=?d6" +
                        " where id_reg = '" + d7 + "'";
                    break;
                case "3":
                    query = "delete from tes_usu_list where id_reg = '" + d7 + "'";
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
        public ActionResult vistausuarios(List<usuario> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "", d3 = "", d4 = "", d5 = "", d6 = "", d7 = "";

            d0 = items[0].operacion;
            d1 = items[0].id_col;
            d2 = items[0].nom_usu;
            d3 = items[0].usu_pas;
            d4 = items[0].usu_cpa;
            d5 = items[0].id_cat;
            d6 = items[0].nom_cat;
            d7 = items[0].id_reg;



            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_usu_list order by id_reg desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_usu_list where id_reg='"+d7+"' order by id_reg desc";
                    break;
                case "10":
                    query3 = "select * from tes_usu_list where id_are = '"+d7+"'";
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
                    usuario nuevo = new usuario();
                    nuevo.id_reg = dr["id_reg"].ToString();
                    nuevo.id_col = dr["id_col"].ToString();
                    nuevo.nom_usu = dr["nom_usu"].ToString();
                    nuevo.nom_cat = dr["nom_cat"].ToString();
                    nuevo.id_cat= dr["id_cat"].ToString();
                    nuevo.usu_pas= dr["usu_pas"].ToString();
                    nuevo.usu_cpa = dr["usu_cpa"].ToString();
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
        public ActionResult vistatipus(List<catusuario> items)
        {

            string query3 = "";
            string d0 = "", d1 = "", d2 = "";
            d0 = items[0].operacion;
            d1 = items[0].id_cat;
            d2 = items[0].cat_nom;


            switch (d0)
            {
                case "1":
                    query3 = "SELECT * FROM tes_cat_usu order by id_cat desc";
                    break;

                case "2":
                    query3 = "SELECT * FROM tes_cat_usu order by id_cat desc";
                    break;
                case "10":
                    query3 = "select * from tes_cat_usu where id_cat = '" + d1 + "'";
                    break;


            }
            List<catusuario> data = new List<catusuario>();
            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);


            try
            {


                MySqlDataReader dr = comannd.ExecuteReader();

                while (dr.Read())
                {
                    catusuario nuevo = new catusuario();

                    nuevo.id_cat = dr["id_cat"].ToString();
                    nuevo.cat_nom = dr["cat_nom"].ToString();
                    data.Add(nuevo);
                }
            }
            catch (Exception) { }

            cone.cerrar();

            return Json(data, JsonRequestBehavior.AllowGet);

        }










        public class colaboradores
        {
         
            public string operacion { get; set; }
            public string col_id { get; set; }
            public string col_dpi { get; set; }
            public string col_cif { get; set; } 
            public string col_1no { get; set; }
            public string col_2no { get; set; }
            public string col_1ap { get; set; }
            public string col_2ap { get; set; }
            public string col_tel { get; set; }
            public string col_ema { get; set; }
            public string col_nac { get; set; }
            public string nom_are { get; set; }
            public string nom_suc { get; set; }

            public string nom_rol { get; set; }
            public string id_are { get; set; }
            public string id_suc { get; set; }
            public string id_rol { get; set; }

        }




        public class usuario
        {

            public string operacion { get; set; }
            public string id_reg { get; set; }
            public string id_col { get; set; }
            public string nom_usu { get; set; }
            public string usu_pas { get; set; }
            public string usu_cpa { get; set; }
            public string id_cat { get; set; }
            public string nom_cat { get; set; }
          


        }



        public class catusuario
        {

            public string operacion { get; set; }
            public string id_cat { get; set; }
            public string cat_nom { get; set; }
         
        }

    }
}