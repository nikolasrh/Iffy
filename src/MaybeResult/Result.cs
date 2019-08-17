using System;
using MaybeResult.Exceptions;

namespace MaybeResult
{
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
    }

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

        public static Result<T, TError> Create<T, TError>(T value, TError error)
        {
            return value == null
                ? Error<T, TError>(error)
                : Ok<T, TError>(value);
        }

        public static Result<T, TError> Create<T, TError>(T? value, TError error) where T : struct
        {
            return value.HasValue
                ? Ok<T, TError>(value.GetValueOrDefault())
                : Error<T, TError>(error);
        }

        public static Result<T, TError> Join<T, TError>(this Result<Result<T, TError>, TError> result)
        {
            return result.IsOk
                ? result.Value
                : Result.Error<T, TError>(result.ErrorOrThrow);
        }

        public static Result<T2, TError> Map<T1, T2, TError>(
            this Result<T1, TError> result,
            Func<T1, T2> fn)
        {
            return result.IsOk
                ? Result.Ok<T2, TError>(fn(result.Value))
                : Result.Error<T2, TError>(result.Error);
        }

        public static Result<T, TError2> MapError<T, TError1, TError2>(
            this Result<T, TError1> result,
            Func<TError1, TError2> fn)
        {
            return result.IsOk
                ? Result.Ok<T, TError2>(result.Value)
                : Result.Error<T, TError2>(fn(result.Error));
        }

        public static Result<T, TError> Filter<T, TError>(
            this Result<T, TError> result,
            TError error,
            Func<T, Boolean> fn)
        {
            return result.IsOk && fn(result.Value)
                ? result
                : Result.Error<T, TError>(error);
        }
    }
}
