using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class ProjectType
    {
        public int ProjectTypeId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectTypeName), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectTypeNameEst), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeNameEst { get; set; }

        [MaxLength(300)]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectComments), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeComments { get; set; }

        [MaxLength(300)]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectCommentsEst), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeCommentsEst { get; set; }


    }
}
