using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class CompanyWorker
    {
        [Display(Name = nameof(Resources.Domain.CompanyWorker.CompanyWorkerId), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public int CompanyWorkerId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyWorker.WorkerName), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public string WorkerName { get; set; }

        public int CompanyWorkerPositionId { get; set; }
        [Display(Name = nameof(Resources.Domain.CompanyWorker.Position), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public CompanyWorkerPosition CompanyWorkerPosition { get; set; }


        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyWorker.WorkerPhone), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public string WorkerPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.CompanyWorker.WorkerEmail), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public string WorkerEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = nameof(Resources.Domain.CompanyWorker.EntryAdded), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public DateTime EntryAdded { get; set; }

        public int CompanyId { get; set; }
        [Display(Name = nameof(Resources.Domain.CompanyWorker.Company), ResourceType = typeof(Resources.Domain.CompanyWorker))]
        public Company Company { get; set; }

        //public virtual List<Contact> Contacts { get; set; } = new List<Contact>();



    }
}
