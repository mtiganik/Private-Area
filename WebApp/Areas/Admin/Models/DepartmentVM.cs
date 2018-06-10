using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class DepartmentVM
    {
        public Department Department { get; set; }

        [Display(Name = nameof(Resources.Domain.Department.DepartmentName), ResourceType = typeof(Resources.Domain.Department))]
        public string DepartmentName { get; set; }
    }
}
