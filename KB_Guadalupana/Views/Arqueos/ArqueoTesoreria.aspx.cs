using System;
using KB_Guadalupana.Models;
using SA_Arqueos.Models;
using SA_Arqueos.Controllers;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoTesoreria : System.Web.UI.Page
    {
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Logica_arqueos logic2 = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        Logica lg = new Logica();
        string fecha;
        string id;
        char delimitador2 = ' ';
        char delimitador = ':';
        char delimitador3 = '-';
        string concat = "T";
        char concat2 = 'T';
        int cont = 0;
        string op;
        Conexion conexiongeneral = new Conexion();
        string fechamin, horamin, fechahora, fechatotal1, año, mes, dia, dia2, usuario, puesto, idusuario, idusuario2, numarqueo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NombreFirma.InnerHtml = Session["Nombre"] as string;
                puesto = Session["puesto_usuario"] as string;
                usuario = Session["sesion_usuario"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                TFecha.Value = Session["fecha"] as string;
                TAgencia.SelectedValue = Session["agencia2"] as string;
                TCodigoagencia.Value = Session["codigoagencia"] as string;
                TNombreoperador.Value = Session["nombreop"] as string;
                TOperador.Value = Session["numoperador"] as string;
                TNombreencargado.Value = Session["nombreencargado"] as string;
                TPuestoencargado.Value = Session["puestoencargado"] as string;
                llenarcomboagencia();
                llenarcombousuario();
                EBuscar.Visible = false;
                arqueo.Visible = false;
                now();
                visualizar.Visible = false;
                imprimir.Visible = false;
                ayuda.Visible = true;
            }
            //siguiente.Enabled = false;
        }

        protected void siguiente_Click(object sender, EventArgs e)
        {
            op = Session["op"] as string;
            if (op == "2")
            {
                String script = "alert('Debe guardar antes de cambiar de página');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            } else if (op == "1")
            {
                Response.Redirect("ArqueoTesoreria2.aspx");
            }
        }

        public void llenarcomboagencia()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from sa_agencia";
                    //MySqlConnection conect = cn.conectar();
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Agencia");
                    TAgencia.DataSource = ds;
                    TAgencia.DataTextField = "idsa_agencia";
                    TAgencia.DataValueField = "idsa_agencia";
                    TAgencia.DataBind();
                    TAgencia.Items.Insert(0, new ListItem("[Código Agencia]", "0"));
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
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
                    //MySqlConnection conect = cn.conectar();
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
                finally { try { cn.desconectar(); } catch { } }
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
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadotesoreria WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + idusuario + "'";
                    }
                    else
                    {
                        QueryString = "SELECT sa_numarqueo FROM sa_encabezadotesoreria WHERE DATE_FORMAT(sa_fechayhora,  '%Y') = '" + año + "' AND DATE_FORMAT(sa_fechayhora,  '%m') = '" + mes + "' AND DATE_FORMAT(sa_fechayhora,  '%d') = '" + dia + "' AND idsa_usuario = '" + CAUsuario.SelectedValue + "'";
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
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        protected void TAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TCodigoagencia.Value = sn.nombreagencia(TAgencia.SelectedValue);
        }

        protected void CAUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboarqueos();
        }

        protected void operar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["op"] = "1";
                Session["siguiente2"] = "0";
                //SUBTOTAL DE BILLETES
                decimal subtotal1, subtotal2, subtotal3, subtotal4, subtotal5, subtotal6, subtotal7;
                subtotal1 = Convert.ToDecimal(200.00) * Convert.ToDecimal(TCantidadb1.Value);
                //TSubtotalb1.Value = Convert.ToString(subtotal1);
                subtotal2 = Convert.ToDecimal(100.00) * Convert.ToDecimal(TCantidadb2.Value);
                //TSubtotalb2.Value = Convert.ToString(subtotal2);
                subtotal3 = Convert.ToDecimal(50.00) * Convert.ToDecimal(TCantidadb3.Value);
                //TSubtotalb3.Value = Convert.ToString(subtotal3);
                subtotal4 = Convert.ToDecimal(20.00) * Convert.ToDecimal(TCantidadb4.Value);
                //TSubtotalb4.Value = Convert.ToString(subtotal4);
                subtotal5 = Convert.ToDecimal(10.00) * Convert.ToDecimal(TCantidadb5.Value);
                //TSubtotalb5.Value = Convert.ToString(subtotal5);
                subtotal6 = Convert.ToDecimal(5.00) * Convert.ToDecimal(TCantidadb6.Value);
                //TSubtotalb6.Value = Convert.ToString(subtotal6);
                subtotal7 = Convert.ToDecimal(1.00) * Convert.ToDecimal(TCantidadb7.Value);
                //TSubtotalb7.Value = Convert.ToString(subtotal7);

                //TOTAL BILLETES
                decimal totalbilletes;
                totalbilletes = Convert.ToDecimal(subtotal1) + Convert.ToDecimal(subtotal2) + Convert.ToDecimal(subtotal3) +
                                Convert.ToDecimal(subtotal4) + Convert.ToDecimal(subtotal5) + Convert.ToDecimal(subtotal6) +
                                Convert.ToDecimal(subtotal7);
                //TTotalbilletes.Value = Convert.ToString(totalbilletes);

                //SUBTOTAL MONEDAS
                decimal subtotalm1, subtotalm2, subtotalm3, subtotalm4, subtotalm5, subtotalm6;
                subtotalm1 = Convert.ToDecimal(1) * Convert.ToDecimal(TCantidadm1.Value);
                //TSubtotalm1.Value = Convert.ToString(subtotalm1);
                subtotalm2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(TCantidadm2.Value);
                //TSubtotalm2.Value = Convert.ToString(subtotalm2);
                subtotalm3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(TCantidadm3.Value);
                //TSubtotalm3.Value = Convert.ToString(subtotalm3);
                subtotalm4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(TCantidadm4.Value);
                //TSubtotalm4.Value = Convert.ToString(subtotalm4);
                subtotalm5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(TCantidadm5.Value);
                //TSubtotalm5.Value = Convert.ToString(subtotalm5);
                subtotalm6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(TCantidadm6.Value);
                //TSubtotalm6.Value = Convert.ToString(subtotalm6);

                //TOTAL MONEDAS
                decimal totalmonedas;
                totalmonedas = Convert.ToDecimal(subtotalm1) + Convert.ToDecimal(subtotalm2) + Convert.ToDecimal(subtotalm3) +
                                Convert.ToDecimal(subtotalm4) + Convert.ToDecimal(subtotalm5) + Convert.ToDecimal(subtotalm6);
                //TTotalmoneda.Value = Convert.ToString(totalmonedas);

                //TOTAL EFECTIVO
                decimal totalefectivo;
                totalefectivo = Convert.ToDecimal(totalbilletes) + Convert.ToDecimal(totalmonedas);
                //TEfectivo.Value = Convert.ToString(totalefectivo);

                //TOTAL FONDO TESORERIA
                decimal fondo;
                fondo = Convert.ToDecimal(totalefectivo) + Convert.ToDecimal(TSolicitud.Value) + Convert.ToDecimal(TEfectivoentregado.Value);
                //TTotalfondo.Value = Convert.ToString(fondo);

                //TOTAL CANTIDAD CHEQUES
                int cheques;
                cheques = Convert.ToInt32(TChequesq.Value) + Convert.ToInt32(TChequesa.Value);
                //TTotalcheques.Value = Convert.ToString(cheques);

                //TOTAL MONTO CHEQUES
                int monto;
                monto = Convert.ToInt32(TMontoq.Value) + Convert.ToInt32(TMontoa.Value);
                //TTotalmonto.Value = Convert.ToString(monto);

                //VARIABLES SESSION ENCABEZADO
                string fecha = TFecha.Value;
                Session["fecha"] = fecha.ToString();
                string agencia = TAgencia.SelectedValue;
                Session["agencia2"] = agencia.ToString();
                string codigoagencia = TCodigoagencia.Value;
                Session["codigoagencia"] = agencia.ToString();
                string nombreop = TNombreoperador.Value;
                Session["nombreop"] = nombreop.ToString();
                string numoperador = TOperador.Value;
                Session["numoperador"] = numoperador.ToString();
                string puestooperador = TPuestooperador.Value;
                Session["puestooperador"] = puestooperador.ToString();
                string nombreencargado = TNombreencargado.Value;
                Session["nombreencargado"] = nombreencargado.ToString();
                string puestoencargado = TPuestoencargado.Value;
                Session["puestoencargado"] = puestoencargado.ToString();

                //INSERTAR ENCABEZADO
                fecha = TFecha.Value;
                string numeroarqueo = "";

                string[] fechasep2 = fecha.Split(delimitador3);
                año = fechasep2[0];
                mes = fechasep2[1];
                dia2 = fechasep2[2];

                string[] fechadia = dia2.Split(concat2);
                dia = fechadia[0];

                string[] fechadia2 = dia2.Split(delimitador2);
                string dia3 = fechadia2[0];
                string hora = fechadia2[1];

                string[] horayfecha = hora.Split(delimitador);
                string hora1 = horayfecha[0];
                string minutos = horayfecha[1];

                string fechayhora2 = dia3 + '-' + mes + '-' + año + ' ' + hora1 + ':' + minutos;

                usuario = Session["sesion_usuario"] as string;
                idusuario = sn.obteneridusuario(usuario);
                numeroarqueo = sn.numarqueoT(dia3, mes, año, idusuario);

                string sig = logic.siguiente("sa_encabezadotesoreria", "idsa_encabezadotesoreria");
                Session["idtesoreria"] = sig.ToString();
                string[] valores = { sig, numeroarqueo, idusuario, fechayhora2, TAgencia.SelectedValue, TNombreoperador.Value, TOperador.Value, TPuestooperador.Value, TNombreencargado.Value, TPuestoencargado.Value, TTesoreria.Value, "0" };
                logic.insertartablas("sa_encabezadotesoreria", valores);
                lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Ingreso de datos", "Creación de arqueo Cajero Tesorería");

                //INSERTAR DETALLE
                string sig1 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores1 = { sig1, "1", "1", TCantidadb1.Value, Convert.ToString(subtotal1), Convert.ToString(totalbilletes), "1", TCantidadm1.Value, Convert.ToString(subtotalm1), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores1);
                string sig2 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores2 = { sig2, "1", "2", TCantidadb2.Value, Convert.ToString(subtotal2), Convert.ToString(totalbilletes), "2", TCantidadm2.Value, Convert.ToString(subtotalm2), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores2);
                string sig3 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores3 = { sig3, "1", "3", TCantidadb3.Value, Convert.ToString(subtotal3), Convert.ToString(totalbilletes), "3", TCantidadm3.Value, Convert.ToString(subtotalm3), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores3);
                string sig4 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores4 = { sig4, "1", "4", TCantidadb4.Value, Convert.ToString(subtotal4), Convert.ToString(totalbilletes), "4", TCantidadm4.Value, Convert.ToString(subtotalm4), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores4);
                string sig5 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores5 = { sig5, "1", "5", TCantidadb5.Value, Convert.ToString(subtotal5), Convert.ToString(totalbilletes), "5", TCantidadm5.Value, Convert.ToString(subtotalm5), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores5);
                string sig6 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores6 = { sig6, "1", "6", TCantidadb6.Value, Convert.ToString(subtotal6), Convert.ToString(totalbilletes), "6", TCantidadm6.Value, Convert.ToString(subtotalm6), Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores6);
                string sig7 = logic.siguiente("sa_detalletesoreria", "idsa_detalletesoreria");
                string[] valores7 = { sig7, "1", "7", TCantidadb7.Value, Convert.ToString(subtotal7), Convert.ToString(totalbilletes), "8", "0", "0", Convert.ToString(totalmonedas), Convert.ToString(totalefectivo), TSolicitud.Value, TEfectivoentregado.Value, Convert.ToString(fondo), "0", "0", sig };
                logic.insertartablas("sa_detalletesoreria", valores7);

                //INSERTAR CHEQUE
                string sig8 = logic.siguiente("sa_chequestesoreria", "idsa_chequestesoreria");
                string[] valores8 = { sig8, "1", "1", TChequesq.Value, TMontoq.Value, Convert.ToString(cheques), Convert.ToString(monto), sig };
                logic.insertartablas("sa_chequestesoreria", valores8);
                string sig9 = logic.siguiente("sa_chequestesoreria", "idsa_chequestesoreria");
                string[] valores9 = { sig9, "2", "1", TChequesa.Value, TMontoa.Value, Convert.ToString(cheques), Convert.ToString(monto), sig };
                logic.insertartablas("sa_chequestesoreria", valores9);

                siguiente.Enabled = true;
                Nombrefirma2.InnerHtml = TNombreoperador.Value;
                NombreFirma.InnerHtml = TNombreencargado.Value;
                puesto2.InnerHtml = TPuestooperador.Value;
                puesto3.InnerHtml = TPuestoencargado.Value;

                String script = "alert('Se han guardado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                operar.Enabled = false;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally { try { cn.desconectar(); } catch { } }
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            if(CABuscarfecha.Value == "")
            {
                String script = "alert('Debe ingresar la fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                numarqueo = DropNumarqueo.SelectedValue;
                Session["siguiente2"] = "1";
                Session["op"] = "1";
                mostrartesoreria();
                if (cont == 1)
                {
                    arqueo.Visible = false;
                    EBuscar.Visible = false;
                }
                else
                {
                    mostrardetalle();
                    mostrarcheques();
                    arqueo.Visible = true;
                    Creararqueo.Visible = false;
                    Buscararqueo.Visible = false;
                    visualizar.Visible = true;
                    imprimir.Visible = true;
                    operar.Visible = false;
                    EBuscar.Visible = false;
                }
            }
           
            //NombreFirma.InnerHtml = Session["Nombre"] as string;
            //Nombrefirma2.InnerHtml = TNombreencargado.Value;
            //puesto2.InnerHtml = TPuestoencargado.Value;
        }

        public void mostrartesoreria()
        {
            numarqueo = DropNumarqueo.SelectedValue;
            fecha = CABuscarfecha.Value;
            string[] fechasep2 = fecha.Split(delimitador3);
            año = fechasep2[0];
            mes = fechasep2[1];
            dia = fechasep2[2];
            TFecha.Attributes.Add("value", fechatotal1);
            puesto = Session["puesto_usuario"] as string;
            usuario = Session["sesion_usuario"] as string;
            idusuario = sn.obteneridusuario(usuario);
            lg.bitacoraingresoprocedimientos(usuario, "Arqueos", "Consulta de datos", "Búsqueda de arqueo Cajero Tesorería");

            string[] var;
            if (puesto == "1")
            {
                var = sn.mostrarencabezadoT(año, mes, dia, idusuario, numarqueo);
            }
            else
            {
                var = sn.mostrarencabezadoT(año, mes, dia, CAUsuario.SelectedValue, numarqueo);
            }
               
            if (var[1] == null)
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
                    string fechaenc = Convert.ToString(var[1]);
                    //TFecha.Value = Convert.ToString(var[1]);
                    TAgencia.SelectedValue = Convert.ToString(var[2]);
                    TCodigoagencia.Value = Convert.ToString(sn.nombreagencia(var[2]));
                    TNombreoperador.Value = Convert.ToString(var[3]);
                    Nombrefirma2.InnerHtml = Convert.ToString(var[3]);
                    TOperador.Value = Convert.ToString(var[4]);
                    TPuestooperador.Value = Convert.ToString(var[5]);
                    puesto2.InnerHtml = Convert.ToString(var[5]);
                    TNombreencargado.Value = Convert.ToString(var[6]);
                    TPuestoencargado.Value = Convert.ToString(var[7]);
                    puesto3.InnerHtml = Convert.ToString(var[7]);
                    TTesoreria.Value = Convert.ToString(var[8]);
                    Session["idtesoreria"] = id.ToString();
                    //string idcajero1 = id.ToString();
                    //Session["idcajero1"] = idcajero1.ToString();

                    string[] fechasep = fechaenc.Split(delimitador2);
                    string[] horai = fechasep[3].Split(delimitador);
                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + ' ' + horai[0] + ":" + horai[1];
                    TFecha.Attributes.Add("value", fechatotal1);
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
        }

        public void mostrardetalle1()
        {
            string[] var = sn.mostrardetalleT1(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb1.Value = Convert.ToString(var[3]);
                TSubtotalb1.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm1.Value = Convert.ToString(var[7]);
                TSubtotalm1.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleT2(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb2.Value = Convert.ToString(var[3]);
                TSubtotalb2.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm2.Value = Convert.ToString(var[7]);
                TSubtotalm2.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleT3(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb3.Value = Convert.ToString(var[3]);
                TSubtotalb3.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm3.Value = Convert.ToString(var[7]);
                TSubtotalm3.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleT4(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb4.Value = Convert.ToString(var[3]);
                TSubtotalb4.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm4.Value = Convert.ToString(var[7]);
                TSubtotalm4.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleT5(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb5.Value = Convert.ToString(var[3]);
                TSubtotalb5.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm5.Value = Convert.ToString(var[7]);
                TSubtotalm5.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleT6(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb6.Value = Convert.ToString(var[3]);
                TSubtotalb6.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TCantidadm6.Value = Convert.ToString(var[7]);
                TSubtotalm6.InnerHtml = Convert.ToString(var[8]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleT7(id);
            for (int i = 0; i < var.Length; i++)
            {
                TCantidadb7.Value = Convert.ToString(var[3]);
                TSubtotalb7.InnerHtml = Convert.ToString(var[4]);
                TTotalbilletes.InnerHtml = Convert.ToString(var[5]);
                TTotalmoneda.InnerHtml = Convert.ToString(var[9]);
                TEfectivo.InnerHtml = Convert.ToString(var[10]);
                TSolicitud.Value = Convert.ToString(var[11]);
                TEfectivoentregado.Value = Convert.ToString(var[12]);
                TTotalfondo.InnerHtml = Convert.ToString(var[13]);
            }
        }

        public void mostrarcheques()
        {
            mostrarcheque1();
            mostrarcheque2();
        }

        public void mostrarcheque1()
        {
            string[] var = sn.mostrarchequesTQ1(id);
            for (int i = 0; i < var.Length; i++)
            {
                TChequesq.Value = Convert.ToString(var[3]);
                TMontoq.Value = Convert.ToString(var[4]);
                TTotalcheques.InnerHtml = Convert.ToString(var[5]);
                TTotalmonto.InnerHtml = Convert.ToString(var[6]);
            }
        }

        public void mostrarcheque2()
        {
            string[] var = sn.mostrarchequesTQ2(id);
            for (int i = 0; i < var.Length; i++)
            {
                TChequesa.Value = Convert.ToString(var[3]);
                TMontoa.Value = Convert.ToString(var[4]);
                TTotalcheques.InnerHtml = Convert.ToString(var[5]);
                TTotalmonto.InnerHtml = Convert.ToString(var[6]);
            }
        }

        protected void creararqueo_Click(object sender, EventArgs e)
        {
            string usuario3, consulta;
            usuario3 = Session["sesion_usuario"] as string;
            idusuario2 = sn.obteneridusuario(usuario3);
            consulta = sn.consultararqueoT(idusuario2);

            Session["op"] = "2";
            arqueo.Visible = true;
            Creararqueo.Visible = false;
            Buscararqueo.Visible = false;
            visualizar.Visible = true;
            imprimir.Visible = true;
            TNombreencargado.Value = Session["Nombre"] as string;
            operar.Enabled = true;
            EBuscar.Visible = false;

            //if (consulta == "")
            //{
            //    Session["op"] = "2";
            //    arqueo.Visible = true;
            //    Creararqueo.Visible = false;
            //    Buscararqueo.Visible = false;
            //    visualizar.Visible = true;
            //    imprimir.Visible = true;
            //    TNombreencargado.Value = Session["Nombre"] as string;
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
            Session["op"] = "1";
            puesto = Session["puesto_usuario"] as string;
            EBuscar.Visible = true;
            visualizar.Visible = false;
            imprimir.Visible = false;

            if (puesto == "1")
            {
                llenarcomboarqueos();
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
                    fechahora = valores2[2] + "-" + valores2[1] + "-" + valores2[0] + delimitador2 + horas[0] + ":" + horas[1];

                    TFecha.Attributes.Add("value", fechahora);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}