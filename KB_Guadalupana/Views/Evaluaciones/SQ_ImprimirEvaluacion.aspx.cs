using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using Microsoft.Reporting.WebForms;

namespace KB_Guadalupana.Views.Evaluaciones
{
    public partial class SQ_ImprimirEvaluacion : System.Web.UI.Page
    {
        ModeloSQ msq = new ModeloSQ();
        string ususario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ususario = Convert.ToString(Session["sesion_usuario"]);
        }


        private DataTable auto15()
        {
            DataTable dt3 = new DataTable();




            string usuario2 = msq.iduser(ususario);

            dt3 = msq.AUTO15(usuario2);






            return dt3;



        }
        private DataTable auto613()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(ususario);



            dt3 = msq.AUTO613(usuario2);






            return dt3;



        }
        private DataTable auto1420()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(ususario);



            dt3 = msq.AUTO1420(usuario2);






            return dt3;



        }
        private DataTable jefe15()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(ususario);



            dt3 = msq.JEFE15(usuario2);






            return dt3;



        }
        private DataTable jefe613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.JEFE613(usuario2);






            return dt3;



        }


        private DataTable auto6132()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(ususario);



            dt3 = msq.AUTO6132(usuario2);






            return dt3;



        }

        private DataTable jefe6132()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.JEFE6132(usuario2);






            return dt3;



        }
        private DataTable JEFE1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.JEFE1420(usuario2);






            return dt3;



        }
        private DataTable promedios15()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.PROM15(usuario2);






            return dt3;



        }
        private DataTable promedios613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.PROM613(usuario2);






            return dt3;



        }
        private DataTable promedios6132()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.PROM6132(usuario2);






            return dt3;



        }
        private DataTable promedios1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.PROM1420(usuario2);






            return dt3;



        }
        private DataTable comentarios()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.COMENT(usuario2);






            return dt3;



        }
        private DataTable encabezado()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.ENCABEZADO(usuario2);






            return dt3;



        }
        private DataTable preguntassub()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.preguntassub();






            return dt3;



        }

        private DataTable preguntasjefe()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.preguntasjefe();






            return dt3;



        }
        private DataTable preguntasjefe17()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.preguntasjefe17();






            return dt3;



        }
        private DataTable preguntasescalajefe()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.preguntasrangosjefe1();






            return dt3;



        }
        private DataTable preguntasescalasub()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.preguntasrangosjefe2();






            return dt3;



        }
        private DataTable SUB15()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.sub15(usuario2);






            return dt3;



        }
        private DataTable SUB613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.sub613(usuario2);






            return dt3;



        }
        private DataTable SUB1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.sub1420(usuario2);






            return dt3;



        }

        private DataTable notafinal()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(ususario);


            dt3 = msq.notafinal(usuario2);






            return dt3;



        }
        public void jeferepo ()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("auto15", auto15());
            ReportDataSource fuente2 = new ReportDataSource("auto613", auto6132());
            ReportDataSource fuente3 = new ReportDataSource("jefe15", jefe15());
            ReportDataSource fuente4 = new ReportDataSource("jefe613", jefe6132());
            ReportDataSource fuente5 = new ReportDataSource("pro1", promedios15());
            ReportDataSource fuente6 = new ReportDataSource("pro2", promedios6132());
            ReportDataSource fuente12 = new ReportDataSource("pro3", promedios1420());
            ReportDataSource fuente7 = new ReportDataSource("comentarios", comentarios());
            ReportDataSource fuente8 = new ReportDataSource("encab", encabezado());
            ReportDataSource fuente9 = new ReportDataSource("subal15", SUB15());
            ReportDataSource fuente10 = new ReportDataSource("subal613", SUB613());
            ReportDataSource fuente11 = new ReportDataSource("subal1420", SUB1420());
            ReportDataSource fuente13 = new ReportDataSource("jefe1420", JEFE1420());
            ReportDataSource fuente14 = new ReportDataSource("auto1420", auto1420());
            ReportDataSource fuente15 = new ReportDataSource("notafinal", notafinal());
            ReportDataSource fuente16 = new ReportDataSource("preguntas", preguntasjefe());
            ReportDataSource fuente17 = new ReportDataSource("preguntas16", preguntasjefe17());


            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.DataSources.Add(fuente2);
            ReportViewer1.LocalReport.DataSources.Add(fuente3);
            ReportViewer1.LocalReport.DataSources.Add(fuente4);
            ReportViewer1.LocalReport.DataSources.Add(fuente5);
            ReportViewer1.LocalReport.DataSources.Add(fuente6);
            ReportViewer1.LocalReport.DataSources.Add(fuente7);
            ReportViewer1.LocalReport.DataSources.Add(fuente8);
            ReportViewer1.LocalReport.DataSources.Add(fuente9);
            ReportViewer1.LocalReport.DataSources.Add(fuente10);
            ReportViewer1.LocalReport.DataSources.Add(fuente11);
            ReportViewer1.LocalReport.DataSources.Add(fuente12);
            ReportViewer1.LocalReport.DataSources.Add(fuente13);
            ReportViewer1.LocalReport.DataSources.Add(fuente14);
            ReportViewer1.LocalReport.DataSources.Add(fuente15);
            ReportViewer1.LocalReport.DataSources.Add(fuente16);
            ReportViewer1.LocalReport.DataSources.Add(fuente17);
  
            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/ReporteDesempeñoJefe.rdlc";

            ReportViewer1.LocalReport.Refresh();
        }


        protected void preguntasgen()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("preguntasescalas", preguntasescalajefe());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/Preguntas.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }
        protected void preguntasgen2()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("preguntasescalas", preguntasescalasub());


            ReportViewer1.LocalReport.DataSources.Add(fuente);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/Preguntas.rdlc";

            ReportViewer1.LocalReport.Refresh();

        }
        public void individualrepo ()
        {
            ReportViewer1.Reset();
            ReportDataSource fuente = new ReportDataSource("auto15", auto15());
            ReportDataSource fuente2 = new ReportDataSource("auto613", auto613());
            ReportDataSource fuente3 = new ReportDataSource("jefe15", jefe15());
            ReportDataSource fuente4 = new ReportDataSource("jefe613", jefe613());
            ReportDataSource fuente5 = new ReportDataSource("pro1", promedios15());
            ReportDataSource fuente6 = new ReportDataSource("pro2", promedios613());
            ReportDataSource fuente7 = new ReportDataSource("comentarios", comentarios());
            ReportDataSource fuente8 = new ReportDataSource("encab", encabezado());
            ReportDataSource fuente9 = new ReportDataSource("preguntas", preguntassub());
    

            ReportViewer1.LocalReport.DataSources.Add(fuente);
            ReportViewer1.LocalReport.DataSources.Add(fuente2);
            ReportViewer1.LocalReport.DataSources.Add(fuente3);
            ReportViewer1.LocalReport.DataSources.Add(fuente4);
            ReportViewer1.LocalReport.DataSources.Add(fuente5);
            ReportViewer1.LocalReport.DataSources.Add(fuente6);
            ReportViewer1.LocalReport.DataSources.Add(fuente7);
            ReportViewer1.LocalReport.DataSources.Add(fuente8);
            ReportViewer1.LocalReport.DataSources.Add(fuente9);

            ReportViewer1.LocalReport.ReportPath = "Views/Evaluaciones/ReporteDesempeño.rdlc";

            ReportViewer1.LocalReport.Refresh();
        }


        protected void Imprimir_Click(object sender, EventArgs e)
        {
            string id = msq.iduser(ususario);
            string[] permiso = msq.puestos(id);
            int cantidadpermiso = permiso.Length;
            if (permiso[0] == "null" || permiso[0] == "0" || permiso[0] == "" || permiso[0] == null)
            {
                //permisoempleado
               individualrepo();
               
            }
            else
            {
                //permisojefe
                 jeferepo();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = msq.iduser(ususario);
            string[] permiso = msq.puestos(id);
            int cantidadpermiso = permiso.Length;
            if (permiso[0] == "null" || permiso[0] == "0" || permiso[0] == "" || permiso[0] == null)
            {
                //permisoempleado
                preguntasgen2();

            }
            else
            {
                //permisojefe
                preguntasgen();
            }
        }
    }
}