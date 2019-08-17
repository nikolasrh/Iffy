using System;
using MaybeResult.Exceptions;

namespace MaybeResult
{
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
    }

    public static partial class Maybe
    {
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value, true);

        public static Maybe<T> None<T>() => new Maybe<T>();

        public static Maybe<T> Create<T>(T value)
        {
            return value == null
                ? None<T>()
                : Some(value);
        }

        public static Maybe<T> Create<T>(T? value) where T : struct
        {
            return value.HasValue
                ? Some(value.GetValueOrDefault())
                : None<T>();
        }

        public static Maybe<T> Join<T>(this Maybe<Maybe<T>> maybe)
        {
            return maybe.IsSome ? maybe.Value : Maybe.None<T>();
        }

        public static Maybe<T2> Map<T1, T2>(this Maybe<T1> maybe, Func<T1, T2> fn)
        {
            return maybe.IsSome ? Maybe.Some(fn(maybe.Value)) : Maybe.None<T2>();
        }

        public static Maybe<T> Filter<T>(this Maybe<T> maybe, Func<T, Boolean> fn)
        {
            return maybe.IsSome && fn(maybe.Value) ? maybe : Maybe.None<T>();
        }
    }
}