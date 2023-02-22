
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace SampleProduct.Application.Common.Behaviours;

public class CustomActionResult : IActionResult
{
    private readonly BaseResponseDto _baseResponseDto;

    public CustomActionResult(BaseResponseDto baseResponseDto)
    { _baseResponseDto = baseResponseDto; }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_baseResponseDto);

        if (_baseResponseDto.Status == ResponseStatus.Success)
        {
            objectResult.StatusCode = (int)HttpStatusCode.OK;
        }
        else if (_baseResponseDto.Status == ResponseStatus.NotFound)
        {
            objectResult.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else
        {
            objectResult.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        await objectResult.ExecuteResultAsync(context);
    }
}

