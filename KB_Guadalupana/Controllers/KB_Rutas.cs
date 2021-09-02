using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class KB_Rutas
    {
        public string rutaestaticaarchivoshallazgos()
        {
            string rutaestaticaarchivoshallazgos = @"C:\ARCHIVOS_KBGUADALUPANA\SISTEMA_HALLAZGOS\Archivos\";
            return rutaestaticaarchivoshallazgos;
        }
        public string rutaestaticaarchivoscrm()
        {
            string rutaestaticaarchivoscrm = @"C:\ARCHIVOS_KBGUADALUPANA\SISTEMA_CRM\ArchiverodeLeads\";
            return rutaestaticaarchivoscrm;
        }
        public string rutaexpedientes() {

            string rutaestaticaexpedientes = @"C:\ARCHIVOS_KBGUADALUPANA\SISTEMA-EXPEDIENTES\Imagenes\pdfencab.png";
            return rutaestaticaexpedientes;


        }
    }
}