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
                    string QueryString = "SELECT a.codshrespuestaasignacion,c.sh_rubro,c.sh_mes,d.sh_gerencianombre,e.sh_areanombre,f.sh_nombre FROM sh_respuesta_asignacion a INNER JOIN sh_asignacion b ON a.codshasignacion=b.id_shasignacion INNER JOIN sh_hallazgo c ON b.sh_hallazgo_id_shhallazgo=c.id_shhallazgo INNER JOIN sh_gerencias d ON b.sh_gerencias_id_shgerencia=d.id_shgerencia INNER JOIN sh_area e ON b.sh_idarea=e.id_sharea INNER JOIN sh_estado f on a.sh_estatus=f.id_shestado WHERE a.sh_estatus='6'";                    
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