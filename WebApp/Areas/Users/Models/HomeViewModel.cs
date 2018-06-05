using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
    }
}
