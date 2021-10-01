using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNetTask
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

        private static SqlCommand GetSqlCommand(string sql, SqlConnection connection)
        {
            return new SqlCommand(sql, connection);
        }

        public static int GetTotalProductsCount()
        {
            const string sql = "SELECT COUNT(*) FROM dbo.Products";

            using var connection = GetConnection();
            using var command = GetSqlCommand(sql, connection);

            return (int)command.ExecuteScalar();
        }

        public static void InsertCategory(string categoryName)
        {
            const string sql = "INSERT INTO dbo.Categories(name) VALUES(@categoryName)";

            using var connection = GetConnection();
            using var command = GetSqlCommand(sql, connection);

            command.Parameters.Add(new SqlParameter("@categoryName", SqlDbType.NVarChar)
            {
                Value = categoryName
            });

            command.ExecuteNonQuery();
        }

        public static void InsertProduct(string productName, int productPrice, int productCategory)
        {
            const string sql = "INSERT INTO dbo.Products(name, price, categoryId)" +
                               "VALUES(@productName, @productPrice, @productCategory)";

            using var connection = GetConnection();
            using var command = GetSqlCommand(sql, connection);

            var sqlParameters = new[]
            {
                new SqlParameter("@productName", SqlDbType.NVarChar)
                {
                    Value = productName
                },
                new SqlParameter("@productPrice", SqlDbType.Int)
                {
                    Value = productPrice
                },
                new SqlParameter("@productCategory", SqlDbType.Int)
                {
                    Value = productCategory
                }
            };

            command.Parameters.AddRange(sqlParameters);
            command.ExecuteNonQuery();
        }

        public static void UpdateProduct(string newProductName, int id)
        {
            const string sql = "UPDATE dbo.Products " +
                               "SET Name = @newProductName " +
                               "WHERE ID = @id";

            using var connection = GetConnection();
            using var command = GetSqlCommand(sql, connection);

            var sqlParameters = new[]
            {
                new SqlParameter("@newProductName", SqlDbType.NVarChar)
                {
                    Value = newProductName
                },
                new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                }
            };

            command.Parameters.AddRange(sqlParameters);
            command.ExecuteNonQuery();
        }

        public static void DeleteProduct(string productName)
        {
            const string sql = "DELETE FROM dbo.Products " +
                               "WHERE Name = @productName";

            using var connection = GetConnection();
            using var command = GetSqlCommand(sql, connection);

            command.Parameters.Add(new SqlParameter("@productName", SqlDbType.NVarChar)
            {
                Value = productName
            });

            command.ExecuteNonQuery();
        }

        public static List<string> GetProductsAndCategoriesList()
        {
            var productsWithCategoriesList = new List<string>();

            const string sql = "SELECT pr.Name AS Products_name, cat.Name AS Categories_Name " +
                               "FROM [dbo].Products AS pr " +
                               "JOIN [dbo].Categories AS cat " +
                               "ON pr.CategoryId = cat.ID";

            using var connection = GetConnection();
            using var reader = GetSqlCommand(sql, connection).ExecuteReader();

            while (reader.Read())
            {
                productsWithCategoriesList.Add($"{reader.GetValue(0)} {reader.GetValue(1)}");
            }

            return productsWithCategoriesList;
        }

        public static DataSet GetProductsAndCategoriesWithSqlDataAdapterList()
        {
            const string sql = "SELECT pr.Name AS Products_name, cat.Name AS Categories_Name " +
                               "FROM [dbo].Products AS pr " +
                               "JOIN [dbo].Categories AS cat " +
                               "ON pr.CategoryId = cat.ID";

            using var connection = GetConnection();
            using var adapter = new SqlDataAdapter(sql, connection);

            var dataSet = new DataSet();

            adapter.Fill(dataSet);

            return dataSet;
        }
    }
}