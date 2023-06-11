using AreaCalculator.Utils;

namespace AreaCalculator.Shapes;

public class Triangle : IShape
{
    public double FirstSide { get; }
    public double SecondSide { get; }
    public double ThirdSide { get; }

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        if (!IsValid(firstSide, secondSide, thirdSide))
            throw new ArgumentException("Invalid triangle sides");
        
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
    }

    private bool IsValid(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            return false;
        
        return firstSide + secondSide > thirdSide
               && firstSide + thirdSide > secondSide
               && secondSide + thirdSide > firstSide;
    }

    public double GetArea()
    {
        var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) 
                                       * (semiPerimeter - SecondSide) 
                                       * (semiPerimeter - ThirdSide));
    }

    public bool IsRight()
    {
        var firstSideSquare = FirstSide * FirstSide;
        var secondSideSquare = SecondSide * SecondSide;
        var thirdSideSquare = ThirdSide * ThirdSide;

        return Math.Abs(firstSideSquare + secondSideSquare - thirdSideSquare) < Constants.Tolerance 
               || Math.Abs(firstSideSquare + thirdSideSquare - secondSideSquare) < Constants.Tolerance 
               || Math.Abs(secondSideSquare + thirdSideSquare - firstSideSquare) < Constants.Tolerance;
    }
}