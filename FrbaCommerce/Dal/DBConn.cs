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
            stringDeConexion = "Server=localhost;Database=GD1C2014;User Id=gd;Password=gd2014";
        }

        public static SqlConnection getDBConn()
        {
            return new SqlConnection(stringDeConexion);
        }
    }
}
