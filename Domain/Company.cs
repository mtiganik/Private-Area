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
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string CompanyRegistrationName { get; set; }

        [MaxLength(200)]
        public string CompanyWebsite { get; set; }

        public int CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }

        public int CompanyFieldOfActivityId { get; set; }
        public CompanyFieldOfActivity CompanyFieldOfActivity { get; set; }

        public virtual List<CompanyWorker> CompanyWorkers { get; set; } = new List<CompanyWorker>();

        public virtual List<Contact> CompanyContacts { get; set; } = new List<Contact>();
    }
}
