using System;
using Resharper_Task.Shapes;

namespace Resharper_Task
{
    internal class App
    {
        private static void Main()
        {
            var square = new Square(3);
            var rectangle = new Rectangle(3, 6);
            var circle = new Circle(5);

            Console.WriteLine($"Square area is: {square.GetArea()}");
            Console.WriteLine($"Circle area is: {circle.GetArea()}");
            Console.WriteLine($"Rectangle area is: {rectangle.GetArea()}");

            Console.ReadKey();
        }
    }
}
