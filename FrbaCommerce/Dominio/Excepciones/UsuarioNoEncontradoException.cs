using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException(string mensaje) : base(mensaje) { }
    }
}
