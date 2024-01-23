using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class Signin : System.Web.UI.Page
    {
        public string mensaje;
        bool camposValidos;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if(!IsPostBack)
                {
                    txtApellido.Text = Session["Apellido"] != null ? Session["Apellido"].ToString() : "";
                    txtNombre.Text = Session["Nombre"] != null ? Session["Nombre"].ToString() : "";
                    txtEmail.Text = Session["Email"] != null ? Session["Email"].ToString() : "";
                   // mensaje = Session["Mensaje"] != null ? Session["Mensaje"].ToString() : "";
                }
                
			}
			catch (Exception ex)
			{
				throw;
			}
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            int i=-1;
            try
            {
                string apellido = txtApellido.Text;
                Session.Add("Apellido", apellido);
                string email = txtEmail.Text;
                Session.Add("Email", email);
                string nombre = txtNombre.Text;
                Session.Add("Nombre", nombre);
                string password = txtPassword.Text;

                if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido))
                {
                    if (ValidarEmail(email))
                    {
                        string imagen = GuardarImagen();

                        if (camposValidos)
                        {
                            Usuario nuevo = new Usuario();
                            nuevo.Email = email;
                            nuevo.Apellido = apellido;
                            nuevo.Nombre = nombre;
                            nuevo.URLImagenPerfil = imagen;
                            nuevo.Password = password;
                            nuevo.Admin = false;

                            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                            i = usuarioNegocio.AgregarUsuario(nuevo);
                        }
                    }
                }

                if(i>0)
                {
                    mensaje = "¡Usuario agregado con éxito!";
                    

                }
                else
                {
                    mensaje = "No se pudo agregar el nuevo usuario";
                }
                
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ValidarEmail(string email)
        {
            bool esValido = false;
            try
            {
                string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex regex = new Regex(pattern);

                esValido= regex.IsMatch(email);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return esValido;
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