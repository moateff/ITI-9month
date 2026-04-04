using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DBManager
    {
        private readonly string _connectionString;

        public DBManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PubDbConnectionString"]?.ConnectionString
                                ?? throw new InvalidOperationException("Connection string not found.");
        }

        #region ExecuteNonQuery

        public int ExecuteNonQuery(string spName, Dictionary<string, object>? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = CreateCommand(connection, spName, parameters);
            connection.Open();
            return command.ExecuteNonQuery();
        }

        #endregion

        #region ExecuteScalar

        public object? ExecuteScalar(string spName, Dictionary<string, object>? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = CreateCommand(connection, spName, parameters);
            connection.Open();
            return command.ExecuteScalar();
        }

        #endregion

        #region ExecuteDataTable

        public DataTable ExecuteDataTable(string spName, Dictionary<string, object>? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = CreateCommand(connection, spName, parameters);
            using var adapter = new SqlDataAdapter(command);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        #endregion

        #region Helper

        private static SqlCommand CreateCommand(SqlConnection connection, string spName, Dictionary<string, object>? parameters)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            return cmd;
        }

        #endregion
    }
}