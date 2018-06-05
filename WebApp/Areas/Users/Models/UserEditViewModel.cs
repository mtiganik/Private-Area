using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class UserEditViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public SelectList DepartmentSelectList { get; set; }
    }
}
