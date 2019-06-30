
using System;

namespace MaybeResult.Tests
{
    public static class Utils
    {
        public static int Add1(int number) => number + 1;

        public static int Add(int firstNumber, int secondNumber) => firstNumber + secondNumber;

        public static string ToUpper(string text) => text.ToUpper();

        public static Result<double, string> SquareRoot(double number)
        {
            if (number < 0d)
            {
                return Result.Error<double, string>("Number is negative");
            }

            return Result.Ok<double, string>(Math.Sqrt(number));
        }

        public static Result<double, string> Divide(double divident, double divisor)
        {
            if (divisor == 0d)
            {
                return Result.Error<double, string>("Divisor is zero");
            }

            return Result.Ok<double, string>(divident / divisor);
        }
    }
}