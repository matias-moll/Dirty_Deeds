using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class UsuarioInhabilitadoException : Exception
    {
        public UsuarioInhabilitadoException(string mensaje) : base(mensaje) { }
    }
}
