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
    public partial class MarcasABM : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio;
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
                marcaNegocio = new MarcaNegocio();

                List<Marca> marcas = marcaNegocio.ObtenerMarcas(); //Traemos todas las marcas
                Session.Add("marcas", marcas);
                ddlMarca.DataSource = marcas; //Las asignamos al ddl
                ddlMarca.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
                ddlMarca.DataValueField = "Id"; //Escondemos el ID
                ddlMarca.DataBind();

                dgvMarcas.DataSource = marcas;
                dgvMarcas.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error intentando cargar controles: " + ex.Message);
            }

        }
        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                string marca = txtNombreMarca.Text;
                bool agregarMarca = !string.IsNullOrEmpty(marca);
                if (agregarMarca)
                {
                    marcaNegocio = new MarcaNegocio();
                    int id = marcaNegocio.AgregarMarca(marca);
                    if (id > 0)
                    {
                        ActualizarMarcas(id, marca);
                        mensaje = "¡Marca agregada con éxito!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                    }
                }
                else
                {
                    mensaje = "Ingrese un nombre para la marca";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private void ActualizarMarcas(int id, string marca)
        {
            try
            {
                List<Marca> marcas = (List<Marca>)Session["marcas"];
                Marca nueva = new Marca();
                nueva.Id = id;
                nueva.Descripcion = marca;
                marcas.Add(nueva);

                Session["marcas"] = marcas; //Pisamos el valor anterior
                ddlMarca.DataSource = marcas; //Las asignamos al ddl
                ddlMarca.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
                ddlMarca.DataValueField = "Id"; //Escondemos el ID
                ddlMarca.DataBind();

                dgvMarcas.DataSource = marcas;
                dgvMarcas.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error actualizando marcas: " + ex.Message);
            }
        }

        public bool ModificarMarca()
        {
            bool modificado = false;
            try
            {
                int idMarca = Convert.ToInt32(this.txtIdMarca.Text);
                string descripcion = this.txtMarca.Text;
                modificado = marcaNegocio.ModificarMarca(idMarca,descripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return modificado;
        }


        private void MostrarModalMarca(int v, int id)
        {
            //Recupero el id de la marca

            //int id = Convert.ToInt32(dgvMarcas.DataKeys[rowIndex].Value);
            List<Marca> marcas = (List<Marca>)Session["marcas"];
            //Busco la marca

            Marca marca = marcas.Find(x => x.Id == id);

            if (v == 1)
            {
                //Configuro el modal
                this.tituloModal = "Modificar marca";
                this.mensajeModal = "Nombre";
                this.txtMarca.Visible = true;
                this.txtMarca.Text = marca.Descripcion;
                this.btnModificar.Visible = true;
                this.btnEliminar.Visible = false;
            }
            else
            {
                //Configuro el modal
                this.tituloModal = "Eliminar marca";
                this.mensajeModal = "¿Desea eliminar la marca: " + marca.Descripcion + "?";

                this.txtMarca.Visible = false;
                this.btnModificar.Visible = false;
                this.btnEliminar.Visible = true;
            }

            //Asigno su valor al txt
            this.txtIdMarca.Text = marca.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalMarca", "mostrarModalMarca()", true);
        }

        protected void dgvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int id = Convert.ToInt32(dgvMarcas.DataKeys[rowIndex].Value);
                MostrarModalMarca(2, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModificarMarca())
                {
                    mensaje = "Marca actualizada con éxito";
                }
                else
                {
                    mensaje = "No se modificó la marca";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EliminarMarca())
                {
                    mensaje = "Marca eliminada con éxito";
                }
                else
                {
                    mensaje = "No se eliminó la marca";
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }

        private bool EliminarMarca()
        {
            bool eliminado = false;
            try
            {
                int idMarca = Convert.ToInt32(this.txtIdMarca.Text);
                eliminado = marcaNegocio.EliminarMarca(idMarca);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminado;
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMarcas.SelectedDataKey.Value);
                MostrarModalMarca(1, id);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);
            }
        }
    }
}