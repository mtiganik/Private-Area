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
        public string ActivityName { get; set; }

        [MaxLength(100)]
        public string ActivityNameEst { get; set; }

    }
}
