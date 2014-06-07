using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal abstract class AccionesTipo
    {
        // Como se agrega una condicion es generico a todos, lo particular es la condicion en si (makeCondition).
        internal void agregarCondicion(ref string where, string nombreCampo, object valorCampo)
        {
            // Los and se ponen al final porque si van antes de la condicion hay problemas con el primer and.
            where = String.Format("{0} {1} and", where, makeCondition(nombreCampo, valorCampo));
        }

        // Firmas obligatorias a implementar en los objetos del strategy.
        abstract internal string formatToSql(object unValor);
        abstract internal string makeCondition(string nombreCampo, object valorCampo);
        abstract internal bool esVacio(object valorProperty);

    }
}
