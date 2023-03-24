using System.Diagnostics;

namespace Utils
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public readonly struct Either<TResult, TError> where TError : Exception
    {
        private readonly TError _error;

        private readonly bool _isError;

        private readonly TResult _result;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Either{TResult, TError}" /> struct.
        /// </summary>
        /// <param name="result">The result of the <see cref="Either{TResult, TError}" />.</param>
        private Either(TResult result)
        {
            _isError = false;
            _error = default!;
            _result = result;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Either{TResult, TError}" /> struct.
        /// </summary>
        /// <param name="error">The error of the <see cref="Either{TResult, TError}" />.</param>
        private Either(TError error)
        {
            _isError = true;
            _error = error;
            _result = default!;
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="TResult" /> to <see cref="Either{TResult, TError}" />.
        /// </summary>
        /// <param name="result">The result to store in the <see cref="Either{TResult, TError}" />.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Either<TResult, TError>(TResult result) => new(result);

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Error" /> to <see cref="Either{TResult, TError}" />.
        /// </summary>
        /// <param name="error">The error to store in the <see cref="Either{TResult, TError}" />.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Either<TResult, TError>(TError error) => new(error);

        /// <inheritdoc />
        public override string ToString() => $"IsResult={_isError == false}";

        public Either<TResult, TError> OnSuccess(Func<TResult, Either<TResult, TError>> func)
        {
            if (_isError)
            {
                return _error;
            }

            return func(_result);
        }

        public Either<TResult, TError> OnSuccess(Action<TResult> action)
        {
            if (_isError)
            {
                return this;
            }

            action.Invoke(_result);
            return this;
        }

        public Either<TResult, TError> OnFailure(Action<TError> action)
        {
            if (_isError == false)
            {
                return _result;
            }

            action.Invoke(_error);
            return this;
        }

        public Either<TResult, TError> OnFailure(Func<TError, Either<TResult, TError>> func)
        {
            if (_isError == false)
            {
                return _result;
            }

            return func(_error);
        }

        private string GetDebuggerDisplay() => ToString();
    }
}
