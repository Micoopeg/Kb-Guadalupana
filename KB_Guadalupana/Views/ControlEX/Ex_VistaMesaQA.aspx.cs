using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text.RegularExpressions;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_VistaMesaQA : System.Web.UI.Page
    {
        ModeloEX mex = new ModeloEX();
        ControladorEX exc = new ControladorEX();
        string fechamin, horamin, fechahora, usernombre, nombrepersona, coduser;
        char delimitador2 = ' ';
        string cif;
        string rol;
        string area;
        string fechaactual;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {


            usernombre = Convert.ToString(Session["sesion_usuario"]);
            nombrepersona = Convert.ToString(Session["Nombre"]);
            coduser = exc.obtenercoduser(usernombre);
            if (usernombre != "" && coduser != "")
            {
                string permiso = exc.obtenerrol(usernombre);
                switch (permiso)
                {
                    //mensajeria
                    case "1":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                    //Mesa
                    
                    //juridico
                    case "2":


                        txtbarras.Visible = true;
                        txtbarras2.Visible = false;
                        span1.Visible = true;
                        span3.Visible = true;
                        alerta2.Visible = true;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = false;
                        asignado.Visible = false;
                        alerta.Visible = false;
                        alerta3.Visible = false;
                        H1.Visible = false;
                        alerta4.Visible = false;
                        encabasignados.Visible = false;
                        ajuridico.Attributes.Add("style", "margin-top: 70px;");
                        alerta2.Attributes.Add("style", "font-size:15px; color: lawngreen; text-align: initial; margin-left: -116px");
                        llenardthallazgo();
                        llenardtgasignado();
                      

                        break;

                    //Negocios
                    case "5":
                        Response.Redirect("Ex_Principal.aspx");
                        break;
                   

             

                    case "8":
                        txtbarras.Visible = true;
                        txtbarras2.Visible = false;

                        span1.Visible = false;
        
                        btnorden.Visible = true;
                        alerta.Visible = false;
                        alerta2.Visible = false;
                        alerta3.Visible = true;
                        asignado.Visible = true;
                        encabenvio.Visible = true;
                        encabselec.Visible = true;
                        alerta4.Visible = false;
                        ajuridico.Visible = true;
                     
                        if (!IsPostBack) { llenarcomboasignadojuridico(); }
                        llenardtgvmesa();
                        llenardtgasignado();
                
                        llenarlistos();
                        break;
                    case "7":
                        txtbarras.Visible = false;
                        btnlimpiar.Visible = false;    
                        hallazgo.Visible = false;
                        span1.Visible = true;
                        span2.Visible = false;
                        span3.Visible = false;
                        alerta4.Visible = true;
                        alerta2.Visible = false;
                        txtbarras2.Visible = true;
                        encabselec.Visible = false;
                        encabenvio.Visible = false;
                        ajuridico.Visible = true;
                        btnorden.Visible = false;
                        asignado.Visible = false;
                        alerta.Visible = false;
                        alerta3.Visible = false;
                        H1.Visible = false;
                        encabasignados.Visible = false;
                        llenararch();

                        break;

                }



            }
            else
            {
                Response.Redirect("../Session/MenuBarra.aspx");

            }


        }

        public void GenerarPDFjuridicomesa()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            crearlotesalida();
            dt3 = mex.llenarenviomesaarch();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/cartaenvio.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/F1.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote2(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                tbl.AddCell(new PdfPCell(new Phrase("NO. LOTE " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                tbl = new PdfPTable(new float[] { 30f, 40f, 30f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(new Phrase("" + noma + ":", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                tbl.AddCell(new PdfPCell(new Phrase("Formato Oficial Para Envío de expedientes ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("ARCHIVO", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                tbl.AddCell(new PdfPCell(new Phrase("DE.......................PARA", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });


                doc.Add(tbl);



                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));



                string[] datos2 = mex.cartaenviomesaarch();


                PdfPTable table = new PdfPTable(6);
                tbl = new PdfPTable(new float[] { 15f, 10f, 15f, 30f, 15f, 15f }) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase("Fecha/Hora Desembolso", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 4f };
                var c2 = new PdfPCell(new Phrase("CIF", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c3 = new PdfPCell(new Phrase("NO. Préstamo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c4 = new PdfPCell(new Phrase("Nombre", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c5 = new PdfPCell(new Phrase("Monto", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };
                var c6 = new PdfPCell(new Phrase("Tipo", negrita)) { Border = 0, BorderWidthBottom = 2f, Padding = 2f };


                string cont = exc.contpdf(usernombre);
                int envios = Convert.ToInt32(cont);
                table.TotalWidth = 550f;

                table.LockedWidth = true;
                float[] widths = new float[] { 40f, 15f, 25f, 40f, 20f, 35f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;

                table.AddCell(c1);
                table.AddCell(c2);
                table.AddCell(c3);
                table.AddCell(c4);
                table.AddCell(c5);
                table.AddCell(c6);

                c1.Border = 0;
                c2.Border = 0;
                c3.Border = 0;
                c4.Border = 0;
                c5.Border = 0;
                c6.Border = 0;

                try
                {

                    for (int j = 0; j < datos2.Length; j++)
                    {

                        /*c1.Phrase = new Phrase(Convert.ToString(datos2.GetValue(j)));*/


                        table.AddCell(Convert.ToString(datos2.GetValue(j)));

                    }

                    doc.Add(table);


                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }








                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/cartaenvio.pdf");
                estadomesaarch();
                Response.Redirect("Ex_VistaMesaQA.aspx");

            }



        }
        public void GenerarPDFjuridicomesaext()
        {
            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            string noma = exc.obtenerareanombre(a);
            crearlotesalida();
            dt3 = mex.llenarenviomesaarch();

            if (dt3.Rows.Count < 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Ningun elemento Seleccionado ')", true);

            }
            else
            {
                Document doc = new Document(PageSize.LETTER);
                doc.SetMargins(40f, 40f, 40f, 40f);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                     Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/cartaenvio5.pdf", FileMode.Create));

                doc.AddAuthor("Micoope");
                doc.AddTitle("Carta");
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine("C:/Users/pgecasasola/Desktop/Repos control de Expedientes/Kb-Guadalupana/KB_Guadalupana/Views/Imagenes/F1.png"));
                logo.ScalePercent(45f);

                BaseFont _titulo = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(_titulo, 20f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont _subtitulo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font subtitulo = new iTextSharp.text.Font(_titulo, 14f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));


                BaseFont _parrafo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font parrafo = new iTextSharp.text.Font(_titulo, 12f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));


                BaseFont _detalle = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font detalle = new iTextSharp.text.Font(_detalle, 15f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                BaseFont helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                iTextSharp.text.Font negrita = new iTextSharp.text.Font(helvetica, 10f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                //obtener el lote al que pertenece 1 exp
                string lote = exc.obtenerlote2(dt3.Rows[0]["gen_numcredito"].ToString());
                int cant = dt3.Rows.Count;
                string cant2 = Convert.ToString(cant);
                doc.Add(Chunk.NEWLINE);

                var tbl = new PdfPTable(new float[] { 40f, 50f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
                tbl.AddCell(new PdfPCell(new Phrase("NO. LOTE " + lote + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("Tipo de Paquete: Expedientes", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("Cantidad: " + cant2 + "", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                doc.Add(tbl);

                doc.Add(new Phrase(" "));
                doc.Add(new Phrase(" "));

                tbl = new PdfPTable(new float[] { 30f, 40f, 30f }) { WidthPercentage = 100 };
                tbl.AddCell(new PdfPCell(new Phrase("" + noma + ":", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                tbl.AddCell(new PdfPCell(new Phrase("Formato Oficial Para Envío de expedientes ", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tbl.AddCell(new PdfPCell(new Phrase("ARCHIVO", detalle)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });

                tbl.AddCell(new PdfPCell(new Phrase("DE.......................PARA", parrafo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });


                doc.Add(tbl);


                
                








                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/cartaenvio5.pdf");
                estadomesaarch();
                Response.Redirect("Ex_VistaMesaQA.aspx");

            }



        }
        public void crearlotesalida()
        {

         

            DataTable dt3 = new DataTable();
    
            dt3 = mex.llenarenviomesaarch();
            string numerolote = exc.siguiente("ex_lotesalida", "numerolote");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {


                string codex =exc.obtenercodexp( dt3.Rows[i]["gen_numcredito"].ToString());

                string envio = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                string siglote = exc.siguiente("ex_lotesalida", "codlote");

             
                string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + envio + "', '" + codex + "', '" + fechaactual + "', 2, 5 );";
                exc.Insertar(bitacora);
                string lote = "INSERT INTO `ex_lotesalida`(`codlote`, `codexp`, `numerolote`, `estado`) VALUES ('" + siglote + "', '" + codex + "', '" + numerolote + "', 0)";
                exc.Insertar(lote);


            }


        }
        public void estadomesaarch()
        {

            DataTable dt3 = new DataTable();
            string a = exc.obtenerarea(usernombre);
            dt3 = mex.llenarenviomesaarch();
            if (dt3.Rows.Count != 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");
                    string codenv = exc.obtenercodenv(dt3.Rows[i]["gen_numcredito"].ToString());
                    string codexp = exc.obtenercodexp(dt3.Rows[i]["gen_numcredito"].ToString());

                    string updateest = "UPDATE `ex_envio` SET `estado`=2 ,`codexetapa`= 5 WHERE Nocredito =  '" + dt3.Rows[i]["gen_numcredito"].ToString() + "'";
                    exc.Insertar(updateest);
                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + codenv + "', '" + codexp + "', '" + fechaactual + "', 2, 5 );";
                    exc.Insertar(bitacora);

                }
            }



        }
        protected void btnorden_Click(object sender, EventArgs e)
        {
          
            string permiso = exc.obtenerrol(usernombre);
            try
            {
              
                switch (permiso)
                {
                    //agencia jefe
                 
                    //mesa encargado 8
                    case "8":


                        GenerarPDFjuridicomesa();
                        GenerarPDFjuridicomesaext();
                        break;
               



                }




            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }



        }
        public void now()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    string hora = Convert.ToString(fecha.GetValue(1));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + " " + hora;

                    fechaactual = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
        public void llenardtgvmesa()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesaarch();
            DGVSELECT.DataSource = dt1;
            DGVSELECT.DataBind();

        }
        public void llenararch()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenararch();
            DGVAMARCAR.DataSource = dt1;
            DGVAMARCAR.DataBind();

        }

        public void llenardthallazgo()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesarchasignadohall(coduser);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }
        public void llenardtgasignado()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarmesarchasignado(coduser);
            DGVCONHALLAZGO.DataSource = dt1;
            DGVCONHALLAZGO.DataBind();

        }

        protected void DGVSELECT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVSELECT.PageIndex = e.NewPageIndex;
            llenardtgvmesa();
        }

        protected void DGVSELECT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quien = asignado.SelectedValue;
            int invl = asignado.SelectedIndex;


            GridViewRow row = DGVSELECT.SelectedRow;
            DataTable dt1 = new DataTable();
            string numcred = (DGVSELECT.SelectedRow.FindControl("lblnumcred") as Label).Text;
            string codexp = exc.obtenercodexp(numcred);
            string sigas = exc.siguiente("ex_asignado", "codasig");
            if (quien != "" && invl != 0)
            {

                string asignar = "INSERT INTO `ex_asignado`(`codasig`, `codexp`, `codasignado`, `proceso`) VALUES ('" + sigas + "', '" + codexp + "', '" + asignado.SelectedValue + "' , 5)";
                exc.Insertar(asignar);

                Response.Redirect("Ex_VistaMesaQA.aspx");
            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione a quién desea asignarle los expedientes.')", true); }



        }

        protected void DGVCONHALLAZGO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVCONHALLAZGO.PageIndex = e.NewPageIndex;
            llenardthallazgo();

        }

        protected void DGVCONHALLAZGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numcred = (DGVCONHALLAZGO.SelectedRow.FindControl("lblnumcred") as Label).Text;

            string cargar = mex.obtenercoment(numcred);
            string codexpe = exc.obtenercodexp(numcred);

            if (codexpe != "")
            {

                hallazgo.Visible = true;
                hallazgo.Disabled = true;
                span3.Visible = true;
                if (cargar == "NULL")
                {
                    num.InnerText = numcred;
                    hallazgo.Value = "No se registraron hallazgos. Puede enviarlo.";
                }
                else
                {
                    num.InnerText = numcred;
                    hallazgo.Value = cargar;

                }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Expediente Inválido')", true); }


        }

        protected void txtbarras_TextChanged(object sender, EventArgs e)
        {
            //buscar segun codigo ingresado y cargar en dgv pendiente



            string barras = txtbarras.Text;
            Regex regex = new Regex("");
            string[] s = regex.Split(barras);



            if (s.Length == 14)
            {

                string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];


                string hall = mex.comentario(numero) ;
                string obtener = mex.confirmarasog(numero);
                string coasg = mex.confirmarareaasig3(numero);
                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);
                if (hall == "")
                {
                    if (codenv != "" && obtener != "" && coasg != "")
                    {

                        string updateenv = "UPDATE `ex_envio` SET `estado`= 2 ,`codexetapa`= 5,`usuario`= '" + coduser + "' , `codareauser`= '" + a + "' WHERE Nocredito = '" + numero + "'";
                        string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                        exc.Insertar(updateres);
                        string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                        string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                        exc.Insertar(bitacoraa);

                        txtbarras.Text = "";
                        String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Expediente con hallazgos')", true); }
            }

            else if (s.Length == 15)
            {

                string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                string obtener = mex.confirmarasog(numero);

                string hall = mex.comentario(numero);
                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);
                string coasg = mex.confirmarareaasig3(numero);

                if (hall == "")
                {
                    if (codenv != "" && obtener != "" && coasg != "")
                    {

                        string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 5  WHERE Nocredito = '" + numero + "'";
                        exc.Insertar(updateres);
                        string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                        string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 5 );";
                        exc.Insertar(bitacoraa);

                        txtbarras.Text = "";
                        String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Expediente con hallazgos')", true); }
            
        }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
        }

        protected void DGVAMARCAR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVAMARCAR.PageIndex = e.NewPageIndex;
            llenardtgasignado();
        }

        protected void DGVOREN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVOREN.PageIndex = e.NewPageIndex;
            llenarlistos();
        }

        protected void txtbarras2_TextChanged(object sender, EventArgs e)
        {
            string barras = txtbarras2.Text;
            Regex regex = new Regex("");
            string[] s = regex.Split(barras);



            if (s.Length == 14)
            {

                string numero = "0" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9];



                string obtener = mex.confirmarasog(numero);
                string coasg = mex.confirmarareaasig3(numero);
                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);

                if (codenv != "" && obtener != "" && coasg != "")
                {


                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 6  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 6 );";
                    exc.Insertar(bitacoraa);

                    txtbarras2.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

            }

            else if (s.Length == 15)
            {

                string numero = s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10];


                string obtener = mex.confirmarasog(numero);


                string a = exc.obtenerarea(usernombre);
                string codenv = exc.obtenercodenv(numero);
                string codexpe = exc.obtenercodexp(numero);
                string coasg = mex.confirmarareaasig3(numero);
                if (codenv != "" && obtener != "" && coasg != "")
                {

                    string updateres = "UPDATE `ex_envio` SET `estado`= 1 ,`codexetapa`= 6  WHERE Nocredito = '" + numero + "'";
                    exc.Insertar(updateres);
                    string sigientebt = exc.siguiente("ex_bitacora", "codexbit");

                    string bitacoraa = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigientebt + "', '" + codenv + "', '" + codexpe + "', '" + fechaactual + "', 1, 6);";
                    exc.Insertar(bitacoraa);

                    txtbarras2.Text = "";
                    String script = "alert('Expediente Validado '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El código ingresado no corresponde a ningún expediente o no ha sigo asignado correctamente, por favor ingreselo manualmente o contacte a soporte')", true); }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número Inválido')", true); }
        }

        protected void btnlimpiar_Click(object sender, EventArgs e)
        {
            if (num.InnerText != "")
            {

                string codexp = exc.obtenercodexp(num.InnerText);
        

                string insertarhall = "UPDATE `ex_expediente` SET `ex_comentario`='' WHERE codexp = '" + codexp + "'";
                exc.Insertar(insertarhall);

               
                String script = "alert('Expediente Listo '); window.location.href= 'Ex_VistaMesaQA.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione el Expediente)", true); }
        }

        public void llenarlistos()
        {

            DataTable dt1 = new DataTable();
            dt1 = mex.llenarenviomesaarch();
            DGVOREN.DataSource = dt1;
            DGVOREN.DataBind();

        }
        public void llenarcomboasignadojuridico()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlingreso WHERE ex_controlarea = 43";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    asignado.DataSource = ds;
                    asignado.DataTextField = "nomcom";
                    asignado.DataValueField = "codexcontroling";
                    asignado.DataBind();
                    asignado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Usuarios]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }
    }
}