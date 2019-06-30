using MaybeResult.Exceptions;
using MaybeResult.Extensions;
using Xunit;

namespace MaybeResult.Tests
{
    public class MaybeTest
    {
        [Fact]
        public void ValueOrThrow_SomeNumber_ReturnsNumber()
        {
            var maybe = Maybe.Some<int>(1);
            var expected = 1;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueOrThrow_NoneNumber_Throws()
        {
            var maybe = Maybe.None<int>();

            Assert.Throws<ValueDoesNotExistException>(() => maybe.ValueOrThrow);
        }

        [Fact]
        public void ValueOrThrow_SomeNull_ReturnsNull()
        {
            var maybe = Maybe.Some<int?>(null);
            int? expected = null;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Struct_ToMaybe_ReturnsValue()
        {
            var maybe = 1.ToMaybe();

            var expected = 1;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonNullNullableStruct_ToMaybe_ReturnsValue()
        {
            int? nullable = 1;
            var maybe = nullable.ToMaybe<int?>();

            int? expected = 1;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullNullableStruct_ToMaybe_ReturnsNull()
        {
            int? nullable = null;
            var maybe = nullable.ToMaybe<int?>();

            int? expected = null;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonNullObject_ToMaybe_ReturnsValue()
        {
            var maybe = "Value".ToMaybe<string>();

            var expected = "Value";
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullObject_ToMaybe_ReturnsNull()
        {
            string nullable = null;
            var maybe = nullable.ToMaybe<string>();

            string expected = null;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NonNullNullableStruct_ToNonNullMaybe_ReturnsValue()
        {
            int? nullable = 1;
            var maybe = nullable.ToNonNullMaybe();

            var expected = 1;
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullNullableStruct_ToNonNullMaybe_IsNone()
        {
            int? nullable = null;
            var maybe = nullable.ToNonNullMaybe();

            Assert.True(maybe.IsNone);
        }

        [Fact]
        public void NonNullObject_ToNonNullMaybe_ReturnsValue()
        {
            string nullable = "Value";
            var maybe = nullable.ToNonNullMaybe();

            var expected = "Value";
            var actual = maybe.ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullObject_ToNonNullMaybe_IsNone()
        {
            string nullable = null;
            var maybe = nullable.ToNonNullMaybe();

            Assert.True(maybe.IsNone);
        }
    }
}
