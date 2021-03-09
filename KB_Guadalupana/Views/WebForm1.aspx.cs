using KB_Guadalupana.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Conexion conn = new Conexion();
            try
            {
             
               //     using (System.Data.SqlClient.Mysqlcommand command = conn.CreateCommand())
               //     {
               //         conn.conectar();
               //     // Create the sample database
               //     string consulta = "SELECT a.ep_informaciongeneralcif,a.ep_informaciongeneralpuesto,b.gen_sucursalnombre,h.gen_areanombre,ep_informaciongeneralprimerapellido,ep_informaciongeneralsegundoapellido,ep_informaciongeneralprimernombre,ep_informaciongeneralsegundonombre,ep_informaciongeneralnombreadicional,e.gen_departamentonombre,f.gen_municipionombre,g.gen_zonanombre,a.ep_informaciongeneraldireccion,d.gen_tipoidentificacionnombre,ep_informaciongeneralnumeroidentificacion,a.ep_informaciongeneralfechanacimiento,a.ep_informaciongeneralnit,a.ep_informaciongeneralnacionalidad,a.ep_informaciongeneralcelular,a.ep_informaciongeneraltelefonocasa,a.ep_informaciongeneralcorreo,a.ep_informaciongeneralestatura,a.ep_informaciongeneralpeso,a.ep_informaciongeneralreligion,c.ep_estadocivilnombre " +
               //"FROM ep_informaciongeneral a " +
               //"INNER JOIN gen_sucursal b " +
               //"INNER JOIN ep_estadocivil c " +
               //"INNER JOIN gen_tipoidentificacion d " +
               //"INNER JOIN gen_departamento e " +
               //"INNER JOIN gen_municipio f " +
               //"INNER JOIN gen_zona g " +
               //"INNER JOIN gen_area h " +
               //"ON b.codgensucursal='1' " +
               //"AND c.codepestadocivil='1' " +
               //"AND d.codgentipoidentificacion='1'" +
               //"AND e.codgendepartamento='1'" +
               //" AND f.codgenmunicipio='1'" +
               //"AND g.codgenzona='1'" +
               //"AND h.codgenarea='1'" +
               //"WHERE codepinformaciongeneralcif='1';";
               //     command.CommandText = consulta;
               //         command.CommandType = System.Data.CommandType.Text;
               //         this.GridView1.DataSource = command.ExecuteReader();
               //         this.GridView1.DataBind();
                        
               //     }

                string QueryString = "SELECT a.ep_informaciongeneralcif,a.ep_informaciongeneralpuesto,b.gen_sucursalnombre,h.gen_areanombre,ep_informaciongeneralprimerapellido,ep_informaciongeneralsegundoapellido,ep_informaciongeneralprimernombre,ep_informaciongeneralsegundonombre,ep_informaciongeneralnombreadicional,e.gen_departamentonombre,f.gen_municipionombre,g.gen_zonanombre,a.ep_informaciongeneraldireccion,d.gen_tipoidentificacionnombre,ep_informaciongeneralnumeroidentificacion,a.ep_informaciongeneralfechanacimiento,a.ep_informaciongeneralnit,a.ep_informaciongeneralnacionalidad,a.ep_informaciongeneralcelular,a.ep_informaciongeneraltelefonocasa,a.ep_informaciongeneralcorreo,a.ep_informaciongeneralestatura,a.ep_informaciongeneralpeso,a.ep_informaciongeneralreligion,c.ep_estadocivilnombre " +
                "FROM ep_informaciongeneral a " +
                "INNER JOIN gen_sucursal b " +
                "INNER JOIN ep_estadocivil c " +
                "INNER JOIN gen_tipoidentificacion d " +
                "INNER JOIN gen_departamento e " +
                "INNER JOIN gen_municipio f " +
                "INNER JOIN gen_zona g " +
                "INNER JOIN gen_area h " +
                "ON b.codgensucursal='1' " +
                "AND c.codepestadocivil='1' " +
                "AND d.codgentipoidentificacion='1'" +
                "AND e.codgendepartamento='1'" +
                " AND f.codgenmunicipio='1'" +
                "AND g.codgenzona='1'" +
                "AND h.codgenarea='1'" +
                "WHERE codepinformaciongeneralcif=codepinformaciongeneralcif;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataSet ds3 = new DataSet();
                myCommand.Fill(ds3, "tipomoneda");
                GridView1.DataSource = ds3;
         
                GridView1.DataBind();
          




            }
            catch
            {
            }
        }
    }
}