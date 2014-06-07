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
    }
}
