using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarvisEF.Service;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.FrontUI.Controllers
{
    public class BaseController : Controller
    {
        private ICacheProvider _cache = null;
        public BaseController()
        {
            //_cache = DependencyResolver.Current.GetService<ICacheProvider>();
        }

        //protected virtual LoginPrincipal LoggedUser
        //{
        //    get { return HttpContext.User as LoginPrincipal; }
        //}
        //
        //protected int GetUserId()
        //{
        //    int userId = -1;
        //    if (Request.IsAuthenticated)
        //    {
        //        userId = LoggedUser.UserId;
        //    }
        //    return userId;
        //}
    }
}