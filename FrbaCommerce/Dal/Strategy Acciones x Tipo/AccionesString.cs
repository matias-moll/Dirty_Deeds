using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesString : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            return String.Format("'{0}'", (string)unValor);
        }

        override internal string makeCondition(string nombreCampo, object valorCampo)
        {
            // Ej: Descripcion like '%pepe%'
            return String.Format("{0} like '%{1}%'", nombreCampo, (string)valorCampo);
        }

        override internal bool esVacio(object valorProperty)
        {
            return ((string)valorProperty) == "";
        }
    }
}
