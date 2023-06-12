namespace AreaCalculator.Shapes;

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Invalid circle radius");
        
        Radius = radius;
    }

    public double GetArea()
    {
        return Radius * Radius * Math.PI;
    }
}