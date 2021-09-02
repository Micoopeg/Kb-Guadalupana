using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_GenExpedientes : System.Web.UI.Page
    {
        string usernombre, nombrepersona, ean;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        string coduser, verifica, fechamin, horamin, fechahora;
        char delimitador2 = ' ';
        ControladorEX exc = new ControladorEX();
        ModeloEX mex = new ModeloEX();
        protected void Page_Load(object sender, EventArgs e)
        {
            usernombre = Convert.ToString(Session["sesion_usuario"] );
            nombrepersona = Convert.ToString(Session["Nombre"]);
            //ean = Convert.ToString(Session["EAN"]);

           
            

            if (usernombre != "")
            {
                coduser = exc.obtenercoduser(usernombre);




                string contador = exc.tablavacia("ex_expediente");
                string ultimoasig = exc.siguiente("ex_expediente","ex_ean13");

                string excontrolean = exc.buscaeanigual(ultimoasig);

                if (excontrolean != "") {

                    NOEXP.Value = Convert.ToString(excontrolean);

                }
                if (contador == "0") {


                    NOEXP.Value = "1000000000001";


                }
                


                if (!IsPostBack)
                {

                    llenarcombotipocred();
                }
            }
            else {
                Response.Redirect("../Session/MenuBarra.aspx");
            
            }


        }



        public long Asignarean() {

            long ean13 = Convert.ToInt64(exc.ultimo("ex_ean13ctrl", "codexan13"));


            return ean13;





        }
        public void procesoasignar() {

            long eanasig = Asignarean();

            string sql3 = "INSERT INTO ex_ean13ctrl VALUES ( " + eanasig + " ,1)";

            exc.Insertar(sql3);

        }

        protected void tipoex(object sender, EventArgs e) {
            if (DropDownTipocredito.SelectedIndex == 4)
            {

                MONTO.Disabled = true;

            }
            else {
                MONTO.Disabled = false;
            }

        }

        public string fechabitacora()
        {

            string[] fecha = mex.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] +" "+ horamin;



                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }
            return fechahora;

        }
        protected void btngenerar_Click(object sender, EventArgs e) {


            if (DropDownTipocredito.SelectedIndex != 0) {
                Asociadoinsert();
                nuevoexp();
                

            }




        }
        public void llenarcombotipocred()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {

                    sqlCon.Open();
                    string QueryString = "select * from ex_tipocredito;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Credito");
                    DropDownTipocredito.DataSource = ds;
                    DropDownTipocredito.DataTextField = "ex_nomtipo";
                    DropDownTipocredito.DataValueField = "codextipocred";
                    DropDownTipocredito.DataBind();
                    DropDownTipocredito.Items.Insert(0, new ListItem("[Tipo Expediente]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        //public void llenarcomboenvio()
        //{


        //    using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string QueryString = "select * from ex_tipocredito;";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds, "Credito");
        //            DropDownenvio.DataSource = ds;
        //            DropDownenvio.DataTextField = "ex_tipocredito";
        //            DropDownenvio.DataValueField = "codextipocred";
        //            DropDownenvio.DataBind();
        //            DropDownenvio.Items.Insert(0, new ListItem("[Tipo Expediente]", "0"));
        //        }
        //        catch { Console.WriteLine("Verifique los campos"); }
        //    }
        //}
        public void nuevoexp() {
           

            if (DropDownTipocredito.SelectedIndex != 4) {
                string cod =  exc.obtenercodporcif(CIFN.Value);
                long ean = Asignarean();
                
                procesoasignar();
                if (cod != "")
                {
                    string sig1 = exc.siguiente("ex_creditos", "codexp");
                 
                    string sql1 = "INSERT INTO ex_creditos VALUES ('" + sig1 + "','" + cod + "','" + MONTO.Value + "',0, "+NCRED.Value+" )";

                    exc.Insertar(sql1);
                    string codncred = exc.obtenercodncred(NCRED.Value);


                    string sig = exc.siguiente("ex_expediente", "codexp");

                    string sql = "INSERT INTO `ex_expediente`(`codexp`, `codexcrd`, `codusuario`, `ex_ean13`, `codextipocred`, `ex_comentario`, `ex_tipoevento`) VALUES ('"+sig+"','"+codncred+"','"+coduser+"','"+NOEXP.Value+"','"+DropDownTipocredito.SelectedIndex+"','"+DESCRIP.Value+"', '7');";

                    exc.Insertar(sql);

                    ExBitacora(sig);

                }
                else {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Numero de CIF invalido ')", true);
                }
               
            }

        }
        public void Asociadoinsert(){
            string cod = exc.obtenercodporcif(CIFN.Value);

            if (cod == "")
            {
                string sig = exc.siguiente("ex_asociado", "codexasociado");

                string sql = "INSERT INTO `ex_asociado`(`codexasociado`, `ex_cif`, `ex_pnombre`, `ex_snombre`, `ex_papell`, `ex_sapell`) VALUES ('" + sig + "','" + CIFN.Value + "','" + PNOMBRE.Value + "','" + SNOMBRE.Value + "','" + PAPELL.Value + "','" + SAPELL.Value + "');";

                exc.Insertar(sql);
            }
          

        }
        public void ExBitacora(string ex) {

            string sig = exc.siguiente("ex_bitacora","codexbit");
            string date = fechabitacora();
            string sql4 = "INSERT INTO ex_bitacora (codexbit, codexp, ex_fechaev, codusuario, codexevento) VALUES ('"+sig+"','"+ex+"', '"+date+"', '"+coduser+"', '7');";
            exc.Insertar(sql4);


        
        
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Sesion/MenuBarra.aspx");

        }

        protected void btnEXGEN_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_Principal.aspx");

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_GenExpedientes.aspx");

        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ex_pendienteAg.aspx");

        }
    }
}