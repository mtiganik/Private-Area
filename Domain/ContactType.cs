using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        public int ContactTypeNameId { get; set; }

        [ForeignKey(nameof(ContactTypeNameId))]
        [Display(Name = nameof(Resources.Domain.ContactType.ContactTypeName), ResourceType = typeof(Resources.Domain.ContactType))]
        public MultiLangString ContactTypeName { get; set; }

    }
}
