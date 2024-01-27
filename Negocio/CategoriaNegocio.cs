using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        private AccesoDB _db;

        public int AgregarCategoria(string categoria)
        {
            int id;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("AgregarCategoria");
                _db.SetParameter("@descripcion", categoria);
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

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerCategorias");
                _db.EjecutarLectura();
                while (_db.Lector.Read())
                {
                    Categoria categoria = CrearCategoria(_db.Lector);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        private Categoria CrearCategoria(SqlDataReader lector)
        {
            Categoria categoria = new Categoria();
            try
            {
                categoria.Id = Convert.ToInt32(lector["Id"]);
                categoria.Descripcion = lector["Descripcion"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoria;
        }

        public bool EliminarCategoria(int idCategoria)
        {
            bool eliminado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("EliminarCategoria");
                _db.SetParameter("@id", idCategoria);
                eliminado = _db.EjecutarScalar() > 0;

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

        public bool ModificarCategoria(int idCategoria, string descripcion)
        {
            bool modificado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ModificarCategoria");
                _db.SetParameter("@id", idCategoria);
                _db.SetParameter("@descripcion", descripcion);
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
    }
}
