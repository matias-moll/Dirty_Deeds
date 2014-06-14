using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException(string mensaje) : base(mensaje) { }
    }
}
