using MaybeResult.Extensions;
using Xunit;
using static MaybeResult.Tests.Utils;

namespace MaybeResult.Tests
{
    public class ResultMapTest
    {
        [Fact]
        public void MapAdd1_ResultOk_AddsOneToValue()
        {
            var result = Result.Ok<int, string>(1);

            var expected = 2;
            var actual = result.Map(Add1).ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MapAdd1_ResultError_ReturnsError()
        {
            var result = Result.Error<int, string>("Number has error");

            var expected = "Number has error";
            var actual = result.Map(Add1).ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MapErrorToUpper_ResultOk_DoesNothing()
        {
            var result = Result.Ok<int, string>(1);

            var expected = 1;
            var actual = result.MapError(ToUpper).ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MapErrorToUpper_ResultError_ReturnsUppercaseError()
        {
            var result = Result.Error<int, string>("Error");

            var expected = "ERROR";
            var actual = result.MapError(ToUpper).ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Lift2Add_TwoResultOk_AddsValues()
        {
            var expected = 3;
            var actual = Result.Lift2(
                Add,
                Result.Ok<int, string>(1),
                Result.Ok<int, string>(2))
                .ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Lift2Add_FirstResultError_ReturnsError()
        {
            var expected = "First number has error";
            var actual = Result.Lift2(
                Add,
                Result.Error<int, string>("First number has error"),
                Result.Ok<int, string>(1))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Lift2Add_SecondResultError_ReturnsError()
        {
            var expected = "Second number has error";
            var actual = Result.Lift2(
                Add,
                Result.Ok<int, string>(1),
                Result.Error<int, string>("Second number has error"))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Lift2Add_TwoResultError_ReturnsFirstError()
        {
            var expected = "First number has error";
            var actual = Result.Lift2(
                Add,
                Result.Error<int, string>("First number has error"),
                Result.Error<int, string>("Second number has error"))
                .ErrorOrThrow;

            Assert.Equal(expected, actual);
        }
    }
}