using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public static class BadDb
    {
        public static readonly string ConnectionString;

        static BadDb()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            ConnectionString = configuration.GetConnectionString("Sql");
        }

        public static int ExecuteNonQueryUnsafe(string sql)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static IDataReader ExecuteReaderUnsafe(string sql)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader();
        }
    }
}

