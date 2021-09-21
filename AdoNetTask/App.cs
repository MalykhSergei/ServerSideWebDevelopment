using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNetTask
{
    internal class App
    {
        private static void Main()
        {
            try
            {
                var totalProductsCount = Utils.GetTotalProductsCount();
                Console.WriteLine($"Total number of products: {totalProductsCount}");
                Console.WriteLine();

                Console.WriteLine("Please enter name of product: ");
                var productName = Console.ReadLine();

                Console.WriteLine("Please enter price of product: ");
                var productPrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter category of product: ");
                var productCategoryId = Convert.ToInt32(Console.ReadLine());

                Utils.InsertProduct(productName, productPrice, productCategoryId);
                Console.WriteLine();

                Console.WriteLine("Please enter new product name: ");
                productName = Console.ReadLine();

                Console.WriteLine("Enter the ID of the product whose name you want to change: ");
                var productId = Convert.ToInt32(Console.ReadLine());

                Utils.UpdateProduct(productName, productId);
                Console.WriteLine();

                Console.WriteLine("Please enter the name of the product you want to delete: ");
                productName = Console.ReadLine();

                Utils.DeleteProduct(productName);

                var productsWithCategoriesList = Utils.GetProductsAndCategoriesList();

                foreach (var item in productsWithCategoriesList)
                {
                    Console.WriteLine(item);
                }

                var dataSet = Utils.GetProductsAndCategoriesWithSqlDataAdapterList();

                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0}", column.ColumnName);
                    }

                    Console.WriteLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        foreach (var cell in cells)
                        {
                            Console.Write("{0} ", cell);
                        }

                        Console.WriteLine();
                    }
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
