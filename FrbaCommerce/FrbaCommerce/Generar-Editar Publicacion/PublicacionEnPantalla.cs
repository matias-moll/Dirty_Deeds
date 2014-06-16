using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace FrbaCommerce
{
    class PublicacionEnPantalla
    {
        public enum modoPublicacion { nueva = 1, existente = 2 };

        public Dominio.Publicacion objeto { get; set; }
        public Estado estado { get; set; }
        public bool esNueva { get; private set; }

        public PublicacionEnPantalla(Dominio.Publicacion publicacion)
        {
            objeto = publicacion;
            esNueva = false;
        }

        public PublicacionEnPantalla(Dominio.Publicacion publicacion, Estado unEstado, modoPublicacion modo)
            : this(publicacion)
        {
            estado = unEstado;
            esNueva = (modo == modoPublicacion.nueva);
        }
    }
}
