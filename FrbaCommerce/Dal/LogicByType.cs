using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    internal static class LogicByType
    {

        private static Dictionary<Type, AccionesTipo> accionesSegunTipo;

        static LogicByType()
        {
            accionesSegunTipo = new Dictionary<Type, AccionesTipo>();
            accionesSegunTipo.Add(typeof(string), new AccionesString());
            accionesSegunTipo.Add(typeof(int), new AccionesInt());
            accionesSegunTipo.Add(typeof(decimal), new AccionesDecimal());
            accionesSegunTipo.Add(typeof(byte), new AccionesByte());
            accionesSegunTipo.Add(typeof(bool), new AccionesBool());
        }
        
        internal static string formatToSql(object unValor)
        {
            // Usamos el diccionario salvador para acceder al objeto correspondiente del strategy
            // Nos sacamos de encima los ifs y las sobrecargas de metodos =D!
            return accionesSegunTipo[unValor.GetType()].formatToSql(unValor);
        }

        internal static bool esVacio(object valorProperty)
        {
            // Delegamos en el objeto correspondiente del strategy a partir del diccionario.
            return accionesSegunTipo[valorProperty.GetType()].esVacio(valorProperty);
        }

        internal static void agregarCondicion(ref string where, string nombreCampo, object valorCampo)
        {
            // Delegamos en el objeto correspondiente del strategy a partir del diccionario.
            accionesSegunTipo[valorCampo.GetType()].agregarCondicion(ref where, nombreCampo, valorCampo);
        }
        
    }
}
