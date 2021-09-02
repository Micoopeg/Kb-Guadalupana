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
    public partial class RespuestaHallazgo : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        Logica_Hallazgos logic = new Logica_Hallazgos();
        Conexion cn = new Conexion();
        KB_Rutas kbrutas = new KB_Rutas();
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
            string[] var1 = sen.consultarHallazgorestructurado(ideditar);
            for (int i = 0; i < var1.Length; i++)
            {
                ID.Value = Convert.ToString(var1[2]);
                MesH.Value = Convert.ToString(var1[4]);
                Año.Value = Convert.ToString(var1[5]);
                Rubro.Value = Convert.ToString(var1[6]);
                Hallazgo.Value = Convert.ToString(var1[9]);
                Recomendacion.Value = Convert.ToString(var1[10]);
            }
            string[] var2 = sen.consultarrespuestadehallazgo(ideditar);
            for (int i = 0; i < var2.Length; i++)
            {
                Textarea1.Value = Convert.ToString(var2[0]);
            }
        }

        // ----------------------------------------------------------------
        // Validar si subio un arhivo
        public void archivo()
        {
            string ruta;
            ideditar = Session["Idguardarse"].ToString();
            string[] var1 = sen.consultararchivodehallazgo(ideditar);
            ruta = Convert.ToString(var1[0]);


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
            // string[] var1 = sen.consultarHallazgorestructurado(ideditar);
            //  string[] var1 = sen.consultarimagensolucionh(ideditar);
            //string[] var1 = sen.consultarimagensolucionh(ideditar);
            string[] var2 = sen.consultararchivodehallazgo(ideditar);

            //ruta = Convert.ToString(var1[8]);
            ruta = Convert.ToString(var2[0]);

            string rutaestatica = kbrutas.rutaestaticaarchivoshallazgos();

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
            }
            else
            {
                Response.Write("EL ARCHIVO QUE ESTÁ BUSCANDO NO SE ENCUENTRA ALMACENADO");
            }
        }



        protected void Guardarse_Hallazgo_Click(object sender, EventArgs e)
        {
            string[] var12 = sen.consultarimagensolucionh(ID.Value);
            if (var12[0] == "null" || var12[0] == "" || var12[0] == null || var12[0] == "0")
            {
                if (FileUpload2.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
                    ext = ext.ToLower();

                    if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                    {
                        string idvalor = Session["Idguardarse"].ToString();

                        string doc = idvalor + FileUpload2.FileName;
                        string rutadoc = kbrutas.rutaestaticaarchivoshallazgos();
                        FileUpload2.SaveAs(rutadoc + doc);

                        ideditar = Session["Idguardarse"].ToString();
                        string[] campos = { "codshrespuestaasignacion", "sh_imagensolucion" };
                        string[] valores = { ideditar, doc };
                        try
                        {
                            logic.modificartablas("sh_respuesta_asignacion", campos, valores);

                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                            bloqueo.Visible = false;
                        }
                        catch
                        {
                        }
                        string[] var1 = sen.consultarHora();
                        string fecha = Convert.ToString(var1[0]);
                        string abre = Session["sesion_usuario"].ToString();
                        ideditar = Session["Idguardarse"].ToString();
                        string[] campos2 = { "codshrespuestaasignacion", "sh_comentario", "sh_estatus", "sh_fecha", "sh_usuario" };
                        string[] valores2 = { ideditar, Textarea1.Value, "2", fecha, abre };
                        try
                        {
                            logic.modificartablas("sh_respuesta_asignacion", campos2, valores2);
                            bloqueo.Visible = false;
                        }
                        catch
                        { }
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
                    string abre = Session["sesion_usuario"].ToString();
                    ideditar = Session["Idguardarse"].ToString();
                    string[] campos = { "codshrespuestaasignacion", "sh_comentario", "sh_estatus", "sh_fecha", "sh_usuario" };
                    string[] valores = { ideditar, Textarea1.Value, "2", fecha, abre };
                    try
                    {
                        logic.modificartablas("sh_respuesta_asignacion", campos, valores);
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                        bloqueo.Visible = false;
                    }
                    catch
                    { }
                }
            }
            else
            {
                string[] var1 = sen.consultarHora();
                string fecha = Convert.ToString(var1[0]);
                string abre = Session["sesion_usuario"].ToString();
                ideditar = Session["Idguardarse"].ToString();
                string[] campos = { "codshrespuestaasignacion", "sh_comentario", "sh_estatus", "sh_fecha", "sh_usuario" };
                string[] valores = { ideditar, Textarea1.Value, "2", fecha, abre };
                try
                {
                    logic.modificartablas("sh_respuesta_asignacion", campos, valores);
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                    bloqueo.Visible = false;
                }
                catch
                { }
                if (FileUpload2.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
                    ext = ext.ToLower();

                    if ((ext == ".docx") || (ext == ".pdf") || (ext == ".jpg") || (ext == ".png"))
                    {
                        string idvalor = Session["Idguardarse"].ToString();

                        string doc = idvalor + FileUpload2.FileName;
                        string rutadoc = kbrutas.rutaestaticaarchivoshallazgos();
                        FileUpload2.SaveAs(rutadoc + doc);

                        ideditar = Session["Idguardarse"].ToString();
                        string[] campos2 = { "codshrespuestaasignacion", "sh_imagensolucion" };
                        string[] valores2 = { ideditar, doc };
                        try
                        {
                            logic.modificartablas("sh_respuesta_asignacion", campos2, valores2);

                            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Respuesta Enviada'); window.location.href= RespuestaEnviada.aspx", true);
                            bloqueo.Visible = false;
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El archivo no es compatible, los formatos permitos son: .docx,pdf,jpg y png')", true);
                    }

                }
            }
        }
    }
}