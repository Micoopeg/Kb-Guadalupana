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

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_VistaMensajeria : System.Web.UI.Page
    {
        ControladorEX exc = new ControladorEX();
        ModeloEX mex = new ModeloEX();
      
        Conexion conexiongeneral = new Conexion();
        string fechaactual, fechamin, fechahora, fechaactual2;
        char delimitador2 = ' ';
        protected void Page_Load(object sender, EventArgs e)
        {
          
            now();
            now2();
            if (!IsPostBack) { 
                llenarcomboasignado();
            }
            actualizarestados();

        }

        public void actualizarestados() {

            string update = "UPDATE `ex_aleatorio` SET `estado`= '0' WHERE fecha < '"+fechaactual2+"'";
            exc.Insertar(update);
        
        
        }
        public void llenarcomboasignado()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ex_controlingreso WHERE ex_controlarea = 45";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    mensajero.DataSource = ds;
                    mensajero.DataTextField = "nomcom";
                    mensajero.DataValueField = "codexcontroling";
                    mensajero.DataBind();
                    mensajero.Items.Insert(0, new ListItem("[Usuarios]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
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
        public void now2()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    string hora = Convert.ToString(fecha.GetValue(1));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2];

                    fechaactual2 = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
        protected void generar_Click(object sender, EventArgs e)
        {

            int quien = mensajero.SelectedIndex;
            string cual = mensajero.SelectedValue;

            if (quien != 0)
            {
                string aleatorio = mex.obteneraleatorio();
                string sig = exc.siguiente("ex_aleatorio", "codexaleatorio");
                string insertarasignado = "INSERT INTO `ex_aleatorio`(`codexaleatorio`, `asignado`, `numero`, `estado`, `fecha`) VALUES ('" + sig+"','"+mensajero.SelectedValue+"','"+aleatorio+"', 1, '"+fechaactual+"')";
                exc.Insertar(insertarasignado);



                cod.InnerText = aleatorio;

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Seleccione al mensajero')", true); }
           
        }
        protected void envio_Click(object sender, EventArgs e)
        {//entrada

            if (name.Text != "" || txtname.Text != "" || LOTEARCHIVO.Text != "" || LOTEENTREGA.Text !="")
            {
                //entrada recibido mensajeria
                if (name.Text != "")
                {
                    //estado recibido y etapa 1 bitacora

                    string verifica = mex.lotevalidado(name.Text);
                    switch (verifica)
                    {

                        case "0":
                            DataTable dt4 = new DataTable();
                            dt4 = mex.lotesinfo(name.Text);
                            if (dt4.Rows.Count != 0)
                            {
                                for (int i = 0; i < dt4.Rows.Count; i++)
                                {

                                    string numeroenv = dt4.Rows[i]["codexenvio"].ToString();
                                    string codexp = exc.obtenercodexp(dt4.Rows[i]["Nocredito"].ToString());
                                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");

                                    string updatelote = "UPDATE `ex_loteenvio` SET  `estado`= 1 WHERE numerolote = '" + name.Text + "' ";
                                    exc.Insertar(updatelote);
                                    string updateenviolote = "UPDATE `ex_envio` SET `estado`= 1,`codexetapa`= 2 WHERE codexenvio = '" + numeroenv + "' ";
                                    exc.Insertar(updateenviolote);

                                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 1, 2 );";
                                    exc.Insertar(bitacora);
                                    name.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                                }
                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }
                            break;

                        case "1":
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Este Lote Ya Fué Recibido en mensajeria')", true);
                            name.Text = "";
                            break;

                        default:
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote no existe')", true);

                            break;

                    }




                }

                //entregao en mesa
                if (LOTEENTREGA.Text !="") {

                    string verifica = mex.lotevalidado(LOTEENTREGA.Text);
                    switch (verifica)
                    {

                        case "1":
                            DataTable dt4 = new DataTable();
                            dt4 = mex.lotesinfo(LOTEENTREGA.Text);
                            if (dt4.Rows.Count != 0)
                            {
                                for (int i = 0; i < dt4.Rows.Count; i++)
                                {

                                    string numeroenv = dt4.Rows[i]["codexenvio"].ToString();
                                    string codexp = exc.obtenercodexp(dt4.Rows[i]["Nocredito"].ToString());
                                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");

                                    string updatelote = "UPDATE `ex_loteenvio` SET  `estado`= 2 WHERE numerolote = '" + LOTEENTREGA.Text + "' ";
                                    exc.Insertar(updatelote);
                                    string updateenviolote = "UPDATE `ex_envio` SET `estado`= 9,`codexetapa`= 2 WHERE codexenvio = '" + numeroenv + "' ";
                                    exc.Insertar(updateenviolote);

                                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 9, 2 );";
                                    exc.Insertar(bitacora);
                                    LOTEENTREGA.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                                }
                            }
                            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }
                            break;

                        case "2":
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Este Lote Ya Fué Entregado a Mesa de Control')", true);
                            LOTEENTREGA.Text = "";
                            break;

                        default:
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote no existe')", true);

                            break;

                    }



                }

                //recibido el de salida de mesa
                if (LOTEARCHIVO.Text != "") {

                    //estado recibido y etapa 1 bitacora
                    string verifica = mex.lotevalidado2(LOTEARCHIVO.Text).Trim();
                    switch (verifica)
                    {

                        case "0":
                            DataTable dt4 = new DataTable();
                            dt4 = mex.lotesinfo2(LOTEARCHIVO.Text);
                            if (dt4.Rows.Count != 0)
                            {
                                for (int i = 0; i < dt4.Rows.Count; i++)
                                {

                                    string numeroenv = dt4.Rows[i]["codexp"].ToString();
                                    string codexp = exc.obtenercodexp(dt4.Rows[i]["codgencred"].ToString());
                                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");

                                    string updatelote = "UPDATE `ex_lotesalida` SET  `estado`= 1 WHERE numerolote = '" + LOTEARCHIVO.Text + "' ";
                                    exc.Insertar(updatelote);
                                    string updateenviolote = "UPDATE `ex_envio` SET `estado`= 1,`codexetapa`= 6 WHERE codexenvio = '" + numeroenv + "' ";
                                    exc.Insertar(updateenviolote);

                                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 1, 5 );";
                                    exc.Insertar(bitacora);
                                    LOTEARCHIVO.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                                }
                            }
                            else { LOTEARCHIVO.Text = ""; ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }



                            break;
                        case "1":
                            LOTEARCHIVO.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El Lote Ya Fué Recibido de Mesa')", true);

                            break;

                        default:
                            LOTEARCHIVO.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote no Existe')", true);
                            break;


                    }

                }




             
                //salida al archivo enviado
                if (txtname.Text != "")
                {
                    //estado recibido y etapa 1 bitacora
                    string verifica = mex.lotevalidado2(txtname.Text).Trim();
                    switch (verifica) {

                        case "1":
                            DataTable dt4 = new DataTable();
                            dt4 = mex.lotesinfo2(txtname.Text);
                            if (dt4.Rows.Count != 0)
                            {
                                for (int i = 0; i < dt4.Rows.Count; i++)
                                {

                                    string numeroenv = dt4.Rows[i]["codexp"].ToString();
                                    string codexp = exc.obtenercodexp(dt4.Rows[i]["codgencred"].ToString());
                                    string sigbit = exc.siguiente("ex_bitacora", "codexbit");

                                    string updatelote = "UPDATE `ex_lotesalida` SET  `estado`= 2 WHERE numerolote = '" + txtname.Text + "' ";
                                    exc.Insertar(updatelote);
                                    string updateenviolote = "UPDATE `ex_envio` SET `estado`= 2,`codexetapa`= 6 WHERE codexenvio = '" + numeroenv + "' ";
                                    exc.Insertar(updateenviolote);

                                    string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 6, 5 );";
                                    exc.Insertar(bitacora);
                                    txtname.Text = "";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                                }
                            }
                            else { txtname.Text = ""; ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }


                          
                            break;
                        case "2":
                            txtname.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El Lote Ya Fué Validado y Enviado Al Archivo')", true);
                            
                            break;
                    
                        default:
                            txtname.Text = "";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El lote no Existe')", true);
                            break;
                      

                    }



                }
         

            }

            else
            {
                txtname.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Aún no ingresa el Número de lote')", true); }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            name.Enabled = true;
            LOTEENTREGA.Enabled = false;
            txtname.Enabled = false;
            LOTEARCHIVO.Enabled = false;
            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            LOTEARCHIVO.Text = "";
            LOTEENTREGA.Text = "";
            txtname.Text = "";
            name.Text = "";


        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LOTEENTREGA.Enabled = true;
            LOTEARCHIVO.Enabled = false;
            txtname.Enabled = false;
            name.Enabled = false;
            RadioButton1.Checked = false;
            RadioButton2.Checked = true;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            LOTEARCHIVO.Text = "";
            LOTEENTREGA.Text = "";
            txtname.Text = "";
            name.Text = "";

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtname.Enabled = false;
            LOTEENTREGA.Enabled = false;
            LOTEARCHIVO.Enabled = true;
            name.Enabled = false;
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = true;
            RadioButton4.Checked = false;
            LOTEARCHIVO.Text = "";
            LOTEENTREGA.Text = "";
            txtname.Text = "";
            name.Text = "";

        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            LOTEARCHIVO.Enabled = false;
            LOTEENTREGA.Enabled = false;
            txtname.Enabled = true;
            name.Enabled = false;
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = true;

            LOTEARCHIVO.Text = "";
            LOTEENTREGA.Text = "";
            txtname.Text = "";
            name.Text = "";

        }

     

        protected void asignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnvis.Visible = true;

        }

        protected void btncerrar(object sender, EventArgs e)
        {

            Response.Redirect("../../Index.aspx");
        }
        protected void btninicio_click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }
    }
}