using System;
using MaybeResult.Extensions;

namespace MaybeResult
{
    public static partial class Result
    {
        public static Result<T2, TError> Bind<T1, T2, TError>(
            Func<T1, Result<T2, TError>> fn,
            Result<T1, TError> result)
        {
            return Map(fn, result).Join();
        }

        public static Result<T3, TError> Bind2<T1, T2, T3, TError>(
            Func<T1, T2, Result<T3, TError>> fn,
            Result<T1, TError> result1,
            Result<T2, TError> result2)
        {
            return Lift2(fn, result1, result2).Join();
        }
    }
}

