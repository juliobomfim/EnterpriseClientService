using EnterpriseClientService.Domain.Interfaces.Models;

namespace EnterpriseClientService.Domain.Models
{
    public class Result : IResult
    {
        public Result() { }

        public string Message { get; set; }
        public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public bool Succeeded { get; set; } = false;

        public static IResult Fail() => new Result { Message = "fail to process your requisition." };
        public static IResult Fail(string property, string errors) => new Result { Errors = new Dictionary<string, string> { { property, errors } } };
        public static IResult Fail(IDictionary<string, string> errors) => new Result { Errors = errors };
        public static IResult Fail(string message) => new Result { Message = message };
        public static Task<IResult> FailAsync() => Task.FromResult(Fail());
        public static Task<IResult> FailAsync(string property, string error) => Task.FromResult(Fail(property, error));
        public static Task<IResult> FailAsync(IDictionary<string, string> errors) => Task.FromResult(Fail(errors));
        public static Task<IResult> FailAsync(string message) => Task.FromResult(Fail(message));

        public static IResult Success() => new Result { Succeeded = true, Message = "Success!" };
        public static IResult Success(string message) => new Result { Succeeded = true, Message = message ?? "Success!" };
        public static Task<IResult> SuccessAsync() => Task.FromResult(Success());
        public static Task<IResult> SuccessAsync(string message) => Task.FromResult(Success(message));
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result() { }

        public T Data { get; set; }

        public new static Result<T> Fail() => new Result<T> { Message = "fail to process your requisition." };
        public new static Result<T> Fail(string property, string error) => new Result<T> { Errors = new Dictionary<string, string> { { property, error } } };
        public new static Result<T> Fail(IDictionary<string, string> errors) => new Result<T> { Errors = errors };
        public new static Result<T> Fail(string message) => new Result<T> { Message = message };
        public new static Task<Result<T>> FailAsync() => Task.FromResult(Fail());
        public new static Task<Result<T>> FailAsync(string property, string error) => Task.FromResult(Fail(new Dictionary<string, string> { { property, error } }));
        public new static Task<Result<T>> FailAsync(IDictionary<string, string> errors) => Task.FromResult(Fail(errors));
        public new static Task<Result<T>> FailAsync(string message) => Task.FromResult(Fail(message));

        public new static Result<T> Success() => new Result<T> { Succeeded = true, Message = "Success!" };
        public new static Result<T> Success(string message) => new Result<T> { Succeeded = true, Message = message ?? "Success!" };
        public static Result<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };
        public static Result<T> Success(T data, string message) => new Result<T> { Succeeded = true, Data = data, Message = message ?? "Success!" };
        public new static Task<Result<T>> SuccessAsync() => Task.FromResult(Success());
        public new static Task<Result<T>> SuccessAsync(string message) => Task.FromResult(Success(message));
        public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult(Success(data));
        public static Task<Result<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));
    }

}
