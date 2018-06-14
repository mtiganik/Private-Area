using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Users.Models
{
    public class CompanyWorkerEditVM
    {
        public CompanyWorker CompanyWorker { get; set; }

        public SelectList WorkerPositionSelectList { get; set; }

        public int? fromProject { get; set; }
    }
}
