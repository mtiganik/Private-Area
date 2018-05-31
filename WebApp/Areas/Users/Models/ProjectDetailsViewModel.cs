using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class ProjectDetailsViewModel
    {
        public Project SelectedProject { get; set; }

        public SelectList CompaniesSelectList { get; set; }

        public IEnumerable<Position> PositionsList { get; set; }

        public IEnumerable<Contact> ContactsList { get; set; }
       // public IEnumerable<CompanyProject> CompanyProjects { get; set; }
    }
}
