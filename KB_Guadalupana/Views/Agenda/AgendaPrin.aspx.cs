 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBGuada.Controllers;
using KBGuada.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

namespace KBGuada.Views
{
    public partial class Index : System.Web.UI.Page
    {
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        string fecha;
        string fecha2;
        string idc;
        string usernombre, nombrepersona;

        string rol;
        int area;
        string entrie;
        protected void Page_Load(object sender, EventArgs e)
        {

            usernombre = Convert.ToString( Session["sesion_usuario"] );
            nombrepersona = Convert.ToString( Session["Nombre"] );
            NombreUsuario.InnerText = Session["Nombre"].ToString();
            entrie = cav.obtenercoduser(usernombre);
            if (entrie == "" || entrie == null) {

                String script = "alert('Favor soliitar acceso a su agenda')";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                Response.Redirect("../Sesion/MenuBarra.aspx");
            }
            else { permisos(cav.obtenercoduser(usernombre)); }


        }

        public void permisos(string usuario){
            rol = cav.consultarRol(usuario);
           

            string agenda = cav.consultaragenda(cav.obtenercoduser(usernombre));
          
                
                //area = Convert.ToInt32(reader2.GetString(0));
                if (rol == "2")
                {
                    asignhome.Visible = false;

                    DataSet ds1 = cav.consultar(usuario);
                    repetir.DataSource = ds1;
                    repetir.DataBind();



                    if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
                    {


                        CABI.InnerText = "Comencemos Agregando Nuevas Tareas";
                        if (agenda == "")
                        {
                            string useragenda = cav.obtenercoduser(usernombre);
                            string sig2 = cav.siguiente("av_agenda", "codavagenda");
                            string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + useragenda + "');";
                            cav.insertartarea(sql3);
                        }


                    }
                    else
                    {
                        CABI.InnerText = "Bienvenido De Nuevo, Tienes Tareas Pendientes";




                    }



                }
                else if (rol == "3")
                {
                    DataSet ds = cav.consultar(usuario);

                    reptir2.DataSource = ds;
                    reptir2.DataBind();


                    if (ds == null || ds.Tables[0].Rows.Count == 0)
                    {

                        CABI.InnerText = "Comencemos Agregando Nuevas Tareas";
                        if (agenda == "")
                        {
                            string useragenda = cav.obtenercoduser(usernombre);
                            string sig2 = cav.siguiente("av_agenda", "codavagenda");
                            string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + useragenda + "');";
                            cav.insertartarea(sql3);
                        }
                    }
                    else
                    {
                        CABI.InnerText = "Bienvenido De Nuevo, Tienes Tareas Pendientes";

                    }
                }
                else if (rol == "1") {

                    DataSet ds1 = cav.consultar(usuario);
                    reptir2.DataSource = ds1;
                    reptir2.DataBind();



                    if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
                    {


                        CABI.InnerText = "Comencemos Agregando Nuevas Tareas";
                        if (agenda == "")
                        {
                            string useragenda = cav.obtenercoduser(usernombre);
                            string sig2 = cav.siguiente("av_agenda", "codavagenda");
                            string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + useragenda + "');";
                            cav.insertartarea(sql3);
                        }


                    }
                    else
                    {
                        CABI.InnerText = "Bienvenido De Nuevo, Tienes Tareas Pendientes";




                    }



                }
            


        }
        //bloqueo de botones
        protected void repetir_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
                {


                    

                    Label identa = (Label)e.Item.FindControl("lblId");

                    HtmlGenericControl cartafront2 = (HtmlGenericControl)identa.FindControl("cartafront") ;

                LinkButton add = (LinkButton)identa.FindControl("btnadd");
                LinkButton mod = (LinkButton)identa.FindControl("btnmod");
                LinkButton reasig = (LinkButton)identa.FindControl("btnreas");
                LinkButton track = (LinkButton)identa.FindControl("btntrack");

                string[] lector = mav.estadopermisotarea(identa.Text);
                    try
                    {
                    for (int i = 0; i < lector.Length; i++)
                    {
                        string estado = Convert.ToString(lector.GetValue(0));
                        string permiso = Convert.ToString(lector.GetValue(1));

                        //if (estado == "1") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:DeepSkyBlue; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "2") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:OrangeRed; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "3") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:ForestGreen; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "4") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:Black; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }

                        switch (estado)
                        {

                            case "1":


                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:OrangeRed; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");

                                break;
                            case "2":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:Gold; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;
                            case "3":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:ForestGreen; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;
                            case "4":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:Black; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;

                        }
                        switch (permiso)
                        {

                            case "1":

                                add.Visible = true;
                                mod.Visible = true;
                                reasig.Visible = false;
                                track.Visible = true;
                                break;
                            case "2":
                                add.Visible = true;
                                mod.Visible = false;
                                reasig.Visible = false;
                                track.Visible = false;
                                break;

                            case "3":
                                add.Visible = true;
                                mod.Visible = true;
                                reasig.Visible = true;
                                track.Visible = true;
                                break;


                        }

                    }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);

                    }
                  
                    

                
            }
        }
        //perfil total
        protected void repetir_ItemDataBound2(object sender, RepeaterItemEventArgs e)
        {


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {




                Label identa = (Label)e.Item.FindControl("lblId");

                HtmlGenericControl cartafront2 = (HtmlGenericControl)identa.FindControl("cartafront");


                string[] lector = mav.estadopermisotarea(identa.Text);
                try
                {
                    for (int i = 0; i < lector.Length; i++)
                    {
                        string estado = Convert.ToString(lector.GetValue(0));
                        string permiso = Convert.ToString(lector.GetValue(1));

                        //if (estado == "1") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:DeepSkyBlue; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "2") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:OrangeRed; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "3") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:ForestGreen; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }
                        //if (estado == "4") { cartafront2.Attributes.Add("style", "border-style: solid;border-color:Black; max-width: 209px; max-height: 350px; width: 209px; height: 350px;"); }

                        switch (estado)
                        {

                            case "1":


                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:OrangeRed; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");

                                break;
                            case "2":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:Gold; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;
                            case "3":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:ForestGreen; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;
                            case "4":

                                cartafront2.Attributes.Add("style", "border-style: solid;border-color:Black; max-width: 209px; max-height: 350px; width: 209px; height: 350px;");
                                break;

                        }
                      
                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }




            }
        }
        protected void btnmod_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("lblId")).Text;
            //Response.Redirect("session/Av_Subtareas.aspx");
            Session["NoTarea"] = idc;

            Response.Redirect("Av_ModTarea.aspx");

            


        }
        protected void btnTarea_Click(object sender, EventArgs e) {

            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("lblId")).Text;
            //Response.Redirect("session/Av_Subtareas.aspx");
            Session["NoTarea"] = idc;

            Response.Redirect("Av_Subtareas.aspx");
        }
        protected void btnreasig_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("lblId")).Text;
            HtmlGenericControl gen = (HtmlGenericControl)item.FindControl("TITLE");

            string titulo = gen.InnerText;
            //Response.Redirect("session/Av_Subtareas.aspx");
            Session["NoTarea"] = idc;
            Session["TituloTarea"] = titulo;
            Response.Redirect("Av_Reasignar.aspx");
        }

        protected void btntrack_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            idc = ((Label)item.FindControl("lblId")).Text;
        

           
          
            Session["NoTarea"] = idc;
        
            Response.Redirect("Av_Tracking.aspx");
        }
        protected void cerrarsession_Click(object sender, EventArgs e) 
        {
            if (Session.IsNewSession)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Entra If');", true);
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }


    }
}