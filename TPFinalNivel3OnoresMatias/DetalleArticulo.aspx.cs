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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        ArticuloNegocio articuloNegocio;
        int idArticulo;
        public bool esFavorito;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    idArticulo = Convert.ToInt32(Request.QueryString["id"]);

                    if (idArticulo > 0)
                    {
                        CargarArticulo();
                        VerificarFavorito();
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void VerificarFavorito()
        {
            articuloNegocio = new ArticuloNegocio();
            Usuario usuario = (Usuario)Session["User"];
            int userID = usuario.Id;
            Articulo articulo = articuloNegocio.ObtenerArticuloFavorito(userID, idArticulo);

            esFavorito = articulo != null ? true : false;
        }

        private void CargarArticulo()
        {
            try
            {
                articuloNegocio = new ArticuloNegocio();
                Articulo articulo = articuloNegocio.ObtenerArticulo(idArticulo);
                txtNombre.InnerHtml = articulo.Nombre;
                txtCodigo.InnerHtml = articulo.Codigo;
                txtDescripcion.InnerHtml = articulo.Descripcion;
                txtId.Text = articulo.Id.ToString();
                txtCategoria.InnerHtml = articulo.Categoria.Descripcion;
                txtMarca.InnerHtml = articulo.Marca.Descripcion;
                txtPrecio.InnerHtml = articulo.Precio.ToString("C");
                imgArticulo.ImageUrl = "Images/" + articulo.Imagen;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

       
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["User"];
                articuloNegocio = new ArticuloNegocio();
                int idArticulo = Convert.ToInt32(txtId.Text);

                Articulo existe = articuloNegocio.ObtenerArticuloFavorito(usuario.Id, idArticulo);
                
                if(existe == null)
                {
                    int resultado = articuloNegocio.AgregarFavorito(usuario.Id, idArticulo);

                    if (resultado > 0)
                    {
                        Response.Redirect("ArticulosFavoritos.aspx", false);

                        //Mostrar modal o toast
                    }
                }
                else
                {
                    //Mostrar modal o toast de que no se pudo agregar porque ya existe
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBorrarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo el ID
                int id = Convert.ToInt32(txtId.Text);

                //Obtengo el ID de usuario
                Usuario usuario = (Usuario)Session["User"];
                int userID = usuario.Id;

                //Quito el articulo favorito de ese usuario
                articuloNegocio = new ArticuloNegocio();
                if (articuloNegocio.BorrarFavorito(userID, id))
                {
                    Response.Redirect("ArticulosFavoritos.aspx?id=" + userID, false);
                }
                else
                {
                    //No se pudo borrar modal
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}