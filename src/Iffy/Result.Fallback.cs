using System;

namespace Iffy
{
    public static partial class Result
    {
        public static T ValueOrFallback<T, TError>(this Result<T, TError> result, T fallbackValue)
        {
            return result.IsOk ? result.Value : fallbackValue;
        }

        public static T ValueOrFallback<T, TError>(this Result<T, TError> result, Func<T> fallbackValueFn)
        {
            return result.IsOk ? result.Value : fallbackValueFn();
        }

        public static Result<T, TError> OrFallback<T, TError>(this Result<T, TError> result, T fallbackValue)
        {
            return result.IsOk ? result: Result.Ok<T, TError>(fallbackValue);
        }

        public static Result<T, TError> OrFallback<T, TError>(Result<T, TError> result, Result<T, TError> fallbackResult)
        {
            return result.IsOk ? result : fallbackResult;
        }

        public static Result<T, TError> OrFallback<T, TError>(Result<T, TError> result, Func<T> fallbackValueFn)
        {
            return result.IsOk ? result : Result.Ok<T, TError>(fallbackValueFn());
        }

        public static Result<T, TError> OrFallback<T, TError>(Result<T, TError> result, Func<Result<T, TError>> fallbackResultFn)
        {
            return result.IsOk ? result : fallbackResultFn();
        }
    }
}