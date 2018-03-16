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
        public string ContactTypeName { get; set; }

        [MaxLength(100)]
        public string ContactTypeNameEst { get; set; }
    }
}
