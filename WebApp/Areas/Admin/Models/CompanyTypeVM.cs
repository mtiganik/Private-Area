using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class CompanyTypeCreateEditVM
    {
        public CompanyType CompanyType { get; set; }

        public string CompanyTypeName { get; set; }
    }
}
