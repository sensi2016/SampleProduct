using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProduct.Application.Models;

public interface IBaseResponse<T>
{
    ResponseStatus Status { get; set; }
    string Message { get; set; }
    object Errors { get; set; }
    T Data { get; set; }
}

public class BaseResponseDto<T> : IBaseResponse<T>
{
    public ResponseStatus Status { get; set; }
    public string Message { get; set; }
    public object Errors { get; set; }
    public T Data { get; set; }
    public static BaseResponseDto<T> Success(string message)
    {
        return new BaseResponseDto<T>
        {
            Message = message,
            Status = ResponseStatus.Success
        };
    }

    public static BaseResponseDto<T> NoTValid(string message)
    {
        return new BaseResponseDto<T>
        {
            Message = message,
            Status = ResponseStatus.NotValid
        };
    }

    public static BaseResponseDto<T> Unknow(string message)
    {
        return new BaseResponseDto<T>
        {
            Message = message,
            Status = ResponseStatus.Unknow
        };
    }

    public static BaseResponseDto<T> Fail(string message)
    {
        return new BaseResponseDto<T>
        {
            Message = message,
            Status = ResponseStatus.Fail
        };
    }

    public static BaseResponseDto<T> NotFound(string message)
    {
        return new BaseResponseDto<T>
        {
            Message = message,
            Status = ResponseStatus.NotFound
        };
    }
}

public class BaseResponseDto : BaseResponseDto<object>
{
}
public enum ResponseStatus
{
    Unknow,
    Fail,
    Success,
    NotValid,
    NotFound
}


