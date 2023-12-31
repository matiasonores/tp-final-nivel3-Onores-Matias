﻿using Dominio;
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
                    Categoria categoria = CrearMarca(_db.Lector);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        private Categoria CrearMarca(SqlDataReader lector)
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
    }
}
