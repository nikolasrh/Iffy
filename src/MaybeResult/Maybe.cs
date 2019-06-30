using System;
using MaybeResult.Exceptions;

namespace MaybeResult
{
    public static partial class Maybe
    {
        public static Maybe<T> Some<T>(T value)
        {
            return new Maybe<T>(value, true);
        }

        public static Maybe<T> None<T>()
        {
            return new Maybe<T>();
        }

        public static Maybe<T> Join<T>(Maybe<Maybe<T>> maybe)
        {
            return maybe.IsSome ? maybe.Value : Maybe.None<T>();
        }
    }

    public struct Maybe<T>
    {
        private readonly T value;
        private readonly bool hasValue;

        internal Maybe(T value = default(T), bool hasValue = false)
        {
            this.value = value;
            this.hasValue = hasValue;
        }

        internal T Value => value;

        public bool IsSome => hasValue;

        public bool IsNone => !hasValue;

        public T ValueOrThrow => IsSome ? value : throw new ValueDoesNotExistException();

        public T ValueOrFallback(T fallbackValue) => IsSome ? value : fallbackValue;

        public T ValueOrFallback(Func<T> fallbackValueFn) => IsSome ? value : fallbackValueFn();

        public Maybe<T> OrFallback(T fallbackValue) => Maybe.Some<T>(fallbackValue);

        public Maybe<T> OrFallback(Func<T> fallbackValueFn) => Maybe.Some<T>(fallbackValueFn());

        public Maybe<T> OrFallback(Maybe<T> fallbackResult) => fallbackResult;

        public Maybe<T> OrFallback(Func<Maybe<T>> fallbackResultFn) => fallbackResultFn();
    }
}