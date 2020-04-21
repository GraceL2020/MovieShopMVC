using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC.Filters
{
    public class LogActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogSomeInfo("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            LogSomeInfo("OnActionExecuting", filterContext.RouteData);

        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            LogSomeInfo("OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //base.OnResultExecuting(filterContext);
            LogSomeInfo("OnResultExecuting", filterContext.RouteData);
        }

        private void LogSomeInfo(String methodName, RouteData routeData)
        {
            //can log this info to files using 3rd logging framework
            //e.g. Nlog,SeriLog,Log4net
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
        }
    }
}