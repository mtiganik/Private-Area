using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class ContactTypeCreateEditVM
    {
        public ContactType ContactType { get; set; }

        public string ContactTypeName { get; set; }
    }
}
