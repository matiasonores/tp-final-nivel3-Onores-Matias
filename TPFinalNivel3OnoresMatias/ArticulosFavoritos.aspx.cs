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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                
                //Obtengo el id del usuario
                int userID = Convert.ToInt32(Request.QueryString["ID"]);
                

                articuloNegocio = new ArticuloNegocio();

                //Busco los articulos favoritos de ese usuario
                List<Articulo> articulosFavoritos = articuloNegocio.ObtenerArticulosFavoritos(userID);

                //Cargo los articulos en el formulario
                repRepetidor.DataSource = articulosFavoritos;
                repRepetidor.DataBind();



            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            //Obtengo el ID

            //Lo quito
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            //Obtengo el ID

            //Redirecciono a la pagina de detalle con el id
        }
    }
}