using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Core.Web.Mvc.Filters
{
    /// <summary>
    /// https://stackoverflow.com/questions/43728142/mvc-clear-cache-after-certain-time-of-day
    /// </summary>
    public class NoCache : ActionFilterAttribute
    {
        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //    filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
        //    filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //    filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    filterContext.HttpContext.Response.Cache.SetNoStore();
        //
        //    base.OnResultExecuting(filterContext);
        //}
    }

    ///https://stackoverflow.com/questions/19315742/after-logout-if-browser-back-button-press-then-it-go-back-last-screen
    //public class NoCacheAttribute : ActionFilterAttribute
    //{
    //    public override void OnResultExecuting(ResultExecutingContext filterContext)
    //    {
    //        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
    //        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
    //        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        filterContext.HttpContext.Response.Cache.SetNoStore();
    //
    //        base.OnResultExecuting(filterContext);
    //    }
    //}
}
