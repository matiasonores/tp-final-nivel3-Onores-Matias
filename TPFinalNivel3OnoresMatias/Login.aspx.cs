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

                throw ex;
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                if(IniciarSesionPrueba(2) != null)
                {
                    Response.Redirect("Default.aspx",false);
                }
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('Username already in use!')", true);
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Usuario IniciarSesionPrueba(int user)
        {
            usuarioNegocio = new UsuarioNegocio();

            string username = user == 1 ? "admin@admin.com" : "user@user.com";
            string passwrod = user == 1 ? "admin" : "user";

            Usuario prueba = usuarioNegocio.ObtenerUsuario(username,passwrod);
            
            if(prueba != null)
            {
                Session.Add("User", prueba);
            }

            return prueba;
        }
    }
}