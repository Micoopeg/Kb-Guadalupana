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
using System.IO;

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class EditarHallazgo : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        KB_Rutas kbruta = new KB_Rutas();
        string ideditar;
        string consulta;
        string valor = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('id: " + Session["Idguardar"] + "');", true);
            //mostrarGerencia1();


            if (!IsPostBack)
            {
                
                llenarcombosucursal();
                actualizar();
                BloquearGerencias2();
                archivo();
                llenarcomboestado();
                mostrarIE();
            }
        }

        public void mostrarIE()
        {
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarHallazgorestructurado(ideditar);
            for (int i = 0; i < var1.Length; i++)
            {
                ID.Value = Convert.ToString(var1[2]);
                Cal.Value = Convert.ToString(var1[3]);
                MesH.Value = Convert.ToString(var1[4]);
                Año.Value = Convert.ToString(var1[5]);
                Rubro.Value = Convert.ToString(var1[6]);
                cmbestado.SelectedValue = Convert.ToString(var1[7]);
                Hallazgo.Value = Convert.ToString(var1[9]);
                Recomendacion.Value = Convert.ToString(var1[10]);             
                txtcomentario.Value = Convert.ToString(var1[11]);
                txtrespuesta.Value = Convert.ToString(var1[12]);
            }
        }

        public void BloquearGerencias2()
        {
            ideditar = Session["Idguardar"].ToString();

            string[] var1 = sen.consultarValor(ideditar);
            consulta = Convert.ToString(var1[0]);
            Rubro.Disabled = true;
            Hallazgo.Disabled = true;

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('id: " + ideditar + " Valor: "+consulta+"');", true);

            
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
                    cmbestado.Items.Insert(0, new ListItem("[Estados]", "0"));
                }
                catch { }
            }
        }
        public void archivo()
        {
            string ruta;
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultararchivodehallazgo(ideditar);
            ruta = Convert.ToString(var1[0]);


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

        public void actualizar()
        {
            string valor;

            llenarcombosucursal();

            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarHallazgorestructurado(ideditar);

            IGAgencia1.Text = Convert.ToString(var1[0]);
            valor = Convert.ToString(var1[0]);
            llenarcomboarea(long.Parse(valor));
            IGADepa1.SelectedValue = Convert.ToString(var1[1]);
        }
        protected void Guardar_Hallazgo_Click(object sender, EventArgs e)
        {
            string ruta;
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultararchivodehallazgo(ideditar);
            ruta = Convert.ToString(var1[0]);
            string rutaestatica = kbruta.rutaestaticaarchivoshallazgos();

            string FilePath = rutaestatica+ruta; //Variable ruta
            WebClient user = new WebClient();
            if (File.Exists(FilePath))
            {
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
                else
                {
                    Response.Write("erorr");
                }
            }
            else
            {
                Response.Write("NO SE ENCUENTRA EL ARCHIVO EN ALMACENADO");
            }
        }

        protected void Visualizar_Hallazgo_Click(object sender, EventArgs e)
        {
            string ruta;
            ideditar = Session["Idguardar"].ToString();
            string[] var1 = sen.consultarimagensolucionh(ideditar);
            ruta = Convert.ToString(var1[0]);
            string rutaestatica = kbruta.rutaestaticaarchivoshallazgos();

            string FilePath = rutaestatica + ruta; //Variable ruta
            WebClient user = new WebClient();
            if (File.Exists(FilePath))
            {
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
                else
                {
                    Response.Write("erorr");
                }
            }
            else
            {
                Response.Write("NO SE ENCUENTRA EL ARCHIVO EN ALMACENADO");
            }
        }

        protected void Eliminar_Hallazgo_Click(object sender, EventArgs e)
        {

            ideditar = Session["Idguardar"].ToString();

            string[] campos = { "codshrespuestaasignacion", "sh_estatus" };
            string[] valores = { ID.Value, "6" };
            try
            {
                logic.modificartablas("sh_respuesta_asignacion", campos, valores);
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Eliminado'); window.location.href= 'VistaHallazgo.aspx';", true);
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
        }

        protected void guardarh_Hallazgo_Click(object sender, EventArgs e)
        {
            string[] arridhallazgo = sen.consultaridhallazgo(ID.Value);
            string idhallazgo = Convert.ToString(arridhallazgo[0]);

            //EN EL CASO QUE SUBA UN ARCHIVO
            if (FileUpload1.HasFile){
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();
                if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                {
                    string idvalor = Session["Idguardar"].ToString();
                    string doc = idvalor + FileUpload1.FileName;
                    FileUpload1.SaveAs(kbruta.rutaestaticaarchivoshallazgos() + idvalor + FileUpload1.FileName);                  

                    string[] campos = { "id_shhallazgo", "sh_archivo"};
                    string[] valores = { idhallazgo, doc};
                    try
                    {
                        logic.modificartablas("sh_hallazgo", campos, valores);
                    }catch { }

                    string[] campos1 = { "codshrespuestaasignacion", "sh_comentario", "sh_calificacion", "sh_comentarioauditor", "sh_estatus", "sh_recomendacion" };
                    string[] valores1 = { ID.Value, txtrespuesta.Value, Cal.Value, txtcomentario.Value, cmbestado.SelectedValue, Recomendacion.Value };
                    try
                    {
                        logic.modificartablas("sh_respuesta_asignacion", campos1, valores1);
                    }
                    catch (Exception ex) { Response.Write(ex); }
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Actualizado'); window.location.href= 'EditarHallazgo.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo no es compatible, los formatos permitos son: .docx,pdf,jpg y png')", true);
                }
            }
            else //EN EL CASO DE QUE NO SUBA UN ARCHIVO.
            {
                if (Rubro.Value == "" || cmbestado.SelectedValue == "[Estados]")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('PORFAVOR COLOCAR UN ESTADO VALIDO O VERIFICAR QUE EL RUBRO NO SE ENCUENTRE VACIO')", true);
                }
                else
                {
                    string[] campos1 = { "codshrespuestaasignacion", "sh_comentario", "sh_calificacion", "sh_comentarioauditor", "sh_estatus", "sh_recomendacion" };
                    string[] valores1 = { ID.Value, txtrespuesta.Value, Cal.Value, txtcomentario.Value, cmbestado.SelectedValue, Recomendacion.Value };
                    try
                    {
                        logic.modificartablas("sh_respuesta_asignacion", campos1, valores1);
                    }
                    catch (Exception ex) { Response.Write(ex); }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Hallazgo Actualizado'); window.location.href= 'VistaHallazgo.aspx';", true);
            }            
        }

  
    }
}