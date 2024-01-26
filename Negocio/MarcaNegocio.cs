using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        private AccesoDB _db;

        public int AgregarMarca(string marca)
        {
            int id;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("AgregarMarca");
                _db.SetParameter("@descripcion", marca);
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

        public bool EliminarMarca(int idMarca)
        {
            throw new Exception("Eliminé la marca: " + idMarca);
        }

        public bool ModificarMarca(int idMarca, string descripcion)
        {
            throw new Exception("Modifiqué la marca: " + idMarca);
        }

        public List<Marca> ObtenerMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerMarcas");
                _db.EjecutarLectura();
                while (_db.Lector.Read())
                {
                    Marca marca = CrearMarca(_db.Lector);
                    marcas.Add(marca);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marcas;
        }

        private Marca CrearMarca(SqlDataReader lector)
        {
            Marca marca = new Marca();
            try
            {
                marca.Id = Convert.ToInt32(lector["Id"]);
                marca.Descripcion = lector["Descripcion"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marca;
        }
    }
}
