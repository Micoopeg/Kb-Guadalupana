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
    public partial class VistaEliminar : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        public void mostrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes,t4.sh_nombre,t2.sh_gerencianombre,t3.sh_areanombre from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia inner join sh_area t3 on t1.sh_idarea= t3.id_sharea inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado where t0.sh_estado_id_shestado ='6'";
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
    }
}