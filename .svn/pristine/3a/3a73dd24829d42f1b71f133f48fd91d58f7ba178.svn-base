using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http.Filters;
using VYSA.WebApi.Controllers;
using VYSA.WebApi.Extensions;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            if (exception == null) return;

            //build Additional Info String here
            var controller = (BaseController)context.ActionContext.ControllerContext.Controller;

            var email = controller.GetEmail();
            var logService = new LogService();
            var additionalInfo = string.Format("email: {0}", email);
            additionalInfo += exception.GetBaseException();
            var exceptionId = logService.LogError(exception, additionalInfo, true, true, email);

            context.Response = context.Request
                .CreateErrorResponse(HttpStatusCode.InternalServerError,
                string.Format("There has been an internal server error: {0}.", exception.Message));

        }
    }
}