using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace DotBox.Api.Filters;

public class ExceptionFilter : IExceptionFilter, IOrderedFilter
{
    public int Order => int.MaxValue;

    public void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult(context.Exception.Message)
        {
            StatusCode = (int)MapExceptionToStatusCode(context.Exception),
            ContentTypes = new MediaTypeCollection
            {
                new MediaTypeHeaderValue(Core.Constants.MediaType.TextPlain)
            }
        };

        context.ExceptionHandled = true;
    }

    internal static HttpStatusCode MapExceptionToStatusCode(Exception e) => e switch
    {
        NotImplementedException =>HttpStatusCode.NotImplemented,

        _ => throw new NotImplementedException(),
    };
}
