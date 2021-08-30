namespace ShapesLibrary
{
    public class Rectangle
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Rectangle with a height {Height} and width {Width}";
        }
    }
}
