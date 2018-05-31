using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Company
    {
        public int CompanyId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.Company.CompanyName), ResourceType = typeof(Resources.Domain.Company))]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(Resources.Domain.Company.CompanyRegistrationName), ResourceType = typeof(Resources.Domain.Company))]
        public string CompanyRegistrationName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(Resources.Domain.Company.CompanyWebsite), ResourceType = typeof(Resources.Domain.Company))]
        public string CompanyWebsite { get; set; }

        public int CompanyTypeId { get; set; }
        [Display(Name = nameof(Resources.Domain.Company.CompanyType), ResourceType = typeof(Resources.Domain.Company))]
        public CompanyType CompanyType { get; set; }

        public int CompanyFieldOfActivityId { get; set; }
        [Display(Name = nameof(Resources.Domain.Company.CompanyFieldOfActivities), ResourceType = typeof(Resources.Domain.Company))]
        public CompanyFieldOfActivity CompanyFieldOfActivity { get; set; }

        [Display(Name = nameof(Resources.Domain.Company.CompanyProjects), ResourceType = typeof(Resources.Domain.Company))]
        public virtual List<CompanyProject> CompanyProjects { get; set; } = new List<CompanyProject>();

        [Display(Name = nameof(Resources.Domain.Company.CompanyWorkers), ResourceType = typeof(Resources.Domain.Company))]
        public virtual List<CompanyWorker> CompanyWorkers { get; set; } = new List<CompanyWorker>();

        [Display(Name = nameof(Resources.Domain.Company.CompanyContacts), ResourceType = typeof(Resources.Domain.Company))]
        public virtual List<Contact> CompanyContacts { get; set; } = new List<Contact>();
    }
}
