using System;
using KBGuada.Controllers;
using KBGuada.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Script.Services;
using System.Web.Services;

namespace KBGuada.Views.session
{

    public partial class Av_Subtareas : System.Web.UI.Page
    {
        string AVSUBDESC, AVFECHAI, AVFECHAF;
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        string tarea, Nombreuser, user;
        string concat = "T";
        string fechamaxn, fechamaxconcat;
        string fechamin, fechaminconcat;
        char delimitador = ' ';
        protected void Page_Load(object sender, EventArgs e)
        {

            string numerotarea = Convert.ToString(Session["NoTarea"]);

            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            NombreUsuario.InnerText = user;
            tarea = numerotarea;
            cargaractividades(numerotarea);
            cargaFechas(numerotarea);
            cabredito.Visible = false;
            mostrarnocredito();
            mostraranular(); 


        }

        public void mostraranular() {

            string rol = cav.consultarRol(cav.obtenercoduser(Nombreuser));

            if (rol == "3") {

                btnanular.Visible = true;

            }
            else if ( rol == "2" ) {

                ASIGHOME.Visible = false;
            }
             
            
         
            } 
        public void mostrarnocredito() {

            string tipo = cav.tipotarea(tarea);
            if (tipo == "1") {

                cabredito.Visible = true;


            }
            


        }

        public void cargaFechas(string no) {


            string[] fecha = mav.consultafecha(no);
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamaxn = Convert.ToString(fecha.GetValue(0));
                    string[] valores1 = fechamaxn.Split(delimitador);

                    fechamaxconcat = valores1[0] + "-" + valores1[1] + "-" + valores1[2] + concat + valores1[3];


                    fechamin = Convert.ToString(fecha.GetValue(1));
                    string[] valores2 = fechamin.Split(delimitador);

                    fechaminconcat = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + concat + valores2[3];

                    FECHAINIC.Attributes.Add("min", fechamaxconcat);
                    FECHAINIC.Attributes.Add("max", fechaminconcat);
                    FECHAFINAL.Attributes.Add("min", fechamaxconcat);
                    FECHAFINAL.Attributes.Add("max", fechaminconcat);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }

        }

        protected void btncredito_Click(object sender, EventArgs e) {


            if (Credit.Value != "")
            {
                string sig = cav.siguiente("av_credito", "codavcredit");

                string sqlcredito = "INSERT INTO av_credito  VALUES( '" + sig + "', '" + tarea + "', '" + Credit.Value + "'  )";
                string tareapa = "UPDATE `av_tarea` SET `cod_estado` = 3 WHERE codavtarea = '"+tarea+"'; ";
                cav.insertartarea(sqlcredito);
                cav.insertartarea(tareapa);
                Response.Redirect("AgendaPrin.aspx");
            }
            else {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' No se puede ingresar sin numero de credito. ')", true);

            }



        }

        public void cargaractividades(string nutarea) {

            DataSet ds1 = cav.consultarAc(nutarea);




            repetirsub.DataSource = ds1;
            repetirsub.DataBind();



        }
        public void limpiar() {
            INACTIVIDAD.Value = string.Empty;
            FECHAINIC.Value = string.Empty;
            FECHAFINAL.Value = string.Empty;


        }


        public void insertarNSubtarea() {
            AVSUBDESC = INACTIVIDAD.Value;
            AVFECHAI = FECHAINIC.Value;
            AVFECHAF = FECHAFINAL.Value;



            if (INACTIVIDAD.Value != "")
            {
                if (FECHAFINAL.Value != "")
                {

                    if (FECHAINIC.Value != "")
                    {

                        string sig = cav.siguiente("av_subtarea", "codsubtarea");

                        string sql = "INSERT INTO av_subtarea VALUES ('" + sig + "', '" + tarea + "', '1' , '" + AVSUBDESC + "','" + AVFECHAI + "','" + AVFECHAF + "'  ); ";

                        cav.insertartarea(sql);
                        limpiar();
                        cargaractividades(tarea);
                        //Response.Redirect("Av_Subtareas.aspx");


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Debe ingresar la fecha inicial ')", true);

                    }


                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Debe ingresar la fecha final ')", true);

                }
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Debe ingresar el nombre de la actividad ')", true);

            }




        }


        protected void btnInsertarsub_Click(object sender, EventArgs e)
        {
            cargaFechas(tarea);
            insertarNSubtarea();

        }

        public void actualizartareapadre(string dato) {


            if (dato == "0") {

                string updatepadre = "UPDATE `av_tarea` SET `cod_estado` = '3' WHERE `av_tarea`.`codavtarea` = '" + tarea + "';";

                cav.insertartarea(updatepadre);

            }



        }
        protected void btnlisto_Click(object sender, EventArgs e) {

            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            string actividad = ((Label)item.FindControl("idsubtarea")).Text;


            string actividadactual = "UPDATE `av_subtarea` SET `codestado` = '3' WHERE `av_subtarea`.`codsubtarea` = '" + actividad + "';";
            cav.insertartarea(actividadactual);


            //si la tarea no tiene mas actividades en estado 1 entonces update tarea padre 3

            string actualizartarea = " UPDATE `av_tarea` SET `cod_estado` = '2' WHERE `av_tarea`.`codavtarea` = '" + tarea + "';   ";

            cav.insertartarea(actualizartarea);


            string actual = cav.obtenerconteo(tarea);

            actualizartareapadre(actual);

            Response.Redirect("Av_Subtareas.aspx");

        }

        protected void insertarcomentario_Click(object sender, EventArgs e)
        {

            if(AVCOMENT.Value == ""){

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingrese la razón por la cual se terminó la tarea. ')", true);

            }
            else{

                string coment = " UPDATE `av_tarea` SET `av_comentario` = '"+AVCOMENT.Value+"' WHERE codavtarea = '"+tarea+"' ;";
                string updatepadre = "UPDATE `av_tarea` SET `cod_estado` = '3' WHERE `av_tarea`.`codavtarea` = '" + tarea + "';";
                cav.insertartarea(coment);
                cav.insertartarea(updatepadre);

        

                Response.Redirect("AgendaPrin.aspx");
            
            }

        
        
        }
        protected void anular_Click(object sender, EventArgs e)
        {

            if (AVCOMENT.Value == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ingrese la razón por la cual se anulará la tarea. ')", true);

            }
            else
            {

                string coment = " UPDATE `av_tarea` SET `av_comentario` = '" + AVCOMENT.Value + "' WHERE codavtarea = '" + tarea + "' ;";
                string updatepadre = "UPDATE `av_tarea` SET `cod_estado` = '4' WHERE `av_tarea`.`codavtarea` = '" + tarea + "';";
                cav.insertartarea(coment);
                cav.insertartarea(updatepadre);



                Response.Redirect("AgendaPrin.aspx");

            }



        }
    }
}