using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class CompanyWorkerPositionVM
    {
        public CompanyWorkerPosition CompanyWorkerPosition { get; set; }

        [Display(Name = nameof(Resources.Domain.CompanyWorkerPosition.PositionName), ResourceType = typeof(Resources.Domain.CompanyWorkerPosition))]
        public string PositionName { get; set; }
    }
}
