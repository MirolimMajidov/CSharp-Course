using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BankManagementSystem.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            object messageInfo = null;
#if DEBUG
            messageInfo = new
            {
                errorMessage = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            };
#else
            messageInfo = new
            {
                errorMessage = "Internal server error",
                stackTrace = ""
            };
#endif


            context.Result = new JsonResult(messageInfo);
        }
    }
}
