using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class UsersIndexData
    {
        public ApplicationUser SelectedApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public string UserName { get; set; }
    }

    public class UsersEditVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public SelectList DepartmentSelectList { get; set; }
    }

}
