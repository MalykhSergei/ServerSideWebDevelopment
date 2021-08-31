namespace ResharperTask.Shapes
{
    internal class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        #region AreaCalculation

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        #endregion

        public override string ToString()
        {
            return $"Square with a length of side: {SideLength}";
        }
    }
}
