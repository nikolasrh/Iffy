using System;

namespace MaybeResult
{
    public static partial class Result
    {
        public static Result<T2, TError> Bind<T1, T2, TError>(
            this Result<T1, TError> result,
            Func<T1, Result<T2, TError>> fn)
        {
            return result.Map(fn).Join();
        }

        public static Result<T3, TError> Bind2<T1, T2, T3, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Func<T1, T2, Result<T3, TError>> fn)
        {
            return Lift2(result1, result2, fn).Join();
        }

        public static Result<T4, TError> Bind3<T1, T2, T3, T4, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Func<T1, T2, T3, Result<T4, TError>> fn)
        {
            return Lift3(result1, result2, result3, fn).Join();
        }

        public static Result<T5, TError> Bind4<T1, T2, T3, T4, T5, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Result<T4, TError> result4,
            Func<T1, T2, T3, T4, Result<T5, TError>> fn)
        {
            return Lift4(result1, result2, result3, result4, fn).Join();
        }

        public static Result<T6, TError> Bind5<T1, T2, T3, T4, T5, T6, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Result<T4, TError> result4,
            Result<T5, TError> result5,
            Func<T1, T2, T3, T4, T5, Result<T6, TError>> fn)
        {
            return Lift5(result1, result2, result3, result4, result5, fn).Join();
        }
    }
}

