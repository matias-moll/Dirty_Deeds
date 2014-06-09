using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesDateTime : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            string valorString = unValor.ToString();
            // Si es pm, tenemos que ajustar a mano la suma de 12 horas porque en la conversion a string
            // se pierde y nos graba todas las horas como si fuera am.
            if (valorString.Contains('p'))
            {
                string horaAnterior = valorString.Substring(11,2);
                int horaAnteriorInt = Convert.ToInt32(horaAnterior);
                horaAnteriorInt += 12;
                horaAnterior = String.Format(" {0}:", horaAnterior);
                string horaNueva = String.Format(" {0}:", horaAnteriorInt.ToString());
                valorString = valorString.Replace(horaAnterior, horaNueva);
            }

            // Hay que cambiar de lugar los dias y el mes porque el sql tiene el formato ingles.
            string dias = valorString.Substring(0, 2);
            string mes = valorString.Substring(3, 2);
            valorString = String.Format("{0}/{1}{2}", mes, dias, valorString.Substring(5, valorString.Length - 5));

            // Le quitamos el p.m. de la string.
            valorString = valorString.Substring(0, valorString.Length - 5);

            return String.Format("'{0}'", valorString);
        }

        override internal string makeCondition(string nombreCampo, object valorCampo)
        {
            return String.Format("{0} = {1}", nombreCampo, formatToSql(valorCampo));
        }

        override internal bool esVacio(object valorProperty)
        {
            return ((DateTime)valorProperty).Year == 1900;
        }
    }
}
