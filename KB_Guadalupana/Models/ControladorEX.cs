using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KB_Guadalupana.Models;
using KB_Guadalupana.Controllers;
namespace KB_Guadalupana.Models
{
    public class ControladorEX
    {
        ModeloEX mex = new ModeloEX();
        public string agencia(string agencia)
        {

            string nomagencia = mex.Agencia(agencia);
            return nomagencia;
        }






    }
}