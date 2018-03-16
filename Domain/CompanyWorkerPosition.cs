using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class CompanyWorkerPosition
    {
        public int CompanyWorkerPositionId { get; set; }

        [MaxLength(100)]
        public string PositionName { get; set; }

        [MaxLength(100)]
        public string PositionNameEst { get; set; }
    }
}
