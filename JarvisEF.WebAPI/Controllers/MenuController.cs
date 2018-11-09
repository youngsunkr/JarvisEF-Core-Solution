using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace JarvisEF.WebAPI.Controllers
{
    /// <summary>
    /// http://blog.naver.com/PostView.nhn?blogId=wolfre&logNo=221016951097&categoryNo=45&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=postView
    /// </summary>
    
    [ServiceFilter(typeof(AuthorizeFilter))]
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2" };
        }
    }
}