using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Week1_HK.Controllers
{
    public abstract class BaseController : Controller
    {
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    if (this.Request.IsAjaxRequest())
        //    {
        //        base.HandleUnknownAction(actionName);
        //    }
        //    else
        //    {
        //        this.RedirectToAction("NotFind", "Home").ExecuteResult(this.ControllerContext);
        //    }

        //}
    }
}