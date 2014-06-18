using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Dal
{
    public static class DBConn
    {

        private static string stringDeConexion;

        static DBConn()
        {
            stringDeConexion = AccesoArchivoConfig.stringConexionBD;
        }

        public static SqlConnection getDBConn()
        {
            return new SqlConnection(stringDeConexion);
        }
    }
}
