using System;
using System.Collections.Generic;
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
using System.Net;

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class EditarHallazgo : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        string ideditar;
        string consulta;
        string valor = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('id: " + Session["Idguardar"] + "');", true);
            //mostrarGerencia1();


            if (!IsPostBack)
            {
                mostrarIE();
                llenarcombosucursal();
                actualizar();
                BloquearGerencias2();
                llenarcombosucursal1();
                actualizar1();
                archivo();
            }
        }

        public void mostrarIE()
        {
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarHallazgo(ideditar);
            for (int i = 0; i < var1.Length; i++)
            {
                ID.Value = Convert.ToString(var1[0]);
                MesH.Value = Convert.ToString(var1[1]);
                Año.Value = Convert.ToString(var1[2]);
                Rubro.Value = Convert.ToString(var1[3]);
                Hallazgo.Value = Convert.ToString(var1[4]);
                Recomendacion.Value = Convert.ToString(var1[5]);
                Estado.Value = Convert.ToString(var1[6]);
                Cal.Value = Convert.ToString(var1[7]);
            }
        }

        public void BloquearGerencias2()
        {
            ideditar = Session["Idguardar"].ToString();

            string[] var1 = sen.consultarValor(ideditar);
            consulta = Convert.ToString(var1[0]);

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('id: " + ideditar + " Valor: "+consulta+"');", true);

            if (consulta == valor)
            {
                gerencia2.Visible = false;
                gerencia21.Visible = false;
            }
            if (consulta != valor)
            {
                gerencia2.Visible = true;
                gerencia21.Visible = true;
            }
        }

        //Si hay 1 gerencias y areas asignadas
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

        public void actualizar()
        {
            string valor;

            llenarcombosucursal();

            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarGerencia11(ideditar);

            IGAgencia1.Text = Convert.ToString(var1[0]);
            valor = Convert.ToString(var1[0]);
            llenarcomboarea(long.Parse(valor));
            IGADepa1.SelectedValue = Convert.ToString(var1[1]);
        }
        // ----------------------------------------------------------------
        //Si hay 2 gerencias y areas asignadas
        public void llenarcombosucursal1()
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
                    IGAgencia4.DataSource = ds;
                    IGAgencia4.DataTextField = "sh_gerencianombre";
                    IGAgencia4.DataValueField = "id_shgerencia";
                    IGAgencia4.DataBind();
                    IGAgencia4.Items.Insert(0, new ListItem("[Gerencias]", "0"));
                }
                catch { }
            }
        }

        public void llenarcomboarea1(long codtiposucursal)
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
                    IGAgencia2.DataSource = ds;
                    IGAgencia2.DataTextField = "sh_areanombre";
                    IGAgencia2.DataValueField = "id_sharea";
                    IGAgencia2.DataBind();
                    IGAgencia2.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void actualizar1()
        {
            string valor;

            llenarcombosucursal1();

            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarGerencia1(ideditar);

            IGAgencia4.Text = Convert.ToString(var1[0]);
            valor = Convert.ToString(var1[0]);
            llenarcomboarea1(long.Parse(valor));
            IGAgencia2.SelectedValue = Convert.ToString(var1[1]);
        }
        // ----------------------------------------------------------------
        // Validar si subio un arhivo
        public void archivo()
        {
            string ruta;
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarHallazgo(ideditar);
            ruta = Convert.ToString(var1[8]);


            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra funcion');", true);
            if (ruta == "null")
            {
                Subir.Visible = true;
                Archivo.Visible = false;
            }
            else
            {
                Subir.Visible = false;
                Archivo.Visible = true;
            }
        }
        //-----------------------------------------------------------------
        protected void Guardar_Hallazgo_Click(object sender, EventArgs e)
        {
            string ruta;
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarHallazgo(ideditar);
            ruta = Convert.ToString(var1[8]);

            string FilePath = Server.MapPath(ruta); //Variable ruta
            WebClient user = new WebClient();
            Byte[] FileBuffer = user.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                string[] partes = ruta.Split('.');
                string subcadena = partes[1];

                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('id: " + subcadena + "');", true);

                if ((subcadena == "png") || (subcadena == "jpg"))
                {
                    Response.ContentType = "text/plain";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
                else if (subcadena == "pdf")
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
                else if (subcadena == "docx")
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
                //Response.ContentType = "application/docx";
            }
        }

        protected void Eliminar_Hallazgo_Click(object sender, EventArgs e)
        {

            ideditar = Session["Idguardar"].ToString();

            string[] campos = { "id_shhallazgo", "sh_estado_id_shestado" };
            string[] valores = { ideditar, "6" };
            try
            {
                logic.modificartablas("sh_hallazgo", campos, valores);
            }
            catch { }
            finally
            {
                try
                {
                    cn.desconectar();
                }
                catch
                { }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Eliminado'); window.location.href= 'VistaHallazgo.aspx';", true);
        }

        protected void guardarh_Hallazgo_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();

                if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                {
                    string idvalor = Session["Idguardar"].ToString();

                    string doc = "Archivos/" + idvalor + FileUpload1.FileName;

                    FileUpload1.SaveAs(Server.MapPath("Archivos/" + idvalor + FileUpload1.FileName));

                    ideditar = Session["Idguardar"].ToString();

                    string[] campos = { "id_shhallazgo", "sh_rubro", "sh_hallazgo", "sh_archivo", "sh_recomendacion", "sh_mes", "sh_año", "sh_calificacion", "sh_estado_id_shestado" };
                    string[] valores = { ideditar, Rubro.Value, Hallazgo.Value, doc, Recomendacion.Value, MesH.Value, Año.Value, Cal.Value, Estado.Value };
                    try
                    {
                        logic.modificartablas("sh_hallazgo", campos, valores);
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
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo no es compatible, los formatos permitos son: .docx,pdf,jpg y png')", true);
                }
            }
            else
            {
                ideditar = Session["Idguardar"].ToString();
                string[] campos = { "id_shhallazgo", "sh_rubro", "sh_hallazgo", "sh_recomendacion", "sh_mes", "sh_año", "sh_calificacion", "sh_estado_id_shestado" };
                string[] valores = { ideditar, Rubro.Value, Hallazgo.Value, Recomendacion.Value, MesH.Value, Año.Value, Cal.Value, Estado.Value };
                try
                {
                    logic.modificartablas("sh_hallazgo", campos, valores);
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



                ideditar = Session["Idguardar"].ToString();
                string[] var2 = sen.consultarasiganacioncontador(ideditar);

                string valor = Convert.ToString(var2[0]);

                if (valor == "2")
                {
                    ideditar = Session["Idguardar"].ToString();
                    string[] var1 = sen.consultarasiganacion1(ideditar);

                    string idpermisos = Convert.ToString(var1[0]);

                    string[] campos1 = { "id_shasignacion", "sh_hallazgo_id_shhallazgo", "sh_gerencias_id_shgerencia", "sh_idarea" };
                    string[] valores1 = { idpermisos, ideditar, IGAgencia1.Text, IGADepa1.Text };
                    try
                    {
                        logic.modificartablas("sh_asignacion", campos1, valores1);
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

                    string[] var3 = sen.consultarasiganacion11(ideditar);

                    string idpermisos1 = Convert.ToString(var3[0]);

                    string[] campos2 = { "id_shasignacion", "sh_hallazgo_id_shhallazgo", "sh_gerencias_id_shgerencia", "sh_idarea" };
                    string[] valores2 = { idpermisos1, ideditar, IGAgencia4.Text, IGAgencia2.Text };
                    try
                    {
                        logic.modificartablas("sh_asignacion", campos2, valores2);
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
                }
                else
                {
                    ideditar = Session["Idguardar"].ToString();
                    string[] var1 = sen.consultarasiganacion1(ideditar);

                    string idpermisos = Convert.ToString(var1[0]);

                    string[] campos1 = { "id_shasignacion", "sh_hallazgo_id_shhallazgo", "sh_gerencias_id_shgerencia", "sh_idarea" };
                    string[] valores1 = { idpermisos, ideditar, IGAgencia1.Text, IGADepa1.Text };
                    try
                    {
                        logic.modificartablas("sh_asignacion", campos1, valores1);
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
                }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Actualizado'); window.location.href= 'VistaHallazgo.aspx';", true);
        }
    }
}