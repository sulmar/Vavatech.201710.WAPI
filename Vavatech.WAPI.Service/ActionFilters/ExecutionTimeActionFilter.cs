using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Vavatech.WAPI.Service.ActionFilters
{
    public class ExecutionTimeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;


            actionContext.Request.Properties[actionName] = Stopwatch.StartNew();

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            var stopwatch = actionExecutedContext.Request.Properties[actionName] as Stopwatch;
            if (stopwatch != null)
            {
                stopwatch.Stop();

                // opcjonalnie
                actionExecutedContext.Response.Headers.Add("Execution-time", stopwatch.Elapsed.ToString());

                Trace.WriteLine($"{actionName} elapsed {stopwatch.Elapsed}");
            }
        }
    }
}