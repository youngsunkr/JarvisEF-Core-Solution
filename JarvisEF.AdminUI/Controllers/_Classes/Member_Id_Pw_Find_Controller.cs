using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.AdminUI.Controllers._Classes
{
    public partial class MemberController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}