using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal class LogicByType
    {

        private static Dictionary<Type, AccionesTipo> accionesSegunTipo;

        static LogicByType()
        {
            accionesSegunTipo = new Dictionary<Type, AccionesTipo>();
            accionesSegunTipo.Add(typeof(string), new AccionesString());
            accionesSegunTipo.Add(typeof(decimal), new AccionesDecimal());
            accionesSegunTipo.Add(typeof(object), new AccionesObject());
            accionesSegunTipo.Add(typeof(byte), new AccionesObject());
        }
        
        internal static string formatToSql(object unValor)
        {
            // Usamos el diccionario salvador para acceder al objeto correspondiente del strategy
            // Nos sacamos de encima los ifs y las sobrecargas de metodos =D!
            return accionesSegunTipo[unValor.GetType()].formatToSql(unValor);
        }
        
    }
}
