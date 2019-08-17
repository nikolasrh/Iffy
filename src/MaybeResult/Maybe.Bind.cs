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

        public static Maybe<T4> Bind3<T1, T2, T3, T4>(
            Func<T1, T2, T3, Maybe<T4>> fn,
            Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3)
        {
            return Lift3(fn, maybe1, maybe2, maybe3).Join();
        }

        public static Maybe<T5> Bind4<T1, T2, T3, T4, T5>(
            Func<T1, T2, T3, T4, Maybe<T5>> fn,
            Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4)
        {
            return Lift4(fn, maybe1, maybe2, maybe3, maybe4).Join();
        }

        public static Maybe<T6> Bind5<T1, T2, T3, T4, T5, T6>(
            Func<T1, T2, T3, T4, T5, Maybe<T6>> fn,
            Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4,
            Maybe<T5> maybe5)
        {
            return Lift5(fn, maybe1, maybe2, maybe3, maybe4, maybe5).Join();
        }
    }
}