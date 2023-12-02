using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string URLImagenPerfil { get; set; }

        public bool Admin { get; set; }
    }
}
