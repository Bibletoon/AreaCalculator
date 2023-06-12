using AreaCalculator.Shapes;

namespace AreaCalculator.Tests;

[TestFixture]
public class CircleTests
{
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void Circle_InvalidRadius_ThrowsArgumentException(double radius)
    {
        Assert.That(() => new Circle(radius), Throws.ArgumentException);
    }

    [Test]
    [TestCase(1)]
    [TestCase(10)]
    public void Circle_ValidRadius_CreatesCircleObject(double radius)
    {
        var circle = new Circle(radius);
        
        Assert.That(circle.Radius, Is.EqualTo(radius));
    }

    [Test]
    [TestCase(1, 3.1415926)]
    [TestCase(5, 78.539816)]
    [TestCase(15, 706.858347)]
    public void Circle_GetArea_ReturnsCorrectArea(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        
        Assert.That(circle.GetArea(), Is.EqualTo(expectedArea).Within(5));
    }
}