using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.AdminUI.Controllers
{
    /// <summary>
    /// https://www.youtube.com/watch?v=23pcCRvysX0
    /// </summary>
    public class TaskBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(int[] locationId)
        //{
        //    HolidayLocationsEntities entities = new HolidayLocationsEntities();
        //    int preference = 1;
        //    foreach (int id in locationId)
        //    {
        //        var holidayLocation = entities.HolidayLocations.Find(id);
        //        holidayLocation.Preference = preference;
        //        entities.SaveChanges();
        //        preference += 1;
        //    }
        //
        //    return View(entities.HolidayLocations.OrderBy(p => p.Preference).ToList());
        //}
    }
}