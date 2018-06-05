using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class CompanyFieldOfActivity
    {
        public int CompanyFieldOfActivityId { get; set; }

        public int ActivityNameId { get; set; }
        [ForeignKey(nameof(ActivityNameId))]
        [Display(Name = nameof(Resources.Domain.CompanyFieldOfActivity.ActivityName), ResourceType = typeof(Resources.Domain.CompanyFieldOfActivity))]
        public MultiLangString ActivityName { get; set; }


    }
}
