using SA_Arqueos.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Arqueos.Models
{
    public class Logica_arqueos
    {
        Sentencia_arqueos sn = new Sentencia_arqueos();
        public void insertarconcepto(string numero, string nombre)
        {

            string cadena = "INSERT INTO gen_sucursal VALUES ('" + numero + "', '" + nombre + "')";
            sn.ingreso(cadena);

        }
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }

        public string ultimoid(string tabla, string campo)
        {
            string llave = sn.ultimoid(tabla, campo);
            return llave;
        }
        public MySqlDataReader consultartabla(string tabla)
        {
            return sn.consultar(tabla);
        }

        public MySqlDataReader consultarRol(string usuario)
        {
            return sn.consultarRol(usuario);
        }

        public MySqlDataReader consultarArea(string usuario)
        {
            return sn.consultarArea(usuario);
        }

        public MySqlDataReader consultarTotal(string id)
        {
            return sn.consultarTotal(id);
        }

        public MySqlDataReader consultarTotalHaber()
        {
            return sn.consultarTotalHaber();
        }

        public MySqlDataReader consultarCodigo(string usuario)
        {
            return sn.consultarCodigo(usuario);
        }

        public MySqlDataReader validarfechadeingreso_ep()
        {
            return sn.validarfechadeingreso_ep();
        }

        public MySqlDataReader fechaactual()
        {
            return sn.fechaactual();
        }
        public MySqlDataReader busquedacif(string usuario, string lote)
        {
            return sn.busquedacif(usuario, lote);
        }

        public MySqlDataReader estadodeprocesocif(string cif)
        {
            return sn.estadodeprocesocif(cif);
        }
        public void insertartablas(string tabla, string[] datos)
        {
            sn.insertartablas(tabla, datos);
        }
        public MySqlDataReader modificartablas(string tabla, string[] campos, string[] datos)
        {
            return sn.modificartablas(tabla, campos, datos);
        }

        public MySqlDataReader modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            return sn.modificartablasdoscampos(tabla, campos, datos);
        }
        public MySqlDataReader consultarconcampo(string tabla, string campo, string valor)
        {
            return sn.consultarconcampo(tabla, campo, valor);
        }
        public MySqlDataReader consultaridcontrol(string usuario, string lote)
        {
            return sn.consultaridcontrol(usuario, lote);
        }

        //MODIFICAR ENCABEZADO
        public void modificarencabezado(string dolares, string id)
        {
             sn.modificarencabezado(dolares, id);
        }


        public DataTable llenarGridView(string id)
        {
            return sn.llenarGridView(id);
        }



    }
}