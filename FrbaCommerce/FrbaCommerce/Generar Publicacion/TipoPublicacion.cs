using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class TipoPublicacion
    {
        public char tipo { get; set; }
        public string descripcion { get; set; }

        public TipoPublicacion(char unTipo, string unaDescripcion)
        {
            tipo = unTipo;
            descripcion = unaDescripcion;
        }

        public static List<TipoPublicacion> tipos;

        public static TipoPublicacion tipoVacio { get { return new TipoPublicacion(' ', ""); } }

        static TipoPublicacion()
        {
            tipos = new List<TipoPublicacion>();
            tipos.Add(new TipoPublicacion('C', "Compra Inmediata"));
            tipos.Add(new TipoPublicacion('S', "Subasta"));
            tipos.Add(tipoVacio);
        }

    }
}
