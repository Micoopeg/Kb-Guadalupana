using KBGuada.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using KBGuada.Models;

namespace KBGuada.Views.session
{
    public partial class Av_Reasignar : System.Web.UI.Page
    {
        ControladorAV cav = new ControladorAV();
        ModeloAV mav = new ModeloAV();
        string tarea;
        string Nombreuser, user, titulo;
        char delimitador = ' ';
        char delimitador2 = ':';
        string concat = "T";
        string codigotarea, codagenda, titulotarea, nombre, apellido, telefono, fechain, fechafin, fechaifor, fechaffor, descrip, estado, prioridad, tipo, asociad, acceso     ;
        protected void Page_Load(object sender, EventArgs e)
        {


            string numerotarea = Convert.ToString(Session["NoTarea"]);
            tarea = numerotarea;
            Nombreuser = Convert.ToString(Session["sesion_usuario"]);
            user = Convert.ToString(Session["Nombre"]);
            titulo = Convert.ToString(Session["TituloTarea"]);
            NombreUsuario.InnerText = user;
            AVTITULO.Value = titulo;

            DataSet ds1 = cav.consultarasigtarea(tarea);
            repetidoruser.DataSource = ds1;
            repetidoruser.DataBind();
        }


        public void reasginacion() {


            if (NOMUSER.Value != "" && CIF.Value != "") {
                //consultar si nombre de usaurio existe
                string codusuario = cav.obtenercoduser(NOMUSER.Value);
                if (codusuario != "")
                {
                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {

                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }
                    //un update o un insert
                    string asignado = cav.consultartareauserexistente(codusuario,tarea);

                    if (asignado == tarea)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Esta tarea ya fue asignada a este usuario')", true);



                    }
                    else if (asignado == "")
                    {

                        string cif = cav.obtenercif(codusuario);

                        string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                        cav.insertartarea(cadena);


                        //obtener los datos de la tarea



                        string[] datostarea = mav.consultadatostarea(tarea);
                        for (int i = 0; i < datostarea.Length; i++)
                        {
                            titulo = AVTITULO.Value;
                            nombre = Convert.ToString(datostarea.GetValue(3));
                            apellido = Convert.ToString(datostarea.GetValue(4));
                            telefono = Convert.ToString(datostarea.GetValue(5));
                            string monto = Convert.ToString(datostarea.GetValue(6));
                            fechain = Convert.ToString(datostarea.GetValue(7));
                            fechafin = Convert.ToString(datostarea.GetValue(8));
                            descrip = Convert.ToString(datostarea.GetValue(11));
                            estado = Convert.ToString(datostarea.GetValue(12));
                            prioridad = Convert.ToString(datostarea.GetValue(13));
                            tipo = Convert.ToString(datostarea.GetValue(14));
                            asociad = Convert.ToString(datostarea.GetValue(15));
                            acceso = Convert.ToString(datostarea.GetValue(16));
                            string[] fechasep = fechain.Split(delimitador);

                            string[] horesep = fechasep[3].Split(delimitador2);
                            string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];


                            string[] fechasep2 = fechafin.Split(delimitador);
                            string[] horesep2 = fechasep2[3].Split(delimitador2);

                            string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];



                            string agenda = cav.consultaragenda(codusuario);
                            string sig = cav.siguiente("av_tarea", "codavtarea");
                            string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                            cav.insertartarea(sql);






                            limpiar();
                            Response.Redirect("Av_Reasignar.aspx");
                        }

                    }
                    else if (asignado != tarea)
                    {

                        string cif = cav.obtenercif(codusuario);

                        string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                        cav.insertartarea(cadena);


                        //obtener los datos de la tarea

                        string[] datostarea = mav.consultadatostarea(tarea);

                        titulo = AVTITULO.Value;

                        for (int i = 0; i < datostarea.Length; i++)
                        {
                            nombre = Convert.ToString(datostarea.GetValue(3));
                            apellido = Convert.ToString(datostarea.GetValue(4));
                            telefono = Convert.ToString(datostarea.GetValue(5));
                            string monto = Convert.ToString(datostarea.GetValue(6));
                            fechain = Convert.ToString(datostarea.GetValue(7));
                            fechafin = Convert.ToString(datostarea.GetValue(8));
                            descrip = Convert.ToString(datostarea.GetValue(11));
                            estado = Convert.ToString(datostarea.GetValue(12));
                            prioridad = Convert.ToString(datostarea.GetValue(13));
                            tipo = Convert.ToString(datostarea.GetValue(14));
                            asociad = Convert.ToString(datostarea.GetValue(15));
                            acceso = Convert.ToString(datostarea.GetValue(16));
                            string[] fechasep = fechain.Split(delimitador);

                            string[] horesep = fechasep[3].Split(delimitador2);
                            string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];

                            string[] fechasep2 = fechafin.Split(delimitador);
                            string[] horesep2 = fechasep2[3].Split(delimitador2);

                            string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];

