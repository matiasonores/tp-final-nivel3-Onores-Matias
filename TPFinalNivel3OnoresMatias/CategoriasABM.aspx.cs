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
    public partial class CategoriasABM : System.Web.UI.Page
    {
        CategoriaNegocio categoriaNegocio;
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
                categoriaNegocio = new CategoriaNegocio();

                List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();
                Session.Add("categorias", categorias);
                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataBind();

                dgvCategorias.DataSource = categorias;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                string categoria = txtNombreCategoria.Text;
                bool agregarCategoria = !string.IsNullOrEmpty(categoria);
                if (agregarCategoria)
                {
                    categoriaNegocio = new CategoriaNegocio();
                    int id = categoriaNegocio.AgregarCategoria(categoria);
                    if (id > 0)
                    {
                        ActualizarCategorias(id, categoria);
                        mensaje = "¡Categoría agregada con éxito!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                    }
                }
                else
                {
                    mensaje = "Ingrese un nombre para la categoria";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private void ActualizarCategorias(int id, string categoria)
        {
            try
            {
                List<Categoria> categorias = (List<Categoria>)Session["categorias"];
                Categoria nueva = new Categoria();
                nueva.Id = id;
                nueva.Descripcion = categoria;
                categorias.Add(nueva);

                Session["categorias"] = categorias; //Pisamos el valor anterior
                ddlCategorias.DataSource = categorias; //Las asignamos al ddl
                ddlCategorias.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
                ddlCategorias.DataValueField = "Id"; //Escondemos el ID
                ddlCategorias.DataBind();

                dgvCategorias.DataSource = categorias;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error actualizando categorías: " + ex.Message);
            }
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCategorias.SelectedDataKey.Value);
                MostrarModalCategoria(1, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        protected void dgvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int id = Convert.ToInt32(dgvCategorias.DataKeys[rowIndex].Value);

                MostrarModalCategoria(2, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private void MostrarModalCategoria(int v, int id)
        {
            try
            {
                //Recupero el id de la marca

                //int id = Convert.ToInt32(dgvCategorias.DataKeys[rowIndex].Value);
                List<Categoria> categorias = (List<Categoria>)Session["categorias"];
                //Busco la marca

                Categoria categoria = categorias.Find(x => x.Id == id);

                if (v == 1)
                {
                    //Configuro el modal
                    this.tituloModal = "Modificar categoría";
                    this.mensajeModal = "Nombre";
                    this.txtCategoria.Visible = true;
                    this.txtCategoria.Text = categoria.Descripcion;
                    this.btnModificar.Visible = true;
                    this.btnEliminar.Visible = false;
                }
                else
                {
                    //Configuro el modal
                    this.tituloModal = "Eliminar categoría";
                    this.mensajeModal = "¿Desea eliminar la categoría: " + categoria.Descripcion + "?";

                    this.txtCategoria.Visible = false;
                    this.btnModificar.Visible = false;
                    this.btnEliminar.Visible = true;
                }

                //Asigno su valor al txt
                this.txtIdCategoria.Text = categoria.Id.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalMarca", "mostrarModalCategoria()", true);
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
                if (ModificarCategoria())
                {
                    mensaje = "Categoría actualizada con éxito";
                }
                else
                {
                    mensaje = "No se modificó la categoría";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private bool ModificarCategoria()
        {
            bool modificado = false;
            try
            {
                int idCategoria = Convert.ToInt32(this.txtIdCategoria.Text);
                string descripcion = this.txtCategoria.Text;
                modificado = categoriaNegocio.ModificarCategoria(idCategoria, descripcion);
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
                if (EliminarCategoria())
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

        private bool EliminarCategoria()
        {
            bool eliminado = false;
            try
            {
                int idCategoria = Convert.ToInt32(this.txtIdCategoria.Text);
                eliminado = categoriaNegocio.EliminarCategoria(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminado;
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                List<Categoria> categorias = (List<Categoria>)Session["categorias"];
                dgvCategorias.DataSource = categorias;
                dgvCategorias.PageIndex = e.NewPageIndex;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}