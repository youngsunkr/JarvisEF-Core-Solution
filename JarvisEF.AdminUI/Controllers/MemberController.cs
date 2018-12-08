using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarvisEF.Models;
using JarvisEF.Repository;
using JarvisEF.Repository.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.AdminUI.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMemberRepository _repository;

        public MemberController(IMemberRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("{id}", Name = "GetContactById")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                var contact = await unitOfWork.Member.Get<Member>(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            //var contact = await _repository.Get(id);
            //if (contact == null)
            //{
            //    return NotFound();
            //}
            //
            //return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                var deleted = await unitOfWork.Member.Get<Member>(id);
                if (deleted == null)
                {
                    return NotFound();
                }

                await unitOfWork.Member.Delete<Member>(id);
                return NoContent();
            }
        }
    }
}