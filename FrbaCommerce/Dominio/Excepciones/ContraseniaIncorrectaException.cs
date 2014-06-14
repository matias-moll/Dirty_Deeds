using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ContraseniaIncorrectaException : Exception
    {
        public ContraseniaIncorrectaException() : base("La contrasenia ingresada es incorrecta, intentelo nuevamente.") { }
    }
}
