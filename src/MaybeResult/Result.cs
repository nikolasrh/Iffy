using System;
using MaybeResult.Exceptions;

namespace MaybeResult
{
    public static partial class Result
    {
        public static Result<T, TError> Ok<T, TError>(T value)
        {
            return new Result<T, TError>(value, hasValue: true);
        }

        public static Result<T, TError> Error<T, TError>(TError error)
        {
            return new Result<T, TError>(error: error);
        }

        public static Result<T, TError> Join<T, TError>(Result<Result<T, TError>, TError> result)
        {
            return result.IsOk
                ? result.Value
                : Result.Error<T, TError>(result.ErrorOrThrow);
        }
    }

    public struct Result<T, TError>
    {
        private readonly T value;
        private readonly TError error;
        private readonly bool hasValue;

        internal Result(T value = default(T), TError error = default(TError), bool hasValue = false)
        {
            this.value = value;
            this.error = error;
            this.hasValue = hasValue;
        }

        internal T Value => value;

        internal TError Error => error;

        public bool IsOk => hasValue;

        public bool IsError => !hasValue;

        public T ValueOrThrow => IsOk ? value : throw new ValueDoesNotExistException();

        public TError ErrorOrThrow => IsError ? error : throw new ErrorDoesNotExistException();

        public T ValueOrFallback(T fallbackValue) => IsOk ? value : fallbackValue;

        public T ValueOrFallback(Func<T> fallbackValueFn) => IsOk ? value : fallbackValueFn();

        public Result<T, TError> OrFallback(T fallbackValue) => Result.Ok<T, TError>(fallbackValue);

        public Result<T, TError> OrFallback(Func<T> fallbackValueFn) => Result.Ok<T, TError>(fallbackValueFn());

        public Result<T, TError> OrFallback(Result<T, TError> fallbackResult) => fallbackResult;

        public Result<T, TError> OrFallback(Func<Result<T, TError>> fallbackResultFn) => fallbackResultFn();
    }
}
