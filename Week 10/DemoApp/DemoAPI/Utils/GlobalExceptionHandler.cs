using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace DemoAPI.Utils
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred.");
        }
    }
}