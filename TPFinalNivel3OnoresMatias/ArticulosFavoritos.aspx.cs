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
    public partial class ArticulosFavoritos : System.Web.UI.Page
    {
        ArticuloNegocio articuloNegocio;
        int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                //Obtengo el id del usuario
                if(Session["User"]!= null)
                {
                    Usuario usuario = (Usuario)Session["User"];
                    userID = usuario.Id;

                    articuloNegocio = new ArticuloNegocio();

                    //Busco los articulos favoritos de ese usuario
                    List<Articulo> articulosFavoritos = articuloNegocio.ObtenerArticulosFavoritos(userID);

                    //Cargo los articulos en el formulario
                    repRepetidor.DataSource = articulosFavoritos;
                    repRepetidor.DataBind();
                }
                
                
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo el ID
                LinkButton linkButton = (LinkButton)sender;
                string idArticulo = linkButton.CommandArgument.ToString();
                int id = Convert.ToInt32(idArticulo);

                //Obtengo el ID de usuario
                Usuario usuario = (Usuario)Session["User"];
                userID = usuario.Id;

                //Busco los articulos favoritos de ese usuario
                articuloNegocio = new ArticuloNegocio();
                if (articuloNegocio.BorrarFavorito(userID, id))
                {
                    Response.Redirect("ArticulosFavoritos.aspx?id=" + id, false);
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

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                //Obtengo el ID
                string idArticulo = linkButton.CommandArgument.ToString();
                int id = Convert.ToInt32(idArticulo);
                //Redirecciono a la pagina de detalle con el id
                Response.Redirect("DetalleArticulo.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}