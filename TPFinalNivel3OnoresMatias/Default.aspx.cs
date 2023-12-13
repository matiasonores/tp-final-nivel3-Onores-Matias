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
    public partial class _Default : Page
    {
        ArticuloNegocio articuloNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            articuloNegocio = new ArticuloNegocio();

            List<Articulo> articulos = articuloNegocio.ObtenerArticulos();
            //List<Articulo> favoritos = articuloNegocio.ObtenerFavoritos();
            List<Articulo> ImagenesCarousel = new List<Articulo>();
            int startIndex = Math.Max(0, articulos.Count - 3);
            for (int i = startIndex; i < articulos.Count; i++)
            {
                ImagenesCarousel.Add(articulos[i]);
            }
            
            //Rodeamos el repeteater dentro de un if para que no cause problemas al querer hacer postback y recargar la pagina
            if (!IsPostBack)
            {
                repRepetidor.DataSource = articulos;
                repRepetidor.DataBind();

                //RepeaterCarousel.DataSource = favoritos;
                RepeaterCarousel.DataSource = ImagenesCarousel;
                RepeaterCarousel.DataBind();

                RepeaterCarousel2.DataSource = ImagenesCarousel;
                RepeaterCarousel2.DataBind();
            }
        }


        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton button = (LinkButton)sender;

                string idArticulo = button.CommandArgument;
                int id = Convert.ToInt32(idArticulo);

                if (AgregarFavorito(id))
                {
                    //Mostrar toast o llevar a favoritos
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool AgregarFavorito(int id)
        {
            bool agregado = false;
            try
            {
                Usuario usuario = (Usuario)Session["User"];
                articuloNegocio = new ArticuloNegocio();

                int resultado = articuloNegocio.AgregarFavorito(usuario.Id, id);
                if (resultado > 0)
                {
                    agregado = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return agregado;
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton button = (LinkButton)sender;

                string idArticulo = button.CommandArgument;
                int id = Convert.ToInt32(idArticulo);
                
                Response.Redirect("DetalleArticulo.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}