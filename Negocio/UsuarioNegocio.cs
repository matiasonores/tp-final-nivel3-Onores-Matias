using System;
using System.Collections.Generic;
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

            return id;
        }

        public Usuario ObtenerUsuario(string username,  string password)
        {
            Usuario usuario = new Usuario();
            try
            {
                _db.SetProcedure("ObtenerUsuario");
                _db.SetParameter("@username", username);
                _db.SetParameter("@password", password);
                _db.EjecutarLectura();

                if (_db.Lector.Read())
                {
                    usuario.Id = Convert.ToInt32(_db.Lector["Id"]);
                    usuario.Admin = Convert.ToBoolean(_db.Lector["admin"]);

                    if (!(_db.Lector["ImagenPerfil"] is DBNull))
                        usuario.URLImagenPerfil = (string)_db.Lector["ImagenPerfil"];
                    if (!(_db.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)_db.Lector["Nombre"];
                    if (!(_db.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)_db.Lector["Apellido"];
                }
            }
            catch (Exception ex)
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
                _db.SetProcedure("ValidarEmail");
                _db.SetParameter("@email", email);
                _db.EjecutarLectura();

                if (_db.Lector.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return existe;
        }

        public bool ModificarUsuario(Usuario usuario) 
        {
            bool modificado = false;
            try
            {
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

            return modificado;
        }
    }
}
