using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesInt : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            return unValor.ToString();
        }

        override internal string makeCondition(string nombreCampo, object valorCampo)
        {
            return String.Format("{0} = {1}", nombreCampo, (int)valorCampo);
        }

        override internal bool esVacio(object valorProperty)
        {
            return (int)valorProperty == 0;
        }
    }
}
