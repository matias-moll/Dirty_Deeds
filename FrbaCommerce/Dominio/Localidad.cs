using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Localidad
    {

        public string campoCodPostal { get; set; }
        public string campoNombre { get; set; }

        public Localidad(string p_codPostal, string p_nombre)
        {
            campoCodPostal = p_codPostal;
            campoNombre = p_nombre;
        }
    }
}
