using System;

namespace MaybeResult
{
    public static partial class Result
    {
        public static Result<T2, TError> Map<T1, T2, TError>(
            Func<T1, T2> fn,
            Result<T1, TError> result)
        {
            return result.IsOk
                ? Result.Ok<T2, TError>(fn(result.Value))
                : Result.Error<T2, TError>(result.ErrorOrThrow);
        }

        public static Result<T, TError2> MapError<T, TError1, TError2>(
            Func<TError1, TError2> fn,
            Result<T, TError1> result)
        {
            return result.IsOk
                ? Result.Ok<T, TError2>(result.Value)
                : Result.Error<T, TError2>(fn(result.Error));
        }

        public static Result<T3, TError> Lift2<T1, T2, T3, TError>(
            Func<T1, T2, T3> fn,
            Result<T1, TError> result1,
            Result<T2, TError> result2)
        {
            if (result1.IsError) return Result.Error<T3, TError>(result1.Error);
            if (result2.IsError) return Result.Error<T3, TError>(result2.Error);

            return Result.Ok<T3, TError>(fn(result1.Value, result2.Value));
        }
    }
}