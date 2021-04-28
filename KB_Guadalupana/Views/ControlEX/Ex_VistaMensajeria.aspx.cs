using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;

namespace KB_Guadalupana.Views.ControlEX
{
    public partial class Ex_VistaMensajeria : System.Web.UI.Page
    {
        ControladorEX exc = new ControladorEX();
        ModeloEX mex = new ModeloEX();
        string fechaactual, fechamin, fechahora;
        char delimitador2 = ' ';
        protected void Page_Load(object sender, EventArgs e)
        {

            now();

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
        protected void envio_Click(object sender, EventArgs e)
        {
            if (name.Text != "") {
                //estado recibido y etapa 1 bitacora
                string verifica = mex.lotevalidado(name.Text);
                if (verifica != "True") {
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
                            string updateenviolote = "UPDATE `ex_envio` SET `estado`= 2,`codexetapa`= 2 WHERE codexenvio = '" + numeroenv + "' ";
                            exc.Insertar(updateenviolote);

                            string bitacora = "INSERT INTO `ex_bitacora` (`codexbit`, `codexenvio`, `codexp`, `ex_fechaev`, `codexevento`, `codexetapa`) VALUES ('" + sigbit + "', '" + numeroenv + "', '" + codexp + "', '" + fechaactual + "', 2, 2 );";
                            exc.Insertar(bitacora);

                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Validado')", true);
                        }
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Lote Inválido')", true); }
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Este Lote Ya Fué Validado')", true); }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Número inválido')", true); }
            

            //estado enviado y etapa 2 envios

        }
    }
}