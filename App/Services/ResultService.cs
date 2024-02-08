
using FluentValidation.Results;

namespace App.Services;

public class ResultService
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }

    public static ResultService RequestError(string message, ValidationResult validationResult)
    {
        return new ResultService
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
        };
    }
    
    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
    {
        return new ResultService<T>
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
        };
    }

    public static ResultService Fail(string messagem) => new ResultService { IsSuccess = false, Message = messagem };
    public static ResultService<T> Fail<T>(string messagem) => new ResultService<T> { IsSuccess = false, Message = messagem };

    public static ResultService Ok() => new ResultService { IsSuccess = true };
    public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data };


}
public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
