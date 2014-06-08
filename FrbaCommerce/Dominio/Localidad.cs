using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Localidad
    {
        public string autoId { get; set; }
        public string campoNombre { get; set; }

        public Localidad(string p_nombre)
        {
            campoNombre = p_nombre;
        }
    }
}
