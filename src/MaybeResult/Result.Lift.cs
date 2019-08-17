using System;

namespace MaybeResult
{
    public static partial class Result
    {
        public static Result<T3, TError> Lift2<T1, T2, T3, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Func<T1, T2, T3> fn)
        {
            if (result1.IsError) return Result.Error<T3, TError>(result1.Error);
            if (result2.IsError) return Result.Error<T3, TError>(result2.Error);

            return Result.Ok<T3, TError>(fn(result1.Value, result2.Value));
        }

        public static Result<T4, TError> Lift3<T1, T2, T3, T4, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Func<T1, T2, T3, T4> fn)
        {
            if (result1.IsError) return Result.Error<T4, TError>(result1.Error);
            if (result2.IsError) return Result.Error<T4, TError>(result2.Error);
            if (result3.IsError) return Result.Error<T4, TError>(result3.Error);

            return Result.Ok<T4, TError>(fn(result1.Value, result2.Value, result3.Value));
        }

        public static Result<T5, TError> Lift4<T1, T2, T3, T4, T5, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Result<T4, TError> result4,
            Func<T1, T2, T3, T4, T5> fn)
        {
            if (result1.IsError) return Result.Error<T5, TError>(result1.Error);
            if (result2.IsError) return Result.Error<T5, TError>(result2.Error);
            if (result3.IsError) return Result.Error<T5, TError>(result3.Error);
            if (result4.IsError) return Result.Error<T5, TError>(result4.Error);

            return Result.Ok<T5, TError>(fn(result1.Value, result2.Value, result3.Value, result4.Value));
        }

        public static Result<T6, TError> Lift5<T1, T2, T3, T4, T5, T6, TError>(
            this Result<T1, TError> result1,
            Result<T2, TError> result2,
            Result<T3, TError> result3,
            Result<T4, TError> result4,
            Result<T5, TError> result5,
            Func<T1, T2, T3, T4, T5, T6> fn)
        {
            if (result1.IsError) return Result.Error<T6, TError>(result1.Error);
            if (result2.IsError) return Result.Error<T6, TError>(result2.Error);
            if (result3.IsError) return Result.Error<T6, TError>(result3.Error);
            if (result4.IsError) return Result.Error<T6, TError>(result4.Error);
            if (result5.IsError) return Result.Error<T6, TError>(result5.Error);

            return Result.Ok<T6, TError>(fn(result1.Value, result2.Value, result3.Value, result4.Value, result5.Value));
        }
    }
}