using AreaCalculator.Shapes;

namespace AreaCalculator.Tests;

[TestFixture]
public class TriangleTests
{
    [TestCase(0, 2, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(1, 2, 0)]
    [TestCase(1, 2, 5)]
    [TestCase(-3, 4, 5)]
    public void Triangle_InvalidSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    [TestCase(8, 15, 17)]
    public void Triangle_ValidSides_CreatesTriangleObject(double firstSide, double secondSide, double thirdSide)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        Assert.Multiple(() =>
        {
            Assert.That(triangle.FirstSide, Is.EqualTo(firstSide));
            Assert.That(triangle.SecondSide, Is.EqualTo(secondSide));
            Assert.That(triangle.ThirdSide, Is.EqualTo(thirdSide));
        });
    }

    [TestCase(3, 4, 5, 6)]
    [TestCase(5, 12, 13, 30)]
    [TestCase(8, 15, 17, 60)]
    public void Triangle_GetArea_ReturnsCorrectArea(double firstSide, double secondSide, double thirdSide, double expectedArea)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        
        double actualArea = triangle.GetArea();
        
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(3));
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    [TestCase(8, 15, 17)]
    public void Triangle_IsRight_RightTriangle_ReturnsTrue(double firstSide, double secondSide, double thirdSide)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        
        bool isRightTriangle = triangle.IsRight();
        
        Assert.That(isRightTriangle, Is.True);
    }

    [TestCase(2, 3, 4)]
    [TestCase(7, 10, 12)]
    [TestCase(5, 6, 9)]
    public void Triangle_IsRight_NotRightTriangle_ReturnsFalse(double firstSide, double secondSide, double thirdSide)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        
        bool isRightTriangle = triangle.IsRight();
        
        Assert.That(isRightTriangle, Is.False);
    }
}