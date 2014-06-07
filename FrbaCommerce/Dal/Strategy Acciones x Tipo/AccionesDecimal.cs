using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class AccionesDecimal : AccionesTipo
    {
        override internal string formatToSql(object unValor)
        {
            return ((decimal)unValor).ToString().Replace(',', '.');
        }
    }
}
