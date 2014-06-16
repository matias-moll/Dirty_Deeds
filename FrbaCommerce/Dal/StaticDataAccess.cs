﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public static class StaticDataAccess
    {
        public static DataTable executeStoredProcedureReturningDataTable(string nameSP)
        {
            return executeQuery(nameSP);
        }

        public static int executeIntFunction(string nameFunction)
        {
            string nombreFuncionCompleto = String.Format("select DIRTYDEEDS.{0}()", nameFunction);

            DataTable dtResultado = executeQuery(nombreFuncionCompleto);
            if ((dtResultado == null) ||(dtResultado.Rows.Count != 1) || (dtResultado.Rows[0][0].GetType() == typeof(DBNull)))
                return 0;

            return Convert.ToInt32(dtResultado.Rows[0][0]);
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

        public static int executeCommand(string stringCommand)
        {
            SqlConnection conexion = DBConn.getDBConn();
            conexion.Open();

            SqlCommand command = conexion.CreateCommand();
            command.CommandText = stringCommand;
            command.Connection = conexion;

            return command.ExecuteNonQuery();
        }

        public static int executeInsert(string stringInsert)
        {
            // Ejecutamos el select para saber el id que nos dio ese insert.
            DataTable dtIdentity = executeQuery(stringInsert);
            if ((dtIdentity == null) || (dtIdentity.Rows.Count != 1))
                return 0;

            // Devolvemos el id.
            return Convert.ToInt32(dtIdentity.Rows[0][0]);
        }

        private static string returnIdentity()
        {
            return "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
        }
    }
}
