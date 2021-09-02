using System;
using System.Text;

namespace VectorTask
{
    internal class App
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[] array1 = { 1, 2, 3 };
            double[] array2 = { 4, 5, 6 };

            var vector1 = new Vector(array1);
            var vector2 = new Vector(array2);

            Console.WriteLine(Vector.GetScalarProduct(vector1, vector2));
        }
    }
}