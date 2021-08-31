using System;
using System.Configuration;
using ResharperTask.Shapes;
using ShapesLibrary;

namespace ResharperTask
{
    internal class App
    {
        private static void Main()
        {
#if DEBUG
            var square = new Square(3);
            var circle = new Circle(5);
            var rectangle = new Rectangle(3, 5);
#else
            var square = new Square(5);
            var circle = new Circle(7);
            var rectangle = new Rectangle(2, 8);
#endif
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