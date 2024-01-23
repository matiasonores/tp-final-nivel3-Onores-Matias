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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private void CargarControles()
        {
            try
            {
                categoriaNegocio = new CategoriaNegocio();

                List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();
                Session.Add("categorias", categorias);
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {

                throw;
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error actualizando categorías: " + ex.Message);
            }
        }
    }
}