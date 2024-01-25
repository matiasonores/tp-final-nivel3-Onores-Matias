using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class Perfil : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        public string mensaje;
        bool camposValidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    CargarUsuario();
                    if (Session["Modificado"] != null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true); //Mostramos el toast
                        Session["Modificado"] = null; //Limpiamos el valor de modificado
                    }
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
                imgPerfil.ImageUrl = "Images/Usuarios/" + usuario.URLImagenPerfil;

            }
        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActualizarDatos())
                {
                    Session.Add("Modificado", "¡Modificado con éxito!");
                    Response.Redirect("Perfil.aspx", false);
                }
            }
            catch (Exception ex)
            {
                mensaje = "¡No se pudo actualizar los datos: " + ex.Message;
            }
        }

        private bool ActualizarDatos()
        {
            bool actualizado = false;
            try
            {
                Usuario usuario = (Usuario)Session["User"];
                usuario.Password = txtPassword.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.URLImagenPerfil = GuardarImagen();

                actualizado = usuarioNegocio.ModificarUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return actualizado;
        }

        private string GuardarImagen()
        {
            string imagenGuardada = "";
            camposValidos = false;
            try
            {
                //Antes de hacer cualquier cosa, validamos que haya un archivo subido
                bool tieneArchivo = fuImagen.HasFile;
                if (tieneArchivo)
                {
                    string archivoSubido = fuImagen.FileName; //Guardamos el nombre del archivo subido
                    string extension = ".jpg"; //Guardamos la extension para las imagenes

                    bool extensionValida = Path.GetExtension(archivoSubido) == extension; //Validamos que el archivo subido tenga la extension admitida
                    if (extensionValida)
                    {
                        string ruta = Server.MapPath("./Images/Usuarios/"); //Ruta para ESCRIBIR ruta de imagen
                        DateTime dateTime = DateTime.Now; //Creamos una cadena de texto con la fecha
                        string nombreArchivo = dateTime.ToString("yyyyMMddHHmmss"); //Casteamos la fecha a string
                        string imagen = ruta + nombreArchivo + extension; //Combinamos las cadenas de texto

                        fuImagen.SaveAs(imagen);//Guardamos el archivo en la carpeta

                        bool guardado = File.Exists(imagen); //Comprobamos que se haya guardado el archivo
                        if (guardado)
                        {
                            imagenGuardada = nombreArchivo + extension;
                            camposValidos = true;
                        }
                    }
                }

                return imagenGuardada; //Comprobamos que existe el archivo y devolvemos la respuesta
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar la imagen del usuario: " + ex.Message);
            }
        }
    }
}