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

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {

        }
    }
}