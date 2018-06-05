using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.Project.ProjectName), ResourceType = typeof(Resources.Domain.Project))]
        public string ProjectName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.Project.ProjectNameEst), ResourceType = typeof(Resources.Domain.Project))]
        public string ProjectNameEst { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(Resources.Domain.Project.ProjectStartDate), ResourceType = typeof(Resources.Domain.Project))]
        public DateTime ProjectStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(Resources.Domain.Project.ProjectEndDate), ResourceType = typeof(Resources.Domain.Project))]
        public DateTime ProjectEndDate { get; set; }

        public int ProjectTypeId { get; set; }
        [Display(Name = nameof(Resources.Domain.Project.ProjectType), ResourceType = typeof(Resources.Domain.Project))]
        public ProjectType ProjectType { get; set; }

        public virtual List<CompanyProject> CompanyProjects { get; set; } = new List<CompanyProject>();

        public virtual List<Position> Positions { get; set; } = new List<Position>();

    }
}
