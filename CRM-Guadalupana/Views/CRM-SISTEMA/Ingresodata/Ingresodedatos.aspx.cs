using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Guadalupana.Views.CRM_SISTEMA.Ingresodata
{
    public partial class Ingresodedatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool ChecarExtension(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".csv":
                    return true;
                default:
                    return false;
            }
        }
        private DataTable CrearTabla(String fila)
        {
            int cantidadColumnas;
            DataTable tabla = new DataTable("Datos");
            String[] valores = fila.Split(new char[] { ';' });
            cantidadColumnas = valores.Length;
            int idx = 0;
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
            }
            return tabla;
        }

        private DataRow AgregarFila(String fila, DataTable tabla)
        {
            int cantidadColumnas = 100;
            String[] valores = fila.Split(new char[] { ';' });
            Int32 numeroTotalValores = valores.Length;
            if (numeroTotalValores > cantidadColumnas)
            {
                Int32 diferencia = numeroTotalValores - cantidadColumnas;
                for (Int32 i = 0; i < diferencia; i++)
                {

                    String nombreColumna = String.Format("{0}", (cantidadColumnas + i));
                    tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
                }
                cantidadColumnas = numeroTotalValores;
            }
            int idx = 0;
            DataRow dfila = tabla.NewRow();
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                dfila[nombreColumna] = val.Trim();
            }
            tabla.Rows.Add(dfila);
            return dfila;
        }
        private void CargarDatos(string strm)
        {
            DataTable tabla = null;
            StreamReader lector = new StreamReader(strm);
            String fila = String.Empty;
            Int32 cantidad = 0;
            do
            {
                fila = lector.ReadLine();
                if (fila == null)
                {
                    break;
                }
                if (0 == cantidad++)
                {
                    tabla = this.CrearTabla(fila);
                }
                this.AgregarFila(fila, tabla);
            } while (true);

            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void btncargardatos_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (ChecarExtension(FileUpload1.FileName))
                {
                    FileUpload1.SaveAs(MapPath("Archivos/" + FileUpload1.FileName));


                    Label1.Text = FileUpload1.FileName + " cargado exitosamente";

                    lblOculto.Text = MapPath("Archivos/" + FileUpload1.FileName);
                }
            }
            else
            {
                Label1.Text = "Error al subir el archivo o no es el tipo .CSV";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                CargarDatos(lblOculto.Text);
            }
            catch
            {
                Response.Write("Ocurrio un error debe cargar antes el archivo");
            }
        }
    }
}