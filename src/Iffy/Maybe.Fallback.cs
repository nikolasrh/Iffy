using System;

namespace Iffy
{
    public static partial class Maybe
    {
        public static T ValueOrFallback<T>(this Maybe<T> maybe, T fallbackValue)
        {
            return maybe.IsSome ? maybe.Value : fallbackValue;
        }

        public static T ValueOrFallback<T>(this Maybe<T> maybe, Func<T> fallbackValueFn)
        {
            return maybe.IsSome ? maybe.Value : fallbackValueFn();
        }

        public static Maybe<T> OrFallback<T>(this Maybe<T> maybe, T fallbackValue)
        {
            return maybe.IsSome ? maybe: Maybe.Some(fallbackValue);
        }

        public static Maybe<T> OrFallback<T>(Maybe<T> maybe, Maybe<T> fallbackMaybe)
        {
            return maybe.IsSome ? maybe : fallbackMaybe;
        }

        public static Maybe<T> OrFallback<T>(Maybe<T> maybe, Func<T> fallbackValueFn)
        {
            return maybe.IsSome ? maybe : Maybe.Some(fallbackValueFn());
        }

        public static Maybe<T> OrFallback<T>(Maybe<T> maybe, Func<Maybe<T>> fallbackMaybeFn)
        {
            return maybe.IsSome ? maybe : fallbackMaybeFn();
        }
    }
}