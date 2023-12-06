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
                IniciarSesionPrueba(1);
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
                IniciarSesionPrueba(2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void IniciarSesionPrueba(int user)
        {
            usuarioNegocio = new UsuarioNegocio();

            string username = user == 1 ? "admin@admin.com" : "admin";
            string passwrod = user == 1 ? "user@user.com" : "user";

            Usuario prueba = usuarioNegocio.ObtenerUsuario(username,passwrod);

            Session.Add("User", prueba);
        }
    }
}