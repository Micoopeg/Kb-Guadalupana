using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Ingresodata
{
   
    public partial class CRM_Ingresodedatos : System.Web.UI.Page
    {
        string usuarioglobal;
        CRM_Logica logic = new CRM_Logica();
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Conexion cn =  new CRM_Conexion(); 
        string registrodpiremplazable = "0"; //remplazable dpi en el ingreso de los datos
        string dpiguardar = "";
        DateTime fechaactual; //FECHA PARA VLAIDACIONES DE NO ESTAR VACIO EL CAMPO
        public bool validardatosdesesion() {


            string usuario = Convert.ToString(Session["usuariodelcrm"]);
            int rol = Convert.ToInt32(Session["roldelcrm"]);
            string sucursal = Convert.ToString(Session["sucurusalcrm"]);
            usuarioglobal = usuario;
            if (rol == 1 || rol == 6 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (validardatosdesesion()==true)
            {
               // Response.Write("Logro entrar");
               if (!IsPostBack)
                {                 
                    btngridview.Visible = false;
                    GridView1.Visible = false;
                    btnaceptar.Visible = false;
                    Chkautorizar.Visible = false;                    
                }
               
            }
            else
            {
                String script = "alert('El usuario "+usuarioglobal+ " no tiene permisos para acceder al sitio web consultar con el departamento de informática '); window.location.href= '../../../Index.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }

        

        }

        bool ChecarExtension(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".csv":
                    return true;
                default:
                    return false;
            }
        }

        bool verificararchivoconmismonombre(string fileName)
        {
            string ext = Path.GetFileName(fileName);
            if (File.Exists(MapPath("Archivos/" + ext)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable CrearTabla(String fila)
        {
            int cantidadColumnas;
            DataTable tabla = new DataTable("Datos");
            String[] valores = fila.Split(new char[] { ';' });
            cantidadColumnas = valores.Length;
            int idx = 0;
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
            }
            return tabla;
        }

        private DataRow AgregarFila(String fila, DataTable tabla)
        {
            int cantidadColumnas = 100;
            String[] valores = fila.Split(new char[] { ';' });
            Int32 numeroTotalValores = valores.Length;
            if (numeroTotalValores > cantidadColumnas)
            {
                Int32 diferencia = numeroTotalValores - cantidadColumnas;
                for (Int32 i = 0; i < diferencia; i++)
                {

                    String nombreColumna = String.Format("{0}", (cantidadColumnas + i));
                    tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
                }
                cantidadColumnas = numeroTotalValores;
            }
            int idx = 0;
            DataRow dfila = tabla.NewRow();
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                dfila[nombreColumna] = val.Trim();
            }
            tabla.Rows.Add(dfila);
            return dfila;
        }
        private void CargarDatos(string strm)
        {
            DataTable tabla = null;
            StreamReader lector = new StreamReader(strm);
            String fila = String.Empty;
            Int32 cantidad = 0;
            do
            {
                fila = lector.ReadLine();
                if (fila == null)
                {
                    break;
                }
                if (0 == cantidad++)
                {
                    tabla = this.CrearTabla(fila);
                }
                this.AgregarFila(fila, tabla);
            } while (true);

            GridView1.DataSource = tabla;
            GridView1.DataBind();
           
        }

        protected void btncargardatos_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (ChecarExtension(FileUpload1.FileName))
                {
                    if (verificararchivoconmismonombre(FileUpload1.FileName) == false)
                    {
                        FileUpload1.SaveAs(MapPath("Archivos/" + FileUpload1.FileName));
                        Label1.Text = FileUpload1.FileName + " cargado exitosamente";
                        lblOculto.Text = MapPath("Archivos/" + FileUpload1.FileName);
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "Ya se encuentra un archivo con el mismo nombre";
                        btngridview.Visible = false;
                    }
                }
                else
                {
                    Label1.Text = "Error al subir el archivo o no es el tipo .CSV";
                }
            }
            else
            {
                Label1.Text = "Error al subir el archivo o no es el tipo .CSV";
            }
            btngridview.Visible = true;
            FileUpload1.Visible = false;
            btncargardatos.Visible = false;
            //leergridview();

        }



        protected void btnmostrardatos_Click(object sender, EventArgs e)
        {
            try
            {

                 CargarDatos(lblOculto.Text);              
                 ingresargridviewbd();
                 PopulateGridview();
                FileUpload1.Visible = false;
                btncargardatos.Visible = false;
                btngridview.Visible = false;
                btnaceptar.Visible = true;
                Chkautorizar.Visible = true;
            }
            catch
            {
                Response.Write("Ocurrio un error debe verificar que los campos se encuentren como se muestran en el manual y subirlo con otro nombre");
            }
        }

        protected void btnguardarenbasededatos_Click(object sender, EventArgs e)
        {
            if (Chkautorizar.Checked==true)
            {
                Ingresaryasignarprospectos();
                logic.eliminadoderegistrosprotegida("crmtamporal_cargadedatos");
                String script = "alert('Los datos han sido procesados correctamente'); window.location.href='../MenuPrincipal/CRM_MenuPrincipal.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                logic.bitacoraingresoprocedimientos(usuarioglobal, "CRM", "ingreso de datos", "Alimentación de CRM - Excel importado: '"+FileUpload1.FileName+"' ");
            }
            else
            {
                String script = "alert('Verfique si  la opcion de Autorizar Envío se encuentra marcada')";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                logic.bitacoraingresoprocedimientos(usuarioglobal, "CRM", "ingreso de datos", "Fallo envio - Excel importado: '" + FileUpload1.FileName + "' ");
            }

            PopulateGridview();

        }

        public void ingresargridviewbd()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                double cantidaddecimal = 0;
                string fecha = row.Cells[0].Text;
                string nombre = row.Cells[1].Text;
                string telefono = row.Cells[2].Text;
                string correo = row.Cells[3].Text;
                string dpi = row.Cells[4].Text;
                string cantidad = row.Cells[5].Text;
                string finalidad = row.Cells[6].Text;
                string zona = row.Cells[7].Text;
                string tiposervicio = row.Cells[8].Text;
                string contacto = row.Cells[9].Text;
                if (row.Cells[0].Text == "Fecha" || row.Cells[1].Text == "Nombre" ||
                    row.Cells[2].Text == "Teléfono" || row.Cells[3].Text == "Correo" ||
                    row.Cells[4].Text == "DPI" || 
                    row.Cells[5].Text == "Cantidad" || row.Cells[6].Text == "Finalidad" ||
                    row.Cells[7].Text == "Zona" || row.Cells[8].Text == "Tipo de servicio" ||
                    row.Cells[9].Text == "Contacto")
                {
                    /// PARA EVITAR EL PRIMER CAMPO
                }
                else
                {
                    
                    string sig = logic.siguiente("crmtamporal_cargadedatos", "codcrmtamporalcargadedatos");
                    string[] valores1 = { sig,fecha,nombre,telefono,correo,dpi,cantidad,finalidad,zona,tiposervicio,contacto };
                     logic.insertartablas("crmtamporal_cargadedatos", valores1);

                }

            }
        }

        /*PARA MOSTRAR UN GRID MODIFICABLE*/

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM crmtamporal_cargadedatos;", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No se encontro datos revisar si el archivo se subio con el formato correcto ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Response.Write("SE REQUIERE ELEVACCÓN EN LA APLICACIÓN");
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;

            PopulateGridview();

        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
                {
                    sqlCon.Open();
                    string query = "UPDATE crmtamporal_cargadedatos SET crmtamporal_cargadedatosfecha=@fecha,crmtamporal_cargadedatosnombre=@nombrecompleto," +
                        "crmtamporal_cargadedatostelefono=@telefono,crmtamporal_cargadedatoscorreo=@correo,crmtamporal_cargadedatosdpi=@dpi," +
                        "crmtamporal_cargadedatoscantidad=@monto,crmtamporal_cargadedatosfinalidad=@finalidad,crmtamporal_cargadedatoszona=@zona,crmtamporal_cargadedatotiposervicio=@tipodeservicio," +
                        "crmtamporal_cargadedatocontactadopor=@contactadopor WHERE codcrmtamporalcargadedatos = @numeroregistro";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@fecha", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtfecha") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@nombrecompleto", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtnmombrecompleto") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@telefono", (gvPhoneBook.Rows[e.RowIndex].FindControl("txttelefono") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@correo", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtcorreo") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@dpi", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtdpi") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@monto", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtmonto") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@finalidad", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtfinalidad") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@zona", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtzona") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@tipodeservicio", (gvPhoneBook.Rows[e.RowIndex].FindControl("txttiposervicio") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@contactadopor", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtcontacatdopor") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@numeroregistro", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Ha modificado exitosamente";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM gen_usuario WHERE codgenusuario = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }

        }

        public void leergridview()
        {
            string comprobardpi = "1234";//funcion que busca sobre toods los dpis existentes

            int centinela1 = 0;
            int centinela2 = 0;

            string[] var1 = sn.fechaactual();
            for (int i = 0; i < var1.Length; i++)
            {
                fechaactual = Convert.ToDateTime(var1[0]);
            }

            int iplus = 0;
            string[] var2 = sn.consultarparateleventas();
            if (centinela1 == var2.Length)
            {
                centinela1 = 0;
                
                for (iplus=centinela1; iplus < var2.Length;)
                {
                    string sucursal = var2[centinela1 + 0];
                    string agente = var2[centinela1 + 1];
                    centinela1 = centinela1 + 2;
                    iplus = centinela1;
                }

            }
            else
            {
                for (int i = 0; i < var2.Length;)
                {
                    string sucursal = var2[centinela1 + 0];
                    string agente = var2[centinela1 + 1];
                    centinela1 = centinela1 + 2;
                    i = centinela1;
                }

            }



                foreach (GridViewRow row in GridView1.Rows)
                    {
                        double cantidaddecimal = 0;
                        string numero = row.Cells[0].Text;
                        string fecha = row.Cells[1].Text;
                        string nombre = row.Cells[2].Text;
                        string telefono = row.Cells[3].Text;
                        string correo = row.Cells[4].Text;
                        string dpi = row.Cells[5].Text;
                        string cantidad = row.Cells[6].Text;
                        if (cantidad != "Cantidad")
                        {
                            cantidaddecimal = Convert.ToDouble(cantidad);
                        }
                        string zona = row.Cells[7].Text;
                        string finalidad = row.Cells[8].Text;
                        string tiposervicio = row.Cells[9].Text;
                        string contactadopor = row.Cells[10].Text;
                        if (cantidaddecimal >= 50000)
                        {
                            //para agencias
                        }
                        else
                        {
                            //para sucursales
                        }

                        if (dpi == comprobardpi)
                        {
                            //Coloca el registro con el usuario existente
                        }
                        else
                        {
                            //crea el registro
                            //coloca el registr ocon el nuevo usuario
                        }
                        //insertar el registro en la base de datos crminfoprospecto; 
                    }//cierre dle registro


        }//cierre de la función

        public void Ingresaryasignarprospectos()
        {
           
            int centinelaagencias = 0;
            int centinelateleventas = 0;
            int centinelatabla = 0;
            string agenteacargo ="";
            // Variables nuevas para remplazarlas en el ingreso de datos
            string nuevopi="";
            string[] tablatemporal = sn.consultartabla("crmtamporal_cargadedatos");
            for (int i=0; i<tablatemporal.Length;i++)
            {          
              /*Variables Globales*/
                int num = gvPhoneBook.Rows.Count;
                double cantidaddecimal = 0;
                /*Variables*/
                string No = tablatemporal[centinelatabla];
                string fecha = tablatemporal[centinelatabla+1];
                string nombre = tablatemporal[centinelatabla+2];
                string telefono = tablatemporal[centinelatabla+3];
                string correo = tablatemporal[centinelatabla+4];
                string dpi = tablatemporal[centinelatabla+5];              
                string cantidad = tablatemporal[centinelatabla+6];
                string finalidad = tablatemporal[centinelatabla+7];
                string zona = tablatemporal[centinelatabla+8];
                string tiposervicio = tablatemporal[centinelatabla+9];
                string contactadopor = tablatemporal[centinelatabla+10];
                if (fecha == "Fecha" && nombre == "Nombre" && telefono == "Tel&#233;fono" && correo == "Correo" && dpi == "DPI" && cantidad == "Cantidad"
                    && zona == "Zona" && finalidad == "Finalidad" && tiposervicio == "Tipo de servicio" && contactadopor == "Contacto")
                {

                }
                else
                {
                    if (comprobardpiexistente(dpi))  //DPI EXISTENTE 
                    {
                        // Response.Write("el nuevo" + registrodpiremplazable);
                        string[] regdpiguardado = sn.consultarconcampo("crminfogeneral_prospecto", "crminfogeneral_prospectodpi", registrodpiremplazable);
                        dpiguardar = regdpiguardado[0];
                    }
                    else
                    {
                        string sig1 = logic.siguiente("crminfogeneral_prospecto", "codcrminfogeneralprospecto");
                        string[] valores2 = {sig1,dpi,"","",nombre,"0"};
                        logic.insertartablas("crminfogeneral_prospecto", valores2);
                        dpiguardar = sig1;
                      

                    }

                    if (cantidad != "Cantidad" || cantidad != "")
                    {
                        cantidaddecimal = Convert.ToDouble(cantidad);
                    }
                    if (cantidaddecimal >= 50000)
                    {
                        string[] var1 = sn.consultarparateleventas();
                        //para televentas

                        if (centinelateleventas == var1.Length)
                        {
                            centinelateleventas = 0;
                            agenteacargo = var1[centinelateleventas];
                            centinelateleventas = centinelateleventas + 3;

                        }
                        else
                        {
                            agenteacargo = var1[centinelateleventas];
                            centinelateleventas = centinelateleventas + 3;
                        }


                    }
                    else
                    {
                        //para agencias
                        string[] var1 = sn.consultarparasucursal();

                        if (centinelaagencias == var1.Length)
                        {
                            centinelaagencias = 0;
                            agenteacargo = var1[centinelaagencias];
                            centinelaagencias = centinelaagencias + 3;

                        }
                        else
                        {
                            agenteacargo = var1[centinelaagencias];
                            centinelaagencias = centinelaagencias + 3;
                        }
                        
                       
                    }
                    //Response.Write("Datos:" + fecha + nombre + telefono + correo + dpi + cantidad + zona + finalidad +
                    //tiposervicio + contactadopor + cantidad + cantidaddecimal + "<br>");

                    string sig = logic.siguiente("crminfo_prospecto", "codcrminfoprospecto");
                    string[] valores1 = { sig, dpiguardar, tiposervicio, "1", "2","2","2","1",telefono,correo,"0","0",Convert.ToString(cantidaddecimal),"0","0","0","2020-01-01","2020-01-01","","0",
                        "0","0","0",contactadopor,""};
                    logic.insertartablas("crminfo_prospecto", valores1);

                    string sig3 = logic.siguiente("crmcontrol_prospecto_agente", "codcrmcontrolprospectoagente");
                         string[] var4 = sn.fechaactual();
                        fechaactual = Convert.ToDateTime(var4[0]);
                    string[] valores3 = { sig3,sig,agenteacargo, string.Format("{0: yyyy-MM-dd}", fechaactual) };   
                    logic.insertartablas("crmcontrol_prospecto_agente", valores3);

                }
                centinelatabla = centinelatabla + 11;                          //El centinela debe sumarle la cantidad de columnas de la tabla
                i = centinelatabla;                                          //el i es un autoincrementable que siempre se igula al centinela
            }//cierre dle registro

        }

        public bool comprobardpiexistente(string dpiacomprobar)
        {
            string[] var2 = sn.consultardpiexistente();
           
            int cont = 0;
            while (cont != var2.Length)
            {
                string dpiextraido = Convert.ToString(var2[cont]);
             
                if (dpiacomprobar != dpiextraido)
                {
                    cont = cont + 1;
                  
                }
                else
                {
                    registrodpiremplazable = dpiacomprobar;
                   
                    return true;
                }
               
            }
            return false;
        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuPrincipal/CRM_MenuPrincipal.aspx");
            logic.eliminadoderegistrosprotegida("crmtamporal_cargadedatos");
        }

        protected void btncerrasesion_Click(object sender, EventArgs e)
        {
            String script = "alert('Se encuentra saliendo del programa'); window.location.href= '../../Index.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }
    }
    }