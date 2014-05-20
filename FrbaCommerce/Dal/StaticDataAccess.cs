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
            DataTable table = new DataTable();
            SqlConnection conexion = DBConn.getDBConn();
            SqlCommand command = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataAdapter da = new SqlDataAdapter(command);

            // El fill ejecuta el query y llena la data table.
            da.Fill(table);

            conexion.Close();
            da.Dispose();

            return table;
        }

        public static void executeCommand(string stringCommand)
        {
            SqlConnection conexion = DBConn.getDBConn();
            conexion.Open();

            SqlCommand command = conexion.CreateCommand();
            command.CommandText = stringCommand;
            command.Connection = conexion;

            command.ExecuteNonQuery();

        }
    }
}
