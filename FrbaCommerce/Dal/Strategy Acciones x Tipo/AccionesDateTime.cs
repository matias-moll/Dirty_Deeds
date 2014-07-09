using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNGS.NetRoutines;

namespace Dal
{
    internal class AccionesDateTime : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            DateTime unaFechaHora = (DateTime)unValor;
            return Ruts.Fh(unaFechaHora);
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
