using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using JarvisEF.Service;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.FrontUI.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICacheProvider _cache = null;
        public BaseController()
        {
            _cache = DependencyResolver.Current.GetService<ICacheProvider>();
        }
    }
}