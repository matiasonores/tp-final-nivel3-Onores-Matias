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
        CategoriaNegocio categoriaNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }
        private void CargarControles()
        {
            marcaNegocio = new MarcaNegocio();
            categoriaNegocio = new CategoriaNegocio();

            List<Marca> marcas = marcaNegocio.ObtenerMarcas(); //Traemos todas las marcas
            Session.Add("marcas", marcas);
            ddlMarca.DataSource = marcas; //Las asignamos al ddl
            ddlMarca.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
            ddlMarca.DataValueField = "Id"; //Escondemos el ID
            ddlMarca.DataBind();

            List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();
            Session.Add("categorias", categorias);
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ActualizarMarcas(int id, string marca)
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ActualizarCategorias(int id, string categoria)
        {
            List<Categoria> categorias = (List<Categoria>)Session["categorias"];
            Categoria nueva = new Categoria();
            nueva.Id = id;
            nueva.Descripcion = categoria;
            categorias.Add(nueva);

            Session["categorias"] = categorias; //Pisamos el valor anterior
            ddlCategoria.DataSource = categorias; //Las asignamos al ddl
            ddlCategoria.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
            ddlCategoria.DataValueField = "Id"; //Escondemos el ID
            ddlCategoria.DataBind();
        }
    }
}