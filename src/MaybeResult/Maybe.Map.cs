using System;

namespace MaybeResult
{
    public static partial class Maybe
    {
        public static Maybe<T2> Map<T1, T2>(
            Func<T1, T2> fn,
            Maybe<T1> maybe)
        {
            return maybe.IsSome
                ? Maybe.Some<T2>(fn(maybe.Value))
                : Maybe.None<T2>();
        }

        public static Maybe<T3> Lift2<T1, T2, T3>(
            Func<T1, T2, T3> fn,
            Maybe<T1> maybe1,
            Maybe<T2> maybe2)
        {
            if (maybe1.IsNone || maybe2.IsNone)
            {
                return Maybe.None<T3>();
            }

            return Maybe.Some<T3>(fn(maybe1.Value, maybe2.Value));
        }
    }
}