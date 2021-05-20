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

        public string contpdf(string usuario)
        {

            string datos = mex.contpdf(usuario);
            return datos;
        }
        public string contenv(string area )
        {

            string ean13 = mex.contenv(area);
            return ean13;
        }
        public string contenv2()
        {

            string ean13 = mex.contenv2();
            return ean13;
        }
        public string contpen(string area )
        {

            string ean13 = mex.contpen(area);
            return ean13;
        }
        public string contret(string area )
        {

            string ean13 = mex.contret(area);
            return ean13;
        }
        public string contexis(string area)
        {

            string ean13 = mex.contexis(area);
            return ean13;
        }

        //fin
    

        public string obtenerrol(string user)
        {

            string rol = mex.obtenerrol(user);
            return rol;
        }
        public string obtenerarea(string user)
        {

            string area = mex.obtenerarea(user);
            return area;
        }
        public string obtenerareanombre(string area)
        {

            string cod = mex.obtenerareanombre(area);
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
        public string obtenercoduserexp(string crd)
        {

            string cod = mex.obtenercoduserexp(crd);
            return cod;
        }
        public string obtenercrdexp(string crd)
        {

            string cod = mex.obtenercrdexp(crd);
            return cod;
        }
        public string obtenertipo(string crd)
        {

            string tipo = mex.obtenertipocrd(crd);
            return tipo;
        }
        public string obtenertiponombre(string crd)
        {

            string tipo = mex.obtenertipocrdnom(crd);
            return tipo;
        }
        public string obtenerlote(string crd)
        {

            string lote = mex.obtenerlote(crd);
            return lote;
        }
        public string obtenerlote2(string crd)
        {

            string lote = mex.obtenerlote2(crd);
            return lote;
        }
        public string obtenercodexp(string crd)
        {

            string cod = mex.obtenerexp(crd);
            return cod;
        }
        public string obtenercodenv(string crd)
        {

            string cod = mex.obtenercodenv(crd);
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
        public string siguiente2(string tabla, string campo)
        {
            string llave = mex.obtenerfinallote(tabla, campo);
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