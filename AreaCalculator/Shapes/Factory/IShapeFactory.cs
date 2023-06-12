namespace AreaCalculator.Shapes.Factory;

public interface IShapeFactory
{
    Circle CreateCircle(double radius);
    Triangle CreateTriangle(double firstSide, double secondSide, double thirdSide);
    IShape Create(params double[] parameters);
}