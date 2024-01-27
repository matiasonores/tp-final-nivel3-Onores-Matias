using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio;
        public string mensaje;

        public string tituloModal;

        public string mensajeModal;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private void CargarControles()
        {
            try
            {
                usuarioNegocio = new UsuarioNegocio();

                List<Usuario> usuarios = usuarioNegocio.ObtenerUsuarios(); //Traemos todas las marcas
                Session.Add("usuarios", usuarios);
                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error intentando cargar controles: " + ex.Message);
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUsuarios.SelectedDataKey.Value);
                MostrarModalUsuario(1, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private void MostrarModalUsuario(int v, int id)
        {
            try
            {
                //Recupero el id de la marca

                List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
                //Busco la marca

                Usuario usuario = usuarios.Find(x => x.Id == id);

                if (v == 1)
                {
                    //Configuro el modal
                    this.tituloModal = "Modificar categoría";
                    this.mensajeModal = "Nombre";
                    this.txtEmail.Visible = true;
                    this.txtEmail.Text = usuario.Email;
                    this.txtPassword.Text = usuario.Password;
                    this.txtPassword.Visible = true;
                    this.chkAdmin.Visible = true;
                    this.chkAdmin.Checked = usuario.Admin;
                    this.txtAdmin.Visible = true;
                    this.btnModificar.Visible = true;
                    this.btnEliminar.Visible = false;
                }
                else
                {
                    //Configuro el modal
                    this.tituloModal = "Eliminar usuario";
                    this.mensajeModal = "¿Desea eliminar el usuario: " + usuario.Email + "?";

                    this.txtPassword.Visible = false;
                    this.txtEmail.Visible = false;
                    this.chkAdmin.Visible =false;
                    this.txtAdmin.Visible = false;

                    this.btnModificar.Visible = false;
                    this.btnEliminar.Visible = true;
                }

                //Asigno su valor al txt
                this.txtIdUsuario.Text = usuario.Id.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalMarca", "mostrarModalUsuario()", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int id = Convert.ToInt32(dgvUsuarios.DataKeys[rowIndex].Value);

                MostrarModalUsuario(2, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.PageIndex = e.NewPageIndex;
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModificarUsuario())
                {
                    mensaje = "Usuario actualizado con éxito";
                }
                else
                {
                    mensaje = "No se modificó el usuario";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private bool ModificarUsuario()
        {
            bool modificado = false;
            try
            {
                int idUser = Convert.ToInt32(this.txtIdUsuario.Text);

                List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];

                Usuario usuario = usuarios.Find(x => x.Id == idUser);
                usuario.Admin = chkAdmin.Checked;
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;

                modificado = usuarioNegocio.ModificarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return modificado;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EliminarUsuario())
                {
                    mensaje = "Categoría eliminada con éxito";
                }
                else
                {
                    mensaje = "No se eliminó la categoría";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private bool EliminarUsuario()
        {
            bool eliminado = false;
            try
            {
                int idUser = Convert.ToInt32(this.txtIdUsuario.Text);
                eliminado = usuarioNegocio.EliminarUsuario(idUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminado;
        }
    }
}