using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class ProjectsIndexViewModel
    {
        public Project SelectedProject { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<Position> Positions { get; set; }

        public int ProjectsId { get; set; }
    }
}
