using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarvisEF.Models;
using JarvisEF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.WebAPI.Controllers
{
    /// <summary>
    /// https://www.strathweb.com/2018/06/controllers-as-action-filters-in-asp-net-core-mvc/
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _repository;

        public MemberController(IMemberRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        //[HttpGet("{id}", Name = "GetContactById")]
        //public async Task<ActionResult<Member>> Get(int id)
        //{
        //    var contact = await _repository.Get(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(contact);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var deleted = await _repository.Get(id);
        //    if (deleted == null)
        //    {
        //        return NotFound();
        //    }

        //    await _repository.Delete(id);
        //    return NoContent();
        //}
    }
}