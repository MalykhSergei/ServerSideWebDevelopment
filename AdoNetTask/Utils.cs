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

        private static SqlCommand GetSqlCommand(string sql)
        {
            using var command = new SqlCommand(sql, GetConnection());

            return command;
        }

        public static object Select(string databaseName)
        {
            var sql = $"SELECT COUNT(*) FROM dbo.{databaseName}";

            return (int)GetSqlCommand(sql).ExecuteScalar();
        }

        public static void InsertCategory(string categoryName)
        {
            const string sql = "INSERT INTO dbo.Categories(name) VALUES(@categoryName)";

            var command = GetSqlCommand(sql);
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

            var command = GetSqlCommand(sql);

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
                               "SET NAME= @newProductName " +
                               "WHERE ID= @id";

            using var command = GetSqlCommand(sql);

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
                               "WHERE NAME= @productName";

            using var command = GetSqlCommand(sql);

            command.Parameters.Add(new SqlParameter("@productName", SqlDbType.NVarChar)
            {
                Value = productName
            });

            command.ExecuteNonQuery();
        }

        public static List<object> GetProductsAndCategoriesList()
        {
            var productsWithCategoriesList = new List<object>();

            const string sql = "SELECT pr.NAME AS Products_name, cat.NAME AS Categories_Name " +
                               "FROM[dbo].Products AS pr " +
                               "LEFT JOIN[dbo].Categories AS cat " +
                               "ON pr.CATEGORYID = cat.ID";

            using var reader = GetSqlCommand(sql).ExecuteReader();

            while (reader.Read())
            {
                productsWithCategoriesList.Add($"{reader.GetValue(0)} {reader.GetValue(1)}");
            }

            return productsWithCategoriesList;
        }

        public static DataSet GetProductsAndCategoriesWithSqlDataAdapterList()
        {
            const string sql = "SELECT pr.NAME AS Products_name, cat.NAME AS Categories_Name " +
                               "FROM[dbo].Products AS pr " +
                               "LEFT JOIN[dbo].Categories AS cat " +
                               "ON pr.CATEGORYID = cat.ID";

            using var adapter = new SqlDataAdapter(sql, GetConnection());

            var dataSet = new DataSet();

            adapter.Fill(dataSet);

            return dataSet;
        }
    }
}
