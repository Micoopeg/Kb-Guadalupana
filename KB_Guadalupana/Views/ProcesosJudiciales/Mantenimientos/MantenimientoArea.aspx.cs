using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales.Mantenimientos
{
    public partial class MantenimientoArea : System.Web.UI.Page
    {
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ABuscar_Click(object sender, EventArgs e)
        {
            string area = sn.nombrearea(MArea.SelectedValue);
            NombreArea.Value = area;
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if(MArea.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione el área a modificar');", true);
            }
            else
            {
                sn.actualizararea(MArea.SelectedValue, NombreArea.Value);
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Área actualizada');", true);
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {

        }
    }
}