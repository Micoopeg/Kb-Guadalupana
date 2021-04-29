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
    public partial class RespuestaHallazgo : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                mostrarIE();
                archivo();
            }
        }

        public void mostrarIE()
        {
            ideditar = Session["Idguardarse"].ToString();
            string[] var1 = sen.consultarHallazgo(ideditar);
            for (int i = 0; i < var1.Length; i++)
            {
                ID.Value = Convert.ToString(var1[0]);
                MesH.Value = Convert.ToString(var1[1]);
                Año.Value = Convert.ToString(var1[2]);
                Rubro.Value = Convert.ToString(var1[3]);
                Hallazgo.Value = Convert.ToString(var1[4]);
                Recomendacion.Value = Convert.ToString(var1[5]);
            }
        }

        // ----------------------------------------------------------------
        // Validar si subio un arhivo
        public void archivo()
        {
            string ruta;
            ideditar = Session["Idguardarse"].ToString();
            string[] var1 = sen.consultarHallazgo(ideditar);
            ruta = Convert.ToString(var1[8]);


            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra funcion');", true);
            if (ruta == "null")
            {
                Subir.Visible = false;
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
            ideditar = Session["Idguardarse"].ToString();
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

        protected void Guardarse_Hallazgo_Click(object sender, EventArgs e)
        {

            if (FileUpload2.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
                ext = ext.ToLower();

                if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                {
                    string idvalor = Session["Idguardarse"].ToString();

                    string doc = "Archivos/" + idvalor + FileUpload2.FileName;

                    FileUpload2.SaveAs(Server.MapPath("Archivos/" + idvalor + FileUpload2.FileName));


                    string[] var1 = sen.consultarHora();
                    string fecha = Convert.ToString(var1[0]);
                    string abre = Session["sesion_usuario"].ToString();


                    string sig199 = logic.siguiente("sh_respuesta ", "id_shrespuesta");
                    string[] valores199 = { sig199, Textarea1.Value, fecha, doc, idvalor, abre };
                    logic.insertartablas("sh_respuesta", valores199);

                    ideditar = Session["Idguardarse"].ToString();

                    string[] campos = { "id_shhallazgo", "sh_estado_id_shestado" };
                    string[] valores = { ideditar, "2" };
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

                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                    bloqueo.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo no es compatible, los formatos permitos son: .docx,pdf,jpg y png')", true);
                }
            }
            else
            {
                string[] var1 = sen.consultarHora();
                string fecha = Convert.ToString(var1[0]);

                string idvalor = Session["Idguardarse"].ToString();
                string sig199 = logic.siguiente("sh_respuesta ", "id_shrespuesta");
                string abre = Session["sesion_usuario"].ToString();
                string[] valores199 = { sig199, Textarea1.Value, fecha, "null", idvalor, abre };
                logic.insertartablas("sh_respuesta", valores199);

                ideditar = Session["Idguardarse"].ToString();

                string[] campos = { "id_shhallazgo", "sh_estado_id_shestado" };
                string[] valores = { ideditar, "2" };
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

                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                bloqueo.Visible = false;
            }
        }
    }
}