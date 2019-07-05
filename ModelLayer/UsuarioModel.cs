using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class UsuarioModel
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }

        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public byte? Genero { get; set; }

        public string Correo { get; set; }
    }
}
