using System;
using System.Data;
using MySql.Data.MySqlClient;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class SeguridadArqueo : System.Web.UI.Page
    {
        Sentencia_seguridad sn = new Sentencia_seguridad();
        Conexion_seguridad cn = new Conexion_seguridad();
        string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcombopuesto();
                SAUsuario.Value = Session["usuario_seguridad"] as string;
            }
            
        }

        public void llenarcombopuesto()
        {
            try
            {
                string QueryString = "select * from sa_puesto";
                MySqlConnection conect = cn.conectar();
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Puesto");
                SAPuesto.DataSource = ds;
                SAPuesto.DataTextField = "sa_puestonombre";
                SAPuesto.DataValueField = "idsa_puesto";
                SAPuesto.DataBind();
                SAPuesto.Items.Insert(0, new ListItem("[Puesto]", "0"));
            }
            catch { }
            finally { try { cn.desconectar(); } catch { } }
        }

        protected void SGuardar_Click(object sender, EventArgs e)
        {
            usuario = sn.obteneridusuario(SAUsuario.Value);
            sn.actualizarArqueos(SAPuesto.SelectedValue, usuario);
        }
    }
}