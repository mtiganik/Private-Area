using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class CompanyFieldOfActivityCreateEditVM
    {
        public CompanyFieldOfActivity CompanyFieldOfActivity {get; set;}

        [Display(Name = nameof(Resources.Domain.CompanyFieldOfActivity.ActivityName), ResourceType = typeof(Resources.Domain.CompanyFieldOfActivity))]
        public string ActivityName { get; set; }
    }
}
