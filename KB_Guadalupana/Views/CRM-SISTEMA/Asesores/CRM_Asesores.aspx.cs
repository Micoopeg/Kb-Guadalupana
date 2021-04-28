using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI; 
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace CRM_Guadalupana.Views.CRM_SISTEMA.Asesores
{
    public partial class CRM_Asesores : System.Web.UI.Page
    {

        string key = "millave";
       // OleDbConnection oledbConn;
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        string nombreusuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["controlingreso"] = controlingresocrm;            
            //Session["sucurusalcrm"] = sucurusalcrm;
            // roldelcrm = Convert.ToString(Session["roldelcrm"]);
            nombreusuario = Convert.ToString(Session["usuariodelcrm"]);
            int rolusuario = Convert.ToInt32(Session["roldelcrm"]);
            if (rolusuario ==3 || rolusuario == 6)
            {
                
            }
            else
            {
                String script = "alert('El usuario " + nombreusuario + " no tiene permisos para accer al sitio web consultar con el departamento de informática '); window.location.href= '../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }        

            if (!IsPostBack){                
                llenarcombotiposervicio();
                llenarcontactollamada();
                llenarsemaforo();
                llenartipodomicilio();
               llenarsucursalmascercana();
            }
            llenargridviewprospecto(nombreusuario);
            llenargrafico2();
            llenargrafico3();
        }


        public void llenargrafico2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT b.crmsemaforo_estadonombre,b.crmsemaforo_estadodescripcion,COUNT(a.codcrmsemaforoestado) AS Cantidad  FROM crminfo_prospecto a INNER JOIN crmsemaforo_estado b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrmsemaforoestado=b.codcrmsemaforoestado AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso where crmcontrol_ingresousuario='"+nombreusuario+"' group by a.codcrmsemaforoestado  order by crmsemaforo_estadonombre ASC;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "grafica");
                    Chart1.Titles.Clear();
                    Chart1.Series.Clear();
                    Chart1.ChartAreas.Clear();
                    // Chart1.DataSource = ds;
                    ChartArea agregargrafico = new ChartArea();
                    agregargrafico.Area3DStyle.Enable3D = true;
                    Chart1.ChartAreas.Add(agregargrafico);
                    Series seriedatos = new Series("codcrmsemaforoestado");
                    seriedatos.ChartType = SeriesChartType.Pie;
                    seriedatos.XValueMember = "crmsemaforo_estadodescripcion";
                    seriedatos.YValueMembers = "Cantidad";
                    seriedatos.IsValueShownAsLabel = true;
                    Chart1.Series.Add(seriedatos);
                    Chart1.DataSource = ds;


                  }
                catch
                {
                    Console.WriteLine("Verifique los campos");
                }
            }


        }

        public void llenargrafico3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT a.codcrmcontrolingreso,COUNT(a.codcrmcontrolingreso) AS Cantidad FROM crmalertas_programadas a INNER JOIN crmcontrol_ingreso b ON a.codcrmcontrolingreso=b.codcrmcontrolingreso where crmcontrol_ingresousuario='"+nombreusuario+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "grafica2");
                    //Chart2.Titles.Clear();
                    //Chart2.Series.Clear();
                    //Chart2.ChartAreas.Clear();
                    // Chart1.DataSource = ds;
                    ChartArea agregargrafico = new ChartArea();
                   // agregargrafico.Area3DStyle.Enable3D = true;
                    Chart2.ChartAreas.Add(agregargrafico);
                    Series seriedatos = new Series("codcrmcontrolingreso");
                    seriedatos.XValueMember = "codcrmcontrolingreso";
                    seriedatos.YValueMembers = "Cantidad";
                    Chart2.Series.Add(seriedatos);
                    Chart2.DataSource = ds;


                }
                catch
                {
                    Console.WriteLine("Verifique los campos");
                }
            }


        }



        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label2.Text = "2";
            Response.Write("2");
        }

        protected void Btn_crearalerta_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('CRM_Asesores.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
            logic.bitacoraingresoprocedimientos(nombreusuario, "CRM", "Aplicación Asesores", "Creación de alerta");
        }

        public void llenargridviewprospecto(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select a.codcrminfoprospecto,a.codcrminfogeneralprospecto,b.crminfogeneral_prospectodpi,b.crminfogeneral_prospectonombrecompleto,a.crminfo_prospectotelefono,a.crminfo_prospectoemail,a.crminfo_prospectoingresos,a.crminfo_prospectoegresos,a.crminfo_prospectoañoslaborados,a.crminfo_prospectotrabajaactualmente,a.crminfo_prospectodescripciontrabajoactual,a.codcrmtiposervicio,a.crminfo_prospectomonto,a.codcrmfinalidadservicio,a.codcrmcontactollamadas,a.crminfo_prospectofechaprimerllamada,a.crminfo_prospectofechaultimallamada,a.codcrmsemaforoestado,a.codcrmestadodescripcion,a.crminfo_prospectocuentaconigss,a.codcrmtipodomicilio,a.crminfo_prospectoañosdomicilio,a.crminfo_prospectocuentaencooperativa,a.crminfo_prospectosucursalcerca,a.crminfo_prospectodescripcion,a.crminfo_contactadopor,a.crminfo_prospectoreferenciado FROM crminfo_prospecto a INNER JOIN crminfogeneral_prospecto b INNER JOIN crmcontrol_prospecto_agente c INNER JOIN crmcontrol_ingreso d ON a.codcrminfogeneralprospecto=b.codcrminfogeneralprospecto AND c.codcrminfoprospecto=a.codcrminfoprospecto AND c.codcrmcontrolingreso=d.codcrmcontrolingreso WHERE d.crmcontrol_ingresousuario='" + usuario + "' AND codcrmsemaforoestado!=4 OR codcrmsemaforoestado!=1;";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewprospectos.DataSource = ds3;
                    gridviewprospectos.DataBind();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }
        protected void OnSelectedIndexChangedprospectos(object sender, EventArgs e)
        {          

            GridViewRow row = gridviewprospectos.SelectedRow;
            txtnumerogeneral.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcodigo") as Label).Text);
            txtnumeroderegistro.Value=Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcodigogeneralprospecto") as Label).Text);
            txtnumerodpi.Value= Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbldpi") as Label).Text);
            txtnombrecompleto.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblnombre") as Label).Text);
            txttelefono.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbltelefono") as Label).Text);
            txtemail.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcorreo") as Label).Text);
            txtingreso.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblingresos") as Label).Text);
            txtegresos.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblegresos") as Label).Text);
            txtañoslaborados.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblañoslaborados") as Label).Text);
            combotienetrabajo.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbltabajaactualmente") as Label).Text);
            txttabajoactual.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbldescripciondeltrabajo") as Label).Text);
            combotiposervicio.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblservicio") as Label).Text);

            txtmonto.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblmonto") as Label).Text);         
                 
           combocontactollamadas.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcontactollamada") as Label).Text);
            string fecha = string.Format("{0:yyyy-MM-dd}", (gridviewprospectos.SelectedRow.FindControl("lblprimerallamada") as Label).Text);
            txtfechainicio.Value = fecha.Trim();
            string fecha2 = string.Format("{0:yyyy-MM-dd}", (gridviewprospectos.SelectedRow.FindControl("lblultimallamada") as Label).Text);
            txtfechafin.Value = fecha2.Trim();       
            combosemaforoestado.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblsemaforoestado") as Label).Text);         
            
            combocuentaigss.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbligss") as Label).Text);         
            combotipodomicilio.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbltipodomicilio") as Label).Text);
            txtañodomicilio.Value= Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblañosendomicilio") as Label).Text);
            comboposeecuentacoope.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcuentaencoope") as Label).Text);
            combosucursalmascerca.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblsucursalcercana") as Label).Text);
            exampleFormControlTextarea1.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbldescripcion") as Label).Text);
            txtdpireferencia.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lbldpireferencia") as Label).Text);
            llenarcombofinalidadservicio(long.Parse(combotiposervicio.SelectedValue));
            combofinalidaddeservicio.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblfinalidadservicio") as Label).Text);
            txtcontactadopor.Value = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblcontactado") as Label).Text);

            llenarcombosemaforodescripcion(long.Parse(combosemaforoestado.SelectedValue));
            combosemaforodescripcion.SelectedValue = Convert.ToString((gridviewprospectos.SelectedRow.FindControl("lblsemaforodescripcion") as Label).Text);
            int num = Convert.ToInt32(combosemaforoestado.SelectedValue);
            switch (num)
            {
                case 0:
                    txtcolorestado.BackColor = Color.Gray;
                    break;
                case 1:
                    //verde
                    txtcolorestado.BackColor = Color.Green;
                    break;
                case 2:
                    //amarillo
                    txtcolorestado.BackColor = Color.Yellow;
                    break;
                case 3:
                    //naranja
                    txtcolorestado.BackColor = Color.Orange;
                    break;
                case 4:
                    //rojo
                    txtcolorestado.BackColor = Color.Red;
                    break;


                    
            }
            txtnumerodpi.Focus();
        }

        public void llenarcombotiposervicio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmtipo_servicio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tiposervicio");
                    combotiposervicio.DataSource = ds;
                    combotiposervicio.DataTextField = "crmtipo_servicionombre";
                    combotiposervicio.DataValueField = "codcrmtiposervicio";
                    combotiposervicio.DataBind();
                    combotiposervicio.Items.Insert(0, new ListItem("[Tipo de servicio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombofinalidadservicio(long codtiposervicio)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crm_finalidadservicio where codcrmtiposervicio='" + codtiposervicio+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "finalidadservicio");
                    combofinalidaddeservicio.DataSource = ds;
                    combofinalidaddeservicio.DataTextField = "crm_finalidaddescripcion";
                    combofinalidaddeservicio.DataValueField = "codcrmfinalidadservicio"; 
                    combofinalidaddeservicio.DataBind();
                    combofinalidaddeservicio.Items.Insert(0, new ListItem("[Seleccione la finalidad del servicio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcontactollamada()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmcontacto_llamadas;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "contactollaamada");
                    combocontactollamadas.DataSource = ds;
                    combocontactollamadas.DataTextField = "crmcontacto_llamadasnombre";
                    combocontactollamadas.DataValueField = "codcrmcontactollamadas";
                    combocontactollamadas.DataBind();
                    combocontactollamadas.Items.Insert(0, new ListItem("[Estado de la llamada]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarsemaforo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmsemaforo_estado;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "semaforo");
                    combosemaforoestado.DataSource = ds;
                    combosemaforoestado.DataTextField = "crmsemaforo_estadonombre";
                    combosemaforoestado.DataValueField = "codcrmsemaforoestado";
                    combosemaforoestado.DataBind();
                    combosemaforoestado.Items.Insert(0, new ListItem("[Seleccione el color]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenartipodomicilio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmtipo_domicilio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipodomicilio");
                    combotipodomicilio.DataSource = ds;
                    combotipodomicilio.DataTextField = "crmtipo_domicilionombre";
                    combotipodomicilio.DataValueField = "codcrmtipodomicilio";
                    combotipodomicilio.DataBind();
                    combotipodomicilio.Items.Insert(0, new ListItem("[Tipo de domicilio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarsucursalmascercana()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "Select * FROM crm_genagencias where crm_genagenciasnombre !='telemercadeo';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "sucursal");
                    combosucursalmascerca.DataSource = ds;
                    combosucursalmascerca.DataTextField = "crm_genagenciasnombre";
                    combosucursalmascerca.DataValueField = "codcrmgenagencias";
                    combosucursalmascerca.DataBind();
                    combosucursalmascerca.Items.Insert(0, new ListItem("[¿Sucrusal más cercana?]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombosemaforodescripcion(long codestadosemaforo)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from crmestado_descripcion where codcrmsemaforoestado='" + codestadosemaforo + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "descripcionestado");
                    combosemaforodescripcion.DataSource = ds;
                    combosemaforodescripcion.DataTextField = "crmestado_descripcionnombre"; 
                    combosemaforodescripcion.DataValueField = "codcrmestadodescripcion";
                    combosemaforodescripcion.DataBind();
                    combosemaforodescripcion.Items.Insert(0, new ListItem("[Motivo del estado]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        protected void tiposervicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombofinalidadservicio(long.Parse(combotiposervicio.SelectedValue));
            combocuentaigss.Focus();
        }
        protected void seleccionsemaforo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(combosemaforoestado.SelectedValue);
            switch (num)
            {
                case 0:
                    txtcolorestado.BackColor = Color.Gray;
                    break;
                case 1:
                    //verde
                    txtcolorestado.BackColor = Color.Green;
                    break;
                case 2:
                    //amarillo
                    txtcolorestado.BackColor = Color.Yellow;
                    break;
                case 3:
                    //naranja
                    txtcolorestado.BackColor = Color.Orange;
                    break;
                case 4:
                    //rojo
                    txtcolorestado.BackColor = Color.Red;
                    break;

            }
            exampleFormControlTextarea1.Focus();

            llenarcombosemaforodescripcion(long.Parse(combosemaforoestado.SelectedValue));
            SetFocus(exampleFormControlTextarea1);
        }


        /*FUNCIO DE ENCRIPTAICON PARA PARAMETROS*/
        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        protected void Btn_abriralerta_Click(object sender, EventArgs e)
        {
            string str;
            string datoencriptado = Encriptar(nombreusuario);
            str = "window.open('../Agenda/CRM_Agenda.aspx?Nombre="+ datoencriptado + "','Titulo','width=350,height=400,sc rollbars=no,resizable=no')";
            Response.Write("<script languaje=javascript>" + str + "</script>");
        }

        protected void Btn_Guardarprospecto_Click(object sender, EventArgs e)
        {
            if (txtnumerodpi.Value == "" || txtnombrecompleto.Value=="" || txttelefono.Value == "" ||
                txtemail.Value == "" || txtingreso.Value == ""||txtegresos.Value==""||txtañoslaborados.Value==""||combotienetrabajo.SelectedValue=="0"||
                txttelefono.Value==""||combotiposervicio.SelectedValue=="0"||txtmonto.Value==""||combofinalidaddeservicio.Value=="0"||combocontactollamadas.SelectedValue=="0"||
                txtfechainicio.Value==""||txtfechafin.Value==""||combosemaforoestado.SelectedValue=="0"||combosemaforodescripcion.SelectedValue=="0"||
                combocuentaigss.SelectedValue=="0"||combotipodomicilio.SelectedValue=="0"||txtañodomicilio.Value==""||comboposeecuentacoope.SelectedValue=="0"||
                combosucursalmascerca.SelectedValue=="0")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] campos = { "codcrminfoprospecto", "codcrminfogeneralprospecto", "codcrmtiposervicio",
                    "codcrmcontactollamadas","codcrmsemaforoestado","codcrmestadodescripcion",
                    "codcrmtipodomicilio","codcrmfinalidadservicio","crminfo_prospectotelefono","crminfo_prospectoemail",
                    "crminfo_prospectoingresos","crminfo_prospectoegresos","crminfo_prospectomonto","crminfo_prospectoañoslaborados",
                    "crminfo_prospectotrabajaactualmente","crminfo_prospectodescripciontrabajoactual","crminfo_prospectofechaprimerllamada",
                    "crminfo_prospectofechaultimallamada","crminfo_prospectodescripcion","crminfo_prospectosucursalcerca","crminfo_prospectocuentaconigss",
                    "crminfo_prospectoañosdomicilio","crminfo_prospectocuentaencooperativa","crminfo_prospectoreferenciado"};
                string[] valores = {txtnumerogeneral.Value,txtnumeroderegistro.Value,combotiposervicio.SelectedValue,
                    combocontactollamadas.SelectedValue,combosemaforoestado.SelectedValue,combosemaforodescripcion.SelectedValue,
                    combotipodomicilio.SelectedValue,combofinalidaddeservicio.Value,txttelefono.Value,txtemail.Value,txtingreso.Value,txtegresos.Value,
                    txtmonto.Value,txtañoslaborados.Value,combotienetrabajo.SelectedValue,txttabajoactual.Value,txtfechainicio.Value,txtfechafin.Value,
                    exampleFormControlTextarea1.Value,combosucursalmascerca.SelectedValue,combocuentaigss.SelectedValue,
                    txtañodomicilio.Value,comboposeecuentacoope.SelectedValue,txtdpireferencia.Value };

                string[] campos1 = { "codcrminfogeneralprospecto", "crminfogeneral_prospectodpi", "crminfogeneral_prospectonombrecompleto"};
                string[] valores1 = {txtnumeroderegistro.Value,txtnumerodpi.Value,txtnombrecompleto.Value };                
                try
                {
                   logic.modificartablas("crminfo_prospecto", campos, valores);
                   logic.modificartablas("crminfogeneral_prospecto", campos1, valores1);
                    logic.bitacoraingresoprocedimientos("usuario", "CRM", "Aplicación Asesores", "Modificado de un prospecto - Correlativo : '"+txtnumerodpi.Value+"'");
                }
                catch {
                    Console.WriteLine("dejo de funcionar");
                }
                llenargridviewprospecto(nombreusuario);
                txtnumerogeneral.Value = "";
                txtnumeroderegistro.Value = ""; combotiposervicio.SelectedValue = "0";
                combocontactollamadas.SelectedValue = "0";
                combosemaforoestado.SelectedValue = "0";
                combosemaforodescripcion.SelectedValue = "0";
                combotipodomicilio.SelectedValue = "0";
                combofinalidaddeservicio.Value = "0";
                txttelefono.Value = ""; txtemail.Value = "";
                txtingreso.Value = "";
                txtegresos.Value = "";
                txtmonto.Value = "";
                txtañoslaborados.Value = "";
                combotienetrabajo.SelectedValue = "0";
                txttabajoactual.Value = "0";
                txtfechainicio.Value = ""; txtfechafin.Value = "";
                exampleFormControlTextarea1.Value = "0";
                combosucursalmascerca.SelectedValue = "0";
                combocuentaigss.SelectedValue = "0";
                combotipodomicilio.SelectedValue = "0";
                comboposeecuentacoope.SelectedValue = "0";
                txtnumeroderegistro.Value = "";
                txtnumerodpi.Value = "";
                txtnombrecompleto.Value = "";
                txtañodomicilio.Value = "";
                exampleFormControlTextarea1.Value = "";
                txtcontactadopor.Value = "";
                txtdpireferencia.Value = "";
            }

        }


    }
}