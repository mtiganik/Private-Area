using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class ProjectTypesVM
    {
        public ProjectType ProjectType { get; set; }

        [Display(Name = nameof(Resources.Domain.ProjectType.ProjectComments), ResourceType = typeof(Resources.Domain.ProjectType))]
        public string ProjectTypeComments { get; set; }
    }
}
