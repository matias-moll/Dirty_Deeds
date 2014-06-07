using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesObject : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            return unValor.ToString();
        }
    }
}
