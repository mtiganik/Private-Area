using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class CompaniesCreateEditViewModel
    {
        public Company Company { get; set; }

        public SelectList CompanyFieldOfActivitesSelectList { get; set; }

        public SelectList CompanyTypesSelectList { get; set; }

    }
}
