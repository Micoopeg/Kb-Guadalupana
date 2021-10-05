using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.ProcesosJudiciales
{
    public partial class ControlIncidente : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Sentencia_juridico sn = new Sentencia_juridico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewbitacora();
                llenarcombofecha();
            }
        }

        public void llenargridviewbitacora()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT DISTINCT(idpj_incidente), pj_numcredito, pj_nombre, pj_fechacreacion, DATEDIFF(now(), pj_fechacreacion) AS Dias FROM pj_bitacora";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIncidente.DataSource = dt;
                    gridViewIncidente.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void OnSelectedIndexChangedIncidente(object sender, EventArgs e)
        {
            string numcredito = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblnumcredito") as Label).Text);
            Session["credito"] = numcredito;
            Response.Redirect("Bitacora.aspx");
        }

        public void llenarcombofecha()
        {
            OrdenarFecha.Items.Insert(0, new ListItem("[Formato]", "0"));
            OrdenarFecha.Items.Insert(1, new ListItem("Ascendente", "1"));
            OrdenarFecha.Items.Insert(2, new ListItem("Descendente", "2"));
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            if(OrdenarFecha.SelectedValue == "1")
            {
                llenarbitacoraascendente();
            }
            else if(OrdenarFecha.SelectedValue == "2")
            {
                llenarbitacoradescendente();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Seleccione la forma de ordenar');", true);
            }
        }

        public void llenarbitacoraascendente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_incidente, pj_numcredito, pj_nombre, pj_fechacreacion, DATEDIFF(now(), pj_fechacreacion) AS Dias FROM pj_bitacora GROUP BY pj_numcredito ORDER BY pj_fechacreacion ASC";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIncidente.DataSource = dt;
                    gridViewIncidente.DataBind();
                }
                catch
                {

                }
            }
        }

        public void llenarbitacoradescendente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_incidente, pj_numcredito, pj_nombre, pj_fechacreacion, DATEDIFF(now(), pj_fechacreacion) AS Dias FROM pj_bitacora GROUP BY pj_numcredito ORDER BY pj_fechacreacion DESC";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIncidente.DataSource = dt;
                    gridViewIncidente.DataBind();
                }
                catch
                {

                }
            }
        }

        public void llenarbitacoracondicion(string condicion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string query = "SELECT idpj_incidente, pj_numcredito, pj_nombre, pj_fechacreacion, DATEDIFF(now(), pj_fechacreacion) AS Dias FROM pj_bitacora "+condicion+ " GROUP BY idpj_incidente,pj_numcredito,pj_nombre,pj_fechacreacion ORDER BY pj_fechacreacion ASC";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    gridViewIncidente.DataSource = dt;
                    gridViewIncidente.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void Buscar2_Click(object sender, EventArgs e)
        {
            if(NumCredito.Value != "" && NumProceso.Value != "" && Nombres.Value != "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND idpj_incidente = '"+NumProceso.Value+ "' AND pj_nombre LIKE '%"+Apellidos.Value.ToUpper()+","+Nombres.Value.ToUpper()+"%'";
                llenarbitacoracondicion(condicion);
                if(gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value != "" && Nombres.Value != "" && Apellidos.Value == "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND idpj_incidente = '" + NumProceso.Value + "' AND pj_nombre LIKE '%" + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value != "" && Nombres.Value == "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND idpj_incidente = '" + NumProceso.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value == "" && Nombres.Value != "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "," + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value != "" && Nombres.Value != "" && Apellidos.Value != "")
            {
                string condicion = "WHERE idpj_incidente = '" + NumProceso.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "," + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value != "" && Nombres.Value == "" && Apellidos.Value == "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND idpj_incidente = '" + NumProceso.Value + "'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value == "" && Nombres.Value == "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value == "" && Nombres.Value != "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "," + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value != "" && Nombres.Value != "" && Apellidos.Value == "")
            {
                string condicion = "WHERE idpj_incidente = '" + NumProceso.Value + "' AND pj_nombre LIKE '%" + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value == "" && Nombres.Value == "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value == "" && Nombres.Value != "" && Apellidos.Value == "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "' AND pj_nombre LIKE '%" + Nombres.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value != "" && Nombres.Value == "" && Apellidos.Value != "")
            {
                string condicion = "WHERE idpj_incidente = '" + NumProceso.Value + "' AND pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value != "" && NumProceso.Value == "" && Nombres.Value == "" && Apellidos.Value == "")
            {
                string condicion = "WHERE pj_numcredito = '" + NumCredito.Value + "'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value == "" && Nombres.Value == "" && Apellidos.Value != "")
            {
                string condicion = "WHERE pj_nombre LIKE '%" + Apellidos.Value.ToUpper() + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value != "" && Nombres.Value == "" && Apellidos.Value == "")
            {
                string condicion = "WHERE idpj_incidente LIKE '%" + NumProceso.Value + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else if (NumCredito.Value == "" && NumProceso.Value == "" && Nombres.Value != "" && Apellidos.Value == "")
            {
                string condicion = "WHERE pj_nombre LIKE '%" + Nombres.Value + "%'";
                llenarbitacoracondicion(condicion);
                if (gridViewIncidente.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se ha encontrado información con esos datos');", true);
                    llenargridviewbitacora();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Debe ingresar al menos un dato');", true);
            }
        }

        protected void VerTodos_Click(object sender, EventArgs e)
        {
            llenargridviewbitacora();
        }

        protected void gridViewIncidente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string estado = Convert.ToString((gridViewIncidente.SelectedRow.FindControl("lblestado") as Label).Text);
                string _estado = DataBinder.Eval(e.Row.DataItem, "pj_nombre").ToString();
                string _credito = DataBinder.Eval(e.Row.DataItem, "pj_numcredito").ToString();
                string[] datos = sn.obtenerdatosbitacora(_credito, sn.ultimabitacora(_credito));
                string area = datos[2];
                int dias = Convert.ToInt32(datos[3]);

                if (area == "ABOGADO EXTERNO" && dias > 50)
                {
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
                else
                    e.Row.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }
}