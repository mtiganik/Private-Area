using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.Department.DepartmentName), ResourceType = typeof(Resources.Domain.Department))]
        public string DepartmentName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.Department.DepartmentNameEst), ResourceType = typeof(Resources.Domain.Department))]
        public string DepartmentNameEst { get; set; }

        public virtual List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
