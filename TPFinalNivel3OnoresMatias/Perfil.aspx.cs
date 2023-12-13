using Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    CargarUsuario();
                }
            }
        }

        private void CargarUsuario()
        {
            Usuario usuario = (Usuario)Session["User"];
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            txtPassword.Text = usuario.Password;
            if (string.IsNullOrEmpty(usuario.URLImagenPerfil))
            {
                imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1213374148/vector/missing-rubber-stamp-vector.jpg?s=612x612&w=0&k=20&c=Ij-YXxAHydym-tzQYVAoieBUA5b3rU1l2P0B49rFNMc=";

            }
            else
            {
                imgPerfil.ImageUrl = "Images/" + usuario.URLImagenPerfil;

            }
        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx",false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}