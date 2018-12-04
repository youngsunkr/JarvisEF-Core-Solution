using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc.Filters;

namespace JarvisEF.DotnetCore.Web.Mvc.Filters
{
    ///https://stackoverflow.com/questions/19315742/after-logout-if-browser-back-button-press-then-it-go-back-last-screen
    public class NoCacheAttribute : ActionFilterAttribute
    {
        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //    filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
        //    filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    filterContext.HttpContext.Response.Cache.SetNoStore();
        //
        //    base.OnResultExecuting(filterContext);
        //
        //
        //}
    }
}
