using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Models
{
    public class Logica
    {
        Sentencia sn = new Sentencia();
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

        public void insertartablas(string tabla, string[] datos)
        {
          sn.insertartablas(tabla, datos);
        }
        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
             sn.modificartablas(tabla, campos, datos);
        }

        public void modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
             sn.modificartablasdoscampos(tabla, campos, datos);
        }






        //FUNCIONES PARA CONSULTAR ESTADO PATRIMONIAL YA INGRESADO

        //FUNCIONES DE MOSTRAR


        public MySqlDataReader consultarCodigo(string usuario)
        {
            return sn.consultarCodigo(usuario);
        }


        public MySqlDataReader consultarIE(string tabla, string campo, string valor)
        {
            return sn.consultarconcampoIE(tabla, campo, valor);
        }


        public MySqlDataReader consultarIO(string tabla, string campo, string valor)
        {
            return sn.consultarconcampoIO(tabla, campo, valor);
        }

        public MySqlDataReader consultarCaja(string tabla, string campo, string valor)
        {
            return sn.consultarconcampoCaja(tabla, campo, valor);
        }

        public MySqlDataReader consultarInv(string tabla, string campo, string valor)
        {
            return sn.consultarconcampoInv(tabla, campo, valor);
        }

        public MySqlDataReader consultarmaquinaria(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomaq(tabla, campo, valor);
        }

        public MySqlDataReader consultarmenaje(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaje(tabla, campo, valor);
        }

        public MySqlDataReader consultarmenaje1(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaje1(tabla, campo, valor);
        }

        public MySqlDataReader consultarmenaje2(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaje2(tabla, campo, valor);
        }

        public MySqlDataReader consultarTV(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenajeTV(tabla, campo, valor);
        }

        public MySqlDataReader consultarES(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenajeES(tabla, campo, valor);
        }

        public MySqlDataReader consultarL(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenajeL(tabla, campo, valor);
        }

        public MySqlDataReader consultarSec(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaSec(tabla, campo, valor);
        }

        public MySqlDataReader consultarEst(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaEST(tabla, campo, valor);
        }

        public MySqlDataReader consultarRefri(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaRefri(tabla, campo, valor);
        }

        public MySqlDataReader consultarTel(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaTel(tabla, campo, valor);
        }

        public MySqlDataReader consultarOtros(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaOtros(tabla, campo, valor);
        }

        public MySqlDataReader consultarOD(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaOD(tabla, campo, valor);
        }

        public MySqlDataReader consultarmostrarPC(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaPC(tabla, campo, valor);
        }

        public MySqlDataReader consultarmostrarIng(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaIng(tabla, campo, valor);
        }

        public MySqlDataReader consultarmostrarNeg(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaNeg(tabla, campo, valor);
        }

        public MySqlDataReader consultarmostrarRem(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaRem(tabla, campo, valor);
        }

        public MySqlDataReader consultarmostrarEgres(string tabla, string campo, string valor)
        {
            return sn.consultarconcampomenaEgres(tabla, campo, valor);
        }

        public void eliminarregistro(string tabla, string campo, string dato)
        {
            sn.eliminarregistro(tabla, campo, dato);
        }

    }
}