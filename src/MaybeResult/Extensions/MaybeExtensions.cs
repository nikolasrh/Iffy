using System;

namespace MaybeResult.Extensions
{
    public static class MaybeExtensions
    {
        public static Maybe<T2> Map<T1, T2>(this Maybe<T1> maybe, Func<T1, T2> fn)
        {
            return Maybe.Map(fn, maybe);
        }

        public static Maybe<T> Join<T>(this Maybe<Maybe<T>> maybe)
        {
            return Maybe.Join(maybe);
        }

        public static Maybe<T2> Bind<T1, T2>(this Maybe<T1> maybe, Func<T1, Maybe<T2>> fn)
        {
            return Maybe.Bind(fn, maybe);
        }

        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return Maybe.Some<T>(value);
        }

        public static Maybe<T> ToNonNullMaybe<T>(this T? value) where T : struct
        {
            return value == null
                ? Maybe.None<T>()
                : Maybe.Some<T>(value.GetValueOrDefault());
        }

        public static Maybe<T> ToNonNullMaybe<T>(this T value) where T : class
        {
            return value == null
                ? Maybe.None<T>()
                : Maybe.Some<T>(value);
        }
    }
}