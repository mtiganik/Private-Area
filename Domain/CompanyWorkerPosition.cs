using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class CompanyWorkerPosition
    {
        public int CompanyWorkerPositionId { get; set; }

        public int PositionNameId { get; set; }
        [ForeignKey(nameof(PositionNameId))]
        [Display(Name = nameof(Resources.Domain.CompanyWorkerPosition.PositionName), ResourceType = typeof(Resources.Domain.CompanyWorkerPosition))]
        public MultiLangString PositionName { get; set; }


        public virtual List<CompanyWorker> CompanyWorkers { get; set; }
    }
}
