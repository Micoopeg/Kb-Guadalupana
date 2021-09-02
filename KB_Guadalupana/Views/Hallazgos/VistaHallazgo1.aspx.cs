using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class VistaHallazgo1 : System.Web.UI.Page
    {

        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        string trimestre, año, gerencia, area1, area2;
        string idguardar;
        bool val;



        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewreporte();
        }

        public void llenargridviewreporte()
        {
            trimestre = Session["MesUsuario1"].ToString();
            año = Session["AñoUsuario1"].ToString();

            area1 = Session["AreaUsuario2"].ToString();
            area2 = Session["AreaUsuario1"].ToString();


            if ((area1 == null) || (area1 == ""))
            {
                val = true;
            }
            gerencia = Session["GerenciaUsuario1"].ToString();

            if (val == false)
            {
                if (gerencia != null)
                {
                    string[] var2 = sen.consultarAreasGerencia(area1);
                    string valor1 = Convert.ToString(var2[0]);

                    mostrar1(valor1);
                }
                else
                {
                    mostrar();
                }
            }
            else
            {
                string[] var2 = sen.consultarAreasGerencia1(area2);
                string valor1 = Convert.ToString(var2[0]);
                string valor11 = Convert.ToString(var2[1]);

                mostrar2(valor1, valor11);
            }
        }

        public void mostrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    //string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes,t4.sh_nombre,t2.sh_gerencianombre,t3.sh_areanombre " +
                    //       "from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo " +
                    //       "inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia " +
                    //       "inner join sh_area t3 on t1.sh_idarea= t3.id_sharea " +
                    //       "inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado " +
                    //       "where t0.sh_mes='" + trimestre + "' and t0.sh_año='" + año + "' and t1.sh_gerencias_id_shgerencia='" + gerencia + "' and t1.sh_idarea='" + area1 + "' and t4.id_shestado!='6'";
                    string QueryString = "SELECT a.codshrespuestaasignacion,c.sh_rubro,c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,f.sh_nombre FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='" + trimestre + "' AND c.sh_año='" + año + "' AND b.sh_gerencias_id_shgerencia='" + gerencia + "' AND b.sh_idarea='" + area1 + "' AND a.sh_estatus!=6;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporteH.DataSource = ds3;
                    GridViewReporteH.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrar1(string valor)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    //string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes," +
                    //    "t4.sh_nombre,t2.sh_gerencianombre,t3.sh_areanombre " +
                    //    "from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo " +
                    //    "inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia " +
                    //    "inner join sh_area t3 on t1.sh_idarea= t3.id_sharea " +
                    //    "inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado " +
                    //    "where t0.sh_mes='"+trimestre+"' and t0.sh_año='"+año+"' and t1.sh_gerencias_id_shgerencia='"+gerencia+"' " +
                    //    "and t1.sh_idarea='"+area1+"' and t4.id_shestado!='6'";
                    string QueryString = "SELECT a.codshrespuestaasignacion,c.sh_rubro,c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,f.sh_nombre FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='" + trimestre + "' AND c.sh_año='" + año + "' AND b.sh_gerencias_id_shgerencia='" + gerencia + "' AND b.sh_idarea='" + area1 + "' AND a.sh_estatus!=6;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporteH.DataSource = ds3;
                    GridViewReporteH.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrar2(string valor, string areasa)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "SELECT a.codshrespuestaasignacion,c.sh_rubro,c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,f.sh_nombre FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE c.sh_mes='"+trimestre+"' AND c.sh_año='"+año+"' AND b.sh_gerencias_id_shgerencia='"+valor+"' AND b.sh_idarea='"+areasa+"' AND a.sh_estatus!=6;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporteH.DataSource = ds3;
                    GridViewReporteH.DataBind();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        protected void OnSelectedIndexChangedReporte(object sender, EventArgs e)
        {
            string val1, val2;



            GridViewRow row = GridViewReporteH.SelectedRow;
            idguardar = Convert.ToString((GridViewReporteH.SelectedRow.FindControl("idhallazgo") as Label).Text);

            Session["Idguardarse"] = idguardar;
            Response.Redirect("RespuestaHallazgo.aspx");
        }
    }
}