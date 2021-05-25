using KB_Guadalupana.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.MantenimientosEP
{
    public partial class Mant_epestados : System.Web.UI.Page
    {
        Sentencia sn = new Sentencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (validaciondesesion()==false)
            {
                String script = "alert('EL USUARIO CON EL QUE HA INGRESADO NO EXISTE O NO ES VALIDO'); window.location.href= 'MenuMantenimientos.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }            
            if (!IsPostBack)
            {

            }
            lblcambioestado.Visible = false;
            comboestado.Visible = false;
            btnefectuar.Visible = false;
        }
        public bool verificaciondeusuario(string cif)
        {                       
            string[] var1 = sn.consultarloteepcif(cif);
            if (var1[0] == null)
            {
                lblerror.InnerText = "EL CIF INGRESADO NO SE ENCUENTRA ALMACENADO";
                return false;
            }
            else
            {
                if (validacionloteactual(var1[0]) == false)
                {
                    
                    lblerror.InnerText = "EL CIF INGRESADO NO TIENE UN LOTE ACTIVO";
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        public bool validacionloteactual(string lote)
        {
            string[] var1 = sn.consultarloteactivo();
            if (var1[0] == lote)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        protected void btncambiar_Click(object sender, EventArgs e)
        {
            if (txtingresocif.Value != "")
            {


                string[] var4 = sn.consultarcorrelativoepcif(txtingresocif.Value);
                if (var4[0] == null || var4[0] == "")
                {
                    lblerror.InnerText = "EL CIF QUE ESTA INGRESANDO NO SE ENCUENTRA ALMACENADO";
                    txtcorrelativo.Value = "";
                    txtingresocif.Value = "";
                }
                else
                {
                    for (int i = 0; i < var4.Length; i++)
                    {
                        if (verificaciondeusuario(var4[i]) == true)
                        {
                            lblcorrelativo.Visible = false;
                            txtcorrelativo.Visible = false;
                            txtingresocif.Visible = false;
                            lblcorrelativo.Visible = false;
                            btncambiar.Visible = false;
                            lblcif.Visible = false;
                            lblerror.InnerText = "CORRELATIVO:" + var4[i];
                            txtcorrelativo.Value = var4[i];
                            string[] var5 = sn.consultarestadodelcorrelativo(var4[i]);
                            if (var5[0] == "2" || var5[0] == "3")
                            {
                                comboestado.Value = var5[0];
                                lblcambioestado.Visible = true;
                                comboestado.Visible = true;
                                btnefectuar.Visible = true;
                              
                            }
                            else
                            {
                                lblerror.InnerText = "EL CIF SE ENCUENTRA EN ESTADO BLOQUEADO, COMUNICARSE CON INFORMATICA Y REGRESE AL MENÚ";
                                txtcorrelativo.Value = "";
                                txtingresocif.Value = "";
                                txtcorrelativo.Disabled = true;
                                txtingresocif.Disabled = true;
                                btncambiar.Visible = false;
                                comboestado.Visible = false;
                                comboestado.Visible = false;
                                btnefectuar.Visible = false;
                                lblcambioestado.Visible = false;
                                lblcorrelativo.Visible = false;


                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                lblerror.InnerText = "LLENE EL CAMPO DE CIF PARA PROCEDER";
            }
            txtingresocif.Value = "";
            txtcorrelativo.Value = "";
            
        }

        protected void btnefectuar_Click(object sender, EventArgs e)
        {
            if (txtcorrelativo.Value=="" && txtingresocif.Value =="" && comboestado.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('ERROR - LA OPERACIÓN FALLO');", true);
            }
            else
            {
                string lbl = lblerror.InnerText;
                string[] dividido = lbl.Split(':');
                string dato = dividido[1].Trim();

                string[] campos = { "codepinformaciongeneralcif", "codeptipoestado" };
                string[] valores = { dato, comboestado.Value };
                try
                {
                    sn.modificartablas("ep_informaciongeneral", campos, valores);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "fallo");
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('OPERACIÓN EFECTUADA PARA EL CIF: " + txtingresocif.Value + "');", true);
                
            }

            lblcorrelativo.Visible = true;
            txtcorrelativo.Visible = true;
            txtingresocif.Visible = true;
            lblcorrelativo.Visible = true;
            lblerror.Visible = false;
            btncambiar.Visible = true;
            lblcif.Visible = true;
            lblerror.InnerText = "";
            lblerror.Visible=true;
        }

        protected void btnmenuprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MenuBarra.aspx");
        }
        public bool validaciondesesion()
        {
          
            string nombreusuario = Session["sesion_usuario"].ToString().Trim();
            string[] var1 = sn.consultarmdipermisos(nombreusuario);
            if (nombreusuario==null || nombreusuario == "")
            {
                Response.Redirect("../../Index.aspx");
            }
            else
            {
                for(int i=0; i < var1.Length; i++)
                {
                    if (var1[i]== "MANTEP")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}