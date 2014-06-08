using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesBool : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            return (converBoolToByteString((bool)unValor));
        }

        override internal string makeCondition(string nombreCampo, object valorCampo)
        {
            return String.Format("{0} = {1}", nombreCampo, converBoolToByteString((bool)valorCampo));
        }

        override internal bool esVacio(object valorProperty)
        {
            return !(bool)valorProperty;
        }

        private string converBoolToByteString(bool unBool)
        {
            return (unBool)? "1":"0";
        }
    }
}
