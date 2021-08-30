using System;

namespace Resharper_Task.Shapes
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"Circle with a radius: {Radius}";
        }
    }
}
