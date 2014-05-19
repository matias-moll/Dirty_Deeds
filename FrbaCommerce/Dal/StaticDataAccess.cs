using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public static class StaticDataAccess
    {
        public static void executeStoredProcedure(string nameSP)
        {

        }

        public static DataTable executeQuery(string query)
        {
            return null;
        }

        public static void executeCommand(string stringCommand)
        {
            SqlConnection conexion = DBConn.getDBConn();
            conexion.Open();

            SqlCommand command = conexion.CreateCommand();
            command.CommandText = stringCommand;

            command.ExecuteNonQuery();

        }
    }
}
