using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private AccesoDB _db;

        public int AgregarUsuario(Usuario usuario)
        {
            int id = -1;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("AgregarUsuario");
                _db.SetParameter("@email", usuario.Email);
                _db.SetParameter("@pass", usuario.Password);
                _db.SetParameter("@nombre", usuario.Nombre);
                _db.SetParameter("@apellido", usuario.Apellido);
                _db.SetParameter("@imagenPerfil", usuario.URLImagenPerfil);
                _db.SetParameter("@admin", usuario.Admin);
                
                id = _db.EjecutarScalar();

                if(id > 0)
                {
                    usuario.Id= id;
                }
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

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerUsuarios");
                _db.EjecutarLectura();
                while (_db.Lector.Read())
                {
                    Usuario usuario = CrearUsuario(_db.Lector);
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarios;
        }

        public Usuario ObtenerUsuario(string username,  string password)
        {
            Usuario usuario = null;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ObtenerUsuario");
                _db.SetParameter("@email", username);
                _db.SetParameter("@password", password);
                _db.EjecutarLectura();

                if (_db.Lector.Read())
                {
                    usuario = CrearUsuario(_db.Lector);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }

            return usuario;
        }

        private Usuario CrearUsuario(SqlDataReader lector)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario.Id = Convert.ToInt32(_db.Lector["Id"]);
                usuario.Email = (string)_db.Lector["email"];
                usuario.Password = (string)_db.Lector["pass"];
                usuario.Admin = Convert.ToBoolean(_db.Lector["admin"]);

                if (!(_db.Lector["ImagenPerfil"] is DBNull))
                    usuario.URLImagenPerfil = (string)_db.Lector["ImagenPerfil"];
                if (!(_db.Lector["Nombre"] is DBNull))
                    usuario.Nombre = (string)_db.Lector["Nombre"];
                if (!(_db.Lector["Apellido"] is DBNull))
                    usuario.Apellido = (string)_db.Lector["Apellido"];
            }
            catch (Exception ex )
            {
                throw ex;
            }

            return usuario;
        }

        public bool ValidarEmail(string email)
        {
            bool existe = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ValidarEmail");
                _db.SetParameter("@email", email);
                _db.EjecutarLectura();

                if (_db.Lector.Read())
                {
                    existe = _db.Lector["id"] != DBNull.Value && (int)_db.Lector["id"] > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.CerrarConexion();
            }

            return existe;
        }

        public bool EliminarUsuario(int idUser)
        {
            bool eliminado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("EliminarUsuario");
                _db.SetParameter("@idUser", idUser);
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

        public bool ModificarUsuario(Usuario usuario) 
        {
            bool modificado = false;
            try
            {
                _db = new AccesoDB();
                _db.SetProcedure("ModificarUsuario");
                _db.SetParameter("@id", usuario.Id);
                _db.SetParameter("@email", usuario.Email);
                _db.SetParameter("@pass", usuario.Password);
                _db.SetParameter("@nombre", usuario.Nombre);
                _db.SetParameter("@apellido", usuario.Apellido);
                _db.SetParameter("@imagenPerfil", usuario.URLImagenPerfil);
                _db.SetParameter("@admin", usuario.Admin);

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
