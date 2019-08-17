using System;

namespace MaybeResult
{
    public static partial class Maybe
    {
        public static Maybe<T2> Bind<T1, T2>(
            this Maybe<T1> maybe,
            Func<T1, Maybe<T2>> fn)
        {
            return maybe.Map(fn).Join();
        }

        public static Maybe<T3> Bind2<T1, T2, T3>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Func<T1, T2, Maybe<T3>> fn)
        {
            return Lift2(maybe1, maybe2, fn).Join();
        }

        public static Maybe<T4> Bind3<T1, T2, T3, T4>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Func<T1, T2, T3, Maybe<T4>> fn)
        {
            return Lift3(maybe1, maybe2, maybe3, fn).Join();
        }

        public static Maybe<T5> Bind4<T1, T2, T3, T4, T5>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4,
            Func<T1, T2, T3, T4, Maybe<T5>> fn)
        {
            return Lift4(maybe1, maybe2, maybe3, maybe4, fn).Join();
        }

        public static Maybe<T6> Bind5<T1, T2, T3, T4, T5, T6>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4,
            Maybe<T5> maybe5,
            Func<T1, T2, T3, T4, T5, Maybe<T6>> fn)
        {
            return Lift5(maybe1, maybe2, maybe3, maybe4, maybe5, fn).Join();
        }
    }
}