using System;

namespace MaybeResult
{
    public static partial class Maybe
    {
        public static Maybe<T3> Lift2<T1, T2, T3>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Func<T1, T2, T3> fn)
        {
            if (maybe1.IsNone || maybe2.IsNone)
            {
                return Maybe.None<T3>();
            }

            return Maybe.Some(fn(maybe1.Value, maybe2.Value));
        }

        public static Maybe<T4> Lift3<T1, T2, T3, T4>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Func<T1, T2, T3, T4> fn)
        {
            if (maybe1.IsNone || maybe2.IsNone || maybe3.IsNone)
            {
                return Maybe.None<T4>();
            }

            return Maybe.Some(fn(maybe1.Value, maybe2.Value, maybe3.Value));
        }

        public static Maybe<T5> Lift4<T1, T2, T3, T4, T5>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4,
            Func<T1, T2, T3, T4, T5> fn)
        {
            if (maybe1.IsNone || maybe2.IsNone || maybe3.IsNone || maybe4.IsNone)
            {
                return Maybe.None<T5>();
            }

            return Maybe.Some(fn(maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value));
        }

        
        public static Maybe<T6> Lift5<T1, T2, T3, T4, T5, T6>(
            this Maybe<T1> maybe1,
            Maybe<T2> maybe2,
            Maybe<T3> maybe3,
            Maybe<T4> maybe4,
            Maybe<T5> maybe5,
            Func<T1, T2, T3, T4, T5, T6> fn)
        {
            if (maybe1.IsNone || maybe2.IsNone || maybe3.IsNone || maybe4.IsNone || maybe5.IsNone)
            {
                return Maybe.None<T6>();
            }

            return Maybe.Some(fn(maybe1.Value, maybe2.Value, maybe3.Value, maybe4.Value, maybe5.Value));
        }
    }
}