using MovieShop.MVC.Utils;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Filters
{
    public class MovieShopExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            var model = new HandleErrorInfo(filterContext.Exception,controllerName, actionName);

            var dateTimeExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            var stackTrace = filterContext.Exception.StackTrace;
            var exceptionMessage = filterContext.Exception.Message;
            var innerException = filterContext.Exception.InnerException;
            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;//used when an exception happens
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;



            //use Nlog to write the info to text files.
            //send out emails to the dev team(MailKit library download from Nuget)

            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error(filterContext.Exception, "Error occured in Home controller Index Action");
            LogManager.Shutdown();

            var Email = new EmailInform();
            Email.Send();

            base.OnException(filterContext);
        }
    }
}