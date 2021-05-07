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
    public partial class EditarArea : System.Web.UI.Page
    {

        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        string idgerencia, idguardar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrar();
            }
        }

        public void mostrar()
        {
            idgerencia = Session["IdArea"].ToString();
            ID.Value = idgerencia;

            string[] var1 = sen.consultarArea(idgerencia);

            Gerencian.Value = Convert.ToString(var1[1]);

        }

        protected void GuardarGerencia_Click(object sender, EventArgs e)
        {

            idgerencia = Session["IdArea"].ToString();

            string[] campos = { "id_sharea", "	sh_areanombre" };
            string[] valores = { idgerencia, Gerencian.Value };
            try
            {
                logic.modificartablas("sh_area", campos, valores);
            }
            catch
            { }
            finally
            {
                try
                {
                    cn.desconectar();
                }
                catch
                { }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Area Actualizada'); window.location.href= 'MantenimientoGerencias.aspx';", true);
        }
    }
}