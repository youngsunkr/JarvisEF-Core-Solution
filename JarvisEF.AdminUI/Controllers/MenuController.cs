using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.AdminUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        #region [[ PC-Web ]]
        public IActionResult MenuSetting()
        {
            return View();
        } 
        #endregion //[[ PC-Web ]]



        #region [[ Mobile Menu Setting]]

        public IActionResult MobileMenuSetting()
        {
            return View();
        }
        #endregion //[[ Mobile Menu Setting]]


    }
}