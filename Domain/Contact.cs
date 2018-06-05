using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }

        public int ContactTypeId { get; set; }
        [Display(Name = nameof(Resources.Domain.Contact.ContactType), ResourceType = typeof(Resources.Domain.Contact))]
        public ContactType ContactType { get; set; }

        public string ApplicationUserId { get; set; }
        [Display(Name = nameof(Resources.Domain.Contact.ApplicationUser), ResourceType = typeof(Resources.Domain.Contact))]
        public ApplicationUser ApplicationUser { get; set; }

        public int? CompanyWorkerId { get; set; }
        [Display(Name = nameof(Resources.Domain.Contact.CompanyWorker), ResourceType = typeof(Resources.Domain.Contact))]
        public CompanyWorker CompanyWorker {get; set;}

        public int CompanyId { get; set; }
        [Display(Name = nameof(Resources.Domain.Contact.Company), ResourceType = typeof(Resources.Domain.Contact))]
        public Company Company { get; set; }

        public int ProjectId { get; set; }
        [Display(Name = nameof(Resources.Domain.Contact.Project), ResourceType = typeof(Resources.Domain.Contact))]
        public Project Project { get; set; }

        [Display(Name = nameof(Resources.Domain.Contact.IsNewContactNeeded), ResourceType = typeof(Resources.Domain.Contact))]
        public bool IsNewContactNeeded { get; set; }

        [Display(Name = nameof(Resources.Domain.Contact.ContactDate), ResourceType = typeof(Resources.Domain.Contact))]
        public DateTime ContactDate { get; set; }

        [Display(Name = nameof(Resources.Domain.Contact.NewContactDate), ResourceType = typeof(Resources.Domain.Contact))]
        public DateTime? NewContactDate { get; set; }

        [Display(Name = nameof(Resources.Domain.Contact.NewConactType), ResourceType = typeof(Resources.Domain.Contact))]
        public string NewContactType { get; set; }

        [MaxLength(400)]
        [Display(Name = nameof(Resources.Domain.Contact.Comments), ResourceType = typeof(Resources.Domain.Contact))]
        public string Comments { get; set; }

    }
}
