using System;
using System.Data.SqlClient;
using CrimeAnalysisReportingSystem.Util;

namespace CrimeAnalysisReportingSystem.Util
{
    public class DBConnection
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            try
            {
                if (connection == null)
                {
                    string connectionString = PropertyUtil.GetConnectionString();
                    connection = new SqlConnection(connectionString);
                }

                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting database connection: {ex.Message}");
                return null;
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing database connection: {ex.Message}");
            }
        }
    }
}