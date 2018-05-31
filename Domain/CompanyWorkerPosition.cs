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
        [Display(Name = nameof(Resources.Domain.CompanyWorkerPosition.PositionName), ResourceType = typeof(Resources.Domain.CompanyWorkerPosition))]
        public string PositionName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyWorkerPosition.PositionNameEst), ResourceType = typeof(Resources.Domain.CompanyWorkerPosition))]
        public string PositionNameEst { get; set; }

        public virtual List<CompanyWorker> CompanyWorkers { get; set; }
    }
}
