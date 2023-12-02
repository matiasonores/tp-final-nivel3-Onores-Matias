using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ObtenerArticulos()
        {
            return null;
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
    }
}
