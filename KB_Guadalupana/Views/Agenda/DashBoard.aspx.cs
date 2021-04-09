using System;
using KBGuada.Controllers;
using KB_Guadalupana.Controllers;
using KBGuada.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace KBGuada.Views.session
{
    public partial class DashBoard : System.Web.UI.Page
    {
        string idc;
        string BCIF,DAREA, FECHAI, FECHAF, DESTADO ;
        string nombreuser, user;
        string rol;
        Conexion conexiongeneral = new Conexion();
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        Conexion cn = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);

            NombreUsuario.InnerText = user;
            permisos(cav.obtenercoduser(nombreuser));
            if (!IsPostBack)
            {

                llenarcomboarea();
                llenarcomboestado();


            }


        }

        //FUNCIONES DE LLENADO DE COMBOS

        public void permisos(string usuario)
        {
           rol = cav.consultarRol(usuario);
            //MySqlDataReader reader2 = cav.consultarArea(usuario);


            
             
                //area = Convert.ToInt32(reader2.GetString(0));
                if (rol == "1")
                {
                    ENCABCIF.Visible = true;
                    BODYCIF.Visible = true;
                    ENCABAREA.Visible = false;
                    BODYAREA.Visible = false;


                }
                else if (rol == "2") {
                    ENCABCIF.Visible = false;
                    BODYCIF.Visible = false;
                    ENCABAREA.Visible = false;
                    BODYAREA.Visible = false;
                ASIGHOME.Visible = false;

                }
                else if (rol == "3") {
                    ENCABCIF.Visible = true;
                    BODYCIF.Visible = true;
                    ENCABAREA.Visible = true;
                    BODYAREA.Visible = true;

                }
              
            
        }
            public void llenarcomboarea()
        {
        
      

            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_estado;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Estado");
                    DropDownEstado.DataSource = ds;
                    DropDownEstado.DataTextField = "av_estado";
                    DropDownEstado.DataValueField = "codestado";
                    DropDownEstado.DataBind();
                    DropDownEstado.Items.Insert(0, new ListItem("[Estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboestado()
        {
            
     
          
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from av_controlsitio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    DropDownArea.DataSource = ds;
                    DropDownArea.DataTextField = "av_nombre";
                    DropDownArea.DataValueField = "codavcontolsitio";
                    DropDownArea.DataBind();
                    DropDownArea.Items.Insert(0, new ListItem("[Area]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        //-----------FIN COMBOS--------------//

    

        protected void btnbuscar_Click(object sender, EventArgs e) {

            BCIF = BUSCARCIF.Value;
            DAREA = DropDownArea.SelectedIndex.ToString();
            FECHAI = FECHAIBUSCAR.Value;
            FECHAF = FECHAFBUSCAR.Value;
            DESTADO = DropDownEstado.SelectedIndex.ToString();
            string area = cav.areauser(cav.obtenercoduser(nombreuser));
            string rol = cav.consultarRol(cav.obtenercoduser(nombreuser));

            //vacios
            if (BCIF == "" && DAREA == "0" && FECHAI == "" && FECHAF == "" && DESTADO == "0")
            {
                if (!IsPostBack) {

                    String script = "alert('Ingrese el campo por el que desea buscar ');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                


            }
            //cif
            if (BCIF != "" && DAREA == "0" && FECHAI == "" && FECHAF == "" && DESTADO == "0")
            {

                switch (rol) {

                    case "1":
                        DataSet ds11 = cav.porcif(BCIF, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;

                    case "2":
                        DataSet ds = cav.porcif(BCIF, area);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();


                        if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porcif(BCIF, area);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();


                        if (ds1.Tables[0].Rows.Count == 0 || ds1.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }

             



            }
            //fechas
            if (BCIF == "" && DAREA == "0" && FECHAI != "" && FECHAF != "" && DESTADO == "0")
            {

                switch (rol)
                {

                    case "1":
                        DataSet ds11 = cav.porfecha(FECHAI,FECHAF, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;

                    case "2":
                        DataSet ds = cav.porfecha(FECHAI, FECHAF, area);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();


                        if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porfecha(FECHAI, FECHAF, area);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();


                        if (ds1.Tables[0].Rows.Count == 0 || ds1.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }





            }
            //cif fecha
            if (BCIF != "" && DAREA == "0" && FECHAI != "" && FECHAF != "" && DESTADO == "0")
            {
               

                switch (rol)
                {
                    case "1":
                        DataSet ds11 = cav.porcif(BCIF, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "2":
                        DataSet ds = cav.porcifFecha(BCIF, FECHAI, FECHAF);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porcifFecha(BCIF, FECHAI, FECHAF);
                        repetidor2.DataSource = ds1;
                        repetidor1.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }

            }
            //cif estado
            if (BCIF != "" && DAREA == "0" && FECHAI == "" && FECHAF == "" && DESTADO != "0")
            {
                

                switch (rol)
                {
                    case "1":
                        DataSet ds11 = cav.porcif(BCIF, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "2":
                        DataSet ds = cav.porcifEstado(BCIF, DESTADO);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porcifEstado(BCIF, DESTADO);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }


            }
            //cif fecha estado
            if (BCIF != "" && DAREA == "0" && FECHAI != "" && FECHAF != "" && DESTADO != "0")
            {
                

                switch (rol)
                {
                    case "1":
                        DataSet ds11 = cav.porcif(BCIF, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "2":
                        DataSet ds = cav.porcifFechaEstado(BCIF, FECHAI, FECHAF, DESTADO);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porcifFechaEstado(BCIF, FECHAI, FECHAF, DESTADO);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }

            }
            //area fecha
            if (BCIF == "" && DAREA != "0" && FECHAI != "" && FECHAF != "" && DESTADO == "0")
            {
               

                switch (rol)
                {
                  
                    case "2":
                        DataSet ds = cav.porareaFecha(DAREA, FECHAI, FECHAF);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porareaFecha(DAREA, FECHAI, FECHAF);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }


                        break;
                }

            }
            //area
            if (BCIF == "" && DAREA != "0" && FECHAI == "" && FECHAF == "" && DESTADO == "0")
            {
             

                switch (rol)
                {
                    case "2":
                        DataSet ds = cav.porarea(DAREA);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porarea(DAREA);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                }

            }
            //area estado
            if (BCIF == "" && DAREA != "0" && FECHAI == "" && FECHAF == "" && DESTADO != "0")
            {
               

                switch (rol)
                {
                    case "2":
                        DataSet ds = cav.porareaEstado(DAREA, DESTADO);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porareaEstado(DAREA, DESTADO);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }
                        break;
                }

            }
            //area fecha estado
            if (BCIF == "" && DAREA != "0" && FECHAI != "" && FECHAF != "" && DESTADO != "0")
            {
               
                switch (rol)
                {
                    case "2":
                        DataSet ds = cav.porareafechaEstado(DAREA, FECHAI, FECHAF, DESTADO);
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porareafechaEstado(DAREA, FECHAI, FECHAF, DESTADO);
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }
                        break;
                }

            }
            //fecha y estado de usuario
            if (BCIF == "" && DAREA == "0" && FECHAI != "" && FECHAF != "" && DESTADO != "0")
            {
                

                switch (rol)
                {
                    case "2":
                        DataSet ds = cav.porfechaEstado(FECHAI, FECHAF, DESTADO, cav.obtenercoduser(nombreuser));
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porfechaEstado(FECHAI, FECHAF, DESTADO, cav.obtenercoduser(nombreuser));
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }
                        break;
                }

            }
            //busqueda por estado usuario
            if (BCIF == "" && DAREA == "0" && FECHAI == "" && FECHAF == "" && DESTADO != "0")
            {
                
                switch (rol)
                {

                    case "1":
                        DataSet ds11 = cav.porestadoadmin(DESTADO, area);
                        repetidor2.DataSource = ds11;
                        repetidor2.DataBind();


                        if (ds11.Tables[0].Rows.Count == 0 || ds11.Tables[0] == null)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "2":
                        DataSet ds = cav.porestadousuario(DESTADO, cav.obtenercoduser(nombreuser));
                        repetidor1.DataSource = ds;
                        repetidor1.DataBind();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }

                        break;
                    case "3":
                        DataSet ds1 = cav.porestadousuario(DESTADO, cav.obtenercoduser(nombreuser));
                        repetidor2.DataSource = ds1;
                        repetidor2.DataBind();

                        if (ds1.Tables[0].Rows.Count == 0)
                        {
                            CABI.InnerText = "Sin Resultados";


                        }
                        else
                        {
                            CABI.InnerText = "Resultados Encontrados";

                        }
                        break;
                }

            }
            //estadoareaadmin
        
        }
        protected void repetir_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {




                Label identa = (Label)e.Item.FindControl("lblId");

                HtmlGenericControl cartafront2 = (HtmlGenericControl)identa.FindControl("cartafront");
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

        protected void btnmod_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
          

            idc = ((Label)item.FindControl("lblId")).Text;
            //Response.Redirect("session/Av_Subtareas.aspx");
            Session["NoTarea"] = idc;

            Response.Redirect("Av_ModTarea.aspx");




        }
        protected void btnTarea_Click(object sender, EventArgs e)
        {
         

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


    }
}