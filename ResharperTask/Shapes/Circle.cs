using System;

namespace ResharperTask.Shapes
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        #region AreaCalculation

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        #endregion

        public override string ToString()
        {
            return $"Circle with a radius: {Radius}";
        }
    }
}
