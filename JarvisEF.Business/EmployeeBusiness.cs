using JarvisEF.Business.Interface;
using JarvisEF.Models;
using System;
using System.Collections.Generic;

namespace JarvisEF.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        public string GetEmployeeName(int EmpId)
        {
            return "Ashish" + EmpId;
        }

        public List<EmployeeDomainModel> GetAllEmployee()
        {
            List<EmployeeDomainModel> list = new List<EmployeeDomainModel>();

            list.Add(new EmployeeDomainModel { Name = "Ashish", EmployeeId = 1 });
            list.Add(new EmployeeDomainModel { Name = "Rob", EmployeeId = 2 });
            list.Add(new EmployeeDomainModel { Name = "Sara", EmployeeId = 3 });
            list.Add(new EmployeeDomainModel { Name = "Jack", EmployeeId = 4 });
            list.Add(new EmployeeDomainModel { Name = "Peter", EmployeeId = 5 });

            return list;
        }
    }
}
