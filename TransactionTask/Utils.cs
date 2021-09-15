using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TransactionTask
{
    internal class Utils
    {
        private const string ConnectionString = @"Server=.;Initial Catalog=Shop;Integrated Security=true;";

        private static SqlConnection GetConnection()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }

        public static void InsertWithTransaction(string newCategoryName)
        {
            var transaction = GetConnection().BeginTransaction();

            try
            {
                const string sql = "INSERT INTO dbo.Categories(name) " +
                                   "VALUES(@newCategoryName)";

                using var command = new SqlCommand(sql, GetConnection());
                command.Parameters.Add(new SqlParameter("@newCategoryName", SqlDbType.NVarChar)
                {
                    Value = newCategoryName
                });

                command.Transaction = transaction;
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
        }

        public static void InsertWithoutTransaction(string newCategoryName)
        {
            try
            {
                const string sql = "INSERT INTO dbo.Categories(name) " +
                                   "VALUES(@newCategoryName)";

                using var command = new SqlCommand(sql, GetConnection());
                command.Parameters.Add(new SqlParameter("@newCategoryName", SqlDbType.NVarChar)
                {
                    Value = newCategoryName
                });

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
