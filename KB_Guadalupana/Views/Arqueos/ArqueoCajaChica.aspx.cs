using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using SA_Arqueos.Controllers;
using SA_Arqueos.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoCajaChica : System.Web.UI.Page
    {
        Conexion conexiongeneral = new Conexion();
        Logica_arqueos logic = new Logica_arqueos();
        Logica lg = new Logica();
        Conexion_arqueos conn = new Conexion_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string total;
        decimal total2;
        decimal total3;
        string total4;
        decimal total5, total6;
        string sig;
        string sig1;
        string fecha;
        string id,id2;
        char delimitador2 = ' ';
        char delimitador = ':';
        char delimitador3 = '-';
        string concat = "T";
        char concat2 = 'T';
        string numarqueo;
        string fechamin, horamin, fechahora, usuario, idusuario, totalhaber, puesto, año, mes, dia, dia3, fechatotal1, fechamin2, año2, mes2, dia2, idusuario2;
        int cont;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NombreFirma2.InnerHtml = Session["Nombre"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;

                //llenargridviewcajachica();
                //mostrargridviewcajachica();
                CCTotalsaldo.Visible = false;
                llenarcomboagencia();
                llenarcombousuario();
                GuardarCambios.Visible = false;
                Eliminar.Visible = false;
                EBuscar.Visible = false;
                arqueo.Visible = false;
                CCNombreencargado.Disabled = false;
                now();
                visualizar.Visible = false;
                imprimir.Visible = false;
                //MySqlDataReader reader3 = logic.fechaactual();
                //if (reader3.Read())
                //{
                //    CCFechaencabezado.Value = reader3.GetString(0);
                //}
            }
        }

        public void llenargridviewcajachica()
        {
            try
            {
                //string[] fecha2 = sn.fechaactual2();
                //for (int i = 0; i < fecha2.Length; i++)
                //{
                //    fechamin2 = Convert.ToString(fecha2.GetValue(0));

                //    string[] valores2 = fechamin2.Split(delimitador3);
                //    año2 = valores2[0];
                //    mes2 = valores2[1];
                //    dia2 = valores2[2];
                //}

                string QueryString = "SELECT * FROM sa_detallecajachica";
                MySqlConnection conect = conn.conectar();
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                GridViewCajaChica.DataSource = ds3;
                GridViewCajaChica.DataBind();
                conn.desconexion(conect);

                totalhaber = sn.totalhaber(id);
                CCTotalhaber.Value = totalhaber;
                CCTotalsaldo.Value = totalhaber;
            }
            catch
            {
            }
            finally { conn.desconectar(); }
        }

        protected void OnSelectedIndexChangedcajachica(object sender, EventArgs e)
        {
            GridViewRow row = GridViewCajaChica.SelectedRow;
            Text6.Value = Convert.ToString((GridViewCajaChica.SelectedRow.FindControl("lblcodigodetalle") as Label).Text);
            CCFecha.Value = (GridViewCajaChica.SelectedRow.FindControl("lblfecha") as Label).Text;
            CCNumdocumento.Value = Convert.ToString((GridViewCajaChica.SelectedRow.FindControl("lblnumdocumento") as Label).Text);
            CCProveedor.Value = (GridViewCajaChica.SelectedRow.FindControl("lblproveedor") as Label).Text;
            CCDescripcion.Value = (GridViewCajaChica.SelectedRow.FindControl("lbldescripcion") as Label).Text;
            CCDebe.Value = Convert.ToString((GridViewCajaChica.SelectedRow.FindControl("lbldebe") as Label).Text);
            CCHaber.Value = Convert.ToString((GridViewCajaChica.SelectedRow.FindControl("lblhaber") as Label).Text);

            GuardarCambios.Visible = true;
            Eliminar.Visible = true;
            Agregar.Visible = false;
        }
        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sa_agencia";
                    //MySqlConnection conect = conn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Agencia");
                    CCAgencia.DataSource = ds;
                    CCAgencia.DataTextField = "idsa_agencia";
                    CCAgencia.DataValueField = "idsa_agencia";
                    CCAgencia.DataBind();
                    CCAgencia.Items.Insert(0, new ListItem("[Código Agencia]", "0"));
                }
                catch { }
                finally { try { conn.desconectar(); } catch { } }
            }
        }

        public void llenarcombousuario()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_usuario";
                    //MySqlConnection conect = conn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Usuario");
                    CAUsuario.DataSource = ds;
                    CAUsuario.DataTextField = "gen_usuarionombre";
                    CAUsuario.DataValueField = "codgenusuario";
                    CAUsuario.DataBind();
                    CAUsuario.Items.Insert(0, new ListItem("[Usuario]", "0"));
                }
                catch { }
                finally { try { conn.desconectar(); } catch { } }
            }
        }

        public void llenarcomboarqueos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "";
                    fecha = CABuscarfecha.Value;

                    string[] fechasep2 = fecha.Split(delimitador3);
                    año = fechasep2[0];
                    mes = fechasep2[1];
                    dia = fechasep2[2];
                    puesto = Session["puesto_usuario"] as string;
                    usuario = Session["sesion_usuario"] as string;
                    idusuario = sn.obteneridusuario(usuario);


                    if (puesto == "1")
                    {
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadocajachica WHERE DATE_FORMAT(sa_fecha,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fecha,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fecha,  '%d') = '" + dia + "' AND idsa_usuario = '" + idusuario + "'";
                    }
                    else
                    {
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadocajachica WHERE DATE_FORMAT(sa_fecha,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fecha,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fecha,  '%d') = '" + dia + "' AND idsa_usuario = '" + CAUsuario.SelectedValue + "'";
                    }

                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Arqueo");
                    DropNumarqueo.DataSource = ds;
                    DropNumarqueo.DataTextField = "sa_numarqueo";
                    DropNumarqueo.DataValueField = "sa_numarqueo";
                    DropNumarqueo.DataBind();
                    DropNumarqueo.Items.Insert(0, new ListItem("[Numero de arqueo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void CCAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNumagencia.Value = sn.nombreagencia(CCAgencia.SelectedValue);
        }

        protected void CAUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboarqueos();
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                sig1 = Session["idcajachica"] as string;
                id = Session["idcajachica"] as string;
                string sig2 = logic.siguiente("sa_detallecajachica", "idsa_detallecajachica");
                    string[] valores2 = { sig2, CCFecha.Value, CCNumdocumento.Value, CCProveedor.Value, CCDescripcion.Value, CCDebe.Value, CCHaber.Value, sig1 };
                    logic.insertartablas("sa_detallecajachica", valores2);
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { conn.desconectar(); } catch { } }
            mostrargridviewcajachica();

            totalhaber = sn.totalhaber(id);
            CCTotalhaber.Value = totalhaber;
            CCTotalsaldo.Value = totalhaber;
        }

        protected void guardarencabezado_Click(object sender, EventArgs e)
        {

            try
            {
                //INSERTAR ENCABEZADO
                fecha = CCFechaencabezado.Value;
                string numeroarqueo = "";

                string[] fechasep2 = fecha.Split(delimitador3);
                año = fechasep2[0];
                mes = fechasep2[1];
                dia3 = fechasep2[2];

                string[] fechadia = dia3.Split(concat2);
                dia = fechadia[0];
                puesto = Session["puesto_usuario"] as string;


                string[] fechadia2 = dia3.Split(delimitador2);
                string dia4 = fechadia2[0];
                string hora = fechadia2[1];

                string[] horayfecha = hora.Split(delimitador);
                string hora1 = horayfecha[0];
                string minutos = horayfecha[1];

                string fechayhora2 = dia4 + '-' + mes + '-' + año + ' ' + hora1 + ':' + minutos;

                usuario = Session["sesion_usuario"] as string;
                idusuario = sn.obteneridusuario(usuario);
                numeroarqueo = sn.numarqueoCC(dia4, mes, año, idusuario);
                sig1 = logic.siguiente("sa_encabezadocajachica", "idsa_encabezadocajachica");
                string[] valores1 = { sig1, numeroarqueo, idusuario, CCAgencia.SelectedValue, fechayhora2, CCNombre.Value, CCOperador.Value, CCPuestooperador.Value, CCNombreencargado.Value, CCPuestoencargado.Value, SaldoInicial2.Value };
                logic.insertartablas("sa_encabezadocajachica", valores1);
                Session["idcajachica"] = sig1.ToString();
                id = Session["idcajachica"] as string;

                lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Ingreso de datos", "Creación de arqueo Caja Chica");

                Saldoinicial.Value = SaldoInicial2.Value;
                parte2.Visible = true;
                guardar.Visible = true;
                NombreFirma.InnerText = CCNombre.Value;
                NombreFirma2.InnerHtml = CCNombreencargado.Value;
                PuestoFirma.InnerHtml = CCPuestooperador.Value;
                PuestoFirma2.InnerHtml = CCPuestoencargado.Value;
                guardar.Enabled = true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { conn.desconectar(); } catch { } }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //SUBTOTAL BILLETES
                decimal subtotalb1, subtotalb2, subtotalb3, subtotalb4, subtotalb5, subtotalb6, subtotalb7;
                subtotalb1 = Convert.ToDecimal(200.00) * Convert.ToDecimal(CACantidad1.Value);
                subtotalb2 = Convert.ToDecimal(100.00) * Convert.ToDecimal(CACantidad2.Value);
                subtotalb3 = Convert.ToDecimal(50.00) * Convert.ToDecimal(CACantidad3.Value);
                subtotalb4 = Convert.ToDecimal(20.00) * Convert.ToDecimal(CACantidad4.Value);
                subtotalb5 = Convert.ToDecimal(10.00) * Convert.ToDecimal(CACantidad5.Value);
                subtotalb6 = Convert.ToDecimal(5.00) * Convert.ToDecimal(CACantidad6.Value);
                subtotalb7 = Convert.ToDecimal(1.00) * Convert.ToDecimal(CACantidad7.Value);

                //TOTAL BILLETES
                decimal totalbilletes;
                totalbilletes = Convert.ToDecimal(subtotalb1) + Convert.ToDecimal(subtotalb2) + Convert.ToDecimal(subtotalb3) + Convert.ToDecimal(subtotalb4) +
                                Convert.ToDecimal(subtotalb5) + Convert.ToDecimal(subtotalb6) + Convert.ToDecimal(subtotalb7);

                //SUBTOTAL MONEDAS
                decimal subtotalm1, subtotalm2, subtotalm3, subtotalm4, subtotalm5, subtotalm6;
                subtotalm1 = Convert.ToDecimal(1.00) * Convert.ToDecimal(CACantidadm1.Value);
                subtotalm2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(CACantidadm2.Value);
                subtotalm3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(CACantidadm3.Value);
                subtotalm4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(CACantidadm4.Value);
                subtotalm5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(CACantidadm5.Value);
                subtotalm6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(CACantidadm6.Value);

                //TOTAL MONEDAS
                decimal totalmonedas;
                totalmonedas = Convert.ToDecimal(subtotalm1) + Convert.ToDecimal(subtotalm2) + Convert.ToDecimal(subtotalm3) +
                               Convert.ToDecimal(subtotalm4) + Convert.ToDecimal(subtotalm5) + Convert.ToDecimal(subtotalm6);

                //TOTAL EFECTIVO
                decimal total;
                total = Convert.ToDecimal(totalbilletes) + Convert.ToDecimal(totalmonedas);

                //TOTAL CAJA
                decimal caja;
                caja = Convert.ToDecimal(CCTotalsaldo.Value) + Convert.ToDecimal(total);

                //INSERTAR DETALLE DE CUADRE
                sig1 = Session["idcajachica"] as string;
                string sig2 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores2 = { sig2, "1", CACantidad1.Value, Convert.ToString(subtotalb1), Convert.ToString(totalbilletes), "1", CACantidadm1.Value, Convert.ToString(subtotalm1), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores2);
                string sig3 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores3 = { sig3, "2", CACantidad2.Value, Convert.ToString(subtotalb2), Convert.ToString(totalbilletes), "2", CACantidadm2.Value, Convert.ToString(subtotalm2), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores3);
                string sig4 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores4 = { sig4, "3", CACantidad3.Value, Convert.ToString(subtotalb3), Convert.ToString(totalbilletes), "3", CACantidadm3.Value, Convert.ToString(subtotalm3), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores4);
                string sig5 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores5 = { sig5, "4", CACantidad4.Value, Convert.ToString(subtotalb4), Convert.ToString(totalbilletes), "4", CACantidadm4.Value, Convert.ToString(subtotalm4), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores5);
                string sig6 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores6 = { sig6, "5", CACantidad5.Value, Convert.ToString(subtotalb5), Convert.ToString(totalbilletes), "5", CACantidadm5.Value, Convert.ToString(subtotalm5), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores6);
                string sig7 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores7 = { sig7, "6", CACantidad6.Value, Convert.ToString(subtotalb6), Convert.ToString(totalbilletes), "6", CACantidadm6.Value, Convert.ToString(subtotalm6), Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores7);
                string sig8 = logic.siguiente("sa_cuadrecajachica", "idsa_cuadrecajachica");
                string[] valores8 = { sig8, "7", CACantidad7.Value, Convert.ToString(subtotalb7), Convert.ToString(totalbilletes), "8", "0", "0", Convert.ToString(totalmonedas), Convert.ToString(total), Convert.ToString(caja), CCCOmentario.Value, sig1 };
                logic.insertartablas("sa_cuadrecajachica", valores8);

                String script = "alert('Se han guardado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                guardar.Enabled = false;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { conn.desconectar(); } catch { } }
        }

        protected void guardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                id= Session["idcajachica"] as string;
                sig1 = Session["idcajachica"] as string;
                sn.modificarRegistros(Text6.Value, CCFecha.Value, CCNumdocumento.Value, CCProveedor.Value, CCDescripcion.Value, CCDebe.Value, CCHaber.Value);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { conn.desconectar(); } catch { } }
            mostrargridviewcajachica();
            totalhaber = sn.totalhaber(id);
            CCTotalhaber.Value = totalhaber;
            CCTotalsaldo.Value = totalhaber;
            GuardarCambios.Visible = false;
            Eliminar.Visible = false;
            Agregar.Visible = true;
        }

        protected void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                sn.eliminarregistro("sa_detallecajachica", "idsa_detallecajachica", Text6.Value);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { conn.desconectar(); } catch { } }
            llenargridviewcajachica();
            GuardarCambios.Visible = false;
            Eliminar.Visible = false;
            Agregar.Visible = true;
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            if (CABuscarfecha.Value == "")
            {
                String script = "alert('Debe ingresar la fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Consulta de datos", "Búsqueda de arqueo Caja Chica");
                numarqueo = DropNumarqueo.SelectedValue;
                mostrarcajachica();
                if (cont == 1)
                {
                    arqueo.Visible = false;
                    EBuscar.Visible = false;
                }
                else
                {
                    arqueo.Visible = true;
                    Creararqueo.Visible = false;
                    Buscararqueo.Visible = false;
                    visualizar.Visible = true;
                    imprimir.Visible = true;
                    GuardarEncabezado.Visible = false;
                    EBuscar.Visible = false;
                    agregarRegistro.Visible = false;
                    guardar.Visible = false;
                    mostrargridviewcajachica();
                    mostrardetalle();
                }
            }
          
        }

     

        public void mostrarcajachica()
        {
            numarqueo = DropNumarqueo.SelectedValue;
            fecha = CABuscarfecha.Value;
            string[] fechasep2 = fecha.Split(delimitador3);
            año = fechasep2[0];
            mes = fechasep2[1];
            dia = fechasep2[2];
            CCFechaencabezado.Attributes.Add("value", fechatotal1);
            puesto = Session["puesto_usuario"] as string;
            usuario = Session["sesion_usuario"] as string;
            idusuario = sn.obteneridusuario(usuario);

            string[] var;
            if (puesto == "1")
            {
                var = sn.mostrarencabezadoCC(año, mes, dia, idusuario, numarqueo);
            }
            else
            {
                var = sn.mostrarencabezadoCC(año, mes, dia, CAUsuario.SelectedValue, numarqueo);
            }

            if (var[2] == null)
            {
                String script = "alert('No existe arqueo con esa fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                cont = 1;
            }
            else
            {
                for (int i = 0; i < var.Length; i++)
                {
                    id = Convert.ToString(var[0]);
                    //Session["idcajachica"] = "2";
                    CCAgencia.SelectedValue = Convert.ToString(var[1]);
                    CCNumagencia.Value = Convert.ToString(sn.nombreagencia(var[1]));
                    string fechaenc = Convert.ToString(var[2]);
                    CCNombre.Value = Convert.ToString(var[3]);
                    NombreFirma.InnerHtml = Convert.ToString(var[3]);
                    CCOperador.Value = Convert.ToString(var[4]);
                    CCPuestooperador.Value = Convert.ToString(var[5]);
                    PuestoFirma.InnerHtml = Convert.ToString(var[5]);
                    CCNombreencargado.Value = Convert.ToString(var[6]);
                    NombreFirma2.InnerHtml = Convert.ToString(var[6]);
                    CCPuestoencargado.Value = Convert.ToString(var[7]);
                    PuestoFirma2.InnerHtml = Convert.ToString(var[7]);
                    SaldoInicial2.Value = Convert.ToString(var[8]);
                    Saldoinicial.Value = Convert.ToString(var[8]);
                    //Session["idtesoreria"] = id.ToString();
                    //string idcajero1 = id.ToString();
                    //Session["idcajero1"] = idcajero1.ToString();

                    string[] fechasep = fechaenc.Split(delimitador2);
                    string[] horai = fechasep[3].Split(delimitador);
                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + ' ' + horai[0] + ":" + horai[1];
                    CCFechaencabezado.Attributes.Add("value", fechatotal1);
                   
                }
            }
        }

        public void mostrardetalle()
        {
            mostrardetalle1();
            mostrardetalle2();
            mostrardetalle3();
            mostrardetalle4();
            mostrardetalle5();
            mostrardetalle6();
            mostrardetalle7();

            totalhaber = sn.totalhaber(id);
            CCTotalhaber.Value = totalhaber;
            CCTotalsaldo.Value = totalhaber;
            mostrargridviewcajachica();
        }

        public void mostrardetalle1()
        {
            string[] var = sn.mostrardetalleCC1(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad1.Value = Convert.ToString(var[2]);
                CASubtotalb1.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm1.Value = Convert.ToString(var[6]);
                CASubtotalm1.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleCC2(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad2.Value = Convert.ToString(var[2]);
                CASubtotalb2.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm2.Value = Convert.ToString(var[6]);
                CASubtotalm2.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleCC3(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad3.Value = Convert.ToString(var[2]);
                CASubtotalb3.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm3.Value = Convert.ToString(var[6]);
                CASubtotalm3.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleCC4(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad4.Value = Convert.ToString(var[2]);
                CASubtotalb4.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm4.Value = Convert.ToString(var[6]);
                CASubtotalm4.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleCC5(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad5.Value = Convert.ToString(var[2]);
                CASubtotalb5.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm5.Value = Convert.ToString(var[6]);
                CASubtotalm5.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleCC6(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad6.Value = Convert.ToString(var[2]);
                CASubtotalb6.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm6.Value = Convert.ToString(var[6]);
                CASubtotalm6.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleCC7(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad7.Value = Convert.ToString(var[2]);
                CASubtotalb7.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CATotalcaja.InnerHtml = Convert.ToString(var[10]);
                CCCOmentario.Value = Convert.ToString(var[11]);
            }
        }

        public void mostrargridviewcajachica()
        {
            DataTable dt1 = new DataTable();
            dt1 = logic.llenarGridView(id);
            GridViewCajaChica.DataSource = dt1;
            GridViewCajaChica.DataBind();

            //try
            //{

            //    ////id2 = Session["idcajachica"] as string;
            //    //string QueryString = "SELECT * FROM sa_detallecajachica WHERE idsa_encabezadocajachica = '"+ id +"'";
            //    //// "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='"+cifactual+"';";
            //    //MySqlConnection conect = conn.conectar();
            //    //MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
            //    //DataTable ds3 = new DataTable();
            //    //myCommand.Fill(ds3);
            //    //GridViewCajaChica.DataSource = ds3;
            //    //GridViewCajaChica.DataBind();
            //    //conn.desconexion(conect);

            //    //totalhaber = sn.totalhaber(id);
            //    //CCTotalhaber.Value = totalhaber;
            //    //CCTotalsaldo.Value = totalhaber;


            //}
            //catch
            //{
            //}
            //finally { conn.desconectar(); }
        }

        //public void mostrargridviewcajachica2()
        //{
        //    try
        //    {
        //        string QueryString = "SELECT * FROM sa_detallecajachica WHERE idsa_encabezadocajachica = '" + id + "'";
        //        // "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='"+cifactual+"';";
        //        MySqlConnection conect = conn.conectar();
        //        MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
        //        DataTable ds3 = new DataTable();
        //        myCommand.Fill(ds3);
        //        GridViewCajaChica.DataSource = ds3;
        //        GridViewCajaChica.DataBind();
        //        conn.desconexion(conect);

        //        totalhaber = sn.totalhaber(id);
        //        CCTotalhaber.Value = totalhaber;
        //        CCTotalsaldo.Value = totalhaber;
        //    }
        //    catch
        //    {
        //    }
        //    finally { conn.desconectar(); }
        //}

        protected void creararqueo_Click(object sender, EventArgs e)
        {
            string usuario3, consulta;
            usuario3 = Session["sesion_usuario"] as string;
            idusuario2 = sn.obteneridusuario(usuario3);
            consulta = sn.consultararqueoCC(idusuario2);
            arqueo.Visible = true;
            Creararqueo.Visible = false;
            Buscararqueo.Visible = false;
            visualizar.Visible = true;
            imprimir.Visible = true;
            CCNombreencargado.Value = Session["Nombre"] as string;
            parte2.Visible = false;
            guardar.Visible = false;
            EBuscar.Visible = false;
            mostrargridviewcajachica();

            //if (consulta == "")
            //{
            //    arqueo.Visible = true;
            //    Creararqueo.Visible = false;
            //    Buscararqueo.Visible = false;
            //    visualizar.Visible = true;
            //    imprimir.Visible = true;
            //    CCNombreencargado.Value = Session["Nombre"] as string;
            //    parte2.Visible = false;
            //    guardar.Visible = false;
            //    mostrargridviewcajachica();
            //}
            //else
            //{
            //    String script = "alert('Ya tiene un arqueo creado por el dia de hoy');";
            //    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            //    arqueo.Visible = false;
            //    EBuscar.Visible = false;
            //    visualizar.Visible = false;
            //    imprimir.Visible = false;
            //}
               
        }

        protected void buscararqueo_Click(object sender, EventArgs e)
        {
                puesto = Session["puesto_usuario"] as string;
                EBuscar.Visible = true;
                visualizar.Visible = false;
                imprimir.Visible = false;

                if (puesto == "1")
                {
                    CAUsuario.Visible = false;
                    TituloUsuario.Visible = false;
                }
                else if (puesto == "2")
                {
                    CAUsuario.Visible = true;
                }
           
        }

        protected void btnArqueos_Click(object sender, EventArgs e)
        {
            llenarcomboarqueos();
        }
        public void now()
        {

            string[] fecha = sn.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador);
                    fechahora = valores2[2] + "-" + valores2[1] + "-" + valores2[0] + ' ' + horas[0] + ":" + horas[1];

                    CCFechaencabezado.Attributes.Add("value", fechahora);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}