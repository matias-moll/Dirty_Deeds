using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class UsuarioInhabilitadoException : Exception
    {
        public UsuarioInhabilitadoException(string mensaje) : base(mensaje) { }
    }
}
