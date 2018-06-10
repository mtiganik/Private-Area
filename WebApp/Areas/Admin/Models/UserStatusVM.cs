using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class UserStatusVM
    {
        public UserStatus UserStatus { get; set; }

        [Display(Name = nameof(Resources.Domain.UserStatus.UserStatusName), ResourceType = typeof(Resources.Domain.UserStatus))]
        public string UserStatusName { get; set; }
    }
}
