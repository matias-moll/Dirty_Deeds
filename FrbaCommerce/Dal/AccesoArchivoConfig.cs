using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public static class AccesoArchivoConfig
    {
        internal static string stringConexionBD { get; private set; }
        public static DateTime fechaActual { get; private set; }

        static AccesoArchivoConfig()
        {
            string pathBase = AppDomain.CurrentDomain.BaseDirectory;
            pathBase = pathBase.Substring(0, pathBase.LastIndexOf("\\bin"));
            string pathToConfig = pathBase  + "\\Configuracion.txt";
            string[] lines = System.IO.File.ReadAllLines(pathToConfig);
            stringConexionBD = lines[0];
            fechaActual = Convert.ToDateTime(lines[1]);
        }

        private static int getFromPositionTo(string[] lines, int inicio, int longitud)
        {
            return Convert.ToInt32(lines[1].Substring(inicio, longitud));
        }
    }
}
