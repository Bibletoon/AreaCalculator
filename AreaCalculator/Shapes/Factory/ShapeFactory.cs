namespace AreaCalculator.Shapes.Factory;

public class ShapeFactory : IShapeFactory
{
    public Circle CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    public Triangle CreateTriangle(double firstSide, double secondSide, double thirdSide)
    {
        return new Triangle(firstSide, secondSide, thirdSide);
    }

    public IShape Create(params double[] parameters)
    {
        return parameters.Length switch
        {
            1 => new Circle(parameters[0]),
            3 => new Triangle(parameters[0], parameters[1], parameters[2]),
            _ => throw new ArgumentException("Invalid shape parameters")
        };
    }
}