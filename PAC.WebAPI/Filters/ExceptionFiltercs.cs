using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using PAC.Domain;

namespace PAC.WebAPI.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ErrorDto errorDto = new ErrorDto();
            errorDto.IsSuccess = false;
            errorDto.Code = 400;
            errorDto.ErrorMessage = context.Exception.Message;

            context.Result = new ObjectResult(errorDto)
            {
                StatusCode = errorDto.Code
            };
        }
    }
}
