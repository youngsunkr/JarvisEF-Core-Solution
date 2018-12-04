using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JarvisEF.Core.Web.Mvc.Filters
{
    /// <summary>
    /// https://docs.microsoft.com/ko-kr/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1
    /// </summary>
    public class LoginFilter : ActionFilterAttribute
    {       
        public bool IsPass = false;

        

    }
}