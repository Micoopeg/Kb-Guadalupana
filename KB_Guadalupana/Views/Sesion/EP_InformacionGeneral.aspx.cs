using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion
{

    public partial class EP_InformacionGeneral : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        string IGCIfc, IGPuestoc, IGAgenciac, IGAreac, IGPApellidoc, IGSApellidoc, IGPNombrec, IGSNombrec, IGDepartac, IGSMunicipioc, IGZonac, IGDireccc, IGDocc, IGNoDocc, IGPNombreadicionalc, IGPesoc;
        string IGFechac, IGNitc, IGNacioc, IGCelc, IGTelc, IGCorrc, IGEsc, IGPesc, IGRelc, tipotelefono;
        string IFCivilc, IFNombrec, IFOcupc, IFFechac, IFCasadac, IFBodac, IFcompletoc, IFParentescoc, IFTelc;
        string ECarrerac, ESemestrec, EAñoc, EUniversidadc, OEcursoc, OEestablecimientoc, OEmodalidadc, OEAñoc, OEDuracionc, idiomauni, idiomacurso;
        string Nombresesion, nombrehijo, ocupacionhijo, fechanachijo, comentariofamilia;
        string codigoloteactual;
        int num;
        string cifactual;
        string varestadoprocesocif;
        string codtelefono;

        string montariocaja, montariobanco, montariomoneda, montarioestatus, montariomonto, montariofondo, ahorrocaja;
        string ahorrobanco;
        string ahorromonedad;
        string ahorroestatus;
        string ahorromonto;
        string ahorrofondo;
        string cooperativabanco;
        string cooperativamoneda;
        string cooperativaestatus;
        string cooperativamonto;
        string cooperativafondo;
        string porcobrarbanco;
        string porcobrarmonto;
        string porcobrarfondo;
        string itipoinstitucion;
        string inombreinversion;
        string iplazo;
        string imoneda, imonto, iorigen;
        string mantenercif;
        string codigousuario;


        string equipocomputo, amuebladodesala, amuebladocomedor, televisorcantidad, televisorvalor, equiposonidocantidad, equiposonidovalor, lavadoracantidad, lavadoravalor, secadoracantidad, secadoravalor, estufacantidad, estufavalor, refrigeradoracantidad, refrigeradoravalor, telefonomcantidad, telefonomvalor;



        string tipoinmueble, bifolios, bilibro, bidireccion, bivalor, bidescripcion;
        string tipovehiculo, vehmarca, vehlinea, vehmodelo, vehnoplaca, inventarionombre, inventariomonto;
        string tipomaquinaria, descmaquinaria, montomaquinaria;
        string var; // estado del field
        string cifantiguo; //para ver si la persona tiene un cif antiguo
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            obtencioncampos();
            if (!IsPostBack)
            {
                try
                {
                    llenarcombos();
                    if (validarfechaingreso() == true)
                    {
                        if (validarusuario() == true)
                        {
                            if (validarcif() == true)
                            {
                                estadodeprocesocif();
                                num = Convert.ToInt32(varestadoprocesocif);
                                switch (num)
                                {
                                    case 0:
                                         Response.Write("ERROR TECNICO CONSULTAR CON EL DEPARTAMENTO DE INFORMATICA +ESTADO INCORRECTO+");
                                        break;
                                    case 1:
                                        Response.Write("ERROR TECNICO CONSULTAR CON EL DEPARTAMENTO DE INFORMATICA +ESTADO INCORRECTO no.2+");
                                        break;
                                    case 2:
                                        //Response.Write("EN PROCESO DE MODIFICCION" + cifactual);
                                       
                                        cargardatosaformulario();
                                        IGCIF.Disabled = true;
                                        llenargridviewcelulares();
                                        llenargridviewcuentasvarias();
                                        llenargridviewinversiones();
                                        llenargridviewestudiosuniversitarios();
                                        llenargridviewpasivos();
                                        llenargridviewtarjetas();
                                        llenargridviewcuentasencoperativa();
                                        llenargridviewestudios();
                                        llenargridviewcuentasporcobrar();
                                        llenargridviewbienesinmuebles();
                                        llenargridviewvehiculos();
                                        llenargridviewcuentasporpagar();
                                        llenargridviewhijos();
                                        break;
                                    case 3:
                                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('El Estado Patrimonial asociado al cif: "+cifactual+" se registro y envio correctamente.);", true);
                                        cargardatosaformulario();
                                        llenargridviewcelulares();
                                        llenargridviewcuentasvarias();
                                        llenargridviewpasivos();
                                        llenargridviewinversiones();
                                        llenargridviewestudiosuniversitarios();
                                        llenargridviewtarjetas();
                                        llenargridviewcuentasencoperativa();
                                        llenargridviewestudios();
                                        llenargridviewcuentasporcobrar();
                                        llenargridviewbienesinmuebles();
                                        llenargridviewvehiculos();
                                        llenargridviewcuentasporpagar();
                                        llenargridviewhijos();
                                        bloquearcamposparalectura();
                                        btnepigfinal.Disabled = true;
                                        btnfinalactivo.Disabled = true;
                                        btnguardaringreso.Disabled = true;
                                        btnguardarpasivo.Disabled = true;
                                        break;
                                    default:
                                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('ERROR TECNICO CONSULTAR CON EL DEPARTAMENTO DE INFORMATICA);", true);
                                        break;
                                }
                            }
                            else
                            {
                                if (validarcifantiguo() == true)
                                {
                                    cargardatosaformulario();
                                    string sig = logic.siguiente("ep_informaciongeneral", "codepinformaciongeneralcif");
                                    string[] valores1 = { sig, "1", "1", "1", "1", "102", "1", "1", "2", IGPNombre.Value, IGSNombre.Value, IGPApellido.Value, IGSApellido.Value, IGONombre.Value, IGFNacimiento.Value, IGNits.Value, IGNoDoc.Value, IGNacionalidad.Value, IGDireccion.Value, IGEstatura.Value, IGPeso.Value, IGReligion.Value, IGCorreo.Value, IGDPuestos.SelectedValue, id_input6.Value, IGCIF.Value };
                                    logic.insertartablas("ep_informaciongeneral", valores1);

                                    string sig2 = logic.siguiente("ep_infofamiliar", "codepinfofamiliar");
                                    string[] valores2 = { sig2, sig, "", "", "", "", "", "", "2020-04-08", "", "", "", "" };
                                    logic.insertartablas("ep_infofamiliar", valores2);

                                    string sig4 = logic.siguiente("ep_bactivos ", "codepbactivos ");
                                    string[] valores4 = { sig4, sig, "1", "1", "1", "" };
                                    logic.insertartablas("ep_bactivos ", valores4);

                                    string sig5 = logic.siguiente("ep_inventario ", "codepinventario");
                                    string[] valores5 = { sig5, sig, "", "", "" };
                                    logic.insertartablas("ep_inventario", valores5);

                                    string sig7 = logic.siguiente("ep_maquinaria ", "codepmaquinaria");
                                    string[] valores7 = { sig7, sig, "", "", "" };
                                    logic.insertartablas("ep_maquinaria", valores7);

                                    string sig8 = logic.siguiente("ep_menajedecasaencabezado ", "codepmenajedecasaencabezado");
                                    string[] valores8 = { sig8, sig, "" };
                                    logic.insertartablas("ep_menajedecasaencabezado", valores8);

                                    string sig9 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores9 = { sig9, sig8, "1", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores9);

                                    string sig10 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores10 = { sig10, sig8, "2", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores10);

                                    string sig11 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores11 = { sig11, sig8, "3", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores11);

                                    string sig12 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores12 = { sig12, sig8, "4", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores12);

                                    string sig13 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores13 = { sig13, sig8, "5", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores13);

                                    string sig14 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores14 = { sig14, sig8, "6", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores14);

                                    string sig15 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores15 = { sig15, sig8, "7", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores15);

                                    string sig16 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores16 = { sig16, sig8, "8", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores16);

                                    string sig17 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores17 = { sig17, sig8, "9", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores17);

                                    string sig18 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores18 = { sig18, sig8, "10", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores18);

                                    string sig19 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores19 = { sig19, sig8, "11", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores19);

                                    string sig20 = logic.siguiente("ep_deudasvarias ", "codepdeudasvarias");
                                    string[] valores20 = { sig20, sig, "", "" };
                                    logic.insertartablas("ep_deudasvarias", valores20);

                                    string sig21 = logic.siguiente("ep_pasivocontigente ", "codeppasivocontigente");
                                    string[] valores21 = { sig21, sig, "", "", "", "", "", "" };
                                    logic.insertartablas("ep_pasivocontigente", valores21);

                                    string sig22 = logic.siguiente("ep_controlingreso ", "codepcontrolingreso");
                                    string[] valores22 = { sig22, sig, "1", "1", "1" };
                                    logic.insertartablas("ep_controlingreso", valores22);

                                    string sig23 = logic.siguiente("ep_ingreso ", "codepingreso");
                                    string[] valores23 = { sig23, sig22, "", "", "" };
                                    logic.insertartablas("ep_ingreso", valores23);

                                    string sig24 = logic.siguiente("ep_negocio ", "codepnegocio");
                                    string[] valores24 = { sig24, sig22, "", "", "", "", "", "", "", "" };
                                    logic.insertartablas("ep_negocio", valores24);

                                    string sig25 = logic.siguiente("ep_remesas ", "codepremesas");
                                    string[] valores25 = { sig25, sig22, "", "", "", "1" };
                                    logic.insertartablas("ep_remesas", valores25);

                                    string sig26 = logic.siguiente("ep_egresos ", "codepegresos");
                                    string[] valores26 = { sig26, sig, "", "", "", "", "", "", "", "" };
                                    logic.insertartablas("ep_egresos", valores26);

                                    string sig27 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores27 = { sig27, "1", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores27);

                                    string sig28 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores28 = { sig28, "2", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores28);

                                    string sig29 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores29 = { sig29, "3", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores29);

                                    string sig30 = logic.siguiente("ep_contratistaproveedor ", "codepcontratistaproveedor");
                                    string[] valores30 = { sig29, sig, "2"};
                                    logic.insertartablas("codepcontratistaproveedor", valores30);


                                    guardarcelulares(sig);
                                    guardarcuentasvarias(sig);
                                    guardarpasivos(sig);
                                    guardartarjetas(sig);
                                    guardarestudios(sig);
                                    guardarinversiones(sig);
                                    guardabienesinmueble(sig);
                                    guardarvehiculos(sig);
                                    guardarhijos(sig);


                                    /*     LLENADO DE GRIDVIEWS   */
                                    llenargridviewcelulares();
                                    llenargridviewcuentasvarias();
                                    llenargridviewpasivos();
                                    llenargridviewtarjetas();
                                    llenargridviewestudios();
                                    llenargridviewbienesinmuebles();
                                    llenargridviewvehiculos();
                                    llenargridviewhijos();
                                    llenargridviewinversiones();
                                    llenargridviewestudiosuniversitarios();
                                    llenargridviewcuentasencoperativa();
                                    llenargridviewcuentasporcobrar();
                                    llenargridviewcuentasporpagar();


                                    string[] var1 = sn.consultarconcampo("gen_usuario", "gen_usuarionombre", Nombresesion);
                                    codigousuario = var1[0];
                                    string[] campos1 = { "codgenusuario", "codepadministracionlote", "codepinformaciongeneralcif" };
                                    string[] datos1 = { codigousuario, codigoloteactual, sig };
                                    logic.modificartablasdoscampos("ep_control", campos1, datos1);
                                    cifactual = sig;
                                    //cifai.Value = cifantiguo;
                                }
                                else
                                {
                                    //Response.Write("crear el reghi");
                                    //CREA UN NUEVO REGISTRO PARA NUEVO EMPLEADO
                                    string sig = logic.siguiente("ep_informaciongeneral", "codepinformaciongeneralcif");
                                    cifai.Value = sig;
                                    cifactual = cifai.Value;

                                    string[] valores1 = { sig, "1", "1", "1", "1", "102", "1", "1", "2", IGPNombre.Value, IGSNombre.Value, IGPApellido.Value, IGSApellido.Value, IGONombre.Value, IGFNacimiento.Value, IGNits.Value, IGNoDoc.Value, IGNacionalidad.Value, IGDireccion.Value, IGEstatura.Value, IGPeso.Value, IGReligion.Value, IGCorreo.Value, IGDPuestos.SelectedValue, id_input6.Value, IGCIF.Value };
                                    logic.insertartablas("ep_informaciongeneral", valores1);

                                    string sig2 = logic.siguiente("ep_infofamiliar", "codepinfofamiliar");
                                    string[] valores2 = { sig2, sig, "", "", "", "", "", "", "2020-04-08", "", "", "", "" };
                                    logic.insertartablas("ep_infofamiliar", valores2);

                                    string sig4 = logic.siguiente("ep_bactivos ", "codepbactivos ");
                                    string[] valores4 = { sig4, sig, "1", "1", "1", "" };
                                    logic.insertartablas("ep_bactivos ", valores4);

                                    string sig5 = logic.siguiente("ep_inventario ", "codepinventario");
                                    string[] valores5 = { sig5, sig, "", "", "" };
                                    logic.insertartablas("ep_inventario", valores5);


                                    string sig7 = logic.siguiente("ep_maquinaria ", "codepmaquinaria");
                                    string[] valores7 = { sig7, sig, "", "", "" };
                                    logic.insertartablas("ep_maquinaria", valores7);

                                    string sig8 = logic.siguiente("ep_menajedecasaencabezado ", "codepmenajedecasaencabezado");
                                    string[] valores8 = { sig8, sig, "" };
                                    logic.insertartablas("ep_menajedecasaencabezado", valores8);

                                    string sig9 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores9 = { sig9, sig8, "1", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores9);

                                    string sig10 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores10 = { sig10, sig8, "2", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores10);

                                    string sig11 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores11 = { sig11, sig8, "3", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores11);

                                    string sig12 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores12 = { sig12, sig8, "4", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores12);

                                    string sig13 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores13 = { sig13, sig8, "5", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores13);

                                    string sig14 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores14 = { sig14, sig8, "6", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores14);

                                    string sig15 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores15 = { sig15, sig8, "7", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores15);

                                    string sig16 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores16 = { sig16, sig8, "8", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores16);

                                    string sig17 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores17 = { sig17, sig8, "9", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores17);

                                    string sig18 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores18 = { sig18, sig8, "10", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores18);

                                    string sig19 = logic.siguiente("ep_menajecasadetalle ", "codepmenajecasadetalle");
                                    string[] valores19 = { sig19, sig8, "11", "", "" };
                                    logic.insertartablas("ep_menajecasadetalle", valores19);

                                    string sig20 = logic.siguiente("ep_deudasvarias ", "codepdeudasvarias");
                                    string[] valores20 = { sig20, sig, "", "" };
                                    logic.insertartablas("ep_deudasvarias", valores20);

                                    string sig21 = logic.siguiente("ep_pasivocontigente ", "codeppasivocontigente");
                                    string[] valores21 = { sig21, sig, "", "", "", "", "", "" };
                                    logic.insertartablas("ep_pasivocontigente", valores21);

                                    string sig22 = logic.siguiente("ep_controlingreso ", "codepcontrolingreso");
                                    string[] valores22 = { sig22, sig, "1", "1", "1" };
                                    logic.insertartablas("ep_controlingreso", valores22);

                                    string sig23 = logic.siguiente("ep_ingreso ", "codepingreso");
                                    string[] valores23 = { sig23, sig22, "", "", "" };
                                    logic.insertartablas("ep_ingreso", valores23);

                                    string sig24 = logic.siguiente("ep_negocio ", "codepnegocio");
                                    string[] valores24 = { sig24, sig22, "", "", "", "", "", "", "", "" };
                                    logic.insertartablas("ep_negocio", valores24);

                                    string sig25 = logic.siguiente("ep_remesas ", "codepremesas");
                                    string[] valores25 = { sig25, sig22, "", "", "", "1" };
                                    logic.insertartablas("ep_remesas", valores25);

                                    string sig26 = logic.siguiente("ep_egresos ", "codepegresos");
                                    string[] valores26 = { sig26, sig, "", "", "", "", "", "", "", "" };
                                    logic.insertartablas("ep_egresos", valores26);

                                    string sig27 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores27 = { sig27, "1", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores27);

                                    string sig28 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores28 = { sig28, "2", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores28);

                                    string sig29 = logic.siguiente("ep_personapep ", "codeppersonapep");
                                    string[] valores29 = { sig29, "3", sig, "1", "1", "", "", "", "", "" };
                                    logic.insertartablas("ep_personapep", valores29);

                                    string sig30 = logic.siguiente("ep_contratistaproveedor ", "codepcontratistaproveedor");
                                    string[] valores30 = { sig29, sig, "2" };
                                    logic.insertartablas("codepcontratistaproveedor", valores30);

                                    string[] var2 = sn.consultarconcampo("gen_usuario", "gen_usuarionombre", Nombresesion);
                                    codigousuario = var2[0];

                                    string[] campos = { "codgenusuario", "codepadministracionlote", "codepinformaciongeneralcif" };
                                    string[] datos = { codigousuario, codigoloteactual, sig };
                                    logic.modificartablasdoscampos("ep_control", campos, datos);

                                   
                                }
                            }
                        }
                        else
                        {
                            String script = "alert('EL USUARIO CON EL QUE HA INGRESADO NO EXISTE O NO ES VALIDO'); window.location.href= '../../Index.aspx';";
                            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                        }
                    }
                    else
                    {
                        String script = "alert('LA FECHA ACTUAL PARA EL INGRESO PATRIMONIAL HA VENCIDO'); window.location.href= '../../Index.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                    }
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
       }
        public void bloquearcamposparalectura()
        {
            IGCIF.Disabled = true;
            IGDPuestos.Enabled = false;
            IGAgencia1.Enabled = false;
            IGADepa1.Enabled = false;
            IGPApellido.Disabled = true;
            IGSApellido.Disabled = true;
            IGPNombre.Disabled = true;
            IGSNombre.Disabled = true;
            IGONombre.Disabled = true;
            IGPDepartamento1.Enabled = false;
            IGMunicipio1.Enabled = false;
            IGPAZona1.Enabled = false;
            IGDireccion.Disabled = true;
            IGDoc1.Enabled = false;
            IGNoDoc.Disabled = true;


            IGFNacimiento.Disabled = true;
            IGNits.Disabled = true;
            IGNacionalidad.Disabled = true;
            IGCorreo.Disabled = true;
            IGEstatura.Disabled = true;
            IGPeso.Disabled = true;
            IGReligion.Disabled = true;
            IGTCel1.Enabled = false;
            IGCelular.Disabled = true;

            //BTNS grid
            AgregarIG.Visible = false;
            GuardarIG.Visible = false;
            GridViewcelular.Enabled = false;

            id_categoriaestadocivil.Enabled = false;
            IFNombre.Disabled = true;
            IFOcupacion.Disabled = true;
            id_input5.Disabled = true;
            id_input6.Disabled = true;
            IFFecha.Disabled = true;

            //btns grid
            AgregarIF.Visible = false;
            GuardarIF.Visible = false;
            EliminarIF.Visible = false;

            Text1.Disabled = true;
            Text2.Disabled = true;
            Text3.Disabled = true;
            Date1.Disabled = true;
            //GridViewhijos.Enabled = false;
            IFNombreCo.Disabled = true;
            IFtel.Disabled = true;
            IFparenteso.Disabled = true;

            ENombreCarrera.Disabled = true;
            ESemestre.Disabled = true;
            EAño.Disabled = true;
            //idiomaestudio.Disabled = true;
            EUniversidad.Disabled = true;
            OECurso.Disabled = true;
            OEEstablecimiento.Disabled = true;
            OEModalidad.Disabled = true;
            OEAño.Disabled = true;
            OEDuracion.Disabled = true;
            Text4.Disabled = true;

            //btns grid
            AgregarEU.Visible = false;
            GuardarEU.Visible = false;
            EliminarIEU.Visible = false;
            GridViewEstudios.Enabled = false;

            //ACTIVOS
            ACCaja.Disabled = true;
            DropDownList1.Disabled = true;
            ACNBanco1.Enabled = false;
            ACEstatus1.Enabled = false;
            ACTMoneda1.Enabled = false;
            ACMonto.Disabled = true;
            ACOFondos.Disabled = true;
            AgregarAC1.Visible = false;
            GuardarAC1.Visible = false;
            EliminarAC1.Visible = false;
            GridViewcuentasvarias.Enabled = false;
            AgregarACC1.Visible = false;
            GuardarACC1.Visible = false;
            EliminarACC1.Visible = false;
            ACCNBanco1.Enabled = false;
            ACCTMoneda1.Enabled = false;
            ACCEstatus1.Enabled = false;
            ACCMonto.Disabled = true;
            ACCOFondos.Disabled = true;
            GridViewcuentascooperativa.Enabled = false;
            Select1.Disabled = true;
            AgregarAP1.Visible = false;
            GuardarAP1.Visible = false;
            EliminarAP1.Visible = false;
            ACPNombre.Disabled = true;
            ACPMonto.Disabled = true;
            ACPMotivo.Disabled = true;
            GridViewcuentasporcobrar.Enabled = false;
            Text5.Disabled = true;
            Number1.Disabled = true;

            //ACIInst.Disabled = true;
            //ACINombre.Disabled = true;
            ACIPlazo.Disabled = true;
            ACIMoneda1.Enabled = false;
            ACIMonto.Disabled = true;

            AgregarBI1.Visible = false;
            GuardarBI1.Visible = false;
            EliminarBI1.Visible = false;
            ACTInmueble1.Enabled = false;
            ACFolio.Disabled = true;
            ACLibro.Disabled = true;
            ACDireccion.Disabled = true;
            ACFinca.Disabled = true;
            ACVActual.Disabled = true;
            ACDes.Disabled = true;
            ACcomentarioinmueble.Disabled = true;
            GridViewbienesinmuebles.Enabled = false;

            AgregarV1.Visible = false;
            GuardarV1.Visible = false;
            EliminarV1.Visible = false;
            ACTVehiculo1.Enabled = false;
            
            ACMarca.Disabled = true;
            ACLinea.Disabled = true;
            ACModelo.Disabled = true;
            ACPlaca.Disabled = true;
            ACCome.Disabled = true;
            GridViewvehiculos.Enabled = false;

            ACTMAquinaria.Disabled = true;
            Number2.Disabled = true;
            ACComentarios.Disabled = true;
            ACMEComputo.Disabled = true;
            ACMASala.Disabled = true;
            ACMAComedor.Disabled = true;
            ACMATelevisorC.Disabled = true;
            ACMATelevisorV.Disabled = true;
            ACMASonidoC.Disabled = true;
            ACMASonidoV.Disabled = true;
            ACMALavadoraC.Disabled = true;
            ACMALavadoraV.Disabled = true;
            ACMASecadoraC.Disabled = true;
            ACMASecadoraV.Disabled = true;
            ACMAEstufaC.Disabled = true;
            ACMAEstufaV.Disabled = true;
            ACMARefrigeradoraC.Disabled = true;
            ACMARefrigeradoraV.Disabled = true;
            ACMATMovilC.Disabled = true;
            ACMATMovilV.Disabled = true;
            ACMAODes.Disabled = true;
            ACMACantidadO.Disabled = true;

            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;

            //grid iversiones
            A1.Disabled = true;
            A2.Disabled = true;
            A3.Disabled = true;


            //PASIVOS
            TipoCuenta.Enabled = false;
            PCPDes1.Disabled = true;
            PCPMonto1.Disabled = true;
            AgregarPC1.Visible = false;
            GuardarPC1.Visible = false;
            EliminarPC1.Visible = false;
            GridViewcuentasporpagar.Enabled = false;
            AgregarPP1.Visible = false;
            GuardarPP1.Visible = false;
            EliminarPP1.Visible = false;
            PTPrestamo1.Enabled = false;
            PNEntidad1.Enabled = false;
            PNPNEntidadnombre1.Enabled = false;
            PMInicial.Disabled = true;
            PSActual.Disabled = true;
            PFDestino.Disabled = true;
            Datedesembolso.Disabled = true;
            Datefinalizacion.Disabled = true;
            GridViewpasivos.Enabled = false;
            AgregarTC1.Visible = false;
            GuardarTC1.Visible = false;
            EliminarTC1.Visible = false;
            PTTEntidad1.Enabled = false;
            PTTNombre1.Enabled = false;
            PTTLimite.Disabled = true;
            PTTLimite2.Disabled = true;
            PTTSaldo.Disabled = true;
            GridViewtarjetas.Enabled = false;
            PODeudas.Disabled = true;
            POMonto.Disabled = true;
            PTNEntidad.Disabled = true;
            PTNDeudor.Disabled = true;
            PTRelacion.Disabled = true;
            PTSaldo.Disabled = true;

            fechadembolso.Disabled = true;
            fechafinalizacion.Disabled = true;

            //INGRESOS Y EGRESOS
            ISBase.Disabled = true;
            IBoni.Disabled = true;
            ICMensuales.Disabled = true;
            rdbnonegociopropio.Disabled = true;
            rdbsinegociopropio.Disabled = true;
            //ITNegocio.Disabled = true;
            ITNNegocio.Disabled = true;
            ITpatente.Disabled = true;
            ITNEmpleados.Disabled = true;
            ITONegocio.Disabled = true;
            ITIMensuales.Disabled = true;
            ITEMensuales.Disabled = true;
            ITDireccion.Disabled = true;
            rdbsiRemesas.Disabled = true;
            rdbnoRemesas.Disabled = true;
            ISRNombre.Disabled = true;
            ISRRelacion.Disabled = true;
            ISRMonto.Disabled = true;
            ISRPeriodo.Enabled = false;
            ITAlimen.Disabled = true;
            ITTras.Disabled = true;
            ITPago.Disabled = true;
            ITPrestamos.Disabled = true;
            ITTarjeta.Disabled = true;
            ITVestuario.Disabled = true;
            ITRecreacion.Disabled = true;
            ITOtros.Disabled = true;
            rdbsiinteres.Disabled = true;
            rdbnointeres.Disabled = true;
            ENIns.Disabled = true;
            EPuesto.Disabled = true;
            EPais.Disabled = true;
            rdbsipep.Disabled = true;
            rdbnopep.Disabled = true;
            EParentesco1.Enabled = false;
            Modalidad1.Enabled = false;
            Text8.Disabled = true;
            Text9.Disabled = true;
            Text10.Disabled = true;
            Text11.Disabled = true;
            rdbsiasociadopep.Disabled = true;
            rdbnoasociadopep.Disabled = true;
            EParentesco2.Enabled = false;
            Modalidad2.Enabled = false;
            EMotivos.Disabled = true;
            ENombres.Disabled = true;
            EINombre.Disabled = true;
            EIPuesto1.Disabled = true;
            EPPais1.Disabled = true;

        }
        public void cargardatosaformulario()
        {
            mostrarcamposgeneral();
            mostrarcamposfam();
            mostrarcaja();
            mostrarinventario();
            mostrarmaquinaria();
            mostrarmenaje1();
            mostrarmenaje2();
            mostrarmenaje3();
            mostrarmenaje4();
            mostrarmenaje5();
            mostrarmenaje6();
            mostrarmenaje7();
            mostrarmenaje8();
            mostrarmenaje9();
            mostrarmenaje10();
            mostrarmenaje11();
            mostrardeudas();
            mostrarpasivocontigente();
            mostraringresos();
            mostrarnegocios();
            mostrarremesas();
            mostraregresos();
            mostrarexpuestapep();
            mostrarparentescopep();
            mostrarasociadocopep();
            mostrarcontratistaproveedor();

        }
        public void llenarcombos()
        {
            llenarcombotipoinstitucioninversion();
            llenarcombosucursal();
        
            llenarcombodepartamento();
            llenarcombomunicipio();
            llenarcombozona();
            llenarcombotipodoc();
            llenarcomboestadocivil();
            llenarcombotipomonedacuentas();
            llenarcombotipomoneda1();
            llenarcombotipomonedacuentascooperativa();
            llenarcombotipomoneda3();
            llenarcomboestatuscuentas();
            llenarcombotipovehiculo();
            llenarcombotipoinmueble();
            llenarcombotipotelefono();
            llenarcomboestatuscuentascooperativa();
            llenarcombotipocuentaporpagar();
            llenarcombotipoinstitucion();
            llenarcombotipoprestamos();
            //llenarcombocuentas();
            llenarcomboinstitucionescuenta();
            llenarcombotipoinstituciontarjeta();
            llenarcombocooperativas();
            llenarcomboparentesco1();
            llenarcomboparentesco2();
            llenarcombonacionalidad1();
            llenarcombonacionalidad2();
        }

        public void obtencioncampos()
        {
            //Usuario Sesion
            Nombresesion = Session["sesion_usuario"].ToString();
            NombreUsuario.InnerText = Session["nombre"].ToString();
            cifactual = cifai.Value;
            Session["cif"] = "31";
        }


        //Funciones de carga combobox
       
       

        public void llenarcombopuesto()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_area;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    IGDPuestos.DataSource = ds;
                    IGDPuestos.DataTextField = "gen_areanombre";
                    IGDPuestos.DataValueField = "codgenarea";
                    IGDPuestos.DataBind();
                    IGDPuestos.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombodepartamento()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_departamento;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Departamento");
                    IGPDepartamento1.DataSource = ds;
                    IGPDepartamento1.DataTextField = "gen_departamentonombre";
                    IGPDepartamento1.DataValueField = "codgendepartamento";
                    IGPDepartamento1.DataBind();
                    IGPDepartamento1.Items.Insert(0, new ListItem("[Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }               
        }
        public void llenarcombomunicipio()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_municipio;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Municipio");
                    IGMunicipio1.DataSource = ds;
                    IGMunicipio1.DataTextField = "gen_municipionombre";
                    IGMunicipio1.DataValueField = "codgenmunicipio";
                    IGMunicipio1.DataBind();
                    IGMunicipio1.Items.Insert(0, new ListItem("[Municipio]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombozona()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_zona;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Zona");
                    IGPAZona1.DataSource = ds;
                    IGPAZona1.DataTextField = "gen_zonanombre";
                    IGPAZona1.DataValueField = "codgenzona";
                    IGPAZona1.DataBind();
                    IGPAZona1.Items.Insert(0, new ListItem("[Zona]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipodoc()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_tipoidentificacion;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Identificacion");
                    IGDoc1.DataSource = ds;
                    IGDoc1.DataTextField = "gen_tipoidentificacionnombre";
                    IGDoc1.DataValueField = "codgentipoidentificacion";
                    IGDoc1.DataBind();
                    IGDoc1.Items.Insert(0, new ListItem("[Tipo De Identificacion]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboestadocivil()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_estadocivil;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "estadocivil");
                    id_categoriaestadocivil.DataSource = ds;
                    id_categoriaestadocivil.DataTextField = "ep_estadocivilnombre";
                    id_categoriaestadocivil.DataValueField = "codepestadocivil";
                    id_categoriaestadocivil.DataBind();
                    id_categoriaestadocivil.Items.Insert(0, new ListItem("[Estado Civil]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipomonedacuentas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipomoneda;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipomoneda");
                    ACTMoneda1.DataSource = ds;
                    ACTMoneda1.DataTextField = "ep_tipomonedanombre";
                    ACTMoneda1.DataValueField = "codeptipomoneda";
                    ACTMoneda1.DataBind();
                    ACTMoneda1.Items.Insert(0, new ListItem("[Tipo Moneda]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipomoneda1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipomoneda;";
                    MySqlDataAdapter myCommand1 = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds1 = new DataSet();
                    myCommand1.Fill(ds1, "tipomoneda1");
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipomonedacuentascooperativa()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipomoneda;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipomoneda");
                    ACCTMoneda1.DataSource = ds;
                    ACCTMoneda1.DataTextField = "ep_tipomonedanombre";
                    ACCTMoneda1.DataValueField = "codeptipomoneda";
                    ACCTMoneda1.DataBind();
                    ACCTMoneda1.Items.Insert(0, new ListItem("[Tipo Moneda]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipomoneda3()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipomoneda;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds3 = new DataSet();
                    myCommand.Fill(ds3, "tipomoneda");
                    ACIMoneda1.DataSource = ds3;
                    ACIMoneda1.DataTextField = "ep_tipomonedanombre";
                    ACIMoneda1.DataValueField = "codeptipomoneda";
                    ACIMoneda1.DataBind();
                    ACIMoneda1.Items.Insert(0, new ListItem("[Tipo Moneda]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcomboestatuscuentas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoestatuscuenta;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoestatus");
                    ACEstatus1.DataSource = ds;
                    ACEstatus1.DataTextField = "ep_tipoestatuscuentanombre";
                    ACEstatus1.DataValueField = "codeptipoestatuscuenta";
                    ACEstatus1.DataBind();
                    ACEstatus1.Items.Insert(0, new ListItem("[Tipo Estatus]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboestatuscuentascooperativa()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoestatuscuenta;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoestatus");
                    ACCEstatus1.DataSource = ds;
                    ACCEstatus1.DataTextField = "ep_tipoestatuscuentanombre";
                    ACCEstatus1.DataValueField = "codeptipoestatuscuenta";
                    ACCEstatus1.DataBind();
                    ACCEstatus1.Items.Insert(0, new ListItem("[Tipo Estatus]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipoinmueble()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoinmueble;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoinmueble");
                    ACTInmueble1.DataSource = ds;
                    ACTInmueble1.DataTextField = "ep_tipoinmueblenombre";
                    ACTInmueble1.DataValueField = "codeptipoinmueble";
                    ACTInmueble1.DataBind();
                    ACTInmueble1.Items.Insert(0, new ListItem("[Tipo Inmueble]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipotelefono()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipotelefono;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipotelefono");
                    IGTCel1.DataSource = ds;
                    IGTCel1.DataTextField = "ep_tipotelefononombre";
                    IGTCel1.DataValueField = "codeptipotelefono";
                    IGTCel1.DataBind();
                    IGTCel1.Items.Insert(0, new ListItem("[Tipo Telefono]", "0"));

                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipovehiculo()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipovehiculo;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipovehiculo");
                    ACTVehiculo1.DataSource = ds;
                    ACTVehiculo1.DataTextField = "ep_tipovehiculonombre";
                    ACTVehiculo1.DataValueField = "codeptipovehiculo";
                    ACTVehiculo1.DataBind();
                    ACTVehiculo1.Items.Insert(0, new ListItem("[Tipo Vehiculo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipocuentaporpagar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipocuentaspopagar;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipocuentasporpagar");
                    TipoCuenta.DataSource = ds;
                    TipoCuenta.DataTextField = "ep_tipocuentaspopagarnombre";
                    TipoCuenta.DataValueField = "codeptipocuentaspopagar";
                    TipoCuenta.DataBind();
                    TipoCuenta.Items.Insert(0, new ListItem("[Corto/Largo Plazo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipoprestamos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoprestamo;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoprestamo");
                    PTPrestamo1.DataSource = ds;
                    PTPrestamo1.DataTextField = "ep_tipoprestamonombre";
                    PTPrestamo1.DataValueField = "codeptipoprestamo";
                    PTPrestamo1.DataBind();
                    PTPrestamo1.Items.Insert(0, new ListItem("[Tipo de prestamo]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipoinstitucion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoinstitucion;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoinstitucion");
                    PNEntidad1.DataSource = ds;
                    PNEntidad1.DataTextField = "ep_tipoinstitucionnombre";
                    PNEntidad1.DataValueField = "codeptipoinstitucion";
                    PNEntidad1.DataBind();
                    PNEntidad1.Items.Insert(0, new ListItem("[Tipo de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboinstitucion(long codtipoinstitucion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_institucion where codeptipoinstitucion='" + codtipoinstitucion + "' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "institucion");
                    PNPNEntidadnombre1.DataSource = ds;
                    PNPNEntidadnombre1.DataTextField = "ep_institucionnombre";
                    PNPNEntidadnombre1.DataValueField = "codepinstitucion";
                    PNPNEntidadnombre1.DataBind();
                    PNPNEntidadnombre1.Items.Insert(0, new ListItem("[Nombre de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombotipoinstitucioninversion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoinstitucion;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoinstitucion");
                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "ep_tipoinstitucionnombre";
                    DropDownList2.DataValueField = "codeptipoinstitucion";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem("[Tipo de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboinstitucioninversion(long codtipoinstitucion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_institucion where codeptipoinstitucion='" + codtipoinstitucion + "' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "institucion");
                    DropDownList3.DataSource = ds;
                    DropDownList3.DataTextField = "ep_institucionnombre";
                    DropDownList3.DataValueField = "codepinstitucion";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem("[Nombre de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombosucursal()  //SUCURSAL AHORA SERA GERENCIAS
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_sucursal;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Sucursall");
                    IGAgencia1.DataSource = ds;
                    IGAgencia1.DataTextField = "gen_sucursalnombre";
                    IGAgencia1.DataValueField = "codgensucursal";
                    IGAgencia1.DataBind();
                    IGAgencia1.Items.Insert(0, new ListItem("[Gerencias]", "0"));
                }
                catch { }
            }
        }
        public void llenarcomboarea(long codtiposucursal)   //AREA SERA DEPARTAMENTO
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_area where codgensucursal='"+codtiposucursal+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "area");
                    IGADepa1.DataSource = ds;
                    IGADepa1.DataTextField = "gen_areanombre";
                    IGADepa1.DataValueField = "codgenarea";
                    IGADepa1.DataBind();
                    IGADepa1.Items.Insert(0, new ListItem("[Area/Departamento]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombopuesto(long codtipodepartamento)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_puestos where codgenarea='" + codtipodepartamento + "' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "institucion");
                    IGDPuestos.DataSource = ds;
                    IGDPuestos.DataTextField = "gen_puestosnombre";
                    IGDPuestos.DataValueField = "codgenpuestos";
                    IGDPuestos.DataBind();
                    IGDPuestos.Items.Insert(0, new ListItem("[Nombre de puestos]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcombocooperativas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * FROM ep_institucion WHERE codeptipoinstitucion=3;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "cooperativas2");
                    ACCNBanco1.DataSource = ds;
                    ACCNBanco1.DataTextField = "ep_institucionnombre";
                    ACCNBanco1.DataValueField = "codepinstitucion";
                    ACCNBanco1.DataBind();
                    ACCNBanco1.Items.Insert(0, new ListItem("[Cooperativas]", "0"));


                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        //public void llenarcombocuentas()
        //{
        //    using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            string QueryString = "SELECT * FROM ep_tipocuenta;";
        //            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
        //            DataSet ds = new DataSet();
        //            myCommand.Fill(ds, "cooperativas");
        //            DropDownList1.DataSource = ds;
        //            DropDownList1.DataTextField = "ep_tipocuentanombre";
        //            DropDownList1.DataValueField = "codeptipocuenta";
        //            DropDownList1.DataBind();
        //            DropDownList1.Items.Insert(0, new ListItem("[Tipo de cuenta]", "0"));
        //        }
        //        catch { Console.WriteLine("Verifique los campos"); }
        //    }
        //}
        public void llenarcomboinstitucionescuenta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM ep_institucion where codeptipoinstitucion=1";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "cooperativas");
                    ACNBanco1.DataSource = ds;
                    ACNBanco1.DataTextField = "ep_institucionnombre";
                    ACNBanco1.DataValueField = "codepinstitucion";
                    ACNBanco1.DataBind();
                    ACNBanco1.Items.Insert(0, new ListItem("[Instituciones]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombotipoinstituciontarjeta()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoinstitucion;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoinstitucion1");
                    PTTEntidad1.DataSource = ds;
                    PTTEntidad1.DataTextField = "ep_tipoinstitucionnombre";
                    PTTEntidad1.DataValueField = "codeptipoinstitucion";
                    PTTEntidad1.DataBind();
                    PTTEntidad1.Items.Insert(0, new ListItem("[Tipo de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboinstituciontarjeta(long codtipoinstitucion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_institucion where codeptipoinstitucion='" + codtipoinstitucion + "' ;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "institucion1");
                    PTTNombre1.DataSource = ds;
                    PTTNombre1.DataTextField = "ep_institucionnombre";
                    PTTNombre1.DataValueField = "codepinstitucion";
                    PTTNombre1.DataBind();
                    PTTNombre1.Items.Insert(0, new ListItem("[Nombre de Institución]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenarcomboparentesco1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoparentesco;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoparentesco");
                    Modalidad1.DataSource = ds;
                    Modalidad1.DataTextField = "ep_tipoparentesconombre";
                    Modalidad1.DataValueField = "codeptipoparentesco";
                    Modalidad1.DataBind();
                    Modalidad1.Items.Insert(0, new ListItem("[Tipo de Parentesco]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcomboparentesco2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tipoparentesco;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tipoparentesco2");
                    Modalidad2.DataSource = ds;
                    Modalidad2.DataTextField = "ep_tipoparentesconombre";
                    Modalidad2.DataValueField = "codeptipoparentesco";
                    Modalidad2.DataBind();
                    Modalidad2.Items.Insert(0, new ListItem("[Tipo de Parentesco]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombonacionalidad1()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tiponacionalidad;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tiponacionalidad");
                    EParentesco1.DataSource = ds;
                    EParentesco1.DataTextField = "ep_tiponacionalidadnombre";
                    EParentesco1.DataValueField = "codeptiponacionalidad";
                    EParentesco1.DataBind();
                    EParentesco1.Items.Insert(0, new ListItem("[Tipo de Nacionalidad]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }
        public void llenarcombonacionalidad2()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from ep_tiponacionalidad;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString,sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "tiponacionalidad2");
                    EParentesco2.DataSource = ds;
                    EParentesco2.DataTextField = "ep_tiponacionalidadnombre";
                    EParentesco2.DataValueField = "codeptiponacionalidad";
                    EParentesco2.DataBind();
                    EParentesco2.Items.Insert(0, new ListItem("[Tipo de Nacionalidad]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void IGAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGADepa1.Visible = true;
            IGADepa1.ClearSelection();
            llenarcomboarea(long.Parse(IGAgencia1.SelectedValue));
        }
        protected void IGADepa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGDPuestos.Visible = true;
            IGDPuestos.ClearSelection();
            llenarcombopuesto(long.Parse(IGADepa1.SelectedValue));
        }


        protected void PNEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNPNEntidadnombre1.Visible = true;
            PNPNEntidadnombre1.ClearSelection();
            llenarcomboinstitucion(long.Parse(PNEntidad1.SelectedValue));
        }

        protected void tipoinstitucioninversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Visible = true;
            DropDownList3.ClearSelection();
            llenarcomboinstitucioninversion(long.Parse(DropDownList2.SelectedValue));
        }

        protected void PTTEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PTTNombre1.Visible = true;
            PTTNombre1.ClearSelection();
            llenarcomboinstituciontarjeta(long.Parse(PTTEntidad1.SelectedValue));
        }

        //------------------------------------------------CODIGO SIN UTILIZAR--------------------------------------//
        protected void cbosucursal_Click(object sender, EventArgs e)
        {
            IGAgenciac = IGAgencia1.Text;
            IGAgencia1.Focus();



        }
        protected void cboarea_Click(object sender, EventArgs e)
        {
            IGAreac = IGADepa1.Text;
        }
        protected void cbodepartamento_Click(object sender, EventArgs e)
        {
            IGDepartac = IGPDepartamento1.Text;
        }
        protected void cbomunicipio_Click(object sender, EventArgs e)
        {
            IGSMunicipioc = IGMunicipio1.Text;
        }
        protected void cbozona_Click(object sender, EventArgs e)
        {
            IGZonac = IGPAZona1.Text;
        }
        protected void cbotipodoc_Click(object sender, EventArgs e)
        {
            IGDocc = IGDoc1.Text;
        }
        protected void cboestadocivil_Click(object sender, EventArgs e)
        {
            IFCivilc = id_categoriaestadocivil.Text;
        }
        protected void cbotipomoneda1_Click(object sender, EventArgs e)
        {
            montariomoneda = ACTMoneda1.Text;
        }
        protected void cbotipomoneda3_Click(object sender, EventArgs e)
        {
            cooperativamoneda = ACCTMoneda1.Text;
        }
        protected void cbotipomoneda4_Click(object sender, EventArgs e)
        {
            imoneda = ACIMoneda1.Text;
        }
        protected void cbotipoestatus1_Click(object sender, EventArgs e)
        {
            montarioestatus = ACEstatus1.Text;
        }
        protected void cbotipoestatus3_Click(object sender, EventArgs e)
        {
            cooperativaestatus = ACCEstatus1.Text;
        }
        protected void cbotipoinmueble_Click(object sender, EventArgs e)
        {
            tipoinmueble = ACTInmueble1.Text;
        }
        protected void cbotipovehiculo_Click(object sender, EventArgs e)
        {
            tipovehiculo = ACTVehiculo1.Text;
        }
        protected void cbotipotelefono_Click(object sender, EventArgs e)
        {
            tipotelefono = IGTCel1.Text;
        }

        //--------------------------------------------------------------------------------------//
        public bool validarfechaingreso()
        {
            DateTime fechaactual = Convert.ToDateTime("10/01/1999"); //FECHA PARA VLAIDACIONES DE NO ESTAR VACIO EL CAMPO
            string[] var1 = sn.fechaactual();
            for (int i = 0; i < var1.Length; i++)
            {
                fechaactual = Convert.ToDateTime(var1[0]);
            }
            string[] var2 = sn.validarfechadeingreso_ep();
            for (int i = 0; i < var2.Length; i++)
            {
                DateTime fecha1 = Convert.ToDateTime(var2[1]);
                DateTime fecha2 = Convert.ToDateTime(var2[2]);
                if ((fechaactual >= fecha1) && (fechaactual <= fecha2))
                {
                    codigoloteactual = var2[3];
                    return true;
                }
            }
            return false;

        }
        public bool validarusuario()
        {

            string[] var3 = sn.validarfechadeingreso_ep();
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string am = var3[centinela];



                centinela = centinela + 5;                          //El centinela debe sumarle la cantidad de columnas de la tabla
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
                if (Nombresesion == am)
                {
                    return true;
                }

            }
            return false;
            
      }
        public bool validarcif()
        {
            string[] var2 = sn.busquedacif(Nombresesion, codigoloteactual);
            string codigocif1 = Convert.ToString(var2[0]);
            if (codigocif1 == null || codigocif1 == "0")
            {
               
                return false;
            }
            else
            {
                cifactual = codigocif1;
                cifai.Value = cifactual;
                return true;
            }
       
        }
        public void estadodeprocesocif()
        {
            string[] var2 = sn.estadodeprocesocif(cifactual);
            for (int i = 0; i < var2.Length; i++)
            {
                varestadoprocesocif = var2[0];
            }
        }

        public bool validarcifantiguo()
        {
            string[] var2 = sn.validarcifantiguo(Nombresesion);

            if (var2[0] == "" || var2[0] == null)
            {
                return false;
            }
            else
            {
                cifantiguo = Convert.ToString(var2[0]);
                cifactual = cifantiguo;
                return true;
            }
        }

        ///////////////////////////////////////////////Botones Guardar o modificar///////////////////////////////////////////
        ///

        protected void btnguardarepfinyenviar_Click(object sender, EventArgs e)
        {
            guardaringreso();
            guardarnegocio();
            guardarremesas();
            guardaregresos();
            guardarexpuestopep();
            guardarparentescopep();
            guardarasociadopep();
            guardarcontratistaproveedor();
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "codgensucursal", "codepestadocivil", "codgentipoidentificacion",
                "codgendepartamento", "codgenmunicipio", "codgenzona", "codgenarea", "codeptipoestado", "ep_informaciongeneralprimernombre",
            "ep_informaciongeneralsegundonombre","ep_informaciongeneralprimerapellido","ep_informaciongeneralsegundoapellido","ep_informaciongeneralnombreadicional",
            "ep_informaciongeneralfechanacimiento","ep_informaciongeneralnit","ep_informaciongeneralnumeroidentificacion","ep_informaciongeneralnacionalidad",
                "ep_informaciongeneraldireccion","ep_informaciongeneralestatura","ep_informaciongeneralpeso","ep_informaciongeneralreligion","ep_informaciongeneralcorreo",
            "ep_informaciongeneralpuesto","ep_informaciongeneralfechaboda","ep_informaciongeneralcif"};
                string[] valores = {cifactual , IGAgencia1.SelectedValue, id_categoriaestadocivil.SelectedValue, IGDoc1.SelectedValue, IGPDepartamento1 .SelectedValue,
            IGMunicipio1.SelectedValue,IGPAZona1.SelectedValue,IGADepa1.SelectedValue,"3",IGPNombre.Value,IGSNombre.Value,IGPApellido.Value,
            IGSApellido.Value,IGONombre.Value,IGFNacimiento.Value,IGNits.Value,IGNoDoc.Value,IGNacionalidad.Value,IGDireccion.Value,IGEstatura.Value,IGPeso.Value,IGReligion.Value,
            IGCorreo.Value,IGDPuestos.SelectedValue,id_input6.Value,IGCIF.Value};
                try
                {
                    logic.modificartablas("ep_informaciongeneral", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
            String script = "alert('EL ESTADO PATRIMONIAL HA SIDO ENVIADO'); window.location.href= '../../Index.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
        }

        protected void btnepguardarinfogeneral_Click(object sender, EventArgs e)
        {
            guardarinicio();
            guardarfam();
        }
        protected void btnguardaractivo_Click(object sender, EventArgs e)
        {
            guardaractivos();
            guardarinventarios();
            guardarmaquinaria();
            guardarmenaje1();
            guardarmenaje2();
            guardarmenaje3();
            guardarmenaje4();
            guardarmenaje5();
            guardarmenaje6();
            guardarmenaje7();
            guardarmenaje8();
            guardarmenaje9();
            guardarmenaje10();
            guardarmenaje11();
        }
        protected void guardarepfinalpasivos1_Click(object sender, EventArgs e)
        {
            guardarotrasdeudas();
            guardarpasivocontigente();
         
        }

        public void guardarinicio()
        {
            if (IGDPuestos.SelectedValue == "0" || IGAgencia1.SelectedValue == "0" || IGADepa1.SelectedValue == "0" || IGPDepartamento1.SelectedValue == "0" || IGMunicipio1.SelectedValue == "0" || IGPAZona1.SelectedValue == "0" || IGDoc1.SelectedValue == "0" || id_categoriaestadocivil.SelectedValue == "0")
            {
                String script = "alert('Verifique que los campos esten llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
            else
            {
                if (cifactual != null)
                {
                    string[] campos = { "codepinformaciongeneralcif", "codgensucursal", "codepestadocivil", "codgentipoidentificacion",
                "codgendepartamento", "codgenmunicipio", "codgenzona", "codgenarea", "codeptipoestado", "ep_informaciongeneralprimernombre",
            "ep_informaciongeneralsegundonombre","ep_informaciongeneralprimerapellido","ep_informaciongeneralsegundoapellido","ep_informaciongeneralnombreadicional",
            "ep_informaciongeneralfechanacimiento","ep_informaciongeneralnit","ep_informaciongeneralnumeroidentificacion","ep_informaciongeneralnacionalidad",
                "ep_informaciongeneraldireccion","ep_informaciongeneralestatura","ep_informaciongeneralpeso","ep_informaciongeneralreligion","ep_informaciongeneralcorreo",
            "codgenpuesto","ep_informaciongeneralfechaboda","ep_informaciongeneralcif"};
                    string[] valores = {cifactual , IGAgencia1.SelectedValue, id_categoriaestadocivil.SelectedValue, IGDoc1.SelectedValue, IGPDepartamento1.SelectedValue,
            IGMunicipio1.SelectedValue,IGPAZona1.SelectedValue,IGADepa1.SelectedValue,"2",IGPNombre.Value,IGSNombre.Value,IGPApellido.Value,
            IGSApellido.Value,IGONombre.Value,IGFNacimiento.Value,IGNits.Value,IGNoDoc.Value,IGNacionalidad.Value,IGDireccion.Value,IGEstatura.Value,IGPeso.Value,IGReligion.Value,
            IGCorreo.Value,IGDPuestos.SelectedValue,id_input6.Value,IGCIF.Value};
                    try
                    {
                        logic.modificartablas("ep_informaciongeneral", campos, valores);
                    }
                    catch { }
                    finally { try { cn.desconectar(); } catch { } }
                    //for (int i = 0; i < campos.Length; i++)
                    //{
                    //    Response.Write(campos[i]); Response.Write(valores[i]);
                    //}
                }
            }




        }
        public void guardarfam()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_infofamiliarnombreconyuge", "ep_infofamiliarocupacionconyuge", "ep_infofamiliarapellidocascada",
                "ep_infofamiliarfechanacimientoconyuge","ep_infofamiliarnombreemergencia","ep_infofamiliarnumeroemergencia","ep_infofamiliarparentesco"};
                string[] valores = { cifactual, IFNombre.Value, IFOcupacion.Value, id_input5.Value, IFFecha.Value, IFNombreCo.Value, IFtel.Value, IFparenteso.Value };
                try
                {
                    logic.modificartablas("ep_infofamiliar", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void guardarcontratistaproveedor()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_contratistaproveedor_si_no" };
                string[] valores = { cifactual, Dropdownlist23.SelectedValue};
                try
                {
                    logic.modificartablas("ep_contratistaproveedor", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void guardaractivos()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_bactivoscaja" };
                string[] valores = { cifactual, ACCaja.Value };
                try
                {
                    logic.modificartablas("ep_bactivos", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarinventarios()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_inventarionombre", "ep_inventariomonto" };
                string[] valores = { cifactual, Text5.Value, Number1.Value };
                try
                {
                    logic.modificartablas("ep_inventario", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
       
        public void guardarmaquinaria()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_maquinarianombre", "ep_maquinariamonto", "ep_maquinariadescripcion" };
                string[] valores = { cifactual, ACTMAquinaria.Value, Number2.Value, ACComentarios.Value };
                try
                {
                    logic.modificartablas("ep_maquinaria", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje1()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];
            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "1", ACMEComputo.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje2()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "2", ACMASala.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje3()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];
            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "3", ACMAComedor.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje4()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "4", ACMATelevisorC.Value, ACMATelevisorV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje5()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "5", ACMASonidoC.Value, ACMASonidoV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje6()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "6", ACMALavadoraC.Value, ACMALavadoraV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje7()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "7", ACMASecadoraC.Value, ACMASecadoraV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje8()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];
            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "8", ACMAEstufaC.Value, ACMAEstufaV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje9()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "9", ACMARefrigeradoraC.Value, ACMARefrigeradoraV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje10()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "10", ACMATMovilC.Value, ACMATMovilV.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarmenaje11()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_menajedecasaencabezado", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codmenajedecasaencabezado", "codeptipobien", "ep_menajecasadetallecantidad", "ep_menajecasadetallevalor" };
                string[] valores = { encabezado, "11", ACMAODes.Value, ACMACantidadO.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_menajecasadetalle", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void guardarotrasdeudas()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_deudasvariasdescripcion", "ep_deudasvariasvalor" };
                string[] valores = { cifactual, PODeudas.Value, POMonto.Value };
                try
                {
                    logic.modificartablas("ep_deudasvarias", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarpasivocontigente()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "ep_pasivocontigenombre", "ep_pasivocontigentedeudor", "ep_pasivocontigentecondeudor",
                "ep_pasivocontigentesaldo","ep_pasivocontigentefechadesembolso","ep_pasivocontigentefechafinalizacion"};
                string[] valores = { cifactual, PTNEntidad.Value, PTNDeudor.Value, PTRelacion.Value, PTSaldo.Value, fechadembolso.Value, fechafinalizacion.Value };
                try
                {
                    logic.modificartablas("ep_pasivocontigente", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardaringreso()
        {
            string encabezado = "";

            string[] var3 = sn.consultarconcampo("ep_controlingreso", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codepcontrolingreso", "ep_ingresosueldo", "ep_ingresobonificacion", "ep_ingresocomisiones" };
                string[] valores = { encabezado, ISBase.Value, IBoni.Value, ICMensuales.Value };
                try
                {
                    logic.modificartablas("ep_ingreso", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void guardarnegocio()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_controlingreso", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];
            if (cifactual != null)
            {
                string[] campos = { "codepcontrolingreso", "ep_negociotipo", "ep_negocionombre", "ep_negociopatente", "ep_negocioempleados",
                    "ep_negocioobjeto", "ep_negocioingresos", "ep_negocioegresos","ep_negociodireccion" };
                string[] valores = { encabezado,/* ITNegocio.Value,*/ ITNNegocio.Value, ITpatente.Value, ITNEmpleados.Value, ITONegocio.Value, ITIMensuales.Value,
                ITEMensuales.Value,ITDireccion.Value};
                try
                {
                    logic.modificartablas("ep_negocio", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }

            }
        }
        public void guardarremesas()
        {
            string encabezado = "";
            string[] var3 = sn.consultarconcampo("ep_controlingreso", "codepinformaciongeneralcif", cifactual);
            encabezado = var3[0];

            if (cifactual != null)
            {
                string[] campos = { "codepcontrolingreso", "ep_remesasnombre", "ep_remesasrelacion", "ep_remesasmonto", "ep_remesasperiodo" };
                string[] valores = { encabezado, ISRNombre.Value, ISRRelacion.Value, ISRMonto.Value, ISRPeriodo.SelectedValue };
                try
                {
                    logic.modificartablas("ep_remesas", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }

        public void guardaregresos()
        {
            if (cifactual != null)
            {
                string[] campos = { "codinformaciongeneralcif", "ep_egresosalimentacion", "ep_egresostransportes", "ep_egresosestudios",
                "ep_egresosprestamo","ep_egresostarjeta","ep_egresosropa","ep_egresosrecreacion","ep_egresosotros"};
                string[] valores = { cifactual, ITAlimen.Value, ITTras.Value, ITPago.Value, ITPrestamos.Value, ITTarjeta.Value, ITVestuario.Value, ITRecreacion.Value, ITOtros.Value };
                try
                {
                    logic.modificartablas("ep_egresos", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }
            }
        }
        public void guardarexpuestopep()
        {
            if (cifactual != null)
            {
                string[] campos = { "codepinformaciongeneralcif", "codeptipopep", "ep_personapepnombreinstitucion", "ep_personapeppuesto", "ep_personapeppais" };
                string[] valores = { cifactual, "1", ENIns.Value, EPuesto.Value, EPais.Value };
                try
                {
                    logic.modificartablasdoscampos("ep_personapep", campos, valores);
                }
                catch { }
                finally { try { cn.desconectar(); } catch { } }

            }
        }
        public void guardarparentescopep()
        {
            if (rdbsipep.Checked == true)
            {
                if (EParentesco1.SelectedValue == "0" || Modalidad1.SelectedValue == "0")
                {
                    String script = "alert('Verifique que los campos esten llenos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    if (cifactual != null)
                    {
                        string[] campos = { "codepinformaciongeneralcif", "codeptipopep", "codeptiponacionalidad", "codeptipoparentesco", "ep_personapepnombre", "ep_personapepnombreinstitucion",
                "ep_personapeppuesto","ep_personapeppais"};
                        string[] valores = { cifactual, "2", EParentesco1.SelectedValue, Modalidad1.SelectedValue, Text8.Value, Text9.Value, Text10.Value, Text11.Value };
                        try
                        {
                            logic.modificartablasdoscampos("ep_personapep", campos, valores);
                        }
                        catch { }
                        finally { try { cn.desconectar(); } catch { } }
                    }

                }
            }
           
        }
        public void guardarasociadopep()
        {
            if (rdbsiasociadopep.Checked==true)
            {
                if (EParentesco2.SelectedValue != "0" | Modalidad2.SelectedValue != "0")
                {
                    String script = "alert('Verifique que los campos esten llenos');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    if (cifactual != null)
                    {
                        string[] campos = { "codepinformaciongeneralcif", "codeptipopep", "codeptiponacionalidad", "codeptipoparentesco","ep_personapepmotivo" ,"ep_personapepnombre", "ep_personapepnombreinstitucion",
                "ep_personapeppuesto","ep_personapeppais"};
                        string[] valores = { cifactual, "3", EParentesco2.SelectedValue, Modalidad2.SelectedValue, EMotivos.Value, ENombres.Value, EINombre.Value, EIPuesto1.Value, EPPais1.Value };
                        try
                        {
                            logic.modificartablasdoscampos("ep_personapep", campos, valores);
                        }
                        catch { }
                        finally { try { cn.desconectar(); } catch { } }
                    }
                }

            }
          
        }
        ///////////////////////////////////////////////GRIDVIEWS///////////////////////////////////////////
        ///
        public void llenargridviewinversiones()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT d.codepinversiones,d.codeptipoinstitucion,d.codepinstitucion,d.codeptipomoneda,a.ep_tipoinstitucionnombre,b.ep_institucionnombre,c.ep_tipomonedanombre,d.ep_inversionesnombre,d.ep_inversionesplazo,d.ep_inversionesmonto,d.ep_inversionesorigen,d.ep_inversionesnumerocuenta FROM ep_inversiones d INNER JOIN ep_tipoinstitucion a INNER JOIN ep_institucion b INNER JOIN ep_tipomoneda c ON d.codeptipoinstitucion=a.codeptipoinstitucion AND d.codepinstitucion=b.codepinstitucion AND d.codeptipomoneda=c.codeptipomoneda WHERE codepinformaciongeneralcif='"+cifactual+"';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    gridviewinversiones.DataSource = ds3;
                    gridviewinversiones.DataBind();
 


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }
        protected void OnSelectedIndexChangedinversiones(object sender, EventArgs e)
        {

            GridViewRow row = gridviewinversiones.SelectedRow;
            DropDownList2.SelectedValue = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblnumerotipoinstitucioninversion") as Label).Text);
            int codigotipoentidad = Convert.ToInt32(DropDownList2.SelectedValue);
            llenarcomboinstitucioninversion(codigotipoentidad);
            DropDownList3.SelectedValue = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblnumeroinstitucioninversion") as Label).Text);
            ACIMoneda1.SelectedValue = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblnumeromonedainversion") as Label).Text);
            ACIPlazo.Value = (gridviewinversiones.SelectedRow.FindControl("lblplazoinversion") as Label).Text;        
            ACIMonto.Value = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblmontoinversion") as Label).Text);
            ACIOrigeninv.Value = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblorigeninversion") as Label).Text);
            Text24.Value = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblnumerodecuenta") as Label).Text);
            Text21.Value = Convert.ToString((gridviewinversiones.SelectedRow.FindControl("lblnumeroinversion") as Label).Text);

        }

        public void llenargridviewestudiosuniversitarios()
        {
         
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepestudio,ep_estudionombre, ep_estudioduracion,ep_estudioaño,ep_estudiolugar FROM ep_estudio where ep_estudiotipo=0 AND codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridestudiosU.DataSource = ds3;
                    GridestudiosU.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }



            }

        }
        protected void OnSelectedIndexChangedestudiosu(object sender, EventArgs e)
        {

            GridViewRow row = GridestudiosU.SelectedRow;
            ENombreCarrera.Value = (GridestudiosU.SelectedRow.FindControl("lblnombreuniversidad") as Label).Text;
            ESemestre.Value = Convert.ToString((GridestudiosU.SelectedRow.FindControl("lblduracionuniversidad") as Label).Text);
            EAño.Value = Convert.ToString((GridestudiosU.SelectedRow.FindControl("lblañouniversidad") as Label).Text);
            EUniversidad.Value = Convert.ToString((GridestudiosU.SelectedRow.FindControl("lbllugaruniversidad") as Label).Text);
            Text22.Value = Convert.ToString((GridestudiosU.SelectedRow.FindControl("lblnumerouniversidad") as Label).Text);

        }

        public void llenargridviewcelulares()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT a.codeptelefono,a.codeptipotelefono,b.ep_tipotelefononombre,a.ep_telefononumero " +
                       "FROM ep_telefono a " +
                       "INNER JOIN ep_tipotelefono b " +
                       "ON a.codeptipotelefono=b.codeptipotelefono WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewcelular.DataSource = ds3;
                    GridViewcelular.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }

            }

        }


        protected void OnSelectedIndexChangedcelular(object sender, EventArgs e)
        {

            GridViewRow row = GridViewcelular.SelectedRow;
            IGCelular.Value = (GridViewcelular.SelectedRow.FindControl("lblnumerotelefono") as Label).Text;
            //IGCelular.Value = (GridViewcelular.SelectedRow.FindControl("lblnombretelefono") as Label).Text;
            IGTCel1.SelectedValue = Convert.ToString((GridViewcelular.SelectedRow.FindControl("lbltipotelefono") as Label).Text);
            Text6.Value = Convert.ToString((GridViewcelular.SelectedRow.FindControl("lblcodeptelefono") as Label).Text);
       
        }

        public void llenargridviewhijos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try {
                    //{
                    //sqlCon.Open();
                    //string QueryString = "SELECT codepinfofamiliar,ep_infofamiliarnombrehijos WHERE codepinformaciongeneralcif=1;";
                    //MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    //DataTable ds4 = new DataTable();
                    //myCommand.Fill(ds4);
                    //GridViewhijos.DataSource = ds4;
                    //GridViewhijos.DataBind();

                    sqlCon.Open();
                    string QueryString = "select codepinfofamiliar, ep_infofamiliarnombrehijos,ep_infofamiliarocupacionhijos,ep_infofamiliarcomentario,ep_infofamiliarfechanacimientohijo from ep_infofamiliar where codepinformaciongeneralcif='"+cifactual+ "' AND ep_infofamiliarnombrehijos!=''";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewhijos.DataSource = ds3;
                    GridViewhijos.DataBind();

                }
                catch
                {
                }
            }
        }

        protected void OnSelectedIndexChangedhijos(object sender, EventArgs e)
        {

            GridViewRow row = GridViewhijos.SelectedRow;
            Text1.Value = (GridViewhijos.SelectedRow.FindControl("lblnombrehijo") as Label).Text;
            Text2.Value = (GridViewhijos.SelectedRow.FindControl("lblocupacionhijo") as Label).Text;
            Text3.Value = (GridViewhijos.SelectedRow.FindControl("lblcomentariohijo") as Label).Text;
            string fecha = string.Format("{0:yyyy-MM-dd}", (GridViewhijos.SelectedRow.FindControl("lblfechanachijo") as Label).Text);
            Date1.Value = fecha.Trim();
            Text7.Value = (GridViewhijos.SelectedRow.FindControl("lblnumerohijo") as Label).Text;
        }

        public void llenargridviewestudios()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT * FROM ep_estudio where codepinformaciongeneralcif='" + cifactual + "'  AND ep_estudiotipo=1;";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewEstudios.DataSource = ds4;
                    GridViewEstudios.DataBind();
                }
                catch
                {
                }
            }
              
        }
        protected void OnSelectedIndexChangedestudios(object sender, EventArgs e)
        {

            GridViewRow row = GridViewEstudios.SelectedRow;

            OECurso.Value = (GridViewEstudios.SelectedRow.FindControl("lblnombrecurso") as Label).Text;
            OEEstablecimiento.Value = (GridViewEstudios.SelectedRow.FindControl("lbllugar") as Label).Text;
            OEModalidad.Value = (GridViewEstudios.SelectedRow.FindControl("lblmodalidad") as Label).Text;
            OEAño.Value = (GridViewEstudios.SelectedRow.FindControl("lblaniocursado") as Label).Text;
            OEDuracion.Value = (GridViewEstudios.SelectedRow.FindControl("lblduracion") as Label).Text;
            Text4.Value = (GridViewEstudios.SelectedRow.FindControl("lblidioma") as Label).Text;
            Text12.Value = (GridViewEstudios.SelectedRow.FindControl("lblnumerocurso") as Label).Text;

        }
        public void llenargridviewcuentasporcobrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas where codepinformaciongeneralcif='" + cifactual + "' AND codeptipocuenta=4;";
                     MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewcuentasporcobrar.DataSource = ds4;
                    GridViewcuentasporcobrar.DataBind();
                }
                catch
                {
                }
            }
        }
        protected void OnSelectedIndexChangedcuentasporcobrar(object sender, EventArgs e)
        {

            GridViewRow row = GridViewcuentasporcobrar.SelectedRow;

            ACPNombre.Value = (GridViewcuentasporcobrar.SelectedRow.FindControl("lblnombrecuentapc") as Label).Text;
            ACPMonto.Value = (GridViewcuentasporcobrar.SelectedRow.FindControl("lblmontocuentapc") as Label).Text;
            ACPMotivo.Value = (GridViewcuentasporcobrar.SelectedRow.FindControl("lblmotivocuentapc") as Label).Text;
            Text15.Value = (GridViewcuentasporcobrar.SelectedRow.FindControl("lblnumerocuentapc") as Label).Text;

        }

        public void llenargridviewbienesinmuebles()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble,ep_inmueblefolio,ep_inmueblelibro,ep_inmueblefinca,ep_inmuebledireccion,ep_inmueblevalor,ep_inmuebledescripcion,ep_inmueblecomentario" +
                        " FROM ep_inmueble a " +
                        "INNER JOIN ep_tipoinmueble b " +
                        "ON a.codeptipoinmueble=b.codeptipoinmueble WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewbienesinmuebles.DataSource = ds4;
                    GridViewbienesinmuebles.DataBind();
                }
                catch
                {
                }
            }
        }
        protected void OnSelectedIndexChangedbienesinmuebles(object sender, EventArgs e)
        {

            GridViewRow row = GridViewbienesinmuebles.SelectedRow;

            ACTInmueble1.SelectedValue = Convert.ToString((GridViewbienesinmuebles.SelectedRow.FindControl("lbltipodeinmueble") as Label).Text);
            ACFolio.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblnumerofolio") as Label).Text;
            ACLibro.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblnumerodelibro") as Label).Text;
            ACFinca.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblinmueblefinca") as Label).Text;
            ACDireccion.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lbldireccioninmueble") as Label).Text;
            ACVActual.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblvalorimnmueble") as Label).Text;
            ACDes.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lbldescripcioninmueble") as Label).Text;
            ACcomentarioinmueble.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblcomentarioinmueble") as Label).Text;
            Text16.Value = (GridViewbienesinmuebles.SelectedRow.FindControl("lblnumerodeinmueble") as Label).Text;


        }


        public void llenargridviewvehiculos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre,ep_vehiculomarca,ep_vehiculolinea,ep_vehiculomodelo,ep_vehiculoplaca,ep_vehiculocomentario,ep_vehiculoanombrede,ep_vehiculomotivodeanombrede,ep_vehiculomonto FROM ep_vehiculo a INNER JOIN ep_tipovehiculo b ON a.codeptipovehiculo = b.codeptipovehiculo WHERE codepinformaciongeneralcif='" + cifactual+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewvehiculos.DataSource = ds4;
                    GridViewvehiculos.DataBind();

                }
                catch
                {
                }
            }
        }
        protected void OnSelectedIndexChangedvehiculos(object sender, EventArgs e)
        {

            GridViewRow row = GridViewvehiculos.SelectedRow;

            ACTVehiculo1.SelectedValue = Convert.ToString((GridViewvehiculos.SelectedRow.FindControl("lblnumerotipovehiculo") as Label).Text);
            ACMarca.Value = (GridViewvehiculos.SelectedRow.FindControl("lblmarca") as Label).Text;
            ACLinea.Value = (GridViewvehiculos.SelectedRow.FindControl("lbllineavehiculo") as Label).Text;
            ACModelo.Value = (GridViewvehiculos.SelectedRow.FindControl("lblmodelo") as Label).Text;
            ACPlaca.Value = (GridViewvehiculos.SelectedRow.FindControl("lblplaca") as Label).Text;
            ACCome.Value = (GridViewvehiculos.SelectedRow.FindControl("lblcomentario") as Label).Text;
            Text25.Value = (GridViewvehiculos.SelectedRow.FindControl("lblaquienesta") as Label).Text;
            Text26.Value = (GridViewvehiculos.SelectedRow.FindControl("lblmotivo") as Label).Text;
            //codtelefono= (GridViewvehiculos.SelectedRow.FindControl("codeptipotelefono") as Label).Text;
            Text17.Value= (GridViewvehiculos.SelectedRow.FindControl("lblnumerodeinmueble") as Label).Text;
            Text27.Value = (GridViewvehiculos.SelectedRow.FindControl("lblmonto") as Label).Text;

        }
        public void llenargridviewcuentasporpagar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre,ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto" +
                        " FROM ep_cuentasporpagar a " +
                        "INNER JOIN ep_tipocuentaspopagar b " +
                        "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewcuentasporpagar.DataSource = ds4;
                    GridViewcuentasporpagar.DataBind();

                }
                catch
                {
                }
            }
        }
        protected void OnSelectedIndexChangedcuentasporpagar(object sender, EventArgs e)
        {

            GridViewRow row = GridViewcuentasporpagar.SelectedRow;

            TipoCuenta.SelectedValue = Convert.ToString((GridViewcuentasporpagar.SelectedRow.FindControl("lbltipocuentasporpagar") as Label).Text);
            PCPDes1.Value = (GridViewcuentasporpagar.SelectedRow.FindControl("lbldescripcion") as Label).Text;
            PCPMonto1.Value = (GridViewcuentasporpagar.SelectedRow.FindControl("lblmonto") as Label).Text;
            Text18.Value = (GridViewcuentasporpagar.SelectedRow.FindControl("lblnumerocuentasporpagar") as Label).Text;

        }
        public void llenargridviewpasivos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepprestamo,a.codeptipoprestamo,a.codepinstitucion,a.codeptipoinstitucion,b.ep_tipoprestamonombre,d.ep_tipoinstitucionnombre,c.ep_institucionnombre,ep_prestamomomentoinicial,ep_prestamosaldoactual,ep_prestamodestino,ep_prestamofechadesembolso,ep_prestamofechadefinalizacion " +
                        "FROM ep_prestamo a " +
                        "INNER JOIN ep_tipoprestamo b " +
                        "INNER JOIN ep_institucion c " +
                        "INNER JOIN ep_tipoinstitucion d " +
                        "ON a.codeptipoprestamo=b.codeptipoprestamo AND a.codepinstitucion=c.codepinstitucion AND a.codeptipoinstitucion=d.codeptipoinstitucion  " +
                        "WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewpasivos.DataSource = ds4;
                    GridViewpasivos.DataBind();

                }
                catch
                {
                }
            }

               
        }
        protected void OnSelectedIndexChangedpasivos(object sender, EventArgs e)
        {
            PNPNEntidadnombre1.Visible = true;
            PTTNombre1.Visible = true;
            GridViewRow row = GridViewpasivos.SelectedRow;

            PTPrestamo1.SelectedValue = Convert.ToString((GridViewpasivos.SelectedRow.FindControl("lblnumerotipoprestamo") as Label).Text);
            PNEntidad1.SelectedValue = Convert.ToString((GridViewpasivos.SelectedRow.FindControl("lblnumtipodeinstitucion") as Label).Text);
            int codigotipoentidad = Convert.ToInt32(PNEntidad1.SelectedValue);
            llenarcomboinstitucion(codigotipoentidad);
            PNPNEntidadnombre1.SelectedValue = Convert.ToString((GridViewpasivos.SelectedRow.FindControl("lblnumerodelainstitucion") as Label).Text);
            PMInicial.Value = (GridViewpasivos.SelectedRow.FindControl("lblmontoinicial") as Label).Text;
            PSActual.Value = (GridViewpasivos.SelectedRow.FindControl("lblsaldoactual") as Label).Text;
            PFDestino.Value = (GridViewpasivos.SelectedRow.FindControl("lbldestinoprestamo") as Label).Text;
           
            string fechadesembolso = string.Format("{0:yyyy-MM-dd}", (GridViewpasivos.SelectedRow.FindControl("lblfechadesembolso") as Label).Text);
            Datedesembolso.Value = fechadesembolso.Trim();
            string fechafinalizacion = string.Format("{0:yyyy-MM-dd}", (GridViewpasivos.SelectedRow.FindControl("lblfechafinalizacion") as Label).Text);
            Datefinalizacion.Value = fechafinalizacion.Trim();
            Text19.Value = (GridViewpasivos.SelectedRow.FindControl("lblnumeroprestamo") as Label).Text;

        }

        public void llenargridviewtarjetas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion," +
                        "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz,ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual " +
                        "FROM ep_tarjetadecredito a " +
                        "INNER JOIN ep_tipoinstitucion b " +
                        "INNER JOIN ep_institucion c " +
                        "ON a.codeptipoinstitucion=b.codeptipoinstitucion AND a.codepinstitucion=c.codepinstitucion  WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewtarjetas.DataSource = ds4;
                    GridViewtarjetas.DataBind();

                }
                catch
                {
                }
            }

        }
        protected void OnSelectedIndexChangedtarjetas(object sender, EventArgs e)
        {
            PTTNombre1.Visible = true;
            GridViewRow row = GridViewtarjetas.SelectedRow;

            PTTEntidad1.SelectedValue = Convert.ToString((GridViewtarjetas.SelectedRow.FindControl("lblnumerotipoinstituciontarjeta") as Label).Text);
            int codigotipoentidad1 = Convert.ToInt32(PTTEntidad1.SelectedValue);
            llenarcomboinstituciontarjeta(codigotipoentidad1);
            PTTNombre1.SelectedValue = Convert.ToString((GridViewtarjetas.SelectedRow.FindControl("lblnumeroinstituciontarjeta") as Label).Text);
            PTTLimite.Value = (GridViewtarjetas.SelectedRow.FindControl("lblmontoqtarjeta") as Label).Text;
            PTTLimite2.Value = (GridViewtarjetas.SelectedRow.FindControl("lblmontousdtarjeta") as Label).Text;
            PTTSaldo.Value = (GridViewtarjetas.SelectedRow.FindControl("lblsaldoactualtarjeta") as Label).Text;
            Text20.Value = (GridViewtarjetas.SelectedRow.FindControl("lblnumerotarjeta") as Label).Text;

        }

        public void llenargridviewcuentasencoperativa()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT a.codepcuentas,a.codepinstitucion,a.codeptipomoneda,a.codeptipoestatuscuenta,a.codeptipocuentacooperativa," +
                        "b.ep_institucionnombre,c.ep_tipomonedanombre,d.ep_tipoestatuscuentanombre,e.ep_tipocuentacooperativanombre,a.ep_cuentasmonto,a.ep_cuentasorigen " +
                        "FROM ep_cuentas a " +
                        "INNER JOIN ep_institucion b " +
                        "INNER JOIN ep_tipomoneda c " +
                        "INNER JOIN ep_tipoestatuscuenta d " +
                        "INNER JOIN ep_tipocuentacooperativa e " +
                        "ON a.codepinstitucion=b.codepinstitucion " +
                        "AND a.codeptipomoneda=c.codeptipomoneda AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta AND a.codeptipocuentacooperativa=e.codeptipocuentacooperativa " +
                        "WHERE a.codeptipocuenta=3 AND a.codepinformaciongeneralcif='"+cifactual+"';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewcuentascooperativa.DataSource = ds4;
                    GridViewcuentascooperativa.DataBind();

                }
                catch
                {
                }
            }
        }
        protected void OnSelectedIndexChangedcuentascooperativa(object sender, EventArgs e)
        {

            GridViewRow row = GridViewcuentascooperativa.SelectedRow;

            ACCNBanco1.SelectedValue = Convert.ToString((GridViewcuentascooperativa.SelectedRow.FindControl("lblnumeroinsticuentacoope") as Label).Text);
            ACCTMoneda1.SelectedValue = Convert.ToString((GridViewcuentascooperativa.SelectedRow.FindControl("lblnumeromonedacuentacoope") as Label).Text);
            ACCEstatus1.SelectedValue = Convert.ToString((GridViewcuentascooperativa.SelectedRow.FindControl("lblnumeroestatuscuentacoope") as Label).Text);
            Select1.Value = Convert.ToString((GridViewcuentascooperativa.SelectedRow.FindControl("lbltipocuentascooperativas") as Label).Text);
            ACCMonto.Value = (GridViewcuentascooperativa.SelectedRow.FindControl("lblmontocuentacoope") as Label).Text;
            ACCOFondos.Value = (GridViewcuentascooperativa.SelectedRow.FindControl("lblorigencuentacoope") as Label).Text;
            Text14.Value = (GridViewcuentascooperativa.SelectedRow.FindControl("lblnumerocuentacoope") as Label).Text;

        }

        public void llenargridviewcuentasvarias()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentas,a.codeptipocuenta,a.codepinstitucion,a.codeptipoestatuscuenta,a.codeptipomoneda," +
                        "b.ep_tipocuentanombre,c.ep_institucionnombre,d.ep_tipoestatuscuentanombre,e.ep_tipomonedanombre,ep_cuentasmonto,ep_cuentasorigen " +
                        "FROM ep_cuentas a " +
                        "INNER JOIN ep_tipocuenta b " +
                        "INNER JOIN ep_institucion c " +
                        "INNER JOIN ep_tipoestatuscuenta d " +
                        "INNER JOIN ep_tipomoneda e ON a.codeptipocuenta=b.codeptipocuenta AND a.codepinstitucion=c.codepinstitucion " +
                        "AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta  AND a.codeptipomoneda=e.codeptipomoneda " +
                        "WHERE codepinformaciongeneralcif='" + cifactual + "';";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    myCommand.Fill(ds4);
                    GridViewcuentasvarias.DataSource = ds4;
                    GridViewcuentasvarias.DataBind();

                }
                catch
                {
                }
            }      
        }
        protected void OnSelectedIndexChangedcuentasvarias(object sender, EventArgs e)
        {

            GridViewRow row = GridViewcuentasvarias.SelectedRow;
            DropDownList1.Value = Convert.ToString((GridViewcuentasvarias.SelectedRow.FindControl("lbltipocuentasvarias") as Label).Text);
            ACNBanco1.SelectedValue = Convert.ToString((GridViewcuentasvarias.SelectedRow.FindControl("lbltipoinstitucionvarias") as Label).Text);
            ACEstatus1.SelectedValue = Convert.ToString((GridViewcuentasvarias.SelectedRow.FindControl("lblnumeroestatusvarias") as Label).Text);
            ACTMoneda1.SelectedValue = Convert.ToString((GridViewcuentasvarias.SelectedRow.FindControl("lblnumeromonedavarias") as Label).Text);
            ACMonto.Value = (GridViewcuentasvarias.SelectedRow.FindControl("lblmontovarias") as Label).Text;
            ACOFondos.Value = (GridViewcuentasvarias.SelectedRow.FindControl("lblorigendefondovarias") as Label).Text;
            Text13.Value = (GridViewcuentasvarias.SelectedRow.FindControl("lblnumerocuentasvarias") as Label).Text;

        }

        public void guardarcelulares(string busquedacif)
        {        
            string[] var3 = sn.consultarconcampo("ep_telefono", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_telefono", "codeptelefono");
                string am = var3[centinela + 1];
                string cifparaingreso = busquedacif;
                string fm = var3[centinela + 3];

                string[] dato = { sig, am, cifparaingreso, fm }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_telefono", dato);
                centinela = centinela + 4;                          //El centinela debe sumarle la cantidad de columnas de la tabla
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }           
        }
        public void guardarcuentasvarias(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_cuentas", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 2];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];
                string am7 = var3[centinela + 8];
                string am8 = var3[centinela + 9];

                string[] dato = { sig, cifparaingreso,am1, am2, am3, am4, am5, am6, am7,am8}; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_cuentas", dato);
                centinela = centinela + 10;                          //El centinela debe sumarle la cantidad de columnas de la tabla
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }
        }
        public void guardarpasivos(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_prestamo", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_prestamo", "codepprestamo");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 1];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];
                string am7 = var3[centinela + 8];
                string am8 = var3[centinela + 9];

                string[] dato = { sig, am1, cifparaingreso, am2, am3, am4, am5, am6, am7, am8}; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_prestamo", dato);
                centinela = centinela + 10;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }         
        }
        public void guardartarjetas(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_tarjetadecredito", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_tarjetadecredito", "codeptrajetadecredito");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 1];
                string am2 = var3[centinela + 2];
                string am3 = var3[centinela + 3];
                string am4 = var3[centinela + 4];
                string am5 = var3[centinela + 5];

                string[] dato = { sig, am1, am2,cifparaingreso, am3, am4, am5}; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_tarjetadecredito", dato);
                centinela = centinela + 7;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }         
        }
        public void guardarestudios(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_estudio", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_estudio", "codepestudio");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 2];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];
                string am7 = var3[centinela + 8];


                string[] dato = { sig, cifparaingreso,am1, am2, am3, am4, am5, am6, am7 }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_estudio", dato);
                centinela = centinela + 9;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }
        }


        public void guardarinversiones(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_inversiones", "codepinversiones", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_inversiones", "codepinversiones");

                string cifparaingreso = busquedacif;
                string am = var3[centinela + 2];
                string fm1 = var3[centinela + 3];
                string fm2 = var3[centinela + 4];
                string fm3 = var3[centinela + 5];
                string fm4 = var3[centinela + 6];
                string fm5 = var3[centinela + 7];
                string fm6 = var3[centinela + 8];
                string fm7 = var3[centinela + 9];

                string[] dato = { sig, cifparaingreso,am, fm1, fm2, fm3, fm4, fm5, fm6,fm7 }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_inversiones", dato);
                centinela = centinela + 10;                          //El centinela debe sumarle la cantidad de columnas de la tabla
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }
        }



        public void guardabienesinmueble(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_inmueble", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_inmueble", "codepinmueble");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 1];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];


                string[] dato = { sig, am1, cifparaingreso, am2, am3, am4, am5, am6 }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_inmueble", dato);
                centinela = centinela + 8;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }   
        }
        public void guardarvehiculos(string busquedacif)
        {
            string[] var3 = sn.consultarconcampo("ep_vehiculo", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_vehiculo", "codepvehiculo");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 1];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];
                string am7 = var3[centinela + 8];
                string am8 = var3[centinela + 9];
                string am9 = var3[centinela + 10];


                string[] dato = { sig, am1, cifparaingreso, am2, am3, am4, am5,am6,am7,am8,am9 }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_vehiculo", dato);
                centinela = centinela + 11;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }
               
        }
        public void guardarhijos(string busquedacif)
        {

            string[] var3 = sn.consultarconcampo("ep_infofamiliar", "codepinformaciongeneralcif", cifactual);
            int centinela = 0;
            for (int i = 0; i < var3.Length;)
            {
                string sig = logic.siguiente("ep_infofamiliar", "codepinfofamiliar");
                string cifparaingreso = busquedacif;
                string am1 = var3[centinela + 2];
                string am2 = var3[centinela + 3];
                string am3 = var3[centinela + 4];
                string am4 = var3[centinela + 5];
                string am5 = var3[centinela + 6];
                string am6 = var3[centinela + 7];
                string am7 = var3[centinela + 8];
                string am8 = var3[centinela + 9];
                string am9 = var3[centinela + 10];
                string am10 = var3[centinela + 11];
                string am11 = var3[centinela + 12];


                string[] dato = { sig, cifparaingreso,am1, am2, am3, am4, am5, am6, am7, am8, am9, am10, am11 }; //Arreglo que utiliza para guardar
                logic.insertartablas("ep_infofamiliar", dato);
                centinela = centinela + 13;                          //El centinela debe sumarle la cantidad de columnas de la tabla desde la 0
                i = centinela;                                          //el i es un autoincrementable que siempre se igula al centinela
            }
           
               
        }

        public void mostrarcamposgeneral()
        {
            string[] var1 = sn.mostrarcamposgeneral(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                IGCIF.Value = Convert.ToString(var1[0]);

                int id = Convert.ToInt32(var1[1]);
                IGAgencia1.SelectedValue = Convert.ToString(id);
                llenarcomboarea(id);
                //Para seleccionar el index del combo
                int id2 = Convert.ToInt32(var1[2]);
                IGADepa1.SelectedValue = Convert.ToString(id2);
                llenarcombopuesto(id2);
                //---------------------------------------
                int id13 = Convert.ToInt32(var1[3]);
                IGDPuestos.SelectedValue = Convert.ToString(id13);


                IGPApellido.Value = Convert.ToString(var1[4]);
                IGSApellido.Value = Convert.ToString(var1[5]);
                IGPNombre.Value = Convert.ToString(var1[6]);
                IGSNombre.Value = Convert.ToString(var1[7]);
                IGONombre.Value = Convert.ToString(var1[8]);

                int id3 = Convert.ToInt32(var1[9]);
                IGPDepartamento1.SelectedIndex = id3;

                int id4 = Convert.ToInt32(var1[10]);
                IGMunicipio1.SelectedIndex = id4;

                int id5 = Convert.ToInt32(var1[11]);
                IGPAZona1.SelectedIndex = id5;
                IGDireccion.Value = Convert.ToString(var1[12]);
                int id6 = Convert.ToInt32(var1[13]);
                IGDoc1.SelectedIndex = id6;

                IGNoDoc.Value = Convert.ToString(var1[14]);
                var fecha = Convert.ToDateTime(var1[15]);
                string fecha2 = fecha.ToString("yyyy-MM-dd");
                IGFNacimiento.Value = fecha2;
                IGNits.Value = Convert.ToString(var1[16]);
                IGNacionalidad.Value = Convert.ToString(var1[17]);
                IGCorreo.Value = Convert.ToString(var1[18]);
                IGEstatura.Value = Convert.ToString(var1[19]);
                IGPeso.Value = Convert.ToString(var1[20]);
                IGReligion.Value = Convert.ToString(var1[21]);

                // IGNoDoc.Value = Convert.ToString(mostrar.GetString(10));
            }
        }
        public void mostrarcamposfam()
        {
            string[] var1 = sn.mostrarcamposgeneralfam(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {

                int id = Convert.ToInt32(var1[0]);
                id_categoriaestadocivil.SelectedIndex = id;
                IFNombre.Value = Convert.ToString(var1[1]);
                IFOcupacion.Value = Convert.ToString(var1[2]);
                id_input5.Value = Convert.ToString(var1[3]);

                var fecha1 = Convert.ToDateTime(var1[4]);
                string fecha3 = fecha1.ToString("yyyy-MM-dd");
                id_input6.Value = fecha3;

                var fecha = Convert.ToDateTime(var1[5]);
                string fecha2 = fecha.ToString("yyyy-MM-dd");
                IFFecha.Value = fecha2;

                IFNombreCo.Value = Convert.ToString(var1[6]);
                IFtel.Value = Convert.ToString(var1[7]);
                IFparenteso.Value = Convert.ToString(var1[8]);
            }           
        }
        
        public void mostrarcaja()
        {
            string[] var1 = sn.mostrarcaja(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACCaja.Value = Convert.ToString(var1[0]);
            }
               
        }
        public void mostrarinventario()
        {
            string[] var1 = sn.mostrarinventario(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                Text5.Value = Convert.ToString(var1[0]);
                Number1.Value = Convert.ToString(var1[1]);
            }          
        }

        public void mostrarmaquinaria()
        {
            string[] var1 = sn.mostrarmaquinaria(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACTMAquinaria.Value = Convert.ToString(var1[0]);
                ACComentarios.Value = Convert.ToString(var1[1]);
                Number2.Value = Convert.ToString(var1[2]);
            }           
        }

        public void mostrarmenaje1()
        {
            string[] var1 = sn.mostrarmenaje1(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMEComputo.Value = Convert.ToString(var1[0]);
            }
        }
        public void mostrarmenaje2()
        {
            string[] var1 = sn.mostrarmenaje2(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMASala.Value = Convert.ToString(var1[0]);
            }         
        }
        public void mostrarmenaje3()
        {
            string[] var1 = sn.mostrarmenaje3(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMAComedor.Value = Convert.ToString(var1[0]);
            }
        }
        public void mostrarmenaje4()
        {
            string[] var1 = sn.mostrarmenaje4(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMATelevisorC.Value = Convert.ToString(var1[0]);
                ACMATelevisorV.Value = Convert.ToString(var1[1]);
            }           
        }
        public void mostrarmenaje5()
        {
            string[] var1 = sn.mostrarmenaje5(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMASonidoC.Value = Convert.ToString(var1[0]);
                ACMASonidoV.Value = Convert.ToString(var1[1]);
            }           
        }
        public void mostrarmenaje6()
        {
            string[] var1 = sn.mostrarmenaje6(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMALavadoraC.Value = Convert.ToString(var1[0]);
                ACMALavadoraV.Value = Convert.ToString(var1[1]);
            }
        }
        public void mostrarmenaje7()
        {
            string[] var1 = sn.mostrarmenaje7(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMASecadoraC.Value = Convert.ToString(var1[0]);
                ACMASecadoraV.Value = Convert.ToString(var1[1]);
            }
        }
        public void mostrarmenaje8()
        {
            string[] var1 = sn.mostrarmenaje8(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMAEstufaC.Value = Convert.ToString(var1[0]);
                ACMAEstufaV.Value = Convert.ToString(var1[1]);
            }          
        }
        public void mostrarmenaje9()
        {
            string[] var1 = sn.mostrarmenaje9(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMARefrigeradoraC.Value = Convert.ToString(var1[0]);
                ACMARefrigeradoraV.Value = Convert.ToString(var1[1]);
            }           
        }
        public void mostrarmenaje10()
        {
            string[] var1 = sn.mostrarmenaje10(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMATMovilC.Value = Convert.ToString(var1[0]);
                ACMATMovilV.Value = Convert.ToString(var1[1]);
            }

        }
        public void mostrarmenaje11()
        {
            string[] var1 = sn.mostrarmenaje11(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ACMAODes.Value = Convert.ToString(var1[0]);
                ACMACantidadO.Value = Convert.ToString(var1[1]);
            }          
        }
        public void mostrardeudas()
        {
            string[] var1 = sn.mostrardeudas(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                PODeudas.Value = Convert.ToString(var1[0]);
                POMonto.Value = Convert.ToString(var1[1]);
            }
        }
        public void mostrarpasivocontigente()
        {
            string[] var1 = sn.mostrarpasivocontigente(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                PODeudas.Value = Convert.ToString(var1[0]);
                POMonto.Value = Convert.ToString(var1[1]);

                PTNEntidad.Value = Convert.ToString(var1[0]);
                PTNDeudor.Value = Convert.ToString(var1[1]);
                PTRelacion.Value = Convert.ToString(var1[2]);
                PTSaldo.Value = Convert.ToString(var1[3]);

                var fecha = Convert.ToDateTime(var1[4]);
                string fecha1 = fecha.ToString("yyyy-MM-dd");
                fechafinalizacion.Value = fecha1;

                var fecha2 = Convert.ToDateTime(var1[5]);
                string fecha3 = fecha2.ToString("yyyy-MM-dd");
                fechafinalizacion.Value = fecha3;
            }
    
        }
        public void mostraringresos()
        {
            string[] var1 = sn.mostraringresos(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ISBase.Value = Convert.ToString(var1[0]);
                IBoni.Value = Convert.ToString(var1[1]);
                ICMensuales.Value = Convert.ToString(var1[2]);
            }
        }

        public void mostrarnegocios()
        {
            string[] var1 = sn.mostrarnegocios(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                //ITNegocio.Value = Convert.ToString(var1[0]);
                ITNNegocio.Value = Convert.ToString(var1[1]);
                ITpatente.Value = Convert.ToString(var1[2]);
                ITNEmpleados.Value = Convert.ToString(var1[3]);
                ITONegocio.Value = Convert.ToString(var1[4]);
                ITIMensuales.Value = Convert.ToString(var1[5]);
                ITEMensuales.Value = Convert.ToString(var1[6]);
                ITDireccion.Value = Convert.ToString(var1[7]);
            }           
        }

        public void mostrarremesas()
        {
            string[] var1 = sn.mostrarremesas(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ISRNombre.Value = Convert.ToString(var1[0]);
                ISRRelacion.Value = Convert.ToString(var1[1]);
                ISRMonto.Value = Convert.ToString(var1[2]);
               
                ISRPeriodo.SelectedValue = Convert.ToString(var1[3]);
            }           
        }

        public void mostraregresos()
        {
            string[] var1 = sn.mostraregresos(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ITAlimen.Value = Convert.ToString(var1[2]);
                ITTras.Value = Convert.ToString(var1[3]);
                ITPago.Value = Convert.ToString(var1[4]);
                ITPrestamos.Value = Convert.ToString(var1[5]);
                ITTarjeta.Value = Convert.ToString(var1[6]);
                ITVestuario.Value = Convert.ToString(var1[7]);
                ITRecreacion.Value = Convert.ToString(var1[8]);
                ITOtros.Value = Convert.ToString(var1[9]);
            }          
        }

        public void mostrarexpuestapep()
        {
            string[] var1 = sn.mostrarexpuestapep(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                ENIns.Value = Convert.ToString(var1[0]);
                EPuesto.Value = Convert.ToString(var1[1]);
                EPais.Value = Convert.ToString(var1[2]);
            }          
        }
        public void mostrarparentescopep()
        {
            string[] var1 = sn.mostrarparentescopep(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                EParentesco1.SelectedValue = Convert.ToString(var1[0]);
                Modalidad1.SelectedValue = Convert.ToString(var1[1]);
                Text8.Value = Convert.ToString(var1[2]);
                Text9.Value = Convert.ToString(var1[3]);
                Text10.Value = Convert.ToString(var1[4]);
                Text11.Value = Convert.ToString(var1[5]);
            }          
        }
        public void mostrarasociadocopep()
        {
            string[] var1 = sn.mostrarasociadocopep(cifactual);
            for (int i = 0; i < var1.Length; i++)
            {
                EParentesco2.SelectedValue = Convert.ToString(var1[0]);
                Modalidad2.SelectedValue = Convert.ToString(var1[1]);
                EMotivos.Value = Convert.ToString(var1[2]);
                ENombres.Value = Convert.ToString(var1[3]);
                EINombre.Value = Convert.ToString(var1[4]);
                EIPuesto1.Value = Convert.ToString(var1[5]);
                EPPais1.Value = Convert.ToString(var1[6]);
            }
        }
        public void mostrarcontratistaproveedor()
        {
            string[] var1 = sn.mostrarcontratistaproveedor(cifactual);
            Dropdownlist23.SelectedValue = Convert.ToString(var1[0]);
        }

        /*--------------------------------------------------------------------------------+*/
        protected void btnguardarcelular1_Click(object sender, EventArgs e)
        {
            if (IGTCel1.SelectedValue == "0" || IGCelular.Value == "")
            {
                String script = "alert('Verificar que los campos de tipo y nombre del telefono no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_telefono", "codeptelefono");

                    string[] valores1 = { sig, IGTCel1.SelectedValue, cifactual, IGCelular.Value };

                    logic.insertartablas("ep_telefono", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcelulares();
        }
        protected void btnguardarhijos_Click(object sender, EventArgs e)
        {
            if (Text1.Value == "" || Text2.Value == "")
            {
                String script = "alert('Verificar que los campos de nombre y ocupacion no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_infofamiliar", "codepinfofamiliar");
                    string[] valores1 = { sig, cifactual, "", Text1.Value, "", Text2.Value, "", "", Date1.Value, "", "", "", Text3.Value };
                    logic.insertartablas("ep_infofamiliar", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewhijos();
        }
        protected void btnguardarestudios_Click(object sender, EventArgs e)
        {
            if (OECurso.Value == "" || OEAño.Value == "" || OEDuracion.Value == "" || OEEstablecimiento.Value == "" || Text4.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_estudio", "codepestudio");
                    string[] valores1 = { sig, cifactual, OECurso.Value, OEAño.Value, OEDuracion.Value, OEEstablecimiento.Value, Text4.Value, "1", OEModalidad.Value };
                    logic.insertartablas("ep_estudio", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewestudios();
        }
        protected void btnguardarcuenta_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Value == "0" || ACNBanco1.SelectedValue == "0" || ACEstatus1.SelectedValue == "0" || ACTMoneda1.SelectedValue == "0" || ACMonto.Value == "0" || ACOFondos.Value == "0")
            {
                String script = "alert('Verificar que los campos de cuentas que no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] valores1 = { sig, cifactual, DropDownList1.Value, ACTMoneda1.SelectedValue, ACEstatus1.SelectedValue, ACNBanco1.SelectedValue, "1","nulo", ACMonto.Value, ACOFondos.Value };
                    logic.insertartablas("ep_cuentas", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasvarias();
        }
        protected void btnguardarcuentascoope_Click(object sender, EventArgs e)
        {
            if (ACCTMoneda1.SelectedValue == "0" || ACCEstatus1.SelectedValue == "0" || ACCNBanco1.SelectedValue == "0" || ACCOFondos.Value == "0" || ACCMonto.Value == "0"||Select1.Value == "0" )
            {
                String script = "alert('Verificar que los campos de de las cuentas en cooperativas no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] valores1 = { sig, cifactual, "3", ACCTMoneda1.SelectedValue, ACCEstatus1.SelectedValue, ACCNBanco1.SelectedValue, Select1.Value, "nulo", ACCMonto.Value, ACCOFondos.Value };
                    logic.insertartablas("ep_cuentas", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACCMonto.Value = "";
            ACCOFondos.Value = "";
            Select1.Value = "0";
            llenargridviewcuentasencoperativa();
        }
        protected void btnguardarcuentasporcobrar_Click(object sender, EventArgs e)
        {
            if (ACPNombre.Value == "" || ACPMonto.Value == "")
            {
                String script = "alert('Verificar que los campos de nombre, monto  y motivo de la cuenta por cobrar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] valores1 = { sig, cifactual, "4", "1", "1", "1","1", ACPNombre.Value, ACPMonto.Value, ACPMotivo.Value };
                    logic.insertartablas("ep_cuentas", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasporcobrar();
        }
        protected void btnguardarbienesinmuebles_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                if (ACTInmueble1.SelectedValue == "0" || ACFolio.Value == "" || ACLibro.Value == "" || ACDireccion.Value == "" || ACVActual.Value == "" || ACDes.Value == "")
                {
                    String script = "alert('Verificar que los campos de inmuebles no se encuentren vacios');";
                    ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                }
                else
                {
                    try
                    {
                        string sig = logic.siguiente("ep_inmueble", "codepinmueble");
                        string[] valores1 = { sig, ACTInmueble1.SelectedValue, cifactual, ACFolio.Value, ACLibro.Value, ACDireccion.Value, ACVActual.Value, ACDes.Value, ACcomentarioinmueble.Value,ACFinca.Value };
                        logic.insertartablas("ep_inmueble", valores1);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                    finally { try { cn.desconectar(); } catch { } }
                }
            }
                ACFolio.Value = "";
                ACLibro.Value = "";
                ACDireccion.Value = "";
            ACFinca.Value = "";
                ACVActual.Value = "";
                ACDes.Value = "";
            ACcomentarioinmueble.Value = "";
                llenargridviewbienesinmuebles();
            
        }
        protected void btnguardarvehiculos_Click(object sender, EventArgs e)
        {
            if (ACTVehiculo1.SelectedValue == "0" || ACMarca.Value == "" || ACLinea.Value == "" || ACModelo.Value == "" || ACPlaca.Value == "")
            {
                String script = "alert('Verificar que los campos de vehiculo no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_vehiculo", "codepvehiculo");
                    string[] valores1 = { sig, ACTVehiculo1.SelectedValue, cifactual, ACMarca.Value, ACLinea.Value, ACModelo.Value, ACPlaca.Value,ACCome.Value,Text25.Value,Text26.Value,Text27.Value};
                    logic.insertartablas("ep_vehiculo", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACMarca.Value = "";
            ACLinea.Value = "";
            ACModelo.Value = "";
            ACPlaca.Value = "";
            ACCome.Value = "";
            Text25.Value = "";
            Text26.Value = "";
            Text27.Value = "";
            llenargridviewvehiculos();
        }

        protected void btnguardarinversiones_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "0" || DropDownList3.SelectedValue == "0" || ACIMoneda1.SelectedValue == "0" || ACIMonto.Value == "")
            {
                String script = "alert('Verificar que los campos en inversiones  no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_inversiones", "codepinversiones");

                    string[] valores1 = { sig ,cifactual, DropDownList2.SelectedValue, DropDownList3.SelectedValue, ACIMoneda1.SelectedValue, "sinnombre",ACIPlazo.Value, ACIMonto.Value, ACIOrigeninv.Value,Text24.Value };

                    logic.insertartablas("ep_inversiones", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACIPlazo.Value = "";
            ACIMonto.Value = "";
            ACIOrigeninv.Value = "";
            Text24.Value = "";

            llenargridviewinversiones();
        }
        protected void btnguardarestudiosuni_Click(object sender, EventArgs e)
        {
            if (ENombreCarrera.Value=="" || ESemestre.Value == "" || EUniversidad.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios universitarios no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_estudio", "codepestudio");

                    string[] valores1 = { sig, cifactual, ENombreCarrera.Value, EAño.Value, ESemestre.Value, EUniversidad.Value,"sinidioma","0","sinmodalidad"};

                    logic.insertartablas("ep_estudio", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ENombreCarrera.Value = "";
            ESemestre.Value = "";
            EAño.Value = "";
            EUniversidad.Value = "";

            llenargridviewestudiosuniversitarios();
        }



        protected void btnagregarcuentasporpagar_Click(object sender, EventArgs e)
        {
            if (TipoCuenta.SelectedValue == "0" || PCPDes1.Value == "" || PCPMonto1.Value == "")
            {
                String script = "alert('Verificar que los campos de cuentas por pagar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentasporpagar", "codepcuentasporpagar");
                    string[] valores1 = { sig, cifactual, TipoCuenta.SelectedValue, PCPDes1.Value, PCPMonto1.Value };
                    logic.insertartablas("ep_cuentasporpagar", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PCPDes1.Value = "";
            PCPMonto1.Value = "";
            llenargridviewcuentasporpagar();
        }
        protected void btnagregarprestamo_Click(object sender, EventArgs e)
        {
            if (PTPrestamo1.SelectedValue == "0" || PNEntidad1.SelectedValue == "0" || PNPNEntidadnombre1.SelectedValue == "0" || PMInicial.Value == "" || PSActual.Value == "" || Datedesembolso.Value == "" || Datefinalizacion.Value == "" || PFDestino.Value == "")
            {
                String script = "alert('Verificar que los campos del prestamo no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_prestamo", "codepprestamo");
                    string[] valores1 = { sig, PTPrestamo1.SelectedValue, cifactual,PNPNEntidadnombre1.SelectedValue ,PNEntidad1.SelectedValue, PMInicial.Value, PSActual.Value, Datedesembolso.Value, Datefinalizacion.Value, PFDestino.Value };
                    logic.insertartablas("ep_prestamo", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PMInicial.Value = "";
            PSActual.Value = "";
            Datedesembolso.Value = "";
            Datefinalizacion.Value = "";
            PFDestino.Value = "";
            llenargridviewpasivos();
        }
        protected void btnagregartarjeta_Click(object sender, EventArgs e)
        {
            if (PTTEntidad1.SelectedValue == "0" || PTTNombre1.SelectedValue == "0" || PTTLimite.Value == "" || PTTLimite2.Value == "" || PTTSaldo.Value == "")
            {
                String script = "alert('Verificar que los campos de las tarjetas de credito no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_tarjetadecredito", "codeptrajetadecredito");
                    string[] valores1 = { sig, PTTEntidad1.SelectedValue, PTTNombre1.SelectedValue, cifactual, PTTLimite.Value, PTTLimite2.Value, PTTSaldo.Value };
                    logic.insertartablas("ep_tarjetadecredito", valores1);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PTTLimite.Value = "";
            PTTLimite2.Value = "";
            PTTSaldo.Value = "";
            llenargridviewtarjetas();
        }
       protected void btnmodificarcelular_Click(object sender, EventArgs e)
        {
            if (IGTCel1.SelectedValue == "0" || IGCelular.Value == "")
            {
                String script = "alert('Verificar que los campos de tipo y nombre del telefono no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_telefono", "codeptelefono");
                    string[] campos = { "codeptelefono", "codeptipotelefono", "codepinformaciongeneralcif", "ep_telefononumero" };
                    string[] datos = { Text6.Value,IGTCel1.SelectedValue, cifactual, IGCelular.Value };

                    logic.modificartablas("ep_telefono", campos, datos);

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcelulares();
        }


        protected void btnmodificarinversiones_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "0" || DropDownList3.SelectedValue == "0" || ACIMoneda1.SelectedValue == "0" || ACIMonto.Value == "")
            {
                String script = "alert('Verificar que los campos de inversiones no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_inversiones", "codepinversiones");
                    string[] campos = { "codepinversiones", "codepinformaciongeneralcif", "codeptipoinstitucion", "codepinstitucion", "codeptipomoneda", "ep_inversionesnombre", "ep_inversionesplazo", "ep_inversionesmonto", "ep_inversionesorigen", "ep_inversionesnumerocuenta" };
                    string[] datos = { Text21.Value, cifactual, DropDownList2.SelectedValue, DropDownList3.SelectedValue, ACIMoneda1.SelectedValue, "sinnombre", ACIPlazo.Value, ACIMonto.Value, ACIOrigeninv.Value,Text24.Value };

                    logic.modificartablas("ep_inversiones", campos, datos);

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACIPlazo.Value = "";
            ACIMonto.Value = "";
            ACIOrigeninv.Value = "";
            Text24.Value = "";

            llenargridviewinversiones();
        }
        protected void btnmodificarestudiosuni_Click(object sender, EventArgs e)
        {
            if (ENombreCarrera.Value == "" || ESemestre.Value == "" || EUniversidad.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios universitarios se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_estudio", "codepestudio");
                    string[] campos = { "codepestudio", "codepinformaciongeneralcif", "ep_estudionombre", "ep_estudioaño", "ep_estudioduracion", "ep_estudiolugar", "ep_estudiotipo" };
                    string[] datos = { Text22.Value, cifactual, ENombreCarrera.Value, EAño.Value, ESemestre.Value, EUniversidad.Value, "0" };

                    logic.modificartablas("ep_estudio", campos, datos);

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ENombreCarrera.Value = "";
            ESemestre.Value = "";
            EAño.Value = "";
            EUniversidad.Value = "";

            llenargridviewestudiosuniversitarios();
        }

   
        protected void btnmodificarhijos_Click(object sender, EventArgs e)
        {
            if (Text1.Value == "" || Text2.Value == "")
            {
                String script = "alert('Verificar que los campos de hijos no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_infofamiliar", "codepinfofamiliar");
                    string[] campos = { "codepinfofamiliar", "codepinformaciongeneralcif", "ep_infofamiliarnombrehijos", "ep_infofamiliarocupacionhijos", "ep_infofamiliarfechanacimientohijo" , "ep_infofamiliarcomentario" };
                    string[] datos = { Text7.Value,cifactual, Text1.Value, Text2.Value, Date1.Value, Text3.Value };

                    logic.modificartablas("ep_infofamiliar", campos, datos);

                    for (int i = 0; i < campos.Length; i++)
                    {
                        Response.Write(campos[i] + datos[i]);
                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewhijos();
        }
        protected void btnmodificarestudios_Click(object sender, EventArgs e)
        {
            if (OECurso.Value == "" || OEAño.Value == "" || OEDuracion.Value == "" || OEEstablecimiento.Value == "" || Text4.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_estudio", "codepestudio");
                    string[] campos = { "codepestudio", "codepinformaciongeneralcif", "ep_estudionombre", "ep_estudioaño", "ep_estudioduracion", "ep_estudiolugar", "ep_estudioidioma", "ep_estudiomodalidad" };
                    string[] datos = { Text12.Value, cifactual, OECurso.Value, OEAño.Value, OEDuracion.Value, OEEstablecimiento.Value, Text4.Value, OEModalidad.Value };
                    logic.modificartablas("ep_estudio", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewestudios();
        }
        protected void btnmodificarcuenta_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Value == "0" || ACNBanco1.SelectedValue == "0" || ACEstatus1.SelectedValue == "0" || ACTMoneda1.SelectedValue == "0" || ACMonto.Value == "0" || ACOFondos.Value == "0")
            {
                String script = "alert('Verificar que los campos de cuentas que no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] campos = { "codepcuentas", "codepinformaciongeneralcif", "codeptipocuenta", "codeptipomoneda", "codeptipoestatuscuenta", "codepinstitucion", "ep_cuentasmonto", "ep_cuentasorigen" };
                    string[] datos = { Text13.Value, cifactual, DropDownList1.Value, ACTMoneda1.SelectedValue, ACEstatus1.SelectedValue, ACNBanco1.SelectedValue, ACMonto.Value, ACOFondos.Value };
                    logic.modificartablas("ep_cuentas",campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasvarias();
        }
        protected void btnmodificarcuentascoope_Click(object sender, EventArgs e)
        {
            if (ACCTMoneda1.SelectedValue == "0" || ACCEstatus1.SelectedValue == "0" || ACCNBanco1.SelectedValue == "0" || ACCOFondos.Value == "0" || ACCMonto.Value == "0")
            {
                String script = "alert('Verificar que los campos de de las cuentas en cooperativas no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] campos = { "codepcuentas", "codepinformaciongeneralcif", "codeptipomoneda", "codeptipoestatuscuenta", "codepinstitucion", "codeptipocuentacooperativa", "ep_cuentasmonto", "ep_cuentasorigen" };
                    string[] datos = { Text14.Value, cifactual, ACCTMoneda1.SelectedValue, ACCEstatus1.SelectedValue, ACCNBanco1.SelectedValue,Select1.Value ,ACCMonto.Value, ACCOFondos.Value };
                    logic.modificartablas("ep_cuentas", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACCMonto.Value = "";
            ACCOFondos.Value = "";
            Select1.Value = "0";
            llenargridviewcuentasencoperativa();
        }
        protected void btnmodificarcuentasporcobrar_Click(object sender, EventArgs e)
        {
            if (ACPNombre.Value == "" || ACPMonto.Value == "")
            {
                String script = "alert('Verificar que los campos de nombre, monto  y motivo de la cuenta por cobrar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentas", "codepcuentas");
                    string[] campos = { "codepcuentas", "codepinformaciongeneralcif", "ep_cuentasnombre", "ep_cuentasmonto", "ep_cuentasorigen" };
                    string[] datos = { Text15.Value, cifactual, ACPNombre.Value, ACPMonto.Value, ACPMotivo.Value };
                    logic.modificartablas("ep_cuentas", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasporcobrar();
        }
        protected void btnmodificarbienesinmuebles_Click(object sender, EventArgs e)
        {
            if (ACTInmueble1.SelectedValue == "0" || ACFolio.Value == "" || ACLibro.Value == "" || ACDireccion.Value == "" || ACVActual.Value == "" || ACDes.Value == "")
            {
                String script = "alert('Verificar que los campos de inmuebles no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_inmueble", "codepinmueble");
                    string[] campos = { "codepinmueble", "codeptipoinmueble", "codepinformaciongeneralcif", "ep_inmueblefolio", "ep_inmueblelibro", "ep_inmuebledireccion", "ep_inmueblevalor", "ep_inmuebledescripcion", "ep_inmueblecomentario", "ep_inmueblefinca" };
                    string[] datos = { Text16.Value, ACTInmueble1.SelectedValue, cifactual, ACFolio.Value, ACLibro.Value, ACDireccion.Value, ACVActual.Value, ACDes.Value, ACcomentarioinmueble.Value,ACFinca.Value };
                    logic.modificartablas("ep_inmueble", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACFolio.Value = "";
            ACLibro.Value = "";
            ACDireccion.Value = "";
            ACFinca.Value = "";
            ACVActual.Value = "";
            ACDes.Value = "";
            ACcomentarioinmueble.Value = "";
            llenargridviewbienesinmuebles();
        }
        protected void btnmodificarvehiculos_Click(object sender, EventArgs e)
        {
            if (ACTVehiculo1.SelectedValue == "0" || ACMarca.Value == "" || ACLinea.Value == "" || ACModelo.Value == "" || ACPlaca.Value == "")
            {
                String script = "alert('Verificar que los campos de vehiculo no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_vehiculo", "codepvehiculo");
                    string[] campos = { "codepvehiculo", "codeptipovehiculo", "codepinformaciongeneralcif", "ep_vehiculomarca", "ep_vehiculolinea", "ep_vehiculomodelo", "ep_vehiculoplaca", "ep_vehiculocomentario", "ep_vehiculoanombrede", "ep_vehiculomotivodeanombrede", "ep_vehiculomonto" };
                    string[] datos = { Text17.Value, ACTVehiculo1.SelectedValue, cifactual, ACMarca.Value, ACLinea.Value, ACModelo.Value, ACPlaca.Value,ACCome.Value,Text25.Value,Text26.Value,Text27.Value};
                    logic.modificartablas("ep_vehiculo", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACMarca.Value = "";
            ACLinea.Value = "";
            ACModelo.Value = "";
            ACPlaca.Value = "";
            ACCome.Value = "";
            Text25.Value = "";
            Text26.Value = "";
            Text27.Value = "";
            llenargridviewvehiculos();
        }
        protected void btnmodificarcuentasporpagar_Click(object sender, EventArgs e)
        {
            if (TipoCuenta.SelectedValue == "0" || PCPDes1.Value == "" || PCPMonto1.Value == "")
            {
                String script = "alert('Verificar que los campos de cuentas por pagar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_cuentasporpagar", "codepcuentasporpagar");
                    string[] campos = { "codepcuentasporpagar", "codepinformaciongeneralcif", "codeptipocuentasporpagar", "ep_cuentasporpagardescripcion", "ep_cuentasporpagarmonto" };
                    string[] datos = { Text18.Value, cifactual, TipoCuenta.SelectedValue, PCPDes1.Value, PCPMonto1.Value };
                    logic.modificartablas("ep_cuentasporpagar", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PCPDes1.Value = "";
            PCPMonto1.Value = "";
            llenargridviewcuentasporpagar();
        }
        protected void btnmodificarprestamos_Click(object sender, EventArgs e)
        {
            if (PTPrestamo1.SelectedValue == "0" || PNEntidad1.SelectedValue == "0" || PNPNEntidadnombre1.SelectedValue == "0" || PMInicial.Value == "" || PSActual.Value == "" || Datedesembolso.Value == "" || Datefinalizacion.Value == "" || PFDestino.Value == "")
            {
                String script = "alert('Verificar que los campos del prestamo no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_prestamo", "codepprestamo");
                    string[] campos = { "codepprestamo", "codeptipoprestamo", "codepinformaciongeneralcif", "codeptipoinstitucion", "codepinstitucion", "ep_prestamomomentoinicial", "ep_prestamosaldoactual", "ep_prestamofechadesembolso", "ep_prestamofechadefinalizacion", "ep_prestamodestino" };
                    string[] datos = { Text19.Value, PTPrestamo1.SelectedValue, cifactual, PNEntidad1.SelectedValue, PNPNEntidadnombre1.SelectedValue, PMInicial.Value, PSActual.Value, Datedesembolso.Value, Datefinalizacion.Value, PFDestino.Value };
                    logic.modificartablas("ep_prestamo", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PMInicial.Value = "";
            PSActual.Value = "";
            Datedesembolso.Value = "";
            Datefinalizacion.Value = "";
            PFDestino.Value = "";
            llenargridviewpasivos();
        }
        protected void btnmodificartarjetacredito_Click(object sender, EventArgs e)
        {
            if (PTTEntidad1.SelectedValue == "0" || PTTNombre1.SelectedValue == "0" || PTTLimite.Value == "" || PTTLimite2.Value == "" || PTTSaldo.Value == "")
            {
                String script = "alert('Verificar que los campos de las tarjetas de credito no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    string sig = logic.siguiente("ep_tarjetadecredito", "codeptrajetadecredito");
                    string[] campos = { "codeptrajetadecredito", "codeptipoinstitucion", "codepinstitucion", "codepinformaciongeneralcif", "ep_tarjetadecreditomonedaqtz", "ep_tarjetadecreditomonedausd", "ep_tarjetadecreditosaldoactual" };
                    string[] datos = { Text20.Value, PTTEntidad1.SelectedValue, PTTNombre1.SelectedValue, cifactual, PTTLimite.Value, PTTLimite2.Value, PTTSaldo.Value };
                    logic.modificartablas("ep_tarjetadecredito", campos, datos);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PTTLimite.Value = "";
            PTTLimite2.Value = "";
            PTTSaldo.Value = "";
            llenargridviewtarjetas();
        }

        protected void btneliminarcelular_Click(object sender, EventArgs e)
        {
            if (IGTCel1.SelectedValue == "0" || IGCelular.Value == "")
            {
                String script = "alert('Verificar que los campos de tipo y nombre del telefono no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_telefono", "codeptelefono", Text6.Value );
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcelulares();
        }

        protected void btneliminarinversion_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "0" || DropDownList3.SelectedValue == "0" || ACIMoneda1.SelectedValue == "0" || ACIMonto.Value == "")
            {
                String script = "alert('Verificar que los de inversiones se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_inversiones", "codepinversiones", Text21.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACIPlazo.Value = "";
            ACIMonto.Value = "";
            ACIOrigeninv.Value = "";
            Text24.Value = "";


            llenargridviewinversiones();
        }

        protected void btneliminarhijos_Click(object sender, EventArgs e)
        {
            if (Text1.Value == "" || Text2.Value == "")
            {
                String script = "alert('Verificar que los campos de hijos no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_infofamiliar", "codepinfofamiliar", Text7.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewhijos();
        }

        protected void btneliminarestudios_Click(object sender, EventArgs e)
        {
            if (OECurso.Value == "" || OEAño.Value == "" || OEDuracion.Value == "" || OEEstablecimiento.Value == "" || Text4.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_estudio", "codepestudio", Text12.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewestudios();
        }

        protected void btneliminarcuenta_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Value == "0" || ACNBanco1.SelectedValue == "0" || ACEstatus1.SelectedValue == "0" || ACTMoneda1.SelectedValue == "0" || ACMonto.Value == "0" || ACOFondos.Value == "0")
            {
                String script = "alert('Verificar que los campos de cuentas que no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_cuentas", "codepcuentas", Text13.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasvarias();
        }

        protected void btneliminarcuentascoope_Click(object sender, EventArgs e)
        {
            if (ACCTMoneda1.SelectedValue == "0" || ACCEstatus1.SelectedValue == "0" || ACCNBanco1.SelectedValue == "0" || ACCOFondos.Value == "0" || ACCMonto.Value == "0" || Select1.Value=="0")
            {
                String script = "alert('Verificar que los campos de de las cuentas en cooperativas no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_cuentas", "codepcuentas", Text14.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACCMonto.Value = "";
            ACCOFondos.Value = "";
            Select1.Value = "0";
            llenargridviewcuentasencoperativa();
        }

        protected void btneliminarcuentasporcobrar_Click(object sender, EventArgs e)
        {
            if (ACPNombre.Value == "" || ACPMonto.Value == "")
            {
                String script = "alert('Verificar que los campos de nombre, monto  y motivo de la cuenta por cobrar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_cuentas", "codepcuentas", Text15.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            llenargridviewcuentasporcobrar();
        }

        protected void btneliminarbienesinmuebles_Click(object sender, EventArgs e)
        {
            if (ACTInmueble1.SelectedValue == "0" || ACFolio.Value == "" || ACLibro.Value == "" || ACDireccion.Value == "" || ACVActual.Value == "" || ACDes.Value == "")
            {
                String script = "alert('Verificar que los campos de inmuebles no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_inmueble", "codepinmueble", Text16.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACFolio.Value = "";
            ACLibro.Value = "";
            ACDireccion.Value = "";
            ACFinca.Value = "";
            ACVActual.Value = "";
            ACDes.Value = "";
            ACcomentarioinmueble.Value = "";
            llenargridviewbienesinmuebles();
        }

        protected void btneliminarvehiculos_Click(object sender, EventArgs e)
        {
            if (ACTVehiculo1.SelectedValue == "0" || ACMarca.Value == "" || ACLinea.Value == "" || ACModelo.Value == "" || ACPlaca.Value == "")
            {
                String script = "alert('Verificar que los campos de vehiculo no se encuentren vacios o que este seleccionado si el vehiculo le pertenece o no');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_vehiculo", "codepvehiculo", Text17.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ACMarca.Value = "";
            ACLinea.Value = "";
            ACModelo.Value = "";
            ACPlaca.Value = "";
            ACCome.Value = "";
            Text25.Value = "";
            Text26.Value = "";
            Text27.Value = "";
            llenargridviewvehiculos();
        }

        protected void btneliminarcuentasporpagar_Click(object sender, EventArgs e)
        {
            if (TipoCuenta.SelectedValue == "0" || PCPDes1.Value == "" || PCPMonto1.Value == "")
            {
                String script = "alert('Verificar que los campos de cuentas por pagar no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_cuentasporpagar", "codepcuentasporpagar", Text18.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PCPDes1.Value = "";
            PCPMonto1.Value = "";
            llenargridviewcuentasporpagar();
        }

        protected void btneliminarprestamos_Click(object sender, EventArgs e)
        {
            if (PTPrestamo1.SelectedValue == "0" || PNEntidad1.SelectedValue == "0" || PNPNEntidadnombre1.SelectedValue == "0" || PMInicial.Value == "" || PSActual.Value == "" || Datedesembolso.Value == "" || Datefinalizacion.Value == "" || PFDestino.Value == "")
            {
                String script = "alert('Verificar que los campos del prestamo no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_prestamo", "codepprestamo", Text19.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PMInicial.Value = "";
            PSActual.Value = "";
            Datedesembolso.Value = "";
            Datefinalizacion.Value = "";
            PFDestino.Value = "";
            llenargridviewpasivos();
        }

        protected void btneliminartarjetacredito_Click(object sender, EventArgs e)
        {
            if (PTTEntidad1.SelectedValue == "0" || PTTNombre1.SelectedValue == "0" || PTTLimite.Value == "" || PTTLimite2.Value == "" || PTTSaldo.Value == "")
            {
                String script = "alert('Verificar que los campos de las tarjetas de credito no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_tarjetadecredito", "codeptrajetadecredito", Text20.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            PTTLimite.Value = "";
            PTTLimite2.Value = "";
            PTTSaldo.Value = "";
            llenargridviewtarjetas();
        }

        protected void btneliminarestudiosuni_Click(object sender, EventArgs e)
        {
            if (ENombreCarrera.Value == "" || ESemestre.Value == "" || EUniversidad.Value == "")
            {
                String script = "alert('Verificar que los campos de estudios universitarios no se encuentren vacios');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                try
                {
                    logic.eliminarregistro("ep_estudio", "codepestudio", Text22.Value);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            }
            ENombreCarrera.Value = "";
            ESemestre.Value = "";
            EAño.Value = "";
            EUniversidad.Value = "";

            llenargridviewestudiosuniversitarios();
        }
    }
}
