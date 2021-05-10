using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM_Guadalupana.Controllers
{
    public class CRM_Sentencias
    {
    
        CRM_Conexion cn = new CRM_Conexion();
    MySqlCommand comm;
        public void insertartablas(string tabla, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string query = "";
                for (int i = 0; i < datos.Length; i++)
                {
                    query += "'";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                }
                try
                {
                    sqlCon.Open();
                    string consulta = "insert into " + tabla + " values(" + query + ");";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
            }
        }

        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(" + campo + "+1) FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                    //Console.WriteLine("El resultado es: " + camporesultante);
                    if (String.IsNullOrEmpty(camporesultante))
                        camporesultante = "1";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }
        }


        public void eliminadoderegistrosprotegida(string tabla)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
              
                try
                {
                    sqlCon.Open();
                    string consulta = "DELETE FROM " + tabla + ";";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
            }
        }

        public string[] fechaactual()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT CURDATE();", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos               
            }

        }

        public string[] consultarparateleventas()//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3 AND crmcontrol_ingresosucursal ='telemercadeo';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultarparasucursal()//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3 AND crmcontrol_ingresosucursal !='telemercadeo';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string query = "";
                int n = 1;
                query += " set ";
                for (int i = 1; i < datos.Length; i++)
                {
                    query += campos[n];
                    query += " = '";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                    n++;
                }

                try
                {
                    sqlCon.Open();
                    string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "';";
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        public string[] consultardpiexistente()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT crminfogeneral_prospectodpi FROM crminfogeneral_prospecto;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultartabla(string tabla)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + tabla +"", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultarconcampo(string tabla, string campo, string dato)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + tabla + " where " + campo + "='" + dato + "'", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public DataSet consultarAc(string controlingreso,string fecha)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM crmalertas_programadas where codcrmcontrolingreso='"+controlingreso+"' AND crmalertas_programadasfechafin='"+fecha+"';", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;
            }

        }

        public DataTable reportetable(string fechainicio,string fechafin,string tiposervicio, string estadosemaforo, string descripcionestado, string tipodomicilio, string finalidadservicio, 
            string ingreso, string monto, string trabajoactual, string cuentaigss, string cuentacoope, string añodomicilio, string tipocontacto,string comboagencia, string combousuario)
        {

            DataTable dt = new DataTable();

            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT c.crminfogeneral_prospectodpi,c.crminfogeneral_prospectonombrecompleto," +
                        "b.crminfo_prospectotelefono,b.crminfo_prospectoemail,b.crminfo_prospectoingresos,b.crminfo_prospectoegresos," +
                        "b.crminfo_prospectomonto,b.crminfo_prospectoañoslaborados,b.crminfo_prospectodescripciontrabajoactual," +
                        "b.crminfo_prospectofechaprimerllamada,b.crminfo_prospectofechaultimallamada,b.crminfo_prospectoañosdomicilio," +
                        "b.crminfo_contactadopor,b.crminfo_prospectoreferenciado,d.crmtipo_servicionombre,e.crmcontacto_llamadasnombre," +
                        "f.crmsemaforo_estadodescripcion,g.crmestado_descripcionnombre,h.crm_finalidaddescripcion,i.crmtipo_domicilionombre," +
                        "j.crmcontrol_ingresosucursal,j.crmcontrol_ingresousuario " +
                        "FROM crmcontrol_prospecto_agente a " +
                        "INNER JOIN crminfo_prospecto  b " +
                        "INNER JOIN crminfogeneral_prospecto c " +
                        "INNER JOIN crmtipo_servicio d " +
                        "INNER JOIN crmcontacto_llamadas e " +
                        "INNER JOIN crmsemaforo_estado f " +
                        "INNER JOIN crmestado_descripcion g " +
                        "INNER JOIN crm_finalidadservicio h " +
                        "INNER JOIN crmtipo_domicilio i  " +
                        "INNER JOIN crmcontrol_ingreso j " +
                        "ON a.codcrmcontrolingreso=j.codcrmcontrolingreso " +
                        "AND a.codcrminfoprospecto=b.codcrminfoprospecto " +
                        "AND b.codcrminfogeneralprospecto=c.codcrminfogeneralprospecto " +
                        "AND b.codcrmtiposervicio=d.codcrmtiposervicio " +
                        "AND b.codcrmcontactollamadas=e.codcrmcontactollamadas " +
                        "AND b.codcrmsemaforoestado=f.codcrmsemaforoestado " +
                        "AND b.codcrmestadodescripcion=g.codcrmestadodescripcion " +
                        "AND b.codcrmtipodomicilio=i.codcrmtipodomicilio " +
                        "AND b.codcrmfinalidadservicio=h.codcrmfinalidadservicio " +
                        "WHERE ((a.fechaasignado >= '"+fechainicio+ "'AND a.fechaasignado <= '" + fechafin + "')) " +
                        "AND b.codcrmtiposervicio  LIKE '" + tiposervicio + "%' " +
                        "AND b.codcrmsemaforoestado  LIKE '" + estadosemaforo + "%' " +
                        "AND b.codcrmestadodescripcion  LIKE '" + descripcionestado + "%'  " +
                        "AND b.codcrmtipodomicilio  LIKE '" + tipodomicilio + "%' " +
                        "AND b.codcrmfinalidadservicio  LIKE '" + finalidadservicio + "%' " +
                        "AND b.crminfo_prospectoingresos  LIKE '%" + ingreso + "%' " +
                        "AND b.crminfo_prospectomonto  LIKE '%" + monto + "%' " +
                        "AND b.crminfo_prospectotrabajaactualmente  LIKE '" + trabajoactual + "%' " +
                        "AND b.crminfo_prospectocuentaconigss  LIKE '" + cuentaigss + "%' " +
                        "AND b.crminfo_prospectocuentaencooperativa  LIKE '" + cuentacoope + "%' " +
                        "AND b.crminfo_prospectoañosdomicilio  LIKE '" + añodomicilio + "%' " +
                        "AND b.crminfo_contactadopor  LIKE '%" + tipocontacto + "%' " +
                        "AND j.crmcontrol_ingresosucursal  LIKE '%" + comboagencia + "%' " +
                        "AND j.crmcontrol_ingresousuario  LIKE '%" + combousuario + "%'", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);



                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }

        public string[] datetime()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT NOW();", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos               
            }

        }

        public string[] consultaparasimultaneasucursal(string sucursal)//metodo que obtiene las lista de todos los empleados de una sucursal
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3  AND crmcontrol_ingresosucursal='"+sucursal+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultaparasimultaneasucursalytelemercadeo(string sucursal)//metodo que obtiene las lista de todos los empleados de una sucursal y telemecadeo
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("Select codcrmcontrolingreso,crmcontrol_ingresosucursal,crmcontrol_ingresousuario FROM crmcontrol_ingreso where crmcontrol_ingresorol=3 AND crmcontrol_ingresosucursal='"+sucursal+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultaporsucursal(string sucursal)//metodo que obtiene las lista de todos los empleados de una sucursal y telemecadeo
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT a.codcrmcontrolingreso,a.codcrmcontrolprospectoagente FROM crmcontrol_prospecto_agente a INNER JOIN crmcontrol_ingreso b ON a.codcrmcontrolingreso=b.codcrmcontrolingreso where b.crmcontrol_ingresosucursal='"+sucursal+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public void modificarregistrodeagente(string fuente, string destino)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            { 

                try
                {
                    sqlCon.Open();
                    string consulta = "UPDATE crmcontrol_prospecto_agente a " +
                        "INNER JOIN crminfo_prospecto b  " +
                        "ON a.codcrminfoprospecto = b.codcrminfoprospecto" +
                        " SET a.codcrmcontrolingreso = '"+destino+"' " +
                        "WHERE a.codcrmcontrolingreso='"+fuente+ "' AND b.codcrmsemaforoestado!=1;";
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        public string[] consultarcontrolingreso(string usuario)//metodo que obtiene el id del suuario
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT codcrmcontrolingreso FROM crmcontrol_ingreso where crmcontrol_ingresousuario='"+usuario+"';", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultadeaprobados() //nos muestra prospectos aprobados
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT count(codcrmsemaforoestado) FROM crminfo_prospecto where codcrmsemaforoestado = 1;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultaenprocesos() //nos muestra prospectos aprobados
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT count(codcrmsemaforoestado) FROM crminfo_prospecto where codcrmsemaforoestado=2;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultanocontesta() //nos muestra prospectos aprobados
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT count(codcrmsemaforoestado) FROM crminfo_prospecto where codcrmsemaforoestado=3;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultanoaplica() //nos muestra prospectos aprobados
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT count(codcrmsemaforoestado) FROM crminfo_prospecto where codcrmsemaforoestado=4;", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public DataSet consultarsubestadosproceso()
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT b.crmestado_descripcionnombre, COUNT(a.codcrmestadodescripcion) as totalestado FROM crminfo_prospecto a INNER JOIN crmestado_descripcion b ON a.codcrmestadodescripcion=b.codcrmestadodescripcion WHERE a.codcrmsemaforoestado=2 GROUP BY a.codcrmestadodescripcion;", sqlCon);
                    MySqlDataAdapter ds = new MySqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(ds1);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return ds1;
            }

        }

        public string[] consultarconcampoingresocrm(string tabla, string campo, string dato)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + tabla + " where " + campo + "='" + dato + "'", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();                
                        if (reader.Read())
                        {                       
                            for (int p = 0; p < reader.FieldCount; p++)
                            {
                                miLista.Add(reader.GetString(p));
                                i++;
                            }
                    }
                    else
                    {
                        miLista.Add("0");
                        Campos = miLista.ToArray();
                        return Campos;// devuelve un arrgeglo con los campos   
                    }


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public void despidocrm(string variabledeeliminacion)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {

                try
                {
                    sqlCon.Open();
                    string consulta = "DELETE FROM crmcontrol_ingreso where codcrmcontrolingreso='" + variabledeeliminacion + "';";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
            }
        }
        public void trasladodeleadspordespido(string fuente, string destino)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(cn.cadenadeconexion()))
            {

                try
                {
                    sqlCon.Open();
                    string consulta = "UPDATE crmcontrol_prospecto_agente SET codcrmcontrolingreso ='" + destino + "'  WHERE codcrmcontrolingreso='" + fuente + "';";
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
    }
}
       
