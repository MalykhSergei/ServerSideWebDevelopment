namespace Resharper_Task.Shapes
{
     internal class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public override string ToString()
        {
            return $"Square with a length of side: {SideLength}";
        }
    }
}
