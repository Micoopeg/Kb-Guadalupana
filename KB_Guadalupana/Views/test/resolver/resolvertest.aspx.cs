using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.test.resolver
{
    public partial class resolvertest : System.Web.UI.Page
    {


        public static string xx = "";
        public static string sid_col, sid_eva, snom_eva, sobs_eva, snom_col, snom_tes, snom_usu, sid_usu, sfec_lim, sid_tes;
        public static string id_eva, id_tes, tit_eva, fec_fin, obs_eva, nom_tes;
        public static string nombre, nom_usu, nom_are, colaborador;
        public static string idcalificacion = "no";
        public static string evaluadonombre, evaluadousu, evaluadoarea, evaluadoid;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {



                


                string dato = this.Session["sessionString"].ToString();
                string calificador = this.Session["calificadorx"].ToString();
                string evaluado = this.Session["calificado"].ToString();
                string test = this.Session["test"].ToString();
                string evaluacion =this.Session["evaluacion"].ToString();



                // bool respuesta = false;
                xx = this.Session["idusu"].ToString();
                if (dato == "si")
                {

                    Response.Redirect("../../Home/Index");
                }
                else if (dato == "resolver")
                {

                    datosevaluador("2", calificador);
                    datosevaenc("1", evaluacion);
                    datosevaluado("2", evaluado);
                    //return RedirectToAction("Index", "resolver");


                }
                else
                {

                    //return RedirectToAction("index", "Home");
                    Response.Redirect("../Home/Index");
                }


            }
            catch (Exception)
            {
                Response.Redirect("../Home/Index");

            }


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

                    nombre = dr["col_1no"].ToString() + " " + dr["col_1ap"].ToString();
                    nom_usu = dr["nom_usu"].ToString();
                    nom_are = dr["nom_are"].ToString();
                    colaborador = dr["col_id"].ToString();

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
                    query3 = "SELECT * FROM tes_eva_enc2 where estado = '1' and id_eva = '" + quien + "'";
                    break;

                case "2":
                    query3 = "SELECT id_reg,nom_usu, id_cat, col_id, col_1no, col_1ap, nom_are FROM tes_usu_list as t1 join test_col_list" +
                              " as t2 on t1.id_col = t2.col_id where t2.col_id = '" + quien + "'";
                    break;


            }

            KB_Guadalupana.conexion.conexion00 cone = new KB_Guadalupana.conexion.conexion00();
            cone.abrirconexion();
            MySqlCommand comannd = new MySqlCommand(query3, cone.conne1);
            id_eva = "No se pudo cargar la información";
            id_tes = "No se pudo cargar la información";
            tit_eva = "No se pudo cargar la información";
            obs_eva = "No se pudo cargar la información";
            nom_tes = "No se pudo cargar la información";

            try
            {

                MySqlDataReader dr = comannd.ExecuteReader();
                while (dr.Read())
                {

                    id_eva = dr["id_eva"].ToString();
                    id_tes = dr["id_tes"].ToString();
                    tit_eva = dr["tit_eva"].ToString();
                    fecha1 = Convert.ToDateTime(dr["fec_fin"].ToString());
                    fec_fin = fecha1.ToString("yyyy-MM-dd");
                    obs_eva = dr["obs_eva"].ToString();
                    nom_tes = dr["nom_tes"].ToString();
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

                    id_eva = dr["id_eva"].ToString();
                    id_tes = dr["id_tes"].ToString();
                    tit_eva = dr["tit_eva"].ToString();
                    fecha1 = Convert.ToDateTime(dr["fec_fin"].ToString());
                    fec_fin = fecha1.ToString("yyyy-MM-dd");
                    obs_eva = dr["obs_eva"].ToString();
                    nom_tes = dr["nom_tes"].ToString();

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

                    evaluadonombre = dr["col_1no"].ToString() + " " + dr["col_1ap"].ToString();
                    evaluadousu = dr["nom_usu"].ToString();
                    evaluadoarea = dr["nom_are"].ToString();
                    evaluadoid = dr["col_id"].ToString();

                }
            }
            catch (Exception)
            {
            }

            cone.cerrar();

        }



    }
}