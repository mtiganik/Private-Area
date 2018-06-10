using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class ContactTypeCreateEditVM
    {
        public ContactType ContactType { get; set; }

        [Display(Name = nameof(Resources.Domain.ContactType.ContactTypeName), ResourceType = typeof(Resources.Domain.ContactType))]
        public string ContactTypeName { get; set; }
    }
}
