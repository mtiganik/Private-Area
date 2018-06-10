using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class CompanyTypeCreateEditVM
    {
        public CompanyType CompanyType { get; set; }

        [Display(Name = nameof(Resources.Domain.CompanyType.CompanyTypeName), ResourceType = typeof(Resources.Domain.CompanyType))]
        public string CompanyTypeName { get; set; }
    }
}
