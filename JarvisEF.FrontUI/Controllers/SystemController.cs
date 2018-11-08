using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.FrontUI.Controllers
{
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Auth()
        {
            return View();
        }
    }
}