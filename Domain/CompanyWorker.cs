using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class CompanyWorker
    {
        public int CompanyWorkerId { get; set; }

        [MaxLength(100)]
        public string WorkerName { get; set; }

        public int CompanyWorkerPositionId { get; set; }
        public CompanyWorkerPosition CompanyWorkerPosition { get; set; }

        [MaxLength(100)]
        public string WorkerPhone { get; set; }

        [MaxLength(100)]
        public string WorkerEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EntryAdded { get; set; }

        public int CompanyId { get; set; }


    }
}
