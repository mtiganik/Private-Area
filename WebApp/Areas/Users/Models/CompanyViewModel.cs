using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class CompanyDetailsViewModel
    {
        public Company SelectedCompany { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        public Contact AddNewContact { get; set; }

        public SelectList WorkerPositionSelectList { get; set; }

        // for adding new contact
        public CompanyWorker AddNewWorker { get; set; }
        public SelectList CompanyWorkerSelectList { get; set; }
        public SelectList ProjectSelectList { get; set; }
        public SelectList ContactTypeSelectList { get; set; }
    }

    public class CompaniesCreateEditViewModel
    {
        public Company Company { get; set; }

        public SelectList CompanyFieldOfActivitesSelectList { get; set; }

        public SelectList CompanyTypesSelectList { get; set; }

        public int? fromProject { get; set; }

    }
}
