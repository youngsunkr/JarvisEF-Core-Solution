using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.DotnetCore.Web.Mvc.Filters
{
    public class LoginFilter : IActionFilter
    {
        public bool IsLogin = false;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (IsLogin) return;

            //var request = HttpContext.Current.Request;

            //if (!request.IsAuthenticated)
            //{
            //    string redirectUrl = "/Login/LoginGate?returnUrl={0}";

            //    if (request.Url == null)
            //    {
            //        redirectUrl = string.Format(redirectUrl, "/");
            //    }
            //    else
            //    {
            //        redirectUrl = string.Format(redirectUrl, System.Web.HttpUtility.UrlEncode(string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Host, request.Url.PathAndQuery)));
            //    }


            //    var result = new ContentResult();
            //    result.Content = string.Format("<script type='text/javascript'>location.href = '{0}';</script>", redirectUrl);
            //    filterContext.Result = result;
            //}

            //if (request.Url.ToString().IndexOf("scourt.hunet.co.kr/sangsang", StringComparison.OrdinalIgnoreCase) > -1)
            //{
            //    filterContext.Result = new RedirectResult("/");
            //}
        }
    }
}
