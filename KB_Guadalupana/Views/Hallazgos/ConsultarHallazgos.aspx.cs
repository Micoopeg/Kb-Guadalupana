using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class ConsultarHallazgos : System.Web.UI.Page
    {

        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarNS();
            Mostrarproceso();
            MostrarSol();
            MostrarNuevos();
            MostrarTtotal();
            MostrarEliminados();
            Mostrarparcial();
            Mostrarnosolucionado();
            if (!IsPostBack)
            {
                llenarcombosucursal();
                llenarcomboestado();
            }
        }

        public void MostrarNS()
        {
            string[] var1 = sen.consultarTotal1();
            for (int i = 0; i < var1.Length; i++)
            {
                noini.Value = Convert.ToString(var1[0]);

            }
        }

        public void Mostrarproceso()
        {
            string[] var1 = sen.consultarTotal2();
            for (int i = 0; i < var1.Length; i++)
            {
                ini.Value = Convert.ToString(var1[0]);

            }
        }

        public void MostrarSol()
        {
            string[] var1 = sen.consultarTotal3();
            for (int i = 0; i < var1.Length; i++)
            {
                ter.Value = Convert.ToString(var1[0]);

            }
        }

        public void MostrarNuevos()
        {
            string[] var1 = sen.consultarTotal4();
            for (int i = 0; i < var1.Length; i++)
            {
                Text1.Value = Convert.ToString(var1[0]);

            }
        }

        public void MostrarTtotal()
        {
            string[] var1 = sen.consultarTotal5();
            for (int i = 0; i < var1.Length; i++)
            {
                Totales.Value = Convert.ToString(var1[0]);

            }
        }

        public void Mostrarparcial()
        {
            string[] var1 = sen.consultaparcial();
            for (int i = 0; i < var1.Length; i++)
            {
                txtsolucionparcial.Value = Convert.ToString(var1[0]);

            }
        }

        public void Mostrarnosolucionado()
        {
            string[] var1 = sen.consultanosolucionado();
            for (int i = 0; i < var1.Length; i++)
            {
                txtnosolucionado.Value = Convert.ToString(var1[0]);

            }
        }

        public void MostrarEliminados()
        {
            string[] var1 = sen.consultarTotal6();
            for (int i = 0; i < var1.Length; i++)
            {
                Text2.Value = Convert.ToString(var1[0]);

            }
        }

        public void llenarcombosucursal()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_gerencias";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "GerenciasH");
                    IGAgencia1.DataSource = ds;
                    IGAgencia1.DataTextField = "sh_gerencianombre";
                    IGAgencia1.DataValueField = "id_shgerencia";
                    IGAgencia1.DataBind();
                    IGAgencia1.Items.Insert(0, new ListItem("[Gerencias]", "0"));
                }
                catch { }
            }
        }

        public void llenarcomboarea(long codtiposucursal)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_area where 	sh_gerencias_id_shgerencia ='" + codtiposucursal + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    IGADepa1.DataSource = ds;
                    IGADepa1.DataTextField = "sh_areanombre";
                    IGADepa1.DataValueField = "id_sharea";
                    IGADepa1.DataBind();
                    IGADepa1.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void IGAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGADepa1.Visible = true;
            IGADepa1.ClearSelection();
            llenarcomboarea(long.Parse(IGAgencia1.SelectedValue));
        }

        protected void iniciar_Click(object sender, EventArgs e)
        {
            Session["Mes"] = Mes.Value;
            Session["Año"] = año.Value;
            Session["Gerencia"] = IGAgencia1.Text;
            Session["Area"] = IGADepa1.Text;
            Session["Estado"] = cmbestado.SelectedValue;

            Response.Redirect("VistaHallazgo.aspx");
        }

        protected void elimi_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaEliminar.aspx");
        }

        public void llenarcomboestado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sh_estado";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "estado");
                    cmbestado.DataSource = ds;
                    cmbestado.DataTextField = "sh_nombre";
                    cmbestado.DataValueField = "id_shestado";
                    cmbestado.DataBind();
                    cmbestado.Items.Insert(0, new ListItem("Estado", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
    }
}