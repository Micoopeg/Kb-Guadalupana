using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;


namespace Login_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
            string nombre;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void iniciarsesion_Click(object sender, EventArgs e)
        {
           if (AuthenticateUser(IdUser.Value, PSUser.Value))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Si Se Autentifica el Usuario');", true);
                 Session["sesion_usuario"] = IdUser.Value;
                 Session["Nombre"] = nombre;
                 Response.Redirect("Inicio.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('No se puede autenticar con las credenciales proporcionadas');", true);
            }
        }

        private bool AuthenticateUser(string userName, string password)
        {
            bool ret = false;
            try
            {
                SearchResultCollection results;
                DirectorySearcher dsearch = null;
                DirectoryEntry de = new DirectoryEntry("LDAP://micoope.local", userName, password);

                dsearch = new DirectorySearcher(de);
                dsearch.PropertiesToLoad.Add("name");
                dsearch.PropertiesToLoad.Add("sn");
                dsearch.Filter = "(&(objectCategory=User)(samaccountname="+userName+"))";
              //  dsearch.Filter = "(&(objectClass=user)(|(sn=Smith)(givenName=John)))";
                results = dsearch.FindAll();

                foreach (SearchResult sr in results)
                {
                    if ((sr.Properties["name"].Count > 0))
                        {
                              nombre = (sr.Properties["name"][0].ToString());
                            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('"+ (sr.Properties["givenname"][0].ToString()) +"');", true);
                        }
                    if ((sr.Properties["sn"].Count > 0))
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('"+ (sr.Properties["sn"][0].ToString()) +"');", true);
                        }
                    ret = true;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        private static string GetProperty(SearchResult searchResult,string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}