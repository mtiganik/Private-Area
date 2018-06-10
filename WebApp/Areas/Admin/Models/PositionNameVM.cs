using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class PositionNameVM
    {
        public PositionName PositionName { get; set; }

        [Display(Name = nameof(Resources.Domain.PositionName.PositionNameName), ResourceType = typeof(Resources.Domain.PositionName))]
        public string PositionNameName { get; set; }
    }
}
