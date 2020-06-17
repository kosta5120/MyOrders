﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyOrders
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null ||
         filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                              RouteValueDictionary(new { controller = "Error", action = "Index", area = "" }));
                    //filterContext.Result = new RedirectToRouteResult(new
                    //                          RouteValueDictionary(new { controller = "Orders", action = "Orders", area = "" }));
                }
            }
        }
    }
}