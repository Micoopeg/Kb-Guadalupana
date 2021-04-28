using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;

namespace KB_Guadalupana.Models
{
    public class Logica_Hallazgos
    {
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();

        public string siguiente(string tabla, string campo)
        {
            string llave = sen.obtenerfinal(tabla, campo);
            return llave;
        }

        public void insertartablas(string tabla, string[] datos)
        {
            sen.insertartablas(tabla, datos);
        }

        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            sen.modificartablas(tabla, campos, datos);
        }

        public void modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            sen.modificartablasdoscampos(tabla, campos, datos);
        }
    }
}