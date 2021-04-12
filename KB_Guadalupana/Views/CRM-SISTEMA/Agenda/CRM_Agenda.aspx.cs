using CRM_Guadalupana.Controllers;
using CRM_Guadalupana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Agenda
{
    public partial class CRM_Agenda : System.Web.UI.Page
    {
        string key = "millave";
        CRM_Sentencias sn = new CRM_Sentencias();
        CRM_Logica logic = new CRM_Logica();
        CRM_Conexion cn = new CRM_Conexion();
        string datoausar="";
        protected void Page_Load(object sender, EventArgs e)
        {
            string var = Request.QueryString["Nombre"];
            // Response.Write(var);




             datoausar = Desencriptar(var);
            txtcodigo.Value = datoausar;
            // Response.Write(datoausar);



        }
        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        protected void btnagendar_Click(object sender, EventArgs e)
        {
  
            if (txtencabezado.Value == "" || txtfechainicio.Value == "" ||
               txtfechafin.Value == "" || TextArea1.Value == "")
            {
                String script = "alert('Verifique que todos los campos se encuentren llenos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                string[] valor1 = sn.consultarcontrolingreso(txtcodigo.Value);
                string sig1 = logic.siguiente("crmalertas_programadas", "codcrmalertasprogramadas");
                string[] valores = {sig1,valor1[0],txtfechainicio.Value,txtfechafin.Value,
                txtencabezado.Value,TextArea1.Value,"1"};
                try
                {
                    logic.insertartablas("crmalertas_programadas", valores);                    
                }
                catch
                {
                    Console.WriteLine("dejo de funcionar");
                }
                String script = "alert('Guardado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                txtencabezado.Value = "";
                txtfechainicio.Value = "";
                txtfechafin.Value ="";
                TextArea1.Value = "";
            }
        }
    }
}