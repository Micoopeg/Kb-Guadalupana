
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
    public partial class CrearHallazgo : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        KB_Rutas rutas = new KB_Rutas();

        int ids = 0;
        int valor = 1;
        int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombosucursal();
                ConsultaId();
            }
        }

        public void llenarcombosucursal()
        {
            //using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            //{
            //    try
            //    {
            //        sqlCon.Open();
            //        string QueryString = "select * from sh_gerencias";
            //        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
            //        DataSet ds = new DataSet();
            //        myCommand.Fill(ds, "GerenciasH");
            //        IGAgencia1.DataSource = ds;
            //        IGAgencia1.DataTextField = "sh_gerencianombre";
            //        IGAgencia1.DataValueField = "id_shgerencia";
            //        IGAgencia1.DataBind();
            //        IGAgencia1.Items.Insert(0, new ListItem("[Gerencias]", "0"));
            //    }
            //    catch { }
            //}
        }

        public void llenarcomboarea(long codtiposucursal)
        {
            //using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
            //{
            //    try
            //    {
            //        sqlCon.Open();
            //        string QueryString = "select * from sh_area where 	sh_gerencias_id_shgerencia ='" + codtiposucursal + "';";
            //        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
            //        DataSet ds = new DataSet();
            //        myCommand.Fill(ds, "area");
            //        IGADepa1.DataSource = ds;
            //        IGADepa1.DataTextField = "sh_areanombre";
            //        IGADepa1.DataValueField = "id_sharea";
            //        IGADepa1.DataBind();
            //        IGADepa1.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
            //    }
            //    catch { Console.WriteLine("Verifique los campos"); }
            //}
        }

        protected void IGAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IGADepa1.Visible = true;
            //IGADepa1.ClearSelection();
            //llenarcomboarea(long.Parse(IGAgencia1.SelectedValue));
        }

        protected void Guardar_Hallazgo_Click(object sender, EventArgs e)
        {
            if ((Rubro.Value == null) || (Rubro.Value == ""))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El area de Rubro no puede estar vacia. " + Rubro.Value + "');", true);
            }
            else if (MesH.Value == "Mes")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Es necesario seleccionar un Mes.');", true);
            }
            else if (Hallazgo.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El area de Hallazgo no puede estar vacia.');", true);
            }
            else if (Recomendacion.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El area de Recomendación no puede estar vacia.');", true);
            }
            else
            {
                if (archivo.HasFile)
                {
                    string[] validacionpunto = archivo.FileName.Split('.');
                    if (validacionpunto.Length == 2)
                    {


                        string ext = System.IO.Path.GetExtension(archivo.FileName);
                        ext = ext.ToLower();

                        if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                        {
                            string idvalor = Session["IDH"].ToString();
                            string rutadoc = rutas.rutaestaticaarchivoshallazgos();
                            //string doc = rutadoc + idvalor + archivo.FileName;
                            string doc = idvalor + archivo.FileName;

                            archivo.SaveAs(rutadoc + doc);
                            //archivo.SaveAs(Server.MapPath("Archivos/" + idvalor + archivo.FileName));

                            string sig199 = logic.siguiente("sh_hallazgo ", "id_shhallazgo");
                            string[] valores199 = { sig199, Rubro.Value, Hallazgo.Value, doc, Recomendacion.Value, MesH.Value, Año.Value, "0", "", "5" };
                            logic.insertartablas("sh_hallazgo", valores199);

                            string[] var1 = sen.cidhallazgo();
                            string val = Convert.ToString(var1[0]);
                            Session["Recomendacion"] = Recomendacion.Value;

                            if (val != sig199)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El Hallazgo no se pudo crear,Favor crearlo nuevamente');window.location.href= 'CrearHallazgo.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "error", "window.location.href= 'AsignarHallazgo.aspx';", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo no es compatible, los formatos permitos son: .docx,pdf,jpg y png')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El documento subido contiene un punto en su nombre favor eliminarlo, y volver a subirlo');window.location.href= 'CrearHallazgo.aspx';", true);
                    }
                }
                else
                {
                    string sig199 = logic.siguiente("sh_hallazgo ", "id_shhallazgo");
                    string[] valores199 = { sig199, Rubro.Value, Hallazgo.Value, "null", Recomendacion.Value, MesH.Value, Año.Value, "0","", "5" };
                    logic.insertartablas("sh_hallazgo", valores199);

                    string[] var1 = sen.cidhallazgo();
                    string val = Convert.ToString(var1[0]);
                    Session["Recomendacion"] = Recomendacion.Value;

                    if (val != sig199)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El Hallazgo no se pudo crear,Favor crearlo nuevamente');window.location.href= 'CrearHallazgo.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "window.location.href= 'AsignarHallazgo.aspx';", true);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Espere un momento mientras el archivo se esta subiendo.');", true);
        }

        public void ConsultaId()
        {
            string[] var1 = sen.consultarID();
            for (int i = 0; i < var1.Length; i++)
            {
                ids = Convert.ToInt32(var1[0]);
                mostrarid();
            }
        }

        public void mostrarid()
        {
            total = ids + valor;
            Session["IDH"] = total;
            Session["Rubro"] = Rubro;
            ID.Value = total.ToString();
        }
    }
}