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
            DateTime unaFechaHora = (DateTime)unValor;
            string fechaFormateada = unaFechaHora.ToString("MM/dd/yyyy HH:mm:ss");
            return String.Format("'{0}'", fechaFormateada);
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
