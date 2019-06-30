using MaybeResult.Extensions;
using Xunit;
using static MaybeResult.Tests.Utils;

namespace MaybeResult.Tests
{
    public class ResultBindTest
    {
        [Fact]
        public void Bind_returns_value_when_number_is_non_negative()
        {
            var result = Result.Ok<double, string>(9d);

            var expected = 3d;
            var actual = result.Bind(SquareRoot).ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind_returns_error_when_number_is_negative()
        {
            var result = Result.Ok<double, string>(-1d);

            var expected = "Number is negative";
            var actual = result.Bind(SquareRoot).ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind_returns_error_when_number_has_error()
        {
            var result = Result.Error<double, string>("Number has error");

            var expected = "Number has error";
            var actual = result.Bind(SquareRoot).ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind2_returns_value_when_divisor_is_non_zero()
        {
            var expected = 2d;
            var actual = Result.Bind2(
                Divide,
                Result.Ok<double, string>(6d),
                Result.Ok<double, string>(3d))
                .ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind2_returns_error_when_divisor_is_zero()
        {
            var expected = "Divisor is zero";
            var actual = Result.Bind2(
                Divide,
                Result.Ok<double, string>(1d),
                Result.Ok<double, string>(0d))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind2_returns_error_when_divident_has_error()
        {
            var expected = "Divident has error";
            var actual = Result.Bind2(
                Divide,
                Result.Error<double, string>("Divident has error"),
                Result.Ok<double, string>(0d))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind2_returns_error_when_divisor_has_error()
        {
            var expected = "Divident has error";
            var actual = Result.Bind2(
                Divide,
                Result.Error<double, string>("Divident has error"),
                Result.Error<double, string>("Divisor has error"))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Bind2_returns_first_error_when_divident_and_divisor_have_errors()
        {
            var expected = "Divisor has error";
            var actual = Result.Bind2(
                Divide,
                Result.Ok<double, string>(1d),
                Result.Error<double, string>("Divisor has error"))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }
    }
}