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
        CategoriaNegocio categoriaNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            //int startIndex = Math.Max(0, articulos.Count - 3);
            //for (int i = startIndex; i < articulos.Count; i++)
            //{
            //    topFavoritos.Add(articulos[i]);
            //}
            
            //Rodeamos el repeteater dentro de un if para que no cause problemas al querer hacer postback y recargar la pagina
            if (!IsPostBack)
            {
                articuloNegocio = new ArticuloNegocio();
                List<Articulo> articulos = articuloNegocio.ObtenerArticulos();
                Session.Add("Articulos", articulos);
                categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();

                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataBind();

                ddlCategorias.Items.Insert(0, new ListItem("Seleccione...", "-1"));

                int cantidad = 3;
                List<Articulo> topFavoritos = articuloNegocio.ObtenerTopFavoritos(cantidad);

                repRepetidor.DataSource = articulos;
                repRepetidor.DataBind();

                //RepeaterCarousel.DataSource = favoritos;
                RepeaterCarousel.DataSource = topFavoritos;
                RepeaterCarousel.DataBind();

                RepeaterCarousel2.DataSource = topFavoritos;
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

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recuperamos el listado de articulos
            List<Articulo> articulos = (List<Articulo>)Session["articulos"];
            //Obtenemos el valor del filtro
            string filtro = ddlCategorias.SelectedItem.ToString();
            //Filtramos la lista
            List<Articulo> articulosFiltrados = articulos.Where(x => x.Categoria.Descripcion == filtro).ToList();
            //Bindeamos la lista nueva
            repRepetidor.DataSource = articulosFiltrados;
            repRepetidor.DataBind();

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Recuperamos el listado de articulos
            List<Articulo> articulos = (List<Articulo>)Session["articulos"];
            //Obtenemos el valor del filtro
            string filtro = txtBuscar.Text;

            filtro = filtro.ToLower();
            //Filtramos la lista
            List<Articulo> articulosFiltrados = articulos.Where(x => x.Nombre.ToLower().Contains(filtro)).ToList();
            //Bindeamos la lista nueva
            repRepetidor.DataSource = articulosFiltrados;
            repRepetidor.DataBind();
        }
    }
}