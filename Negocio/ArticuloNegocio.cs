using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        private AccesoDB _db;
        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerArticulos");
                _db.EjecutarLectura();
                while (_db.Lector.Read())
                {
                    Articulo articulo = CrearArticulo(_db.Lector);
                    articulos.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return articulos;
        }

        private Articulo CrearArticulo(SqlDataReader lector)
        {
            Articulo articulo = new Articulo();
            try
            {
                articulo.Id = Convert.ToInt32(lector["Id"]);
                articulo.Codigo = lector["Codigo"].ToString();
                articulo.Nombre = lector["Nombre"].ToString();
                articulo.Descripcion = lector["Descripcion"].ToString();
                Marca marca = new Marca();
                marca.Id = Convert.ToInt32(lector["IdMarca"]);
                marca.Descripcion = lector["Marca"].ToString();
                articulo.Marca = marca;
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(lector["IdCategoria"]);
                categoria.Descripcion = lector["Categoria"].ToString();
                articulo.Categoria = categoria;
                articulo.Imagen = lector["Imagen"].ToString();
                articulo.Precio = Convert.ToDecimal(lector["Precio"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return articulo;
        }

        public int AgregarArticulo(Articulo articulo)
        {
            int id;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("AgregarArticulo");
                _db.SetParameter("@codigo", articulo.Codigo);
                _db.SetParameter("@nombre", articulo.Nombre);
                _db.SetParameter("@descripcion", articulo.Descripcion);
                _db.SetParameter("@precio", articulo.Precio);
                _db.SetParameter("@imagen", articulo.Imagen);
                _db.SetParameter("@marca", articulo.Marca.Id);
                _db.SetParameter("@categoria", articulo.Categoria.Id);
                
                id = _db.EjecutarScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
            return id;
        }

        public bool ModificarArticulo(Articulo articulo)
        {
            bool modificado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ModificarArticulo");
                _db.SetParameter("@id", articulo.Id);
                _db.SetParameter("@codigo", articulo.Codigo);
                _db.SetParameter("@nombre", articulo.Nombre);
                _db.SetParameter("@descripcion", articulo.Descripcion);
                _db.SetParameter("@precio", articulo.Precio);
                _db.SetParameter("@imagen", articulo.Imagen);
                _db.SetParameter("@marca", articulo.Marca.Id);
                _db.SetParameter("@categoria", articulo.Categoria.Id);
                _db.EjecutarAccion();
                modificado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }
            return modificado;
        }

        public bool BorrarArticulo(int id)
        {
            bool eliminado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("BorrarArticulo");
                _db.SetParameter("@id", id);
                _db.EjecutarAccion();
                eliminado = true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }

            return eliminado;
        }

        public Articulo ObtenerArticulo(int id)
        {
            Articulo articulo = new Articulo();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerArticulo");
                _db.SetParameter("@id", id);
                
                _db.EjecutarLectura();

                while (_db.Lector.Read())
                {
                    articulo = CrearArticulo(_db.Lector);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return articulo;
        }

        public object ObtenerArticulosFiltro(string campo, string criterio, string filtro)
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerArticulosFiltro");
                _db.SetParameter("@campo", campo);
                _db.SetParameter("@criterio", criterio);
                _db.SetParameter("@filtro", filtro);
                _db.EjecutarLectura();
                while (_db.Lector.Read())
                {
                    Articulo articulo = CrearArticulo(_db.Lector);
                    articulos.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return articulos;
        }
    }
}
