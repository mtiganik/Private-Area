using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class CompanyFieldOfActivity
    {
        public int CompanyFieldOfActivityId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyFieldOfActivity.ActivityName), ResourceType = typeof(Resources.Domain.CompanyFieldOfActivity))]
        public string ActivityName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyFieldOfActivity.ActivityNameEst), ResourceType = typeof(Resources.Domain.CompanyFieldOfActivity))]
        public string ActivityNameEst { get; set; }

    }
}
