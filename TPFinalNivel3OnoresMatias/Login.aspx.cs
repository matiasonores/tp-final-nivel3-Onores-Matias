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
        public string mensaje;
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
                mensaje = "Ocurrió un error al intentar iniciar sesión como admin: ";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + _mensaje + ex.Message + "');", true);
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
                mensaje = "Ocurrió un error al intentar iniciar sesión como usuario: ";
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + _mensaje + ex.Message + "');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);

            }
        }

        private Usuario IniciarSesionPrueba(int user)
        {
            Usuario prueba = null;
            try
            {
                usuarioNegocio = new UsuarioNegocio();

                string username = user == 1 ? "admin@admin.com" : "user@user.com";
                string password = user == 1 ? "admin" : "user";

                prueba = usuarioNegocio.ObtenerUsuario(username, password);
                
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IniciarSesion())
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);

            }
        }

        private bool IniciarSesion()
        {
            bool tieneSesion  = false;
            try
            {
                string mail = this.txtEmail.Value;
                string password = this.txtPassword.Value;
                if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                {
                    mensaje = "¡Debe llenar todos los campos!";
                }
                else
                {
                    usuarioNegocio = new UsuarioNegocio();
                    Usuario usuario = usuarioNegocio.ObtenerUsuario(mail, password);

                    tieneSesion = usuario != null;
                    if (tieneSesion)
                    {
                        Session.Add("User", usuario);
                    }
                    else
                    {
                        mensaje = "¡Usuario o contraseña incorrectos!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tieneSesion;
        }
    }
}