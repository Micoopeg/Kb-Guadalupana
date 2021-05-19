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
    public partial class ConsultaHallazgo : System.Web.UI.Page
    {
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                permisos();
            }
        }

        public void permisos()
        {
            //Session["sesion_usuario"] = "pgdgomez";
            string sesionuser = Session["sesion_usuario"].ToString();

            string[] var1 = sen.consultarUsuario(sesionuser);
            string valor = Convert.ToString(var1[0]);

            string[] var2 = sen.consultarRol(valor);
            string valor1 = Convert.ToString(var2[0]);

            //Auditor Interno - JEFE

            //Gerente General
            if (valor1 == "1")
            {
                if (!IsPostBack)
                {
                    llenarcombosucursal();
                    g1.Visible = false;
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
            }
            //Jefe de Area
            else if (valor1 == "3")
            {
                string valor12 = Convert.ToString(var2[2]);


                string[] var3 = sen.consultarAreas(valor12);
                string valor11 = Convert.ToString(var3[0]);

                areas1.InnerText = valor11;

                IGAgencia1.Visible = false;
                string valores1 = Convert.ToString(var2[1]);

                if (valores1 == "1")
                {
                    g1.Visible = true;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
                else if (valores1 == "2")
                {
                    g1.Visible = false;
                    g2.Visible = true;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
                else if (valores1 == "3")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = true;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
                else if (valores1 == "4")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = true;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
                else if (valores1 == "5")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = true;
                    g6.Visible = false;
                    g7.Visible = false;
                }
                else if (valores1 == "7")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = true;
                }
                IGADepa1.Visible = false;
                Messa.Visible = true;
                año.Visible = true;
            }
            //Gerente
            else if (valor1 == "2")
            {
                string valores1 = Convert.ToString(var2[1]);

                if (valores1 == "1")
                {
                    g1.Visible = true;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                    llenarcomboarea1(valores1);
                }
                else if (valores1 == "2")
                {
                    g1.Visible = false;
                    g2.Visible = true;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                    llenarcomboarea1(valores1);
                }
                else if (valores1 == "3")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = true;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                    llenarcomboarea1(valores1);
                }
                else if (valores1 == "4")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = true;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                    llenarcomboarea1(valores1);
                }
                else if (valores1 == "5")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = true;
                    g6.Visible = false;
                    g7.Visible = false;
                    llenarcomboarea1(valores1);
                }
                else if (valores1 == "7")
                {
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = true;
                    llenarcomboarea1(valores1);
                }

                IGAgencia1.Visible = false;
                IGADepa1.Visible = true;
                Messa.Visible = true;
                año.Visible = true;
            }
            //Auditor Interno - JEFE
            else if (valor1 == "5")
            {
                if (!IsPostBack)
                {
                    llenarcombosucursal();
                    g1.Visible = false;
                    g1.Visible = false;
                    g2.Visible = false;
                    g3.Visible = false;
                    g4.Visible = false;
                    g5.Visible = false;
                    g6.Visible = false;
                    g7.Visible = false;
                }
            }
            else
            {
                IGAgencia1.Visible = false;
                IGADepa1.Visible = false;
                Messa.Visible = false;
                año.Visible = false;
                g1.Visible = false;
                g1.Visible = false;
                g2.Visible = false;
                g3.Visible = false;
                g4.Visible = false;
                g5.Visible = false;
                g6.Visible = false;
                g7.Visible = false;
                boton.Visible = false;
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

        public void llenarcomboarea1(string codtiposucursal)
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
            Session["MesUsuario1"] = Messa.Value;
            Session["AñoUsuario1"] = año.Value;
            Session["AreaUsuario2"] = IGADepa1.Text;
            Session["AreaUsuario1"] = areas1.InnerText;


            Session["GerenciaUsuario1"] = IGAgencia1.Text;
            Session["g1"] = g1.InnerText;
            Session["g2"] = g2.InnerText;
            Session["g3"] = g3.InnerText;
            Session["g4"] = g4.InnerText;
            Session["g5"] = g5.InnerText;
            Session["g6"] = g6.InnerText;
            Session["g7"] = g7.InnerText;

            Response.Redirect("VistaHallazgo1.aspx");
        }
    }
}