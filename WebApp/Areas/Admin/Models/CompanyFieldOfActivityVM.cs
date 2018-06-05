using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class CompanyFieldOfActivityCreateEditVM
    {
        public CompanyFieldOfActivity CompanyFieldOfActivity {get; set;}

        public string ActivityName { get; set; }
    }
}
