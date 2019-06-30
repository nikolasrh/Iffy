using MaybeResult.Extensions;
using Xunit;
using static MaybeResult.Tests.Utils;

namespace MaybeResult.Tests
{
    public class MaybeMapTest
    {
        [Fact]
        public void MapAdd1_MaybeSome_AddsOneToValue()
        {
            var maybe = Maybe.Some<int>(1);

            var expected = 2;
            var actual = maybe.Map(Add1).ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MapAdd1_MaybeNone_DoesNothing()
        {
            var maybe = Maybe.None<int>();

            var isNoneBeforeMap = maybe.IsNone;
            var isNoneAfterMap = maybe.Map(Add1).IsNone;

            Assert.True(isNoneBeforeMap);
            Assert.True(isNoneAfterMap);
        }

        [Fact]
        public void Lift2Add_TwoMaybeSome_AddsValues()
        {
            var expected = 3;
            var actual = Maybe.Lift2(
                Add,
                Maybe.Some<int>(1),
                Maybe.Some<int>(2))
                .ValueOrThrow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Lift2Add_FirstMaybeNone_DoesNothing()
        {
            var isNoneAfterMap = Maybe.Lift2(
                Add,
                Maybe.None<int>(),
                Maybe.Some<int>(2))
                .IsNone;

            Assert.True(isNoneAfterMap);
        }

        [Fact]
        public void Lift2Add_SecondMaybeNone_DoesNothing()
        {
            var isNoneAfterMap = Maybe.Lift2(
                Add,
                Maybe.Some<int>(2),
                Maybe.None<int>())
                .IsNone;

            Assert.True(isNoneAfterMap);
        }

        [Fact]
        public void Lift2Add_TwoMaybeNone_DoesNothing()
        {
            var isNoneAfterMap = Maybe.Lift2(
                Add,
                Maybe.None<int>(),
                Maybe.None<int>())
                .IsNone;

            Assert.True(isNoneAfterMap);
        }
    }
}