using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
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
            if (!IsPostBack)
            {
                CargarArticulos();
                CargarCategorias();
                CargarFavoritos();
                CargarDropDownList();
            }
        }

        private void CargarDropDownList()
        {
            ddlOrdenar.Items.Clear();
            ddlOrdenar.Items.Insert(0, new ListItem("Seleccione...", "-1"));
            ddlOrdenar.Items.Insert(1, new ListItem("Nombre", "1"));
            ddlOrdenar.Items.Insert(2, new ListItem("Precio", "2"));
        }

        private void CargarFavoritos()
        {
            try
            {
                int cantidad = 3;

                List<Articulo> topFavoritos = articuloNegocio.ObtenerTopFavoritos(cantidad);

                RepeaterCarousel.DataSource = topFavoritos;
                RepeaterCarousel.DataBind();

                RepeaterCarousel2.DataSource = topFavoritos;
                RepeaterCarousel2.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarCategorias()
        {
            try
            {
                categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();

                ddlCategorias.DataSource = categorias;
                ddlCategorias.DataValueField = "Id";
                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataBind();

                ddlCategorias.Items.Insert(0, new ListItem("Seleccione...", "-1"));
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
            if (filtro == "Seleccione...")
            {
                repRepetidor.DataSource = articulos;
            }
            else
            {
                List<Articulo> articulosFiltrados = articulos.Where(x => x.Categoria.Descripcion == filtro).ToList();
                //Bindeamos la lista nueva
                repRepetidor.DataSource = articulosFiltrados;
            }
            repRepetidor.DataBind();

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarArticulos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarArticulos()
        {
            try
            {
                if (IsPostBack)
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
                else
                {
                    articuloNegocio = new ArticuloNegocio();
                    List<Articulo> articulos = articuloNegocio.ObtenerArticulos();
                    Session.Add("Articulos", articulos);
                    repRepetidor.DataSource = articulos;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDropDownListCriterio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDropDownListCriterio()
        {
            try
            {
                string criterio = ddlOrdenar.SelectedItem.Text;

                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Insert(0, new ListItem("Seleccione...", "-1"));
                if (criterio == "Nombre")
                {
                    ddlCriterio.Items.Insert(1, new ListItem("A-Z", "1"));
                    ddlCriterio.Items.Insert(2, new ListItem("Z-A", "2"));
                }
                else
                {
                    ddlCriterio.Items.Insert(1, new ListItem("Menor a mayor", "1"));
                    ddlCriterio.Items.Insert(2, new ListItem("Mayor a menor", "2"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OrdenarArticulos();
                
                //ClientScript.RegisterStartupScript(this.GetType(), "MostrarModal", "mostrarModal()", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarModal()", true);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OrdenarArticulos()
        {
            try
            {
                string criterio = ddlCriterio.SelectedItem.Text;
                List<Articulo> articulos = (List<Articulo>)Session["articulos"];

                List<Articulo> articulosFiltrados = new List<Articulo>();

                switch (criterio) 
                {
                    case "A-Z":
                        articulosFiltrados = articulos.OrderBy(x => x.Nombre).ToList();
                        break;
                    case "Z-A":
                        articulosFiltrados = articulos.OrderByDescending(x => x.Nombre).ToList();
                        break;
                    case "Menor a mayor":
                        articulosFiltrados = articulos.OrderBy(x => x.Precio).ToList();
                        break;
                    case "Mayor a menor":
                        articulosFiltrados = articulos.OrderByDescending(x => x.Precio).ToList();
                        break;
                    default:
                        articulosFiltrados = articulos;
                        break;
                }
                repRepetidor.DataSource = articulosFiltrados;
                repRepetidor.DataBind();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}