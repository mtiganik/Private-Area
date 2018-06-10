using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class ProjectsIndexData
    {
        public Project SelectedProject { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public int ProjectId { get; set; }

    }

    public class ProjectsCreateEditVM
    {
        public Project Project { get; set; }

        public SelectList ProjectTypeSelectList { get; set; }
    }
}