                            string agenda = cav.consultaragenda(codusuario);
                            string sig = cav.siguiente("av_tarea", "codavtarea");
                            string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                            cav.insertartarea(sql);






                            limpiar();
                            Response.Redirect("Av_Reasignar.aspx");


                        }






                    }




                }


                //si existe reasignar tarea a ese usuario



                else
                {
                    string usher = NOMUSER.Value;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " + usher + " no existe ')", true);
                }
            }

                if (NOMUSER.Value != "" && CIF.Value == "") {



                //consultar si nombre de usaurio existe
                string codusuario = cav.obtenercoduser(NOMUSER.Value);
                if (codusuario != "")
                {
                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {
                   
                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }
                    //un update o un insert
                    string asignado = cav.consultartareauserexistente(codusuario, tarea);

                    if (asignado != "" )
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Esta tarea ya fue asignada a este usuario')", true);



                    }
                    else if (asignado == "") {

                        string cif = cav.obtenercif(codusuario);

                        string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                        cav.insertartarea(cadena);


                        //obtener los datos de la tarea


                     
                        string[] datostarea = mav.consultadatostarea(tarea);
                        for (int i = 0; i < datostarea.Length; i++)
                        {
                            titulo = AVTITULO.Value;
                            nombre = Convert.ToString(datostarea.GetValue(3));
                            apellido = Convert.ToString(datostarea.GetValue(4));
                            telefono = Convert.ToString(datostarea.GetValue(5));
                            string monto = Convert.ToString(datostarea.GetValue(6));
                            fechain = Convert.ToString(datostarea.GetValue(7));
                            fechafin = Convert.ToString(datostarea.GetValue(8));
                            descrip = Convert.ToString(datostarea.GetValue(11));
                            estado = Convert.ToString(datostarea.GetValue(12));
                            prioridad = Convert.ToString(datostarea.GetValue(13));
                            tipo = Convert.ToString(datostarea.GetValue(14));
                            asociad = Convert.ToString(datostarea.GetValue(15));
                            acceso = Convert.ToString(datostarea.GetValue(16));
                            string[] fechasep = fechain.Split(delimitador);

                            string[] horesep = fechasep[3].Split(delimitador2);
                            string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];


                            string[] fechasep2 = fechafin.Split(delimitador);
                            string[] horesep2 = fechasep2[3].Split(delimitador2);

                            string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];



                            string agenda = cav.consultaragenda(codusuario);
                            string sig = cav.siguiente("av_tarea", "codavtarea");
                            string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                            cav.insertartarea(sql);






                            limpiar();
                            Response.Redirect("Av_Reasignar.aspx");
                        }

                    }
                    //else if (asignado == "") {

                    //    string cif = cav.obtenercif(codusuario);

                    //    string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                    //    cav.insertartarea(cadena);


                    //    //obtener los datos de la tarea

                    //    string[] datostarea = mav.consultadatostarea(tarea);

                    //    titulo = AVTITULO.Value;

                    //    for (int i = 0; i < datostarea.Length; i++)
                    //    {
                    //        nombre = Convert.ToString(datostarea.GetValue(3));
                    //    apellido = Convert.ToString(datostarea.GetValue(4));
                    //    telefono = Convert.ToString(datostarea.GetValue(5));
                    //string monto = Convert.ToString(datostarea.GetValue(6));
                    //        fechain = Convert.ToString(datostarea.GetValue(7));
                    //    fechafin = Convert.ToString(datostarea.GetValue(8));
                    //    descrip = Convert.ToString(datostarea.GetValue(11));
                    //    estado = Convert.ToString(datostarea.GetValue(12));
                    //    prioridad = Convert.ToString(datostarea.GetValue(13));
                    //    tipo = Convert.ToString(datostarea.GetValue(14));
                    //    asociad = Convert.ToString(datostarea.GetValue(15));
                    //    acceso = Convert.ToString(datostarea.GetValue(16));
                    //        string[] fechasep = fechain.Split(delimitador);

                    //        string[] horesep = fechasep[3].Split(delimitador2);
                    //        string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];

                    //        string[] fechasep2 = fechafin.Split(delimitador);
                    //        string[] horesep2 = fechasep2[3].Split(delimitador2);

                    //        string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];

                    //        string agenda = cav.consultaragenda(codusuario);
                    //        string sig = cav.siguiente("av_tarea", "codavtarea");
                    //        string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                    //        cav.insertartarea(sql);






                    //        limpiar();
                    //        Response.Redirect("Av_Reasignar.aspx");


                    //    }

                    




                    //}




                }


                //si existe reasignar tarea a ese usuario



                else
                {
                    string usher = NOMUSER.Value;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " +usher+ " no existe ')", true);
                }
            }      

            else if (NOMUSER.Value == "" && CIF.Value != "") {


                //consultar si nombre de usaurio existe por cif
                string codusuario = cav.buscarusercif(CIF.Value);
                if (codusuario != "")
                {
                    string agendae = cav.consultaragenda(codusuario);
                    if (agendae == "")
                    {

                        string sig2 = cav.siguiente("av_agenda", "codavagenda");
                        string sql3 = "INSERT INTO av_agenda VALUES ( '" + sig2 + "', '" + codusuario + "');";
                        cav.insertartarea(sql3);
                    }
                    //un update o un insert
                    string asignado = cav.consultartareauserexistente(codusuario,tarea);

                    if (asignado != "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Esta tarea ya fue asignada a este usuario')", true);



                    }
                    else if (asignado == "")
                    {

                        string cif = cav.obtenercif(codusuario);
                        //insertar en tabla de asignados
                        string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                        cav.insertartarea(cadena);



                        //obtener los datos de la tarea

                        string[] datostarea = mav.consultadatostarea(tarea);
                        for (int i = 0; i < datostarea.Length; i++)
                        {
                            titulo = AVTITULO.Value;
                            nombre = Convert.ToString(datostarea.GetValue(3));
                            apellido = Convert.ToString(datostarea.GetValue(4));
                            telefono = Convert.ToString(datostarea.GetValue(5));
                            string monto = Convert.ToString(datostarea.GetValue(6));
                            fechain = Convert.ToString(datostarea.GetValue(7));
                            fechafin = Convert.ToString(datostarea.GetValue(8));
                            descrip = Convert.ToString(datostarea.GetValue(11));
                            estado = Convert.ToString(datostarea.GetValue(12));
                            prioridad = Convert.ToString(datostarea.GetValue(13));
                            tipo = Convert.ToString(datostarea.GetValue(14));
                            asociad = Convert.ToString(datostarea.GetValue(15));
                            acceso = Convert.ToString(datostarea.GetValue(16));
                            string[] fechasep = fechain.Split(delimitador);

                            string[] horesep = fechasep[3].Split(delimitador2);
                            string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];


                            string[] fechasep2 = fechafin.Split(delimitador);
                            string[] horesep2 = fechasep2[3].Split(delimitador2);

                            string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];



                            string agenda = cav.consultaragenda(codusuario);
                            string sig = cav.siguiente("av_tarea", "codavtarea");
                            string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                            cav.insertartarea(sql);

                            limpiar();
                            Response.Redirect("Av_Reasignar.aspx");

                            //insertar tarea en agenda de asignado

                        }




                    }

                    //else if (asignado != tarea)
                    //{
                    //    string cif = cav.obtenercif(codusuario);
                    //    //insertar en tabla de asignados
                    //    string cadena = "INSERT INTO av_controlasignado VALUES ( '" + codusuario + "', '" + tarea + "','" + cif + "' );";
                    //    cav.insertartarea(cadena);



                    //    //obtener los datos de la tarea

                    //   string[] datostarea = mav.consultadatostarea(tarea);
                    //    for (int i = 0; i < datostarea.Length; i++)
                    //    {
                    //        titulo = AVTITULO.Value;
                    //        nombre = Convert.ToString(datostarea.GetValue(3));
                    //        apellido = Convert.ToString(datostarea.GetValue(4));
                    //        telefono = Convert.ToString(datostarea.GetValue(5));
                    //        string monto = Convert.ToString(datostarea.GetValue(6));
                    //        fechain = Convert.ToString(datostarea.GetValue(7));
                    //        fechafin = Convert.ToString(datostarea.GetValue(8));
                    //        descrip = Convert.ToString(datostarea.GetValue(11));
                    //        estado = Convert.ToString(datostarea.GetValue(12));
                    //        prioridad = Convert.ToString(datostarea.GetValue(13));
                    //        tipo = Convert.ToString(datostarea.GetValue(14));
                    //        asociad = Convert.ToString(datostarea.GetValue(15));
                    //        acceso = Convert.ToString(datostarea.GetValue(16));

                    //        string[] fechasep = fechain.Split(delimitador);

                    //        string[] horesep = fechasep[3].Split(delimitador2);
                    //        string fechainitotal = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horesep[0] + ":" + horesep[1];


                    //        string[] fechasep2 = fechafin.Split(delimitador);
                    //        string[] horesep2 = fechasep2[3].Split(delimitador2);

                    //        string fechafintotal = fechasep2[0] + "-" + fechasep2[1] + "-" + fechasep2[2] + concat + horesep2[0] + ":" + horesep2[1];


                    //        string agenda = cav.consultaragenda(codusuario);
                    //        string sig = cav.siguiente("av_tarea", "codavtarea");
                    //        string sql = "SET lc_time_names = 'es_ES'; INSERT INTO `av_tarea`(`codavtarea` , `codavagenda`, `av_titulo`, `av_pnombre`, `av_papellido`, `av_telefono`, `av_fechaini`, `av_fechafin`,`fechaini`, `fechafin`, `av_descripcion`, `cod_estado`, `codprioridad`, `codtipotarea`, `codasociado`,`codavpertarea`) VALUES ('" + sig + "', '" + agenda + "' ,'" + titulo + "','" + nombre + "','" + apellido + "','" + telefono + "','" + fechainitotal + "','" + fechafintotal + "', DATE_FORMAT('" + fechainitotal + "', '%d %b %Y'),  DATE_FORMAT('" + fechafintotal + "', '%d %b %Y') , '" + descrip + "', '" + estado + "' , '" + prioridad + "' ,'" + tipo + "',1, '" + acceso + "' ); ";

                    //        cav.insertartarea(sql);

                    //        limpiar();
                    //        Response.Redirect("Av_Reasignar.aspx");


                    //    }
                    //}


                }


                //si existe reasignar tarea a ese usuario



                else
                {
                    string usher = NOMUSER.Value;

                    //sino existe entonces lanzar mensaje
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' El suario " + usher + " no existe ')", true);
                }







            }
                 
            
            
            
        
        
        
        
        }

        public void limpiar() {

            NOMUSER.Value = "";
            CIF.Value = "";
        
        }
        protected void btnreasignar_Click(object sender, EventArgs e)
        {

            if (NOMUSER.Value == "" && CIF.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Debe llenar el campo CIF o el nombre de usuario que incia con PG ')", true);
            }
            else { reasginacion(); }

            
            
            



        }
    }
}