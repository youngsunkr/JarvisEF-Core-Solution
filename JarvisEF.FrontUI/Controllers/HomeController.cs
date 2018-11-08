using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JarvisEF.FrontUI.Models;
using Microsoft.AspNetCore.Http;

namespace JarvisEF.FrontUI.Controllers
{
    public class HomeController : BaseController
    {
        //[OutputCache(Duration = 0, VaryByParam = "*")]
        public IActionResult Index()
        {
            // Drag & Drop 관련
            // https://blog.shibayan.jp/entry/20110702/1309532938
            // http://www.technolibrary.co.uk/Article/MVC_jQuery_Upload__NPOI


            // https://docs.microsoft.com/ko-kr/aspnet/core/fundamentals/app-state?view=aspnetcore-2.1
            // 위 페이지 보고 다시 확인 할 것

            // Wipe the uploaded files from the session.
            HttpContext.Session.SetString("uploads", "uploads");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
