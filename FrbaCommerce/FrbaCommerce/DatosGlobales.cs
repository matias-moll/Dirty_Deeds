using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    internal static class DatosGlobales
    {
        internal static Dominio.Usuario usuarioLoggeado { get; private set; }

        internal static void seLoggeoElUsuario(Dominio.Usuario usuario)
        {
            usuarioLoggeado = usuario;
        }
    }
}
