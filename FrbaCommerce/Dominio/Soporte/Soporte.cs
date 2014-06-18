using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;

namespace Dominio
{
    public static class Soporte
    {

        public static object notNull(object unObjeto, object valor)
        {
            return (unObjeto == null)? valor: unObjeto;
        }

        public static DateTime Now()
        {
            return AccesoArchivoConfig.fechaActual;
        }
    }
}
