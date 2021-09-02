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
    public partial class temporal : System.Web.UI.Page
    {

        ModeloSQ msq = new ModeloSQ();
        string ususario;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        private DataTable auto15()
        {
            DataTable dt3 = new DataTable();




            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            dt3 = msq.AUTO15(usuario2);






            return dt3;



        }
        private DataTable auto613()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(TextBox1.Text.Trim());



            dt3 = msq.AUTO613(usuario2);






            return dt3;



        }
        private DataTable auto1420()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(TextBox1.Text.Trim());



            dt3 = msq.AUTO1420(usuario2);






            return dt3;



        }
        private DataTable jefe15()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(TextBox1.Text.Trim());



            dt3 = msq.JEFE15(usuario2);






            return dt3;



        }
        private DataTable jefe613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE613(usuario2);






            return dt3;



        }


        private DataTable auto6132()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(TextBox1.Text.Trim());



            dt3 = msq.AUTO6132(usuario2);






            return dt3;



        }

        private DataTable jefe6132()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE6132(usuario2);






            return dt3;



        }
        private DataTable JEFE1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE1420(usuario2);






            return dt3;



        }


        private DataTable promedios15()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.PROM15(usuario2);






            return dt3;



        }
        private DataTable promedios613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.PROM613(usuario2);






            return dt3;



        }
        private DataTable promedios6132()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.PROM6132(usuario2);






            return dt3;



        }
        private DataTable promedios1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.PROM1420(usuario2);






            return dt3;



        }
        private DataTable comentarios()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.COMENT(usuario2);






            return dt3;



        }
        private DataTable encabezado()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.ENCABEZADO(usuario2);






            return dt3;



        }
        private DataTable preguntassub()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.preguntassub();






            return dt3;



        }



        private DataTable preguntasjefe()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.preguntasjefe();






            return dt3;



        }
        private DataTable preguntasjefe17()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.preguntasjefe17();






            return dt3;



        }
        private DataTable preguntasescalajefe()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.preguntasrangosjefe1();






            return dt3;



        }
        private DataTable preguntasescalasub()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.preguntasrangosjefe2();






            return dt3;



        }
        private DataTable SUB15()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.sub15(usuario2);






            return dt3;



        }
        private DataTable SUB613()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.sub613(usuario2);






            return dt3;



        }
        private DataTable SUB1420()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.sub1420(usuario2);






            return dt3;



        }

        private DataTable promediosbueno()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio1");



            dt3 = msq.AUTO15(usuario2);
            dt4 = msq.JEFE15(usuario2);
            dt5 = msq.sub15(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);

            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);


            row1["promedio1"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio1"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio1"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio1"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio1"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;

            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);





            return dt6;

        }
        private DataTable promediosbueno2()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            DataRow row6 = dt6.NewRow();
            DataRow row7 = dt6.NewRow();
            DataRow row8 = dt6.NewRow();
            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio2");



            dt3 = msq.AUTO6132(usuario2);
            dt4 = msq.JEFE6132(usuario2);
            dt5 = msq.sub613(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            var datos6 = Convert.ToDecimal(dt5.Rows[5]["resultado"]);
            var datos7 = Convert.ToDecimal(dt5.Rows[6]["resultado"]);
            var datos8 = Convert.ToDecimal(dt5.Rows[7]["resultado"]);
            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);
            var datoj6 = Convert.ToDecimal(dt4.Rows[5]["nota"]);
            var datoj7 = Convert.ToDecimal(dt4.Rows[6]["nota"]);
            var datoj8 = Convert.ToDecimal(dt4.Rows[7]["nota"]);

            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);
            var dato6 = Convert.ToDecimal(dt3.Rows[5]["nota"]);
            var dato7 = Convert.ToDecimal(dt3.Rows[6]["nota"]);
            var dato8 = Convert.ToDecimal(dt3.Rows[7]["nota"]);


            row1["promedio2"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio2"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio2"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio2"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio2"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;
            row6["promedio2"] = decimal.Round((dato6 + datoj6 + datos6) / 3, 2); ;
            row7["promedio2"] = decimal.Round((dato7 + datoj7 + datos7) / 3, 2); ;
            row8["promedio2"] = decimal.Round((dato8 + datoj8 + datos8) / 3, 2); ;

            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);
            dt6.Rows.Add(row6);
            dt6.Rows.Add(row7);
            dt6.Rows.Add(row8);





            return dt6;

        }
        private DataTable promediosbueno3()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            DataRow row6 = dt6.NewRow();
            DataRow row7 = dt6.NewRow();

            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio3");



            dt3 = msq.AUTO1420(usuario2);
            dt4 = msq.JEFE1420(usuario2);
            dt5 = msq.sub1420(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            var datos6 = Convert.ToDecimal(dt5.Rows[5]["resultado"]);
            var datos7 = Convert.ToDecimal(dt5.Rows[6]["resultado"]);

            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);
            var datoj6 = Convert.ToDecimal(dt4.Rows[5]["nota"]);
            var datoj7 = Convert.ToDecimal(dt4.Rows[6]["nota"]);


            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);
            var dato6 = Convert.ToDecimal(dt3.Rows[5]["nota"]);
            var dato7 = Convert.ToDecimal(dt3.Rows[6]["nota"]);



            row1["promedio3"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio3"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio3"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio3"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio3"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;
            row6["promedio3"] = decimal.Round((dato6 + datoj6 + datos6) / 3, 2); ;
            row7["promedio3"] = decimal.Round((dato7 + datoj7 + datos7) / 3, 2); ;


            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);
            dt6.Rows.Add(row6);
            dt6.Rows.Add(row7);






            return dt6;

        }

        private DataTable promediosbuenoag()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio1");



            dt3 = msq.AUTO15(usuario2);
            dt4 = msq.JEFE15mod(usuario2);
            dt5 = msq.sub15(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);

            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);


            row1["promedio1"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio1"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio1"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio1"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio1"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;

            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);





            return dt6;

        }
        private DataTable promediosbueno2ag()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            DataRow row6 = dt6.NewRow();
            DataRow row7 = dt6.NewRow();
            DataRow row8 = dt6.NewRow();
            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio2");



            dt3 = msq.AUTO6132(usuario2);
            dt4 = msq.JEFE6132mod(usuario2);
            dt5 = msq.sub613(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            var datos6 = Convert.ToDecimal(dt5.Rows[5]["resultado"]);
            var datos7 = Convert.ToDecimal(dt5.Rows[6]["resultado"]);
            var datos8 = Convert.ToDecimal(dt5.Rows[7]["resultado"]);
            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);
            var datoj6 = Convert.ToDecimal(dt4.Rows[5]["nota"]);
            var datoj7 = Convert.ToDecimal(dt4.Rows[6]["nota"]);
            var datoj8 = Convert.ToDecimal(dt4.Rows[7]["nota"]);

            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);
            var dato6 = Convert.ToDecimal(dt3.Rows[5]["nota"]);
            var dato7 = Convert.ToDecimal(dt3.Rows[6]["nota"]);
            var dato8 = Convert.ToDecimal(dt3.Rows[7]["nota"]);


            row1["promedio2"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio2"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio2"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio2"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio2"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;
            row6["promedio2"] = decimal.Round((dato6 + datoj6 + datos6) / 3, 2); ;
            row7["promedio2"] = decimal.Round((dato7 + datoj7 + datos7) / 3, 2); ;
            row8["promedio2"] = decimal.Round((dato8 + datoj8 + datos8) / 3, 2); ;

            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);
            dt6.Rows.Add(row6);
            dt6.Rows.Add(row7);
            dt6.Rows.Add(row8);





            return dt6;

        }
        private DataTable promediosbueno3ag()
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            string usuario2 = msq.iduser(TextBox1.Text.Trim());

            DataRow row1 = dt6.NewRow();
            DataRow row2 = dt6.NewRow();
            DataRow row3 = dt6.NewRow();
            DataRow row4 = dt6.NewRow();
            DataRow row5 = dt6.NewRow();
            DataRow row6 = dt6.NewRow();
            DataRow row7 = dt6.NewRow();

            dt6.Columns.Add("usuario_calificado");
            dt6.Columns.Add("ordenpregunta");
            dt6.Columns.Add("promedio3");



            dt3 = msq.AUTO1420(usuario2);
            dt4 = msq.JEFE1420mod(usuario2);
            dt5 = msq.sub1420(usuario2);

            //seccion subalterno
            var datos1 = Convert.ToDecimal(dt5.Rows[0]["resultado"]);
            var datos2 = Convert.ToDecimal(dt5.Rows[1]["resultado"]);
            var datos3 = Convert.ToDecimal(dt5.Rows[2]["resultado"]);
            var datos4 = Convert.ToDecimal(dt5.Rows[3]["resultado"]);
            var datos5 = Convert.ToDecimal(dt5.Rows[4]["resultado"]);
            var datos6 = Convert.ToDecimal(dt5.Rows[5]["resultado"]);
            var datos7 = Convert.ToDecimal(dt5.Rows[6]["resultado"]);

            //seccion jefes
            var datoj1 = Convert.ToDecimal(dt4.Rows[0]["nota"]);
            var datoj2 = Convert.ToDecimal(dt4.Rows[1]["nota"]);
            var datoj3 = Convert.ToDecimal(dt4.Rows[2]["nota"]);
            var datoj4 = Convert.ToDecimal(dt4.Rows[3]["nota"]);
            var datoj5 = Convert.ToDecimal(dt4.Rows[4]["nota"]);
            var datoj6 = Convert.ToDecimal(dt4.Rows[5]["nota"]);
            var datoj7 = Convert.ToDecimal(dt4.Rows[6]["nota"]);


            //seccion auto
            var dato1 = Convert.ToDecimal(dt3.Rows[0]["nota"]);
            var dato2 = Convert.ToDecimal(dt3.Rows[1]["nota"]);
            var dato3 = Convert.ToDecimal(dt3.Rows[2]["nota"]);
            var dato4 = Convert.ToDecimal(dt3.Rows[3]["nota"]);
            var dato5 = Convert.ToDecimal(dt3.Rows[4]["nota"]);
            var dato6 = Convert.ToDecimal(dt3.Rows[5]["nota"]);
            var dato7 = Convert.ToDecimal(dt3.Rows[6]["nota"]);



            row1["promedio3"] = decimal.Round((dato1 + datoj1 + datos1) / 3, 2);

            row2["promedio3"] = decimal.Round((dato2 + datoj2 + datos2) / 3, 2);
            row3["promedio3"] = decimal.Round((dato3 + datoj3 + datos3) / 3, 2);

            row4["promedio3"] = decimal.Round((dato4 + datoj4 + datos4) / 3, 2);

            row5["promedio3"] = decimal.Round((dato5 + datoj5 + datos5) / 3, 2); ;
            row6["promedio3"] = decimal.Round((dato6 + datoj6 + datos6) / 3, 2); ;
            row7["promedio3"] = decimal.Round((dato7 + datoj7 + datos7) / 3, 2); ;


            dt6.Rows.Add(row1);
            dt6.Rows.Add(row2);
            dt6.Rows.Add(row3);
            dt6.Rows.Add(row4);
            dt6.Rows.Add(row5);
            dt6.Rows.Add(row6);
            dt6.Rows.Add(row7);






            return dt6;

        }



        private DataTable notafinal()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.notafinal(usuario2);






            return dt3;



        }
        public void jeferepo()
        {

       
            string puestos = msq.obtenerpuesto(TextBox1.Text.Trim());

            if (puestos == "83" || puestos == "76")
            {
                ReportViewer1.Reset();
                ReportDataSource fuente = new ReportDataSource("auto15", auto15());
                ReportDataSource fuente2 = new ReportDataSource("auto613", auto6132());
                ReportDataSource fuente3 = new ReportDataSource("jefe15", jefe15mod());
                ReportDataSource fuente4 = new ReportDataSource("jefe613", jefe6132mod());
                ReportDataSource fuente5 = new ReportDataSource("pro1", promediosbuenoag());
                ReportDataSource fuente6 = new ReportDataSource("pro2", promediosbueno2ag());
                ReportDataSource fuente12 = new ReportDataSource("pro3", promediosbueno3ag());
                ReportDataSource fuente7 = new ReportDataSource("comentarios", comentariosmod());
                ReportDataSource fuente8 = new ReportDataSource("encab", encabezadomod());
                ReportDataSource fuente9 = new ReportDataSource("subal15", SUB15());
                ReportDataSource fuente10 = new ReportDataSource("subal613", SUB613());
                ReportDataSource fuente11 = new ReportDataSource("subal1420", SUB1420());
                ReportDataSource fuente13 = new ReportDataSource("jefe1420", JEFE1420mod());
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
            else
            {
                ReportViewer1.Reset();
                ReportDataSource fuente = new ReportDataSource("auto15", auto15());
                ReportDataSource fuente2 = new ReportDataSource("auto613", auto6132());
                ReportDataSource fuente3 = new ReportDataSource("jefe15", jefe15());
                ReportDataSource fuente4 = new ReportDataSource("jefe613", jefe6132());
                ReportDataSource fuente5 = new ReportDataSource("pro1", promediosbueno());
                ReportDataSource fuente6 = new ReportDataSource("pro2", promediosbueno2());
                ReportDataSource fuente12 = new ReportDataSource("pro3", promediosbueno3());
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



        }

        private DataTable encabezadomod()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.ENCABEZADOmod(usuario2);






            return dt3;



        }
        private DataTable jefe15mod()
        {
            DataTable dt3 = new DataTable();


            string usuario2 = msq.iduser(TextBox1.Text.Trim());



            dt3 = msq.JEFE15mod(usuario2);






            return dt3;



        }
        private DataTable jefe613mod()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE613mod(usuario2);






            return dt3;



        }
        private DataTable jefe6132mod()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE6132mod(usuario2);






            return dt3;



        }
        private DataTable JEFE1420mod()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.JEFE1420mod(usuario2);






            return dt3;



        }
        private DataTable comentariosmod()
        {
            DataTable dt3 = new DataTable();



            string usuario2 = msq.iduser(TextBox1.Text.Trim());


            dt3 = msq.COMENTmod(usuario2);






            return dt3;



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
        public void individualrepo()
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
            string id = msq.iduser(TextBox1.Text.Trim());
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
            string id = msq.iduser(TextBox1.Text.Trim());
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