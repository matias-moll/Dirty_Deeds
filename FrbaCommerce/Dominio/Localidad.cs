using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Localidad
    {
        private string codPostal;
        private string nombre;

        public string campoCodPostal { get { return String.Format("'{0}'", codPostal); }}
        public string campoNombre { get { return String.Format("'{0}'", nombre); } }

        public Localidad(string p_codPostal, string p_nombre)
        {
            codPostal = p_codPostal;
            nombre = p_nombre;
        }
    }
}
