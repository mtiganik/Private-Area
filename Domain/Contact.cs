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
        public ContactType ContactType {get; set;}

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int WorkerId { get; set; }
        
        public bool IsNewContactNeeded { get; set; }

        public DateTime ContactDate { get; set; }

        public DateTime NewContactDate { get; set; }

        public int NewContactType { get; set; }

        [MaxLength(400)]
        public string Comments { get; set; }

    }
}
