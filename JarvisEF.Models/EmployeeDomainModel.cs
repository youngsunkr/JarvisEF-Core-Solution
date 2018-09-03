using System;
using System.ComponentModel.DataAnnotations;

namespace JarvisEF.Models
{
    public class EmployeeDomainModel : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
    }

    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        public string ExtraValue { get; set; }

        public string CurrentDate { get; set; }


    }

    public class EmployeeDomainModelWeb
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int ExtraValue { get; set; }
        public DateTime CurrentDate { get; set; }
    }

}
