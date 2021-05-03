using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using MySql.Data.MySqlClient;
using KBGuada.Controllers;

namespace KBGuada.Reportes
{
    public partial class ReporteUsuarios : System.Web.UI.Page
    {
        string Nombreuser, user, area;
        string rol;
        ControladorAV cav = new ControladorAV();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnmostrar.Enabled = false;

            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            NombreUsuario.InnerText = user;
            area = cav.areauser(cav.obtenercoduser(Nombreuser));
            permisos(cav.obtenercoduser(Nombreuser));
        }

        public void permisos(string usuario) {

          rol = cav.consultarRol(usuario);
            
               
                if (rol == "2")
                {
                    btnmostrar.Visible = false;
                    btnmostrartodo.Visible = false;
                btnmontos.Visible = false;
                    cabusuario.Visible = false;
                ASIGHOME.Visible = false;
                }


                
            }
        protected void activar_TextChanged(object sender, EventArgs e) {

           

                btnmostrar.Enabled = true;
            
          

  
        
        
        }

        protected void btnmontos_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSet5", obtenermontos());
            ReportDataSource fuente2 = new ReportDataSource("DataSet2", obtenermontosdatos());
            ReportDataSource fuente3 = new ReportDataSource("DataSet1", obtenermontosrestante());

            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.DataSources.Add(fuente2);
            ReportViewer1.LocalReport.DataSources.Add(fuente3);
            ReportViewer1.LocalReport.ReportPath = "ReportesAv/ReporteMontos.rdlc";

            ReportViewer1.LocalReport.Refresh();









        }
        protected void btnmostrar_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSet2", obtenerdatos());

            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.ReportPath = "ReportesAv/Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnmostrartodo_Click(object sender, EventArgs e)
        {


            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSet2", obtenertodos());

            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.ReportPath = "ReportesAv/Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();



        }
        protected void btnmostrartodouno_Click(object sender, EventArgs e)
        {

            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("DataSet2", obtenerunusuario());

            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.ReportPath = "ReportesAv/Report1.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }


        private DataTable obtenermontosrestante()
        {
            DataTable dt3 = new DataTable();


            if (AVFECHAINI.Value == "" || AVFECHAFIN.Value == "")
            {

                String script = "alert('Ingrese el rango de fechas a buscar ');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);



            }
            else
            {


                dt3 = cav.reportemontosresultante(AVFECHAINI.Value, AVFECHAFIN.Value);


            }



            return dt3;



        }
        private DataTable obtenerdatos()
        {

            DataTable dt = new DataTable();

            string codusr = cav.obtenercoduser(coduser.Text); 

            dt = cav.reportetable(codusr,area);

            return dt;


        }

        private DataTable obtenertodos()
        {


            DataTable dt2 = new DataTable();

            dt2 = cav.reportetabletodos(area);

            return dt2;



        }

        private DataTable obtenerunusuario() {
            DataTable dt3 = new DataTable();

            if (AVFECHAINI.Value == "" || AVFECHAFIN.Value == "")
            {

                String script = "alert('Ingrese el rango de fechas a buscar ');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);



            }
            else {
                string codusr = cav.obtenercoduser(Nombreuser);

                dt3 = cav.reportetableunososlo(codusr, AVFECHAINI.Value, AVFECHAFIN.Value);


            }



            return dt3;
        }


        private DataTable obtenermontos() {
            DataTable dt3 = new DataTable();
         

            if (AVFECHAINI.Value == "" || AVFECHAFIN.Value == "")
            {

                String script = "alert('Ingrese el rango de fechas a buscar ');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);



            }
            else
            {
                

                dt3 = cav.reportemontos( AVFECHAINI.Value, AVFECHAFIN.Value);
       

            }



            return dt3;
          


        }

        private DataTable obtenermontosdatos()
        {
   
            DataTable dt4 = new DataTable();
        

            if (AVFECHAINI.Value == "" || AVFECHAFIN.Value == "")
            {

                String script = "alert('Ingrese el rango de fechas a buscar ');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);



            }
            else
            {


 
                dt4 = cav.reportemontosdatos(AVFECHAINI.Value, AVFECHAFIN.Value);
       

            }



            return dt4;



        }
        //private DataTable obtenermontostotal()
        //{
      
        //    DataTable dt5 = new DataTable();

        //    if (AVFECHAINI.Value == "" || AVFECHAFIN.Value == "")
        //    {

        //        String script = "alert('Ingrese el rango de fechas a buscar ');";
        //        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);



        //    }
        //    else
        //    {


             
        //        dt5 = cav.reportemontostotal(AVFECHAINI.Value, AVFECHAFIN.Value);

        //    }



        //    return dt5;



        //}


    }
}