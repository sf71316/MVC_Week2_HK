using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Week1_HK.ActionFilter
{
    public sealed class IDFilterAttribute : ActionFilterAttribute
    {

        public IDFilterAttribute()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = filterContext.HttpContext.Request.QueryString["id"];
            int _id = 0;
            if (int.TryParse(id, out _id))
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }


    }
}