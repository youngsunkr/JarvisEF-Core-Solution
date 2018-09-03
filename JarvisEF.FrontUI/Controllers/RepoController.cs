using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarvisEF.Business.Interface;
using JarvisEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.FrontUI.Controllers
{
    public class RepoController : BaseController
    {
        IEmployeeBusiness _empBusiness;

        // oop principle: depend on the abstraction not on the concrete classes

        public RepoController(IEmployeeBusiness empBusiness)
        {
            _empBusiness = empBusiness;
        }

        // GET: Repo
        public ActionResult Index()
        {

            ViewBag.EmpName = _empBusiness.GetEmployeeName(254);

            List<EmployeeDomainModel> listDomain = _empBusiness.GetAllEmployee();

            listDomain.Add(new EmployeeDomainModel { EmployeeId = 1, Name = "Ashish" });
            listDomain.Add(new EmployeeDomainModel { EmployeeId = 2, Name = "Ajay" });

            List<EmployeeViewModel> listemployeeVM = new List<EmployeeViewModel>();

            AutoMapper.Mapper.Map(listDomain, listemployeeVM);

            //ViewBag["EmployeeList"] = listDomain;
            ViewBag.EmployeeList = listDomain;


            return View();
        }
    }
}