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
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }

        public static void InsertWithTransaction(string newCategoryName)
        {
            using var connection = GetConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                const string sql = "INSERT INTO dbo.Categories(name) " +
                                   "VALUES (@newCategoryName)";

                using var command = new SqlCommand(sql, connection);

                command.Parameters.Add(new SqlParameter("@newCategoryName", SqlDbType.NVarChar)
                {
                    Value = newCategoryName
                });

                command.Transaction = transaction;
                command.ExecuteNonQuery();

                if (newCategoryName == "newCategory")
                {
                    throw new Exception("Data could not be added to the database");
                }

                transaction.Commit();
                Console.WriteLine("Data added to the database");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }

        public static void InsertWithoutTransaction(string newCategoryName)
        {
            try
            {
                const string sql = "INSERT INTO dbo.Categories(name) " +
                                   "VALUES (@newCategoryName)";

                using var connection = GetConnection();
                using var command = new SqlCommand(sql, connection);

                command.Parameters.Add(new SqlParameter("@newCategoryName", SqlDbType.NVarChar)
                {
                    Value = newCategoryName
                });

                command.ExecuteNonQuery();

                if (newCategoryName == "newCategory")
                {
                    throw new Exception("Data could not be added to the database");
                }

                Console.WriteLine("Data added to the database");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
