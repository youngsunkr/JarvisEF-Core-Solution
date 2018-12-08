using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JarvisEF.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.AdminUI.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }



        #region [[ PC-Web ]]
        public IActionResult MenuSetting()
        {
            return View();
        }

        //[HttpPut]
        //public async Task<ActionResult> UpdateOrder(IList<int> ids)
        //{
        //    try
        //    {
        //        await _repository.UpdateOrder(ids);
        //        return Json(new { @success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { @success = false });
        //    }
        //}

        //public async Task UpdateSorting(List<int> ids)
        //{
        //    for (int i = 0; i < ids.Count(); i++)
        //    {
        //        var id = ids[i];
        //        var slide = await Context.Slides.FirstOrDefaultAsync(e => e.Id == id);
        //        slide.SortOrder = i;
        //        await Context.SaveChangesAsync();
        //    }
        //}
        #endregion //[[ PC-Web ]]



        #region [[ Mobile Menu Setting]]

        public IActionResult MobileMenuSetting()
        {
            return View();
        }
        #endregion //[[ Mobile Menu Setting]]


        #region [[ Common ]]


        #endregion // [[ Common ]]



    }
}