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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
            }
            catch (Exception ex)
            {

                //Mostrar modal
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
                    }
                }
            }
            catch (Exception ex)
            {
                //Mostrar modal
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

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error actualizando marcas: " + ex.Message);
            }
        }
    }
}