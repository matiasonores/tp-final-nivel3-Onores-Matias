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
    public partial class Articulos : System.Web.UI.Page
    {
        ArticuloNegocio articuloNegocio;
        CategoriaNegocio categoriaNegocio;
        MarcaNegocio marcaNegocio;

        public bool FiltroAvanzado { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Guardamos la lista en el session y bindeamos el session en el dgv
                articuloNegocio = new ArticuloNegocio();
                List<Articulo> lista = articuloNegocio.ObtenerArticulos();
                Session.Add("listaArticulos", lista);
                CargarArticulos();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            string busqueda = txtFiltro.Text.ToUpper();
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(busqueda));
            
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                articuloNegocio = new ArticuloNegocio();

                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dgvArticulos.DataSource = articuloNegocio.ObtenerArticulosFiltro(campo, criterio, filtro);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosABM.aspx");
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturamos el id y lo usamos para redireccionar al formulario de pokemon
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticulosABM.aspx?id=" + id);
        }


        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                CargarArticulos();
                dgvArticulos.PageIndex = e.NewPageIndex;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarArticulos()
        {
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }
    }
}