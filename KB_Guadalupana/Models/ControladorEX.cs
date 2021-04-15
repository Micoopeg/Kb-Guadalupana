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
        public string obtenercodporcif(string cif)
        {

            string cod = mex.obtenercodporcif(cif);
            return cod;
        }

        //conteo expedientes

        public string contenv(string usuario)
        {

            string ean13 = mex.contenv(usuario);
            return ean13;
        }
        public string contpen(string usuario)
        {

            string ean13 = mex.contpen(usuario);
            return ean13;
        }
        public string contret(string usuario)
        {

            string ean13 = mex.contret(usuario);
            return ean13;
        }
        public string contexis(string usuario)
        {

            string ean13 = mex.contexis(usuario);
            return ean13;
        }

        //fin
        public string obtenerean13(string expediente)
        {

            string ean13 = mex.obtenerean13(expediente);
            return ean13;
        }

        public string obtenercodcred(string codexp)
        {

            string cod = mex.obtenercodcred(codexp);
            return cod;
        }
        public string obtenercodncred(string ncred)
        {

            string cod = mex.obtenercodncred(ncred);
            return cod;
        }
        public string obtenercoduser(string nomuser)
        {

            string cod = mex.obtenercoduser(nomuser);
            return cod;
        }

        public void Insertar(string sql)
        {

            mex.Insertar(sql);

        }
        public string siguiente(string tabla, string campo)
        {
            string llave = mex.obtenerfinal(tabla, campo);
            return llave;
        }
        public string ultimo(string tabla, string campo)
        {
            string llave = mex.obtenerultimo(tabla, campo);
            return llave;
        }
        public string buscaeanigual(string ean)
        {
            string repetido = mex.buscareanigual(ean);
            return repetido;
        }
        public string tablavacia(string tabla)
        {
            string tab = mex.tablavacia(tabla);
            return tab;
        }

    }
}