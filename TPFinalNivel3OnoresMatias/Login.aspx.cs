using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio;
        string _mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IniciarSesionPrueba(1) != null)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                _mensaje = "Ocurrió un error al intentar iniciar sesión como admin: ";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + _mensaje + ex.Message + "');", true);
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (IniciarSesionPrueba(2) != null)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                _mensaje = "Ocurrió un error al intentar iniciar sesión como usuario: ";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + _mensaje + ex.Message + "');", true);
            }
        }

        private Usuario IniciarSesionPrueba(int user)
        {
            Usuario prueba = null;
            try
            {
                usuarioNegocio = new UsuarioNegocio();

                string username = user == 1 ? "admin@admin.com" : "user@user.com";
                string passwrod = user == 1 ? "admin" : "user";

                prueba = usuarioNegocio.ObtenerUsuario(username, passwrod);
                
                if (prueba != null)
                {
                    Session.Add("User", prueba);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prueba;

        }
    }
}