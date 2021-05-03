using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KBGuada.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace KBGuada.Controllers
{
    public class ControladorAV
    {
       ModeloAV mav   = new ModeloAV ();

        public DataSet consultarAc(string numero)
        {
            return mav.consultarAc(numero);
        }
        public DataSet consultarAcReal(string numero)
        {
            return mav.consultarAcReal(numero);
        }
        public DataTable reportetable(string  coduser, string area)
        {
            return mav.reportetable(coduser, area);
        }
        public DataTable reportemontosresultante(string fecha1, string fecha2)
        {
            return mav.reportemontosresultante(fecha1, fecha2);
        }
        public DataTable reportetableunososlo(string coduser, string fecha1, string fecha2)
        {
            return mav.reportetableunosolo(coduser, fecha1, fecha2);
        }
        public DataTable reportemontos( string fecha1, string fecha2)
        {
            return mav.reportemontos( fecha1, fecha2);
        }
        public DataTable reportemontosdatos(string fecha1, string fecha2)
        {
            return mav.reportemontosdatos(fecha1, fecha2);
        }

        public DataTable reportemontostotal(string fecha1, string fecha2)
        {
            return mav.reportemontostotal(fecha1, fecha2);
        }


        public DataTable reportetabletodos(string area)
        {
            return mav.reportetabletodos(area);

        }
            public DataSet consultar(string usertarea)
        {
            return mav.consultar(usertarea);
        }
        //public MySqlDataReader estadopermisotarea(string tarea)
        //{
        //    return mav.estadopermisotarea(tarea);

        //}
       
        //public MySqlDataReader permisotarea(string tarea)
        //{
        //    return mav.permisotarea(tarea);
        //}
        //busquedas
        public DataSet porcif(string cif, string area)
        {
            return mav.porcif(cif, area);
        }
        public DataSet porfecha(string fecha1, string fecha2, string area)
        {
            return mav.porFecha(fecha1, fecha2, area);
        }
        public DataSet consultarasigtarea(string tarea)
        {
            return mav.consultarasigtarea(tarea);


        }
        public DataSet porcifFecha(string cif, string fecha1, string fecha2)
        {
            return mav.porcifFecha(cif,fecha1, fecha2);
        }
        public DataSet porcifEstado(string cif, string estado)
        {
            return mav.porcifEstado(cif, estado);
        }
        public DataSet porcifFechaEstado(string cif, string fecha1, string fecha2, string estado)
        {
            return mav.porcifFechaEstado(cif, fecha1, fecha2, estado);
        }
        public DataSet porareaFecha(string area, string fecha1, string fecha2)
        {
            return mav.porareaFecha(area, fecha1, fecha2);
        }
        public string consultarRol(string usuario)
        {
            string rol = mav.consultarRol(usuario);
            return rol;
        }

        public string consultarArea(string usuario)
        {
            string area = mav.consultarArea(usuario);
            return area;
        }

        public DataSet porarea(string area)
        {
            return mav.porarea(area);
        }
        public DataSet porareaEstado(string area, string estado)
        {
            return mav.porareaEstado(area, estado);
        }
        public DataSet porareafechaEstado(string area, string fecha1, string fecha2, string estado)
        {
            return mav.porareafechaEstado(area, fecha1, fecha2, estado);
        }
        public DataSet porfechaEstado(string fecha1, string fecha2, string estado, string user)
        {
            return mav.porfechaEstado(fecha1, fecha2, estado, user);
        }

        public DataSet porestadousuario(string estado, string usuario)
        {
            return mav.porestadousuairo(estado, usuario);
        }
        public DataSet porestadoadmin(string estado, string area )
        {
            return mav.porestadoadmin(estado, area);
        }
        ///------------------------fin busqueda
        //public MySqlDataReader datetime() 
        //{
        //    return mav.datetime();
        //}
        public string areauser(string usuario)
        {
            string area = mav.areauser(usuario);
            return area;


        }
        public string tipotarea(string tarea)
        {
            string tipotarea = mav.tipotarea(tarea);
            return tipotarea;

        }
            public string buscarusercif(string cif) {
            string asigcif = mav.buscarusercif(cif);
            return asigcif;


        }
        public string obtenerconteo(string tarea)
        {
            string cantidad = mav.obtenerconteo(tarea);
            return cantidad;


        }
            public string consultartareauserexistente(string user, string codtar)
        {
            string asign = mav.consultartareauserexistente(user, codtar);
            return asign;
        }
            public string siguiente(string tabla, string campo)
        {
            string llave = mav.obtenerfinal(tabla, campo);
            return llave;
        }
        public string obtenercoduser(string nomuser)
        {
            string nomusr = mav.obtenercoduser(nomuser);
            return nomusr;
        }
        public string obtenercif(string coduser)
        {
            string cif = mav.obtenercif(coduser);
            return cif;
        }
        public string consultaragenda(string coduser) {

            string coduseagenda = mav.consultaragenda(coduser);
            return coduseagenda;
        }
        public DataSet consultarapps(string id)
        {
            return mav.consultarapps(id);
        }
        public string url(string app)
        {
            string app1 = mav.url(app);
            return app1;

        }
        public void Insertar(string sql)
        {

            mav.Insertar(sql);

        }

      
     

        public void insertartarea(string sql) {

            mav.insertartarea(sql);        
        
        }
    }
}