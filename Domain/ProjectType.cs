using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ProjectType
    {
        public int ProjectTypeId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectTypeName), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeName { get; set; }

        public int ProjectTypeCommentsId { get; set; }

        [ForeignKey(nameof(ProjectTypeCommentsId))]
        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectComments), ResourceType = typeof(Resources.Domain.ProjectType))]
        public MultiLangString ProjectTypeComments { get; set; }


    }
}
