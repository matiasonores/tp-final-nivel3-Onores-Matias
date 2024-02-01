using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class ArticulosABM : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio;
        CategoriaNegocio categoriaNegocio;
        ArticuloNegocio articuloNegocio;
        bool camposValidos;
        string idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idArticulo = Request.QueryString["id"];

                if (!IsPostBack)
                {
                    CargarControles();
                }

                if (!string.IsNullOrEmpty(idArticulo) && !IsPostBack)
                {
                    articuloNegocio = new ArticuloNegocio();
                    
                    Articulo articulo = articuloNegocio.ObtenerArticulo(Convert.ToInt32(idArticulo));
                    txtId.Text = idArticulo;
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    imagen.ImageUrl = "~/Images/" + articulo.Imagen;
                    ddlCategoria.SelectedIndex = articulo.Categoria.Id;
                    ddlMarca.SelectedIndex = articulo.Marca.Id;
                    txtPrecio.Text = articulo.Precio.ToString();

                    btnAceptar.Text = "Modificar";
                    btnEliminar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + ex.Message + "');", true);
            }
        }

        private void CargarControles()
        {
            try
            {
                string ruta = "~/Images/"; //Para LEER la ruta de imagen
                string imagePlaceholder = "imagePlaceholder"; //Nombre del archivo
                string extension = ".jpg"; //Extension

                imagen.ImageUrl = ruta + imagePlaceholder + extension;

                marcaNegocio = new MarcaNegocio();
                categoriaNegocio = new CategoriaNegocio();

                List<Marca> marcas = marcaNegocio.ObtenerMarcas(); //Traemos todas las marcas
                marcas.Insert(0, new Marca { Id = 0, Descripcion = "Seleccione..." });

                Session.Add("marcas", marcas);
                ddlMarca.DataSource = marcas; //Las asignamos al ddl
                ddlMarca.DataTextField = "Descripcion"; //Mostrarmos la descripcion de la marca
                ddlMarca.DataValueField = "Id"; //Escondemos el ID
                ddlMarca.DataBind();

                List<Categoria> categorias = categoriaNegocio.ObtenerCategorias();
                categorias.Insert(0, new Categoria { Id = 0, Descripcion = "Seleccione..." });

                Session.Add("categorias", categorias);
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar controles: " + ex.Message);
            }

        }
        private string GuardarImagen()
        {
            string imagenGuardada = "";
            camposValidos = false;
            try
            {
                //Antes de hacer cualquier cosa, validamos que haya un archivo subido
                bool tieneArchivo = fileImagen.HasFile;
                if (tieneArchivo)
                {
                    string archivoSubido = fileImagen.FileName; //Guardamos el nombre del archivo subido
                    string extension = ".jpg"; //Guardamos la extension para las imagenes

                    bool extensionValida = Path.GetExtension(archivoSubido) == extension; //Validamos que el archivo subido tenga la extension admitida
                    if (extensionValida)
                    {
                        string ruta = Server.MapPath("./Images/"); //Ruta para ESCRIBIR ruta de imagen
                        DateTime dateTime = DateTime.Now; //Creamos una cadena de texto con la fecha
                        string nombreArchivo = dateTime.ToString("yyyyMMddHHmmss"); //Casteamos la fecha a string
                        string imagen = ruta + nombreArchivo + extension; //Combinamos las cadenas de texto

                        fileImagen.SaveAs(imagen);//Guardamos el archivo en la carpeta

                        bool guardado = File.Exists(imagen); //Comprobamos que se haya guardado el archivo
                        if (guardado)
                        {
                            imagenGuardada = nombreArchivo + extension;
                            camposValidos = true;
                        }
                    }
                }

                return imagenGuardada; //Comprobamos que existe el archivo y devolvemos la respuesta
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                throw new Exception("Ocurrió un error al guardar la imagen: " + ex.Message);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ValidarCadenaVacia(txtCodigo.Text);
                string descripcion = ValidarCadenaVacia(txtDescripcion.Text);
                string nombre = ValidarCadenaVacia(txtNombre.Text);
                string imagen = GuardarImagen();
                decimal precio = ValidarPrecio(txtPrecio.Text);
                if (camposValidos)
                {
                    bool existeID = !string.IsNullOrEmpty(txtId.Text);
                    
                    int id = AgregarArticulo(Convert.ToInt32(this.idArticulo), codigo, nombre, descripcion, imagen, precio, existeID);
                    
                    if (id > 0)
                    {
                        Response.Redirect("Articulos.aspx",false);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + ex.Message +"');", true);
            }
        }

        private int AgregarArticulo(int idArticulo, string codigo, string nombre, string descripcion, string imagen, decimal precio, bool existeID)
        {
            Articulo articulo;
            int id;
            try
            {
                articulo = new Articulo();
                articulo.Codigo = codigo;
                articulo.Nombre = nombre;
                articulo.Descripcion = descripcion;
                articulo.Precio = precio;
                articulo.Imagen = imagen;
                articulo.Marca = new Marca();
                articulo.Marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);

                articuloNegocio = new ArticuloNegocio();
                if (existeID)
                {
                    articulo.Id = idArticulo;
                    id = Convert.ToInt32(articuloNegocio.ModificarArticulo(articulo));
                }
                else
                {
                    id = articuloNegocio.AgregarArticulo(articulo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }

        private decimal ValidarPrecio(string text)
        {
            decimal precio;
                
            camposValidos = Decimal.TryParse(text, out precio);

            return precio;
        }

        private string ValidarCadenaVacia(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                camposValidos = false;
            }
            return text;
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                articuloNegocio = new ArticuloNegocio();
                if(articuloNegocio.BorrarArticulo(id))
                {
                    Response.Redirect("Articulos.aspx",false);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + ex.Message + "');", true);

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        
        protected void btnImagen_Click(object sender, EventArgs e)
        {
            //Actualizar Imagen
        }
    }
}