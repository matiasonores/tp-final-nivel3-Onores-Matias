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

        public bool AgregarArticulo(Articulo articulo)
        {
            return true;
        }

        public bool ModificarArticulo(Articulo articulo)
        {
            return true;
        }

        public bool BorrarArticulo(int id)
        {
            return true;
        }

        public Articulo ObtenerArticulo(int id)
        {
            return null;
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
