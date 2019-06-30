using System;
using MaybeResult.Extensions;

namespace MaybeResult
{
    public static partial class Maybe
    {
        public static Maybe<T2> Bind<T1, T2>(
            Func<T1, Maybe<T2>> fn,
            Maybe<T1> result)
        {
            return Map(fn, result).Join();
        }

        public static Maybe<T3> Bind2<T1, T2, T3>(
            Func<T1, T2, Maybe<T3>> fn,
            Maybe<T1> maybe1,
            Maybe<T2> maybe2)
        {
            return Lift2(fn, maybe1, maybe2).Join();
        }
    }
}