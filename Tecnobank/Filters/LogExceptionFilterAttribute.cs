using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Tecnobank.Filters
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(actionExecutedContext.Exception.Message.ToString(), Encoding.UTF8, "application/json"),
                StatusCode = status
            };

            base.OnException(actionExecutedContext);

        }
    }
}