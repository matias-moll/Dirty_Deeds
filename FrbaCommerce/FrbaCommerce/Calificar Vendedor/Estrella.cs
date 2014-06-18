using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class Estrella
    {
        public string descripcion { get; set; }
        public int valor { get; set; }

        public Estrella(int unValor, string unaDes)
        {
            valor = unValor;
            descripcion = unaDes;
        }
    }
}
