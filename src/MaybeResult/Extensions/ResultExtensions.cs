using System;

namespace MaybeResult.Extensions
{
    public static class ResultExtensions
    {
        public static Result<T2, TError> Map<T1, T2, TError>(
            this Result<T1, TError> result,
            Func<T1, T2> fn)
        {
            return Result.Map(fn, result);
        }

        public static Result<T, TError2> MapError<T, TError1, TError2>(
            this Result<T, TError1> result,
            Func<TError1, TError2> fn)
        {
            return Result.MapError(fn, result);
        }

        public static Result<T, TError> Join<T, TError>(
            this Result<Result<T, TError>, TError> result)
        {
            return Result.Join(result);
        }

        public static Result<T2, TError> Bind<T1, T2, TError>(
            this Result<T1, TError> result, Func<T1, Result<T2, TError>> fn)
        {
            return Result.Bind(fn, result);
        }

        public static Result<T, TError> ToResult<T, TError>(this T value)
        {
            return Result.Ok<T, TError>(value);
        }

        public static Result<T, TError> ToNonNullResult<T, TError>(this T? value, TError error) where T : struct
        {
            return value == null
                ? Result.Error<T, TError>(error)
                : Result.Ok<T, TError>(value.GetValueOrDefault());
        }

        public static Result<T, TError> ToNonNullResult<T, TError>(this T value, TError error) where T : class
        {
            return value == null
                ? Result.Error<T, TError>(error)
                : Result.Ok<T, TError>(value);
        }
    }
}