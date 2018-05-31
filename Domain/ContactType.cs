using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ContactType.ContactTypeName), ResourceType = typeof(Resources.Domain.ContactType))]
        public string ContactTypeName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ContactType.ContactTypeNameEst), ResourceType = typeof(Resources.Domain.ContactType))]
        public string ContactTypeNameEst { get; set; }
    }
}
