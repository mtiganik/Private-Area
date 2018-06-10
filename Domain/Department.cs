using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public int DepartmentNameId { get; set; }
        [ForeignKey(nameof(DepartmentNameId))]
        [Display(Name = nameof(Resources.Domain.Department.DepartmentName), ResourceType = typeof(Resources.Domain.Department))]
        public MultiLangString DepartmentName { get; set; }

        public virtual List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
