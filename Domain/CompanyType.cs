using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class CompanyType
    {
        public int CompanyTypeId { get; set; }

        public int? CompanyTypeNameId { get; set; }
        [ForeignKey(nameof(CompanyTypeNameId))]
        [Display(Name = nameof(Resources.Domain.CompanyType.CompanyTypeName), ResourceType = typeof(Resources.Domain.CompanyType))]
        public MultiLangString CompanyTypeName { get; set; }

    }
}
