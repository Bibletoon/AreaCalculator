using AreaCalculator.Shapes;
using AreaCalculator.Shapes.Factory;

namespace AreaCalculator.Tests.Shapes;

[TestFixture]
public class ShapeFactoryTests
{
    [Test]
    [TestCase(5)]
    public void ShapeFactory_CreateCircle_ReturnsCircle(double radius)
    {
        var shapeFactory = new ShapeFactory();
        
        var circle = shapeFactory.CreateCircle(radius);
        
        Assert.Multiple(() =>
        {
            Assert.That(circle, Is.Not.Null);
            Assert.That(circle, Is.TypeOf<Circle>());
            Assert.That(circle.Radius, Is.EqualTo(radius));
        });
    }

    [Test]
    [TestCase(3, 4, 5)]
    public void ShapeFactory_CreateTriangle_ReturnsTriangle(double firstSide, double secondSide, double thirdSide)
    {
        var shapeFactory = new ShapeFactory();
        
        var triangle = shapeFactory.CreateTriangle(firstSide, secondSide, thirdSide);
        
        Assert.Multiple(() =>
        {
            Assert.That(triangle, Is.Not.Null);
            Assert.That(triangle, Is.TypeOf<Triangle>());
            Assert.That(triangle.FirstSide, Is.EqualTo(firstSide));
            Assert.That(triangle.SecondSide, Is.EqualTo(secondSide));
            Assert.That(triangle.ThirdSide, Is.EqualTo(thirdSide));
        });
    }

    [TestCase(new double[]{})]
    [TestCase(3, 4)]
    [TestCase(1, 2, 3, 4)]
    public void ShapeFactory_CreateWithInvalidArgumentsCount_ThrowsArgumentException(params double[] parameters)
    {
        var shapeFactory = new ShapeFactory();
        
        Assert.That(() => shapeFactory.Create(parameters), Throws.ArgumentException);
    }

    [TestCase(5)]
    public void ShapeFactory_CreateWithOneArgument_CreatesCircle(double parameter)
    {
        var shapeFactory = new ShapeFactory();

        var shape = shapeFactory.Create(parameter);
        
        Assert.Multiple(() =>
        {
            Assert.That(shape, Is.Not.Null);
            Assert.That(shape, Is.InstanceOf<Circle>());
        });
    }
    
    [TestCase(3, 4, 5)]
    public void ShapeFactory_CreateWithMultipleArguments_CreatesTriangle(params double[] parameters)
    {
        var shapeFactory = new ShapeFactory();

        var shape = shapeFactory.Create(parameters);
        
        Assert.Multiple(() =>
        {
            Assert.That(shape, Is.Not.Null);
            Assert.That(shape, Is.InstanceOf<Triangle>());
        });
    }
}
