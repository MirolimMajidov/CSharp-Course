using SOLID.SRP;

namespace SOLID.OCP
{
    // Bad example
    public class CircleBad
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class SquareBad
    {
        public double SideLength { get; set; }

        public double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }


    // Good example
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }


    //Second good example 

    public static class EmailServiceExtensions
    {
        public static void SendEmail(this EmailService emailService, User user, string message)
        {
            emailService.SendEmail(user.EmailAddress, message);
        }
    }
}
