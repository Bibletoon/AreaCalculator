using AreaCalculator.Shapes;
using AreaCalculator.Shapes.Factory;

namespace AreaCalculator.Tests;

using NUnit.Framework;

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

    [TestCase(5)]
    [TestCase(3, 4, 5)]
    public void ShapeFactory_Create_CreatesShape(params double[] parameters)
    {
        var shapeFactory = new ShapeFactory();
        
        var shape = shapeFactory.Create(parameters);
        
        Assert.Multiple(() =>
        {
            Assert.That(shape, Is.Not.Null);
            Assert.That(shape, Is.InstanceOf<IShape>()); 
        });
    }
}
