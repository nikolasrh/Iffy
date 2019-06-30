using MaybeResult.Exceptions;
using MaybeResult.Extensions;
using Xunit;

namespace MaybeResult.Tests
{
    public class ResultTest
    {
        [Fact]
        public void Ok_Struct_IsOk()
        {
            var result = Result.Ok<int, string>(1);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void Ok_NonNullNullableStruct_IsOk()
        {
            int? nullable = 1;
            var result = Result.Ok<int?, string>(nullable);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void Ok_NullNullableStruct_IsOk()
        {
            var result = Result.Ok<int?, string>(null);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void Ok_NonNullObject_IsOk()
        {
            var result = Result.Ok<string, int>(null);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void Ok_NullObject_IsOk()
        {
            var result = Result.Ok<int?, string>(null);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void Error_NonNull_IsError()
        {
            var result = Result.Error<int, string>(null);
            string expected = null;
            var actual = result.ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Error_Null_IsError()
        {
            var result = Result.Error<int, string>(null);
            string expected = null;
            var actual = result.ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueOrThrow_OkNumber_ReturnsNumber()
        {
            var result = Result.Ok<int, string>(1);
            var expected = 1;
            var actual = result.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueOrThrow_ErrorNumber_Throws()
        {
            var result = Result.Error<int, string>("Error");

            Assert.Throws<ValueDoesNotExistException>(() => result.ValueOrThrow);
        }

        [Fact]
        public void ErrorOrThrow_ErrorNumber_ReturnsError()
        {
            var result = Result.Error<int, string>("Error");
            var expected = "Error";
            var actual = result.ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ErrorOrThrow_OkNumber_Throws()
        {
            var result = Result.Ok<int, string>(1);

            Assert.Throws<ErrorDoesNotExistException>(() => result.ErrorOrThrow);
        }

        [Fact]
        public void ToResult_Number_IsOk()
        {
            var result = 1.ToResult<int, string>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToResult_Struct_IsOk()
        {
            var result = 1.ToResult<int, string>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToResult_NonNullNullableStruct_IsOk()
        {
            int? nullable = 1;
            var result = nullable.ToResult<int?, string>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToResult_NullNullableStruct_IsOk()
        {
            int? nullable = null;
            var result = nullable.ToResult<int?, string>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToResult_NonNullObject_IsOk()
        {
            var result = "Value".ToResult<string, int>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToResult_NullObject_IsOk()
        {
            string nullable = null;
            var result = nullable.ToResult<string, int>();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void ToNonNullResult_NonNullNullableStruct_IsOk()
        {
            int? nullable = 1;
            var result = nullable.ToNonNullResult("Error");

            var expected = 1;
            var actual = result.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullNullableStruct_ToNonNullResult_ReturnsError()
        {
            int? nullable = null;
            var result = nullable.ToNonNullResult("Error");

            var expected = "Error";
            var actual = result.ErrorOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonNullObject_ToNonNullResult_ReturnsValue()
        {
            string nullable = "Value";
            var result = nullable.ToNonNullResult("Error");

            var expected = "Value";
            var actual = result.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullObject_ToNonNullResult_ReturnsError()
        {
            string nullable = null;
            var result = nullable.ToNonNullResult("Error");

            var expected = "Error";
            var actual = result.ErrorOrThrow;

            Assert.Equal(expected, actual);
        }
    }
}
