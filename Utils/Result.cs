using System.Diagnostics;

namespace Utils;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public readonly struct Result<TSuccess, TError> where TError : Exception
{
    private readonly TError _error;

    private readonly bool _isError;

    private readonly TSuccess _result;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Result{TResult,TError}" /> struct.
    /// </summary>
    /// <param name="result">The result of the <see cref="Result{TResult,TError}" />.</param>
    private Result(TSuccess result)
    {
        _isError = false;
        _error = default!;
        _result = result;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Result{TResult,TError}" /> struct.
    /// </summary>
    /// <param name="error">The error of the <see cref="Result{TResult,TError}" />.</param>
    private Result(TError error)
    {
        _isError = true;
        _error = error;
        _result = default!;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="TSuccess" /> to <see cref="Result{TResult,TError}" />.
    /// </summary>
    /// <param name="result">The result to store in the <see cref="Result{TResult,TError}" />.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Result<TSuccess, TError>(TSuccess result) => new(result);

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Error" /> to <see cref="Result{TResult,TError}" />.
    /// </summary>
    /// <param name="error">The error to store in the <see cref="Result{TResult,TError}" />.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator Result<TSuccess, TError>(TError error) => new(error);

    public bool TryGetResult(out TSuccess result)
    {
        result = _result;
        return !_isError;
    }

    public bool TryGetError(out TError error)
    {
        error = _error;
        return _isError;
    }

    public static implicit operator TSuccess(Result<TSuccess, TError> result) => result._result;

    public static implicit operator TError(Result<TSuccess, TError> result) => result._error;

    /// <inheritdoc />
    public override string ToString() => $"IsResult={_isError == false}";

    public Result<TSuccess, TError> OnSuccess(Func<TSuccess, Result<TSuccess, TError>> func)
        => _isError ? _error : func(_result);

    public Result<TSuccess, TError> OnSuccess(Action<TSuccess> action)
    {
        if (_isError)
            return this;

        action.Invoke(_result);
        return this;
    }

    public Result<TNextSuccess,TError> OnSuccess<TNextSuccess>(Func<TSuccess, Result<TNextSuccess,TError>> func)
        => _isError ? _error : func(_result);

    public Result<TSuccess, TError> OnFailure(Action<TError> action)
    {
        if (_isError == false)
            return _result;

        action.Invoke(_error);
        return this;
    }

    public Result<TSuccess, TError> OnFailure(Func<TError, Result<TSuccess, TError>> func)
        => _isError == false ? _result : func(_error);

    public Result<TSuccess, TNextError> OnFailure<TNextError>(Func<TError, Result<TSuccess, TNextError>> func)
        where TNextError : Exception
        => _isError == false ? _result : func(_error);

    private string GetDebuggerDisplay()
        => _isError ? $"Error: {_error}" : $"Result: {_result}";
}