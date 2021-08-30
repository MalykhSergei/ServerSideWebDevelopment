using System;
using System.Configuration;
using Resharper_Task.Shapes;
using ShapesLibrary;

namespace Resharper_Task
{
    internal class App
    {
        private static void Main()
        {
            var square = new Square(3);
            var circle = new Circle(5);
            var rectangle = new Rectangle(3, 5);

            Console.WriteLine($"Square area is: {square.GetArea()}");
            Console.WriteLine($"Circle area is: {circle.GetArea()}");
            Console.WriteLine(rectangle);

            Console.WriteLine();

            var site = ConfigurationManager.AppSettings["SiteUrl"];
            Console.WriteLine(site);

            Console.ReadKey();
        }
    }
}
