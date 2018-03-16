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
        public string CompanyTypeName { get; set; }

        [MaxLength(100)]
        public string CompanyTypeNameEst { get; set; }
    }
}
