using JarvisEF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Business.Interface
{
    public interface IEmployeeBusiness
    {
        string GetEmployeeName(int EmpId);
        List<EmployeeDomainModel> GetAllEmployee();
    }
}
