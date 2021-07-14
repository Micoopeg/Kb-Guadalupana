using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;

namespace KB_Guadalupana.Views.Evaluaciones
{
    public partial class SQ_Dashboard : System.Web.UI.Page
    {
        string fechamin, fechahora;
        char delimitador2 = ' ';
        ModeloSQ msq = new ModeloSQ();
        protected void Page_Load(object sender, EventArgs e)
        {

            now();

        }

        public void now()
        {

            string[] fecha = msq.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);

                    fechahora = valores2[2] + "/" + valores2[1] + "/" + valores2[0];

                    Date.InnerText = fechahora;

                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}