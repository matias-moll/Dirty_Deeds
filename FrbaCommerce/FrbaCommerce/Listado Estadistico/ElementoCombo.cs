using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class ElementoCombo
    {
        public string descripcion { get; set; }
        public int valor { get; set; }

        public ElementoCombo(int unValor, string unaDes)
        {
            valor = unValor;
            descripcion = unaDes;
        }
    }
}
