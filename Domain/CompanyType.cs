using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class CompanyType
    {
        public int CompanyTypeId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyType.CompanyTypeName), ResourceType = typeof(Resources.Domain.CompanyType))]
        public string CompanyTypeName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyType.CompanyTypeNameEst), ResourceType = typeof(Resources.Domain.CompanyType))]
        public string CompanyTypeNameEst { get; set; }
    }
}
