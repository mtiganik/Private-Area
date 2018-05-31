using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public string UserName { get; set; }
        public IEnumerable<SelectListItem> ApplicationUsersList { get; set; }

        public string RoleName { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; } 


        public IEnumerable<SelectListItem> RolesForThisUser { get; set; }

        public string ResultMessage { get; set; }

    }
}
